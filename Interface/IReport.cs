using FMS.Models;

namespace FMS.Data
{
    public interface IReport
    {
        Task<IEnumerable<Pnl>> GetAllPnl(string Fillter,DateTime? StartDate, DateTime? EndDate, int BoatId=0);
        Task<IEnumerable<CommissionReport>> GetAllCommission(string Fillter, DateTime StartDate, DateTime EndDate, int BoatId = 0);
        Task<IEnumerable<Dashboard>> GetDashboard();
    }
}
