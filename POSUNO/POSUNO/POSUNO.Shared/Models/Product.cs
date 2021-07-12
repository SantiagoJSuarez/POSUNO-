

namespace POSUNO.Models
{
    public class Product
    {
        public int Id { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public decimal Price { get; set; }

        public float Stock { get; set; } //Cantidad de producto en inventario

        public bool IsActive { get; set; }

        public User User { get; set; } //Relacion de un 1 a varios (Un producto pertenece a un Usuario y un Usuario tiene muchos productos)


    }
}
