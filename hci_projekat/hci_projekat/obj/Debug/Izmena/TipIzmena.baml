   M S B A M L   `   `   `  ����G  Chci_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:hci_projekat.Izmenahci_projekat.Izmena  5   	   +clr-namespace:hci_projekathci_projekat  5   	   #    hci_projekat.Izmena.TipIzmena   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:hci_projekat.Izmena     5   	   *valclr-namespace:hci_projekat     5   	     � Title$  Izmena Tipa��5	   	   $	��390��6   $	��410��6*   $	��390��67   $	��390��6G    � WindowStartupLocation$ CenterScreen=�6W    � 
ResizeMode$ NoResize=�6|   .��5
      � 
�������$	��400��6   $	��350��6*    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $	��100 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��Medium"�6   $��0��6(   $��0��68   $��15(�6E    �� TextAlignment$ Center=�6S   $��Center=�6j   $��Center=�6�   Oznaka Tipa:6�   �� 5   
   -   5        $��textBoxOznakaTipa��5      $��5q�6o   $��1��6�   $��0��6�   $��Center=�6�   
���   �$��Center=�6�   $	��100��6�   $��25��6�   ��6,   ��  �� Path$ OznakaT� �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5   
   $��Medium"�6   $��0��6(   $��1��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   Naziv Tipa:6�   �� 5   
   $��5q�6   $��1��6'   $��1��67   $��Center=�6D   
���   �$��Center=�6u   $	��100��6�   $��25��6�   .��6�   ��5      �� 5      $
 ImeT�6   $ PropertyChanged=�6&    �� ValidationRules 5      #   hci_projekat.CheckIfEmptyRule  5       ,  &System.Windows.Controls.ValidationRule	   ValidationStep$	 RawProposedValue=�6/   "   hci_projekat.CheckStringRule  5!      $	 RawProposedValue=�6.   5#      .��5$      
 =� ErrorTemplate
 5%      �� 5&      .R�5'      �  5(      �� 5)       5+      �� 5,      �� 5-      $
��Auto �6/   .+�5/      �� $��0��64   $��0��6D   �� 50      $��Medium"�6$   $��Center=�68   $	��Top=�6U   $
��20,0q�6m   $��1��6{   $��0��6�   
���  ��$��15(�6�   ��6�   �� *[0].ErrorContent+6�   51      52      .��53   (   54      �� 56   
   $��Medium"�6   $��0��6(   $��2��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   
Ikonica:6�   �� 57   
   -   5        $��imageBorder��57   v   $��2q�6   $��1��6%   $��2��65   
����İ�$��82��6_   $��82��6j   ._�58      �� -   5        $��image1��58   H   $��1��6   $��2��6$   $��80��61   $��80��6<   ��6V   �� $ ikonicaT�6y   59      �� 5;   
   -   5        $��15(�5;      $��Medium"�6   $��2��63   $��2��6C   $��Center=�6P   $��2q�6m   $��Center=�6�   $	��100��6�   $��30��6�   
���   � � Cursor$
 Hand��6�   .��6�   	Izaberi6�   �� 5=   
   $��Medium"�6   $��0��6(   $��3��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   
Opis Tipa:6�   �� 5>   
   $��5q�6   $��1��6'   $��3��67   $��Center=�6D   $��Center=�6a   $	��100��6|   $��70��6�   
���   �.��6�   ��5?      �� 5@      $ OpisT�6   $ PropertyChanged=�6'    5A        5B      $	 RawProposedValue=�6/   5D      .��5E      
 5F      �� 5G      .R�5H      �  5I      �� 5J       5L      �� 5M      �� 5N      $
��Auto �6/   .+�5P      �� $��0��64   $��0��6D   �� 5Q      $��Medium"�6$   $��Center=�68   $��Center=�6U   $��20q�6p   $��1��6|   $��1��6�   
���  ��$��15(�6�   ��6�   �� *[0].ErrorContent+6�   5R      5S      .��5T   (   5U      �� 5[   
   -   5        $��15(�5[      $��Medium"�6   $��2��63   $��4��6C   $	��100��6P   $��30��6\   
���   �$
 Hand��6|   $��2q�6�   $��Center=�6�   $��Center=�6�   .��6�   Izmeni6�   �� 5\   
   -   5        $��15(�5\      $��Medium"�6   $��0��63   $��4��6C   $	��100��6P   $��30��6\   
���   �$
 Hand��6|   $��2q�6�   $��Center=�6�   $��Center=�6�   .��6�   
Odustani6�   5]      5^      