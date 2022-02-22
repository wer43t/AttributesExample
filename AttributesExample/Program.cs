using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AttributesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("toma", 0);
            Validate(person);
        }

        private static void Validate(Person person)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(person);
            if (!Validator.TryValidateObject(person, context, results, true))
            {
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            else
                Console.WriteLine($"{person.Name} прошел валидацию");
        }
    }



    class Person
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не допустимая длина имени")]
        [MyName]
        public string Name { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class MyNameAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Person person = value as Person;
            if (person.Age == 33)
            {
                this.ErrorMessage = "Возраст пользователя не должен быть равен 33";
                return false;
            }
            return true;
        }
    }
}
