   M S B A M L   `   `   `  ����G  Chci_projekat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:hci_projekathci_projekat  5   	       hci_projekat.Logging   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:hci_projekat     5   	     � Title$  	Logovanje��5   	    � WindowStartupLocation$ CenterScreen=�6D    � WindowState$ 	Maximized=�6i    � WindowStyle$
 None=�6�   ��6   �� *y+��60   �� *x+.��5	      � $��0,-7,-0.4,-4.2q�6   ��5
   
   �� 5       �� ImageSource$ Prozori/mapa.png��6    �� Opacity$
 0.35Q�68   6I    � RowDefinitions 5   
   �� 5      $	��95* �6   �� 5      $
��291* �6   �� 5      $
��154* �6    � ColumnDefinitions 5   
   �� 5      $
��214* �6   �� 5      $
��320* �6   �� 5      $
��227* �6   .+�5   
   �� $��Center=�6   $��75.6,44.8,58.4,202.4q�6/   $��Center=�6M   $��Bookman Header)�6j   $��23(�6�   $��DemiBold"�6�   $	��186��6�   $��44��6�   $��1��6�   $��1��6�   �� 6�   $	�   ��6�   �� 6�   $�Korisničko ime:��6�   6  �� 5   
   -   5        $��korisnickoPrijava��5   c    � ToolTip$O IUneti korisničko ime koje je korišćeno prilikom registracije na sistem��6   $��1��6|   $��48.6,78.8,41.4,177.4q�6�   $��35��6�   $��Center=�6�   $	��230��6�   $��Center=�6�   $��1��6�   
����ح�$��3q�6  �� 5   
   $��1��6   $��1��6$   $��Center=�61   $��Center=�6M   $��Bookman Header)�6j   $��23(�6�   $��DemiBold"�6�   $��30��6�   $	��186��6�   $��        Lozinka:��6�   $��75.6,131.8,58.4,129.4q�6�   �� 5   
   -   5        $��lozinkaPrijava��5   i   $G AUneti lozinku koja je korišćena prilikom registracije na sistem��6   $��1��6\   $��Center=�6   $��Center=�6�   $	��230��6�   $��35��6�   $��1��6�   $��46.6,166.8,43.4,89.4q�6�   
����ح�$��3q�6  �� 5    
   -   5        $��1��5       $��1��6!   $��Center=�6.   $��Center=�6I   $��Italic$�6f   $��Bookman Header)�6y   $��20(�6�   $��DemiBold"�6�   $	��124��6�   $��99.6,244.8,96.4,14.4q�6�   $��32��6�   .��6  
Prijavi se6  �� 5"   
   $��2��6   $��15(�6!   $��Center=�6/   $��Center=�6L   $	��299��6h   $��20��6t   $��1��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   z�5#      V� 5$      .~�5%      �� �� 5&      �� 5'      
 �� Angle$
 -0.003Q�6&   T� 5(      5)      Ukoliko niste korisnik, �� 5,      -   5        $��Prozori/Registracija.xaml?�5,      .�6P   �5-   	   �� 5.      $�Registrujte��6   .�5/      50      	 se ovde.52      56      57      