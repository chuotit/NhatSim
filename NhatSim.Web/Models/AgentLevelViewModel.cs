using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhatSim.Web.Models
{
    public class AgentLevelViewModel
    {
        public int Id { set; get; }

        public string AgentId { set; get; }

        private AgentViewModel Agent { set; get; }

        public string Name { set; get; }

        public decimal? PriceFrom { set; get; }

        public decimal? PriceTo { set; get; }

        public int Percent { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public int? DisplayOrder { set; get; }
    }
}