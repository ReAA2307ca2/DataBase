using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Библиотекарь
{
    public int Id { get; set; }

    public string? Имя { get; set; }

    public virtual ICollection<Формуляр> Формулярs { get; set; } = new List<Формуляр>();
}
