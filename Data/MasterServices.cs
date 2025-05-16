using Dapper;
using FMS.Models;
using FMS.Repository;
using System.Data;

namespace FMS.Data
{
    public class MasterServices : IMaster
    {
        private readonly IRepository _repository;

        public MasterServices(IRepository repository)
        {
            _repository = repository;
        }

        #region Boat

        public async Task<IEnumerable<Boat>> GetAllBoat(string BoatCode, string BoatName, int? IsActive)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(BoatCode))
                {
                    searchText += " AND BoatCode LIKE '%" + BoatCode + "%'";
                }
                if (!string.IsNullOrEmpty(BoatName))
                {
                    searchText += " AND BoatName LIKE '%" + BoatName + "%'";
                }
                if (IsActive != -1)
                {
                    searchText += " AND IsActive LIKE '%" + IsActive + "%'";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<Boat, dynamic>("USP_BOAT", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Boat> GetByIdAsyncBoat(int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("BoatId", BoatId, DbType.Int32);

                IEnumerable<Boat> Boat = await _repository.GetByIdAsync<Boat, dynamic>("USP_BOAT", parameters);
                return Boat.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Boat> UpsertAsyncBoat(Boat model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("BoatId", model.BoatId, DbType.Int32);
                parameters.Add("BoatCode", model.BoatCode, DbType.String);
                parameters.Add("BoatName", model.BoatName, DbType.String);
                parameters.Add("IsActive", model.IsActive, DbType.String);
                parameters.Add("CreatedBy", model.CreatedBy, DbType.Int32);

                await _repository.UpsertAsync("USP_BOAT", parameters);

                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<bool> UpdateStatusAsyncBoat(int BoatId, int CreatedBY)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Type", "UPDATE_STATUS", DbType.String);
            parameters.Add("BoatId", BoatId, DbType.Int32);
            parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

            await _repository.UpsertAsync("USP_BOAT", parameters);

            return true;
        }

        public async Task<IncomeReponce> DeleteAsyncBoat(int BoatId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("BoatId", BoatId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_BOAT", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }

        public async Task<Boat> IsDuplicateAsyncBoat(int BoatId, string Name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Type", "IsDuplicate", DbType.String);
            parameters.Add("BoatId", BoatId, DbType.Int32);
            parameters.Add("Name", Name, DbType.String);

            IEnumerable<Boat> Boat = await _repository.GetByIdAsync<Boat, dynamic>("USP_BOAT", parameters);
            return Boat.FirstOrDefault();
        }

        #endregion Boat

        #region ExpenseType

        public async Task<IEnumerable<ExpenseType>> GetAllExpenseType(string ExpenseTypeCode, string ExpenseTypeName, int? IsActive)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(ExpenseTypeCode))
                {
                    searchText += " AND ExpenseTypeCode LIKE '%" + ExpenseTypeCode + "%'";
                }
                if (!string.IsNullOrEmpty(ExpenseTypeName))
                {
                    searchText += " AND ExpenseTypeName LIKE '%" + ExpenseTypeName + "%'";
                }
                if (IsActive != -1)
                {
                    searchText += " AND IsActive LIKE '%" + IsActive + "%'";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<ExpenseType, dynamic>("USP_ExpenseType", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ExpenseType> GetByIdAsyncExpenseType(int ExpenseTypeId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("ExpenseTypeId", ExpenseTypeId, DbType.Int32);

                IEnumerable<ExpenseType> ExpenseType = await _repository.GetByIdAsync<ExpenseType, dynamic>("USP_ExpenseType", parameters);
                return ExpenseType.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ExpenseType> UpsertAsyncExpenseType(ExpenseType model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("ExpenseTypeId", model.ExpenseTypeId, DbType.Int32);
                parameters.Add("ExpenseTypeCode", model.ExpenseTypeCode, DbType.String);
                parameters.Add("ExpenseTypeName", model.ExpenseTypeName, DbType.String);
                parameters.Add("IsActive", model.IsActive, DbType.String);
                parameters.Add("CreatedBy", model.CreatedBy, DbType.Int32);

                await _repository.UpsertAsync("USP_ExpenseType", parameters);

                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<bool> UpdateStatusAsyncExpenseType(int ExpenseTypeId, int CreatedBY)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Type", "UPDATE_STATUS", DbType.String);
            parameters.Add("ExpenseTypeId", ExpenseTypeId, DbType.Int32);
            parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

            await _repository.UpsertAsync("USP_ExpenseType", parameters);

            return true;
        }

        public async Task<IncomeReponce> DeleteAsyncExpenseType(int ExpenseTypeId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("ExpenseTypeId", ExpenseTypeId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_ExpenseType", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }

        public async Task<ExpenseType> IsDuplicateAsyncExpenseType(int ExpenseTypeId, string Name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Type", "IsDuplicate", DbType.String);
            parameters.Add("ExpenseTypeId", ExpenseTypeId, DbType.Int32);
            parameters.Add("Name", Name, DbType.String);

            IEnumerable<ExpenseType> ExpenseType = await _repository.GetByIdAsync<ExpenseType, dynamic>("USP_ExpenseType", parameters);
            return ExpenseType.FirstOrDefault();
        }

        #endregion ExpenseType

        #region CommissionType

        public async Task<IEnumerable<CommissionType>> GetAllCommissionType(string CommissionTypeCode, string CommissionTypeName, int? IsActive)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);

                string searchText = string.Empty;

                if (!string.IsNullOrEmpty(CommissionTypeCode))
                {
                    searchText += " AND CommissionTypeCode LIKE '%" + CommissionTypeCode + "%'";
                }
                if (!string.IsNullOrEmpty(CommissionTypeName))
                {
                    searchText += " AND CommissionTypeName LIKE '%" + CommissionTypeName + "%'";
                }
                if (IsActive != -1)
                {
                    searchText += " AND IsActive LIKE '%" + IsActive + "%'";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<CommissionType, dynamic>("USP_CommissionType", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CommissionType> GetByIdAsyncCommissionType(int CommissionTypeId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_BY_ID", DbType.String);
                parameters.Add("CommissionTypeId", CommissionTypeId, DbType.Int32);

                IEnumerable<CommissionType> CommissionType = await _repository.GetByIdAsync<CommissionType, dynamic>("USP_CommissionType", parameters);
                return CommissionType.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CommissionType> UpsertAsyncCommissionType(CommissionType model)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "INSERT_UPDATE", DbType.String);
                parameters.Add("CommissionTypeId", model.CommissionTypeId, DbType.Int32);
                parameters.Add("CommissionTypeCode", model.CommissionTypeCode, DbType.String);
                parameters.Add("CommissionTypeName", model.CommissionTypeName, DbType.String);
                parameters.Add("IsActive", model.IsActive, DbType.String);
                parameters.Add("CreatedBy", model.CreatedBy, DbType.Int32);

                await _repository.UpsertAsync("USP_CommissionType", parameters);

                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }

        public async Task<bool> UpdateStatusAsyncCommissionType(int CommissionTypeId, int CreatedBY)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Type", "UPDATE_STATUS", DbType.String);
            parameters.Add("CommissionTypeId", CommissionTypeId, DbType.Int32);
            parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

            await _repository.UpsertAsync("USP_CommissionType", parameters);

            return true;
        }

        public async Task<IncomeReponce> DeleteAsyncCommissionType(int CommissionTypeId, int CreatedBY)
        {
            IncomeReponce resultReponce = new IncomeReponce();
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "DELETE", DbType.String);
                parameters.Add("CommissionTypeId", CommissionTypeId, DbType.Int32);
                parameters.Add("CreatedBy", CreatedBY, DbType.Int32);

                resultReponce = await _repository.UpsertAsync("USP_CommissionType", parameters);

                return resultReponce;
            }
            catch (Exception ex)
            {
                return resultReponce;
            }
        }

        public async Task<CommissionType> IsDuplicateAsyncCommissionType(int CommissionTypeId, string Name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Type", "IsDuplicate", DbType.String);
            parameters.Add("CommissionTypeId", CommissionTypeId, DbType.Int32);
            parameters.Add("Name", Name, DbType.String);

            IEnumerable<CommissionType> CommissionType = await _repository.GetByIdAsync<CommissionType, dynamic>("USP_CommissionType", parameters);
            return CommissionType.FirstOrDefault();
        }

        #endregion CommissionType
    }
}