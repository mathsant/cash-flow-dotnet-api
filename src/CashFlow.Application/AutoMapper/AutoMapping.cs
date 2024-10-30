using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>()
            .ForMember(dest => dest.Tags, config => config.MapFrom(source => source.Tags.Distinct()));
        
        CreateMap<RequestCreateUserJson, User>()
            .ForMember(destination => destination.Password, config => config.Ignore());
        
        CreateMap<Communication.Enums.ExpenseTag, Tag>()
            .ForMember(dest => dest.Value, config => config.MapFrom(source => source));
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseExpenseJson>()
            .ForMember(dest => dest.Tags, config => config.MapFrom(source => source.Tags.Select(tag => tag.Value)));
        
        CreateMap<Expense, ResponseRegisterExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<User, ResponseUserProfileJson>();
    }
}
