using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ATMImitationWebApp.Models
{
    public class ClientContext:DbContext
    {
        public ClientContext() : base("ClientContext") { }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}