﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OneHealth.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
    }
}
