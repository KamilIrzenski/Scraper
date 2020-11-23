using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSeymSraping.Migrations
{
    public partial class initalsecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetingses");

            migrationBuilder.DropTable(
                name: "Votings");

            migrationBuilder.DropTable(
                name: "Envoys");

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
                name: "Votes",
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
                    table.PrimaryKey("PK_Votes", x => x.NumberVoteId);
                    table.ForeignKey(
                        name: "FK_Votes_Deputies_NameEnvoyID",
                        column: x => x.NameEnvoyID,
                        principalTable: "Deputies",
                        principalColumn: "EnvoyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
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
                    table.PrimaryKey("PK_Meetings", x => x.NrID);
                    table.ForeignKey(
                        name: "FK_Meetings_Votes_NumberVoteId",
                        column: x => x.NumberVoteId,
                        principalTable: "Votes",
                        principalColumn: "NumberVoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_NumberVoteId",
                table: "Meetings",
                column: "NumberVoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_NameEnvoyID",
                table: "Votes",
                column: "NameEnvoyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Deputies");

            migrationBuilder.CreateTable(
                name: "Envoys",
                columns: table => new
                {
                    EnvoyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    PoliticalParty = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envoys", x => x.EnvoyID);
                });

            migrationBuilder.CreateTable(
                name: "Votings",
                columns: table => new
                {
                    NumberVoteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameEnvoy = table.Column<string>(type: "TEXT", nullable: true),
                    NameEnvoyID = table.Column<int>(type: "INTEGER", nullable: true),
                    VoteType = table.Column<int>(type: "INTEGER", nullable: true)
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
                    NrID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfVote = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NrMeetings = table.Column<int>(type: "INTEGER", nullable: false),
                    NumberVoteId = table.Column<int>(type: "INTEGER", nullable: true),
                    TimeOfVote = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VotingTopic = table.Column<string>(type: "TEXT", nullable: true)
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
    }
}
