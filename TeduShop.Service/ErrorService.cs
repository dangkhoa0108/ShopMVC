using System;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Service
{
    public interface IErrorService
    {
        Error CreateError(Error error);
        void Save();
    }
    public class ErrorService:IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _errorRepository = errorRepository;
        }
        public Error CreateError(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
