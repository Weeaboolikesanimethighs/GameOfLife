   M S B A M L   `   `   `  ����E  AGameOfLife, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GameOfLife
GameOfLife  5   	       GameOfLife.Window1   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GameOfLife     5   	     � Title$  	NormalGOL��5   	    � 
ResizeMode$ NoResize=�6   $	��720��61   $	��980��6>   .��5	      � .+�5
   
   �� -   5         ��Name$ startButton��5
      $��Start��6&   $	��12 (�66   $
��Left=�5      $��768,469,0,0q�6   $	��Top=�63    J� RenderTransformOrigin$ -8.481,-0.884&�6K   $��55��6q   $	��184��6}   6�   �� 5   
   -   5         ��Name$ gameArea��5      $
��Left=�6#   $	��500��6>   $	��Top=�6K   $	��700��6c   
���   �$��	29,24,0,0q�6�   �� 5   
   -   5        $ clearButton��5      $��Clear��6&   $	��12 (�66   $
��Left=�6E   $��162,575,0,0q�6`   $	��Top=�6u   $ -8.481,-0.884&�6�   $��64��6�   $	��114��6�   6�   �� 5   
   -   5        $ pauseButton��5      $��Pause��6&   $	��12 (�66   $��Center=�6E   $��	0,575,0,0q�6b   $	��Top=�6u   $ -8.481,-0.884&�6�   $��64��6�   $	��112��6�   6�   �� 5   
   -   5        $ forwardButton��5      $��Step Forward��6(   $	��12 (�6?   $
��Left=�6N   $��299,575,0,0q�6i   $	��Top=�6~   $ -8.481,-0.884&�6�   $��64��6�   $	��113��6�   6�   �� 5   
   -   5        $ 
loadButton��5      $
��Load��6%   $	��12 (�64   $��838,575,28,0q�6C   $	��Top=�6Y   $ -8.481,-0.884&�6q   $��64��6�   6�   �� 5   
   -   5        $ saveImageButton��5      $��Save as Image��6*   $	��12 (�6B   $
��Left=�6Q   $��703,575,0,0q�6l   $	��Top=�6�   $ -8.481,-0.884&�6�   $��64��6�   $	��113��6�   6�   �� 5   
   -   5        $ 
saveButton��5      $
��Save��6%   $	��12 (�64   $
��Left=�6C   $��569,575,0,0q�6^   $	��Top=�6s   $ -8.481,-0.884&�6�   $��64��6�   $	��113��6�   6�   �� 5   
   -	   5        $ randomButton��5      $��Random��6'   $	��12 (�68   $
��Left=�6G   $��
29,575,0,0q�6b   $	��Top=�6v   $ -8.481,-0.884&�6�   $��64��6�   $��113                 ��6�   6�   �� 5   
   -
   5        $��numberOfRandom��5      $
��Left=�6)   $��
29,639,0,0q�6h    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��113��6�   $��22��6�   $ 0.513,-1.18&�6�   �� 5   
   -   5         ��Name$ _94b_png��5      $
��Left=�6"   $	��168��6=   $��
760,24,0,0q�6J   $	��Top=�6^   $	��368��6v   $��94b.png��6�   5      5      