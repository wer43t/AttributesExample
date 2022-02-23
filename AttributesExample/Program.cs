using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AttributesExample
{
    static public class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("toma", 33);
            Validate(person);
        }

        public static List<ValidationResult> Validate(Person person)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(person);
            Validator.TryValidateObject(person, context, results, true);
            return results;
        }
    }



    public class Person
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Не допустимая длина имени")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Required]
        [MyName]
        [Range(1, 100, ErrorMessage = "Недопустимый возраст")]
        [Display(Name = "Возраст")]
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
            int age = Convert.ToInt32(value);
            if (age == 33)
            {
                this.ErrorMessage = "Возраст пользователя не должен быть равен 33";
                return false;
            }
            return true;
        }
    }
}
