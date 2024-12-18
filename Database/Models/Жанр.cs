using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Жанр
{
    public int Id { get; set; }

    public string? Название { get; set; }

    public virtual ICollection<ЖанрыКниг> ЖанрыКнигs { get; set; } = new List<ЖанрыКниг>();
}
