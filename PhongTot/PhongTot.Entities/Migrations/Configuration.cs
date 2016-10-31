namespace PhongTot.Entities.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhongTot.Entities.Models.RoomsEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhongTot.Entities.Models.RoomsEntity context)
        {
            CreatePostSample(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
        private void CreatePostSample(PhongTot.Entities.Models.RoomsEntity context)
        {
            if(context.Posts.Count()==0)
            {
                List<Post> listPost = new List<Post>()
            {
                new Post() {Name="Nhà đẹp khỏi bàn",Alias="nha-dep-khoi-ban",CategoryID=1,Status=true },
                new Post() {Name="Nhà xấu đừng xem",Alias="nha-xau-dung-xem",CategoryID=1,Status=true },
                new Post() {Name="Nhà cũng bình thường thôi",Alias="nha-cung-binh-thuong-thoi",CategoryID=2,Status=true },
                new Post() {Name="Nhà tạm được",Alias="nha-tam-duoc",CategoryID=2,Status=true },
            };
                context.Posts.AddRange(listPost);
                context.SaveChanges();
            }
           
        }
    }
}
