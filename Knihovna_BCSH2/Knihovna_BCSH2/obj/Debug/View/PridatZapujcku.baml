   M S B A M L   `   `   `  ����  Knihovna_BCSH2#    Knihovna_BCSH2.PridatZapujcku   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $	��400��5   !   $	��300��6.     � Title  6	   �� *Title+.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $��50 �6   .+�5   
   �� $��Datum zápůjčky:��6   $��0��6+   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatumZapujckyPicker��5      $��0��62   $��	100,0,0,5q�6?      SelectedDate 6R   �� *DatumZapujcky+�� 5   
   $��Datum vrácení:��6   $��1��6*     5   
   -   5        $ DatumVraceniPicker��5      $��1��61   $��	100,0,0,5q�6>    6Q   �� *DatumVraceni+�� 5   
   $��Kniha:��6   $��2��6"   �� 5   
   -   5         ��Name$ KnihaComboBox��5      $��2��6*   $��	100,0,0,5q�67    �� DisplayMemberPath$ Nazev��5       �� SelectedValuePath$ Id��6-    �� SelectedValue 5      �� *SelectedKnihaId+��6=   �� *AvailableBooks+�� 5   
   $��Zákazník:��6   $��3��6%   �� 5   
   -   5        $ ZakaznikComboBox��5      $��3��6-   $��	100,0,0,5q�6:   $ FullName��5      $ Id��60    5      �� *SelectedZakaznikId+��6@   �� *AvailableCustomers+�� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��4��6J   $��0,10,0,0q�6W   .+�5      �� $��OK��6   $��80��6"   $��5q�6-   ��68   �� *	OkCommand+��6V   �� 	 �� RelativeSource	 �� 
 �� AncestorType$
 WindowL��� 5       $��Zrušit��6   $��80��6&   $��5q�61   ��6<   �� *CancelCommand+��6^   �� 	 �� $
 WindowL�5!      5"      5#      