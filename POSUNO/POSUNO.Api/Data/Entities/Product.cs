using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Api.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required] //Volver el campo obligatorio
        [MaxLength(50)] //Maximo de caracteres
        public string Name { get; set; }


        [Required] //Volver el campo obligatorio
        [MaxLength(500)] //Maximo de caracteres
        public string Description { get; set; }


        public decimal Price { get; set; }

        public float Stock { get; set; } //Cantidad de producto en inventario

        public User User { get; set; } //Relacion de un 1 a varios (Un producto pertenece a un Usuario y un Usuario tiene muchos productos)
    }
}
