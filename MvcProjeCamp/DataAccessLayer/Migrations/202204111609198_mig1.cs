﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()                              //kaydedersem gerçekleşecek
        {
            AddColumn("dbo.Contents", "WriterId", c => c.Int());
            CreateIndex("dbo.Contents", "WriterId");
            AddForeignKey("dbo.Contents", "WriterId", "dbo.Writers", "WriterId");
        }
        
        public override void Down()                            //kaydetmezsem gerçekleşecek
        {
            DropForeignKey("dbo.Contents", "WriterId", "dbo.Writers");
            DropIndex("dbo.Contents", new[] { "WriterId" });
            DropColumn("dbo.Contents", "WriterId");
        }
    }
}