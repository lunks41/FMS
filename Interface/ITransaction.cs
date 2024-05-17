﻿using FMS.Models;

namespace FMS.Data
{
    public interface ITransaction
    {
        #region Sale
        Task<IEnumerable<SaleHd>> GetAllSale(string SaleCode, string SaleName, int? IsActive);
        Task<SaleHd> GetByIdAsyncSale(long SaleId);
        Task<IncomeReponce> UpsertAsyncSale(SaleHd model);
        Task<IncomeReponce> UpsertAsyncSaleDetails(SaleDt model);
        Task<IEnumerable<SaleDt>> GetByIdAsyncSaleDetails(long ExpenseId);
        Task<IncomeReponce> DeleteAsyncSale(int SaleId, int CreatedBY);
        #endregion

        #region Expense
        Task<IEnumerable<OwnerExpenseHd>> GetAllExpense(string? SaleCode, string? SaleName);
        Task<OwnerExpenseHd> GetByIdAsyncExpense(int ExpenseId);
        Task<IncomeReponce> UpsertAsyncExpense(OwnerExpenseHd model);
        Task<IncomeReponce> UpsertAsyncExpenseDetails(OwnerExpenseDt model);
        Task<IEnumerable<OwnerExpenseDt>> GetByIdAsyncExpenseDetails(int ExpenseId);
        Task<IncomeReponce> DeleteAsyncExpense(int ExpenseId, int CreatedBY);
        #endregion

        #region Income
        Task<IEnumerable<IncomeHd>> GetAllIncome(string? SaleCode, string? SaleName);
        Task<IncomeHd> GetByIdAsyncIncome(int IncomeId);
        Task<IncomeReponce> UpsertAsyncIncome(IncomeHd model);
        Task<IncomeReponce> UpsertAsyncIncomeDetails(IncomeDt model);
        Task<IEnumerable<IncomeDt>> GetByIdAsyncIncomeDetails(int IncomeId);
        Task<IncomeReponce> DeleteAsyncIncome(int IncomeId, int CreatedBY);

        #endregion

        #region Credit
        Task<IEnumerable<CreditHd>> GetAllCredit(string? SaleCode, string? SaleName);
        Task<CreditHd> GetByIdAsyncCredit(int CreditId);
        Task<IncomeReponce> UpsertAsyncCredit(CreditHd model);
        Task<IncomeReponce> UpsertAsyncCreditDetails(CreditDt model);
        Task<IEnumerable<CreditDt>> GetByIdAsyncCreditDetails(int CreditId);
        Task<IncomeReponce> DeleteAsyncCredit(int CreditId, int CreatedBY);

        #endregion
    }
}