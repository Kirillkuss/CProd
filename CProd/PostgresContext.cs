using CProod;
using Microsoft.EntityFrameworkCore;

namespace CProd;
public partial class PostgresContext : DbContext
{
    public PostgresContext(){
    }

    public PostgresContext(DbContextOptions<PostgresContext> options): base(options){
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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<CardPatient>(entity =>{    
            entity.HasKey( e => e.IdCardPatient ).HasName( "card_patient_pkey" );
            entity.ToTable( "card_patient" );
            entity.Property( e => e.IdCardPatient ).HasColumnName( "id_card_patient" );
            entity.Property( e => e.Diagnosis ).HasMaxLength(50).HasColumnName( "diagnosis" );
            entity.Property( e => e.Allergy ).HasColumnName( "allergy" );
            entity.Property( e => e.Note ).HasMaxLength(255).HasColumnName( "note" );
            entity.Property(e => e.Conclusion ).HasMaxLength(255).HasColumnName( "сonclusion" );
            entity.Property(e => e.PatientId ).HasColumnName( "patient_id" );
            entity.HasOne(d => d.Patient).WithOne().HasForeignKey<CardPatient>(cp => cp.PatientId);
        });

        modelBuilder.Entity<Complaint>(entity =>{
            entity.HasKey( e => e.IdComplaint ).HasName( "complaint_pkey" );
            entity.ToTable( "complaint" );
            entity.Property( e => e.IdComplaint ).HasColumnName( "id_complaint" );
            entity.Property( e => e.FunctionalImpairment ).HasMaxLength(100).HasColumnName( "functional_impairment" );
        });

        modelBuilder.Entity<Doctor>(entity =>{
            entity.HasKey( e => e.IdDoctor ).HasName( "doctor_pkey" );
            entity.ToTable( "doctor" );
            entity.Property( e => e.IdDoctor ).HasColumnName( "id_doctor" );
            entity.Property( e => e.Surname ).HasMaxLength(30).HasColumnName( "surname" );
            entity.Property( e => e.Name ).HasMaxLength(30).HasColumnName( "name" );
            entity.Property( e => e.FullName ).HasMaxLength(30).HasColumnName( "full_name" );
        });

       modelBuilder.Entity<Document>(entity =>{    
            entity.HasKey( e => e.IdDocument ).HasName( "document_pkey" );
            entity.ToTable( "document" );
            entity.Property( e => e.IdDocument ).HasColumnName( "id_document" );
            entity.Property( e => e.TypeDocument ).HasMaxLength(40).HasColumnName( "type_document" );
            entity.Property( e => e.Seria ).HasMaxLength(20).HasColumnName( "seria" );
            entity.Property( e => e.Numar ).HasMaxLength(20).HasColumnName( "numar" );
            entity.Property(e => e.Snils ).HasMaxLength(20).HasColumnName( "snils" );
            entity.Property(e => e.Polis ).HasMaxLength(20).HasColumnName( "polis" );
        });

        modelBuilder.Entity<Drug>(entity =>{
            entity.HasKey( e => e.IdDrug ).HasName( "drug_pkey" );
            entity.ToTable( "drug" );
            entity.Property( e => e.IdDrug ).HasColumnName( "id_drug" );
            entity.Property( e => e.Name ).HasMaxLength(255).HasColumnName( "name" );
            entity.Property( e => e.DrugTreatmentId ).HasColumnName( "drug_treatment_id" );
            entity.HasOne(d => d.DrugTreatment).WithOne().HasForeignKey<Drug>(p => p.DrugTreatmentId);
        });

        modelBuilder.Entity<DrugTreatment>(entity =>{
            entity.HasKey( e => e.IdDrugTreatment ).HasName( "drug_treatment_pkey" );
            entity.ToTable( "drug_treatment" );
            entity.Property( e => e.IdDrugTreatment ).HasColumnName( "id_drug_treatment" );
            entity.Property( e => e.Name ).HasMaxLength(255).HasColumnName( "name" );
        });

        modelBuilder.Entity<Patient>(entity =>{
            entity.HasKey( e => e.IdPatient ).HasName( "patient_pkey" );
            entity.ToTable( "patient" );
            entity.Property( e => e.IdPatient ).HasColumnName( "id_patient" );
            entity.Property( e => e.Surname ).HasMaxLength(30).HasColumnName( "surname" );
            entity.Property( e => e.Name ).HasMaxLength(30).HasColumnName( "name" );
            entity.Property( e => e.FullName ).HasMaxLength(30).HasColumnName( "full_name" );
            entity.Property(e => e.Gender ).HasMaxLength(5).HasColumnName( "gender" );
            entity.Property(e => e.Phone ).HasMaxLength(12).HasColumnName( "phone" );
            entity.Property(e => e.Address ).HasMaxLength(100).HasColumnName( "address" );
            entity.Property(e => e.Document_id ).HasColumnName( "document_id" );
            entity.HasOne(d => d.Document).WithOne().HasForeignKey<Patient>(p => p.Document_id);
        });

        modelBuilder.Entity<RecordPatient>(entity =>{
            entity.HasKey( e => e.IdRecord ).HasName( "record_patient_pkey" );
            entity.ToTable( "record_patient" );
            entity.Property( e => e.IdRecord ).HasColumnName( "id_record" );
            entity.Property( e => e.DateRecord ).HasColumnName( "date_record" );
            entity.Property( e => e.DateAppointment ).HasColumnName( "date_appointment" );
            entity.Property( e => e.NumberRoom ).HasMaxLength(30).HasColumnName( "number_room" );
            entity.Property( e => e.DoctorId ).HasColumnName( "doctor_id" );  
            entity.HasOne(d => d.Doctor).WithOne().HasForeignKey<RecordPatient>(rp => rp.DoctorId );
            entity.Property(e => e.CardPatientId ).HasMaxLength(100).HasColumnName( "card_patient_id" );
        });

       modelBuilder.Entity<RehabilitationSolution>(entity =>{
            entity.HasKey( e => e.IdRehabilitationSolution ).HasName( "rehabilitation_solution_pkey" );
            entity.ToTable( "rehabilitation_solution" );
            entity.Property( e => e.IdRehabilitationSolution ).HasColumnName( "id_rehabilitation_solution" );
            entity.Property( e => e.Name ).HasMaxLength(100).HasColumnName( "name" );
            entity.Property( e => e.SurveyPlan ).HasMaxLength(255).HasColumnName( "survey_plan" );
        });

        modelBuilder.Entity<Treatment>(entity =>{
            entity.HasKey( e => e.IdTreatment ).HasName( "treatment_pkey" );
            entity.ToTable( "treatment" );
            entity.Property( e => e.IdTreatment ).HasColumnName( "id_treatment" );
            entity.Property( e => e.TimeStartTreatment ).HasColumnName( "time_start_treatment" );
            entity.Property( e => e.EndTimeTreatment ).HasColumnName( "end_time_treatment" );
            entity.Property( e => e.DrugId ).HasColumnName( "drug_id" );
            entity.HasOne(d => d.Drug).WithOne().HasForeignKey<Treatment>(p => p.DrugId);
            entity.Property( e => e.RehabilitationSolutionId ).HasColumnName( "rehabilitation_solution_id" );
            entity.HasOne(d => d.RehabilitationSolution).WithOne().HasForeignKey<Treatment>(p => p.RehabilitationSolutionId);
            entity.Property(e => e.CardPatientId ).HasColumnName( "card_patient_id" );
            entity.Property(e => e.DoctorId ).HasColumnName( "doctor_id" );
            entity.HasOne(d => d.Doctor).WithOne().HasForeignKey<Treatment>(p => p.DoctorId);
        });

        modelBuilder.Entity<TypeComplaint>(entity =>{
            entity.HasKey( e => e.IdTypeComplaint ).HasName( "type_complaint_pkey" );
            entity.ToTable( "type_complaint" );
            entity.Property( e => e.IdTypeComplaint ).HasColumnName( "id_type_complaint" );
            entity.Property( e => e.name ).HasMaxLength(150).HasColumnName( "name" );
            entity.HasOne( e => e.Complaint ).WithOne().HasForeignKey<Complaint>( c => c.IdComplaint );
        });

        modelBuilder.Entity<CardPatientComplaint>(entity =>{
            entity.HasNoKey().ToTable( "card_patient_complaint" );
            entity.Property( e => e.CardPatientId ).HasColumnName( "card_patient_id" );
            entity.Property( e => e.TypeComplaintId ).HasColumnName( "type_complaint_id" );
            entity.HasOne(e => e.IdTypeComplaintNavigation).WithMany()
                .HasForeignKey( tp => tp.TypeComplaintId )
                .HasConstraintName("card_patient_complaint_type_complaint_id_fkey");
            entity.HasOne(e => e.IdCardPatientNavigation).WithMany()
                .HasForeignKey( tp => tp.CardPatientId )
                .HasConstraintName("card_patient_complaint_card_patient_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
