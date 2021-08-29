using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Tedusop.Model.Models;
using Tedusop.web.Models;


namespace Tedusop.web.Mappings
{
    public static class AutoMapperConfiguration
    {
        public static void confuginon()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Tag,TagViewModel>();
            Mapper.CreateMap<PostTag, PostTagViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();

        }
    }
}