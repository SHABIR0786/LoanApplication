﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.Configuration
{
   public class SMTPOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
