using System;

namespace Transformation_Reduction
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) Value types
            int temperatureVal1 = 30;
            float temperatureVal2 = 99.53f;

            //temperatureVal2 = temperatureVal1;

            temperatureVal1 = (int)temperatureVal2;


            //2) Ref Types

            var animal = new Animal { Species = "marine" };
            var giraffe = new Giraffe {Species = "land", NeckLength = 10};

            animal = giraffe;
            var spec = animal.Species;

            giraffe = (Giraffe)animal;

            //Animal animal1 = new Animal();
            //giraffe = (Giraffe)animal1;
        }
    }
}
