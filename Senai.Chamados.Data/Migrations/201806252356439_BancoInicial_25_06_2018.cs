namespace Senai.Chamados.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoInicial_25_06_2018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsuarioDomains",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        Eamil = c.String(),
                        Telefone = c.String(),
                        Cpf = c.String(),
                        Senha = c.String(),
                        Cep = c.String(),
                        Logradouro = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        DataCriacao = c.DateTime(nullable: false),
                        DataAlteracao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsuarioDomains");
        }
    }
}
