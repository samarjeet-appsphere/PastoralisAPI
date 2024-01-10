using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pastorials.Models;

public partial class PastorialsContext : DbContext
{
    public PastorialsContext()
    {
    }

    public PastorialsContext(DbContextOptions<PastorialsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Blockreporthistory> Blockreporthistories { get; set; }

    public virtual DbSet<Bookingevent> Bookingevents { get; set; }

    public virtual DbSet<Bookingstatus> Bookingstatuses { get; set; }

    public virtual DbSet<Counselee> Counselees { get; set; }

    public virtual DbSet<Counsellingtype> Counsellingtypes { get; set; }

    public virtual DbSet<Entitytype> Entitytypes { get; set; }

    public virtual DbSet<Otpmail> Otpmails { get; set; }

    public virtual DbSet<Pastor> Pastors { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<Sessionstatus> Sessionstatuses { get; set; }

    public virtual DbSet<Slot> Slots { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<Surveyresponse> Surveyresponses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userentityaccess> Userentityaccesses { get; set; }

    public virtual DbSet<Userimage> Userimages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Pastorials;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Audit_Log_pkey");

            entity.ToTable("Audit_Log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.EventDescription)
                .HasColumnType("character varying")
                .HasColumnName("event_description");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.EventName)
                .HasColumnType("character varying")
                .HasColumnName("event_name");
            entity.Property(e => e.EventType)
                .HasColumnType("character varying")
                .HasColumnName("event_type");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Event).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("Audit_Log_event_id_fkey");
        });

        modelBuilder.Entity<Blockreporthistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("blockreporthistory_pkey");

            entity.ToTable("blockreporthistory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlockReason)
                .HasColumnType("character varying")
                .HasColumnName("block_reason");
            entity.Property(e => e.CounseleeId).HasColumnName("counselee_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.IsBlocked).HasColumnName("is_blocked");
            entity.Property(e => e.IsReported).HasColumnName("is_reported");
            entity.Property(e => e.PastorId).HasColumnName("pastor_id");
            entity.Property(e => e.ReportReason)
                .HasColumnType("character varying")
                .HasColumnName("report_reason");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Counselee).WithMany(p => p.Blockreporthistories)
                .HasForeignKey(d => d.CounseleeId)
                .HasConstraintName("blockreporthistory_counselee_id_fkey");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Blockreporthistories)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("blockreporthistory_created_by_fkey");

            entity.HasOne(d => d.Pastor).WithMany(p => p.Blockreporthistories)
                .HasForeignKey(d => d.PastorId)
                .HasConstraintName("blockreporthistory_pastor_id_fkey");
        });

        modelBuilder.Entity<Bookingevent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookingevent_pkey");

            entity.ToTable("bookingevent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BookingDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("booking_date");
            entity.Property(e => e.BookingStatusId).HasColumnName("booking_status_id");
            entity.Property(e => e.CounseleeId).HasColumnName("counselee_id");
            entity.Property(e => e.IsBooked).HasColumnName("is_booked");
            entity.Property(e => e.IsPaymentSuccessful).HasColumnName("is_payment_successful");
            entity.Property(e => e.PastorId).HasColumnName("pastor_id");
            entity.Property(e => e.SlotId).HasColumnName("slot_id");
            entity.Property(e => e.SubscriptionId).HasColumnName("subscription_id");
            entity.Property(e => e.SurveyAttempted).HasColumnName("survey_attempted");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.BookingStatus).WithMany(p => p.Bookingevents)
                .HasForeignKey(d => d.BookingStatusId)
                .HasConstraintName("bookingevent_booking_status_id_fkey");

            entity.HasOne(d => d.Counselee).WithMany(p => p.Bookingevents)
                .HasForeignKey(d => d.CounseleeId)
                .HasConstraintName("bookingevent_counselee_id_fkey");

            entity.HasOne(d => d.Pastor).WithMany(p => p.Bookingevents)
                .HasForeignKey(d => d.PastorId)
                .HasConstraintName("bookingevent_pastor_id_fkey");

            entity.HasOne(d => d.Slot).WithMany(p => p.Bookingevents)
                .HasForeignKey(d => d.SlotId)
                .HasConstraintName("bookingevent_slot_id_fkey");

            entity.HasOne(d => d.Subscription).WithMany(p => p.Bookingevents)
                .HasForeignKey(d => d.SubscriptionId)
                .HasConstraintName("bookingevent_subscription_id_fkey");
        });

        modelBuilder.Entity<Bookingstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("bookingstatus_pkey");

            entity.ToTable("bookingstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Counselee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("counselee_pkey");

            entity.ToTable("counselee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CounseleeEmail)
                .HasColumnType("character varying")
                .HasColumnName("counselee_email");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.SubscriptionType)
                .HasColumnType("character varying")
                .HasColumnName("subscription_type");
            entity.Property(e => e.SurveyAttempted).HasColumnName("survey_attempted");
        });

        modelBuilder.Entity<Counsellingtype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("counsellingtype_pkey");

            entity.ToTable("counsellingtype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CounsellingType1)
                .HasColumnType("character varying")
                .HasColumnName("counselling_type");
        });

        modelBuilder.Entity<Entitytype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("entitytype_pkey");

            entity.ToTable("entitytype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EntityType1)
                .HasMaxLength(100)
                .HasColumnName("entity_type");
        });

        modelBuilder.Entity<Otpmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("otpmail_pkey");

            entity.ToTable("otpmail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Otp)
                .HasColumnType("character varying")
                .HasColumnName("otp");
        });

        modelBuilder.Entity<Pastor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pastor_pkey");

            entity.ToTable("pastor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.PastorDescription).HasColumnName("pastor_description");
            entity.Property(e => e.PastorEmail)
                .HasColumnType("character varying")
                .HasColumnName("pastor_email");
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("plan_pkey");

            entity.ToTable("plan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.PlanCode)
                .HasColumnType("character varying")
                .HasColumnName("plan_code");
            entity.Property(e => e.PlanName)
                .HasColumnType("character varying")
                .HasColumnName("plan_name");
            entity.Property(e => e.PlanPeriod).HasColumnName("plan_period");
            entity.Property(e => e.PlanPrice).HasColumnName("plan_price");
            entity.Property(e => e.PlanType)
                .HasColumnType("character varying")
                .HasColumnName("plan_type");
            entity.Property(e => e.Plandate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("plandate");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rating_pkey");

            entity.ToTable("rating");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PastorId).HasColumnName("pastor_id");
            entity.Property(e => e.Rating1).HasColumnName("rating");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Pastor).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.PastorId)
                .HasConstraintName("rating_pastor_id_fkey");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("review_pkey");

            entity.ToTable("review");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.PastorId).HasColumnName("pastor_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewComment).HasColumnName("review_comment");
            entity.Property(e => e.ReviewedBy).HasColumnName("reviewed_by");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Pastor).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.PastorId)
                .HasConstraintName("review_pastor_id_fkey");

            entity.HasOne(d => d.ReviewedByNavigation).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("review_reviewed_by_fkey");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("session_pkey");

            entity.ToTable("session");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.IsPaymentSuccessful).HasColumnName("is_payment_successful");
            entity.Property(e => e.PlanId).HasColumnName("plan_id");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Event).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("session_event_id_fkey");

            entity.HasOne(d => d.Plan).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.PlanId)
                .HasConstraintName("session_plan_id_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("session_status_id_fkey");
        });

        modelBuilder.Entity<Sessionstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sessionstatus_pkey");

            entity.ToTable("sessionstatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Slot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("slot_pkey");

            entity.ToTable("slot");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_time");
            entity.Property(e => e.IsAvailable).HasColumnName("is_available");
            entity.Property(e => e.IsClosed).HasColumnName("is_closed");
            entity.Property(e => e.PastorId).HasColumnName("pastor_id");
            entity.Property(e => e.SlotDate).HasColumnName("slot_date");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Pastor).WithMany(p => p.Slots)
                .HasForeignKey(d => d.PastorId)
                .HasConstraintName("slot_pastor_id_fkey");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subscription_pkey");

            entity.ToTable("subscription");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("end_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.StartDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_date");
            entity.Property(e => e.SubscriptionPlan)
                .HasColumnType("character varying")
                .HasColumnName("subscription_plan");
            entity.Property(e => e.SubscriptionPrice).HasColumnName("subscription_price");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("survey_pkey");

            entity.ToTable("survey");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CounselingType).HasColumnName("counseling_type");
            entity.Property(e => e.DisplayOrder).HasColumnName("display_order");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Options)
                .HasColumnType("character varying")
                .HasColumnName("options");
            entity.Property(e => e.Question)
                .HasColumnType("character varying")
                .HasColumnName("question");

            entity.HasOne(d => d.CounselingTypeNavigation).WithMany(p => p.Surveys)
                .HasForeignKey(d => d.CounselingType)
                .HasConstraintName("survey_counseling_type_fkey");
        });

        modelBuilder.Entity<Surveyresponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("surveyresponse_pkey");

            entity.ToTable("surveyresponse");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CounseleeId).HasColumnName("counselee_id");
            entity.Property(e => e.CounselingType).HasColumnName("counseling_type");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Response)
                .HasColumnType("json")
                .HasColumnName("response");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");

            entity.HasOne(d => d.Counselee).WithMany(p => p.Surveyresponses)
                .HasForeignKey(d => d.CounseleeId)
                .HasConstraintName("surveyresponse_counselee_id_fkey");

            entity.HasOne(d => d.CounselingTypeNavigation).WithMany(p => p.Surveyresponses)
                .HasForeignKey(d => d.CounselingType)
                .HasConstraintName("surveyresponse_counseling_type_fkey");

            entity.HasOne(d => d.Question).WithMany(p => p.Surveyresponses)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("surveyresponse_question_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.HasIndex(e => e.UserEmail, "email_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.EntityType).HasColumnName("entity_type");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.LoginAttempt).HasColumnName("login_attempt");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserEmail)
                .HasColumnType("character varying")
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasColumnType("character varying")
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<Userentityaccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userentityaccess_pkey");

            entity.ToTable("userentityaccess");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.EntityId).HasColumnName("entity_id");
            entity.Property(e => e.EntityType).HasColumnName("entity_type");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.EntityTypeNavigation).WithMany(p => p.Userentityaccesses)
                .HasForeignKey(d => d.EntityType)
                .HasConstraintName("userentityaccess_entity_type_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Userentityaccesses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userentityaccess_user_id_fkey");
        });

        modelBuilder.Entity<Userimage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userimage_pkey");

            entity.ToTable("userimage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_date");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Userimages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("userimage_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
