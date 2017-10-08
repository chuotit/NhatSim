using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NhatSim.Data.Infrastructure;
using NhatSim.Data.Repositories;
using NhatSim.Model.Models;

namespace NhatSim.Service
{
    public interface ISimStoreService
    {
        SimStore Add(SimStore simStore);

        void Update(SimStore simStore);

        SimStore Delete(string id);

        IEnumerable<SimStore> GetAll();

        SimStore GetById(string id);

        IEnumerable<SimStore> GetByNetwork(int id);

        void SaveChanges();

        IEnumerable<SimStore> SearchSimByOptions(Expression<Func<SimStore, bool>> where);
    }

    public class SimStoreService : ISimStoreService
    {
        private ISimStoreRepository _simStoreRepository;
        private IUnitOfWork _unitOfWork;

        public SimStoreService(ISimStoreRepository simStoreRepository, IUnitOfWork unitOfWork)
        {
            this._simStoreRepository = simStoreRepository;
            this._unitOfWork = unitOfWork;
        }

        public SimStore Add(SimStore simStore)
        {
            return _simStoreRepository.Add(simStore);
        }

        public void Update(SimStore simStore)
        {
            _simStoreRepository.Update(simStore);
        }

        public SimStore Delete(string id)
        {
            return _simStoreRepository.Delete(id);
        }

        public IEnumerable<SimStore> GetAll()
        {
            return _simStoreRepository.GetAll(new string[] { "SimNetwork", "Agent" });
        }

        public SimStore GetById(string id)
        {
            return _simStoreRepository.GetSingleById(id);
        }

        public IEnumerable<SimStore> GetByNetwork(int id)
        {
            return _simStoreRepository.GetMulti(x => x.NetWorkId == id, new string[] { "SimNetwork" });
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<SimStore> SearchSimByOptions(Expression<Func<SimStore, bool>> where)
        {
            var query = _simStoreRepository.GetMulti(where, new string[] { "SimNetwork", "Agent" });

            return query;
        }
    }
}
