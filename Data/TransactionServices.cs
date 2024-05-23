using FMS.Models;
using FMS.Repository;
using Dapper;
using System.Data;
using Microsoft.IdentityModel.Tokens;

namespace FMS.Data
{
    public class TransactionServices : ITransaction
    {
        private readonly IRepository _repository;

        public TransactionServices(IRepository repository)
        {
            _repository = repository;

        }

        #region Sale
        public async Task<IEnumerable<SaleHd>> GetAllSale(string Fillter, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(Fillter))
                {
                    searchText += " AND BoatName LIKE '%" + Fillter + "%'";
                    searchText += " OR SaleNo LIKE '%" + Fillter + "%'";
                }
                if (BoatId > 0)
                {
                    searchText += $" AND SaleHd.BoatId = {BoatId} OR ({BoatId} = 0)";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<SaleHd, dynamic>("USP_Sale", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<SaleHd> GetByIdAsyncSale(long SaleId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("SaleId", SaleId, DbType.Int64);

                IEnumerable<SaleHd> Sale = await _repository.GetByIdAsync<SaleHd, dynamic>("USP_Sale", parameters);
                return Sale.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<SaleDt>> GetByIdAsyncSaleDetails(long SaleId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_DETAILS_BY_ID", DbType.String);
                parameters.Add("SaleId", SaleId, DbType.Int64);

                var result = await _repository.GetByIdAsync<SaleDt, dynamic>("USP_SaleDt", parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncSale(SaleHd model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("SaleId", model.SaleId, DbType.Int64);
                parameters.Add("SaleNo", model.SaleNo, DbType.String);
                parameters.Add("BoatId", model.BoatId, DbType.Int32);
                parameters.Add("TripNo", model.TripNo, DbType.Byte);
                parameters.Add("StartDate", model.StartDate, DbType.DateTime);
                parameters.Add("EndDate", model.EndDate, DbType.DateTime);
                parameters.Add("NoOfDays", model.NoOfDays, DbType.Int32);
                parameters.Add("TotalSaleAmount", model.TotalSaleAmount, DbType.Decimal);
                parameters.Add("CommisionAmount", model.CommisionAmount, DbType.Decimal);
                parameters.Add("TempleAmount", model.TempleAmount, DbType.Decimal);
                parameters.Add("IceQty", model.IceQty, DbType.Decimal);
                parameters.Add("IcePrice", model.IcePrice, DbType.Decimal);
                parameters.Add("IceAmount", model.IceAmount, DbType.Decimal);
                parameters.Add("FuelQty", model.FuelQty, DbType.Decimal);
                parameters.Add("FuelPrice", model.FuelPrice, DbType.Decimal);
                parameters.Add("FuelAmount", model.FuelAmount, DbType.Decimal);
                parameters.Add("FoodAmount", model.FoodAmount, DbType.Decimal);
                parameters.Add("MiscellaneousAmount", model.MiscellaneousAmount, DbType.Decimal);
                parameters.Add("HelperAmount", model.HelperAmount, DbType.Decimal);
                parameters.Add("BataNoOfPerson", model.BataNoOfPerson, DbType.Decimal);
                parameters.Add("BataPerDayAmount", model.BataPerDayAmount, DbType.Decimal);
                parameters.Add("BataAmount", model.BataAmount, DbType.Decimal);
                parameters.Add("DrinkingWaterAmount", model.DrinkingWaterAmount, DbType.Decimal);
                parameters.Add("SrankAmount", model.SrankAmount, DbType.Decimal);
                parameters.Add("CPhoneRechargeAmount", model.CPhoneRechargeAmount, DbType.Decimal);
                parameters.Add("BerthAmount", model.BerthAmount, DbType.Decimal);
                parameters.Add("CookingGasAmount", model.CookingGasAmount, DbType.Decimal);
                parameters.Add("OilChnageAmount", model.OilChnageAmount, DbType.Decimal);
                parameters.Add("TabRechargeAmount", model.TabRechargeAmount, DbType.Decimal);
                parameters.Add("TotalExpenseAmount", model.TotalExpenseAmount, DbType.Decimal);
                parameters.Add("BalanceAmount", model.BalanceAmount, DbType.Decimal);
                parameters.Add("CreatedBy", 1, DbType.Int32);

                return await _repository.UpsertAsync("USP_Sale", parameters);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncSaleDetails(SaleDt model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("SaleId", model.SaleId, DbType.Int64);
                parameters.Add("SaleNo", model.SaleNo, DbType.String);
                parameters.Add("ItemNo", model.ItemNo, DbType.Byte);
                parameters.Add("SquenceNo", model.SquenceNo, DbType.Byte);
                parameters.Add("ExpenseTypeId", model.ExpenseTypeId, DbType.Byte);
                parameters.Add("MisAmount", model.MisAmount, DbType.Decimal);

                return await _repository.UpsertAsync("USP_SaleDt", parameters);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> DeleteAsyncSale(int SaleId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("SaleId", SaleId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_Sale", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }

        #endregion

        #region Expense

        public async Task<IEnumerable<OwnerExpenseHd>> GetAllExpense(string Fillter, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(Fillter))
                {
                    searchText += " AND BoatName LIKE '%" + Fillter + "%'";
                    searchText += " OR OwnerExpenseHd.SaleNo LIKE '%" + Fillter + "%'";
                    searchText += " OR OwnerExpenseNo LIKE '%" + Fillter + "%'";
                }
                if (BoatId > 0)
                {
                    searchText += $"AND SaleHd.BoatId = {BoatId} OR ({BoatId} = 0)";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<OwnerExpenseHd, dynamic>("USP_OwnerExpense", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<OwnerExpenseHd> GetByIdAsyncExpense(int OwnerExpenseId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("OwnerExpenseId", OwnerExpenseId, DbType.Int32);

                IEnumerable<OwnerExpenseHd> ExpensesHd = await _repository.GetByIdAsync<OwnerExpenseHd, dynamic>("USP_OwnerExpense", parameters);

                return ExpensesHd.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OwnerExpenseDt>> GetByIdAsyncExpenseDetails(int OwnerExpenseId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_DETAILS_BY_ID", DbType.String);
                parameters.Add("OwnerExpenseId", OwnerExpenseId, DbType.Int32);

                var result = await _repository.GetByIdAsync<OwnerExpenseDt, dynamic>("USP_OwnerExpenseDt", parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncExpense(OwnerExpenseHd model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("OwnerExpenseId", model.OwnerExpenseId, DbType.Int32);
                parameters.Add("OwnerExpenseNo", model.OwnerExpenseNo, DbType.String);
                parameters.Add("SaleId", model.SaleId, DbType.Int64);
                parameters.Add("SaleNo", model.SaleNo, DbType.String);
                parameters.Add("TotalAmount", model.TotalAmount, DbType.Decimal);
                parameters.Add("CreatedBy", 1, DbType.Int32);

                return await _repository.UpsertAsync("USP_OwnerExpense", parameters);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncExpenseDetails(OwnerExpenseDt model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("OwnerExpenseId", model.OwnerExpenseId, DbType.Int32);
                parameters.Add("OwnerExpenseNo", model.OwnerExpenseNo, DbType.String);
                parameters.Add("ItemNo", model.ItemNo, DbType.Byte);
                parameters.Add("SquenceNo", model.SquenceNo, DbType.Byte);
                parameters.Add("ExpenseTypeId", model.ExpenseTypeId, DbType.Byte);
                parameters.Add("Qty", model.Qty, DbType.Decimal);
                parameters.Add("Price", model.Price, DbType.Decimal);
                parameters.Add("Amount", model.Amount, DbType.Decimal);

                return await _repository.UpsertAsync("USP_OwnerExpenseDt", parameters);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IncomeReponce> DeleteAsyncExpense(int ExpenseId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("OwnerExpenseId", ExpenseId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_OwnerExpense", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }

        #endregion

        #region Income

        public async Task<IEnumerable<IncomeHd>> GetAllIncome(string Fillter, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(Fillter))
                {
                    searchText += " AND BoatName LIKE '%" + Fillter + "%'";
                    searchText += " OR IncomeHd.SaleNo LIKE '%" + Fillter + "%'";
                    searchText += " OR IncomeNo LIKE '%" + Fillter + "%'";
                }
                if (BoatId > 0)
                {
                    searchText += $"AND SaleHd.BoatId = {BoatId} OR ({BoatId} = 0)";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<IncomeHd, dynamic>("USP_Income", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IncomeHd> GetByIdAsyncIncome(int IncomeId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("IncomeId", IncomeId, DbType.Int32);

                IEnumerable<IncomeHd> IncomesHd = await _repository.GetByIdAsync<IncomeHd, dynamic>("USP_Income", parameters);

                return IncomesHd.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<IncomeDt>> GetByIdAsyncIncomeDetails(int IncomeId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_DETAILS_BY_ID", DbType.String);
                parameters.Add("IncomeId", IncomeId, DbType.Int32);

                var result = await _repository.GetByIdAsync<IncomeDt, dynamic>("USP_IncomeDt", parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncIncome(IncomeHd model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("IncomeId", model.IncomeId, DbType.Int32);
                parameters.Add("IncomeNo", model.IncomeNo, DbType.String);
                parameters.Add("SaleId", model.SaleId, DbType.Int64);
                parameters.Add("SaleNo", model.SaleNo, DbType.String);
                parameters.Add("BalanceAmount", model.BalanceAmount, DbType.Decimal);
                parameters.Add("TotalAmount", model.TotalAmount, DbType.Decimal);
                parameters.Add("CreatedBy", 1, DbType.Int32);

                return await _repository.UpsertAsync("USP_Income", parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncIncomeDetails(IncomeDt model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("IncomeId", model.IncomeId, DbType.Int32);
                parameters.Add("IncomeNo", model.IncomeNo, DbType.String);
                parameters.Add("ItemNo", model.ItemNo, DbType.Byte);
                parameters.Add("SquenceNo", model.SquenceNo, DbType.Byte);
                parameters.Add("CommissionTypeId", model.CommissionTypeId, DbType.Byte);
                parameters.Add("Qty", model.Qty, DbType.Decimal);
                parameters.Add("Price", model.Price, DbType.Decimal);
                parameters.Add("Amount", model.Amount, DbType.Decimal);

                return await _repository.UpsertAsync("USP_IncomeDt", parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> DeleteAsyncIncome(int IncomeId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("IncomeId", IncomeId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_Income", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }

        #endregion

        #region Credit

        public async Task<IEnumerable<CreditHd>> GetAllCredit(string SaleNo, string SaleName)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(SaleNo))
                {
                    searchText += " AND SaleNo LIKE '%" + SaleNo + "%'";
                }
                if (!string.IsNullOrEmpty(SaleName))
                {
                    searchText += " AND SaleName LIKE '%" + SaleName + "%'";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<CreditHd, dynamic>("USP_Credit", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<CreditHd> GetByIdAsyncCredit(int CreditId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("CreditId", CreditId, DbType.Int32);

                IEnumerable<CreditHd> CreditsHd = await _repository.GetByIdAsync<CreditHd, dynamic>("USP_Credit", parameters);

                return CreditsHd.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CreditDt>> GetByIdAsyncCreditDetails(int CreditId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_DETAILS_BY_ID", DbType.String);
                parameters.Add("CreditId", CreditId, DbType.Int32);

                var result = await _repository.GetByIdAsync<CreditDt, dynamic>("USP_CreditDt", parameters);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncCredit(CreditHd model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("CreditId", model.CreditId, DbType.Int32);
                parameters.Add("CreditNo", model.CreditNo, DbType.String);
                parameters.Add("BoatId", model.BoatId, DbType.Int32);
                parameters.Add("PersonName", model.PersonName, DbType.String);
                parameters.Add("CreditDate", model.CreditDate, DbType.DateTime);
                parameters.Add("CreditAmount", model.CreditAmount, DbType.Decimal);
                parameters.Add("BalanceAmount", model.BalanceAmount, DbType.Decimal);
                parameters.Add("CreatedBy", 1, DbType.Int32);

                return await _repository.UpsertAsync("USP_Credit", parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> UpsertAsyncCreditDetails(CreditDt model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("CreditId", model.CreditId, DbType.Int32);
                parameters.Add("CreditNo", model.CreditNo, DbType.String);
                parameters.Add("ItemNo", model.ItemNo, DbType.Byte);
                parameters.Add("SquenceNo", model.SquenceNo, DbType.Byte);
                parameters.Add("ReceivedDate", model.ReceivedDate, DbType.DateTime);
                parameters.Add("Amount", model.Amount, DbType.Decimal);

                return await _repository.UpsertAsync("USP_CreditDt", parameters);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IncomeReponce> DeleteAsyncCredit(int CreditId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("CreditId", CreditId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_Credit", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }
        #endregion

    }
}
