   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	        WpfApplication1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6K   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��8* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��7.71* �6   �� 5      $��1.29* �6   .+�5   
   �� -   5         ��Name$
 list��5      $��1��6    $��0��6-   5      �� 5   
   $��1��6   $��1��6"   .+�5      �� -   5         ��Name$ 	btnFields��5      .��6@   Show fields6M   �� 5      -   5        $ btnProps��5      .��6>   Show properties6O   �� 5      -   5        $ 
btnMethods��5      .��6B   Show methods6P   �� 5      -   5        $ btnAll��5      .��6:   
Show all6D   �� 5      -   5        $ btnSelectDll��5      .��6F   Sellect dll6S   5      �� 5    
   $��1��6   $��2��6%   .+�5!      �� -   5        $ btnOpen��5!      .��6<   Open6B   �� 5"      -   5        $ btnClose��5"      .��6>   Close6E   5#      �� 5%   
   -	   5         ��Name$ tboxPath��5%      $��0��6$   $��2��64   6C   �� 5&   
   -
   5         ��Name$ label��5&      $
��Left=�6   $��52,0,0,0q�6:   $	��Top=�6L   $��32��6d   $	��268��6p   5(      5)      