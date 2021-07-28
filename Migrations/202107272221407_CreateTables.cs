namespace ProjetoCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        AlunoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AlunoID)
                .ForeignKey("dbo.Cursoes", t => t.CursoID, cascadeDelete: true)
                .Index(t => t.CursoID);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        CursoID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UniversidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursoID)
                .ForeignKey("dbo.Universidades", t => t.UniversidadeID, cascadeDelete: true)
                .Index(t => t.UniversidadeID);
            
            CreateTable(
                "dbo.Universidades",
                c => new
                    {
                        UniversidadeID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.UniversidadeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alunoes", "CursoID", "dbo.Cursoes");
            DropForeignKey("dbo.Cursoes", "UniversidadeID", "dbo.Universidades");
            DropIndex("dbo.Cursoes", new[] { "UniversidadeID" });
            DropIndex("dbo.Alunoes", new[] { "CursoID" });
            DropTable("dbo.Universidades");
            DropTable("dbo.Cursoes");
            DropTable("dbo.Alunoes");
        }
    }
}
