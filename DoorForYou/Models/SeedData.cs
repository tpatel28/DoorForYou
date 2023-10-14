using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Doorforyou.Data;
using System.Threading.Tasks;

namespace Doorforyou.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DoorforyouContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DoorforyouContext>>()))
            {
                // Look for any movies.
                if (context.Door.Any())
                {
                    return;   // DB has been seeded
                }

                context.Door.AddRange(
                    new Door
                    {
                        Type = "Wooden",
                        Color = "Oak",
                        Edition = "Vintage",
                        Make = "USA",
                        Price = 450,
                        Rating = "4.5"
                    },
new door
{
    Type = "Glass",
    Color = "Clear",
    Edition = "Modern",
    Make = "Germany",
    Price = 720,
    Rating = "4.9"
},
new door
{
    Type = "Steel",
    Color = "Silver",
    Edition = "Industrial",
    Make = "China",
    Price = 380,
    Rating = "4.2"
},
new door
{
    Type = "Fiberglass",
    Color = "White",
    Edition = "Contemporary",
    Make = "Canada",
    Price = 590,
    Rating = "4.7"
},
new door
{
    Type = "Aluminum",
    Color = "Gray",
    Edition = "Minimalist",
    Make = "Japan",
    Price = 520,
    Rating = "4.6"
},
new door
{
    Type = "Iron",
    Color = "Black",
    Edition = "Antique",
    Make = "France",
    Price = 690,
    Rating = "4.4"
},
new door
{
    Type = "Composite",
    Color = "Brown",
    Edition = "Rustic",
    Make = "Spain",
    Price = 480,
    Rating = "4.3"
},
new door
{
    Type = "UPVC",
    Color = "White",
    Edition = "Energy-Efficient",
    Make = "UK",
    Price = 550,
    Rating = "4.8"
},
new door
{
    Type = "Barn",
    Color = "Rustic Red",
    Edition = "Farmhouse",
    Make = "USA",
    Price = 620,
    Rating = "4.6"
},
new door
{
    Type = "French",
    Color = "Mahogany",
    Edition = "Elegant",
    Make = "France",
    Price = 780,
    Rating = "4.9"
}
                );
                context.SaveChanges();
            }
        }
    }
}
