using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ATMImitationWebApp.Models
{
    public class BankClientsDbInitializer:DropCreateDatabaseAlways<ClientContext>
    {
        protected override void Seed(ClientContext context)
        {
            Client ivan = new Client { FullName = "Иван Иванович Иванов"};
            Client darhan = new Client { FullName = "Дархан Ахметович Сагитов" };
            Client pavel = new Client { FullName = "Павел Владимирович Павлов" };

            context.Clients.AddRange(new Client[] {ivan,darhan,pavel});

            context.Cards.Add(new Card { PinCode = 3421, CardNumber = "1231-3233-2424-2424", Balance = 20000.332m, Client = ivan});
            context.Cards.Add(new Card { PinCode = 2323, CardNumber = "1234-5757-2524-2464", Balance = 340000.235m, Client = darhan });
            context.Cards.Add(new Card { PinCode = 5555, CardNumber = "1251-3753-8654-8655", Balance = 124000.442m, Client = pavel });

            base.Seed(context);
        }
    }
}