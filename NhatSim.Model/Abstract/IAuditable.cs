using System;

namespace NhatSim.Model.Abstract
{
    public interface IAuditable
    {
        string MetaDescription { set; get; }
        string MetaKeyword { set; get; }

        DateTime? CreateDate { set; get; }
        string CreateBy { set; get; }

        DateTime? UpdateDate { set; get; }
        string UpdateBy { set; get; }

        bool Status { set; get; }

        int? DisplayOrder { set; get; }
    }
}