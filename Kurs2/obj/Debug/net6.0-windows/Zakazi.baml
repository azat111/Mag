   M S B A M L   `   `   `  ????@  <Kurs2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Kurs2Kurs2  5   	       Kurs2.Zakazi   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Kurs2     5   	     ? Title$  	Zakaixaml??5   	   $	??450??6   $	??800??6+   $	??450??6:   $	??800??6J   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6   ?? 5      $??2* ?6    ? RowDefinitions 5   
   ?? 5      $	??52* ?6   ?? 5      $	??39* ?6   ?? 5      $
??273* ?6   ?? 5      $	??38* ?6   ?? 5      $	??32* ?6   .+?5   
   ?? 
???????$??7??6!   $??0??66    J? Opacity$	 0.5Q?6C   6S   ?? 5   
   
???????$??7??6!   $??4??66   $	 0.5Q?6C   6T   ?? 5   
   
???????$??7??6!   $??2??66   $	 0.5Q?6C    ?? RadiusX$ 20??6Q    ?? RadiusY$ 20??6^   $??	10,0,10,0q?6k   6?   ?? 5   
   $??Заказы??6   $??7??6!   $??1??65   $??Center=?6B   $??Center=?6`   $??18(?6{   6?   ?? 5   
   $??2??6   $??0??6$   $??/Resources/DM.png??62   $??Right=?6M   $??Center=?6i   $??10,0,0,0q?6?   6?   ?? 5   
   -   5        $??
Выход??5      $??6??6    $??0??60   $??Center=?6=   $??Center=?6Z   $??20(?6u   6?   ?? 5    
   $??Заказы??6   $??5??6!   $??0??61   $??Center=?6>   $??Center=?6[   $??20(?6v   6?   ?? 5!   
   -   5        $??Товары??5!      $??4??6!   $??0??61   $??Center=?6>   $??Center=?6[   $??20(?6v   6?   &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ DataGridZakaz??5"         
IsReadOnly$
 True??6*   $??2??6<   $??7??6I   $??30,10,20,10q?6]      AutoGenerateColumns$ false??6r   	   Columns	 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Номер заказа??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   ?? *IdЗаказ+6Y     5%      $
 
Адрес??6%    64   ?? *
Адрес+6P     5&      $
 Способ оплаты??6%    6<   ?? *СпособОплаты+6_     5'      $
 Сумма заказа??6%    6;   ?? *ОбщаяСтоимость+6`     5(      $!
 Id Пользователя??6%    6>   ?? *IdПользователя+6c     5)      $
 Товары??6%    65   ?? *Товары+6R   5+      5,      5-      