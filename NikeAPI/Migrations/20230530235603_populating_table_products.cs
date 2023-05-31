using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikeAPI.Migrations
{
    /// <inheritdoc />
    public partial class populating_table_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into produtos (Nome, Descricao, Unitario, ImageUrl, Saldo, DataCadastro, CategoriaId) values ('Nike Air Force 1','Branco', 985.00, 'NikeAirForceOne.jpg', 10, now(), 1)");
            mb.Sql("insert into produtos (Nome, Descricao, Unitario, ImageUrl, Saldo, DataCadastro, CategoriaId) values ('Nike Air Force 1 Travis','Limited Edition', 2530.00, 'NikeAirForceTravis.jpg', 3, now(), 1)");
            mb.Sql("insert into produtos (Nome, Descricao, Unitario, ImageUrl, Saldo, DataCadastro, CategoriaId) values ('Nike Air Force Low','Preto', 750.00, 'NikeAirForceLow.jpg', 25, now(), 2)");
            mb.Sql("insert into produtos (Nome, Descricao, Unitario, ImageUrl, Saldo, DataCadastro, CategoriaId) values ('Nike SB','Rosa', 450.00, 'NikeSB.jpg', 80, now(), 2)");
            mb.Sql("insert into produtos (Nome, Descricao, Unitario, ImageUrl, Saldo, DataCadastro, CategoriaId) values ('Nike 2','Branco', 350.00, 'Nike2.jpg', 40, now(), 3)");
            mb.Sql("insert into produtos (Nome, Descricao, Unitario, ImageUrl, Saldo, DataCadastro, CategoriaId) values ('Moleton Nike','Branco', 250.00, 'MoletonNike.jpg', 150, now(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from produtos");
        }
    }
}
