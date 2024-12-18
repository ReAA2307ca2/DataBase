using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Полка
{
    public int Id { get; set; }

    public int? FkСтеллажа { get; set; }

    public virtual Стеллаж? FkСтеллажаNavigation { get; set; }

    public virtual ICollection<Ячейка> Ячейкаs { get; set; } = new List<Ячейка>();
}
