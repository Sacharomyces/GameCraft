namespace GameCraft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedRolesAndInitialUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'41526e95-6dab-4c38-bfc3-764d085dba98', N'guest@gamecraft.pl', 0, N'AFeqTQxStVQ4m+8QHiAfqODviGZspRfypsah9hpHStmYDIfI//Z3L/rZGAVYOqswuw==', N'e75e0529-f33b-47b2-a0b6-1c6579ae651d', NULL, 0, 0, NULL, 1, 0, N'guest@gamecraft.pl')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8661ca63-3711-4373-94c9-ea3f69eb890c', N'admin@gamecraft.pl', 0, N'AE5NWPrAFEcfBDwE2qnw3uN9F/EjHdGGPWcOWGkzIpMCiRG01hVzRUKGW4T01JdONw==', N'edeefbaf-cf3b-4873-8c98-ea5fe4515480', NULL, 0, 0, NULL, 1, 0, N'admin@gamecraft.pl')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'05a25639-f54e-4d93-9d13-30a2bfd9f760', N'CanManageBoardgames')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8661ca63-3711-4373-94c9-ea3f69eb890c', N'05a25639-f54e-4d93-9d13-30a2bfd9f760')");
        }
        
        public override void Down()
        {
        }
    }
}
