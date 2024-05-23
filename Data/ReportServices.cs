﻿using FMS.Models;
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

        #region Pnl
        public async Task<IEnumerable<Pnl>> GetAllPnl(string Fillter, int BoatId)
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
                }
                if (BoatId > 0)
                {
                    searchText += $" AND SaleHd.BoatId = {BoatId} OR ({BoatId} = 0)";
                }

                parameters.Add("@SearchText", searchText);

                var result = await _repository.GetAllAsync<Pnl, dynamic>("USP_Pnl", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}
