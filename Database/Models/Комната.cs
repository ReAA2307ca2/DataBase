using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Комната
{
    public int Id { get; set; }

    public virtual ICollection<Сектор> Секторs { get; set; } = new List<Сектор>();
}
