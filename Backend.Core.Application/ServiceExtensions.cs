using System.Reflection;
using Backend.Core.Application.Shared.Behavior;
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
    }
}
