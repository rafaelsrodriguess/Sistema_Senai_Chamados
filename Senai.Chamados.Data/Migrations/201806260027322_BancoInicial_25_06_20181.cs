namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial_25_06_20181 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsuarioDomains", newName: "Ususarios");
            AlterColumn("dbo.Ususarios", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Ususarios", "Eamil", c => c.String(nullable: false));
            AlterColumn("dbo.Ususarios", "Senha", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.Ususarios", "Cep", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ususarios", "Cep", c => c.String());
            AlterColumn("dbo.Ususarios", "Senha", c => c.String());
            AlterColumn("dbo.Ususarios", "Eamil", c => c.String());
            AlterColumn("dbo.Ususarios", "Nome", c => c.String());
            RenameTable(name: "dbo.Ususarios", newName: "UsuarioDomains");
        }
    }
}
