using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EquivalenceAndTests
{
   public class EquivalenceTests
    {

        [Fact]
        public void TwoObjectsEquivalenceTest()
        {
            //Arrange
            var olga = new Player { Name = "Olga" };
            var olga2 = new Player { Name = "Olga" };

            //Act
            var actualResultA = olga == olga2;
            var actualResultB = olga.Equals(olga2);

            //Assert
            //Assert.True(actualResultA);
            Assert.True(actualResultB);  
        }

        [Fact]
        public void EqualsNecessityPositivTest()
        {
            //Arrange
            var clientsList = new List<Player>();

            var olga = new Player { Name = "Olga", Number = 321 };
            var olgaIvanna = new Player { Name = "Olga", Number = 321 };

            clientsList.Add(olga);


            //Act
            var firatOlga = clientsList.FirstOrDefault(p => p.Name == "Olga");
            var isOlgaInList = clientsList.Contains(olga);
            var isolgaIvannaInList = clientsList.Contains(olgaIvanna);

            //Assert
            Assert.True(isolgaIvannaInList);
        }

        [Fact]
        public void GetHashCodeNecessityPositivTest()
        {
            //Arrange
            var accointsDyctionary = new Dictionary<Player, Team>();

            var olga = new Player { Name = "Olga" };
            var olgaIvanna = new Player { Name = "Olga" };

            accointsDyctionary.Add(olga, new Team { Name = "Zinit" });

            //Act
            var expected = accointsDyctionary[olga];
            var actual = accointsDyctionary[olgaIvanna];

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
