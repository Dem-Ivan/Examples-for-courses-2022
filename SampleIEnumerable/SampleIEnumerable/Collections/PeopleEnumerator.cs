using System;
using System.Collections;
using SampleIEnumerable.Models;

namespace SampleIEnumerable.Collections
{
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
                if (_position == -1 || _position >= _people.Length)
                    throw new ArgumentException();

                var currentPerson = _people[_position];

                return currentPerson;
            }
        }

        // Перевод указательня на следующую позицию. Метод возвращает false, если операция не была выполнена. 
        // Например: Закончилась коллекция, следующего элемента не существует. 
        public bool MoveNext()
        {
            if (_position < _people.Length - 1)
            {
                _position++;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Обнуление позиции указателя
        public void Reset()
        {
            _position = -1;
        }
    }
}