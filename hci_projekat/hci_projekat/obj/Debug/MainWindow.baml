   M S B A M L   `   `   `  ����G  Chci_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:hci_projekat.Klasehci_projekat.Klase  5   	   A%clr-namespace:hci_projekat.HelpSystemhci_projekat.HelpSystem  5   	   +clr-namespace:hci_projekathci_projekat  5	   
       hci_projekat.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/netfx/2007/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=1.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   ,local clr-namespace:hci_projekat.Klase  5   	   -l%clr-namespace:hci_projekat.HelpSystem  5   	   $cmdclr-namespace:hci_projekat  5	   
     � Title$  Mapa Spomenika��5   	    � WindowStartupLocation$ CenterScreen=�6     � WindowState$ 	Maximized=�6E    � WindowStyle$
 None=�6]   $��Stretch=�6p   $��Stretch=�6�   $	��987��6�   $
��1540��6�    � 	Resources 5         
FolderOpen �� 	UriSource  FolderClosed  	SmallIcon �� 
TargetType �� Property �� Value��%&  &	        &	 =     &	 y     �� 5   
   $) #/hci_projekat;component/foldero.png?�6)   �� 5   
   $( "/hci_projekat;component/folder.png?�6+   �� 5   
   " ��6"   .�5      ��  � ��$ 16��6)   �� 5       � ��$ 16��6*   �� 5       � ��$ 1q�6'   5      5      	 J� CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5        
   Command$
 cmd:Mnemonic.Spomenik��5      6y     5   
   -   5        $
 cmd:Mnemonic.Etiketa��5      6v     5   
   -   5        $
 cmd:Mnemonic.Tip��5      6j     5   
   -   5        $
 cmd:Mnemonic.Pregled��5      6v     5   
   -   5        $
 cmd:Mnemonic.Pomoc��5      6p   .��5      ]� 
�������$��Stretch=�6#   $��Stretch=�6A   .+�5   
   � $��Bottom=�6   ���#2aa2a2$��Stretch=�6<   $��215,0,198.6,0q�6Z   $	��135��6q    J� RenderTransformOrigin$ 0.5,0.5&�6~   z�5       V� 5!      .~�5"      ��  �� ScaleY$ -1Q�6%   �� 5#      �� 5$      T� 5%      5&      5)      � 5,   
   $
��Left=�6   ���#2aa2a2$	��219��6;   $��0,72,0,-135.4q�6G   $��Stretch=�6^   $��Stretch=�6|    � ColumnDefinitions 5-      �� 5.       � RowDefinitions 50      �� 51      .+�53      � 
�������$��Center=�6&   $	��Top=�6C   $	��595��6[   $	��190��6h    54      �� 55      �� 56      �� 57      .+�5:      �� $��0��6   $��30��6,   $��Center=�68   $	��Top=�6U   $��Medium"�6m   $��13(�6�   $��10q�6�   $��Ikonica��6�   �� 5;      $��1��6   $��30��6,   $��Center=�68   $	��Top=�6U   $��10q�6m   $��Medium"�6y   $��13(�6�   $��Oznaka��6�   6�   �� 5<      $��2��6   $��30��6,   $��Center=�68   $	��Top=�6U   $��10q�6m   $��Medium"�6y   $��13(�6�   $��Naziv��6�   6�   �� 5=      -   5        $��listViewMapa��5=      $	��565��6/   $	��190��6<   $��Center=�6H   $��Center=�6e   $��
0,30,0.4,0q�6�   $ 0.728,0.493&�6�   $��3��6�   ��6�   �� *	spomenici+��5?      �� 5@      .R�5A      � $��50��6(   .+�5C   "   �� .��5E   &   �� $��50��6M   $��50��6Y   ��6,   �� *spomenikpath+6f   5F   #   �� 5G   "   $��	         ��6,   6?   �� 5H   "   $��50��6(   $��Center=�64   .��5I   &   �� $��Center=�60   $��10q�6K   $��15(�6W   $��Center=�6e   $��Medium"�6�   ��6�   ��  �� Path$ oznakaSpomenik�6�   5J   #   �� 5K   "   $��              ��6,   6D   �� 5L   "   $��50��6(   $��Center=�64   .��5M   &   �� $��Center=�60   $��10q�6K   $��Center=�6W   $��15(�6t   $��Medium"�6�   ��6�   �� $ nazivSpomenik�6�   5O   #   5Q      5R      5V      5W      5\      �� 5a   
   $��72��6   $	��Top=�6!   $��Stretch=�66   $��Stretch=�6T   ���#2aa2a2$��-219.2,0,-0.4,0q�6�   .+�5b      � $��Stretch=�6   $	��Top=�61   $��64��6I   $��0,0.4,-5.6,0q�6U   ���#2aa2a2$
��1540��6�    5c      �� 5d      $	��220��6'   �� 5e      $	��275��6'   �� 5f      $	��275��6'   �� 5h      $	��275��6'   �� 5i      $	��275��6'   �� 5j      $	��220��6'    5l      �� 5m      $��55 �6$   .+�5p      �� -   5        
������� � ToolTip$$ Tabelarni prikaz svih entiteta��5p   0   $��cmd:Mnemonic.Pregled��6Y   $��Medium"�6x   $��0��6�   $��20(�6�   
���   �$��2q�6�   $��56��6�   $	��275��6�   $��Center=�6�   $��1��6  .��6.  	Pregled5t      &   Xceed.Wpf.Toolkit.DropDownButton  5u      -   5        $	��275��5u   &   $��2��62   $' !Dodavanje novih entiteta u sistem��6B   $��20(�6n   $��Dodaj��6|   
���   �$��2q�6�   $��56��6�   $��Medium"�6�   $��Center=�6�      DropDownContent 5v      �� 5w      $	��220��6%   .+�5x      m� -	   5        $��Spomenik��5x   '   $ Prečica: Ctrl + S��69   6V   m� 5y      -
   5        $	��Tip��5y   '   $ Prečica: Ctrl + T��64   6h   m� 5z      -   5        $��Etiketa��5z   '   $ Prečica: Ctrl + E��68   6q   5{      5�      �� 5�      -   5        $��Pomoć��5�      $ Korisničko uputstvo��6)   $��cmd:Mnemonic.Pomoc��6G   *   $hci_projekat.HelpSystem.HelpProvider   HelpKey$ Pomoc��6d   $��Medium"�6�   $��0��6�   $��Center=�6�   $��3��6�   
���   �$��2q�6�   $	��275��6�   $��Center=�6  $��20(�6   $��56��6.  6S  �� 5�      -   5        $��Medium"�5�      $��20(�6<   $��4��6J   $��Center=�6Z   $	��Top=�6w   $��0��6�   
���   �$	��275��6�   $��56��6�   $��2��6�   $��0,0,218,-0.8q�6�   .��6�   Odjava6�   5�      5�      �� 5�   
   $��Right=�6   $	��209��6,   ���#2aa2a2$��0,0,0,-135.4q�6M   5�      �� 5�   
   -   5        $��canvas��5�   &   $	��Top=�6   $��Center=�65   $	��650��6P   $
��1102��6]   $��Center=�6j    J� 	AllowDrop . $��1.8,26q�6�   ��5�      �� 5�       �� ImageSource$ Prozori/mapa.png��6   6>   5�      5�      5�      