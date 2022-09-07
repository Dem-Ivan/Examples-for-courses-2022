using System.Collections;
using SampleIEnumerable.Models;

namespace SampleIEnumerable.Collections;

public class PeopleEnumerator : IEnumerator
{
    private readonly Person[] _people;
    private int _position = -1;

    public PeopleEnumerator(Person[] people)
    {
        _people = people;
    }


    // Получение того элемента коллекции, на который в данный момент указывает указатель
    public object Current
    {
        get
        {
            Console.WriteLine("Called method get current person");

            if (_position == -1 || _position >= _people.Length)
                throw new ArgumentException();

            var currentPerson = _people[_position];

            Console.WriteLine($"Current person is {currentPerson.FirstName} {currentPerson.LastName}");

            return currentPerson;
        }
    }

    // Перевод указательня на следующую позицию. Метод возвращает false, если операция не была выполнена. 
    // Например: Закончилась коллекция, следующего элемента не существует. 
    public bool MoveNext()
    {
        Console.WriteLine("Called method MoveNext");

        if (_position < _people.Length - 1)
        {
            _position++;

            Console.WriteLine($"Current position is {_position}");

            return true;
        }
        else
        {
            Console.WriteLine("Collection items are over");
            return false;
        }
    }

    // Обнуление позиции указателя
    public void Reset()
    {
        Console.WriteLine("Called method Reset");
        Console.WriteLine("position = -1");
        
        _position = -1;
    }
}