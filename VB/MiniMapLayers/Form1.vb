Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraMap

Namespace MiniMapLayers
    Partial Public Class Form1
        Inherits Form

        Private Const dataFilepath As String = "../../Data/Ships.xml"
        Private Const imageFilepath As String = "../../Images/Ship.png"
        Private Const bingKey As String = "Your Bing Key Here"

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Function LoadData(ByVal path As String) As Object
            Dim ds As New DataSet()
            ds.ReadXml(path)
            Dim table As DataTable = ds.Tables(0)
            Return table
        End Function

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            #Region "#AssignToolTipController"
            Dim data As Object = LoadData(dataFilepath)
            mapControl.ToolTipController = New ToolTipController() With {.AllowHtmlText = True}
'            #End Region ' #AssignToolTipController

'            #Region "#AssignImageList"
            mapControl.ImageList = CreateImageList()
'            #End Region ' #AssignImageList

'            #Region "#AddLayer"
            mapControl.Layers.Add(CreateVectorLayer(data))
'            #End Region ' #AddLayer

'            #Region "#AssignMiniMap"
            mapControl.MiniMap = CreateMiniMap(data)
'            #End Region ' #AssignMiniMap

'            #Region "#AddLegend"
            mapControl.Legends.Add(CreateLegend())
'            #End Region ' #AddLegend
        End Sub

        #Region "#ImageCollection"
        Private Function CreateImageList() As Object
            Dim collection As New ImageCollection() With {.ImageSize = New Size(40, 40)}
            collection.Images.Add(New Bitmap(imageFilepath))
            Return collection
        End Function
        #End Region ' #ImageCollection

        #Region "#ColorListLegend"
        Private Function CreateLegend() As MapLegendBase
            Dim legend As New ColorListLegend() With {.ImageList = mapControl.ImageList, .Alignment = LegendAlignment.TopRight}
            legend.CustomItems.Add(New ColorLegendItem() With {.ImageIndex = 0, .Text = "Shipwreck Location"})
            Return legend
        End Function
        #End Region ' #ColorListLegend

        #Region "#MiniMap"
        Private Function CreateMiniMap(ByVal data As Object) As MiniMap

            Dim miniMap As New MiniMap() With { _
                .Height = 200, .Width = 300, .Behavior = New FixedMiniMapBehavior() With {.CenterPoint = New GeoPoint(-35, 140), .ZoomLevel = 3} _
            }

            Dim mapLayer As New MiniMapImageTilesLayer() With { _
                .DataProvider = New BingMapDataProvider() With {.BingKey = bingKey, .Kind = BingMapKind.Area} _
            }

            Dim vectorLayer As New MiniMapVectorItemsLayer()
            Dim adapter As New ListSourceDataAdapter()
            adapter.DataSource = data
            adapter.Mappings.Latitude = "Latitude"
            adapter.Mappings.Longitude = "Longitude"
            adapter.DefaultMapItemType = MapItemType.Dot
            adapter.PropertyMappings.Add(New MapDotSizeMapping() With {.DefaultValue = 10})
            vectorLayer.Data = adapter
            vectorLayer.ItemStyle.Fill = Color.FromArgb(74, 212, 255)
            vectorLayer.ItemStyle.Stroke = Color.Gray

            miniMap.Layers.Add(mapLayer)
            miniMap.Layers.Add(vectorLayer)
            Return miniMap
        End Function
        #End Region ' #MiniMap

        #Region "#VectorItemsLayer"
        Private Function CreateVectorLayer(ByVal data As Object) As LayerBase
            Dim adapter As New ListSourceDataAdapter() With {.DataSource = data, .DefaultMapItemType = MapItemType.Custom}
            adapter.Mappings.Latitude = "Latitude"
            adapter.Mappings.Longitude = "Longitude"

            adapter.AttributeMappings.Add(New MapItemAttributeMapping() With {.Name = "Name", .Member = "Name"})
            adapter.AttributeMappings.Add(New MapItemAttributeMapping() With {.Name = "Year", .Member = "Year"})
            adapter.AttributeMappings.Add(New MapItemAttributeMapping() With {.Name = "Description", .Member = "Description"})

            Dim layer As New VectorItemsLayer() With {.Data = adapter, .ItemImageIndex = 0, .EnableSelection = False, .EnableHighlighting = False, .ToolTipPattern = "<b>{Name} ({Year})</b>" & ControlChars.Lf & "{Description}"}
            Return layer
        End Function
        #End Region ' #VectorItemsLayer
    End Class
End Namespace
