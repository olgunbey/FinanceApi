namespace FinanceCore.Repository.Dtos;

public class MoneyTransferDto
{
    public string SendIBAN { get; set; }
    public string TargetIBAN { get; set; }
    public decimal SendMoney { get; set; }
}