using System;
using System.Collections.Generic;

namespace Manga_BLL.Entities;

public partial class Feature
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime DateAppear { get; set; }

    public DateTime? DateDisappear { get; set; }

    public virtual Character Character { get; set; } = null!;
}
