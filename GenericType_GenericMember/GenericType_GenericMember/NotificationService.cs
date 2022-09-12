using GenericType_GenericMember.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericType_GenericMember
{
    public class NotificationService<T> where T : IPerson 
    {
        public void SendMessage(in T item)
        {
            string mesageText = $"Уважаемый {item.Name}. Завтра в 13:01 состается матч... .";

            // отправика сообщения по номеру item.PhoneNumber;
        }

        public void SendBonusAnons<K>(in K item) where K : Cheerleader
        {
            string mesageText = $"Уважаемый {item.Name}, вы получили возможность басплатно поситить игру...";
            item.Name = "324r";
            // отправика сообщения по номеру item.PhoneNumber;
        }
    }
}
