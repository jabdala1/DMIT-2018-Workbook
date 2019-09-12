using BloggingDemo.DAL;
using BloggingDemo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BloggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Program();
            // . is Member Acess Operator
            app.Run();
            Write("Press any key to continue...");
            ReadKey();
        }

        private void Run()
        {
            Welcome();
            // Display the blogs in the database
            using (var context = new BloggingContext())
            {
                // Create and save a new blog
                Write("Enter a name for a new blog: ");
                var name = ReadLine();

                var blog = new Blog
                {
                    Name = name
                };

                context.Blogs.Add(blog);
                context.SaveChanges();

                // Display all blogs from the database
                List<Blog> blogs = context.Blogs.ToList();
                DisplayBlogNames(blogs);

            }
        }

        private void DisplayBlogNames(List<Blog> blogs)
        {
            foreach (var item in blogs)
                WriteLine(item.Name);
        }

        private void Welcome()
        {
            WriteLine("Blogging Demo Program");
        }
    }

    namespace Entities
    {
        public class Blog
        {
            // "Primary Key", by convention
            public int BlogID { get; set; }
            public string Name { get; set; }

            // Navigation Property
            public virtual ICollection<Post> Posts { get; set; }
        } // End of Blog class

        public class Post
        {
            // "Primary Key", by convention
            public int PostID { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            // Navigation Property
            public virtual Blog Blog { get; set; }
        } // End of Post class
    } // End of Entities namespace

    namespace DAL
    {
        public class BloggingContext : DbContext
        {
            public BloggingContext() : base("name=BlogDb")
            {
            }

            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
    }
}

