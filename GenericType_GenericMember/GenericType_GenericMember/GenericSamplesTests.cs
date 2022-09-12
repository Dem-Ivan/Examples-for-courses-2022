using GenericType_GenericMember.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericType_GenericMember
{
    public class GenericSamplesTests
    {
        [Fact]
        public void GenericСonstraintTest()
        {
            //Arrange
            var notificationService = new NotificationService<Player>();
            var olga = new Player 
            {
                Name = "Olga",
                Number = 2,
                PhoneNumber = 77812332
            };


            notificationService.SendMessage(olga);

        }

        [Fact]
        public void GenericСonstraintWithInterfaceTest()
        {
            //Arrange
            var notificationService = new NotificationService<IPerson>();
           
            var olga = new Player
            {
                Name = "Olga",
                Number = 2,
                PhoneNumber = 77812332
            };

            var sergeyIvanovic = new Trainer
            {
                Name = "Sergey Ivanovic",
                TeamName = "Spartac",
                PhoneNumber = 77922144
            };

            var cristyna = new Cheerleader
            {
                Name = "Cristyna",                
                PhoneNumber = 77922177
            };

            var people = new List<IPerson> 
            {
                olga,
                sergeyIvanovic,
                cristyna
            };


            //Act
            foreach (var person in people)
            {
                notificationService.SendMessage(person);
            }

            
        }

        [Fact]
        public void GenericMethodTest()
        {
            //Arrange
            var notificationService = new NotificationService<Player>();
            var cristyna = new Cheerleader
            {
                Name = "Cristyna",               
                PhoneNumber = 77922177
            };
            var olga = new Player
            {
                Name = "Olga",
                Number = 2,
                PhoneNumber = 77812332
            };

            notificationService.SendBonusAnons(cristyna);
            notificationService.SendBonusAnons(olga);
        }       
    }
}
