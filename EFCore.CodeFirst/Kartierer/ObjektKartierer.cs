using AutoMapper;
using EFCore.CodeFirst.DÜOe;
using EFCore.CodeFirst.DZS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst.Kartierer
{
    internal class ObjektKartierer
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BenutzerdefinierteKartierung>();
            });
            return config.CreateMapper();
        });
        public static IMapper Kartierung => lazy.Value;
    }

    internal class BenutzerdefinierteKartierung:Profile
    {
        public BenutzerdefinierteKartierung()
        {
            CreateMap<ProduktDüo, Produkt>().ReverseMap();
        }
    }
}
