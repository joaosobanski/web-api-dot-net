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

            var category = new Category()
            {
                Name = "Primeira Categoria",
                Slug = ""
            };

            ctx.Categories.Add(category);

            ctx.SaveChanges();

        }

    }
}