   M S B A M L   `   `   `  ����K  GPolyclinicWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PolyclinicWpfApp.AppPagesPolyclinicWpfApp.AppPages  5      .    (PolyclinicWpfApp.AppPages.MainDoctorPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      5local'clr-namespace:PolyclinicWpfApp.AppPages   5        N� Title$  DoctorsPage��5
       N� 
Background �#FCF3E9.��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� -   5        $	��150��5      $	��Top=�6   $
��auto��66   ���#0D969B$��2��6X   ._�5      � .+�5      �� -   5         ��Name$ ExitBtn��5      $	��150��6*   $��60��66   $��Right=�5      $��0,0,20,0q�61   ���#4EDFDE$��2q�5   +   ���#0D969B.  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp0=�5      .��5      �� $&�� Выйти из аккаунта��6    $��20(�5       $��
Arial Bold)�6.   ���#FCF3E9$
��Wrap=�5   5    �� TextAlignment$ Center=�5       69   5      5      5!      � 5#   
   $��1��6   $��50��6   $	��150��6.   $��Right=�6=   $	��Top=�6Y   $��0,0,20,0q�6q    � ColumnDefinitions 5$      �� 5%      �� 5&      �� 5'      .+�5*      �� -   5        $ windowHideBtn��5*      $��Right=�5+      $��0��61   ���#4EDFDE$��2q�5,   +   ���#0D969B$	 Dp0=�5.      .��51      �� $
��🗕��6   $��20(�52       $��
Arial Bold)�6.   ���#FCF3E9$	��-10q�53   5   $ Center=�54       69   55      �� 57      -   5        $ windowMaxMinBtn��57      $��Right=�58      $��1��61   ���#4EDFDE$��2q�59   +   ���#0D969B$	 Dp0=�5;      .��5>      �� $	��❑��6   $��20(�5?       $��
Arial Bold)�6.   ���#FCF3E9$	��-10q�5@   5   $ Center=�5A       69   5B      �� 5D      -   5        $ windowCloseBtn��5D      $��Right=�5E      $��2��61   ���#4EDFDE$��2q�5F   +   ���#0D969B$	 Dp0=�5H      .��5K      �� $	��✕��6   $��20(�5L       $��
Arial Bold)�6.   ���#FCF3E9$	��-10q�5M   5   $ Center=�5N       69   5O      5P      �� 5Q   
   $��
20,-20,0,0q�6   $!��Окно главврача��6(   $��2��6>   $
��Left=�5R      $��Center=�6/   ���#FCF3E9$��
Arial Bold)�5S   )   $��60(�6A   6Q   �� 5T   
   -   5         ��Name$ UserFullNameTB��5T      $��	20,0,0,10q�6,   $Y��SЗаполните ФИО учётной записи для отображения��6?   $��2��6s   $
��Left=�5U      $��Bottom=�6/   ���#FCF3E9$��Arial)�5V   )   $��35(�6<   6L    � 5W   
   -   5        	  �Name$	 FunctionFrame��5W      $��1��6'   ���#FCF3E9
  � NavigationUIVisibility$
 Hidden=�6b   6�   5X      5Y      