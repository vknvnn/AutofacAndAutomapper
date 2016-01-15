﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using AutoMapper.Mappers;
using Demo.Models;

namespace Demo
{
    class Program
    {
        private static IContainer _container;
        static void Main(string[] args)
        {
            Register();
            using (var scope = _container.BeginLifetimeScope())
            {
                var mapper = scope.Resolve<IMappingEngine>();
                var customerModel = new CustomerModel {Id = 1, Name = "Nghiep Vo"};
                var customer = mapper.Map<Customer>(customerModel);

            }
        }

        private static void Register()
        {
            var builder = new ContainerBuilder();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof (Profile).IsAssignableFrom(t))
                .As<Profile>();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            //builder.RegisterType<EntityMappingProfile>().As<Profile>();
            builder.Register(ctx => new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers))
                .AsImplementedInterfaces()
                .SingleInstance()
                .OnActivating(x =>
                {
                    foreach (var profile in x.Context.Resolve<IEnumerable<Profile>>())
                    {
                        x.Instance.AddProfile(profile);
                    }
                });

            builder.RegisterType<MappingEngine>().As<IMappingEngine>();
            _container = builder.Build();
        }


    }
}