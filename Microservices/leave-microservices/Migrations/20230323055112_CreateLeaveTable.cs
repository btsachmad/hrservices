using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRServicesAPI.Migrations
{
    public partial class CreateLeaveTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdEmployee = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    StartDt = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDt = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpiredDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovalDt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdApprover = table.Column<Guid>(type: "uuid", nullable: true),
                    AutoApprove = table.Column<bool>(type: "boolean", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leaves");
        }
    }
}
