﻿using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update;
public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpensesUpdateOnlyRepository _repository;
    private readonly ILoggedUser _loggedUser;

    public UpdateExpenseUseCase(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IExpensesUpdateOnlyRepository repository,
        ILoggedUser loggedUser
        )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
        _loggedUser = loggedUser;
    }

    public async Task<Expense> Execute(long id, RequestExpenseJson request)
    {
        Validate(request);

        var loggerUser = await _loggedUser.Get();

        var expense = await _repository.GetById(loggerUser, id);

        if (expense is null) throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
        
        expense.Tags.Clear();

        _mapper.Map(request, expense);

        _repository.Update(expense);

        await _unitOfWork.Commit();

        return expense;
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid != false) return;
        
        var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
        throw new ErrorOnValidationException(errorMessages);
    }
}
