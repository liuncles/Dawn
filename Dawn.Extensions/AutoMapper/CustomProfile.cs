using AutoMapper;
using Dawn.Entities.Dto.System;
using Dawn.Entities.System;

namespace Dawn.Extensions.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            //CreateMap<BlogArticle, BlogViewModels>();
            //CreateMap<BlogViewModels, BlogArticle>();

            CreateMap<SysUser, SysUser>()
                .ForMember(a => a.Id, o => o.MapFrom(d => d.Id))
                .ForMember(a => a.RoleIds, o => o.MapFrom(d => d.RoleIds))
                .ForMember(a => a.UserName, o => o.MapFrom(d => d.UserName))
                .ForMember(a => a.Password, o => o.MapFrom(d => d.Password))
                .ForMember(a => a.UserNick, o => o.MapFrom(d => d.UserNick))
                .ForMember(a => a.Gender, o => o.MapFrom(d => d.Gender))
                .ForMember(a => a.Age, o => o.MapFrom(d => d.Age))
                .ForMember(a => a.Portrait, o => o.MapFrom(d => d.Portrait))
                .ForMember(a => a.Email, o => o.MapFrom(d => d.Email))
                .ForMember(a => a.Phone, o => o.MapFrom(d => d.Phone))
                .ForMember(a => a.Description, o => o.MapFrom(d => d.Description))
                .ForMember(a => a.Status, o => o.MapFrom(d => d.Status))
                .ForMember(a => a.ErrorCount, o => o.MapFrom(d => d.ErrorCount))
                .ForMember(a => a.LastErrTime, o => o.MapFrom(d => d.LastErrTime))
                .ForMember(a => a.IsDeleted, o => o.MapFrom(d => d.IsDeleted))
                .ForMember(a => a.CreatedTime, o => o.MapFrom(d => d.CreatedTime))
                .ForMember(a => a.ModifiedTime, o => o.MapFrom(d => d.ModifiedTime))
                .ForMember(a => a.RoleNames, o => o.MapFrom(d => d.RoleNames));
            CreateMap<SysUserDto, SysUser>()
                .ForMember(a => a.Id, o => o.MapFrom(d => d.Id))
                .ForMember(a => a.RoleIds, o => o.MapFrom(d => d.RoleIds))
                .ForMember(a => a.UserName, o => o.MapFrom(d => d.UserName))
                .ForMember(a => a.Password, o => o.MapFrom(d => d.Password))
                .ForMember(a => a.UserNick, o => o.MapFrom(d => d.UserNick))
                .ForMember(a => a.Gender, o => o.MapFrom(d => d.Gender))
                .ForMember(a => a.Age, o => o.MapFrom(d => d.Age))
                .ForMember(a => a.Portrait, o => o.MapFrom(d => d.Portrait))
                .ForMember(a => a.Email, o => o.MapFrom(d => d.Email))
                .ForMember(a => a.Phone, o => o.MapFrom(d => d.Phone))
                .ForMember(a => a.Description, o => o.MapFrom(d => d.Description))
                .ForMember(a => a.Status, o => o.MapFrom(d => d.Status))
                .ForMember(a => a.ErrorCount, o => o.MapFrom(d => d.ErrorCount))
                .ForMember(a => a.LastErrTime, o => o.MapFrom(d => d.LastErrTime))
                .ForMember(a => a.IsDeleted, o => o.MapFrom(d => d.IsDeleted))
                .ForMember(a => a.CreatedTime, o => o.MapFrom(d => d.CreatedTime))
                .ForMember(a => a.ModifiedTime, o => o.MapFrom(d => d.ModifiedTime))
                .ForMember(a => a.RoleNames, o => o.MapFrom(d => d.RoleNames));
        }
    }
}
