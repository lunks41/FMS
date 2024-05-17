﻿using FMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FMS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Master
        public DbSet<Boat>? Boat { get; set; }
        public DbSet<ExpenseType>? ExpensesType { get; set; }
        public DbSet<CommissionType>? CommissionType { get; set; }
        #endregion

        #region Transactions
        public DbSet<SaleHd>? SaleHd { get; set; }
        public DbSet<OwnerExpenseHd>? OwnerExpenseHd { get; set; }
        public DbSet<IncomeHd>? IncomeHd { get; set; }
        public DbSet<CreditHd>? CreditHd { get; set; }
        #endregion

        #region Report
        #endregion
    }
}