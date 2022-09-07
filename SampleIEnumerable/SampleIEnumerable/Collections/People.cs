using System.Collections;
using SampleIEnumerable.Models;

namespace SampleIEnumerable.Collections;

public class People : IEnumerable
{
    private Person[] _people { get; set; }

    public People(Person[] people)
    {
        _people = people;
    }

    public IEnumerator GetEnumerator()
    {
        return new PeopleEnumerator(_people);
    }
}