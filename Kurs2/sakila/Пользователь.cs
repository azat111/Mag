using System;
using System.Collections.Generic;

namespace Kurs2.sakila;

public partial class Пользователь
{
    public int IdПользователь { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public string Роль { get; set; } = null!;

    public virtual ICollection<Заказ> Заказs { get; set; } = new List<Заказ>();

    public virtual ICollection<Корзина> Корзинаs { get; set; } = new List<Корзина>();
}
