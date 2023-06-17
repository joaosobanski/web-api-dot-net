// See https://aka.ms/new-console-template for more information

using Domain.Models;
using Infra;

class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Hello, World!");

        using( var ctx =  new DataContext())
        {
            ctx.Users.Add(new User()
            {
                Name = "Joao",
                Email = "joao@email",
                PasswordHash = "1234",
                Slug = "joao",
                Bio = "Dev Joao",
                Image = "no image",
            });
            
            ctx.SaveChanges();
        }

    }
}