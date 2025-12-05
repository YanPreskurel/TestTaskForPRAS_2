using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsPortal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallToActionBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallToActionBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlagImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lawyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lawyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhoWeArePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhoWeArePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallToActionBlockTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallToActionBlockId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallToActionBlockTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallToActionBlockTranslation_CallToActionBlocks_CallToActionBlockId",
                        column: x => x.CallToActionBlockId,
                        principalTable: "CallToActionBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseDocumentTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseDocumentId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseDocumentTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseDocumentTranslation_CaseDocuments_CaseDocumentId",
                        column: x => x.CaseDocumentId,
                        principalTable: "CaseDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseNoteTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseNoteId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseNoteTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseNoteTranslation_CaseNotes_CaseNoteId",
                        column: x => x.CaseNoteId,
                        principalTable: "CaseNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseTranslation_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LawyerTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LawyerId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LawyerTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LawyerTranslation_Lawyers_LawyerId",
                        column: x => x.LawyerId,
                        principalTable: "Lawyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TagTranslation_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WhoWeArePageTranslation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhoWeArePageId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionText1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SectionText2 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhoWeArePageTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WhoWeArePageTranslation_WhoWeArePages_WhoWeArePageId",
                        column: x => x.WhoWeArePageId,
                        principalTable: "WhoWeArePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaseFullDescription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseTranslationId = table.Column<int>(type: "int", nullable: false),
                    MessageNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paragraph1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section1Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section1Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paragraph2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section2Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Section2Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListItems = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Paragraph3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecisionLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFullDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseFullDescription_CaseTranslation_CaseTranslationId",
                        column: x => x.CaseTranslationId,
                        principalTable: "CaseTranslation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallToActionBlockTranslation_CallToActionBlockId",
                table: "CallToActionBlockTranslation",
                column: "CallToActionBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocumentTranslation_CaseDocumentId",
                table: "CaseDocumentTranslation",
                column: "CaseDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFullDescription_CaseTranslationId",
                table: "CaseFullDescription",
                column: "CaseTranslationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseNoteTranslation_CaseNoteId",
                table: "CaseNoteTranslation",
                column: "CaseNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseTranslation_CaseId",
                table: "CaseTranslation",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_LawyerTranslation_LawyerId",
                table: "LawyerTranslation",
                column: "LawyerId");

            migrationBuilder.CreateIndex(
                name: "IX_TagTranslation_TagId",
                table: "TagTranslation",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_WhoWeArePageTranslation_WhoWeArePageId",
                table: "WhoWeArePageTranslation",
                column: "WhoWeArePageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "CallToActionBlockTranslation");

            migrationBuilder.DropTable(
                name: "CaseDocumentTranslation");

            migrationBuilder.DropTable(
                name: "CaseFullDescription");

            migrationBuilder.DropTable(
                name: "CaseNoteTranslation");

            migrationBuilder.DropTable(
                name: "LawyerTranslation");

            migrationBuilder.DropTable(
                name: "TagTranslation");

            migrationBuilder.DropTable(
                name: "WhoWeArePageTranslation");

            migrationBuilder.DropTable(
                name: "CallToActionBlocks");

            migrationBuilder.DropTable(
                name: "CaseDocuments");

            migrationBuilder.DropTable(
                name: "CaseTranslation");

            migrationBuilder.DropTable(
                name: "CaseNotes");

            migrationBuilder.DropTable(
                name: "Lawyers");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "WhoWeArePages");

            migrationBuilder.DropTable(
                name: "Cases");
        }
    }
}
