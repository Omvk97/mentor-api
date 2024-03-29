﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mentor_API.Migrations
{
    public partial class MentorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.UniqueConstraint("AK_Categories_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.UniqueConstraint("AK_Cities_PostalCode", x => x.PostalCode);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.Id);
                    table.UniqueConstraint("AK_Specializations_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastActive = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeachingInformation = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Mentors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MentorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price30Min = table.Column<int>(nullable: false),
                    Price45Min = table.Column<int>(nullable: false),
                    Price60Min = table.Column<int>(nullable: false),
                    MentorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachableCities",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachableCities", x => new { x.MentorId, x.CityId });
                    table.ForeignKey(
                        name: "FK_TeachableCities_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachableCities_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    MentorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachings_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachings_Mentors_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentors",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachingSpecializations",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(nullable: false),
                    TeachingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachingSpecializations", x => new { x.SpecializationId, x.TeachingId });
                    table.ForeignKey(
                        name: "FK_TeachingSpecializations_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachingSpecializations_Teachings_TeachingId",
                        column: x => x.TeachingId,
                        principalTable: "Teachings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_MentorId",
                table: "Pictures",
                column: "MentorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prices_MentorId",
                table: "Prices",
                column: "MentorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeachableCities_CityId",
                table: "TeachableCities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachings_CategoryId",
                table: "Teachings",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachings_MentorId",
                table: "Teachings",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachingSpecializations_TeachingId",
                table: "TeachingSpecializations",
                column: "TeachingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "TeachableCities");

            migrationBuilder.DropTable(
                name: "TeachingSpecializations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Specializations");

            migrationBuilder.DropTable(
                name: "Teachings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
