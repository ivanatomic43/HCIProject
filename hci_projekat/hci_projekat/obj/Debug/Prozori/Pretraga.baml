   M S B A M L   `   `   `  ����G  Chci_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:hci_projekat.Prozorihci_projekat.Prozori  5   	   +clr-namespace:hci_projekathci_projekat  5   	   #    hci_projekat.Prozori.Pretraga   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:hci_projekat.Prozori     5   	   *valclr-namespace:hci_projekat     5   	     � 
ResizeMode$  NoResize=�5	   
    � Title$ Pretraga spomenika��5
   	   $	��450��6$   $	��600��61    � WindowStartupLocation$ CenterScreen=�6=   .��5      � 
�������$	��800��6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $	��150 �6   �� 5      $	��100 �6   �� 5      $	��120 �6    � RowDefinitions 5   
   �� 5      $��45 �6   �� 5      $��45 �6   �� 5      $��80 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��65 �6   �� 5      $��80 �6   .+�5   
   �� $��Medium"�6   $��0��6(   $��0��68   $��15(�6F    �� TextAlignment$ Center=�6T   $��Center=�6k   $��Center=�6�   	Oznaka:6�   �� 5   
   -   5        $��textBoxOznakaSpomenik��5   v   $��1��6   $
��Left=�6"   $��4q�6=   $��0��6Q   $��25��6^   $	��130��6j   
���   ���6�   ��  �� Path$ Oznaka� �� UpdateSourceTrigger$ PropertyChanged=�.��6�   5"      �� 5$   
   $��Medium"�6   $��0��6(   $��1��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   Naziv:6�   �� 5%   
   -   5        $��textBoxImeSpomenik��5%   �   $��Center=�6   $��5q�6-   $
��Left=�6A   $��1��6\   $��1��6l   $��25��6y   $	��130��6�   
���   �.��6�   ��5&      �� 5'      $ Naziv�6   $ PropertyChanged=�6'   5)      .��5*      5+      �� 5-   
   $��Medium"�6   $��0��6)   $��2��69   $��15(�6F   $��Center=�6T   $��Center=�6q   $ Center=�6�   Opis:6�   �� 5.   
   -   5        $��textBoxOpisSpomenik��5.   ^   $��1��6   $��5q�6"   $��2��66   $
��Left=�6C   $��60��6y   $	��130��6�   
���   �.��6�   ��5/      �� 50      $
 Opis�6   $ PropertyChanged=�6&   52      .��53      54      �� 56   
   $��Medium"�6   $��0��6)   $��3��69   $��15(�6F   $ Center=�6T   $��Center=�6k   $��Center=�6�   �� 6�   $�
Ekološki ��6�   �� 6�   �� 6�   $�	ugrožen:��6�   6�   	� 57   
   -   5        $��radio1��57   �   $��Medium"�6   $��5q�6+   $��Da��6?   $��3��6L   $��1��6Y   $��Center=�6i   $��Center=�6�   $��27,22.6,89.4,25.2q�6�   	� 58   
   -   5        $��radio2��58   �   $��Medium"�6   $��5q�6+   $��Ne��6?   $��3��6L   $��1��6Y   $��Center=�6i   $��Center=�6�   $��84,22.6,30.4,25.2q�6�   $��36��6�   �� 5:   
   $��Medium"�6   $��0��6(   $��4��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   �� 6�   $�	Stanište��6�   �� 6�   �� 6�   $�ugroženih vrsta:��6�   6�   	� 5;   
   -   5        $��radio3��5;   �   $��Medium"�6   $��5q�6+   $��Da��6?   $��4��6L   $��1��6Y   $��Center=�6i   $��Center=�6�   $��27,22.6,89.4,25.2q�6�   	� 5<   
   -   5        $��radio4��5<   �   $��Medium"�6   $��5q�6+   $��Ne��6?   $��4��6L   $��1��6Y   $��Center=�6i   $��Center=�6�   $��84,22.6,30.4,25.2q�6�   $��36��6�   �� 5>   
   $��Medium"�6   $��0��6(   $��5��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   �� 6�   $�Naseljen��6�   �� 6�   �� 6�   $�region:��6�   6�   	� 5?   
   -   5        $��radio5��5?   �   $��Medium"�6   $��5q�6+   $��Da��6?   $��5��6L   $��1��6Y   $��Center=�6i   $��Center=�6�   $��27,22.6,89.4,25.2q�6�   	� 5@   
   -	   5        $��radio6��5@   �   $��Medium"�6   $��5q�6+   $��Ne��6?   $��5��6L   $��1��6Y   $��Center=�6i   $��Center=�6�   $��84,22.6,30.4,25.2q�6�   $��36��6�   �� 5B   
   $��Medium"�6   $��2��6(   $��0��68   $��15(�6E   $��Center=�6S   $��Center=�6p   $ Center=�6�   Tip:6�   �� 5C   
   -
   5        $��comboBoxTipD��5C   �    �� SelectedIndex$ 0��6   $��5q�6e   $��0��6�   $��Center=�6�   $	��110��6�   $��22��6�   $��3��6�   
���   �	 �� Text	 6%   �� $	 Tip�$ PropertyChanged=���6y   �� $ tipovi�5E      �� 5H   
   $��Medium"�6   $��2��6(   $��1��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   Klima:6�   �� 5I   
   -   5        $��comboBoxKlima��5I   �   $��1��6   $	��110��6j   
 �� 
IsEditable
 .  
����ح�$��5q�6�   $��3��6�   $��22��6�    6    �� $ Klima�$ PropertyChanged=�.@�5J      �� $��Polarna��6   �� 5K      $��Kontinentalna��6   �� 5L      $��Umereno-kontinentalna��6   �� 5M      $��
Pustinjska��6   �� 5N      $��
Suptropska��6   �� 5O      $��Tropska��6   5Q      �� 5S   
   $��Medium"�6   $��2��6)   $��2��69   $��15(�6F   $ Center=�6T   $��Center=�6k   $��Center=�6�   �� 6�   $�Turistički��6�   �� 6�   �� 6�   $�status:��6�   6�   6�   �� 5T   
   -   5        $��comboBoxStatus��5T   �   $��2��6   $	��110��6j   $��Center=�6v   
����ح�
 .  $��3��6�   $��22��6�    �� SelectedItem 6    �� $ Status�$ PropertyChanged=�.@�5U      �� $��Eksploatisan��6   �� 5V      $��Dostupan��6   �� 5W      $��
Nedostupan��6   5Z      �� 5]   
   $��Medium"�6   $��2��6(   $��3��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   �� 6�   $�	Godišnji��6�   �� 6�   �� 6�   $�prihod:��6�   6�   6�   �� 5^   
   -   5        $��textBoxPrihod��5^   O   $��3��6   $��5q�6"   $��3��66   $	��100��6C   
���   �$��25��6x   .��6�   ��5_      �� 5`      $ Prihod�6   $ PropertyChanged=�6(   5b      .��5c      5e      �� 5g   
   $��Medium"�6   $��2��6)   $��4��69   $��15(�6F   $ Center=�6T   $��Center=�6k   $��Center=�6�   $��15.6,19.8,10.4,5q�6�   $��74��6�   �� 6�   $�Datum:��6�   �� 6�   �� 6�   $�otkrivanja:��6�   6  6  (  "System.Windows.Controls.DatePicker  5h   
   -   5        $
��date��5h   E   $��3q�61   $��3��6Q   $��4��6a   $	��110��6n   $��Center=�6z   
����İ�$��Center=�6�   $��30��6�   $��4.6,19.8,5.4,15q�6�   �� 5j   
   -   5        $��15(�5j      $��Medium"�6   $��3��63   $��6��6C   $	��2.5q�6P   
���   � � Cursor$
 Hand��6z   $��30��6�   $	��100��6�   $��Center=�6�   $��Center=�6�   $��55.2,10.2,-34.4,39.8q�6�   .��6  	Pretraži6  �� 5k   
   -   5        $��15(�5k      $��Medium"�6   $��2��63   $��6��6C   
���   �$	��2.5q�6d   $
 Hand��6z   $��30��6�   $	��100��6�   $��Center=�6�   $��Center=�6�   $��16,10.2,105.6,39.8q�6�   $��2��6  .��6  
Odustani6#  5n      5o      