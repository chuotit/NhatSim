﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhatSim.Model.Models
{
    [Table("AppRoleGroups")]
    public class AppRoleGroup
    {
        [Key]
        [Column(Order = 1)]
        public int GroupId { set; get; }

        [Column(Order = 2)]
        [StringLength(128)]
        [Key]
        public string RoleId { set; get; }

        [ForeignKey("RoleId")]
        public virtual AppRole AppRole { set; get; }

        [ForeignKey("GroupId")]
        public virtual AppGroup AppGroup { set; get; }
    }
}