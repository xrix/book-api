namespace Buku.API.Migrations
{
    using BussinessObject;
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BukuDALContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BukuDALContext context)
        {


            var students = new List<Student>
            {
                    new Student{ Id = 1, Name = "Olin" },
                    new Student{ Id = 2, Name = "Udin" },
            };

            students.ForEach(s => context.Student.AddOrUpdate(p => p.Id, s));

            var authors = new List<Author>
            {
                new Author() { Id = 1, Name = "Jane Austen" },
                new Author() { Id = 2, Name = "Charles Dickens" },
                new Author() { Id = 3, Name = "Miguel de Cervantes" },
            };

            authors.ForEach(a => context.Author.AddOrUpdate(x => x.Id, a));
            context.SaveChanges();

            context.Book.AddOrUpdate(x => x.Id,
                new Book()
                {
                    Id = 1,
                    Title = "Pride and Prejudice",
                    Year = 1813,
                    Price = 9.99M,
                    Genre = "Comedy of manners",
                    Stock = 1,
                    StudentId = students.Single(s => s.Name == "Olin").Id,
                    AuthorId = authors.Single(a => a.Name == "Jane Austen").Id

                },
                new Book()
                {
                    Id = 2,
                    Title = "Northanger Abbey",
                    Year = 1817,
                    Price = 12.95M,
                    Genre = "Gothic parody",
                    Stock = 1,
                    StudentId = students.Single(s => s.Name == "Olin").Id,
                    AuthorId = authors.Single(a => a.Name == "Jane Austen").Id
                },
                new Book()
                {
                    Id = 3,
                    Title = "David Copperfield",
                    Year = 1850,
                    Price = 15,
                    Genre = "Bildungsroman",
                    Stock = 1,
                    StudentId = students.Single(s => s.Name == "Olin").Id,
                    AuthorId = authors.Single(a => a.Name == "Jane Austen").Id
                },
                new Book()
                {
                    Id = 4,
                    Title = "Don Quixote",
                    Year = 1617,
                    Price = 8.95M,
                    Genre = "Picaresque",
                    Stock = 1,
                    StudentId = students.Single(s => s.Name == "Olin").Id,
                    AuthorId = authors.Single(a => a.Name == "Jane Austen").Id
                }
                );
        }
    }
}
