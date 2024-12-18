using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class АвторыКниг
{
    public int Id { get; set; }

    public int? FkКниги { get; set; }

    public int? FkАвтора { get; set; }

    public virtual Автор? FkАвтораNavigation { get; set; }

    public virtual Книга? FkКнигиNavigation { get; set; }
}
