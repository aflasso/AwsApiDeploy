using MoneyBankService.Domain.Entities;

namespace MoneyBankService.Application.Interfaces.Services;

public interface IAccountService
{
    Task<Account> CreateAccountAsync(Account account);
    Task<List<Account>> GetAccountsByAccountNumberAsync(string accountNumber);
    Task<Account> GetAccountByIdAsync(int accountId);
    Task<Account> UpdateAccountAsync(int accountId, Account newAccount);
    Task DeleteAccountAsync(int accountId);
    Task<bool> TryWithdrawAsync(int accountId, Transaction transaction);
    Task<bool> TryDepositAsync(int accountId, Transaction transaction);
}
