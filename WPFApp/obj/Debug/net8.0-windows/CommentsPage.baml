   M S B A M L   `   `   `  ����A  =WPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFAppWPFApp  5          WPFApp.CommentsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:WPFApp     5        N� Title$  CommentPage��5	      .��5      � 
�������.+�5   
   �� -   5         ��Name$ lbBookTitle_Copy��5      
���   �$��DemiBold"�6=   $��Center=�6S   $��20(�5      $��Comments��6   ]� 5   
   $	��Top=�6   $��0,50,0,0q�6,   .+�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $��4* �6$   �� 5      $��* �6$   .+�5      �� 
����ح� �� Orientation$ Vertical=�64   $
��Left=�5      $	��400��60   .+�5      �� -   5        $��lbBookTitle��5      
���  ��$��DemiBold"�6@   $��20(�5      $��Comments��6'   �� 5      -   5        $��lbBookID��5      $��Book ID��6,   �� 5      -   5        $��	txtBookID��5      $��Stretch=�6/   $��25��5       �� 
IsReadOnly$
 True��5!      ��5      ��  �� Path$ Book.BookId� �� Mode$ OneWay=� � DataContext 5      ��  �� ElementName$ 	lvComment��$ SelectedItem�5!      �� 5"      -   5        $��lbTitle��5"      $��Title��6+   �� 5#      -   5        $��txtTitle��5#      $��Stretch=�6.   $
 True��6L   $��25��5$      ��5%      �� $ 
Book.Title�$ OneWay=� 5&      �� $ 	lvComment��$ SelectedItem��� 5(      -   5        $��lbAuthor��5(      $��Author��6,   �� 5)      -   5        $��	txtAuthor��5)      $��Stretch=�6/   $
 True��6M   $��25��5*      ��5+      �� $ Book.Author�$ OneWay=� 5,      �� $ 	lvComment��$ SelectedItem��� 5.      -	   5        $��	lbComment��5.      $��Comment��6-   �� 5/      -
   5        $��
txtComment��5/      $��Stretch=�60   $��25��50      ��51      �� $ Comments�$ OneWay=� 52      �� $ 	lvComment��$ SelectedItem��� 54      -   5        $��lbRating��54      $��Rating��6,   �� 55      -   5        $��	txtRating��55      $��Stretch=�6/   $��25��56      ��57      �� $ Rating�$ OneWay=� 58      �� $ 	lvComment��$ SelectedItem�5:      �� 5<      $��1��6   $ 
Horizontal=�6*   $
��Left=�5=      .+�5>      �� -   5        	 ��Name$	 
btnComment��5>      $��10q�61   $��80��6=   $��Comment��6H   5?      �� 5@      -   5        $	 	btnRemove��5@      $��10q�60   $��80��6<   $��Remove��6G   5A      5B      �� 5D      -   5        $��	lvComment��5D   (   $��2��6   $
��Auto��69   $
��Auto��6F   
 �� View
 5E      �� 5F      .P�5G      �� $��Book ID��6-    �� Width$	 100��6>    �� DisplayMemberBinding 5H   !   �� $ Book.BookId��� 5I      $��Title��6-   $	 200��6<    5J   !   �� $ 
Book.Title��� 5K      $��Author��6-   $	 120��6=    5L   !   �� $ Book.Author��� 5M      $��Comment��6-   $	 100��6>    5N   !   �� $ Comments��� 5O      $��Rating��6-   $	 100��6=    5P   !   �� $ Rating�5Q      5S      5U      5V      5W      5X      