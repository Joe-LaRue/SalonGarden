﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalonGarden.Infrastructure.Data;

namespace SalonGarden.Infrastructure.Migrations
{
    [DbContext(typeof(SalonGardenContext))]
    [Migration("20190720184025_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview6.19304.10");

            modelBuilder.Entity("SalonGarden.Core.Entities.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("EducatorId");

                    b.Property<int>("EvaluationStatusId");

                    b.Property<int>("EvaluationTypeId");

                    b.Property<string>("StudentId");

                    b.Property<int>("TechniqueId");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationStatusId");

                    b.HasIndex("EvaluationTypeId");

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("EvaluationCriteriaGroupId");

                    b.Property<int>("SequenceNumber");

                    b.Property<int>("TotalPoints");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationCriteriaGroupId");

                    b.ToTable("EvaluationCriterias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Warm Welcome",
                            EvaluationCriteriaGroupId = 1,
                            SequenceNumber = 1,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Introduction",
                            EvaluationCriteriaGroupId = 1,
                            SequenceNumber = 2,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 3,
                            Description = "Sensory Experience",
                            EvaluationCriteriaGroupId = 2,
                            SequenceNumber = 1,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Listening Skills",
                            EvaluationCriteriaGroupId = 2,
                            SequenceNumber = 2,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 5,
                            Description = "Appropriate Questions",
                            EvaluationCriteriaGroupId = 2,
                            SequenceNumber = 3,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 6,
                            Description = "Maintenance/Product Reccomendations",
                            EvaluationCriteriaGroupId = 2,
                            SequenceNumber = 4,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 7,
                            Description = "Review/Agreement",
                            EvaluationCriteriaGroupId = 2,
                            SequenceNumber = 5,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 8,
                            Description = "Shampoo/Massage/Cleanup",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 1,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 9,
                            Description = "Clean Sections",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 2,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 10,
                            Description = "Body Position",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 3,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 11,
                            Description = "Knowledge of Technique",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 4,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 12,
                            Description = "Control",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 5,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 13,
                            Description = "Cross Check/Balance",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 6,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 14,
                            Description = "Completed On Time",
                            EvaluationCriteriaGroupId = 3,
                            SequenceNumber = 7,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 15,
                            Description = "Appropriate Conversation",
                            EvaluationCriteriaGroupId = 4,
                            SequenceNumber = 1,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 16,
                            Description = "Personal Appearance",
                            EvaluationCriteriaGroupId = 4,
                            SequenceNumber = 2,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 17,
                            Description = "Ask for Referrals/Rebooks",
                            EvaluationCriteriaGroupId = 4,
                            SequenceNumber = 3,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 18,
                            Description = "Explanation of Products",
                            EvaluationCriteriaGroupId = 5,
                            SequenceNumber = 1,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 19,
                            Description = "Sectioning",
                            EvaluationCriteriaGroupId = 5,
                            SequenceNumber = 2,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 20,
                            Description = "Control of Hair",
                            EvaluationCriteriaGroupId = 5,
                            SequenceNumber = 3,
                            TotalPoints = 0
                        },
                        new
                        {
                            Id = 21,
                            Description = "Teach Guest How to Recreate",
                            EvaluationCriteriaGroupId = 5,
                            SequenceNumber = 4,
                            TotalPoints = 0
                        });
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationCriteriaGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("SequenceNumber");

                    b.HasKey("Id");

                    b.ToTable("EvaluationCriteriaGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Greeting",
                            SequenceNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Consultation",
                            SequenceNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Technical",
                            SequenceNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Professionalism",
                            SequenceNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Styling",
                            SequenceNumber = 5
                        });
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationDetailItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AllocatedPoints");

                    b.Property<int>("EvaluationCriteriaId");

                    b.Property<int>("EvaluationId");

                    b.HasKey("Id");

                    b.HasIndex("EvaluationId");

                    b.ToTable("EvaluationDetailItem");
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("EvaluationStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Open"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Closed"
                        });
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("EvaluationType");
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.Technique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("TechniqueTypeId");

                    b.HasKey("Id");

                    b.ToTable("Techniques");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Vertical Foil",
                            TechniqueTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Diagonal Foil",
                            TechniqueTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Double Process",
                            TechniqueTypeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Single Process",
                            TechniqueTypeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "Scissor Over Comb",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "Clipper Cut",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 7,
                            Description = "Horizontal Graduation",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            Description = "Vertical Graduation",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 9,
                            Description = "Triangular graduation",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 10,
                            Description = "Short Graduation",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 11,
                            Description = "Short Round Layer",
                            TechniqueTypeId = 2
                        },
                        new
                        {
                            Id = 12,
                            Description = "Long Layer",
                            TechniqueTypeId = 2
                        });
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.TechniqueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("TechniqueTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Color"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Cut"
                        });
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.Evaluation", b =>
                {
                    b.HasOne("SalonGarden.Core.Entities.EvaluationStatus", "EvaluationStatus")
                        .WithMany()
                        .HasForeignKey("EvaluationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalonGarden.Core.Entities.EvaluationType", "EvaluationType")
                        .WithMany()
                        .HasForeignKey("EvaluationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationCriteria", b =>
                {
                    b.HasOne("SalonGarden.Core.Entities.EvaluationCriteriaGroup", null)
                        .WithMany("EvaluationCriteria")
                        .HasForeignKey("EvaluationCriteriaGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalonGarden.Core.Entities.EvaluationDetailItem", b =>
                {
                    b.HasOne("SalonGarden.Core.Entities.Evaluation", null)
                        .WithMany("EvaluationDetailItems")
                        .HasForeignKey("EvaluationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
