using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Ячейка
{
    public int Id { get; set; }

    public int? FkПолки { get; set; }

    public virtual Полка? FkПолкиNavigation { get; set; }

    public virtual ICollection<ЭкземплярКниги> ЭкземплярКнигиs { get; set; } = new List<ЭкземплярКниги>();
}
