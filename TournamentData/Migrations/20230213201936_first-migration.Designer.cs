// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TournamentData;

#nullable disable

namespace TournamentData.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230213201936_first-migration")]
    partial class firstmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("TournamentData.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TournamentData.Entities.PlayerTournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TournamentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TournamentId");

                    b.ToTable("PlayerTournaments");
                });

            modelBuilder.Entity("TournamentData.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("TournamentData.Entities.PlayerTournament", b =>
                {
                    b.HasOne("TournamentData.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TournamentData.Entities.Tournament", "Tournament")
                        .WithMany("Players")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TournamentData.Entities.Tournament", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
