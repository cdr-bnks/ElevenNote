namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Description", c => c.String(nullable: false));
        }
    }
}
