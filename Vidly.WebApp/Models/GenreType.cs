﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.WebApp.Models
{
    public class GenreType
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}