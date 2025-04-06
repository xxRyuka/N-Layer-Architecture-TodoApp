using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLayer_TodoApp.Business.DependencyResolvers.Microsoft;
using NLayer_TodoApp.Business.Interfaces;
using NLayer_TodoApp.Business.Mappings.AutoMapper;
using NLayer_TodoApp.Business.Services;
using NLayer_TodoApp.DataAccess.Contexts;
using NLayer_TodoApp.DataAccess.UnitOfWork;

namespace NLayer_TodoApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
         {
            services.AddDbContext<TodoContext>(opt=>
            {
            opt.UseSqlServer("Server=Ryuka; Database=TodoAppDb;Integrated Security=True;TrustServerCertificate=True");
            opt.LogTo(Console.WriteLine,LogLevel.Information);
            });

            var config = new MapperConfiguration(opt => opt.AddProfile(new WorkProfile()));
            
            var mapper = config.CreateMapper();
            
            
            services.AddSingleton(mapper);
            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkService, WorkService>();
         }
    }
}