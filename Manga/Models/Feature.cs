using System;
using System.Collections.Generic;

namespace Manga.Models;

public partial class Feature
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime DateAppear { get; set; }

    public DateTime? DateDisappear { get; set; }

    public virtual ICollection<Character> Characters { get; set; } = new List<Character>();
}
