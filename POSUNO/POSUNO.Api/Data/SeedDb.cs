using Microsoft.EntityFrameworkCore;
using POSUNO.Api.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckUserAsync(); //Crear un usuario
            await CheckCustumersAsync();
            await CheckProductsAsync();




        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                Random random = new Random();
                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 0; i <= 200; i++)
                {
                    _context.Products.Add(new Product
                    {
                        Name = $"Producto {i}",
                        Description = $"Producto{i}",
                        Price = random.Next(5, 1000),
                        Stock = random.Next(0, 500),
                        IsActive = true,
                        User = user
                    });
                }

                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckCustumersAsync()
        {
            if (!_context.Customers.Any())
            {

                User user = await _context.Users.FirstOrDefaultAsync();
                for (int i = 0; i <= 50; i++)
                {
                    _context.Customers.Add(new Customer
                    {
                        FirstName = $"Cliente {i}",
                        LastName = $"Apellido{i}",
                        Phonenumber = "3128480036",
                        Address = "Clle luna #5254",
                        Email= $"cliente{i}@yopmail.com",
                        IsActive = true,
                        User = user
                    });
                }

                await _context.SaveChangesAsync();

            }
        }

        private async Task CheckUserAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    Email = "juan@yopmail.com",
                    FirstName = "Juan",
                    LastName = "Zuluaga",
                    Password = "123456"
                });

                _context.Users.Add(new User
                {
                    Email = "santiago@yopmail.com",
                    FirstName = "santiago",
                    LastName = "jimenez",
                    Password = "123456"
                });

                await _context.SaveChangesAsync();
            }
        }
    }

}