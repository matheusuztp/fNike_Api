using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeAPI.Migrations
{
    /// <inheritdoc />
    public partial class populating_the_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into categorias(Nome, Image) values ('Tênis Masculino', 'TenisAzul.jpg')");
            mb.Sql("insert into categorias(Nome, Image) values ('Tênis Feminino', 'TenisRosa.jpg')");
            mb.Sql("insert into categorias(Nome, Image) values ('Casacos', 'Casacos.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from categorias");
        }
    }
}
