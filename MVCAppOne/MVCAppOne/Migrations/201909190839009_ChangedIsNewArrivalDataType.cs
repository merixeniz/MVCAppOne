namespace MVCAppOne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIsNewArrivalDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "IsNewArrival", c => c.Boolean(nullable: false));
                     
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "IsNewArrival", c => c.String());
        }
    }
}
