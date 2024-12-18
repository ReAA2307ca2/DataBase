using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Книга
{
    public int Id { get; set; }

    public string? Название { get; set; }

    public int? FkЖанра { get; set; }

    public int? FkАвтора { get; set; }

    public int? FkИздателя { get; set; }

    public int? FkЭкземпляра { get; set; }

    public virtual Издатель? FkИздателяNavigation { get; set; }

    public virtual ICollection<АвторыКниг> АвторыКнигs { get; set; } = new List<АвторыКниг>();

    public virtual ICollection<ЖанрыКниг> ЖанрыКнигs { get; set; } = new List<ЖанрыКниг>();

    public virtual ICollection<ЭкземплярКниги> ЭкземплярКнигиs { get; set; } = new List<ЭкземплярКниги>();
}
