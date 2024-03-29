﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using xfilmx.Models;

#nullable disable

namespace xfilmx.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("xfilmx.Models.Celebritie", b =>
                {
                    b.Property<int>("CelebritieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CelebritieId"), 1L, 1);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnOrder(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnOrder(1);

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)")
                        .HasColumnOrder(5);

                    b.Property<string>("PlaceOfBirth")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)")
                        .HasColumnOrder(4);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(2);

                    b.HasKey("CelebritieId");

                    b.ToTable("Celebrities");
                });

            modelBuilder.Entity("xfilmx.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(1);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("xfilmx.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(1);

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("xfilmx.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnOrder(3);

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnOrder(5);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(2);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("xfilmx.Models.Production", b =>
                {
                    b.Property<int>("ProductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionId"), 1L, 1);

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("date")
                        .HasColumnOrder(3);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnOrder(6);

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<bool>("IsSerie")
                        .HasColumnType("bit")
                        .HasColumnOrder(1);

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)")
                        .HasColumnOrder(7);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(2);

                    b.HasKey("ProductionId");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionActor", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CelebritieId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnOrder(2);

                    b.HasKey("ProductionId", "CelebritieId");

                    b.HasIndex("CelebritieId");

                    b.ToTable("ProductionActors");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionComment", b =>
                {
                    b.Property<int>("ProductionCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionCommentId"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("ProductionCommentId");

                    b.HasIndex("ProductionId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductionComments");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionCountry", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProductionId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("ProductionCountries");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionDirector", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CelebritieId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProductionId", "CelebritieId");

                    b.HasIndex("CelebritieId");

                    b.ToTable("ProductionDirectors");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionEpisod", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("Season")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Episod")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnOrder(3);

                    b.HasKey("ProductionId", "Season", "Episod");

                    b.ToTable("ProductionEpisods");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionGenre", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProductionId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("ProductionGenres");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionPicture", b =>
                {
                    b.Property<int>("ProductionPictureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionPictureId"), 1L, 1);

                    b.Property<byte[]>("Picture")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnOrder(2);

                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProductionPictureId");

                    b.HasIndex("ProductionId");

                    b.ToTable("ProductionPictures");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionRate", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("Stars")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("ProductionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductionRates");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionScreenwriter", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CelebritieId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProductionId", "CelebritieId");

                    b.HasIndex("CelebritieId");

                    b.ToTable("ProductionScreenwriters");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionTrailer", b =>
                {
                    b.Property<int>("ProductionTrailerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionTrailerId"), 1L, 1);

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnOrder(2);

                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.HasKey("ProductionTrailerId");

                    b.HasIndex("ProductionId");

                    b.ToTable("ProductionTrailers");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionWatchStatus", b =>
                {
                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("WatchStatus")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("ProductionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductionWatchStatuses");
                });

            modelBuilder.Entity("xfilmx.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(3);

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)")
                        .HasColumnOrder(4);

                    b.Property<int>("UserType")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("xfilmx.Models.News", b =>
                {
                    b.HasOne("xfilmx.Models.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionActor", b =>
                {
                    b.HasOne("xfilmx.Models.Celebritie", "Celebritie")
                        .WithMany("ProductionActors")
                        .HasForeignKey("CelebritieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionActors")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celebritie");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionComment", b =>
                {
                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionComments")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.User", "User")
                        .WithMany("ProductionComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");

                    b.Navigation("User");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionCountry", b =>
                {
                    b.HasOne("xfilmx.Models.Country", "Country")
                        .WithMany("ProductionCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionCountries")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionDirector", b =>
                {
                    b.HasOne("xfilmx.Models.Celebritie", "Celebritie")
                        .WithMany("ProductionDirectors")
                        .HasForeignKey("CelebritieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionDirectors")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celebritie");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionEpisod", b =>
                {
                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionEpisods")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionGenre", b =>
                {
                    b.HasOne("xfilmx.Models.Genre", "Genre")
                        .WithMany("ProductionGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionGenres")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionPicture", b =>
                {
                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionPictures")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionRate", b =>
                {
                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionRates")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.User", "User")
                        .WithMany("ProductionRates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");

                    b.Navigation("User");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionScreenwriter", b =>
                {
                    b.HasOne("xfilmx.Models.Celebritie", "Celebritie")
                        .WithMany("ProductionScreenwriters")
                        .HasForeignKey("CelebritieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionScreenwriters")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celebritie");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionTrailer", b =>
                {
                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionTrailers")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");
                });

            modelBuilder.Entity("xfilmx.Models.ProductionWatchStatus", b =>
                {
                    b.HasOne("xfilmx.Models.Production", "Production")
                        .WithMany("ProductionWatchStatuses")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xfilmx.Models.User", "User")
                        .WithMany("ProductionWatchStatuses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Production");

                    b.Navigation("User");
                });

            modelBuilder.Entity("xfilmx.Models.Celebritie", b =>
                {
                    b.Navigation("ProductionActors");

                    b.Navigation("ProductionDirectors");

                    b.Navigation("ProductionScreenwriters");
                });

            modelBuilder.Entity("xfilmx.Models.Country", b =>
                {
                    b.Navigation("ProductionCountries");
                });

            modelBuilder.Entity("xfilmx.Models.Genre", b =>
                {
                    b.Navigation("ProductionGenres");
                });

            modelBuilder.Entity("xfilmx.Models.Production", b =>
                {
                    b.Navigation("ProductionActors");

                    b.Navigation("ProductionComments");

                    b.Navigation("ProductionCountries");

                    b.Navigation("ProductionDirectors");

                    b.Navigation("ProductionEpisods");

                    b.Navigation("ProductionGenres");

                    b.Navigation("ProductionPictures");

                    b.Navigation("ProductionRates");

                    b.Navigation("ProductionScreenwriters");

                    b.Navigation("ProductionTrailers");

                    b.Navigation("ProductionWatchStatuses");
                });

            modelBuilder.Entity("xfilmx.Models.User", b =>
                {
                    b.Navigation("News");

                    b.Navigation("ProductionComments");

                    b.Navigation("ProductionRates");

                    b.Navigation("ProductionWatchStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
