using FMS.Models;

namespace FMS.Data
{
    public interface IReport
    {
        Task<IEnumerable<SaleHd>> GetAllSaleReport(string? Fillter, DateTime StartDate, DateTime EndDate, int BoatId = 0);

        Task<IEnumerable<OwnerExpenseHd>> GetAllExpenseReport(string? Fillter, DateTime StartDate, DateTime EndDate, int BoatId = 0);

        Task<IEnumerable<IncomeHd>> GetAllIncomeReport(string? Fillter, DateTime StartDate, DateTime EndDate, int BoatId = 0);

        Task<IEnumerable<Pnl>> GetAllPnl(string Fillter, DateTime? StartDate, DateTime? EndDate, int BoatId = 0);

        Task<IEnumerable<CommissionReport>> GetAllCommission(string Fillter, DateTime StartDate, DateTime EndDate, int BoatId = 0);

        Task<IEnumerable<Dashboard>> GetDashboard();
    }
}