using FMS.Models;
using FMS.Repository;
using Dapper;
using System.Data;

namespace FMS.Data
{
    public class ReportServices : IReport
    {
        private readonly IRepository _repository;

        public ReportServices(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SaleHd>> GetAllSaleReport(string? Fillter, DateTime StartDate, DateTime EndDate, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", 1);
                parameters.Add("@BoatId", BoatId);
                parameters.Add("@StartDate", StartDate);
                parameters.Add("@EndDate", EndDate);

                var result = await _repository.GetAllAsync<SaleHd, dynamic>("USP_Reports", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IncomeHd>> GetAllIncomeReport(string? Fillter, DateTime StartDate, DateTime EndDate, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Type", 3);
                parameters.Add("@BoatId", BoatId);
                parameters.Add("@StartDate", StartDate);
                parameters.Add("@EndDate", EndDate);

                var result = await _repository.GetAllAsync<IncomeHd, dynamic>("USP_Reports", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OwnerExpenseHd>> GetAllExpenseReport(string? Fillter, DateTime StartDate, DateTime EndDate, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("@Type", 2);
                parameters.Add("@BoatId", BoatId);
                parameters.Add("@StartDate", StartDate);
                parameters.Add("@EndDate", EndDate);

                var result = await _repository.GetAllAsync<OwnerExpenseHd, dynamic>("USP_Reports", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Pnl

        public async Task<IEnumerable<Pnl>> GetAllPnl(string Fillter, DateTime? StartDate, DateTime? EndDate, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                //parameters.Add("Type", "GET_ALL", DbType.String);

                //string searchText = string.Empty;

                //if (!string.IsNullOrEmpty(Fillter))
                //{
                //    searchText += " AND BoatName LIKE '%" + Fillter + "%'";
                //    searchText += " OR OwnerExpenseHd.SaleNo LIKE '%" + Fillter + "%'";
                //}
                //if (BoatId > 0)
                //{
                //    searchText += $" AND SaleHd.BoatId = {BoatId} OR ({BoatId} = 0)";
                //}
                //searchText += $" AND SaleHd.StartDate BETWEEN '{StartDate?.ToString("yyyy-MM-dd")}' AND '{EndDate?.ToString("yyyy-MM-dd")}'";

                //parameters.Add("@SearchText", searchText);

                parameters.Add("@Type", 4);
                parameters.Add("@BoatId", BoatId);
                parameters.Add("@StartDate", StartDate);
                parameters.Add("@EndDate", EndDate);

                // var result = await _repository.GetAllAsync<Pnl, dynamic>("USP_Pnl", parameters);
                var result = await _repository.GetAllAsync<Pnl, dynamic>("USP_Reports", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CommissionReport>> GetAllCommission(string Fillter, DateTime StartDate, DateTime EndDate, int BoatId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("Type", "GET_ALL", DbType.String);
                parameters.Add("@BoatId", BoatId);
                parameters.Add("@StartDate", StartDate);
                parameters.Add("@EndDate", EndDate);

                var result = await _repository.GetAllAsync<CommissionReport, dynamic>("USP_RPTCommsion", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Dashboard>> GetDashboard()
        {
            try
            {
                var parameters = new DynamicParameters();

                var result = await _repository.GetAllAsync<Dashboard, dynamic>("Get_Dashboard", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Pnl
    }
}