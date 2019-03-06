using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMImitationWebApp.Models
{
    public class Card
    {
        [Key]
        [ForeignKey("Client")]
        public int Id { get; set; }                  
        
        public int PinCode { get; set; }        
        public string CardNumber { get; set; }
        public Decimal Balance { get; set; }

        public Client Client { get; set; }
    }
}