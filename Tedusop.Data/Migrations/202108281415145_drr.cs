namespace Tedusop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategorys", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategorys", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategorys", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.PostCategorys", "UpdateBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategorys", "MetaKeyword", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategorys", "MetaDescription", c => c.String(maxLength: 256));
            AddColumn("dbo.PostCategorys", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategorys", "Status");
            DropColumn("dbo.PostCategorys", "MetaDescription");
            DropColumn("dbo.PostCategorys", "MetaKeyword");
            DropColumn("dbo.PostCategorys", "UpdateBy");
            DropColumn("dbo.PostCategorys", "UpdatedDate");
            DropColumn("dbo.PostCategorys", "CreatedBy");
            DropColumn("dbo.PostCategorys", "CreatedDate");
        }
    }
}
