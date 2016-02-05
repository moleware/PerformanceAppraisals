using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AssociateAppraisals.Model;
using AssociateAppraisals.Web.ViewModels;

namespace AssociateAppraisals.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AppraisalFormViewModel, Appraisal>()
                .ForMember(g => g.ReviewYear, map => map.MapFrom(vm => vm.ReviewYear))
                .ForMember(g => g.StartDate, map => map.MapFrom(vm => vm.StartDate))
                .ForMember(g => g.EndDate, map => map.MapFrom(vm => vm.EndDate));
        }
    }
}