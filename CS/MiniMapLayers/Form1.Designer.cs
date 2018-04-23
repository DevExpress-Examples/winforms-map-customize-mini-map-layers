namespace MiniMapLayers {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            DevExpress.XtraMap.ColorListLegend colorListLegend1 = new DevExpress.XtraMap.ColorListLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mapControl = new DevExpress.XtraMap.MapControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl
            // 
            this.mapControl.CenterPoint = new DevExpress.XtraMap.GeoPoint(-33D, 150D);
            this.mapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl.ImageList = this.imageCollection1;
            bingMapDataProvider1.BingKey = "Your Bing Key Here";
            imageTilesLayer1.DataProvider = bingMapDataProvider1;
            this.mapControl.Layers.Add(imageTilesLayer1);
            this.mapControl.Legends.Add(colorListLegend1);
            this.mapControl.Location = new System.Drawing.Point(0, 0);
            this.mapControl.Name = "mapControl";
            this.mapControl.Size = new System.Drawing.Size(784, 561);
            this.mapControl.TabIndex = 0;
            this.mapControl.ZoomLevel = 6D;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(40, 40);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Ship.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mapControl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}

