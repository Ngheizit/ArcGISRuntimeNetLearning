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

namespace AddLayersToMap
{
    /// <summary>
    /// Provides map data to an application
    /// </summary>
    public class MapViewModel : INotifyPropertyChanged
    {
        public MapViewModel()
        {
            // 3. Display the new map in app
            this.CreateNewMap();
        }

        private FeatureLayer GetFeatureLayerFromUrl(string url)
        { return new FeatureLayer(new Uri(url)); }
        

        // 1. Create a new map with an imagery basemap
        private async void CreateNewMap()
        {
            Map pMap = new Map(Basemap.CreateImagery());

            // 2. Create a new map layer
                // �й�������Ԫ - ��״
            FeatureLayer pFeatureLayer_CH_Boundary_poly = GetFeatureLayerFromUrl("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/arcgis/rest/services/�й�ʡ��������Ԫ/FeatureServer/0");
                // �й��������� - ��״
            FeatureLayer pFeatureLayer_CH_Boundary_arc = GetFeatureLayerFromUrl("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/�й���������/FeatureServer/0");
                // �й��������� - ��״
            FeatureLayer pFeatureLayer_CH_Admin_pt = GetFeatureLayerFromUrl("https://services9.arcgis.com/8vu5jgpRPi7NCKmE/ArcGIS/rest/services/�й�ʡ����������/FeatureServer/0");

            // �첽����ͼ�㲢�ȴ������
            await pFeatureLayer_CH_Boundary_poly.LoadAsync();
            await pFeatureLayer_CH_Boundary_arc.LoadAsync();
            await pFeatureLayer_CH_Admin_pt.LoadAsync();

            // ��ͼ����ӵ���ͼ�Ĳ���ͼ�㼯����
            pMap.OperationalLayers.Add(pFeatureLayer_CH_Boundary_poly);
            pMap.OperationalLayers.Add(pFeatureLayer_CH_Boundary_arc);
            pMap.OperationalLayers.Add(pFeatureLayer_CH_Admin_pt);

            // ����ͼ�ĳ�ʼ����ʾ����ViewPoint������Ϊ���ͼ����Ҫ�صķ�Χ
            pMap.InitialViewpoint = new Viewpoint(pFeatureLayer_CH_Boundary_poly.FullExtent);

            // ���µ�ͼ
            this.Map = pMap;
        }
        
        





        // --------------------------------------------------------------

        private Map _map = new Map(Basemap.CreateStreets());

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
