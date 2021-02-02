using Autofac;
using AutoMapper;
using ClothingStoreFranchise.NetCore.Common.RabbitMq;
using ClothingStoreFranchise.NetCore.Common.RabbitMq.Impl;
using ClothingStoreFranchise.NetCore.Employees.Dao;
using ClothingStoreFranchise.NetCore.Employees.Dao.Impl;
using ClothingStoreFranchise.NetCore.Employees.EventHandlers;
using ClothingStoreFranchise.NetCore.Employees.Facade;
using ClothingStoreFranchise.NetCore.Employees.Facade.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Linq;
using System.Reflection;

namespace ClothingStoreFranchise.NetCore.Employees
{
    public static class EmployeesServiceCollection
    {
        public static void AddEmployeesServices(this IServiceCollection services)
        {
            services.AddScoped<IShopDao, ShopDao>();
            services.AddScoped<IWarehouseDao, WarehouseDao>();
            services.AddScoped<IWarehouseEmployeeDao, WarehouseEmployeeDao>();
            services.AddScoped<IShopEmployeeDao, ShopEmployeeDao>();

            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWarehouseEmployeeService, WarehouseEmployeeService>();
            services.AddScoped<IShopEmployeeService, ShopEmployeeService>();

            services.AddAutoMapper(typeof(Startup).GetTypeInfo().Assembly);
        }

        public static IServiceCollection AddEventBus(this IServiceCollection services, RabbitMqOptions options)
        {

            var subscriptionClientName = options.Namespace;

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = options.Retries;

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            services.AddTransient<WarehouseCreatedHandler>();
            services.AddTransient<WarehouseUpdatedHandler>();
            services.AddTransient<ShopCreatedHandler>();
            services.AddTransient<ShopUpdatedHandler>();

            return services;
        }

        public static IServiceCollection AddIntegrationServices(this IServiceCollection services, RabbitMqOptions options)
        {
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<RabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = options.Hostnames.FirstOrDefault(),
                    DispatchConsumersAsync = true
                };

                factory.UserName = options.Username;

                factory.Password = options.Password;

                var retryCount = options.Retries;

                return new RabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<EmployeesContext>(options =>
            {
                options.UseSqlServer(@configuration["DatabaseConnection:DataSource"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });
            /*
            services.AddDbContext<IntegrationEventLogContext>(options =>
            {
                options.UseSqlServer(@configuration["DatabaseConnection:DataSource"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });
            */
            return services;
        }
    }
}
