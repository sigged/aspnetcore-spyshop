using CoreCourse.Spyshop.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreCourse.Spyshop.Web.Data
{
    public static class DataSeeder
    {
        public static void Seed(SpyShopContext context)
        {
            // Are there any products in the db?
            if (context.Categories.Any())
                return;   // DB has already been seeded

            var categories = new Category[]
            {
                new Category{ Name = "Cameras" },
                new Category{ Name = "Communication" },
                new Category{ Name = "Distraction" },
                new Category{ Name = "General" },
                new Category{ Name = "Navigation" },
            };
            foreach (Category c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                 //Camera's
                new Product{ Name = "Spywatch", Price = 39.95M, Category = categories[0],
                    Description = "The built-in camera in this watch transmits a secured videofeed to a nearby monitor.",
                    PhotoUrl = "watch.jpg", SortNumber = 1 },
                new Product{ Name = "Spywatch with storage", Price = 39.95M, Category = categories[0],
                    Description = "The built-in camera in this watch transmits a secured videofeed to a nearby monitor. Videos can be saved locally on a microchip.",
                    PhotoUrl = "watch.jpg", SortNumber = 2 },
                new Product{ Name = "Underwater camera", Price = 111.95M, Category = categories[0],
                    Description = "This camera is waterproof to an astounding 700m, and runs entirely on hydrogen extracted by the environment.",
                    PhotoUrl = null, SortNumber = 3 },
                new Product{ Name = "Rocketchute \"Bird's eye\"", Price = 7.95M, Category = categories[0],
                    Description = "When reaching an altitude of 1,5 km, this camera sends a live feed of the environment while parachuting down.",
                    PhotoUrl = null, SortNumber = 4 },
                new Product{ Name = "Infrared camera", Price = 15.95M, Category = categories[0],
                    Description = "Easy to hide and mount IR camera.",
                    PhotoUrl = null, SortNumber = 5 },

                //Communication
                new Product{ Name = "Communication pencil", Price = 6.95M, Category = categories[1],
                    Description = "A small transmitter shaped as a pencil. Speak in the tip and listen at the other end. Also writes.",
                    PhotoUrl = "pencil.jpg", SortNumber = 1 },
                new Product{ Name = "Point of view pen", Price = 9.95M, Category = categories[1],
                    Description = "Point this pen at your discussion partner to convince him of your point of view. Writes in blue ink.",
                    PhotoUrl = "pen.jpg", SortNumber = 2 },
                new Product{ Name = "Cigar laserpointer", Price = 13.95M, Category = categories[1],
                    Description = "Evil geniuses have cats. Distract them with this laser pointer. Disperses catnip as a last resort.",
                    PhotoUrl = "cigar.jpg", SortNumber = 3 },
                new Product{ Name = "Mustasch Translator", Price = 73.95M, Category = categories[1],
                    Description = "Advanced voice-technology ensures this moustasche translates every word you say in the language of choice.",
                    PhotoUrl = "stash.jpg", SortNumber = 4 },
                new Product{ Name = "Earring Translator", Price = 93.95M, Category = categories[1],
                    Description = "Hang these low profile ear rings and translate every word to a preset language whispered in your ear.",
                    PhotoUrl = "earrings.jpg", SortNumber = 5 },
                new Product{ Name = "Babelfish", Price = 123.95M, Category = categories[1],
                    Description = "Put this robotic fish-shaped device in your ear and understand any language.",
                    PhotoUrl = null, SortNumber = null },
                new Product{ Name = "Cellphone with tracking", Price = 33.95M, Category = categories[1],
                    Description = "A tiny cellphony with tracking capabilities.",
                    PhotoUrl = "tinyphone.jpg", SortNumber = null },

                //Distraction
                new Product{ Name = "Holographic cushion", Price = 69.95M, Category = categories[2],
                    Description = "A small button underneath activates a hologram where you were previously seated.",
                    PhotoUrl = "cushion.jpg", SortNumber = 1 },
                new Product{ Name = "Correction liquid", Price = 129.95M, Category = categories[2],
                    Description = "One small drip of this liquid on the nose of your victim and he will tell you no more lies. Works best on long noses.",
                    PhotoUrl = "corrliq.jpg", SortNumber = 2 },
                new Product{ Name = "Identity Scrambler", Price = 145.95M, Category = categories[2],
                    Description = "When an enemy approaches you, simply switch on this device to confuse him. He will identify you as friendly.",
                    PhotoUrl = "idscramble.jpg", SortNumber = 3 },
                new Product{ Name = "Exchange wallet", Price = 29.95M, Category = categories[2],
                    Description = "Place banknotes in this wallet. Place this in the fridge overnight to have them turn into the local currency.",
                    PhotoUrl = "wallet.jpg", SortNumber = 4 },
                new Product{ Name = "Cola and mentos", Price = 1.95M, Category = categories[2],
                    Description = "Place mentos in cola bottle. Point at target to distract.",
                    PhotoUrl = null, SortNumber = 5 },

                //General 
                new Product{ Name = "Zooming contactlenses", Price = 73.95M, Category = categories[3],
                    Description = "The lenses allow to you to zoom up to 5 km.",
                    PhotoUrl = "lenses.jpg", SortNumber = null },
                new Product{ Name = "Quick Bandages", Price = 12.95M, Category = categories[3],
                    Description = "Put a bandage on a wound and wait 10 to 30 minutes. Your injury will be fully healed.",
                    PhotoUrl = null, SortNumber = null },
                new Product{ Name = "Bulletproof tuxedo", Price = 133.95M, Category = categories[3],
                    Description = "A must-have when mingling with wealthy, evil geniuses.",
                    PhotoUrl = null, SortNumber = null },
                new Product{ Name = "Card game", Price = 70.95M, Category = categories[3],
                    Description = "This card game targets a specific person and lets him to win or lose. Comes with a mobile app.",
                    PhotoUrl = null, SortNumber = null },

                //Navigation 
                new Product{ Name = "Satellite Monitor", Price = 25.95M, Category = categories[4],
                    Description = "Analyses signals sent to satellites. ",
                    PhotoUrl = null, SortNumber = 1 },
                new Product{ Name = "Offroad GPS", Price = 15.95M, Category = categories[4],
                    Description = "Tracks your accurate altitude and position in every landscape.",
                    PhotoUrl = "gps.jpg", SortNumber = 2 },
                new Product{ Name = "Galileo tracer", Price = 25.95M, Category = categories[4],
                    Description = "Tracks your accurate altitude and position using the Galileo satellites.",
                    PhotoUrl = null, SortNumber = 3 },
                new Product{ Name = "Tracer Batteries", Price = 29.95M, Category = categories[4],
                    Description = "These batteries (available in AA and AAA) send accurate positioning signals to the satellites of your choice.",
                    PhotoUrl = "batteries.jpg", SortNumber = 4 },

            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
