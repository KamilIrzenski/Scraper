using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSeymSraping.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Envoys",
                columns: table => new
                {
                    EnvoyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    LastName = table.Column<string>(maxLength: 128, nullable: false),
                    PoliticalParty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envoys", x => x.EnvoyID);
                });

            migrationBuilder.CreateTable(
                name: "Votings",
                columns: table => new
                {
                    NumberVoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoteType = table.Column<int>(nullable: true),
                    NameEnvoyID = table.Column<int>(nullable: true),
                    NameEnvoy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votings", x => x.NumberVoteId);
                    table.ForeignKey(
                        name: "FK_Votings_Envoys_NameEnvoyID",
                        column: x => x.NameEnvoyID,
                        principalTable: "Envoys",
                        principalColumn: "EnvoyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetingses",
                columns: table => new
                {
                    NrID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NrMeetings = table.Column<int>(nullable: false),
                    DateOfVote = table.Column<DateTime>(nullable: false),
                    NumberVoteId = table.Column<int>(nullable: true),
                    TimeOfVote = table.Column<DateTime>(nullable: false),
                    VotingTopic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetingses", x => x.NrID);
                    table.ForeignKey(
                        name: "FK_Meetingses_Votings_NumberVoteId",
                        column: x => x.NumberVoteId,
                        principalTable: "Votings",
                        principalColumn: "NumberVoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetingses_NumberVoteId",
                table: "Meetingses",
                column: "NumberVoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Votings_NameEnvoyID",
                table: "Votings",
                column: "NameEnvoyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetingses");

            migrationBuilder.DropTable(
                name: "Votings");

            migrationBuilder.DropTable(
                name: "Envoys");
        }
    }
}
