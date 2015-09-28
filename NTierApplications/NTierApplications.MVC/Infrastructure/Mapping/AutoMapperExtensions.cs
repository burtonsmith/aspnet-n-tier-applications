using System.Linq;
using AutoMapper;

namespace NTierApplications.MVC.Infrastructure.Mapping
{
	public static class AutoMapperExtensions
	{
		public static IMappingExpression<TSource, TDestination> IgnoreUnmappedAttributes<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
		{
			var sourceType = typeof(TSource);
			var destinationType = typeof(TDestination);
			var existingMaps = Mapper.GetAllTypeMaps().First(x => x.SourceType == sourceType && x.DestinationType == destinationType);
			foreach (var property in existingMaps.GetUnmappedPropertyNames())
			{
				expression.ForMember(property, opt => opt.Ignore());
			}
			return expression;
			
			//  EXAMPLE:
			//  Mapper.CreateMap<SourceType, DestinationType>()
			//  	.ForMember(prop => x.Property, opt => opt.MapFrom(src => src.OtherProperty))
			//  	.IgnoreUnmappedAttributes();
		}
	}
}