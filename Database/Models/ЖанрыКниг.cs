using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ЖанрыКниг
{
    public int Id { get; set; }

    public int? FkКниги { get; set; }

    public int? FkЖанра { get; set; }

    public virtual Жанр? FkЖанраNavigation { get; set; }

    public virtual Книга? FkКнигиNavigation { get; set; }
}
