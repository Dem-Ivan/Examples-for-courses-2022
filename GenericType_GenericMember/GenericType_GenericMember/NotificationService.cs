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
            string mesageText = $"Уважаемый {item.Name}. Завтра в 13:01 состоится матч... .";

            // отправка сообщения по номеру item.PhoneNumber;
        }

        public void SendBonusAnons<K>(in K item) where K : Cheerleader
        {
            string mesageText = $"Уважаемый {item.Name}, вы получили возможность бесплатно посетить игру...";
            
            // отправка сообщения по номеру item.PhoneNumber;
        }
    }
}
