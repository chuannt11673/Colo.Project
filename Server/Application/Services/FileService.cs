using Application.Helpers;
using Application.Models;
using Core.Entities;
using Elect.DI.Attributes;
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

        public Task<FileModel> Upload(FileCreateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
