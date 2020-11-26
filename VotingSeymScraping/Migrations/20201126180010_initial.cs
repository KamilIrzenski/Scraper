using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSeymSraping.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deputies",
                columns: table => new
                {
                    EnvoyID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    PoliticalParty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deputies", x => x.EnvoyID);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    NrID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NrMeetings = table.Column<int>(nullable: false),
                    DateOfVote = table.Column<DateTime>(nullable: false),
                    TimeOfVote = table.Column<DateTime>(nullable: false),
                    VotingTopic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.NrID);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoteType = table.Column<int>(nullable: true),
                    NameEnvoyID = table.Column<int>(nullable: true),
                    MeetingNrID = table.Column<int>(nullable: true),
                    NameEnvoy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteID);
                    table.ForeignKey(
                        name: "FK_Votes_Meetings_MeetingNrID",
                        column: x => x.MeetingNrID,
                        principalTable: "Meetings",
                        principalColumn: "NrID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Deputies_NameEnvoyID",
                        column: x => x.NameEnvoyID,
                        principalTable: "Deputies",
                        principalColumn: "EnvoyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_MeetingNrID",
                table: "Votes",
                column: "MeetingNrID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_NameEnvoyID",
                table: "Votes",
                column: "NameEnvoyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Deputies");
        }
    }
}
