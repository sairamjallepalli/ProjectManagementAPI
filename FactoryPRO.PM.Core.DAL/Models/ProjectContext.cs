using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCheckList> TblCheckList { get; set; }
        public virtual DbSet<TblCustomFields> TblCustomFields { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
        public virtual DbSet<TblList> TblList { get; set; }
        public virtual DbSet<TblProjects> TblProjects { get; set; }
        public virtual DbSet<TblSpace> TblSpace { get; set; }
        public virtual DbSet<TblTaskStatus> TblTaskStatus { get; set; }
        public virtual DbSet<TblTasks> TblTasks { get; set; }
        public virtual DbSet<TblTasksHistory> TblTasksHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ProjectManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCheckList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblCheckList");

                entity.Property(e => e.CheckListName).HasMaxLength(100);

                entity.Property(e => e.Cid)
                    .HasColumnName("CID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TaskId)
                    .HasColumnName("TaskID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__tblCheckL__TaskI__56E8E7AB");
            });

            modelBuilder.Entity<TblCustomFields>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK_CustomID");

                entity.ToTable("tblCustomFields");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FieldValue)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModuleId)
                    .IsRequired()
                    .HasColumnName("ModuleID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .IsRequired()
                    .HasColumnName("ProjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Revision)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblCustomFields)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblCustom__Proje__671F4F74");
            });

            modelBuilder.Entity<TblDocuments>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblDocuments");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Did)
                    .HasColumnName("DID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Files).HasMaxLength(1000);

                entity.Property(e => e.TaskId)
                    .HasColumnName("TaskID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__tblDocume__TaskI__58D1301D");
            });

            modelBuilder.Entity<TblList>(entity =>
            {
                entity.HasKey(e => e.ListId)
                    .HasName("PK_ListID");

                entity.ToTable("tblList");

                entity.Property(e => e.ListId)
                    .HasColumnName("ListID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Lid)
                    .HasColumnName("LID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ListName).HasMaxLength(500);

                entity.Property(e => e.ListOwnerId).HasColumnName("ListOwnerID");

                entity.Property(e => e.ListStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblList)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__tblList__Project__489AC854");
            });

            modelBuilder.Entity<TblProjects>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK_ProjectID");

                entity.ToTable("tblProjects");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ActualDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalPlanDate).HasColumnType("datetime");

                entity.Property(e => e.OverridePlanDate).HasColumnType("datetime");

                entity.Property(e => e.ParentProjectId)
                    .HasColumnName("ParentProjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pid)
                    .HasColumnName("PID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ProjectPhases)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStartDate).HasColumnType("datetime");

                entity.Property(e => e.Revision)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpaceId)
                    .HasColumnName("SpaceID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TargetDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Space)
                    .WithMany(p => p.TblProjects)
                    .HasForeignKey(d => d.SpaceId)
                    .HasConstraintName("FK__tblProjec__Space__45BE5BA9");
            });

            modelBuilder.Entity<TblSpace>(entity =>
            {
                entity.HasKey(e => e.SpaceId)
                    .HasName("PK_SpaceID");

                entity.ToTable("tblSpace");

                entity.Property(e => e.SpaceId)
                    .HasColumnName("SpaceID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModuleId)
                    .HasColumnName("ModuleID")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sid)
                    .HasColumnName("SID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SpaceName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<TblTaskStatus>(entity =>
            {
                entity.HasKey(e => e.TaskStatusId)
                    .HasName("PK_TaskStatusID");

                entity.ToTable("tblTaskStatus");

                entity.Property(e => e.TaskStatusId).HasColumnName("TaskStatusID");

                entity.Property(e => e.TaskStatusName).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK_TaskID");

                entity.ToTable("tblTasks");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TaskID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompletedEfforts).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EstimatedEfforts).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ListId)
                    .HasColumnName("ListID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("ProjectID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskName).HasMaxLength(2000);

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.TblTasks)
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("FK__tblTasks__ListID__4D5F7D71");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TblTasks)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__tblTasks__Projec__6166761E");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.TblTasks)
                    .HasForeignKey(d => d.TaskStatus)
                    .HasConstraintName("FK__tblTasks__TaskSt__4F47C5E3");
            });

            modelBuilder.Entity<TblTasksHistory>(entity =>
            {
                entity.HasKey(e => e.Tid)
                    .HasName("PK_TID");

                entity.ToTable("tblTasksHistory");

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.CompletedEfforts).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("DepartmentID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EstimatedEfforts).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IsRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ListId)
                    .HasColumnName("ListID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TaskID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.List)
                    .WithMany(p => p.TblTasksHistory)
                    .HasForeignKey(d => d.ListId)
                    .HasConstraintName("FK__tblTasksH__ListI__531856C7");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.TblTasksHistory)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__tblTasksH__TaskI__5224328E");

                entity.HasOne(d => d.TaskStatusNavigation)
                    .WithMany(p => p.TblTasksHistory)
                    .HasForeignKey(d => d.TaskStatus)
                    .HasConstraintName("FK__tblTasksH__TaskS__55009F39");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
