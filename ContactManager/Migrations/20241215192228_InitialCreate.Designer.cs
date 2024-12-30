﻿// <auto-generated />
using ContactManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContactManager.Migrations
{
    [DbContext(typeof(ContactDatabase))]
    [Migration("20241215192228_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ContactManager.Database.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ContactManager.Database.EmailAddress", b =>
                {
                    b.Property<int>("EmailAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryEmailAddressCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EmailAddressId");

                    b.HasIndex("CategoryEmailAddressCategoryId");

                    b.HasIndex("ContactId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("ContactManager.Database.EmailAddressCategory", b =>
                {
                    b.Property<int>("EmailAddressCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("EmailAddressCategoryId");

                    b.ToTable("EmailAddressCategories");

                    b.HasData(
                        new
                        {
                            EmailAddressCategoryId = 1,
                            Label = "Personal"
                        },
                        new
                        {
                            EmailAddressCategoryId = 2,
                            Label = "Work"
                        },
                        new
                        {
                            EmailAddressCategoryId = 3,
                            Label = "Other"
                        });
                });

            modelBuilder.Entity("ContactManager.Database.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryPhoneNumberCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContactId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.HasKey("PhoneNumberId");

                    b.HasIndex("CategoryPhoneNumberCategoryId");

                    b.HasIndex("ContactId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("ContactManager.Database.PhoneNumberCategory", b =>
                {
                    b.Property<int>("PhoneNumberCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("PhoneNumberCategoryId");

                    b.ToTable("PhoneNumberCategories");

                    b.HasData(
                        new
                        {
                            PhoneNumberCategoryId = 1,
                            Label = "Home"
                        },
                        new
                        {
                            PhoneNumberCategoryId = 2,
                            Label = "Work"
                        },
                        new
                        {
                            PhoneNumberCategoryId = 3,
                            Label = "Mobile"
                        },
                        new
                        {
                            PhoneNumberCategoryId = 4,
                            Label = "Other"
                        });
                });

            modelBuilder.Entity("ContactManager.Database.EmailAddress", b =>
                {
                    b.HasOne("ContactManager.Database.EmailAddressCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryEmailAddressCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContactManager.Database.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("ContactManager.Database.PhoneNumber", b =>
                {
                    b.HasOne("ContactManager.Database.PhoneNumberCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryPhoneNumberCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContactManager.Database.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Contact");
                });
#pragma warning restore 612, 618
        }
    }
}
