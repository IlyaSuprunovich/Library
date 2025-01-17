﻿using AutoMapper;
using System.Reflection;

namespace Library.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            List<Type> types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                     i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (Type type in types)
            {
                object? instance = Activator.CreateInstance(type);
                MethodInfo? methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
