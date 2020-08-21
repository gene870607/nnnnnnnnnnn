using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Storyteller.DBModels
{
    public partial class GoodGood_DBContext : DbContext
    {
        public GoodGood_DBContext()
        {
        }

        public GoodGood_DBContext(DbContextOptions<GoodGood_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BestCreation> BestCreation { get; set; }
        public virtual DbSet<BestCreationDetail> BestCreationDetail { get; set; }
        public virtual DbSet<Cgimage> Cgimage { get; set; }
        public virtual DbSet<Img> Img { get; set; }
        public virtual DbSet<Script> Script { get; set; }
        public virtual DbSet<ScriptCategory> ScriptCategory { get; set; }
        public virtual DbSet<ScriptDetail> ScriptDetail { get; set; }
        public virtual DbSet<ScriptJsonfour> ScriptJsonfour { get; set; }
        public virtual DbSet<ScriptJsonone> ScriptJsonone { get; set; }
        public virtual DbSet<ScriptJsonthree> ScriptJsonthree { get; set; }
        public virtual DbSet<ScriptJsontwo> ScriptJsontwo { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=leidba.database.windows.net;Database=GoodGood_DB;Trusted_Connection=False;User=leidba;Password=!qaz2wsx");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BestCreation>(entity =>
            {
                entity.Property(e => e.BestCreationId)
                    .HasColumnName("BestCreationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ScriptId).HasColumnName("ScriptID");

                entity.HasOne(d => d.Script)
                    .WithMany(p => p.BestCreation)
                    .HasForeignKey(d => d.ScriptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BestCreation_Script");
            });

            modelBuilder.Entity<BestCreationDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BestCreationId).HasColumnName("BestCreationID");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.BestCreation)
                    .WithMany()
                    .HasForeignKey(d => d.BestCreationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BestCreationDetail_BestCreation");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BestCreationDetail_User");
            });

            modelBuilder.Entity<Cgimage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CGImage");

                entity.Property(e => e.ScriptId).HasColumnName("ScriptID");

                entity.HasOne(d => d.Script)
                    .WithMany()
                    .HasForeignKey(d => d.ScriptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CGImage_Script");
            });

            modelBuilder.Entity<Img>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ScriptId).HasColumnName("ScriptID");

                entity.HasOne(d => d.Script)
                    .WithMany()
                    .HasForeignKey(d => d.ScriptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Img_Script");
            });

            modelBuilder.Entity<Script>(entity =>
            {
                entity.Property(e => e.ScriptId).HasColumnName("ScriptID");

                entity.Property(e => e.ScriptCategoryId).HasColumnName("ScriptCategoryID");

                entity.Property(e => e.ScriptDuration).HasMaxLength(10);

                entity.Property(e => e.ScriptLaunchedDate).HasColumnType("datetime");

                entity.Property(e => e.ScriptName).HasMaxLength(50);

                entity.HasOne(d => d.ScriptCategory)
                    .WithMany(p => p.Script)
                    .HasForeignKey(d => d.ScriptCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Script_ScriptCategory");
            });

            modelBuilder.Entity<ScriptCategory>(entity =>
            {
                entity.Property(e => e.ScriptCategoryId)
                    .HasColumnName("ScriptCategoryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tag).HasMaxLength(20);
            });

            modelBuilder.Entity<ScriptDetail>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CharacterIntroduction).HasMaxLength(100);

                entity.Property(e => e.CharacterName).HasMaxLength(20);

                entity.Property(e => e.ScriptId).HasColumnName("ScriptID");

                entity.HasOne(d => d.Script)
                    .WithMany()
                    .HasForeignKey(d => d.ScriptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScriptDetail_Script");
            });

            modelBuilder.Entity<ScriptJsonfour>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ScriptJSONFour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.GoSectionIndexNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.GoSectionIndex)
                    .HasConstraintName("FK_ScriptJSONFour_ScriptJSONThree");
            });

            modelBuilder.Entity<ScriptJsonone>(entity =>
            {
                entity.HasKey(e => e.CharacterId)
                    .HasName("PK_ScriptJSON_1");

                entity.ToTable("ScriptJSONOne");

                entity.Property(e => e.CharacterId)
                    .HasColumnName("CharacterID")
                    .ValueGeneratedNever();

                entity.Property(e => e.MainText).HasMaxLength(50);

                entity.Property(e => e.Roles).HasMaxLength(10);

                entity.Property(e => e.ScriptId).HasColumnName("ScriptID");

                entity.HasOne(d => d.Script)
                    .WithMany(p => p.ScriptJsonone)
                    .HasForeignKey(d => d.ScriptId)
                    .HasConstraintName("FK_ScriptJSONOne_Script");
            });

            modelBuilder.Entity<ScriptJsonthree>(entity =>
            {
                entity.HasKey(e => e.GoSectionIndex)
                    .HasName("PK_ScriptThree");

                entity.ToTable("ScriptJSONThree");

                entity.Property(e => e.GoSectionIndex).ValueGeneratedNever();

                entity.Property(e => e.Input)
                    .HasColumnName("input")
                    .HasMaxLength(100);

                entity.Property(e => e.InputText).HasMaxLength(100);

                entity.Property(e => e.OptionDesc).HasMaxLength(50);

                entity.HasOne(d => d.TrueOrFalseNavigation)
                    .WithMany(p => p.ScriptJsonthree)
                    .HasForeignKey(d => d.TrueOrFalse)
                    .HasConstraintName("FK_ScriptJSONThree_ScriptJSONTwo");
            });

            modelBuilder.Entity<ScriptJsontwo>(entity =>
            {
                entity.HasKey(e => e.TrueOrFalse);

                entity.ToTable("ScriptJSONTwo");

                entity.Property(e => e.TrueOrFalse).ValueGeneratedNever();

                entity.Property(e => e.Cgimg).HasColumnName("CGImg");

                entity.Property(e => e.CharacterId).HasColumnName("CharacterID");

                entity.Property(e => e.Conversation).HasMaxLength(50);

                entity.Property(e => e.Issue).HasMaxLength(50);

                entity.Property(e => e.Script).HasMaxLength(50);

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.ScriptJsontwo)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK_ScriptJSONTwo_ScriptJSONOne");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserData>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DisplayAchievement).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserData_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
