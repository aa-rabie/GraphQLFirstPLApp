using System;
using System.Collections.Generic;
using GraphQLFirstPLApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraphQLFirstPLApp.Data
{
    public class CarvedRockDbContext: DbContext
    {
        public CarvedRockDbContext(DbContextOptions<CarvedRockDbContext> options): base(options)
        {
            
        }

        

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<Product>()
                .Property(p => p.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

           builder.Entity<Product>().HasKey(p => p.Id);

           builder.Entity<ProductReview>()
               .Property(p => p.Id).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

           builder.Entity<ProductReview>().HasKey(p => p.Id);
           builder.Entity<ProductReview>().HasOne<Product>(s => s.Product)
               .WithMany(g => g.ProductReviews)
               .HasForeignKey(s => s.ProductId);

            #region data seed

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = -1,
                    Name = "Mountain Walkers",
                    Description = "Use these sturdy shoes to pass any mountain range with ease.",
                    Price = 219.5m,
                    Rating = 4,
                    Type = ProductType.Boots,
                    Stock = 12,
                    PhotoFileName = "shutterstock_66842440.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = -2,
                    Name = "Army Slippers",
                    Description = "For your everyday marches in the army.",
                    Price = 125.9m,
                    Rating = 3,
                    Type = ProductType.Boots,
                    Stock = 56,
                    PhotoFileName = "shutterstock_222721876.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = -3,
                    Name = "Backpack Deluxe",
                    Description = "This backpack can survive any tornado.",
                    Price = 199.99m,
                    Rating = 5,
                    Type = ProductType.ClimbingGear,
                    Stock = 66,
                    PhotoFileName = "shutterstock_6170527.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = -4,
                    Name = "Climbing Kit",
                    Description = "Anything you need to climb the mount Everest.",
                    Price = 299.5m,
                    Rating = 5,
                    Type = ProductType.ClimbingGear,
                    Stock = 3,
                    PhotoFileName = "shutterstock_48040747.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = -5,
                    Name = "Blue Racer",
                    Description = "Simply the fastest kayak on earth and beyond for 2 persons.",
                    Price = 350m,
                    Rating = 5,
                    Type = ProductType.Kayaks,
                    Stock = 8,
                    PhotoFileName = "shutterstock_441989509.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                },
                new Product
                {
                    Id = -6,
                    Name = "Orange Demon",
                    Description = "One person kayak with hyper boost button.",
                    Price = 450m,
                    Rating = 2,
                    Type = ProductType.Kayaks,
                    Stock = 1,
                    PhotoFileName = "shutterstock_495259978.jpg",
                    IntroducedAt = DateTimeOffset.Now.AddMonths(-1)
                }
            );

            builder.Entity<ProductReview>().HasData(new ProductReview
                {
                    Id = -1,
                    ProductId = -2,
                    Title = "Crossed the Himalayas",
                    Review =
                        "First released almost 30 years ago, the Titan 26078 is a classic work boot. It’s also one of Timberland’s all time best sellers."
                },
                new ProductReview
                {
                    Id = -2,
                    ProductId = -2,
                    Title = "Comfortable",
                    Review =
                        "One of the most comfortable hiking boots available, each pair comes complete with the Power Fit Comfort System, designed to offer maximum support at key areas of your feet."
                }, 
                new ProductReview
                {
                    Id = -3,
                    ProductId = -3,
                    Title = "Feels like canvas",
                    Review = "The Better Backpack is made from 100% recycled plastic but looks and feels like canvas. We were sent the grey bag with the tan leather accents and silver zippers. I’ve personally always liked tan leather paired with the color grey and appreciate the feel of the leather pull tabs and handles at the top of the bag. Additionally the inside is navy blue with a diagonal stitch pattern which gives it an air of sophistication."
                },
                new ProductReview
                {
                    Id = -4,
                    ProductId = -5,
                    Title = "So this is my 1st ever...",
                    Review = "So this is my 1st ever kayak and my 1st experience paddling a kayak. I struggled with whether I should spend more money to buy a \"Fishing\" kayak, or even a \"higher end\" kayak because my fear was paddling around a bathtub on the lake. I have to say, I love this kayak for me. It doesn\'t have a lot of the bells and whistles that some of the pricier kayaks have but, I\'m not disappointed.\r\n\r\nIt\'s pretty bare bones aside from some dry storage areas and some bungees. It does have a bungee to hold your paddle on the side. I feel it paddles very easy. It goes exactly where I want it to, I didn\'t struggle to keep it on course. A stiff wind can knock you off track but it was very sturdy and I feel like it would take a lot to tip it over. I stayed fairly dry aside from the dripping off the paddle but its a sit on top so thats to be expected."
                },
                new ProductReview
                {
                    Id = -5,
                    ProductId = -5,
                    Title = "Great for all genders",
                    Review = "I am a fit 5'7 woman 140lbs and I take my 30# dog along with no troubles. I have fished with it by using a bucket strapped in the back with my bungee cords. It holds my rods and small tackle tray, bug spray etc so I can get to it all easily. I can even get it up on the roof of my jeep alone. "
                },
                new ProductReview
                {
                    Id = -6,
                    ProductId = -5,
                    Title = "Happy",
                    Review = "Very happy with my purchase and I recommend this to anyone who doesn't want to spend over 600$ on a kayak but also doesn't want a cheap ole hunk of plastic. "
                });
            #endregion
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
