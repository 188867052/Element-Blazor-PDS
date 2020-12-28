using AutoMapper;
using IssueManage.Pages.Entity;
using IssueManage.Pages.Issues;
namespace IssueManage.Pages.Dtos
{
    public class IssueProfile : Profile
    {
        public IssueProfile()
        {
            CreateMap<IssueModel, Issue>()
                .ForMember(d => d.Id, s => s.MapFrom(s => s.Id))
                .ForMember(d => d.CreateTime, s => s.MapFrom(s => s.CreateTime))
                .ForMember(d => d.ImplementTime, s => s.MapFrom(s => s.ImplementTime))
                .ForMember(d => d.Description, s => s.MapFrom(s => s.Description))
                .ForMember(d => d.Product, s => s.MapFrom(s => s.Product))
                .ForMember(d => d.ChangeFrom, s => s.MapFrom(s => s.ChangeFrom))
                .ForMember(d => d.Status, s => s.MapFrom(s => s.Status))
                .ReverseMap();
        }
    }
}
