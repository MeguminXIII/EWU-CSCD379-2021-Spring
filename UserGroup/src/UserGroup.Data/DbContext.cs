using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;


namespace UserGroup.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Event> Events => Set<Event>();
        public DbContext()
            : base(new DbContextOptionsBuilder<DbContext>().UseSqlite("Data Source=main.db").Options)
        {}

    }
}