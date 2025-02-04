﻿namespace WebCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.2121110054_Post", "Topics_Id", "dbo.2121110054_Topic");
            DropIndex("dbo.2121110054_Post", new[] { "Topics_Id" });
            DropTable("dbo.2121110054_Post");
            DropTable("dbo.2121110054_Topic");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.2121110054_Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Slug = c.String(),
                        Parent_Id = c.Int(nullable: false),
                        Metakey = c.String(nullable: false, maxLength: 150),
                        Metadesc = c.String(nullable: false, maxLength: 150),
                        Status = c.Boolean(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.2121110054_Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic_Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Slug = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                        Type = c.String(),
                        Metakey = c.String(),
                        Metadesc = c.String(),
                        Status = c.Boolean(nullable: false),
                        Create_By = c.Int(nullable: false),
                        Update_By = c.Int(nullable: false),
                        Create_at = c.DateTime(nullable: false),
                        Update_at = c.DateTime(nullable: false),
                        Topics_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.2121110054_Post", "Topics_Id");
            AddForeignKey("dbo.2121110054_Post", "Topics_Id", "dbo.2121110054_Topic", "Id");
        }
    }
}
