using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Newtonsoft.Json.Linq;
using NTierApplications.Domain.Entities;
using NTierApplications.MVC.Infrastructure.Mapping;
using NTierApplications.MVC.Infrastructure.Tasks;
using NTierApplications.MVC.Models;
using StructureMap;
using StructureMap.TypeRules;

namespace NTierApplications.MVC
{
	public class AutoMapperConfig : IRunAtStartup
	{
		public void Execute()
		{
			var types = Assembly.GetExecutingAssembly().GetExportedTypes();

			CreateMappings(types);
			CreateCustomMappings(types);

			Mapper.AssertConfigurationIsValid();
		}


		//public static void Initialize(IContainer container)
		//{
		//	var types = Assembly.GetExecutingAssembly().GetExportedTypes();

		//	CreateMappings(types);
		//	CreateCustomMappings(types);

		//	Mapper.AssertConfigurationIsValid();
		//}

		private static void CreateMappings(IEnumerable<Type> types)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where i.IsGenericType
							  && i.GetGenericTypeDefinition() == typeof(ICreateMapping<>)
							  && !t.IsAbstract
							  && !t.IsInterface
						select new
						{
							Entity = i.GetGenericArguments()[0],
							ViewModel = t
						}).ToList();

			foreach (var map in maps)
			{
				var toViewModel = Mapper.CreateMap(map.Entity, map.ViewModel);
				var toEntity = Mapper.CreateMap(map.ViewModel, map.Entity);

				var toViewModelTypeMap = Mapper.FindTypeMapFor(map.Entity, map.ViewModel);
				var toEntityTypeMap = Mapper.FindTypeMapFor(map.ViewModel, map.Entity);

				if (toViewModelTypeMap != null)
				{
					foreach (var unmappedPropertyName in toViewModelTypeMap.GetUnmappedPropertyNames())
					{
						toViewModel.ForMember(unmappedPropertyName, opt => opt.Ignore());
					}
				}

				if (toEntityTypeMap != null)
				{
					foreach (var unmappedPropertyName in toEntityTypeMap.GetUnmappedPropertyNames())
					{
						toEntity.ForMember(unmappedPropertyName, opt => opt.Ignore());
					}
				}
			}
		}

		private static void CreateCustomMappings(IEnumerable<Type> types)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where typeof(ICreateCustomMapping).IsAssignableFrom(t)
							  && !t.IsAbstract
							  && !t.IsInterface
						select (ICreateCustomMapping)Activator.CreateInstance(t)).ToArray();

			foreach (var map in maps)
			{
				map.CustomMapping(Mapper.Configuration);
			}
		}

	}
}