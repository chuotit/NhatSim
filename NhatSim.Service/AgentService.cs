using System.Collections.Generic;
using NhatSim.Data.Infrastructure;
using NhatSim.Data.Repositories;
using NhatSim.Model.Models;

namespace NhatSim.Service
{
    public interface IAgentService
    {
        Agent Add(Agent agent);

        void Update(Agent agent);

        Agent Delete(int id);

        IEnumerable<Agent> GetAll();

        IEnumerable<Agent> GetAll(string keyword);

        Agent GetById(int id);
        
        void SaveChanges();
    }

    internal class AgentService : IAgentService
    {
        private IAgentRepository _agentRepository;
        private IUnitOfWork _unitOfWork;

        public AgentService(IAgentRepository agentRepository, IUnitOfWork unitOfWork)
        {
            this._agentRepository = agentRepository;
            this._unitOfWork = unitOfWork;
        }

        public Agent Add(Agent agent)
        {
            return _agentRepository.Add(agent);
        }

        public void Update(Agent agent)
        {
            _agentRepository.Update(agent);
        }

        public Agent Delete(int id)
        {
            return _agentRepository.Delete(id);
        }

        public IEnumerable<Agent> GetAll()
        {
            return _agentRepository.GetAll();
        }

        public IEnumerable<Agent> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
                return _agentRepository.GetMulti(x => x.Name.Contains(keyword) || x.Address.Contains(keyword) || x.Email.Contains(keyword) || x.Hotline.Contains(keyword));
            else
                return _agentRepository.GetAll();

        }

        public Agent GetById(int id)
        {
            return _agentRepository.GetSingleById(id);
        }
        
        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}