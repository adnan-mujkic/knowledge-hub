using knowledge_hub.WebAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace knowledge_hub.WebAPI.Database
{
   public partial class databaseContext
   {
      partial void OnModelCreatingPartial(ModelBuilder modelBuilder) {
         modelBuilder.Entity<Role>().HasData(
            new Role { RoleID = 1, Name = "Admin" },
            new Role { RoleID = 2, Name = "User" },
            new Role { RoleID = 3, Name = "Delivery" }
         );

         SeedUsers(ref modelBuilder);

         modelBuilder.Entity<City>().HasData(
            new City { CityId = 1, Name = "Sarajevo", ZipCode = "71000", Country = "Bosnia and Herzegovina" },
            new City { CityId = 2, Name = "Mostar", ZipCode = "88000", Country = "Bosnia and Herzegovina" },
            new City { CityId = 3, Name = "Konjic", ZipCode = "88400", Country = "Bosnia and Herzegovina" },
            new City { CityId = 4, Name = "Zenica", ZipCode = "72000", Country = "Bosnia and Herzegovina" },
            new City { CityId = 5, Name = "Banja Luka", ZipCode = "78000", Country = "Bosnia and Herzegovina" },
            new City { CityId = 6, Name = "Tuzla", ZipCode = "75000", Country = "Bosnia and Herzegovina" }
         );

         modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Art & Photography" },
            new Category { CategoryId = 2, Name = "Biography" },
            new Category { CategoryId = 3, Name = "Children's Books" },
            new Category { CategoryId = 4, Name = "Crafts & Hobbies" },
            new Category { CategoryId = 5, Name = "Crime & Thriller" },
            new Category { CategoryId = 6, Name = "Fantasy" },
            new Category { CategoryId = 7, Name = "Ficition" },
            new Category { CategoryId = 8, Name = "Food & Drinks" },
            new Category { CategoryId = 9, Name = "Graphics Novels" },
            new Category { CategoryId = 10, Name = "History" },
            new Category { CategoryId = 11, Name = "Horror" },
            new Category { CategoryId = 12, Name = "Manga" },
            new Category { CategoryId = 13, Name = "Mind, Body & Spirit" },
            new Category { CategoryId = 14, Name = "Science Fiction" }
         );

         modelBuilder.Entity<Language>().HasData(
            new Language { LanguageId = 1, Name = "English" },
            new Language { LanguageId = 2, Name = "Deutsch" },
            new Language { LanguageId = 3, Name = "Español" },
            new Language { LanguageId = 4, Name = "Français" },
            new Language { LanguageId = 5, Name = "官話/官话 " },
            new Language { LanguageId = 6, Name = "日本語 " }
         );

         modelBuilder.Entity<Book>().HasData(
            new Book
            {
               BookId = 1,
               Author = "J. R. R. Tolkien",
               CategoryId = 6,
               LanguageId = 1,
               Name = "The Fellowship of the Ring : The Lord of the Rings, Part 1",
               PricePhysical = 14.5,
               PriceDigital = 8.99,
               Score = 4.38,
               ImagePath = "LOTR1.jpg",
               FilePath = "LOTR1.pdf",
               Description = "Continuing the story begun in The Hobbit, this is the first part of " +
               "Tolkien's epic masterpiece, The Lord of the Rings, featuring a striking black cover based on Tolkien's own design, " +
               "the definitive text, and a detailed map of Middle-earth. Sauron, the Dark Lord, has gathered to him all the " +
               "Rings of Power - the means by which he intends to rule Middle-earth. All he lacks in his plans for dominion is the " +
               "One Ring - the ring that rules them all - which has fallen into the hands of the hobbit, Bilbo Baggins. In a sleepy " +
               "village in the Shire, young Frodo Baggins finds himself faced with an immense task, as his elderly cousin Bilbo " +
               "entrusts the Ring to his care. Frodo must leave his home and make a perilous journey across Middle-earth to the " +
               "Cracks of Doom, there to destroy the Ring and foil the Dark Lord in his evil purpose. Now published again in" +
               " B format, J.R.R. Tolkien's great work of imaginative fiction has been labelled both a heroic romance and a " +
               "classic fantasy fiction. By turns comic and homely, epic and diabolic, the narrative moves through countless " +
               "changes of scene and character in an imaginary world which is totally convincing in its detail."
            },
            new Book
            {
               BookId = 2,
               Author = "J. R. R. Tolkien",
               CategoryId = 6,
               LanguageId = 1,
               Name = "The Two Towers",
               PricePhysical = 13.5,
               PriceDigital = 7.99,
               Score = 4.46,
               ImagePath = "LOTR2.jpg",
               FilePath = "LOTR2.pdf",
               Description = "Building on the story begun in The Hobbit, this is the second part of Tolkien's epic masterpiece, " +
               "The Lord of the Rings, featuring a striking black cover based on Tolkien's own design, the definitive text, " +
               "and a detailed map of Middle-earth."
            },
            new Book
            {
               BookId = 3,
               Author = "J. R. R. Tolkien",
               CategoryId = 6,
               LanguageId = 1,
               Name = "The Return of the King",
               PricePhysical = 14.5,
               PriceDigital = 7.99,
               Score = 4.55,
               ImagePath = "LOTR3.jpg",
               FilePath = "LOTR3.pdf",
               Description = "Concluding the story begun in The Hobbit, this is the final part of Tolkien's " +
               "epic masterpiece, The Lord of the Rings. Featuring a striking black cover based on Tolkien's " +
               "own design, the definitive text, and a detailed map of Middle-earth."
            },
            new Book
            {
               BookId = 4,
               Author = "J. R. R. Tolkien",
               CategoryId = 6,
               LanguageId = 1,
               Name = "The Hobbit",
               PricePhysical = 11.5,
               PriceDigital = 6.99,
               Score = 4.28,
               ImagePath = "Hobbit.jpg",
               FilePath = "Hobbit.pdf",
               Description = "Bilbo Baggins is a hobbit who enjoys a comfortable, unambitious life, " +
               "rarely travelling further than the pantry of his hobbit-hole in Bag End. But his contentment " +
               "is disturbed when the wizard, Gandalf, and a company of thirteen dwarves arrive on his " +
               "doorstep one day to whisk him away on an unexpected journey 'there and back again'. " +
               "They have a plot to raid the treasure hoard of Smaug the Magnificent, a large and very dangerous dragon..."
            },
            new Book
            {
               BookId = 5,
               Author = " Hajime Isayama ",
               CategoryId = 12,
               LanguageId = 1,
               Name = "Attack On Titan 1",
               PricePhysical = 12.0,
               PriceDigital = 5.99,
               Score = 4.47,
               ImagePath = "AOT1.jpg",
               FilePath = "AOT1.pdf",
               Description = "Several hundred years ago, humans were nearly exterminated by giants. " +
               "Giants are typically several stories tall, seem to have no intelligence and who devour " +
               "human beings. A small percentage of humanity survied barricading themselves in a " +
               "city protected by walls even taller than the biggest of giants. Flash forward to the " +
               "present and the city has not seen a giant in over 100 years - before teenager " +
               "Eren and his foster sister Mikasa witness something horrific as the city walls " +
               "are destroyed by a super-giant that appears from nowhere."
            },
            new Book
            {
               BookId = 6,
               Author = "Chip Zdarsky, Mark Bagley",
               CategoryId = 9,
               LanguageId = 1,
               Name = "Spider-man: Life Story",
               PricePhysical = 24.5,
               PriceDigital = 12.99,
               Score = 4.21,
               ImagePath = "SpiderManLifeStory.jpg",
               FilePath = "SpiderManLifeStory.pdf",
               Description = "In 1962's Amazing Fantasy #15, fifteen-year-old Peter Parker was bitten by a " +
               "radioactive spider and became the Amazing Spider-Man! 57 years have passed in the real world " +
               "since that event - so what would have happened if the same amount of time passed for" +
               " Peter as well? To celebrate Marvel's 80th anniversary, Chip Zdarsky and Spider-Man " +
               "legend Mark Bagley unite to spin a unique Spidey tale - telling an entire history of " +
               "Spider-Man from beginning to end, set against the key events of the decades through which he lived!"
            },
            new Book
            {
               BookId = 7,
               Author = "Louise Pickford",
               CategoryId = 8,
               LanguageId = 1,
               Name = "The Noodle Bowl : Over 70 Recipes for Asian-Inspired Noodle Dishes",
               PricePhysical = 21.5,
               PriceDigital = 11.99,
               Score = 4.5,
               ImagePath = "NoodleBowlRecipes.jpg",
               FilePath = "NoodleBowlRecipes.pdf",
               Description = "Fresh, tasty and bursting with nutritious ingredients and lively aromas, " +
               "delicious one-bowl, Asian-inspired noodle dishes have never been more popular. " +
               "Their variety and versatility, speedy cooking time and ability to soak up the bold " +
               "flavours they're prepared with, make noodle dishes an exotic yet accessible dish and, " +
               "with The Noodle Bowl, you'll be able to celebrate this wonderful food and feast on the results. "
            }, 
            new Book
            {
               BookId = 8,
               Author = "Louise Pickford",
               CategoryId = 8,
               LanguageId = 1,
               Name = "The Modern Tagine Cookbook : Delicious Recipes for Moroccan One-Pot Meals",
               PricePhysical = 23.5,
               PriceDigital = 12.6,
               Score = 3.75,
               ImagePath = "ModernTagineCookbook.jpg",
               FilePath = "ModernTagineCookbook.pdf",
               Description = "These hearty one-pot meals, flavoured with fragrant spices, are cooked and " +
               "served from an elegant, specially designed cooking vessel, also called a tagine. In Ghillie " +
               "Basan's collection of deliciously authentic recipes you will find some of the best-loved " +
               "classics of the Moroccan kitchen."
            }
         );

         modelBuilder.Entity<CardInfo>().HasData(SeedCards());
         modelBuilder.Entity<Order>().HasData(SeedOrders());
         modelBuilder.Entity<Transaction>().HasData(SeedTransactions());
      }

      private void SeedUsers(ref ModelBuilder modelBuilder) {
         string adminPassword = "admin";
         string passwordSalt = PasswordHelper.GeneratePasswordSalt();
         modelBuilder.Entity<Login>().HasData(
            new Login
            {
               LoginId = 1,
               Email = "admin@knowledge.com",
               PasswordSalt = passwordSalt,
               PasswordHash = PasswordHelper.GeneratePasswordHash(passwordSalt, adminPassword)
            }
            );
         modelBuilder.Entity<User>().HasData(
            new User
            {
               LoginId = 1,
               UserId = 1,
               Username = "Admin",
               Biography = ""
            });
         modelBuilder.Entity<UserRoles>().HasData(
            new UserRoles
            {
               UserRoleID = 1,
               RoleID = 1,
               UserID = 1
            }
            );

         string deliveryPassword = "delivery";
         passwordSalt = PasswordHelper.GeneratePasswordSalt();
         modelBuilder.Entity<Login>().HasData(
            new Login
            {
               LoginId = 2,
               Email = "delivery@knowledge.com",
               PasswordSalt = passwordSalt,
               PasswordHash = PasswordHelper.GeneratePasswordHash(passwordSalt, deliveryPassword)
            }
            );
         modelBuilder.Entity<User>().HasData(
            new User
            {
               LoginId = 2,
               UserId = 2,
               Username = "Delivery",
               Biography = ""
            });
         modelBuilder.Entity<UserRoles>().HasData(
            new UserRoles
            {
               UserRoleID = 2,
               RoleID = 3,
               UserID = 2
            }
            );

         string userPassword = "user";
         passwordSalt = PasswordHelper.GeneratePasswordSalt();
         modelBuilder.Entity<Login>().HasData(
            new Login
            {
               LoginId = 3,
               Email = "user1@knowledge.com",
               PasswordSalt = passwordSalt,
               PasswordHash = PasswordHelper.GeneratePasswordHash(passwordSalt, userPassword)
            }
            );
         modelBuilder.Entity<User>().HasData(
            new User
            {
               LoginId = 3,
               UserId = 3,
               Username = "User",
               Biography = ""
            });
         modelBuilder.Entity<UserRoles>().HasData(
            new UserRoles
            {
               UserRoleID = 3,
               RoleID = 2,
               UserID = 3
            }
            );

         userPassword = "user";
         passwordSalt = PasswordHelper.GeneratePasswordSalt();
         modelBuilder.Entity<Login>().HasData(
            new Login
            {
               LoginId = 4,
               Email = "user2@knowledge.com",
               PasswordSalt = passwordSalt,
               PasswordHash = PasswordHelper.GeneratePasswordHash(passwordSalt, userPassword)
            }
            );
         modelBuilder.Entity<User>().HasData(
            new User
            {
               LoginId = 4,
               UserId = 4,
               Username = "User",
               Biography = ""
            });
         modelBuilder.Entity<UserRoles>().HasData(
            new UserRoles
            {
               UserRoleID = 4,
               RoleID = 2,
               UserID = 4
            }
            );
      }

      private CardInfo[] SeedCards() {
         return new[] {
            new CardInfo {
               CardInfoId = 1,
               FullName = "User 1",
               CardNumber = "4242",
               CardDate = "01/25",
               UserId = 3
            },
            new CardInfo
            {
               CardInfoId = 2,
               FullName = "User 2",
               CardNumber = "4242",
               CardDate = "02/24",
               UserId = 4
            }};
      }

      private Order[] SeedOrders() {
         return new[] {
            new Order
            {
               OrderId = 1,
               OrderNumber = "8e778038-71fc-4930-bbee-197c50499f9d",
               Digital = true,
               UserId = 3,
               UserFullName = "User 1",
               BookId = 1,
               OrderDate = DateTime.Now,
               ShippingDate = DateTime.Now,
               OrderStatus = 0,
               Comment = "",
               AddressLine = "",
               CityId = 1
            },
            new Order
            {
               OrderId = 2,
               OrderNumber = "c4a82927-67ac-4aa1-a045-902caf095900",
               Digital = true,
               UserId = 3,
               UserFullName = "User 1",
               BookId = 2,
               OrderDate = DateTime.Now,
               ShippingDate = DateTime.Now,
               OrderStatus = 0,
               Comment = "",
               AddressLine = "",
               CityId = 1
            },
            new Order
            {
               OrderId = 3,
               OrderNumber = "5ed359e2-1ed1-4bea-bdcf-018afff2f05f",
               Digital = true,
               UserId = 4,
               UserFullName = "User 2",
               BookId = 1,
               OrderDate = DateTime.Now,
               ShippingDate = DateTime.Now,
               OrderStatus = 0,
               Comment = "",
               AddressLine = "",
               CityId = 1
            },
            new Order
            {
               OrderId = 4,
               OrderNumber = "7bc51742-86ee-4611-a46d-0dcc6f0161b6",
               Digital = true,
               UserId = 4,
               UserFullName = "User 2",
               BookId = 3,
               OrderDate = DateTime.Now,
               ShippingDate = DateTime.Now,
               OrderStatus = 0,
               Comment = "",
               AddressLine = "",
               CityId = 1
            },
            new Order
            {
               OrderId = 5,
               OrderNumber = "f5a98595-55d5-41f0-a467-d71ad7ba0603",
               Digital = true,
               UserId = 4,
               UserFullName = "User 2",
               BookId = 3,
               OrderDate = DateTime.Now,
               ShippingDate = DateTime.Now,
               OrderStatus = 0,
               Comment = "",
               AddressLine = "",
               CityId = 1
            } };
      }

      private Transaction[] SeedTransactions() {
         return new[] {
            new Transaction
            {
               TransactionId = 1,
               OrderId = 1,
               CardInfoId = 1,
               TransactionTime = DateTime.Now,
               Price = 8.99
            },
            new Transaction
            {
               TransactionId = 2,
               OrderId = 2,
               CardInfoId = 1,
               TransactionTime = DateTime.Now,
               Price = 12.99
            },
            new Transaction
            {
               TransactionId = 3,
               OrderId = 3,
               CardInfoId = 2,
               TransactionTime = DateTime.Now,
               Price = 13.99
            },
            new Transaction
            {
               TransactionId = 4,
               OrderId = 4,
               CardInfoId = 2,
               TransactionTime = DateTime.Now,
               Price = 7.99
            },
            new Transaction
            {
               TransactionId = 5,
               OrderId = 5,
               CardInfoId = 2,
               TransactionTime = DateTime.Now,
               Price = 5.99
            } };
      }
   }
}
