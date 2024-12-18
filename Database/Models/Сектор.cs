using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Сектор
{
    public int Id { get; set; }

    public int? FkКомнаты { get; set; }

    public virtual Комната? FkКомнатыNavigation { get; set; }

    public virtual ICollection<Ряд> Рядs { get; set; } = new List<Ряд>();
}
