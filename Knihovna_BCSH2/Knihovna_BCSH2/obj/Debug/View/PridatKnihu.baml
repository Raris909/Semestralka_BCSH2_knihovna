   M S B A M L   `   `   `  ����I  EKnihovna_BCSH2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Knihovna_BCSH2Knihovna_BCSH2  5   	        Knihovna_BCSH2.PridatKnihu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Knihovna_BCSH2     5   	   $	��400��5   !   $	��300��6.     � Title  6	   �� *Title+.��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��50 �6   .+�5   
   �� $��Název:��6   $��0��6"   �� 5   
   -   5         ��Name$ NazevTextBox��5      $��0��6(   $��	100,0,0,5q�65   ��6H   �� *Nazev+�� 5   
   $��Autor:��6   $��1��6"   �� 5   
   -   5         ��Name$ AutorComboBox��5      $��1��6*   $��	100,0,0,5q�67    �� DisplayMemberPath$ FullName��5       �� SelectedValuePath$ Id��6(   ��6?   �� *AvailableAuthors+ �� SelectedValue 6h   �� *SelectedAutorId+�� 5   
   $��Žánr:��6   $��2��6!   �� 5   
   -   5        $ ZanrTextBox��5      $��2��6'   $��	100,0,0,5q�64   ��6G   �� *Zanr+�� 5    
   $��
Vydavatel:��6   $��3��6&   �� 5!   
   -   5        $ VydavatelTextBox��5!      $��3��6,   $��	100,0,0,5q�69   ��6L   �� *	Vydavatel+�� 5#   
   $��Rok vydání:��6   $��4��6'   �� 5$   
   -   5        $ RokVydaniTextBox��5$      $��4��6,   $��	100,0,0,5q�69   ��6L   �� *	RokVydani+�� 5&   
   $��Počet stran:��6   $��5��6(   �� 5'   
   -   5        $ PocetStranTextBox��5'      $��5��6-   $��	100,0,0,5q�6:   ��6M   �� *
PocetStran+�� 5)   
   $��Jazyk:��6   $��6��6"   �� 5*   
   -   5        $ JazykTextBox��5*      $��6��6(   $��	100,0,0,5q�65   ��6H   �� *Jazyk+�� 5,   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��8��6J   $��0,10,0,0q�6W   .+�5-      �� $��OK��6   $��80��6"   $��5q�6-   ��68   �� *	OkCommand+�� 5.      $��Zrušit��6   $��80��6&   $��5q�61   ��6<   �� *CancelCommand+5/      50      51      