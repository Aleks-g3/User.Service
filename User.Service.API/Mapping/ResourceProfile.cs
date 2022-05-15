using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;
using User.Service.API.Resources;

namespace User.Service.API.Mapping
{
    public class ResourceProfile : Profile
    {
        public ResourceProfile()
        {
            CreateMap<UserFormDTO, UserEntity>();
            CreateMap<UserTaskFormDTO, UserTask>();

            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserTask, UserTaskDTO>();
        }
    }
}
