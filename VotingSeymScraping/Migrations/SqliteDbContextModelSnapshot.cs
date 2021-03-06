﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VotingSeymSraping.Data;

namespace VotingSeymSraping.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    partial class SqliteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("VotingSeymSraping.Entity.Deputy", b =>
                {
                    b.Property<int>("EnvoyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("PoliticalParty")
                        .HasColumnType("TEXT");

                    b.HasKey("EnvoyID");

                    b.ToTable("Deputies");
                });

            modelBuilder.Entity("VotingSeymSraping.Entity.Meeting", b =>
                {
                    b.Property<int>("NrID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DateOfVote")
                        .HasColumnType("TEXT");

                    b.Property<string>("DetailsLink")
                        .HasColumnType("TEXT");

                    b.Property<int>("NrMeetings")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TimeOfVote")
                        .HasColumnType("TEXT");

                    b.Property<string>("VotingLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("VotingTopic")
                        .HasColumnType("TEXT");

                    b.HasKey("NrID");

                    b.ToTable("Meetings");
                });

            modelBuilder.Entity("VotingSeymSraping.Entity.Vote", b =>
                {
                    b.Property<int>("VoteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DeputyEnvoyID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DetailsLink")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MeetingNrID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NameEnvoy")
                        .HasColumnType("TEXT");

                    b.Property<string>("VoteType")
                        .HasColumnType("TEXT");

                    b.HasKey("VoteID");

                    b.HasIndex("DeputyEnvoyID");

                    b.HasIndex("MeetingNrID");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("VotingSeymSraping.Entity.Vote", b =>
                {
                    b.HasOne("VotingSeymSraping.Entity.Deputy", "Deputy")
                        .WithMany()
                        .HasForeignKey("DeputyEnvoyID");

                    b.HasOne("VotingSeymSraping.Entity.Meeting", "Meeting")
                        .WithMany()
                        .HasForeignKey("MeetingNrID");
                });
#pragma warning restore 612, 618
        }
    }
}
