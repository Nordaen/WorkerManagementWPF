   M S B A M L   `   `   `  ����F  BTestTaskWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestTaskWPFTestTaskWPF  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	   7 clr-namespace:TestTaskWPF.CommonTestTaskWPF.Common  5
   	       TestTaskWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TestTaskWPF     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   E ADragablz, Version=0.0.3.203, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5   	   0sys&clr-namespace:System;assembly=mscorlib  5	   	   -local1 clr-namespace:TestTaskWPF.Common  5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Worker Management��5   	   $	��800��6#   $
��1600��60    � 	Resources 5      +   %TestTaskWPF.Common.DateToAgeConverter  	DateToAge��%   &	         5   
   6$   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5!   
   c� $��0��6   $��0��6   .@�5"      �� $��18��6   $��Center=�6$   $��5,0,5,0q�6A   
Filters:6\   �� 5#      $��60��5$      $��30��6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��67   ��5#      �� *
NameFilter+ �� UpdateSourceTrigger$ PropertyChanged=�5$   7   �� 5%      $��60��5&      $��30��6+   $ Position��67   ��5%      �� *PositionFilter+$ PropertyChanged=�5&   7   �� 5(      �� 5)       � ToolTip$ 
Add filter��6<   $��
5, 0, 5, 0q�6Q   ��6   �� *ApplyWorkerFilters+.��5*      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Check=�6*   5+      �� 5,      $ Remove filter��6=   $��
5, 0, 5, 0q�6U   ��6   �� *RemoveWorkerFilters+.��5-        $	 Close=�6*   5.      �� 5/      $ 
Add worker��6=   $��
5, 0, 5, 0q�6R   ��6   �� *OpenAddWorkerDialog+.��50        $
	 Plus=�6*   51      �� 52      $��
5, 0, 5, 0q�66   $ Delete worker��6J   ��6   �� *RemoveWorker+.��53        $	 Delete=�6*   54      �� 55      $��
5, 0, 5, 0q�6>   $ 
ChangeWork��6R   ��6   �� *OpenChangeWorkDialog+.��56        $	 AccountConvert=�6*   57      58      &   System.Windows.Controls.DataGrid  5:   
   -   5        
  Name$
 	RolesGrid��5:   @    %� IsVirtualizing . $��1��6S   $��0��6`      AutoGenerateColumns .     CanUserResizeColumns .    CanUserSortColumns . $��Stretch=�5;   T   $��Stretch=�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      
IsReadOnly . ��5:   p   �� *WorkersCollection+$ PropertyChanged=� �� NotifyOnSourceUpdated .  �� NotifyOnTargetUpdated .  �� Mode$ TwoWay=� �� SelectedItem 5;   r   �� *SelectedWorker+   Columns 5=      4  .System.Windows.Controls.DataGridTemplateColumn  5>      ,  &System.Windows.Controls.DataGridColumn   Width$
 auto 6)      MinWidth$	 130Q�66      CellTemplate 5?      �� 5@      .R�5A      �� .+�5B   "   �� -   5        $- 'Редактировать запись��5B   )   $	��100��6_   .��5C   &     $	 SquareEditOutline=�6>   5D   #   5E      5F         CellEditingTemplate 5H      �� 5I      .R�5J      ��  �� Orientation$ 
Horizontal=�6)   $
��auto��6B   .+�5K   "   �� -   5        $��50��5K   <   $��0 0 5 0q�6J   .��5L   &     $	 Check=�6>   5M   #   �� 5N   "   -   5        $��X��5N   )   $��50��6L   5O      5P      5R        5S      $ * 6)   $	 200Q�63      Header$
 Name��6B    5T      �� 5U      .R�5V      �� $��Center=�6>   ��6(   �� *Name+6>   5W      5Y        5Z      $ * 6)   $	 200Q�63   $ Position��6B    5[      �� 5\      .R�5]      �� $��Center=�6B   ��6(   �� *
Position+6B   5^       5`      �� 5a      .R�5b      �� 
���������69   �� *
Position+$ TwoWay=�$ Explicit=�5c      5e        5f      $ * 6)   $	 200Q�63   $	 Age��6B    5g      �� 5h      .R�5i      �� $��Center=�6g   ��6(   �� *
Birthday+ �� 	Converter# [ 6g   5j      5l        5m      $ * 6)   $	 200Q�63   $ Status��6B    5n      �� 5o      .R�5p      �� $��Center=�6@   ��6(   �� *Status+6@   5q      5s      5u      5v      5x      