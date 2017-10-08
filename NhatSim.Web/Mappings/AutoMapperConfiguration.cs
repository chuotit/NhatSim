using AutoMapper;
using NhatSim.Model.Models;
using NhatSim.Web.Models;

namespace NhatSim.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Agent, AgentViewModel>();

            Mapper.CreateMap<AgentLevel, AgentLevelViewModel>();

            Mapper.CreateMap<FirstNumber, FirstNumberViewModel>();

            Mapper.CreateMap<SimNetwork, SimNetworkViewModel>();

            Mapper.CreateMap<SimStore, SimStoreViewModel>();
        }
    }
}