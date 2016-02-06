using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AssociateAppraisals.Model;
using AssociateAppraisals.Web.ViewModels;
using DGS_Enterprise.Model;

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
            Mapper.CreateMap<Appraisal, AppraisalViewModel>();
            Mapper.CreateMap<AppraisalQuestion, AppraisalQuestionViewModel>();
            Mapper.CreateMap<Associate, AssociateViewModel>();
            Mapper.CreateMap<AssociateAppraisal, AssociateAppraisalViewModel>();        


            /*
            var appraisalConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Appraisal, AppraisalViewModel>(); });
            IMapper appraisalMapper = appraisalConfig.CreateMapper();
            var appraisal = new Appraisal();
            var appraisalDest = appraisalMapper.Map<Appraisal, AppraisalViewModel>(appraisal);

            var appraisalQuestionConfig = new MapperConfiguration(cfg => { cfg.CreateMap<AppraisalQuestion, AppraisalQuestionViewModel>(); });
            IMapper appraisalQuestionMapper = appraisalQuestionConfig.CreateMapper();
            var appraisalQuestion = new AppraisalQuestion();
            var appraisalQuestionDest = appraisalQuestionMapper.Map<AppraisalQuestion, AppraisalQuestionViewModel>(appraisalQuestion);
        */

            /*
            var Aconfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Appraisal, AppraisalFormViewModel>()
                    .ForMember(g => g.ReviewYear, map => map.MapFrom(vm => vm.ReviewYear))
                    .ForMember(g => g.StartDate, map => map.MapFrom(vm => vm.StartDate))
                    .ForMember(g => g.EndDate, map => map.MapFrom(vm => vm.EndDate))
                    .ForMember(g => g.Questions, map => map.MapFrom(vm => vm.Questions));
            });
            var AQconfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<AppraisalQuestion, AppraisalQuestionFormViewModel>()
                    .ForMember(g => g.AppraisalId, map => map.MapFrom(vm => vm.AppraisalId))
                    .ForMember(g => g.AppraisalQuestionGroupId, map => map.MapFrom(vm => vm.AppraisalQuestionGroupId))
                    .ForMember(g => g.AppraisalQuestionTypeId, map => map.MapFrom(vm => vm.AppraisalQuestionTypeId))
                    .ForMember(g => g.Question, map => map.MapFrom(vm => vm.Question))
                    .ForMember(g => g.QuestionNumber, map => map.MapFrom(vm => vm.QuestionNumber));
            });
            */
        }
    }
}