﻿using expense_tracker_backend.Domain.Enums;
using System;

namespace expense_tracker_backend.Transfer
{
    public class TransactionRequest
    {
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public string CurrencyName { get; set; }
        public string Note { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AccountId { get; set; }
    }
}
