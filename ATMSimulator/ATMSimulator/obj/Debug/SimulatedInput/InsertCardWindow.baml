   M S B A M L   `   `   `  ����  ATMSimulator2    ,ATMSimulator.SimulatedInput.InsertCardWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  LoginWindow��5   	   $	��242��6   $	��402��6*    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFF3F3F3��6    � Offset$ 0Q�6-   � 5	      $ 	#FFD6D6D6��6   $ 1Q�6-   5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��99* �6   �� 5      .+�5   
   �� $
��Left=�6   $
��Wrap=�6/   $��10,10,0,140q�6C   $	��372��6X   �� 6e   $���Simulate the Card Insert. Please Enter a 16 Digit Number. Then Click "Insert Card". The only valid card number input is 1234567812345678.��6i   6  �� 5   
   -   5         ��Name$ CardNumberField��5      $��10,63,10,104q�6+   $��1234567812345678��6A   $��24(�6Y   	 �� TextAlignment$	 Center=�6g   �� 5   
   -   5        $	��100��5      $��"Insert Card"��69   $��10,114,10,55q�6[   
 J� RenderTransformOrigin$
 0.768,0.957&�6q   5      5      