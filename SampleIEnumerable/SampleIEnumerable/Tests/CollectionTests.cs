using SampleIEnumerable.Collections;
using SampleIEnumerable.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SampleIEnumerable.Tests
{
    public class CollectionTests
    {
        [Fact]
        public void ExceptionWithActiveEnumerator()
        {
            //Arrange
            var person1 = new Person { FirstName = "John", LastName = "Silver" };
            var person2 = new Person { FirstName = "Richard", LastName = "Frank" };
            var person3 = new Person { FirstName = "Lisa", LastName = "Clark" };
            var person4 = new Person { FirstName = "James", LastName = "Farmer" };

            var people = new List<Person>() { person1, person2, person3, person4 };

            //Act
            foreach (var person in people)
            {
                people.Add(new Person() { FirstName = "Annette", LastName = "Wallace" });
            }
        }

        [Fact]
        public void DemonstrationEnumerationWork()
        {
            var person1 = new Person { FirstName = "John", LastName = "Silver" };
            var person2 = new Person { FirstName = "Richard", LastName = "Frank" };
            var person3 = new Person { FirstName = "Lisa", LastName = "Clark" };
            var person4 = new Person { FirstName = "James", LastName = "Farmer" };

            var people = new People(new Person[] { person1, person2, person3, person4 });

            foreach (var man in people)
            {
                Console.WriteLine(man.ToString());
            }
        }

        [Fact]
        public void DemonstrationLazyLoading()
        {
            //Arrange
            var random = new Random();
            var numArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var randomNumFiltered = numArray.Where(u => u == random.Next(1, 9));

            //Act
            var firstNum = randomNumFiltered.FirstOrDefault();
            var secondNum = randomNumFiltered.FirstOrDefault();

            //Assert
            Assert.Equal(firstNum, secondNum);
        }
    }
}