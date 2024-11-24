using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Context;
using Backend.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options
            => options.UseMySql(
                configuration.GetConnectionString("Default"),
                ServerVersion.Parse("8.0.40-mysql")
            ));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<ILessonPlanRepository, LessonPlanRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IStudentActivityRepository, StudentActivityRepository>();
        services.AddScoped<IStudentPerformanceRepository, StudentPerformanceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
