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
               ImagePath = "",
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
               ImagePath = "",
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
               ImagePath = "",
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
               ImagePath = "",
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
               ImagePath = "",
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
               ImagePath = "",
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
               ImagePath = "",
               Description = "Fresh, tasty and bursting with nutritious ingredients and lively aromas, " +
               "delicious one-bowl, Asian-inspired noodle dishes have never been more popular. " +
               "Their variety and versatility, speedy cooking time and ability to soak up the bold " +
               "flavours they're prepared with, make noodle dishes an exotic yet accessible dish and, " +
               "with The Noodle Bowl, you'll be able to celebrate this wonderful food and feast on the results. "
            }, new Book
            {
               BookId = 8,
               Author = "Louise Pickford",
               CategoryId = 8,
               LanguageId = 1,
               Name = "The Modern Tagine Cookbook : Delicious Recipes for Moroccan One-Pot Meals",
               PricePhysical = 23.5,
               PriceDigital = 12.6,
               Score = 3.75,
               ImagePath = "",
               Description = "These hearty one-pot meals, flavoured with fragrant spices, are cooked and " +
               "served from an elegant, specially designed cooking vessel, also called a tagine. In Ghillie " +
               "Basan's collection of deliciously authentic recipes you will find some of the best-loved " +
               "classics of the Moroccan kitchen."
            }
         );
      }
   }
}
