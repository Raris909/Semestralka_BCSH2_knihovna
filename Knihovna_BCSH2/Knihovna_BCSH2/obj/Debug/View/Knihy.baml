   M S B A M L   `   `   `  ����I  EKnihovna_BCSH2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Knihovna_BCSH2.ViewModelKnihovna_BCSH2.ViewModel  5   	       Knihovna_BCSH2.Knihy   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Knihovna_BCSH2.ViewModel     5   	     � Title$  Knihy��5   	   $	��450��6   $	��800��6$    � DataContext 5	      -   'Knihovna_BCSH2.ViewModel.KnihyViewModel  5
   
   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��BooksDataGrid��5         AutoGenerateColumns .  $��10,10,10,50q�6D      CanUserAddRows .     
IsReadOnly .    SelectionMode$ Single=�5   <   ��6S   �� *Books+ �� SelectedItem 6q   �� *SelectedBook+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Název��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *Nazev+6N     5      $ Autor��6%   $	 * 6P   
 64   �� *	AutorId+6P     5      $ Žánr��6%   $	 * 6L   
 63   �� *Zanr+6L     5      $ 	Vydavatel��6%   $	 * 6V   
 68   �� *	Vydavatel+6V     5      $ Rok vydání��6%   $	 * 6W   
 69   �� *	RokVydani+6W     5      $ Počet stran��6%   $	 * 6Y   
 6:   �� *
PocetStran+6Y     5      $ Jazyk��6%   $	 * 6N   
 64   �� *Jazyk+6N   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��10q�6e   .+�5      �� $��Přidat��6   $��80��6&   $��5q�61   ��6<   �� *
AddCommand+�� 5      $��Upravit��6   $��80��6'   $��5q�62   ��6=   �� *EditCommand+�� 5      $��	Odstranit��6   $��80��6)   $��5q�64   ��6?   �� *DeleteCommand+�� 5      $��Zpět do hlavního menu��6   $
��Left=�65   $��5q�6P   $	��Top=�6[   ��6s   �� *BackToMenuCommand+5      5      5       