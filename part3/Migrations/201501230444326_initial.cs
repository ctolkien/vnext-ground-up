using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Model;
using System;

namespace part3.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("TodoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String()
                    })
                .PrimaryKey("PK_TodoItem", t => t.Id);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("TodoItem");
        }
    }
}