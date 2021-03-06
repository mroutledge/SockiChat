namespace SockChat.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SockChat.Models;
    using System.Data.Entity.Migrations;
    using System;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SockChat.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext socki)
        {
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
            
            AddUserAndRole(socki);
        }

        public void AddUserAndRole(ApplicationDbContext context)
        {
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("canEdit"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "canEdit" });
            }

            if (!roleMgr.RoleExists("admin"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
            }

            //var userStore = new UserStore<ApplicationUser>(context);
            //var userMgr = new UserManager<ApplicationUser>(userStore);
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var appUser = new ApplicationUser
            {
                UserName = "Morgan",
                Email = "morgan.routledge@gmail.com"
            };
            IdUserResult = userMgr.Create(appUser, "");

            string adminId = userMgr.FindByEmail("morgan.routledge@gmail.com").Id;

            if (!userMgr.IsInRole(adminId, "canEdit"))
            {
                //IdUserResult = userMgr.AddToRole(appUser.Id, "canEdit");
                IdUserResult = userMgr.AddToRole(adminId, "canEdit");
            }

            if (!userMgr.IsInRole(adminId, "admin"))
            {
                //  IdUserResult = userMgr.AddToRole(appUser.Id, "canEdit");
                IdUserResult = userMgr.AddToRole(adminId, "admin");
            }

            context.Channels.AddOrUpdate(p => p.Topic, new Channel { Creator = context.Users.Find(adminId), Topic = "Main", AddedOn = DateTime.Now });

            //context.SaveChanges();
            //context.Messages.AddOrUpdate(
            //    P => P.MessageText,
            //    new MessageData() { BackgroundColour = "Black", TargetChannel = context.Channels.FirstOrDefault(p => p.Topic == "Main"), Colour = "Black", Created = DateTime.Now, MessageText = "Test", User = context.Users.Find(adminId) }
            //    );
        }
    }
}
