   M S B A M L   `   `   `  ????I  ETotalCommander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TotalCommander.ViewsTotalCommander.Views  5   	   E'clr-namespace:TotalCommander.ViewModelsTotalCommander.ViewModels  5   	   %    TotalCommander.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:TotalCommander.Views     5   	   6vm'clr-namespace:TotalCommander.ViewModels     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)    ? DataContext 5
      -  'TotalCommander.ViewModels.MainViewModel  5   
   6   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??8* ?6   6*   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      6!   .+?5   
   ?? $??0??6   ??5      ?? *panel1+5      ?? 5   
   $??1??6   ??5      ?? *panel2+5       ?? 5"   
   $??1??6    ?? Orientation$ 
Horizontal=?6"   $??Center=?6;   .+?5#      ?? $??15(?5$      $??10q?5%      $
??Bold)?5&      
???????
???????Enter-просмотр5)   #   ?? 5*      $??15(?5+      $??10q?5,      
???????
???????Backspace-назад51      54      ?? 55   
   $ 
Horizontal=?6   $??1??6.   $??1??6;   $??Center=?6K   .+?56      ?? $??15(?57      $??10q?58      
???????
???????F5-копировать5;   !   ?? 5<      $??15(?5=      $??10q?5>      $
??Bold)?5?      
???????
???????F6-переместить5E      5F      5G      5H      