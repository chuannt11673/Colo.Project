﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20200903083707_AddPostComments")]
    partial class AddPostComments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.ChatEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FromUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ToUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ToUserId");

                    b.HasIndex("FromUserId", "ToUserId")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Core.Entities.ChatFileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("FileId");

                    b.ToTable("ChatFileEntity");
                });

            modelBuilder.Entity("Core.Entities.FileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Core.Entities.FriendShipEntity", b =>
                {
                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("FriendShips");
                });

            modelBuilder.Entity("Core.Entities.NotificationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("ForAllUsers")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("NotificationEntity");
                });

            modelBuilder.Entity("Core.Entities.PostCommentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostCommentEntity");
                });

            modelBuilder.Entity("Core.Entities.PostEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Core.Entities.PostImageEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("PostId");

                    b.ToTable("PostImages");
                });

            modelBuilder.Entity("Core.Entities.PostLikeEntity", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("PostId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("PostLikeEntity");
                });

            modelBuilder.Entity("Core.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.UserFileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("FileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFileEntity");
                });

            modelBuilder.Entity("Core.Entities.UserLikeEntity", b =>
                {
                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("SenderId", "ReceiverId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("UserLikes");
                });

            modelBuilder.Entity("Core.Entities.ChatEntity", b =>
                {
                    b.HasOne("Core.Entities.UserEntity", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.ChatFileEntity", b =>
                {
                    b.HasOne("Core.Entities.ChatEntity", "Chat")
                        .WithMany("ChatFiles")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.FileEntity", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.FriendShipEntity", b =>
                {
                    b.HasOne("Core.Entities.UserEntity", "Receiver")
                        .WithMany("ReceivingFriendShips")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "Sender")
                        .WithMany("SendingFriendShips")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.NotificationEntity", b =>
                {
                    b.HasOne("Core.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Core.Entities.PostCommentEntity", b =>
                {
                    b.HasOne("Core.Entities.PostEntity", "Post")
                        .WithMany("PostComments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.PostEntity", b =>
                {
                    b.HasOne("Core.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.PostImageEntity", b =>
                {
                    b.HasOne("Core.Entities.FileEntity", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.PostEntity", "Post")
                        .WithMany("PostImages")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.PostLikeEntity", b =>
                {
                    b.HasOne("Core.Entities.PostEntity", "Post")
                        .WithMany("PostLikes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.UserFileEntity", b =>
                {
                    b.HasOne("Core.Entities.FileEntity", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "User")
                        .WithMany("UserFiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.UserLikeEntity", b =>
                {
                    b.HasOne("Core.Entities.UserEntity", "Receiver")
                        .WithMany("ReceivingUserLikes")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Core.Entities.UserEntity", "Sender")
                        .WithMany("SendingUserLikes")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
