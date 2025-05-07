using System;
using System.Collections.Generic;
using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public partial class MilitaryPersonnelContext : IdentityDbContext<IdentityUser>
{
    public MilitaryPersonnelContext()
    {
    }

    public MilitaryPersonnelContext(DbContextOptions<MilitaryPersonnelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Awards> Awards { get; set; }
    public virtual DbSet<CharacterTraits> CharacterTraits { get; set; }
    public virtual DbSet<CivilProfessions> CivilProfessions { get; set; }
    public virtual DbSet<ContactInfo> ContactInfo { get; set; }
    public virtual DbSet<DischargeLog> DischargeLog { get; set; }
    public virtual DbSet<Discharges> Discharges { get; set; }
    public virtual DbSet<DocumentAssignments> DocumentAssignments { get; set; }
    public virtual DbSet<DocumentFlow> DocumentFlow { get; set; }
    public virtual DbSet<DocumentStatuses> DocumentStatuses { get; set; }
    public virtual DbSet<DocumentTypes> DocumentTypes { get; set; }
    public virtual DbSet<Documents> Documents { get; set; }
    public virtual DbSet<Educations> Educations { get; set; }
    public virtual DbSet<FamilyMembers> FamilyMembers { get; set; }
    public virtual DbSet<FitnessCategories> FitnessCategories { get; set; }
    public virtual DbSet<LanguageSkills> LanguageSkills { get; set; }
    public virtual DbSet<MedicalRecords> MedicalRecords { get; set; }
    public virtual DbSet<MilitarySpecialties> MilitarySpecialties { get; set; }
    public virtual DbSet<MilitaryUnits> MilitaryUnits { get; set; }
    public virtual DbSet<MobilizationListEntries> MobilizationListEntries { get; set; }
    public virtual DbSet<MobilizationLists> MobilizationLists { get; set; }
    public virtual DbSet<OperationalReadiness> OperationalReadiness { get; set; }
    public virtual DbSet<Positions> Positions { get; set; }
    public virtual DbSet<PsychologicalProfiles> PsychologicalProfiles { get; set; }
    public virtual DbSet<Punishments> Punishments { get; set; }
    public virtual DbSet<RankAssignments> RankAssignments { get; set; }
    public virtual DbSet<Ranks> Ranks { get; set; }
    public virtual DbSet<Recruitments> Recruitments { get; set; }
    public virtual DbSet<Resolutions> Resolutions { get; set; }
    public virtual DbSet<ServiceAttitudes> ServiceAttitudes { get; set; }
    public virtual DbSet<ServiceForms> ServiceForms { get; set; }
    public virtual DbSet<ServiceHistory> ServiceHistory { get; set; }
    public virtual DbSet<ServiceStatuses> ServiceStatuses { get; set; }
    public virtual DbSet<Servicemen> Servicemen { get; set; }
    public virtual DbSet<Subdivisions> Subdivisions { get; set; }
    public virtual DbSet<Trainings> Trainings { get; set; }
    public virtual DbSet<vw_ServicemenDetails> vw_ServicemenDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=MilitaryPersonnelDB;TrustServerCertificate=True;Integrated Security=True");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(login => new { login.LoginProvider, login.ProviderKey });

        modelBuilder.Entity<Awards>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Awards__3214EC07881247D0");
            entity.Property(e => e.AwardName).HasMaxLength(255);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.Awards)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Awards__Servicem__59FA5E80");
        });

        modelBuilder.Entity<CharacterTraits>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC07D4C6FF8D");
            entity.Property(e => e.TraitName).HasMaxLength(100);
        });

        modelBuilder.Entity<CivilProfessions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CivilPro__3214EC077F9C80FE");
            entity.Property(e => e.ProfessionName).HasMaxLength(255);
        });

        modelBuilder.Entity<ContactInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactI__3214EC07149FCB2F");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.ContactInfo)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__ContactIn__Servi__4CA06362");
        });

        modelBuilder.Entity<DischargeLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discharg__3214EC078EB882C8");
            entity.Property(e => e.DischargeReason).HasMaxLength(255);
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Discharges>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discharg__3214EC0705A57DC8");
            entity.ToTable(tb => tb.HasTrigger("trg_AfterDischarge"));
            entity.Property(e => e.DischargeReason).HasMaxLength(255);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.Discharges)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Discharge__Servi__778AC167");
        });

        modelBuilder.Entity<DocumentAssignments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC073023A88A");
            entity.Property(e => e.AssignedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsCompleted).HasDefaultValue(false);
            entity.HasOne(d => d.Assignee).WithMany(p => p.DocumentAssignments)
                .HasForeignKey(d => d.AssigneeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentA__Assig__0F624AF8");
            entity.HasOne(d => d.Document).WithMany(p => p.DocumentAssignments)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentA__Docum__0E6E26BF");
        });

        modelBuilder.Entity<DocumentFlow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07E1B26C88");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(255);
            entity.HasOne(d => d.CreatedBy).WithMany(p => p.DocumentFlowCreatedBy)
                .HasForeignKey(d => d.CreatedById)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentF__Creat__08B54D69");
            entity.HasOne(d => d.DocumentType).WithMany(p => p.DocumentFlow)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentF__Docum__07C12930");
            entity.HasOne(d => d.MilitaryUnit).WithMany(p => p.DocumentFlow)
                .HasForeignKey(d => d.MilitaryUnitId)
                .HasConstraintName("FK_DocumentFlow_MilitaryUnits");
            entity.HasOne(d => d.Serviceman).WithMany(p => p.DocumentFlowServiceman)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK_DocumentFlow_Servicemen");
            entity.HasOne(d => d.Status).WithMany(p => p.DocumentFlow)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DocumentF__Statu__09A971A2");
        });

        modelBuilder.Entity<DocumentStatuses>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07E89C3F9A");
            entity.Property(e => e.StatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<DocumentTypes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07CD20F36A");
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Documents>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC0771F975FB");
            entity.Property(e => e.DocumentNumber).HasMaxLength(50);
            entity.Property(e => e.DocumentType).HasMaxLength(100);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Documents__Servi__4F7CD00D");
        });

        modelBuilder.Entity<Educations>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC07B1A6D7E0");
            entity.Property(e => e.EducationLevel).HasMaxLength(255);
            entity.Property(e => e.Institution).HasMaxLength(255);
            entity.Property(e => e.Specialty).HasMaxLength(255);
        });

        modelBuilder.Entity<FamilyMembers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FamilyMe__3214EC07AB47F928");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Relationship).HasMaxLength(100);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.FamilyMembers)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__FamilyMem__Servi__5FB337D6");
        });

        modelBuilder.Entity<FitnessCategories>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FitnessC__3214EC07EB94EAC7");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<LanguageSkills>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Language__3214EC07AF825A04");
            entity.Property(e => e.Language).HasMaxLength(100);
            entity.Property(e => e.ProficiencyLevel).HasMaxLength(100);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.LanguageSkills)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__LanguageS__Servi__68487DD7");
        });

        modelBuilder.Entity<MedicalRecords>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MedicalR__3214EC0702719F01");
            entity.Property(e => e.MedicalCondition).HasMaxLength(255);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__MedicalRe__Servi__571DF1D5");
        });

        modelBuilder.Entity<MilitarySpecialties>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Military__3214EC07CAA81010");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.SpecialtyName).HasMaxLength(255);
        });

        modelBuilder.Entity<MilitaryUnits>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Military__3214EC07012DC185");
            entity.Property(e => e.UnitName).HasMaxLength(255);
        });

        modelBuilder.Entity<MobilizationListEntries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mobiliza__3214EC07B7B39F81");
            entity.HasOne(d => d.MobilizationList).WithMany(p => p.MobilizationListEntries)
                .HasForeignKey(d => d.MobilizationListId)
                .HasConstraintName("FK__Mobilizat__Mobil__70DDC3D8");
            entity.HasOne(d => d.Serviceman).WithMany(p => p.MobilizationListEntries)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Mobilizat__Servi__71D1E811");
        });

        modelBuilder.Entity<MobilizationLists>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Mobiliza__3214EC070B4DC6E3");
            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ListName).HasMaxLength(255);
        });

        modelBuilder.Entity<OperationalReadiness>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Operatio__3214EC075219E08E");
            entity.Property(e => e.ReadinessStatus).HasMaxLength(255);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.OperationalReadiness)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Operation__Servi__6B24EA82");
        });

        modelBuilder.Entity<Positions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC07AC1015C1");
            entity.Property(e => e.PositionName).HasMaxLength(255);
        });

        modelBuilder.Entity<PsychologicalProfiles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Psycholo__3214EC07689799C3");
            entity.Property(e => e.ProfileDescription).HasMaxLength(1000);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.PsychologicalProfiles)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Psycholog__Servi__628FA481");
        });

        modelBuilder.Entity<Punishments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Punishme__3214EC07B1C352BD");
            entity.Property(e => e.PunishmentDescription).HasMaxLength(255);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.Punishments)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Punishmen__Servi__5CD6CB2B");
        });

        modelBuilder.Entity<RankAssignments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RankAssi__3214EC072558147C");
            entity.HasOne(d => d.Rank).WithMany(p => p.RankAssignments)
                .HasForeignKey(d => d.RankId)
                .HasConstraintName("FK__RankAssig__RankI__49C3F6B7");
            entity.HasOne(d => d.Serviceman).WithMany(p => p.RankAssignments)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__RankAssig__Servi__48CFD27E");
        });

        modelBuilder.Entity<Ranks>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ranks__3214EC0766BDA39B");
            entity.Property(e => e.RankName).HasMaxLength(100);
        });

        modelBuilder.Entity<Recruitments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recruitm__3214EC07D3EAAC26");
            entity.HasOne(d => d.Serviceman).WithMany(p => p.Recruitments)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Recruitme__Servi__74AE54BC");
        });

        modelBuilder.Entity<Resolutions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resoluti__3214EC075C445D1B");
            entity.Property(e => e.ResolutionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.HasOne(d => d.Author).WithMany(p => p.Resolutions)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resolutio__Autho__14270015");
            entity.HasOne(d => d.Document).WithMany(p => p.Resolutions)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Resolutio__Docum__1332DBDC");
        });

        modelBuilder.Entity<ServiceAttitudes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceA__3214EC07DA82ECE5");
            entity.Property(e => e.AttitudeDescription).HasMaxLength(255);
        });

        modelBuilder.Entity<ServiceForms>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceF__3214EC07E60223CC");
            entity.Property(e => e.FormName).HasMaxLength(100);
        });

        modelBuilder.Entity<ServiceHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceH__3214EC07FF563193");
            entity.HasOne(d => d.Position).WithMany(p => p.ServiceHistory)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__ServiceHi__Posit__534D60F1");
            entity.HasOne(d => d.Serviceman).WithMany(p => p.ServiceHistory)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__ServiceHi__Servi__52593CB8");
            entity.HasOne(d => d.Subdivision).WithMany(p => p.ServiceHistory)
                .HasForeignKey(d => d.SubdivisionId)
                .HasConstraintName("FK__ServiceHi__Subdi__5441852A");
        });

        modelBuilder.Entity<ServiceStatuses>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceS__3214EC073F7CFCAD");
            entity.Property(e => e.StatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<Servicemen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Servicem__3214EC076662FD23");
            entity.ToTable(tb => tb.HasTrigger("trg_AfterInsertServiceman"));
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsOfficer).HasDefaultValue(false);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.HasOne(d => d.CharacterTrait).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.CharacterTraitId)
                .HasConstraintName("FK__Serviceme__Chara__4222D4EF");
            entity.HasOne(d => d.CivilProfession).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.CivilProfessionId)
                .HasConstraintName("FK__Serviceme__Civil__3C69FB99");
            entity.HasOne(d => d.Education).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.EducationId)
                .HasConstraintName("FK__Serviceme__Educa__3E52440B");
            entity.HasOne(d => d.FitnessCategory).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.FitnessCategoryId)
                .HasConstraintName("FK__Serviceme__Fitne__44FF419A");
            entity.HasOne(d => d.MilitarySpecialty).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.MilitarySpecialtyId)
                .HasConstraintName("FK__Serviceme__Milit__3D5E1FD2");
            entity.HasOne(d => d.Position).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Serviceme__Posit__3F466844");
            entity.HasOne(d => d.ServiceAttitude).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.ServiceAttitudeId)
                .HasConstraintName("FK__Serviceme__Servi__4316F928");
            entity.HasOne(d => d.ServiceForm).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.ServiceFormId)
                .HasConstraintName("FK__Serviceme__Servi__412EB0B6");
            entity.HasOne(d => d.ServiceStatus).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.ServiceStatusId)
                .HasConstraintName("FK__Serviceme__Servi__440B1D61");
            entity.HasOne(d => d.Subdivision).WithMany(p => p.Servicemen)
                .HasForeignKey(d => d.SubdivisionId)
                .HasConstraintName("FK__Serviceme__Subdi__403A8C7D");
        });

        modelBuilder.Entity<Subdivisions>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subdivis__3214EC07374AB499");
            entity.Property(e => e.SubdivisionName).HasMaxLength(255);
            entity.HasOne(d => d.MilitaryUnit).WithMany(p => p.Subdivisions)
                .HasForeignKey(d => d.MilitaryUnitId)
                .HasConstraintName("FK__Subdivisi__Milit__267ABA7A");
        });

        modelBuilder.Entity<Trainings>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Training__3214EC071F9F2F71");
            entity.Property(e => e.TrainingName).HasMaxLength(255);
            entity.HasOne(d => d.Serviceman).WithMany(p => p.Trainings)
                .HasForeignKey(d => d.ServicemanId)
                .HasConstraintName("FK__Trainings__Servi__656C112C");
        });

        modelBuilder.Entity<vw_ServicemenDetails>(entity =>
        {
            entity.HasNoKey().ToView("vw_ServicemenDetails");
            entity.Property(e => e.CivilProfession).HasMaxLength(255);
            entity.Property(e => e.EducationLevel).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.MilitarySpecialty).HasMaxLength(255);
            entity.Property(e => e.MilitaryUnit).HasMaxLength(255);
            entity.Property(e => e.PositionName).HasMaxLength(255);
            entity.Property(e => e.RankName).HasMaxLength(100);
            entity.Property(e => e.ServiceForm).HasMaxLength(100);
            entity.Property(e => e.SubdivisionName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}