   M S B A M L   `   `   `  ����   ATMSimulator"    ATMSimulator.Pages.LoginPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���� $��Center=�$��Center=�.+��� $��0, 0, 0, 10q�$
��Left=�$��14(�$
��Wrap=�$	��230��ecThe card was successfuly read. Please enter the 4 digit PIN associated with this card. (HINT: 1234)� $
��Left=�  � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto � � ColumnDefinitions �� $	��150 ��� $��80 �.+��� $��0��$��1��$	��150��$
��Left=�.+�G� -    G�Name$ PINInput��$	��150��$��30��
�������$��3q����#0099ff G� 	MaxLength$ 4��$��18(��� -    ��Name$ PINErrorLabel��$	��150��$��55��
���   �$
��Wrap=�*(Three PIN submissions attempts remaining�� .+��   �� $��50 ��� $��50 ��� $��50 � �� $��50 ��� $��50 ��� $��50 �.+��� -   $��0��$��2��$��Center=�$��40��$��3q�$��1��
 � Tag$ 1���� -   $��1��$��2��$��Center=�$��40��$��3q�$��2��$ 2���� -   $��2��$��2��$��Center=�$��40��$��3q�$��3��$ 3���� -   $��0��$��1��$��Center=�$��40��$��3q�$��4��$ 4���� -   $��1��$��1��$��Center=�$��40��$��3q�$��5��$ 5���� -   $��2��$��1��$��Center=�$��40��$��3q�$��6��$ 6���� -	   $��0��$��0��$��Center=�$��40��$��3q�$��7��$ 7���� -
   $��1��$��0��$��Center=�$��40��$��3q�$��8��$ 8���� -   $��2��$��0��$��Center=�$��40��$��3q�$��9��$ 9���� -   $��Center=�$	��140��$��40��$��3q�$��0��$ 0���� $	��100��$��1��$��1��$
��Left=�$��5 0 0 5q�.+��� -   $��75��$��40��$��0 0 0 10q�$��Center=�.���� .+��� $'��!/Pictures/Buttons/Icons/clear.jpg���� 	Backspace�� -   $��75��$��40��$��0 0 0 10q�$��Center=�.���� .+��� $'��!/Pictures/Buttons/Icons/clear.jpg���� Reset Field�� -   $��75��$��50��$��0 0 0 10q�$��Center=�.���� .+��� $(��"/Pictures/Buttons/Icons/verify.jpg���� 
Submit PIN�� -   $��75��$��40��$��0 77 0 0q�$��Center=�.���� .+��� $'��!/Pictures/Buttons/Icons/clear.jpg���� End Session