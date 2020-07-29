using Application.Helpers;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
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
    }
}
