using System.Data.Entity;
using SimpleBlog.Core.Model;

namespace SimpleBlog.Core.Data
{
    public class Db : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Entity<Post>().
                HasMany(r => r.Tags).
                WithMany(o => o.Posts).
                Map(f =>
                        {
                            f.MapLeftKey("PostId");
                            f.MapRightKey("TagId");
                        });

            modelBuilder.
                Entity<Post>().
                HasRequired(r => r.Category).
                WithMany(o => o.Posts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
