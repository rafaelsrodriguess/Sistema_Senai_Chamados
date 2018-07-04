namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alteração_Tabela_Usuario_03_07_2018 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ususarios", "TipoUsuario", c => c.Int(nullable: false));
            AddColumn("dbo.Ususarios", "Sexo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ususarios", "Sexo");
            DropColumn("dbo.Ususarios", "TipoUsuario");
        }
    }
}
