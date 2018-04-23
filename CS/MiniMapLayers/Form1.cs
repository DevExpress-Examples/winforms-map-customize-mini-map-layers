using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraMap;

namespace MiniMapLayers {
    public partial class Form1 : Form {
        const string dataFilepath = "../../Data/Ships.xml";
        const string imageFilepath = "../../Images/Ship.png";
        const string bingKey = "Your Bing Key Here";

        public Form1() {
            InitializeComponent();
        }

        object LoadData(string path) {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            DataTable table = ds.Tables[0];
            return table;
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            #region #AssignToolTipController
            object data = LoadData(dataFilepath);
            mapControl.ToolTipController = new ToolTipController() {
                AllowHtmlText = true
            };
            #endregion #AssignToolTipController

            #region #AssignImageList
            mapControl.ImageList = CreateImageList();
            #endregion #AssignImageList

            #region #AddLayer
            mapControl.Layers.Add(CreateVectorLayer(data));
            #endregion #AddLayer

            #region #AssignMiniMap
            mapControl.MiniMap = CreateMiniMap(data);
            #endregion #AssignMiniMap

            #region #AddLegend
            mapControl.Legends.Add(CreateLegend());
            #endregion #AddLegend
        }

        #region #ImageCollection
        object CreateImageList() {
            ImageCollection collection = new ImageCollection() {
                ImageSize = new Size(40, 40)
            };
            collection.Images.Add(new Bitmap(imageFilepath));
            return collection;
        }
        #endregion #ImageCollection
        
        #region #ColorListLegend
        MapLegendBase CreateLegend() {
            ColorListLegend legend = new ColorListLegend() {
                ImageList = mapControl.ImageList,
                Alignment = LegendAlignment.TopRight
            };
            legend.CustomItems.Add(new ColorLegendItem() {
                ImageIndex = 0,
                Text = "Shipwreck Location"
            });
            return legend;
        }
        #endregion #ColorListLegend

        #region #MiniMap
        MiniMap CreateMiniMap(object data) {
            
            MiniMap miniMap = new MiniMap() {
                Height = 200,
                Width = 300,
                Behavior = new FixedMiniMapBehavior() {
                    CenterPoint = new GeoPoint(-35, 140),
                    ZoomLevel = 3
                }
            };

            MiniMapImageTilesLayer mapLayer = new MiniMapImageTilesLayer() {
                DataProvider = new BingMapDataProvider() {
                    BingKey = bingKey,
                    Kind = BingMapKind.Area
                }
            };

            MiniMapVectorItemsLayer vectorLayer = new MiniMapVectorItemsLayer();
            ListSourceDataAdapter adapter = new ListSourceDataAdapter();
            adapter.DataSource = data;
            adapter.Mappings.Latitude = "Latitude";
            adapter.Mappings.Longitude = "Longitude";
            adapter.DefaultMapItemType = MapItemType.Dot;
            adapter.PropertyMappings.Add(
                new MapDotSizeMapping() { DefaultValue = 10 }
            );
            vectorLayer.Data = adapter;
            vectorLayer.ItemStyle.Fill = Color.FromArgb(74, 212, 255);
            vectorLayer.ItemStyle.Stroke = Color.Gray;

            miniMap.Layers.Add(mapLayer);
            miniMap.Layers.Add(vectorLayer);
            return miniMap;
        }
        #endregion #MiniMap

        #region #VectorItemsLayer
        LayerBase CreateVectorLayer(object data) {
            ListSourceDataAdapter adapter = new ListSourceDataAdapter() {
                DataSource = data,
                DefaultMapItemType = MapItemType.Custom
            };
            adapter.Mappings.Latitude = "Latitude";
            adapter.Mappings.Longitude = "Longitude";

            adapter.AttributeMappings.Add(new MapItemAttributeMapping() {Name = "Name", Member = "Name"});
            adapter.AttributeMappings.Add(new MapItemAttributeMapping() {Name = "Year", Member = "Year"});
            adapter.AttributeMappings.Add(new MapItemAttributeMapping() {Name = "Description", Member = "Description"});

            VectorItemsLayer layer = new VectorItemsLayer() {
                Data = adapter,
                ItemImageIndex = 0,
                EnableSelection = false,
                EnableHighlighting = false,
                ToolTipPattern = "<b>{Name} ({Year})</b>\n{Description}"
            };
            return layer;
        }
        #endregion #VectorItemsLayer
    }
}
