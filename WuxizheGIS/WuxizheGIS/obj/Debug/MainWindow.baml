   M S B A M L   `   `   `  ����  
WuxizheGIS    WuxizheGIS.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   c _DevExpress.Xpf.Ribbon.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   [ WEsri.ArcGISRuntime, Version=100.6.0.0, Culture=neutral, PublicKeyToken=8fc3cc631e44ad866esri+http://schemas.esri.com/arcgis/runtime/2013  5   	   -   5          � Title$  希浙的GIS平台��5	   	   $	��683��6   $
��1118��6'   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   )  #DevExpress.Xpf.Ribbon.RibbonControl  $��0��6      RibbonStyle$ 
Office2010=�6)      ToolbarItems 5      +  %DevExpress.Xpf.Bars.BarButtonItemLink  5      )  #DevExpress.Xpf.Bars.BarItemLinkBase   BarItemName$ newItem��6(      Items. 5      5  /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2  ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Pages. 5      &   DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$ 开始 6!      Groups. 5      +  %DevExpress.Xpf.Ribbon.RibbonPageGroup  	   Caption$	 图层��6*   
   Items.
 5      '	  !DevExpress.Xpf.Bars.BarButtonItem	  -   5         	 Name$ btn_SelectBasemap��5   ,   !
  DevExpress.Xpf.Bars.BarItem 
  Content$ 新建底图 6G    
  RibbonStyle$ Large=�6V    
  Glyph 6j   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ DefaultMap_32x32.png  
  
LargeGlyph 6�     $ DefaultMap_32x32.png 6�   5      5      5      5      2  ,DevExpress.Xpf.Ribbon.RibbonStatusBarControl  5   
   $��2��6%      
RightItems 5      	  5      -   5        $ 	printItem��5   $   $ Print 67    6G     $ Print_16x16.png 5       &   DevExpress.Xpf.Core.DXTabControl  5!   
   $��1��6   .@�5"      #  DevExpress.Xpf.Core.DXTabItem  �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v18.1, Version=18.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ 二维视图��6   .��5#      ,  &Esri.ArcGISRuntime.UI.Controls.MapView  -   5          Name$ 	AxMapView��5#      $��-12,-12,-12,-12q�62   5$        5%      $ 三维视图��6   .��5&      .  (Esri.ArcGISRuntime.UI.Controls.SceneView  $��-12,-12,-12,-12q�6!   5'      5(      5)      5*      