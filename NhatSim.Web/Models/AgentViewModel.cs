using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhatSim.Web.Models
{
    public class AgentViewModel
    {
        public string Id { set; get; }

        public string Name { set; get; }

        public string Website { set; get; }

        public string Email { set; get; }

        public string Hotline { set; get; }

        public string Address { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }

        public virtual IEnumerable<AgentLevelViewModel> AgentLevels { set; get; }

        public virtual IEnumerable<SimStoreViewModel> SimStores { set; get; }
    }
}