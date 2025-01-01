using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactManager.Data.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddressCategories",
                columns: table => new
                {
                    EmailAddressCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddressCategories", x => x.EmailAddressCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberCategories",
                columns: table => new
                {
                    PhoneNumberCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Label = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberCategories", x => x.PhoneNumberCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 254, nullable: false),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryEmailAddressCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailAddressId);
                    table.ForeignKey(
                        name: "FK_Emails_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_EmailAddressCategories_CategoryEmailAddressCategoryId",
                        column: x => x.CategoryEmailAddressCategoryId,
                        principalTable: "EmailAddressCategories",
                        principalColumn: "EmailAddressCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    PhoneNumberId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    ContactId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryPhoneNumberCategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.PhoneNumberId);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_PhoneNumberCategories_CategoryPhoneNumberCategoryId",
                        column: x => x.CategoryPhoneNumberCategoryId,
                        principalTable: "PhoneNumberCategories",
                        principalColumn: "PhoneNumberCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailAddressCategories",
                columns: new[] { "EmailAddressCategoryId", "Label" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "Work" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumberCategories",
                columns: new[] { "PhoneNumberCategoryId", "Label" },
                values: new object[,]
                {
                    { 1, "Home" },
                    { 2, "Work" },
                    { 3, "Mobile" },
                    { 4, "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_CategoryEmailAddressCategoryId",
                table: "Emails",
                column: "CategoryEmailAddressCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactId",
                table: "Emails",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CategoryPhoneNumberCategoryId",
                table: "PhoneNumbers",
                column: "CategoryPhoneNumberCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ContactId",
                table: "PhoneNumbers",
                column: "ContactId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "EmailAddressCategories");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "PhoneNumberCategories");
        }
    }
}
