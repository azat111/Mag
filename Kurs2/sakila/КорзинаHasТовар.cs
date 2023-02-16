using System;
using System.Collections.Generic;

namespace Kurs2.sakila;

public partial class КорзинаHasТовар
{
    public int КорзинаIdКорзина { get; set; }

    public int ТоварIdТовар { get; set; }

    public int? Колво { get; set; }

    public int? ИтогЦена { get; set; }

    public virtual Корзина КорзинаIdКорзинаNavigation { get; set; } = null!;

    public virtual Товар ТоварIdТоварNavigation { get; set; } = null!;

	public string Название => this.ТоварIdТоварNavigation.Название;
    public string Стоимость => this.ТоварIdТоварNavigation.FullPrice;

}
