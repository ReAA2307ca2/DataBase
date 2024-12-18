using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Издатель
{
    public int Id { get; set; }

    public string? Название { get; set; }

    public virtual ICollection<Книга> Книгаs { get; set; } = new List<Книга>();
}
