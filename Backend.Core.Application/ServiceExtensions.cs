using System.Reflection;
using Backend.Core.Application.Shared.Behavior;
using Backend.Core.Application.UseCases.Class.CreateClass;
using Backend.Core.Application.UseCases.Class.DeleteClass;
using Backend.Core.Application.UseCases.Class.GetAllClasses;
using Backend.Core.Application.UseCases.Class.GetClassById;
using Backend.Core.Application.UseCases.Class.UpdateClass;
using Backend.Core.Application.UseCases.School.CreateSchool;
using Backend.Core.Application.UseCases.School.DeleteSchool;
using Backend.Core.Application.UseCases.School.GetAllSchools;
using Backend.Core.Application.UseCases.School.GetSchoolById;
using Backend.Core.Application.UseCases.School.UpdateSchool;
using Backend.Core.Application.UseCases.User.CreateUser;
using Backend.Core.Application.UseCases.User.DeleteUser;
using Backend.Core.Application.UseCases.User.GetAllUsers;
using Backend.Core.Application.UseCases.User.GetUserById;
using Backend.Core.Application.UseCases.User.UpdateUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient<CreateUserUseCase>();
        services.AddTransient<UpdateUserUseCase>();
        services.AddTransient<DeleteUserUseCase>();
        services.AddTransient<GetAllUsersUseCase>();
        services.AddTransient<GetUserByIdUseCase>();

        services.AddTransient<CreateSchoolUseCase>();
        services.AddTransient<UpdateSchoolUseCase>();
        services.AddTransient<DeleteSchoolUseCase>();
        services.AddTransient<GetAllSchoolsUseCase>();
        services.AddTransient<GetSchoolByIdUseCase>();

        services.AddTransient<CreateClassUseCase>();
        services.AddTransient<UpdateClassUseCase>();
        services.AddTransient<DeleteClassUseCase>();
        services.AddTransient<GetAllClassesUseCase>();
        services.AddTransient<GetClassByIdUseCase>();
    }
}
