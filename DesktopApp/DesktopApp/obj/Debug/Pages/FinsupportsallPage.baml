   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:DesktopApp.PagesDesktopApp.Pages  5      )    #DesktopApp.Pages.FinsupportsallPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:DesktopApp.Pages     5        N� Title$  FinsupportsallPage��5	      .��5      � .+�5   
   ]� 
�������$��1��6'   .+�5      �� $	��Top=�6   ���#d2dcff �� Orientation$ 
Horizontal=�6C   $��35��6\   $��0,15,0,0q�6h   .+�5      �� -   5         ��Name$ 	tbFinsupp��5      $"��Финансирование��6/   $��Center=�6E   ���#727daa$
��Bold"�6u   $��10,0,0,0q�6�    � Cursor$
 Hand��5   �   5      ]� 5      $	��Top=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ FinSuppDataGrid��5         CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     
IsReadOnly . 	   AutoGenerateColumns	 .  $��5q�5      
�������$��Hidden=�6=   
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   ��  �� Path$ Finsourcecode�  5      $ Наименование��6-   $ * 6C    6M   �� $ 	Finsource�  5      $
 2019��6-   $ 60 6;    6F   �� $ Fo2019�  5      $
 2020��6-   $ 60 6;    6F   �� $ Fo2020�  5      $
 2021��6-   $ 60 6;    6F   �� $ Fo2021�  5      $
 2022��6-   $ 60 6;    6F   �� $ Fo2022�  5      $
 2023��6-   $ 60 6;    6F   �� $ Fo2023�  5      $
 2024��6-   $ 60 6;    6F   �� $ Fo2024�   RowHeaderStyle 5      �� 5        �� 
TargetType:  4System.Windows.Controls.Primitives.DataGridRowHeader"  6    .�5!      ��  �� Property � �� �� Value 5"   "   �� 5#   &   5%      5&         	CellStyle 5(      �� 5)      *  $System.Windows.Controls.DataGridCell"  6     �� Triggers 5*      P� 5+   "    P� Property �@ 
IsSelected P� Value . . �5,   &   ��  � �� �#628db76C   �� 5-   &    � ��
 �����6C   �� 5.   &    � �� �#628db76D   5/   #   51         RowStyle 53      �� 54      )  #System.Windows.Controls.DataGridRow"  6     55      P� 56   "    �@ 
IsSelected . . �57   &   ��  � �� �#628db76C   58   #   5:      5<      5=      5>      5?      5@      