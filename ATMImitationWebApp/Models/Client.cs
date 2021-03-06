﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMImitationWebApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual Card Card { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

        public Client()
        {
            Transactions = new List<Transaction>();
        }
    }
}