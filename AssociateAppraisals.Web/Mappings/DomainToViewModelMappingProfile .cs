using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AssociateAppraisals.Model;
using AssociateAppraisals.Web.ViewModels;

namespace AssociateAppraisals.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            // Apparently this is the obsolete way of doing things...
            Mapper.CreateMap<Appraisal, AppraisalViewModel>();
            Mapper.CreateMap<AppraisalQuestion, AppraisalQuestionViewModel>();
            Mapper.CreateMap<Associate, AssociateViewModel>();
            Mapper.CreateMap<AssociateAppraisal, AssociateAppraisalViewModel>();
        }
    }
}