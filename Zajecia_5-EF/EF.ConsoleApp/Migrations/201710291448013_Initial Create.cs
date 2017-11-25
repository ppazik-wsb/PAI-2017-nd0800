namespace EF.ConsoleApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        DishId = c.Int(nullable: false, identity: true),
                        DishName = c.String(nullable: false, maxLength: 255),
                        Price = c.Double(),
                        CreatedBy = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.DishId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dishes");
        }
    }
}
