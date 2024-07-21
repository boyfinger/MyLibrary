﻿using System;
using System.Collections.Generic;

namespace model;

public partial class BorrowRecord
{
    public int UserId { get; set; }

    public int BookId { get; set; }

    public DateOnly? BorrowDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
