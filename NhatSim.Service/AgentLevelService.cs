using System.Collections.Generic;
using NhatSim.Data.Infrastructure;
using NhatSim.Data.Repositories;
using NhatSim.Model.Models;

namespace NhatSim.Service
{
    public interface IAgentLevelService
    {
        AgentLevel Add(AgentLevel agentLevel);

        void Update(AgentLevel agentLevel);

        AgentLevel Delete(int id);

        IEnumerable<AgentLevel> GetAll();

        AgentLevel GetById(int id);

        IEnumerable<AgentLevel> GetByAgentId(string id);

        void SaveChanges();
    }

    internal class AgentLevelService : IAgentLevelService
    {
        private IAgentLevelRepository _agentLevelRepository;
        private IUnitOfWork _unitOfWork;

        public AgentLevelService(IAgentLevelRepository agentLevelRepository, IUnitOfWork unitOfWork)
        {
            this._agentLevelRepository = agentLevelRepository;
            this._unitOfWork = unitOfWork;
        }

        public AgentLevel Add(AgentLevel agentLevel)
        {
            return _agentLevelRepository.Add(agentLevel);
        }

        public void Update(AgentLevel agentLevel)
        {
            _agentLevelRepository.Update(agentLevel);
        }

        public AgentLevel Delete(int id)
        {
            return _agentLevelRepository.Delete(id);
        }

        public IEnumerable<AgentLevel> GetAll()
        {
            return _agentLevelRepository.GetAll();
        }

        public AgentLevel GetById(int id)
        {
            return _agentLevelRepository.GetSingleById(id);
        }

        public IEnumerable<AgentLevel> GetByAgentId(string id)
        {
            return _agentLevelRepository.GetMulti(x => x.AgentID == id.ToString());
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}