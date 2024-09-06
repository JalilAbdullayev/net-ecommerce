using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netcore_ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
                {
                    migrationBuilder.CreateTable(
                        name: "Orders",
                        columns: table => new
                        {
                            Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                            ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                            Quantity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                            Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                            Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                            Phone = table.Column<string>(type: "varchar(14)", nullable: false),
                            Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                            GrandTotal = table.Column<double>(type: "float", nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_Orders", x => x.Id);
                        });
                }
        
                /// <inheritdoc />
                protected override void Down(MigrationBuilder migrationBuilder)
                {
                    migrationBuilder.DropTable(
                        name: "Orders");
                }
    }
}
