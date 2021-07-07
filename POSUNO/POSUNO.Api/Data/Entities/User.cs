using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Api.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required] //Volver el campo obligatorio
        [EmailAddress] //Nos verifica si es un email valido 
        public string Email { get; set; }


        [Required] //Volver el campo obligatorio
        [MaxLength(50)] //Maximo de caracteres
        public string FirstName { get; set; }

        [Required] //Volver el campo obligatorio
        [MaxLength(50)] //Maximo de caracteres
        public string LastName { get; set; }

        [Required] //Volver el campo obligatorio
        [MaxLength(20)] //Maximo de caracteres
        [MinLength(6)] //Minimo de caracteres
        public string Password { get; set; }

        //Relacion de un 1 a varios (Un producto pertenece a un Usuario y un Usuario tiene muchos productos)

        public ICollection<Product> Products { get; set; }
    }
}
