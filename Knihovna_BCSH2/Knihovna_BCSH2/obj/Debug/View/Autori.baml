   M S B A M L   `   `   `  ����I  EKnihovna_BCSH2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Knihovna_BCSH2.ViewModelKnihovna_BCSH2.ViewModel  5   	       Knihovna_BCSH2.Autori   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:Knihovna_BCSH2.ViewModel     5   	     � Title$  Autori��5   	   $	��450��6   $	��800��6%    � DataContext 5	      .   (Knihovna_BCSH2.ViewModel.AutoriViewModel  5
   
   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��10,10,10,50q�6O      CanUserAddRows .     
IsReadOnly .    SelectionMode$ Single=�5   <   ��5      �� *	Authors+ �� SelectedItem 5   S   �� *SelectedAuthor+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Jméno��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Jmeno+6N     5      $	 Příjmení��6%   $
 * 6T    67   �� *
Prijmeni+6T     5      $	 Datum narození��6%   $
 * 6_    6=   �� *DatumNarozeni+6_     5      $	 Země��6%   $
 * 6L    63   �� *Zeme+6L   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Bottom=�6J   $��10q�6e   .+�5      �� $��Přidat��6   $��80��6&   $��5q�61   ��6<   �� *
AddCommand+�� 5      $��Upravit��6   $��80��6'   $��5q�62   ��6=   �� *EditCommand+�� 5      $��	Odstranit��6   $��80��6)   $��5q�64   ��6?   �� *DeleteCommand+�� 5      $��Zpět do hlavního menu��6   $
��Left=�65   $��5q�6P   $	��Top=�6[   ��6s   �� *BackToMenuCommand+5      5      5      