   M S B A M L   `   `   `  ����G  CPOLOSIN_3_PR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:POLOSIN_3_PR.UI_AdditionalWindows!POLOSIN_3_PR.UI_AdditionalWindows  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   .    (POLOSIN_3_PR.UI_AdditionalWindows.Graphs   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:POLOSIN_3_PR.UI_AdditionalWindows     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  Graphs��5	   	   $	��450��6   $	��800��6%   .��5
      � .+�5   
   #  LiveCharts.Wpf.CartesianChart  -   5          Name$ ConcentrationGraphs��5      $��15,25,0,100q�6:   $	��425��6O   $
��Left=�6[   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6v   �� 5   
   $5��/Показатели экономичности��6   $��Bottom=�65   $��15,0,150,15q�6P   $��65��6e   
���   �$��1q�6�   .��5      �  � ColumnDefinitions 5      �� 5      6)   �� 5      6)   �� 5      6)   �� 5      6)   �� 5      6)   �� 5      6)   .+�5      �� $��0��6   $��Center=�6(   .��6C   Время, мс6N   �� 5      -   5         ��Name$ ElapsedTimeTextBox��5      $��1��66    �� 
IsReadOnly$
 True��6F   $��3,3,3,3q�6X   $��Center=�6i   �� 5      $��2��6   $��Center=�6,   $��WrapWithOverflow=�6G   ,*Производительность, МБ6   �� 5      -   5        $ MemoryUsedTextBox��5      $��3��65   $
 True��6E   $��3,3,3,3q�6W   $��Center=�6h   �� 5      $��4��6   $��Center=�6,   $��WrapWithOverflow=�6G   0.Кол-во арифм. операций, шт6�   �� 5      -   5        $ OperationCountTextBox��5      $��5��69   $
 True��6I   $��3,3,3,3q�6[   $��Center=�6l   5      5      �� 5!   
   $%��Таблица значений��6   $��Right=�6+   $	��Top=�6G   $��	0,0,105,0q�6_   �� 5#   
   -   5         ��Name$ GetDocument��5#      $&�� Сохранить в отчет��6&   $��Right=�6B   $��Bottom=�6^   $	��125��6y   $��35��6�   $��	0,0,15,25q�6�   6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ ConcentrationDataGrid��5%      $��Right=�62   $��0,25,15,100q�6N   $	��300��6c      AutoGenerateColumns$
 True��6o   	   CanUserResizeColumns$	 False��6�   
   CanUserReorderColumns$
 False��6�      CanUserSortColumns$ False��6�      SelectionUnit$
 Cell=�6�      CanUserResizeRows$ False��6�      
IsReadOnly$
 True��6  5&      5(      5)      