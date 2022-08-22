using System;

namespace Value_Type_and_Ref_Type
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) Struct------------------------------
            State england = new State { Name = "England" };
            State france = new State { Name = "France" };

            france.Code = 1;
            france.Population = 100_000_000;

            england = france;
            england.Code = 2;


            //2) Class-------------------------------
            Country london = new Country { Name = "London" };
            Country paris = new Country { Name = "Paris" };

            paris.Code = 3;
            paris.Population = 2000_000;

            london = paris;
            london.Code = 5;         


            //3) Ref type in Value type--------------            
            france.Country = paris;            

            england = france;
            england.Country.Population = 50_000;

           

            //4) Method parameters-------------------
            var tiras = new Country { Name = "Tiras" };

            RenameCountry(tiras);            
        }

        static void RenameCountry(Country country)
        {
            country.Name = "Tiras2";

            //country = new Country { Name = "NewTiras" };
        }
    }
}
