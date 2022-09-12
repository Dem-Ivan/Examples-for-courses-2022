using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ExceptionHandling
{
    public class StorageTests
    {
        [Fact]
        public void AddPlayerWithoutNumber_throw_NumberRestrictionException()
        {
            var playerStorage = new Storage();
            var olga = new Player 
            {
                //Name = "Olga",//3
                Number = 333
            };

            //playerStorage.AddClient(olga);//1

            try//2
            {
                playerStorage.AddClient(olga);
            }
            catch (NumberRestrictionException e)
            {
                Assert.Equal("Номер игрока обязательен для заполнения", e.Message);
                Assert.Equal(typeof(NumberRestrictionException), e.GetType());
            }
            //catch (Exception e)
            //{
            //    Assert.True(false);
            //}
        }

        [Fact]
        public void AddPlayerWithoutName_throw_ArgumentNullException()
        {
            var playerStorage = new Storage();
            var olga = new Player
            {
                         
            };

            Assert.Throws<ArgumentNullException>(() => playerStorage.AddClient(olga));//4
            
        }

        [Fact]
        public void AddPlayerPositivTest()
        {

        }
    }
}
