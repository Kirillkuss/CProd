using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CProd;

public partial class KlinikaContext : DbContext{
    public KlinikaContext(){
    }

    public KlinikaContext(DbContextOptions<KlinikaContext> options): base(options){
    }

    public virtual DbSet<CardPatient> CardPatients { get; set; }

    public virtual DbSet<Complaint> Complaints { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<DrugTreatment> DrugTreatments { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<RecordPatient> RecordPatients { get; set; }

    public virtual DbSet<RehabilitationSolution> RehabilitationSolutions { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<TypeComplaint> TypeComplaints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Klinika;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<CardPatient>(entity =>{
            entity.HasKey(e => e.IdCardPatient).HasName("card_patient_pkey");
            entity.ToTable("card_patient");
            entity.HasIndex(e => e.PatientId, "card_patient_patient_id_key").IsUnique();
            entity.Property(e => e.IdCardPatient).HasColumnName("id_card_patient");
            entity.Property(e => e.Allergy).HasColumnName("allergy");
            entity.Property(e => e.Diagnosis).HasMaxLength(50).HasColumnName("diagnosis");
            entity.Property(e => e.Note).HasMaxLength(255).HasColumnName("note");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Сonclusion).HasMaxLength(255).HasColumnName("сonclusion");
            entity.HasMany(d => d.TypeComplaints).WithMany(p => p.CardPatients)
                .UsingEntity<Dictionary<string, object>>(
                    "CardPatientComplaint",
                    r => r.HasOne<TypeComplaint>().WithMany()
                        .HasForeignKey("TypeComplaintId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("card_patient_complaint_type_complaint_id_fkey"),
                    l => l.HasOne<CardPatient>().WithMany()
                        .HasForeignKey("CardPatientId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("card_patient_complaint_card_patient_id_fkey"),
                    j =>
                    {
                        j.HasKey("CardPatientId", "TypeComplaintId").HasName("card_patient_complaint_pkey");
                        j.ToTable("card_patient_complaint");
                        j.IndexerProperty<int>("CardPatientId").HasColumnName("card_patient_id");
                        j.IndexerProperty<int>("TypeComplaintId").HasColumnName("type_complaint_id");
                    });
        });

        modelBuilder.Entity<Complaint>(entity =>{
            entity.HasKey(e => e.IdComplaint).HasName("complaint_pkey");
            entity.ToTable("complaint");
            entity.HasIndex(e => e.FunctionalImpairment, "complaint_functional_impairment_key").IsUnique();
            entity.Property(e => e.IdComplaint).HasColumnName("id_complaint");
            entity.Property(e => e.FunctionalImpairment).HasMaxLength(100).HasColumnName("functional_impairment");
        });

        modelBuilder.Entity<Doctor>(entity =>{
            entity.HasKey(e => e.IdDoctor).HasName("doctor_pkey");
            entity.ToTable("doctor");
            entity.Property(e => e.IdDoctor).HasColumnName("id_doctor");
            entity.Property(e => e.FullName).HasMaxLength(60).HasColumnName("full_name");
            entity.Property(e => e.Name).HasMaxLength(60).HasColumnName("name");
            entity.Property(e => e.Surname).HasMaxLength(60).HasColumnName("surname");
        });

        modelBuilder.Entity<Document>(entity =>{
            entity.HasKey(e => e.IdDocument).HasName("document_pkey");
            entity.ToTable("document");
            entity.HasIndex(e => e.Numar, "document_numar_key").IsUnique();
            entity.HasIndex(e => e.Polis, "document_polis_key").IsUnique();
            entity.HasIndex(e => e.Snils, "document_snils_key").IsUnique();
            entity.Property(e => e.IdDocument).HasColumnName("id_document");
            entity.Property(e => e.Numar).HasMaxLength(20).HasColumnName("numar");
            entity.Property(e => e.Polis).HasMaxLength(20).HasColumnName("polis");
            entity.Property(e => e.Seria).HasMaxLength(20).HasColumnName("seria");
            entity.Property(e => e.Snils).HasMaxLength(20).HasColumnName("snils");
            entity.Property(e => e.TypeDocument).HasMaxLength(40).HasColumnName("type_document");
        });

        modelBuilder.Entity<Drug>(entity =>{
            entity.HasKey(e => e.IdDrug).HasName("drug_pkey");
            entity.ToTable("drug");
            entity.HasIndex(e => e.Name, "drug_name_key").IsUnique();
            entity.Property(e => e.IdDrug).HasColumnName("id_drug");
            entity.Property(e => e.DrugTreatmentId).HasColumnName("drug_treatment_id");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
        });

        modelBuilder.Entity<DrugTreatment>(entity =>{
            entity.HasKey(e => e.IdDrugTreatment).HasName("drug_treatment_pkey");
            entity.ToTable("drug_treatment");
            entity.Property(e => e.IdDrugTreatment).HasColumnName("id_drug_treatment");
            entity.Property(e => e.Name).HasMaxLength(255).HasColumnName("name");
        });

        modelBuilder.Entity<Patient>(entity =>{
            entity.HasKey(e => e.IdPatient).HasName("patient_pkey");
            entity.ToTable("patient");
            entity.HasIndex(e => e.DocumentId, "patient_document_id_key").IsUnique();
            entity.HasIndex(e => e.Phone, "patient_phone_key").IsUnique();
            entity.Property(e => e.IdPatient).HasColumnName("id_patient");
            entity.Property(e => e.Address).HasMaxLength(100).HasColumnName("address");
            entity.Property(e => e.DocumentId).HasColumnName("document_id");
            entity.Property(e => e.FullName).HasMaxLength(30).HasColumnName("full_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name).HasMaxLength(30).HasColumnName("name");
            entity.Property(e => e.Phone).HasMaxLength(12).HasColumnName("phone");
            entity.Property(e => e.Surname).HasMaxLength(30).HasColumnName("surname");
        });

        modelBuilder.Entity<RecordPatient>(entity =>{
            entity.HasKey(e => e.IdRecord).HasName("record_patient_pkey");
            entity.ToTable("record_patient");
            entity.Property(e => e.IdRecord).HasColumnName("id_record");
            entity.Property(e => e.CardPatientId).HasColumnName("card_patient_id");
            entity.Property(e => e.DateAppointment).HasColumnType("timestamp(6) without time zone").HasColumnName("date_appointment");
            entity.Property(e => e.DateRecord).HasColumnType("timestamp(6) without time zone").HasColumnName("date_record");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.NumberRoom).HasColumnName("number_room");
        });

        modelBuilder.Entity<RehabilitationSolution>(entity =>{
            entity.HasKey(e => e.IdRehabilitationSolution).HasName("rehabilitation_solution_pkey");
            entity.ToTable("rehabilitation_solution");
            entity.HasIndex(e => e.Name, "rehabilitation_solution_name_key").IsUnique();
            entity.Property(e => e.IdRehabilitationSolution).HasColumnName("id_rehabilitation_solution");
            entity.Property(e => e.Name).HasMaxLength(100).HasColumnName("name");
            entity.Property(e => e.SurveyPlan).HasMaxLength(255).HasColumnName("survey_plan");
        });

        modelBuilder.Entity<Treatment>(entity =>{
            entity.HasKey(e => e.IdTreatment).HasName("treatment_pkey");
            entity.ToTable("treatment");
            entity.Property(e => e.IdTreatment).HasColumnName("id_treatment");
            entity.Property(e => e.CardPatientId).HasColumnName("card_patient_id");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.EndTimeTreatment).HasColumnType("timestamp(6) without time zone").HasColumnName("end_time_treatment");
            entity.Property(e => e.RehabilitationSolutionId).HasColumnName("rehabilitation_solution_id");
            entity.Property(e => e.TimeStartTreatment).HasColumnType("timestamp(6) without time zone").HasColumnName("time_start_treatment");
        });

        modelBuilder.Entity<TypeComplaint>(entity =>{
            entity.HasKey(e => e.IdTypeComplaint).HasName("type_complaint_pkey");
            entity.ToTable("type_complaint");
            entity.HasIndex(e => e.Name, "type_complaint_name_key").IsUnique();
            entity.Property(e => e.IdTypeComplaint).HasColumnName("id_type_complaint");
            entity.Property(e => e.ComplaintId).HasColumnName("complaint_id");
            entity.Property(e => e.Name).HasMaxLength(150).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
