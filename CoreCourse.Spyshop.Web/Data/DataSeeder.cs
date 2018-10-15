using CoreCourse.Spyshop.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCourse.Spyshop.Web.Data
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Cameras" },
                new Category { Id = 2, Name = "Communication" },
                new Category { Id = 3, Name = "Distraction" },
                new Category { Id = 4, Name = "General" },
                new Category { Id = 5, Name = "Navigation" }
            );

            modelBuilder.Entity<Product>().HasData(
                //Camera's
                new 
                {
                    Id = 1L,
                    Name = "Spywatch",
                    Price = 39.95M,
                    CategoryId = 1L,
                    Description = "The built-in camera in this watch transmits a secured videofeed to a nearby monitor.",
                    PhotoUrl = "watch.jpg",
                    SortNumber = 1
                },
                new 
                {
                    Id = 2L,
                    Name = "Spywatch with storage",
                    Price = 39.95M,
                    CategoryId = 1L,
                    Description = "The built-in camera in this watch transmits a secured videofeed to a nearby monitor. Videos can be saved locally on a microchip.",
                    PhotoUrl = "watch.jpg",
                    SortNumber = 2
                },
                new 
                {
                    Id = 3L,
                    Name = "Underwater camera",
                    Price = 111.95M,
                    CategoryId = 1L,
                    Description = "This camera is waterproof to an astounding 700m, and runs entirely on hydrogen extracted by the environment.",
                    PhotoUrl = (string) null,
                    SortNumber = (int?)  3
                },
                new 
                {
                    Id = 4L,
                    Name = "Rocketchute \"Bird's eye\"",
                    Price = 7.95M,
                    CategoryId = 1L,
                    Description = "When reaching an altitude of 1,5 km, this camera sends a live feed of the environment while parachuting down.",
                    PhotoUrl = (string) null,
                    SortNumber = 4
                },
                new 
                {
                    Id = 5L,
                    Name = "Infrared camera",
                    Price = 15.95M,
                    CategoryId = 1L,
                    Description = "Easy to hide and mount IR camera.",
                    PhotoUrl = (string) null,
                    SortNumber = 5
                },

                //Communication
                new 
                {
                    Id = 6L,
                    Name = "Communication pencil",
                    Price = 6.95M,
                    CategoryId = 2L,
                    Description = "A small transmitter shaped as a pencil. Speak in the tip and listen at the other end. Also writes.",
                    PhotoUrl = "pencil.jpg",
                    SortNumber = 1
                },
                new 
                {
                    Id = 7L,
                    Name = "Point of view pen",
                    Price = 9.95M,
                    CategoryId = 2L,
                    Description = "Point this pen at your discussion partner to convince him of your point of view. Writes in blue ink.",
                    PhotoUrl = "pen.jpg",
                    SortNumber = 2
                },
                new 
                {
                    Id = 8L,
                    Name = "Cigar laserpointer",
                    Price = 13.95M,
                    CategoryId = 2L,
                    Description = "Evil geniuses have cats. Distract them with this laser pointer. Disperses catnip as a last resort.",
                    PhotoUrl = "cigar.jpg",
                    SortNumber = 3
                },
                new 
                {
                    Id = 9L,
                    Name = "Mustasch Translator",
                    Price = 73.95M,
                    CategoryId = 2L,
                    Description = "Advanced voice-technology ensures this moustasche translates every word you say in the language of choice.",
                    PhotoUrl = "stash.jpg",
                    SortNumber = 4
                },
                new 
                {
                    Id = 10L,
                    Name = "Earring Translator",
                    Price = 93.95M,
                    CategoryId = 2L,
                    Description = "Hang these low profile ear rings and translate every word to a preset language whispered in your ear.",
                    PhotoUrl = "earrings.jpg",
                    SortNumber = 5
                },
                new 
                {
                    Id = 11L,
                    Name = "Babelfish",
                    Price = 123.95M,
                    CategoryId = 2L,
                    Description = "Put this robotic fish-shaped device in your ear and understand any language.",
                    PhotoUrl = (string) null,
                    SortNumber = (int?)  null
                },
                new 
                {
                    Id = 12L,
                    Name = "Cellphone with tracking",
                    Price = 33.95M,
                    CategoryId = 2L,
                    Description = "A tiny cellphony with tracking capabilities.",
                    PhotoUrl = "tinyphone.jpg",
                    SortNumber = (int?)  null
                },

                //Distraction
                new 
                {
                    Id = 13L,
                    Name = "Holographic cushion",
                    Price = 69.95M,
                    CategoryId = 3L,
                    Description = "A small button underneath activates a hologram where you were previously seated.",
                    PhotoUrl = "cushion.jpg",
                    SortNumber = 1
                },
                new 
                {
                    Id = 14L,
                    Name = "Correction liquid",
                    Price = 129.95M,
                    CategoryId = 3L,
                    Description = "One small drip of this liquid on the nose of your victim and he will tell you no more lies. Works best on long noses.",
                    PhotoUrl = "corrliq.jpg",
                    SortNumber = 2
                },
                new 
                {
                    Id = 15L,
                    Name = "Identity Scrambler",
                    Price = 145.95M,
                    CategoryId = 3L,
                    Description = "When an enemy approaches you, simply switch on this device to confuse him. He will identify you as friendly.",
                    PhotoUrl = "idscramble.jpg",
                    SortNumber = 3
                },
                new 
                {
                    Id = 16L,
                    Name = "Exchange wallet",
                    Price = 29.95M,
                    CategoryId = 3L,
                    Description = "Place banknotes in this wallet. Place this in the fridge overnight to have them turn into the local currency.",
                    PhotoUrl = "wallet.jpg",
                    SortNumber = 4
                },
                new 
                {
                    Id = 17L,
                    Name = "Cola and mentos",
                    Price = 1.95M,
                    CategoryId = 3L,
                    Description = "Place mentos in cola bottle. Point at target to distract.",
                    PhotoUrl = (string) null,
                    SortNumber = 5
                },

                //General 
                new 
                {
                    Id = 18L,
                    Name = "Zooming contactlenses",
                    Price = 73.95M,
                    CategoryId = 4L,
                    Description = "The lenses allow to you to zoom up to 5 km.",
                    PhotoUrl = "lenses.jpg",
                    SortNumber = (int?)  null
                },
                new 
                {
                    Id = 19L,
                    Name = "Quick Bandages",
                    Price = 12.95M,
                    CategoryId = 4L,
                    Description = "Put a bandage on a wound and wait 10 to 30 minutes. Your injury will be fully healed.",
                    PhotoUrl = (string) null,
                    SortNumber = (int?)  null
                },
                new 
                {
                    Id = 20L,
                    Name = "Bulletproof tuxedo",
                    Price = 133.95M,
                    CategoryId = 4L,
                    Description = "A must-have when mingling with wealthy, evil geniuses.",
                    PhotoUrl = (string) null,
                    SortNumber = (int?)  null
                },
                new 
                {
                    Id = 21L,
                    Name = "Card game",
                    Price = 70.95M,
                    CategoryId = 4L,
                    Description = "This card game targets a specific person and lets him to win or lose. Comes with a mobile app.",
                    PhotoUrl = (string)null,
                    SortNumber = (int?)  null
                },

                //Navigation 
                new 
                {
                    Id = 22L,
                    Name = "Satellite Monitor",
                    Price = 25.95M,
                    CategoryId = 5L,
                    Description = "Analyses signals sent to satellites. ",
                    PhotoUrl = (string)null,
                    SortNumber = 1
                },
                new 
                {
                    Id = 23L,
                    Name = "Offroad GPS",
                    Price = 15.95M,
                    CategoryId = 5L,
                    Description = "Tracks your accurate altitude and position in every landscape.",
                    PhotoUrl = "gps.jpg",
                    SortNumber = 2
                },
                new 
                {
                    Id = 24L,
                    Name = "Galileo tracer",
                    Price = 25.95M,
                    CategoryId = 5L,
                    Description = "Tracks your accurate altitude and position using the Galileo satellites.",
                    PhotoUrl = (string)null,
                    SortNumber = 3
                },
                new 
                {
                    Id = 25L,
                    Name = "Tracer Batteries",
                    Price = 29.95M,
                    CategoryId = 5L,
                    Description = "These batteries (available in AA and AAA) send accurate positioning signals to the satellites of your choice.",
                    PhotoUrl = "batteries.jpg",
                    SortNumber = 4
                }
            );
            
        }
    }
}
