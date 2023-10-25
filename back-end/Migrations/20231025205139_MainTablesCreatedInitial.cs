using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace back_end.Migrations
{
    /// <inheritdoc />
    public partial class MainTablesCreatedInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeEmpresa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                });

            migrationBuilder.CreateTable(
                name: "VagasEmpregos",
                columns: table => new
                {
                    VagasId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeVaga = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DescricaoVaga = table.Column<string>(type: "text", nullable: false),
                    ValorPagamento = table.Column<decimal>(type: "numeric", nullable: false),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagasEmpregos", x => x.VagasId);
                    table.ForeignKey(
                        name: "FK_VagasEmpregos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    EmpresaId = table.Column<long>(type: "bigint", nullable: true),
                    VagasEmpregoVagasId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "EmpresaId");
                    table.ForeignKey(
                        name: "FK_Usuarios_VagasEmpregos_VagasEmpregoVagasId",
                        column: x => x.VagasEmpregoVagasId,
                        principalTable: "VagasEmpregos",
                        principalColumn: "VagasId");
                });

            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    CompetenciaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    NomeCompetencia = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DescCompetencia = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.CompetenciaId);
                    table.ForeignKey(
                        name: "FK_Competencias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empregos",
                columns: table => new
                {
                    EmpregoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    NomeEmprego = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    DescricaoEmprego = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empregos", x => x.EmpregoId);
                    table.ForeignKey(
                        name: "FK_Empregos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Estado = table.Column<int>(type: "integer", nullable: false),
                    Rua = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Complemento = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_UsuarioId",
                table: "Competencias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empregos_UsuarioId",
                table: "Empregos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioId",
                table: "Enderecos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaId",
                table: "Usuarios",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_VagasEmpregoVagasId",
                table: "Usuarios",
                column: "VagasEmpregoVagasId");

            migrationBuilder.CreateIndex(
                name: "IX_VagasEmpregos_EmpresaId",
                table: "VagasEmpregos",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Empregos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VagasEmpregos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
