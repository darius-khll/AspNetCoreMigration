using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClassLibraryStandard
{
    /*
        docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1!@#$QaZ0' -p 1433:1433 -d mcr.microsoft.com/mssql/server
        docker exec -it bc123 bash
        /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P '1!@#$QaZ0'
        CREATE DATABASE myDb
        SELECT Name from sys.Databases
        USE myDb
        CREATE TABLE Posts (id INT IDENTITY(1,1), Text NVARCHAR(50))
        drop table Posts
        SELECT * FROM Posts;

        go
    */
    class MyContext : DbContext
    {
        public MyContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=myDb;user=sa;password=1!@#$QaZ0;");
        }

        public DbSet<Post> Posts { get; set; }
    }

    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
