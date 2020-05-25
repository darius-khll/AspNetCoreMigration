using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibraryStandard
{
    public class Super
    {
        public static string SuperMethod(string s)
        {
            AddToDb();

            var posts = GetFromDb();

            return $"Hello World! {s}";

        }

        public static void AddToDb()
        {
            var rnd = new Random();
            using (var db = new MyContext())
            {
                var text = $"Some number: {rnd.Next(100)}";

                db.Posts.Add(new Post { Text = text });

                db.SaveChanges();
            }
        }

        public static List<Post> GetFromDb()
        {
            using (var db = new MyContext())
            {
                return db.Posts.ToList();
            }
        }
    }
}
