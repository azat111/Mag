using System;
using System.Collections.Generic;

namespace Kurs2.sakila;

public partial class Корзина
{
    public int IdКорзина { get; set; }

    public int IdПользователь { get; set; }

    public virtual ICollection<КорзинаHasТовар> КорзинаHasТоварs { get; set; } = new List<КорзинаHasТовар>();

    public virtual Пользователь ПользовательIdПользовательNavigation { get; set; } = null!;
}
