using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;

namespace CashFlow.Domain.Extensions;
public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.CASH => ResourceReportGenerationMessages.CASH,
            PaymentType.CREDIT_CARD => ResourceReportGenerationMessages.CREDIT_CARD,
            PaymentType.DEBIT_CARD => ResourceReportGenerationMessages.DEBIT_CARD,
            PaymentType.PIX => ResourceReportGenerationMessages.PIX,
            _ => string.Empty
        };
    }
}
