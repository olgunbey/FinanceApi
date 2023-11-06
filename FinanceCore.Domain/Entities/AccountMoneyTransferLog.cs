using FinanceCore.Domain.Command;

namespace FinanceCore.Domain.Entities;

public class AccountMoneyTransferLog:BaseEntityID
{
    public string SendIBAN { get; set; }
    public string TargetIBAN { get; set; }
    public decimal SendMoney { get; set; }
    public DateTime DateTime { get; set; }
    
}