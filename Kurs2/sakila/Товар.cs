using System;
using System.Collections.Generic;

namespace Kurs2.sakila;

public partial class Товар
{
    public int IdТовар { get; set; }

    public string Название { get; set; } = null!;

    public int Стоимость { get; set; }

    public int? Количество { get; set; }

    public string? Категория { get; set; }

    public byte[]? Фото { get; set; }

    public virtual ICollection<КорзинаHasТовар> КорзинаHasТоварs { get; set; } = new List<КорзинаHasТовар>();

	public string FullPrice => Convert.ToString(this.Стоимость) + " Руб";
}
