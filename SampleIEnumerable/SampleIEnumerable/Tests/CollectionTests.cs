using SampleIEnumerable.Collections;
using SampleIEnumerable.Models;
using Xunit;

namespace SampleIEnumerable.Tests;

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
        
        var people = new List<Person>(){ person1, person2, person3, person4 };

        //Act
        foreach (var person in people)
        {
            //Здесь будет сгенерировано InvalidOperationException
            people.Add(new Person(){FirstName = "Annette", LastName = "Wallace"});
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

    // [Fact]
    // public void DemonstrationLazyLoading()
    // {
    //     var person1 = new Person { FirstName = "John", LastName = "Silver" , Age = 24};
    //     var person2 = new Person { FirstName = "Richard", LastName = "Frank" , Age = 20};
    //     var person3 = new Person { FirstName = "Lisa", LastName = "Clark" , Age = 33};
    //     var person4 = new Person { FirstName = "James", LastName = "Farmer" , Age = 24};
    //
    //     var people = new People(new Person[] { person1, person2, person3, person4 });
    //     
    //     var orderedPeople = people.
    // }
}