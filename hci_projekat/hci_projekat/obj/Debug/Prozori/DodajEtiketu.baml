   M S B A M L   `   `   `  ����G  Chci_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:hci_projekat.Prozorihci_projekat.Prozori  5   	   +clr-namespace:hci_projekathci_projekat  5   	   '    !hci_projekat.Prozori.DodajEtiketu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   .local"clr-namespace:hci_projekat.Prozori  5   	   $valclr-namespace:hci_projekat  5   	     � Title$  Unos nove etikete��5
   	   $	��278��6#   $	��410��60   $	��290��6<   $	��290��6L    � WindowStartupLocation$ CenterScreen=�6\    � 
ResizeMode$ NoResize=�6�   .��5      � 
�������$	��400��6   $	��250��6*    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $	��100 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��Medium"�6   $��0��6(   $��0��68   $��15(�6E    �� TextAlignment$ Center=�6S   $��Center=�6j   $��Center=�6�   Oznaka Etikete:6�   �� 5   
   -   5        $��textBox1��5      $��3q�6"   $��1��66   $��0��6F   $��Center=�6S   
���   �$��Center=�6�   $	��100��6�   $��25��6�   ��6�   ��  �� Path$ Test1� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $��Medium"�6   $��0��6(   $��1��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   Boja:6�   #  Xceed.Wpf.Toolkit.ColorPicker  5   
   -   5        $	��Clr��5   B      DisplayColorAndName . $��1��6h   $��1��6x   $��Center=�6�   $��2q�6�   
����ح�$��Center=�6�   $	��100��6�   $��25��6�   	   SelectedColor	 6   �� $
 Boja�6  �� 5   
   $��Medium"�6   $��0��6(   $��2��68   $��15(�6E   $ Center=�6S   $��Center=�6j   $��Center=�6�   Opis:6�   �� 5   
   -   5        $��textBox2��5   �   $��1��6   $��3q�6"   $��2��66   $��Center=�6C   $��Center=�6`   $	��100��6{   $��60��6�   
���   �.��6�   ��5       �� 5!      $
 opis�6   $ PropertyChanged=�6&   
 �� ValidationRules
 5"      #   hci_projekat.CheckIfEmptyRule  5#      ,  &System.Windows.Controls.ValidationRule   ValidationStep$ RawProposedValue=�6/   5%      .��5&       =� ErrorTemplate 5'      �� 5(      .R�5)      �  5*      �� 5+       5-      �� 5.      �� 5/      $
��Auto �6/   .+�51      �� $��0��64   $��0��6D   �� 52      $��Medium"�6$   $��Center=�68   $��Center=�6U   $��20q�6p   $��1��6|   $��1��6�   
���  ��$��15(�6�   ��6�   �� *[0].ErrorContent+6�   53      54      .��55   (   56      �� 5:   
   -   5        $��15(�5:      $��Medium"�6   $��2��63   $��4��6C   $	��100��6P   $��30��6\   
���   � � Cursor$
 Hand��6|   $��2q�6�   $��Center=�6�   $��Center=�6�   .��6�   Dodaj6�   �� 5;   
   -   5        $��15(�5;      $��Medium"�6   $��0��63   $��4��6C   $	��100��6P   $��30��6\   
���   �$
 Hand��6|   $��2q�6�   $��Center=�6�   $��Center=�6�   .��6�   
Odustani6�   5<      5=      