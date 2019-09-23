using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Security;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.UI;

namespace StyleFeatureLayers
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
            AddFeatureLayer(CreateSymbolizedFeatureLayer_byPictureMarker());
            AddFeatureLayer(CreateSymbolizedFeatureLayer_byUniqueValues());
            AddFeatureLayer(CreateSymboliaedFeatureLayer_byNumericValue());
        }


        private Map _map = new Map(Basemap.CreateStreets());
        //private Map _map;

        // ��һ���Ż���ͼƬ��ǣ�
        private FeatureLayer CreateSymbolizedFeatureLayer_byPictureMarker()
        {
            // 1. ͨ������ͼƬ��Ƿ��ţ���ͼ��URL����������
                // ʹ�ñ�Ƿ��Ŵ����µļ���Ⱦ��
            string str_img = "http://static.arcgis.com/images/Symbols/NPS/npsPictograph_0231b.png";
            var imageUrl = new Uri(str_img);
            PictureMarkerSymbol pPictureFillSymbol = new PictureMarkerSymbol(imageUrl);
            SimpleRenderer pSimpleRenderer = new SimpleRenderer(pPictureFillSymbol);

            // 2. ����FeatureLayer,Ӧ����Ⱦ��������ͼ��
            string str_featureLayer_url = "https://services3.arcgis.com/GVgbJbqm8hXASVYi/arcgis/rest/services/Trailheads/FeatureServer/0";
            var url_featureLayer = new Uri(str_featureLayer_url);
            FeatureLayer pFeatureLayer = new FeatureLayer(url_featureLayer);
            pFeatureLayer.Renderer = pSimpleRenderer;
            return pFeatureLayer;
        }

        // Ψһֵ���Ż�
        private FeatureLayer CreateSymbolizedFeatureLayer_byUniqueValues()
        {
            // 1. ����UniqueValue�����Զ���ҪӦ�õ�����ֵ�ͷ���
            SimpleLineSymbol pSimpleLineSymbol_v1 = new SimpleLineSymbol(SimpleLineSymbolStyle.Dot, System.Drawing.Color.Blue, 2.0);
            SimpleLineSymbol pSimpleLineSymbol_v2 = new SimpleLineSymbol(SimpleLineSymbolStyle.Dot, System.Drawing.Color.Red, 2.0);
            UniqueValue pUniqueValue_v1 = new UniqueValue("Bike trails", "Bike", pSimpleLineSymbol_v1, "Yes");
            UniqueValue pUniqueValue_v2 = new UniqueValue("No Bike trails", "No Bike", pSimpleLineSymbol_v2, "No");

            // 2. ����һ���µ�UniqueValueRenederer���������Ҫ��Ⱦ��ָ������
            UniqueValueRenderer pUniqueValueRenderer = new UniqueValueRenderer();
            pUniqueValueRenderer.FieldNames.Add("USE_BIKE");
            pUniqueValueRenderer.UniqueValues.Add(pUniqueValue_v1);
            pUniqueValueRenderer.UniqueValues.Add(pUniqueValue_v2);

            // 3. ����FeatureLayer��Ӧ��Ψһֵ��Ⱦ��������ͼ��
            string str_featureLayer_url = "https://services3.arcgis.com/GVgbJbqm8hXASVYi/arcgis/rest/services/Trails/FeatureServer/0";
            var url_featureLayer = new Uri(str_featureLayer_url);
            FeatureLayer pFeatureLayer = new FeatureLayer(url_featureLayer);
            pFeatureLayer.Renderer = pUniqueValueRenderer;
            return pFeatureLayer;
        }

        // ��ֵ�ּ�������Ż�
        private FeatureLayer CreateSymboliaedFeatureLayer_byNumericValue()
        {
            // 1. 
            SimpleLineSymbol pSimpleLineSymbol_fillOutline = new SimpleLineSymbol(SimpleLineSymbolStyle.Solid, System.Drawing.Color.DarkGray, 0.5);
            SimpleFillSymbol pSimpleFillSymbol_c1 = new SimpleFillSymbol(SimpleFillSymbolStyle.Solid, System.Drawing.Color.FromArgb(255, 45, 128, 120), pSimpleLineSymbol_fillOutline);
            SimpleFillSymbol pSimpleFillSymbol_c2 = new SimpleFillSymbol(SimpleFillSymbolStyle.Solid, System.Drawing.Color.FromArgb(255, 173, 212, 106), pSimpleLineSymbol_fillOutline);
            SimpleFillSymbol pSimpleFillSymbol_c3 = new SimpleFillSymbol(SimpleFillSymbolStyle.Solid, System.Drawing.Color.FromArgb(255, 226, 235, 211), pSimpleLineSymbol_fillOutline);

            // 2. �����������Ϊÿ����ָ����ͬ�������ţ��ṩ�����ͱ�ǩ��������ÿ����Χ����Сֵ�����ֵ
            // ���������ӵ��б���
            ClassBreak pClassBreak_c1 = new ClassBreak("Under 1,629", "0 - 1629", 0.0, 1629.0, pSimpleFillSymbol_c1);
            ClassBreak pClassBreak_c2 = new ClassBreak("1,629 to 3,754", "1629 - 3754", 1629.0, 3754.0, pSimpleFillSymbol_c2);
            ClassBreak pClassBreak_c3 = new ClassBreak("3,754 to 11,438", "3754 - 11438", 3754.0, 11438.0, pSimpleFillSymbol_c3);
            List<ClassBreak> pClassBreakList = new List<ClassBreak> { pClassBreak_c1, pClassBreak_c2, pClassBreak_c3 };

            // 3. �������ж���Ⱦ����ͼ�㣬ָ����Ⱦ��������ͼ��
            ClassBreaksRenderer pClassBreakRenderer = new ClassBreaksRenderer("GIS_ACRES", pClassBreakList);
            string str_featureLayer = "https://services3.arcgis.com/GVgbJbqm8hXASVYi/arcgis/rest/services/Parks_and_Open_Space/FeatureServer/0";
            var url_featureLayer = new Uri(str_featureLayer);
            FeatureLayer pFeautreLayer = new FeatureLayer(url_featureLayer);
            pFeautreLayer.Renderer = pClassBreakRenderer;
            return pFeautreLayer;
        }

        private async void AddFeatureLayer(FeatureLayer featureLayer)
        {
            await featureLayer.LoadAsync();
            this.Map.OperationalLayers.Add(featureLayer);
            this.Map.InitialViewpoint = new Viewpoint(featureLayer.FullExtent);
        }

        // --------------------------------------------------------------


        /// <summary>
        /// Gets or sets the map
        /// </summary>
        public Map Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Raises the <see cref="MapViewModel.PropertyChanged" /> event
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChangedHandler = PropertyChanged;
            if (propertyChangedHandler != null)
                propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
