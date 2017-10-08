﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhatSim.Model.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int Id { set; get; }

        public string Message { set; get; }

        public string StackTrace { set; get; }

        public DateTime CreateDate { set; get; }
    }
}