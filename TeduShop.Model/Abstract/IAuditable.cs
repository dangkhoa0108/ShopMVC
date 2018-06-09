using System;
using System.ComponentModel.DataAnnotations;

namespace TeduShop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdateBy { get; set; }

        [MaxLength(256)]
        string MetaKeyword { get; set; }

        [MaxLength(256)]
        string MetaDescription { get; set; }

        bool Status { get; set; }
    }
}