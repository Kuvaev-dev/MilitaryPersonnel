using Database.Context;
using Database.Repositories;
using DinkToPdf.Contracts;
using DinkToPdf;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace MilitaryPersonnel
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ukrainianCulture = new CultureInfo("uk-UA");
            CultureInfo.DefaultThreadCurrentCulture = ukrainianCulture;
            CultureInfo.DefaultThreadCurrentUICulture = ukrainianCulture;

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<MilitaryPersonnelContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<MilitaryPersonnelContext>()
                .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Login";
                options.AccessDeniedPath = "/Home/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

            builder.Services.AddScoped<IAwardRepository, AwardRepository>();
            builder.Services.AddScoped<ICharacterTraitRepository, CharacterTraitRepository>();
            builder.Services.AddScoped<ICivilProfessionRepository, CivilProfessionRepository>();
            builder.Services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
            builder.Services.AddScoped<IDischargeLogRepository, DischargeLogRepository>();
            builder.Services.AddScoped<IDischargeRepository, DischargeRepository>();
            builder.Services.AddScoped<IDocumentAssignmentRepository, DocumentAssignmentRepository>();
            builder.Services.AddScoped<IDocumentFlowRepository, DocumentFlowRepository>();
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
            builder.Services.AddScoped<IDocumentStatusRepository, DocumentStatusRepository>();
            builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            builder.Services.AddScoped<IEducationRepository, EducationRepository>();
            builder.Services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
            builder.Services.AddScoped<IFitnessCategoryRepository, FitnessCategoryRepository>();
            builder.Services.AddScoped<ILanguageSkillRepository, LanguageSkillRepository>();
            builder.Services.AddScoped<IMedicalRecordRepsitory, MedicalRecordRepsitory>();
            builder.Services.AddScoped<IMilitarySpecialtyRepository, MilitarySpecialtyRepository>();
            builder.Services.AddScoped<IMilitaryUnitRepository, MilitaryUnitRepository>();
            builder.Services.AddScoped<IMobilizationListEntryRepository, MobilizationListEntryRepository>();
            builder.Services.AddScoped<IMobilizationListRepository, MobilizationListRepository>();
            builder.Services.AddScoped<IOperationalReadinessRepository, OperationalReadinessRepository>();
            builder.Services.AddScoped<IPositionRepository, PositionRepository>();
            builder.Services.AddScoped<IPsychologicalProfileRepository, PsychologicalProfileRepository>();
            builder.Services.AddScoped<IPunishmentRepository, PunishmentRepository>();
            builder.Services.AddScoped<IResolutionRepository, ResolutionRepository>();
            builder.Services.AddScoped<IServiceAttitudeRepository, ServiceAttitudeRepository>();
            builder.Services.AddScoped<IServiceFormRepository, ServiceFormRepository>();
            builder.Services.AddScoped<IServiceHistoryRepository, ServiceHistoryRepository>();
            builder.Services.AddScoped<IServicemanRepository, ServicemanRepository>();
            builder.Services.AddScoped<IServiceStatusRepository, ServiceStatusRepository>();
            builder.Services.AddScoped<ISubdivisionRepository, SubdivisionRepository>();
            builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
