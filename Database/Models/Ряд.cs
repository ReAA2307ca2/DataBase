using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Ряд
{
    public int Id { get; set; }

    public int? FkСектора { get; set; }

    public virtual Сектор? FkСектораNavigation { get; set; }

    public virtual ICollection<Стеллаж> Стеллажs { get; set; } = new List<Стеллаж>();
}
