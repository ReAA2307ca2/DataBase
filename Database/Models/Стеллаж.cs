using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Стеллаж
{
    public int Id { get; set; }

    public int? FkРяда { get; set; }

    public virtual Ряд? FkРядаNavigation { get; set; }

    public virtual ICollection<Полка> Полкаs { get; set; } = new List<Полка>();
}
