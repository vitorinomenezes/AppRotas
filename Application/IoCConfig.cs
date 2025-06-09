using Application.MappingProfiles;
using Application.Services;
using Domain.Abstractions;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class IoCConfig
    {
        /// <summary>
        /// Inversão de Controle (IoC) é realizada principalmente por meio de Injeção de Dependência (DI).
        /// Em especifico a aplicação necessariamente precisa de um container IoC para resolver as dependências entre os serviços e repositórios.
        /// Então nada mais justo do quê deixa-la responsavel por essa tarefa.
        /// </summary>
        public static IServiceCollection ApplyIoC(this IServiceCollection services)
        {
            // Add Repositories
            services.AddTransient<DbContext, ApplicationDbContext>();
            services.AddTransient<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddTransient<IRouterRepository, RouteRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            // Add Services
            services.AddScoped<RouteService>();
            services.AddScoped<UsersService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(RouteProfile).Assembly);

            return services;
        }
    }
        }
