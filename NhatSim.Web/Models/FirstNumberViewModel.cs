using System;
using System.Collections.Generic;

namespace NhatSim.Web.Models
{
    public class FirstNumberViewModel
    {
        public string Id { set; get; }

        public int NetworkId { set; get; }
        public virtual SimNetworkViewModel SimNetwork { set; get; }

        public string FirstNumberName { set; get; }

        public string Description { set; get; }

        public string Alias { set; get; }

        public Boolean HomeFlag { set; get; }

        public virtual IEnumerable<SimStoreViewModel> SimStores { set; get; }

        public string MetaDescription { set; get; }

        public string MetaKeyword { set; get; }

        public DateTime? CreateDate { set; get; }

        public string CreateBy { set; get; }

        public DateTime? UpdateDate { set; get; }

        public string UpdateBy { set; get; }

        public bool Status { set; get; }

        public int? DisplayOrder { set; get; }
    }
}