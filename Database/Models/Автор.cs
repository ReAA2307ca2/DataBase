using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Автор
{
    public int Id { get; set; }

    public string? Имя { get; set; }

    public virtual ICollection<АвторыКниг> АвторыКнигs { get; set; } = new List<АвторыКниг>();
}
