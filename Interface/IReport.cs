using FMS.Models;

namespace FMS.Data
{
    public interface IReport
    {
        Task<IEnumerable<Pnl>> GetAllPnl(string Fillter, int BoatId = 0);
        Task<IEnumerable<CommissionReport>> GetAllCommission(string Fillter, int BoatId = 0);
        Task<IEnumerable<Dashboard>> GetDashboard();
    }
}
