﻿using System;
using System.Collections.Generic;

namespace Manga_BLL.Entities;

public partial class Character
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Origin { get; set; }

    public string? MangaGenre { get; set; }

    public bool? IsOngoing { get; set; }

    public string? Author { get; set; }

    public virtual Feature? Feature { get; set; }
}
