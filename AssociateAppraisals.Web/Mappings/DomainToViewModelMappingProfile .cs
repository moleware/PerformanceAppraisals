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
            var appraisalConfig = new MapperConfiguration(cfg => { cfg.CreateMap<Appraisal, AppraisalViewModel>(); });
            IMapper appraisalMapper = appraisalConfig.CreateMapper();
            var appraisal = new Appraisal();
            var appraisalDest = appraisalMapper.Map<Appraisal, AppraisalViewModel>(appraisal);

            var appraisalQuestionConfig = new MapperConfiguration(cfg => { cfg.CreateMap<AppraisalQuestion, AppraisalQuestionViewModel>(); });
            IMapper appraisalQuestionMapper = appraisalQuestionConfig.CreateMapper();
            var appraisalQuestion = new AppraisalQuestion();
            var appraisalQuestionDest = appraisalQuestionMapper.Map<AppraisalQuestion, AppraisalQuestionViewModel>(appraisalQuestion);
        }
    }
}