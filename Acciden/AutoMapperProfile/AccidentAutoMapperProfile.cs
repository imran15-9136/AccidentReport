using Accident.Models.Models;
using Accident.Models.RequestModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acciden.AutoMapperProfile
{
    public class AccidentAutoMapperProfile: Profile
    {
        public AccidentAutoMapperProfile()
        {
            CreateMap<AccidentCreateDto, AccidentModel>();
        }
    }
}
