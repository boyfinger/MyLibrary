   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5          WPFApp.BorrowPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:WPFApp     5        N� Title$  
BorrowPage��5	      .��5      � 
�������.+�5   
   �� -   5         ��Name$ lbBookTitle_Copy��5      
���   �$��DemiBold"�6=   $��Center=�6S   $��20(�5      $��Borrow book��6   ]� 5   
   $	��Top=�6   $��0,50,0,0q�6,   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��4* �6$   �� 5      $��* �6$   .+�5      �� 
����ح� �� Orientation$ Vertical=�64   $
��Left=�5      $	��400��60   .+�5      �� -   5        $��lbBookTitle��5      
���  ��$��DemiBold"�6@   $��20(�5      $��Book Information��6'   �� 5      -   5        $��lbBookID��5      $��Book ID��6,   �� 5      -   5        $��	txtBookID��5      $��Stretch=�6/   $��25��5       �� 
IsReadOnly$
 True��5!      ��5      ��  �� Path$ BookId� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ lvBook��$ SelectedItem�5!      �� 5"      -   5        $��lbTitle��5"      $��Title��6+   �� 5#      -   5        $��txtTitle��5#      $��Stretch=�6.   $
 True��6L   $��25��5$      ��5%      �� $ Title�$ OneWay=� 5&      �� $ lvBook��$ SelectedItem��� 5(      -   5        $��lbAuthor��5(      $��Author��6,   �� 5)      -   5        $��	txtAuthor��5)      $��Stretch=�6/   $
 True��6M   $��25��5*      ��5+      �� $ Author�$ OneWay=� 5,      �� $ lvBook��$ SelectedItem��� 5.      -	   5        $��lbReturnDate��5.      $��Return Date��60   (  "System.Windows.Controls.DatePicker  5/      -
   5        $��
txtDueDate��5/   !   	   SelectedDateFormat$	 Short=�50      51      52      �� 54      $��1��6   $ 
Horizontal=�6*   $
��Left=�55      .+�56      �� -   5        
 ��Name$
 	btnBorrow��56      $��10q�60   $��80��6<   $��Borrow��6G   57      �� 58      -   5        $
 
btnReserve��58      $��10q�61   $��80��6=   $��Reserve��6H   59      5:      �� 5<      -   5        $��lvBook��5<   (   $��2��6   $
��Auto��66   $
��Auto��6C    �� View 5=      �� 5>      .P�5?      �� $��Book ID��6-    �� Width$	 100��6>    �� DisplayMemberBinding 5@   !   �� $ BookId��� 5A      $��Title��6-   $	 200��6<    5B   !   �� $ Title��� 5C      $��Author��6-   $	 200��6=    5D   !   �� $ Author�5E      5G      5I      5J      5K      5L      