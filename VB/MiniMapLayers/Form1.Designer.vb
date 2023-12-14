Namespace MiniMapLayers

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

'#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim imageTilesLayer1 As DevExpress.XtraMap.ImageTilesLayer = New DevExpress.XtraMap.ImageTilesLayer()
            Dim bingMapDataProvider1 As DevExpress.XtraMap.BingMapDataProvider = New DevExpress.XtraMap.BingMapDataProvider()
            Dim colorListLegend1 As DevExpress.XtraMap.ColorListLegend = New DevExpress.XtraMap.ColorListLegend()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MiniMapLayers.Form1))
            Me.mapControl = New DevExpress.XtraMap.MapControl()
            Me.imageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
            CType((Me.mapControl), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.imageCollection1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' mapControl
            ' 
            Me.mapControl.CenterPoint = New DevExpress.XtraMap.GeoPoint(-33R, 150R)
            Me.mapControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.mapControl.ImageList = Me.imageCollection1
            bingMapDataProvider1.BingKey = "Your Bing Key Here"
            imageTilesLayer1.DataProvider = bingMapDataProvider1
            Me.mapControl.Layers.Add(imageTilesLayer1)
            Me.mapControl.Legends.Add(colorListLegend1)
            Me.mapControl.Location = New System.Drawing.Point(0, 0)
            Me.mapControl.Name = "mapControl"
            Me.mapControl.Size = New System.Drawing.Size(784, 561)
            Me.mapControl.TabIndex = 0
            Me.mapControl.ZoomLevel = 6R
            ' 
            ' imageCollection1
            ' 
            Me.imageCollection1.ImageSize = New System.Drawing.Size(40, 40)
            Me.imageCollection1.ImageStream = CType((resources.GetObject("imageCollection1.ImageStream")), DevExpress.Utils.ImageCollectionStreamer)
            Me.imageCollection1.Images.SetKeyName(0, "Ship.png")
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.mapControl)
            Me.Name = "Form1"
            Me.Text = "Form1"
            AddHandler Me.Load, New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.mapControl), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.imageCollection1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

'#End Region
        Private mapControl As DevExpress.XtraMap.MapControl

        Private imageCollection1 As DevExpress.Utils.ImageCollection
    End Class
End Namespace
