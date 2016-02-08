using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AssociateAppraisals.Model;
using AssociateAppraisals.Web.ViewModels;


namespace AssociateAppraisals.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration config;

        public static void Configure()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });


            // This style is apparently obsolete...
            /*           Mapper.Initialize(cfg =>
                       {
                           cfg.AddProfile<DomainToViewModelMappingProfile>();
                           cfg.AddProfile<ViewModelToDomainMappingProfile>();
                       });
                       */
        }
    }
}