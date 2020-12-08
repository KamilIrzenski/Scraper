using Microsoft.EntityFrameworkCore.Migrations;

namespace VotingSeymSraping.Migrations
{
    public partial class init : Migration
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
                    DateOfVote = table.Column<string>(nullable: true),
                    TimeOfVote = table.Column<string>(nullable: true),
                    VotingTopic = table.Column<string>(nullable: true),
                    DetailsLink = table.Column<string>(nullable: true),
                    VotingLink = table.Column<string>(nullable: true)
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
                    VoteType = table.Column<string>(nullable: true),
                    DeputyEnvoyID = table.Column<int>(nullable: true),
                    MeetingNrID = table.Column<int>(nullable: true),
                    DetailsLink = table.Column<string>(nullable: true),
                    NameEnvoy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteID);
                    table.ForeignKey(
                        name: "FK_Votes_Deputies_DeputyEnvoyID",
                        column: x => x.DeputyEnvoyID,
                        principalTable: "Deputies",
                        principalColumn: "EnvoyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_Meetings_MeetingNrID",
                        column: x => x.MeetingNrID,
                        principalTable: "Meetings",
                        principalColumn: "NrID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_DeputyEnvoyID",
                table: "Votes",
                column: "DeputyEnvoyID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_MeetingNrID",
                table: "Votes",
                column: "MeetingNrID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Deputies");

            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
