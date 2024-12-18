using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Формуляр
{
    public int Id { get; set; }

    public int? FkКниги { get; set; }

    public int? FkБилета { get; set; }

    public int? FkБиблиотекаря { get; set; }

    public int? FkОперации { get; set; }

    public DateTime? Дата { get; set; }

    public virtual Библиотекарь? FkБиблиотекаряNavigation { get; set; }

    public virtual Читатель? FkБилетаNavigation { get; set; }

    public virtual ЭкземплярКниги? FkКнигиNavigation { get; set; }

    public virtual Операция? FkОперацииNavigation { get; set; }
}
