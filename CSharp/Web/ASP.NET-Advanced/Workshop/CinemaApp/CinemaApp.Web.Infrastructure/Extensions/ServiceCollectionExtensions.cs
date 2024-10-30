﻿using CinemaApp.Data.Models;
using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepositories(this IServiceCollection services, Assembly modelsAssemby)
        {
            // ignore ApplicationUser
            Type[] typesToExclude = new Type[] { typeof(ApplicationUser) };

            // get all other types
            Type[] modelTypes = modelsAssemby.GetTypes()
                .Where(t => !t.IsAbstract
                        && !t.IsInterface
                        && !t.Name.ToLower().EndsWith("attribute")
                        && !typesToExclude.Contains(t))
                .ToArray();

            // register repository for each type
            foreach (Type type in modelTypes)
            {
                // for each type:
                // get id property info
                PropertyInfo idPropInfo = type.GetProperty("Id");

                // get type of repository interface and class
                Type repositoryInterface = typeof(IRepository<,>);
                Type repositoryInstanceType = typeof(BaseRepository<,>);

                // define repository interface and class construction arguments
                Type[] constructArgs = new Type[2];
                constructArgs[0] = type;

                if (idPropInfo == null)
                {
                    constructArgs[1] = typeof(object);
                }
                else
                {
                    constructArgs[1] = idPropInfo.PropertyType;
                }

                // create repository interface and class instances with defined construction arguments
                repositoryInterface = repositoryInterface.MakeGenericType(constructArgs);
                repositoryInstanceType = repositoryInstanceType.MakeGenericType(constructArgs);

                // add to services
                services.AddScoped(repositoryInterface, repositoryInstanceType);
            }
        }
    }
}
