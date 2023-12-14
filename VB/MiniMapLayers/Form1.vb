Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Utils
Imports DevExpress.XtraMap

Namespace MiniMapLayers

    Public Partial Class Form1
        Inherits System.Windows.Forms.Form

        Const dataFilepath As String = "../../Data/Ships.xml"

        Const imageFilepath As String = "../../Images/Ship.png"

        Const bingKey As String = "Your Bing Key Here"

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Function LoadData(ByVal path As String) As Object
            Dim ds As System.Data.DataSet = New System.Data.DataSet()
            ds.ReadXml(path)
            Dim table As System.Data.DataTable = ds.Tables(0)
            Return table
        End Function

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs)
'#Region "#AssignToolTipController"
            Dim data As Object = Me.LoadData(MiniMapLayers.Form1.dataFilepath)
            Me.mapControl.ToolTipController = New DevExpress.Utils.ToolTipController() With {.AllowHtmlText = True}
'#End Region  ' #AssignToolTipController
'#Region "#AssignImageList"
            Me.mapControl.ImageList = Me.CreateImageList()
'#End Region  ' #AssignImageList
'#Region "#AddLayer"
            Me.mapControl.Layers.Add(Me.CreateVectorLayer(data))
'#End Region  ' #AddLayer
'#Region "#AssignMiniMap"
            Me.mapControl.MiniMap = Me.CreateMiniMap(data)
'#End Region  ' #AssignMiniMap
'#Region "#AddLegend"
            Me.mapControl.Legends.Add(Me.CreateLegend())
'#End Region  ' #AddLegend
        End Sub

'#Region "#ImageCollection"
        Private Function CreateImageList() As Object
            Dim collection As DevExpress.Utils.ImageCollection = New DevExpress.Utils.ImageCollection() With {.ImageSize = New System.Drawing.Size(40, 40)}
            collection.Images.Add(New System.Drawing.Bitmap(MiniMapLayers.Form1.imageFilepath))
            Return collection
        End Function

'#End Region  ' #ImageCollection
'#Region "#ColorListLegend"
        Private Function CreateLegend() As MapLegendBase
            Dim legend As DevExpress.XtraMap.ColorListLegend = New DevExpress.XtraMap.ColorListLegend() With {.ImageList = Me.mapControl.ImageList, .Alignment = DevExpress.XtraMap.LegendAlignment.TopRight}
            legend.CustomItems.Add(New DevExpress.XtraMap.ColorLegendItem() With {.ImageIndex = 0, .Text = "Shipwreck Location"})
            Return legend
        End Function

'#End Region  ' #ColorListLegend
'#Region "#MiniMap"
        Private Function CreateMiniMap(ByVal data As Object) As MiniMap
            Dim miniMap As DevExpress.XtraMap.MiniMap = New DevExpress.XtraMap.MiniMap() With {.Height = 200, .Width = 300, .Behavior = New DevExpress.XtraMap.FixedMiniMapBehavior() With {.CenterPoint = New DevExpress.XtraMap.GeoPoint(-35, 140), .ZoomLevel = 3}}
            Dim mapLayer As DevExpress.XtraMap.MiniMapImageTilesLayer = New DevExpress.XtraMap.MiniMapImageTilesLayer() With {.DataProvider = New DevExpress.XtraMap.BingMapDataProvider() With {.BingKey = MiniMapLayers.Form1.bingKey, .Kind = DevExpress.XtraMap.BingMapKind.Area}}
            Dim vectorLayer As DevExpress.XtraMap.MiniMapVectorItemsLayer = New DevExpress.XtraMap.MiniMapVectorItemsLayer()
            Dim adapter As DevExpress.XtraMap.ListSourceDataAdapter = New DevExpress.XtraMap.ListSourceDataAdapter()
            adapter.DataSource = data
            adapter.Mappings.Latitude = "Latitude"
            adapter.Mappings.Longitude = "Longitude"
            adapter.DefaultMapItemType = DevExpress.XtraMap.MapItemType.Dot
            adapter.PropertyMappings.Add(New DevExpress.XtraMap.MapDotSizeMapping() With {.DefaultValue = 10})
            vectorLayer.Data = adapter
            vectorLayer.ItemStyle.Fill = System.Drawing.Color.FromArgb(74, 212, 255)
            vectorLayer.ItemStyle.Stroke = System.Drawing.Color.Gray
            miniMap.Layers.Add(mapLayer)
            miniMap.Layers.Add(vectorLayer)
            Return miniMap
        End Function

'#End Region  ' #MiniMap
'#Region "#VectorItemsLayer"
        Private Function CreateVectorLayer(ByVal data As Object) As LayerBase
            Dim adapter As DevExpress.XtraMap.ListSourceDataAdapter = New DevExpress.XtraMap.ListSourceDataAdapter() With {.DataSource = data, .DefaultMapItemType = DevExpress.XtraMap.MapItemType.Custom}
            adapter.Mappings.Latitude = "Latitude"
            adapter.Mappings.Longitude = "Longitude"
            adapter.AttributeMappings.Add(New DevExpress.XtraMap.MapItemAttributeMapping() With {.Name = "Name", .Member = "Name"})
            adapter.AttributeMappings.Add(New DevExpress.XtraMap.MapItemAttributeMapping() With {.Name = "Year", .Member = "Year"})
            adapter.AttributeMappings.Add(New DevExpress.XtraMap.MapItemAttributeMapping() With {.Name = "Description", .Member = "Description"})
            Dim layer As DevExpress.XtraMap.VectorItemsLayer = New DevExpress.XtraMap.VectorItemsLayer() With {.Data = adapter, .ItemImageIndex = 0, .EnableSelection = False, .EnableHighlighting = False, .ToolTipPattern = "<b>{Name} ({Year})</b>" & Global.Microsoft.VisualBasic.Constants.vbLf & "{Description}"}
            Return layer
        End Function
'#End Region  ' #VectorItemsLayer
    End Class
End Namespace
