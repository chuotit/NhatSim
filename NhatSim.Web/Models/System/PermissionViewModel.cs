﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhatSim.Web.Models
{
    public class PermissionViewModel
    {

        public int ID { get; set; }


        public string RoleId { get; set; }

        public string FunctionId { get; set; }

        public bool CanCreate { set; get; }

        public bool CanRead { set; get; }

        public bool CanUpdate { set; get; }

        public bool CanDelete { set; get; }

        public AppRoleViewModel AppRole { get; set; }

        public FunctionViewModel Function { get; set; }
    }
}