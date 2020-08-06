﻿using Application.Helpers;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
using Elect.Mapper.AutoMapper.IQueryableUtils;
using Elect.Mapper.AutoMapper.ObjUtils;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IFileService
    {
        Task<FileModel> Upload(FileCreateModel model);
        Task<FileModel[]> Upload(FileCreateModel[] models);
    }

    [ScopedDependency(ServiceType = typeof(IFileService))]
    public class FileService : IFileService
    {
        private readonly IFileHelper _fileHelper;
        private readonly IGenericRepo<FileEntity> _fileRepo;
        private readonly IUnitOfWork _unitOfWork;
        public FileService(IFileHelper fileHelper, IGenericRepo<FileEntity> fileRepo, IUnitOfWork unitOfWork)
        {
            _fileHelper = fileHelper;
            _fileRepo = fileRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<FileModel> Upload(FileCreateModel model)
        {
            var savedFileModel = await _fileHelper.Resize(model.Base64);
            var entity = new FileEntity
            {
                FileName = savedFileModel.FileName,
                Url = savedFileModel.Url
            };

            _fileRepo.Add(entity);
            _unitOfWork.Commit();

            return entity.MapTo<FileModel>();
        }

        public async Task<FileModel[]> Upload(FileCreateModel[] models)
        {
            var files = new List<FileHelperModel>();

            foreach (var model in models)
            {
                files.Add(await _fileHelper.Resize(model.Base64));
            }

            var entities = files.Select(x => new FileEntity
            {
                FileName = x.FileName,
                Url = x.Url
            }).ToArray();

            _fileRepo.Add(entities);
            _unitOfWork.Commit();

            return entities.AsQueryable().QueryTo<FileModel>().ToArray();
        }
    }
}