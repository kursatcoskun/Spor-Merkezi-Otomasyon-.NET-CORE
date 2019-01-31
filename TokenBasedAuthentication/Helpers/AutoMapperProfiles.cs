using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamSporMerkezi.API.Dtos;
using AdamSporMerkezi.API.Models;
using AutoMapper;
using TokenBasedAuthentication.Dtos;
using TokenBasedAuthentication.Models;

namespace TokenBasedAuthentication.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Uye, UyeListDto>();
            CreateMap<Uye, UyeDetailDto>();
            CreateMap<UyeProgram, UyeProgramDetailDto>();
            CreateMap<UyeVucutInfo, UyeVucutBilgiDetailDto>();
            CreateMap<UyeProgram, UyeProgramAddDto>();
            CreateMap<Urun, UrunForListDto>();
            CreateMap<UyeOdeme, Class>();
            

        }

    }
}
