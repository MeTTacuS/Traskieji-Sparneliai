﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WTService.Models
{
    public class Person
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Bitmap image { get; set; }
    }
}