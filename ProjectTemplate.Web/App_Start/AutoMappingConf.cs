using System;
using AutoMapper;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Services.DTO;
using ProjectTemplate.Web.Models.Account;
using ProjectTemplate.Web.Models.Email;

namespace ProjectTemplate.Web.App_Start
{
    public static class AutoMappingConf
    {
         public static void ApplyMappings()
         {
             Mapper.CreateMap<SignUpModel, UserInfoDTO>()
                 .ForMember(dto => dto.CreatedAt, opt => opt.UseValue(DateTime.UtcNow))
                 .ForMember(dto => dto.UpdatedAt, opt => opt.UseValue(DateTime.UtcNow));
             Mapper.CreateMap<FacebookUserInformation, UserInfoDTO>()
                .ForMember(dto => dto.CreatedAt, opt => opt.UseValue(DateTime.UtcNow))
                .ForMember(dto => dto.UpdatedAt, opt => opt.UseValue(DateTime.UtcNow));

             Mapper.CreateMap<SignUpModel, ConfirmAccountModel>();
             Mapper.CreateMap<UserInfoDTO, FacebookUserInformation>();
             Mapper.CreateMap<User, SendResetPasswordEmailModel>();
         }
    }
}