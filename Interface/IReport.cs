using FMS.Models;

namespace FMS.Data
{
    public interface IReport
    {
        #region Sale
        Task<IEnumerable<Pnl>> GetAllPnl(string Fillter, int BoatId = 0);
        #endregion
    }
}
