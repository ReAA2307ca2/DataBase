using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ЭкземплярКниги
{
    public int Id { get; set; }

    public int? FkЯчейки { get; set; }

    public int? FkОригинала { get; set; }

    public virtual Книга? FkОригиналаNavigation { get; set; }

    public virtual Ячейка? FkЯчейкиNavigation { get; set; }

    public virtual ICollection<Формуляр> Формулярs { get; set; } = new List<Формуляр>();
}
