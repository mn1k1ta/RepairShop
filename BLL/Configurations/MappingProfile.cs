using AutoMapper;
using BLL.ModelDTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandPhone, BrandPhoneDTO>().ReverseMap();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Crash, CrashDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<ModelPhone, ModelPhoneDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderCrush, OrderCrushDTO>().ReverseMap();
            CreateMap<Price, PriceDTO>().ReverseMap();
        }
    }
}
