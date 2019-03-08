using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATMImitationWebApp.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get;set; }
        public Decimal Summa { get; set; }

        public int ClientId { get; set; }
        virtual public Client Client { get; set; }
    }
}