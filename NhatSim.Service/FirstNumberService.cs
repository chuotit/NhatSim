using System.Collections.Generic;
using NhatSim.Data.Infrastructure;
using NhatSim.Data.Repositories;
using NhatSim.Model.Models;

namespace NhatSim.Service
{
    public interface IFirstNumberService
    {
        FirstNumber Add(FirstNumber firstNumber);

        void Update(FirstNumber firstNumber);

        FirstNumber Delete(string id);

        IEnumerable<FirstNumber> GetAll();

        FirstNumber GetById(string id);

        IEnumerable<FirstNumber> GetByNetwork(int id);

        void SaveChanges();
    }

    public class FirstNumberService : IFirstNumberService
    {
        private IFirstNumberRepository _firstNumberRepository;
        private IUnitOfWork _unitOfWork;

        public FirstNumberService(IFirstNumberRepository firstNumberRepository, IUnitOfWork unitOfWork)
        {
            this._firstNumberRepository = firstNumberRepository;
            this._unitOfWork = unitOfWork;
        }

        public FirstNumber Add(FirstNumber firstNumber)
        {
            return _firstNumberRepository.Add(firstNumber);
        }

        public void Update(FirstNumber firstNumber)
        {
            _firstNumberRepository.Update(firstNumber);
        }

        public FirstNumber Delete(string id)
        {
            return _firstNumberRepository.Delete(id);
        }

        public IEnumerable<FirstNumber> GetAll()
        {
            return _firstNumberRepository.GetAll(new string[] { "SimNetwork" });
        }

        public FirstNumber GetById(string id)
        {
            return _firstNumberRepository.GetSingleById(id);
        }

        public IEnumerable<FirstNumber> GetByNetwork(int id)
        {
            return _firstNumberRepository.GetMulti(x => x.NetworkId == id, new string[] { "SimNetwork" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}