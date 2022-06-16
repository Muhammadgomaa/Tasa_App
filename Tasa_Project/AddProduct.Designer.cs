
namespace Tasa_Project
{
    partial class AddProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame2 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_top = new System.Windows.Forms.Panel();
            this.home = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.logout = new DevExpress.XtraEditors.SimpleButton();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.NumericUpDown();
            this.category = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.ComboBox();
            this.panel_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.price)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(240, 239);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(291, 37);
            this.name.TabIndex = 2;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(113)))), ((int)(((byte)(146)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(129)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(323, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 39);
            this.button1.TabIndex = 5;
            this.button1.Text = "Add Product";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.home);
            this.panel_top.Controls.Add(this.label4);
            this.panel_top.Controls.Add(this.logout);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(129)))));
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(720, 61);
            this.panel_top.TabIndex = 7;
            // 
            // home
            // 
            this.home.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.Appearance.Font = new System.Drawing.Font("Kristen ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.home.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.Appearance.Options.UseBackColor = true;
            this.home.Appearance.Options.UseBorderColor = true;
            this.home.Appearance.Options.UseFont = true;
            this.home.Appearance.Options.UseForeColor = true;
            this.home.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceDisabled.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceDisabled.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceDisabled.Options.UseBackColor = true;
            this.home.AppearanceDisabled.Options.UseBorderColor = true;
            this.home.AppearanceDisabled.Options.UseForeColor = true;
            this.home.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearanceHovered.Options.UseBackColor = true;
            this.home.AppearanceHovered.Options.UseBorderColor = true;
            this.home.AppearanceHovered.Options.UseForeColor = true;
            this.home.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearancePressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.home.AppearancePressed.Options.UseBackColor = true;
            this.home.AppearancePressed.Options.UseBorderColor = true;
            this.home.AppearancePressed.Options.UseForeColor = true;
            this.home.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.home.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("home.ImageOptions.SvgImage")));
            this.home.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.home.Location = new System.Drawing.Point(580, 12);
            this.home.Name = "home";
            this.home.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.home.Size = new System.Drawing.Size(50, 40);
            this.home.TabIndex = 9;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 29);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add Product";
            // 
            // logout
            // 
            this.logout.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.Appearance.Font = new System.Drawing.Font("Kristen ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.Appearance.Options.UseBackColor = true;
            this.logout.Appearance.Options.UseBorderColor = true;
            this.logout.Appearance.Options.UseFont = true;
            this.logout.Appearance.Options.UseForeColor = true;
            this.logout.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceDisabled.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceDisabled.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceDisabled.Options.UseBackColor = true;
            this.logout.AppearanceDisabled.Options.UseBorderColor = true;
            this.logout.AppearanceDisabled.Options.UseForeColor = true;
            this.logout.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceHovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearanceHovered.Options.UseBackColor = true;
            this.logout.AppearanceHovered.Options.UseBorderColor = true;
            this.logout.AppearanceHovered.Options.UseForeColor = true;
            this.logout.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearancePressed.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearancePressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.logout.AppearancePressed.Options.UseBackColor = true;
            this.logout.AppearancePressed.Options.UseBorderColor = true;
            this.logout.AppearancePressed.Options.UseForeColor = true;
            this.logout.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.logout.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("logout.ImageOptions.SvgImage")));
            this.logout.ImageOptions.SvgImageSize = new System.Drawing.Size(50, 50);
            this.logout.Location = new System.Drawing.Point(658, 12);
            this.logout.Name = "logout";
            this.logout.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.logout.Size = new System.Drawing.Size(50, 40);
            this.logout.TabIndex = 6;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // tileControl1
            // 
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Location = new System.Drawing.Point(0, 58);
            this.tileControl1.MaxId = 1;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.Size = new System.Drawing.Size(718, 175);
            this.tileControl1.TabIndex = 8;
            this.tileControl1.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItem1);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileItem1
            // 
            tileItemElement3.ImageOptions.Image = global::Tasa_Project.Properties.Resources.logo22;
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileItemElement3.ImageOptions.ImageSize = new System.Drawing.Size(200, 120);
            tileItemElement3.Text = "";
            this.tileItem1.Elements.Add(tileItemElement3);
            tileItemFrame2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            tileItemFrame2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            tileItemFrame2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            tileItemFrame2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            tileItemFrame2.Appearance.Options.UseBackColor = true;
            tileItemFrame2.Appearance.Options.UseBorderColor = true;
            tileItemFrame2.Appearance.Options.UseForeColor = true;
            tileItemElement4.ImageOptions.Image = global::Tasa_Project.Properties.Resources.logo22;
            tileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Squeeze;
            tileItemElement4.ImageOptions.ImageSize = new System.Drawing.Size(200, 120);
            tileItemElement4.Text = "";
            tileItemFrame2.Elements.Add(tileItemElement4);
            tileItemFrame2.Image = global::Tasa_Project.Properties.Resources.logo22;
            this.tileItem1.Frames.Add(tileItemFrame2);
            this.tileItem1.Id = 0;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.tileItem1.Name = "tileItem1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(90, 513);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(130, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Muhammad Gomaa ©";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(11, 513);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 10;
            this.label7.Text = "Copyrights :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 29);
            this.label3.TabIndex = 14;
            this.label3.Text = "Category :";
            // 
            // price
            // 
            this.price.DecimalPlaces = 2;
            this.price.Location = new System.Drawing.Point(240, 305);
            this.price.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(291, 37);
            this.price.TabIndex = 15;
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // category
            // 
            this.category.FormattingEnabled = true;
            this.category.Items.AddRange(new object[] {
            "بيتزا",
            "كريب",
            "مشروبات",
            "اضافات",
            "مقبلات و سلطات",
            "سندوتشات",
            "برجر",
            "حواوشى",
            "ارز",
            "وجبات"});
            this.category.Location = new System.Drawing.Point(240, 371);
            this.category.Name = "category";
            this.category.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.category.Size = new System.Drawing.Size(291, 37);
            this.category.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Size :";
            // 
            // size
            // 
            this.size.FormattingEnabled = true;
            this.size.Items.AddRange(new object[] {
            "صغير",
            "وسط",
            "كبير"});
            this.size.Location = new System.Drawing.Point(240, 437);
            this.size.Name = "size";
            this.size.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.size.Size = new System.Drawing.Size(291, 37);
            this.size.TabIndex = 18;
            // 
            // AddProduct
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(202)))), ((int)(((byte)(127)))));
            this.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            this.Appearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(720, 540);
            this.Controls.Add(this.size);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.category);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tileControl1);
            this.Controls.Add(this.panel_top);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IconOptions.Image = global::Tasa_Project.Properties.Resources.logo22;
            this.MaximizeBox = false;
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tasa";
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_top;
        private DevExpress.XtraEditors.SimpleButton logout;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton home;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown price;
        private System.Windows.Forms.ComboBox category;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox size;
    }
}