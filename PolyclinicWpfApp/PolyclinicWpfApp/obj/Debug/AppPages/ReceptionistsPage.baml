   M S B A M L   `   `   `  ����K  GPolyclinicWpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PolyclinicWpfApp.AppPagesPolyclinicWpfApp.AppPages  5      1    +PolyclinicWpfApp.AppPages.ReceptionistsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.8.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      5local'clr-namespace:PolyclinicWpfApp.AppPages   5        N� Title$  ReceptionistsPage��5
       N� 
Background �#FCF3E9.��5      � -   5         �Name$ MainGrid��5       � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� -   5        $	��150��5      $	��Top=�6   $
��auto��66   ���#0D969B$��2��6X   ._�5      � .+�5      �� -   5         ��Name$ ExitBtn��5      $	��150��6*   $��60��66   $��Right=�5      $��0,0,20,0q�61   ���#4EDFDE$��2q�5   +   ���#0D969B.  (MaterialDesignThemes.Wpf.ElevationAssist   	Elevation$	 Dp0=�5      .��5      �� $&�� Выйти из аккаунта��6    $��20(�5       $��
Arial Bold)�6.   ���#FCF3E9$
��Wrap=�5   5    �� TextAlignment$ Center=�5       69   5      5      5!      � 5#   
   $��1��6   $��50��6   $	��150��6.   $��Right=�6=   $	��Top=�6Y   $��0,0,20,0q�6q    � ColumnDefinitions 5$      �� 5%      �� 5&      �� 5'      .+�5*      �� -   5        $ windowHideBtn��5*      $��Right=�5+      $��0��61   ���#4EDFDE$��2q�5,   +   ���#0D969B$	 Dp0=�5.      .��50      �� $
��🗕��6   $��20(�51       $��
Arial Bold)�6.   ���#FCF3E9$	��-10q�52   5   $ Center=�53       69   54      �� 56      -   5        $ windowMaxMinBtn��56      $��Right=�57      $��1��61   ���#4EDFDE$��2q�58   +   ���#0D969B$	 Dp0=�5:      .��5=      �� $	��❑��6   $��20(�5>       $��
Arial Bold)�6.   ���#FCF3E9$	��-10q�5?   5   $ Center=�5@       69   5A      �� 5C      -   5        $ windowCloseBtn��5C      $��Right=�5D      $��2��61   ���#4EDFDE$��2q�5E   +   ���#0D969B$	 Dp0=�5G      .��5I      �� $	��✕��6   $��20(�5J       $��
Arial Bold)�6.   ���#FCF3E9$	��-10q�5K   5   $ Center=�5L       69   5M      5N      �� 5O   
   $��
20,-20,0,0q�6   $'��!Окно регистратора��6(   $��2��6A   $
��Left=�5P      $��Center=�6/   ���#FCF3E9$��
Arial Bold)�5Q   )   $��60(�6A   6Q   �� 5R   
   -   5         ��Name$ UserFullNameTB��5R      $��	20,0,0,10q�6,   $Y��SЗаполните ФИО учётной записи для отображения��6?   $��2��6s   $
��Left=�5S      $��Bottom=�6/   ���#FCF3E9$��Arial)�5T   )   $��35(�6<   6L    � 5U   
   -   5        	  �Name$	 FunctionFrame��5U      $��1��6'   ���#FCF3E9
  � NavigationUIVisibility$
 Hidden=�6b   6�   5V      5W      