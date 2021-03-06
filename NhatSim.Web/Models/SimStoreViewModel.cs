﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhatSim.Web.Models
{
    public class SimStoreViewModel
    {
        public string SimId { set; get; }

        public string SimName { set; get; }

        public int NetWorkId { set; get; }
        public virtual SimNetworkViewModel SimNetwork { set; get; }

        public string AgentId { set; get; }
        public virtual AgentViewModel Agent { set; get; }

        public int Discount { set; get; }
        
        public decimal Price { set; get; }

        public DateTime? CreateDate { set; get; }

        public DateTime? UpdateDate { set; get; }

        public bool Status { set; get; }
    }
}