   M S B A M L   `   `   `  ????@  <Lab_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_2Lab_2  5   	       Lab_2.Greeting   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_2     5   	   -   5          ?Name$  GreetingForm??5   	    ? Title$ Приветствие??5   	   $	??222??6   $	??534??6*    ? WindowStyle$ ThreeDBorderWindow=?66    ? WindowStartupLocation$ CenterScreen=?6n    ? 
ResizeMode$ NoResize=?6?   .??5	      ?  J? RenderTransformOrigin$ 0.552,0.247&?6    ? RowDefinitions 5
   
   ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      ?? 5      ?? 5      .+?5   
   ?? -   5         ??Name$ ButtonForward??5      $??
Далее??6(   $??Center=?68   $	??166??6U   ${?False??6a   $??20(?6s   $ 0.5,0.5&?6?   $??Center=?6?   $??1??6?   $??1??6?   $??64??6?   ?? 5   
   -   5        	 ??Name$	 CountAnswer??5      $e??_Количество вопросов 
на которые вы хотите ответить:??6%   $??Center=?6l   $??Center=?6?   $??20(?6?   $	??336??6?   $??2??6?   $??64??6?   ?? 5   
   -   5        
 ??Name$
 CountAnswerTextBox??5      $??2??6.   $??Center=?6>    ?? TextWrapping$
 Wrap=?6[   $??Center=?6o   $	??158??6?   $ -0.21,-0.447&?6?   $??20(?6?   $??64??6?   .??6?    ? ToolTip 5      _? 5      .??5      ?? .+?5      ?? -   5         ??Name$ CountAnswerTooltip??5   $   $
??Left=?6@   $
??Wrap=?6[   $	??Top=?6o   $
??auto??6?   $??1??6?   5      5      .??5      5      5      5      