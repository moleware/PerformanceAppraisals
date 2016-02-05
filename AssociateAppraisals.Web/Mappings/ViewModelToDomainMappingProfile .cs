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
            Mapper.CreateMap<AppraisalQuestionFormViewModel, AppraisalQuestion>()
                .ForMember(g => g.AppraisalId, map => map.MapFrom(vm => vm.AppraisalId))
                .ForMember(g => g.AppraisalQuestionGroupId, map => map.MapFrom(vm => vm.AppraisalQuestionGroupId))
                .ForMember(g => g.AppraisalQuestionTypeId, map => map.MapFrom(vm => vm.AppraisalQuestionTypeId))
                .ForMember(g => g.Question, map => map.MapFrom(vm => vm.Question))
                .ForMember(g => g.QuestionNumber, map => map.MapFrom(vm => vm.QuestionNumber));
        }
    }
}