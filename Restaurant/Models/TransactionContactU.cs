﻿using System;
using System.Collections.Generic;

namespace Restaurant.Models;

public partial class TransactionContactUs : BaseEntity
{
    public int TransactionContactUsId { get; set; }

    public string? TransactionContactUsFullName { get; set; }

    public string? TransactionContactUsEmail { get; set; }

    public string? TransactionContactUsSubject { get; set; }

    public string? TransactionContactUsMessage { get; set; }
}
