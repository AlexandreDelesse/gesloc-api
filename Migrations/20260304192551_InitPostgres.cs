using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeslocApi.Migrations
{
    /// <inheritdoc />
    public partial class InitPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyName = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<Guid>(type: "uuid", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    EmploymentType = table.Column<string>(type: "text", nullable: false),
                    Income = table.Column<decimal>(type: "numeric", nullable: false),
                    HasGuarantor = table.Column<bool>(type: "boolean", nullable: false),
                    GuarantorLastName = table.Column<string>(type: "text", nullable: true),
                    GuarantorFirstName = table.Column<string>(type: "text", nullable: true),
                    GuarantorEmploymentType = table.Column<string>(type: "text", nullable: true),
                    GuarantorIncome = table.Column<decimal>(type: "numeric", nullable: true),
                    CoverLetter = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    SubmittedAt = table.Column<string>(type: "text", nullable: false),
                    GdprConsent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TenancyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Period = table.Column<string>(type: "text", nullable: false),
                    RentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ChargesAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DueDate = table.Column<string>(type: "text", nullable: false),
                    PaidAt = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Owner_LastName = table.Column<string>(type: "text", nullable: false),
                    Owner_FirstName = table.Column<string>(type: "text", nullable: false),
                    Owner_Address_Number = table.Column<int>(type: "integer", nullable: true),
                    Owner_Address_Street = table.Column<string>(type: "text", nullable: true),
                    Owner_Address_PostCode = table.Column<string>(type: "text", nullable: true),
                    Owner_Address_City = table.Column<string>(type: "text", nullable: true),
                    Owner_Address_Residence = table.Column<string>(type: "text", nullable: true),
                    Address_Number = table.Column<int>(type: "integer", nullable: true),
                    Address_Street = table.Column<string>(type: "text", nullable: false),
                    Address_PostCode = table.Column<string>(type: "text", nullable: false),
                    Address_City = table.Column<string>(type: "text", nullable: false),
                    Address_Residence = table.Column<string>(type: "text", nullable: true),
                    Surface = table.Column<double>(type: "double precision", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    BuildingType = table.Column<string>(type: "text", nullable: true),
                    LegalRegime = table.Column<string>(type: "text", nullable: true),
                    ConstructionYear = table.Column<int>(type: "integer", nullable: true),
                    RoomCount = table.Column<int>(type: "integer", nullable: true),
                    Building = table.Column<string>(type: "text", nullable: true),
                    ApartmentNumber = table.Column<string>(type: "text", nullable: true),
                    Equipment = table.Column<string[]>(type: "text[]", nullable: false),
                    HeatingType = table.Column<string>(type: "text", nullable: true),
                    HotWaterType = table.Column<string>(type: "text", nullable: true),
                    InternetAccess = table.Column<bool>(type: "boolean", nullable: true),
                    InternetType = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenancies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PropertyId = table.Column<Guid>(type: "uuid", nullable: false),
                    Tenant_LastName = table.Column<string>(type: "text", nullable: false),
                    Tenant_FirstName = table.Column<string>(type: "text", nullable: false),
                    Tenant_Address_Number = table.Column<int>(type: "integer", nullable: true),
                    Tenant_Address_Street = table.Column<string>(type: "text", nullable: true),
                    Tenant_Address_PostCode = table.Column<string>(type: "text", nullable: true),
                    Tenant_Address_City = table.Column<string>(type: "text", nullable: true),
                    Tenant_Address_Residence = table.Column<string>(type: "text", nullable: true),
                    Guarantor_LastName = table.Column<string>(type: "text", nullable: true),
                    Guarantor_FirstName = table.Column<string>(type: "text", nullable: true),
                    Guarantor_Address_Number = table.Column<int>(type: "integer", nullable: true),
                    Guarantor_Address_Street = table.Column<string>(type: "text", nullable: true),
                    Guarantor_Address_PostCode = table.Column<string>(type: "text", nullable: true),
                    Guarantor_Address_City = table.Column<string>(type: "text", nullable: true),
                    Guarantor_Address_Residence = table.Column<string>(type: "text", nullable: true),
                    LegalFramework = table.Column<string>(type: "text", nullable: false),
                    PropertyUse = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<string>(type: "text", nullable: false),
                    DurationMonths = table.Column<int>(type: "integer", nullable: false),
                    RentAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ChargesAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ChargesType = table.Column<string>(type: "text", nullable: false),
                    PaymentDueDay = table.Column<int>(type: "integer", nullable: false),
                    SecurityDeposit = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    SignedDocument = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenancies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsGuarantorDoc = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    MimeType = table.Column<string>(type: "text", nullable: false),
                    File = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateDocuments_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDocuments_CandidateId",
                table: "CandidateDocuments",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateDocuments");

            migrationBuilder.DropTable(
                name: "CandidateLinks");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Tenancies");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
