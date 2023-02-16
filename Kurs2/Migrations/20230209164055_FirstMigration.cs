using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kurs2.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "пользователь",
                columns: table => new
                {
                    Idпользователь = table.Column<int>(name: "Id_пользователь", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Логин = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Пароль = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Роль = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Idпользователь);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "товар",
                columns: table => new
                {
                    idтовар = table.Column<int>(name: "id_товар", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Название = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Стоимость = table.Column<int>(type: "int", nullable: false),
                    Количество = table.Column<int>(type: "int", nullable: true),
                    Категория = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Фото = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idтовар);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "заказ",
                columns: table => new
                {
                    idзаказ = table.Column<int>(name: "id_заказ", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Адрес = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Способоплаты = table.Column<string>(name: "Способ оплаты", type: "varchar(200)", maxLength: 200, nullable: true),
                    Общаястоимость = table.Column<int>(name: "Общая стоимость", type: "int", nullable: false),
                    idпользователя = table.Column<int>(name: "id_пользователя", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idзаказ);
                    table.ForeignKey(
                        name: "id_пользователя",
                        column: x => x.idпользователя,
                        principalTable: "пользователь",
                        principalColumn: "Id_пользователь");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "корзина",
                columns: table => new
                {
                    idкорзина = table.Column<int>(name: "id_корзина", type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Количество = table.Column<int>(type: "int", nullable: true),
                    Общаястоимость = table.Column<int>(name: "Общая стоимость", type: "int", nullable: true),
                    пользовательIdпользователь = table.Column<int>(name: "пользователь_Id_пользователь", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idкорзина);
                    table.ForeignKey(
                        name: "id_корзина",
                        column: x => x.пользовательIdпользователь,
                        principalTable: "пользователь",
                        principalColumn: "Id_пользователь",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "корзина_has_товар",
                columns: table => new
                {
                    КорзинаIdКорзина = table.Column<int>(type: "int", nullable: false),
                    ТоварIdТовар = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.КорзинаIdКорзина, x.ТоварIdТовар });
                    table.ForeignKey(
                        name: "fk_корзина_has_товар_корзина1",
                        column: x => x.КорзинаIdКорзина,
                        principalTable: "корзина",
                        principalColumn: "id_корзина",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_корзина_has_товар_товар1",
                        column: x => x.ТоварIdТовар,
                        principalTable: "товар",
                        principalColumn: "id_товар",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "id_пользователь_idx",
                table: "заказ",
                column: "id_пользователя");

            migrationBuilder.CreateIndex(
                name: "id_корзина_idx",
                table: "корзина",
                column: "пользователь_Id_пользователь");

            migrationBuilder.CreateIndex(
                name: "fk_корзина_has_товар_корзина1_idx",
                table: "корзина_has_товар",
                column: "КорзинаIdКорзина");

            migrationBuilder.CreateIndex(
                name: "fk_корзина_has_товар_товар1_idx",
                table: "корзина_has_товар",
                column: "ТоварIdТовар");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "заказ");

            migrationBuilder.DropTable(
                name: "корзина_has_товар");

            migrationBuilder.DropTable(
                name: "корзина");

            migrationBuilder.DropTable(
                name: "товар");

            migrationBuilder.DropTable(
                name: "пользователь");
        }
    }
}
