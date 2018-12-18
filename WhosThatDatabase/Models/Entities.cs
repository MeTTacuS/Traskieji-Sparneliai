﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WhosThatDatabase.Models
{
    public class LoginInfo
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
    }

    public class UserInfo
    {
        [Key]
        public int ID { get; set; }
        public int Points { get; set; }
        public byte[] ImageByteArray { get; set; }
    }

    public class WhoSawWho
    {
        [Key]
        public int WhoSawID { get; set; }
        public int WasSeenID { get; set; }
        public string DateTime { get; set; }
    }
}