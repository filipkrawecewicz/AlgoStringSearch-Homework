   M S B A M L   `   `   `  ����G  CStringSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:StringSearchStringSearch  5   	       StringSearch.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:StringSearch     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � ���	#FFCCCCCC � RowDefinitions 5
   
   �� 5      $	��44* �6   �� 5      $
��173* �6   .+�5   
   �� -   5         ��Name$ BruteLbl��5      $��--��6"   $
��Left=�6/   $��
400,54,0,0q�6J   $	��Top=�6^   $��35��6v   $��1��6�   �� 5   
   -   5         ��Name$ 	SearchBtn��5      $��Search��6$   $
��Left=�65   $��
538,88,0,0q�6P   $	��Top=�6d   $��30��6�   $	��110��6�   ���	#FF46B7FF$��16(�6�   $
��Bold"�6�   $��2��6�   �� 5   
   -   5         ��Name$ 	SearchBox��5      $
��Left=�6%   $��
107,88,0,0q�6@    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��370��6�   $��30��6�   $��16(�6�   $��Normal"�6�   $
��with��6�   $��2��6�   �� 5   
   -   5        $ AlgoLbl1��5      $��Brute Force��6"   $
��Left=�68   $��
112,54,0,0q�6S   $	��Top=�6g   $��35��6   $��96��6�   $��16(�6�   $
��Bold"�6�   $��1��6�   �� 5   
   -   5        $ AlgoLbl2��5      $	��KMP��6"   $
��Left=�60   $��113,112,0,0q�6K   $	��Top=�6`   $��78��6x   $��16(�6�   $
��Bold"�6�   $��1��6�   $��34��6�   �� 5   
   -   5        $ KMPLbl��5      $��--��6    $
��Left=�6-   $��400,116,0,0q�6H   $	��Top=�6]   $��1��6u    J� RenderTransformOrigin$ 0.766,0.644&�6�   $��29��6�   �� 5   
   -   5        $ AlgoLbl3��5      $��Boyer-Moore��6"   $
��Left=�68   $��113,169,0,0q�6S   $	��Top=�6h   $��16(�6�   $
��Bold"�6�   $��1��6�   $��34��6�   �� 5   
   -   5        $ BMLbl��5      $��--��6   $
��Left=�6,   $��400,174,0,0q�6G   $	��Top=�6\   $��1��6t   $��29��6�   �� 5   
   -	   5        $ AlgoLbl4��5      $��
Rabin-Karp��6"   $
��Left=�67   $��112,223,0,0q�6R   $	��Top=�6g   $��16(�6   $
��Bold"�6�   $��1��6�   $��34��6�   �� 5   
   $��Type your search here:��6   $
��Left=�61   $��
107,60,0,0q�6L   $��28��6`   $	��Top=�6l   �� 5   
   $��Search String Program��6   $
��Left=�60   $��
107,10,0,0q�6K   $	��Top=�6_   $��22(�6w   $��Arial Black)�6�   �� 5   
   -
   5        $ RKLbl��5      $��--��6   $
��Left=�6,   $��400,227,0,0q�6G   $��1��6\   $	��Top=�6i   5      5      