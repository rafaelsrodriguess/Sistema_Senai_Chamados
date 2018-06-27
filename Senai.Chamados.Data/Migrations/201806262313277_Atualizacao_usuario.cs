namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Atualizacao_usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ususarios", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Ususarios", "Eamil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ususarios", "Eamil", c => c.String(nullable: false));
            DropColumn("dbo.Ususarios", "Email");
        }
    }
}
