using System;
using NhatSim.Model.Models;
using NhatSim.Web.Models;

namespace NhatSim.Web.Infrastructure.Extensions
{
    internal static class EntityExtensions
    {
        public static void UpdateSimNetwork(this SimNetwork simNetwork, SimNetworkViewModel simNetworkViewModel)
        {
            simNetwork.Id = simNetworkViewModel.Id;
            simNetwork.Name = simNetworkViewModel.Name;
            simNetwork.Alias = simNetworkViewModel.Alias;
            simNetwork.Image = simNetworkViewModel.Image;
            simNetwork.Description = simNetworkViewModel.Description;
            simNetwork.MetaKeyword = simNetworkViewModel.MetaKeyword;
            simNetwork.MetaDescription = simNetworkViewModel.MetaDescription;
            simNetwork.HomeFlag = simNetworkViewModel.HomeFlag;
            simNetwork.CreateDate = simNetworkViewModel.CreateDate;
            simNetwork.CreateBy = simNetworkViewModel.CreateBy;
            simNetwork.UpdateDate = simNetworkViewModel.UpdateDate;
            simNetwork.UpdateBy = simNetworkViewModel.UpdateBy;
            simNetwork.Status = simNetworkViewModel.Status;
            simNetwork.DisplayOrder = simNetworkViewModel.DisplayOrder;
        }

        public static void UpdateFirstNumber(this FirstNumber firstNumber, FirstNumberViewModel firstNumberViewModel)
        {
            firstNumber.Id = firstNumberViewModel.Id;
            firstNumber.NetworkId = firstNumberViewModel.NetworkId;
            firstNumber.FirstNumberName = firstNumberViewModel.FirstNumberName;
            firstNumber.Description = firstNumberViewModel.Description;
            firstNumber.Alias = firstNumberViewModel.Alias;
            firstNumber.HomeFlag = firstNumberViewModel.HomeFlag;
            firstNumber.MetaDescription = firstNumberViewModel.MetaDescription;
            firstNumber.MetaKeyword = firstNumberViewModel.MetaKeyword;
            firstNumber.CreateDate = firstNumberViewModel.CreateDate;
            firstNumber.CreateBy = firstNumberViewModel.CreateBy;
            firstNumber.UpdateDate = firstNumberViewModel.UpdateDate;
            firstNumber.UpdateBy = firstNumberViewModel.UpdateBy;
            firstNumber.Status = firstNumberViewModel.Status;
            firstNumber.DisplayOrder = firstNumberViewModel.DisplayOrder;
        }

        public static void UpdateSimStore(this SimStore simStore, SimStoreViewModel simStoreViewModel)
        {
            simStore.SimId = simStoreViewModel.SimId;
            simStore.SimName = simStoreViewModel.SimName;
            simStore.NetWorkId = simStoreViewModel.NetWorkId;
            simStore.AgentId = simStoreViewModel.AgentId;
            simStore.Price = simStoreViewModel.Price;
            simStore.Discount = simStoreViewModel.Discount;
            simStore.CreateDate = simStoreViewModel.CreateDate;
            simStore.UpdateDate = simStoreViewModel.UpdateDate;
            simStore.Status = simStoreViewModel.Status;
        }

        public static void UpdateAgent(this Agent agent, AgentViewModel agentViewModel)
        {
            agent.Id = agentViewModel.Id;
            agent.Name = agentViewModel.Name;
            agent.Hotline = agentViewModel.Hotline;
            agent.Address = agentViewModel.Address;
            agent.Website = agentViewModel.Website;
            agent.Email = agentViewModel.Email;
            agent.CreateDate = agentViewModel.CreateDate;
            agent.CreateBy = agentViewModel.CreateBy;
            agent.UpdateDate = agentViewModel.UpdateDate;
            agent.UpdateBy = agentViewModel.UpdateBy;
            agent.Status = agentViewModel.Status;
            agent.DisplayOrder = agentViewModel.DisplayOrder;
        }

        public static void UpdateAgentLevel(this AgentLevel agentLevel, AgentLevelViewModel agentLevelViewModel)
        {
            agentLevel.Id = agentLevelViewModel.Id;
            agentLevel.AgentId = agentLevelViewModel.AgentId;
            agentLevel.Name = agentLevelViewModel.Name;
            agentLevel.PriceFrom = agentLevelViewModel.PriceFrom;
            agentLevel.PriceFrom = agentLevelViewModel.PriceFrom;
            agentLevel.PriceTo = agentLevelViewModel.PriceTo;
            agentLevel.Percent = agentLevelViewModel.Percent;
            agentLevel.CreateDate = agentLevelViewModel.CreateDate;
            agentLevel.CreateBy = agentLevelViewModel.CreateBy;
            agentLevel.UpdateDate = agentLevelViewModel.UpdateDate;
            agentLevel.UpdateBy = agentLevelViewModel.UpdateBy;
            agentLevel.DisplayOrder = agentLevelViewModel.DisplayOrder;
        }
    }
}