using AutoMapper;
using Suppliers.App.Models;
using Suppliers.DataModel;
using System.Runtime;

namespace Suppliers.App.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }
}
