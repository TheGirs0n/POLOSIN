   M S B A M L   `   `   `  ����G  CPOLOSIN_3_PR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:POLOSIN_3_PR.UI_AdditionalWindows!POLOSIN_3_PR.UI_AdditionalWindows  5   	   ;    5POLOSIN_3_PR.UI_AdditionalWindows.AddChemicalEquation   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:POLOSIN_3_PR.UI_AdditionalWindows     5   	     � Title$  AddChemicalEquation��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   �� $<��6Количество компонентов слева��6   $
��Left=�67   $	��Top=�6R   $��	15,10,0,0q�6j   �� 5   
   $>��8Количество компонентов справа��6   $��Right=�68   $	��Top=�6T   $��	0,10,15,0q�6l   �� 5   
   -   5         ��Name$ VelocityConstTypeComboBox��5       �� SelectedIndex$ 0��66   $��Center=�6H   $��Center=�6e   $��
175,0,0,75q�6�   .@�5      �� Дж/моль6!   �� 5      Кдж/моль6"   5      �� 5   
   -   5         ��Name$( "LeftChemicalComponentsCountTextBox��5      $
��Left=�6>   $	��Top=�6Y   $	��100��6q   $��
205,15,0,0q�6}   6�   �� 5   
   -   5        $) #RightChemicalComponentsCountTextBox��5      $��Right=�6?   $	��Top=�6[   $	��100��6s   $��
0,15,210,0q�6   6�   �� 5   
   -   5         ��Name$ AddComponentsToReaction��5      $��=��62   $	��Top=�6>   $��Center=�6V   $��0,15,0,0q�6s   $��25��6�   $	��125��6�   6�   �� 5   
   -   5        $ AddReaction��5      $%��Добавить реакцию��6&   $��Center=�6A   $��Center=�6^   $	��160��6y   $��35��6�   $��0,50,0,0q�6�   6�   �� 5   
   -   5        $ GetOverralReaction��5      $��Вид реакции��6-   $y�Hidden=�6C   $��Center=�6W   $��Center=�6t   $��	0,150,0,0q�6�   $	��150��6�   $��35��6�   6�   �� 5   
   -   5         ��Name$ LeftComponentGroupBox��5      $B��<Компоненты в левой части реакции��62   $
��Left=�6\   $	��Top=�6w   $��	15,50,0,0q�6�   $	��250��6�   $	��250��6�   $	��250��6�   
���   �.��5      �� $
��Auto=�6   .��5      �� -   5         ��Name$ LeftComponentsStackPanel��5      5      5      �� 5   
   -	   5        $ RightComponentGroupBox��5      $D��>Компоненты в правой части реакции��63   $��Right=�6^   $	��Top=�6z   $��	0,50,15,0q�6�   $	��250��6�   $	��250��6�   $	��250��6�   
���   �.��5      �� $
��Auto=�6   .��5      �� -
   5        $ RightComponentsStackPanel��5      5       5!      �� 5"   
   $"��Пред. множитель��6   $��Center=�6,   $	��Top=�6I   $��	0,80,75,0q�6a   
���   �$	��160��6�   .��5#      ��  �� Orientation$ 
Horizontal=�6   .+�5$      �� .��6   K6   �� 5%      -   5        $ VelocityConst��5%      $��Center=�6�   $ �� HorizontalScrollBarVisibility$
 Auto=�6�   5&      5'      �� 5(   
   $'��!Энергия активации��6   $��Center=�6.   $��Center=�6K   
���   �$	��160��6z   $��	0,0,75,80q�6�   .��5)      �� $ 
Horizontal=�6   .+�5*      �� .��6   E6   �� 5+      -   5        $ EnergyActivation��5+      $��Center=�6�   $
 Auto=�6�   6�   5,      5-      �� 51   
   $
��*10^��6   $��Center=�6   $	��Top=�6<   $��
130,95,0,0q�6T   �� 52   
   -   5        	 ��Name$	 ReactionView��52      $��Вид реакции��6&   $��Bottom=�6<   $��0,0,0,50q�6W   $��Center=�6i   $y�Hidden=�6�   �� 53   
   -   5        $	 OverralReactionView��53      $�� ��6-   $��Bottom=�68   $��
15,0,15,25q�6S   $y�Hidden=�6g   $��Center=�6{   $��20(�6�   �� 54   
   -   5        $ 
PowTextBox��54      $��Center=�6&   $��215,100,0,0q�6C   
 �� TextWrapping$

 Wrap=�6X   $�� ��6l   $	��Top=�6t   $��40��6�   6�   55      56      