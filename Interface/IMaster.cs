using FMS.Models;

namespace FMS.Data
{
    public interface IMaster
    {
        #region Boat

        Task<IEnumerable<Boat>> GetAllBoat(string Code, string Name, int? Status);

        Task<Boat> GetByIdAsyncBoat(int Id);

        Task<Boat> UpsertAsyncBoat(Boat model);

        Task<bool> UpdateStatusAsyncBoat(int Id, int CreatedBY);

        Task<IncomeReponce> DeleteAsyncBoat(int Id, int CreatedBY);

        Task<Boat> IsDuplicateAsyncBoat(int Id, string Name);

        #endregion Boat

        #region ExpenseType

        Task<IEnumerable<ExpenseType>> GetAllExpenseType(string Code, string Name, int? Status);

        Task<ExpenseType> GetByIdAsyncExpenseType(int Id);

        Task<ExpenseType> UpsertAsyncExpenseType(ExpenseType model);

        Task<bool> UpdateStatusAsyncExpenseType(int Id, int CreatedBY);

        Task<IncomeReponce> DeleteAsyncExpenseType(int Id, int CreatedBY);

        Task<ExpenseType> IsDuplicateAsyncExpenseType(int Id, string Name);

        #endregion ExpenseType

        #region CommissionType

        Task<IEnumerable<CommissionType>> GetAllCommissionType(string Code, string Name, int? Status);

        Task<CommissionType> GetByIdAsyncCommissionType(int Id);

        Task<CommissionType> UpsertAsyncCommissionType(CommissionType model);

        Task<bool> UpdateStatusAsyncCommissionType(int Id, int CreatedBY);

        Task<IncomeReponce> DeleteAsyncCommissionType(int Id, int CreatedBY);

        Task<CommissionType> IsDuplicateAsyncCommissionType(int Id, string Name);

        #endregion CommissionType
    }
}