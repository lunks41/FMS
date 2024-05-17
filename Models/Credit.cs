﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Models
{
    public class CreditHd : AddCommonEntity
    {
        public int CreditId { get; set; }
        public string? CreditNo { get; set; }
        public int BoatId { get; set; }
        public string? BoatName { get; set; }
        public string? PersonName { get; set; }
        public DateTime CreditDate { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        [NotMapped]
        public ICollection<CreditDt>? CreditsDts { get; set; }
    }

    [Keyless]
    public class CreditDt
    {
        public int CreditId { get; set; }
        public string? CreditNo { get; set; }
        public byte ItemNo { get; set; }
        public byte SquenceNo { get; set; }
        public DateTime ReceivedDate { get; set; }
        public decimal Amount { get; set; }
    }
}