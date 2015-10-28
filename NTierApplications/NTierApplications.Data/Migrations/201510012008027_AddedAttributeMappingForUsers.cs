namespace NTierApplications.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttributeMappingForUsers : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserClaims", "ClaimType", c => c.String(nullable: false));
            AlterColumn("dbo.UserClaims", "ClaimValue", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.UserLogins", "LoginProvider", c => c.String(nullable: false));
            AlterColumn("dbo.UserLogins", "ProviderKey", c => c.String(nullable: false));
            AlterColumn("dbo.UserRoles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserRoles", "Name", c => c.String());
            AlterColumn("dbo.UserLogins", "ProviderKey", c => c.String());
            AlterColumn("dbo.UserLogins", "LoginProvider", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
            AlterColumn("dbo.UserClaims", "ClaimValue", c => c.String());
            AlterColumn("dbo.UserClaims", "ClaimType", c => c.String());
        }
    }
}
