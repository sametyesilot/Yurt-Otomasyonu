namespace YurtOtomasyon
{
    partial class RandevuBildir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandevuBildir));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.txtOgrEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtRehberEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.memoMesaj = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.mskOgrTel = new System.Windows.Forms.MaskedTextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbRehber = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnKayit = new DevExpress.XtraEditors.SimpleButton();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.memoRandevuSebep = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOgrSoyad = new DevExpress.XtraEditors.TextEdit();
            this.txtOgrAd = new DevExpress.XtraEditors.TextEdit();
            this.txtRandevu = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRehberEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMesaj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRehber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRandevuSebep.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrSoyad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrAd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRandevu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, -2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1487, 739);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
//            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(1493, -2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(546, 744);
            this.xtraTabControl1.TabIndex = 5;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.txtRandevu);
            this.xtraTabPage1.Controls.Add(this.txtOgrEmail);
            this.xtraTabPage1.Controls.Add(this.labelControl8);
            this.xtraTabPage1.Controls.Add(this.txtRehberEmail);
            this.xtraTabPage1.Controls.Add(this.labelControl7);
            this.xtraTabPage1.Controls.Add(this.memoMesaj);
            this.xtraTabPage1.Controls.Add(this.labelControl6);
            this.xtraTabPage1.Controls.Add(this.mskOgrTel);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.cbRehber);
            this.xtraTabPage1.Controls.Add(this.btnKayit);
            this.xtraTabPage1.Controls.Add(this.txtId);
            this.xtraTabPage1.Controls.Add(this.labelControl12);
            this.xtraTabPage1.Controls.Add(this.labelControl11);
            this.xtraTabPage1.Controls.Add(this.memoRandevuSebep);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.txtOgrSoyad);
            this.xtraTabPage1.Controls.Add(this.txtOgrAd);
            this.xtraTabPage1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.ImageOptions.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(539, 694);
            this.xtraTabPage1.Text = "Randevu Bildir";
            // 
            // txtOgrEmail
            // 
            this.txtOgrEmail.Enabled = false;
            this.txtOgrEmail.Location = new System.Drawing.Point(168, 201);
            this.txtOgrEmail.Name = "txtOgrEmail";
            this.txtOgrEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOgrEmail.Properties.Appearance.Options.UseFont = true;
            this.txtOgrEmail.Size = new System.Drawing.Size(333, 32);
            this.txtOgrEmail.TabIndex = 61;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(44, 324);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(116, 25);
            this.labelControl8.TabIndex = 60;
            this.labelControl8.Text = "Rehber E-Mail";
            // 
            // txtRehberEmail
            // 
            this.txtRehberEmail.Enabled = false;
            this.txtRehberEmail.Location = new System.Drawing.Point(168, 321);
            this.txtRehberEmail.Name = "txtRehberEmail";
            this.txtRehberEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRehberEmail.Properties.Appearance.Options.UseFont = true;
            this.txtRehberEmail.Size = new System.Drawing.Size(333, 32);
            this.txtRehberEmail.TabIndex = 59;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(25, 471);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(135, 25);
            this.labelControl7.TabIndex = 58;
            this.labelControl7.Text = "Eklenecek Mesaj";
            // 
            // memoMesaj
            // 
            this.memoMesaj.Location = new System.Drawing.Point(168, 461);
            this.memoMesaj.Name = "memoMesaj";
            this.memoMesaj.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoMesaj.Properties.Appearance.Options.UseFont = true;
            this.memoMesaj.Size = new System.Drawing.Size(334, 52);
            this.memoMesaj.TabIndex = 57;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(43, 364);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(117, 25);
            this.labelControl6.TabIndex = 56;
            this.labelControl6.Text = "Randevu Saati";
            // 
            // mskOgrTel
            // 
            this.mskOgrTel.Enabled = false;
            this.mskOgrTel.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mskOgrTel.Location = new System.Drawing.Point(168, 241);
            this.mskOgrTel.Mask = "(999) 000-0000";
            this.mskOgrTel.Name = "mskOgrTel";
            this.mskOgrTel.Size = new System.Drawing.Size(333, 31);
            this.mskOgrTel.TabIndex = 54;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(116, 204);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 25);
            this.labelControl4.TabIndex = 52;
            this.labelControl4.Text = "Email";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(97, 244);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(63, 25);
            this.labelControl5.TabIndex = 53;
            this.labelControl5.Text = "Telefon";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(18, 284);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(142, 25);
            this.labelControl3.TabIndex = 50;
            this.labelControl3.Text = "Rehber Ad Soyad";
            // 
            // cbRehber
            // 
            this.cbRehber.Enabled = false;
            this.cbRehber.Location = new System.Drawing.Point(168, 281);
            this.cbRehber.Name = "cbRehber";
            this.cbRehber.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbRehber.Properties.Appearance.Options.UseFont = true;
            this.cbRehber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRehber.Size = new System.Drawing.Size(333, 32);
            this.cbRehber.TabIndex = 49;
            // 
            // btnKayit
            // 
            this.btnKayit.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKayit.Appearance.Options.UseFont = true;
            this.btnKayit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKayit.ImageOptions.Image")));
            this.btnKayit.Location = new System.Drawing.Point(345, 519);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(156, 52);
            this.btnKayit.TabIndex = 48;
            this.btnKayit.Text = "BİLDİR";
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(168, 81);
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtId.Properties.Appearance.Options.UseFont = true;
            this.txtId.Size = new System.Drawing.Size(333, 32);
            this.txtId.TabIndex = 46;
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(65, 84);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(95, 25);
            this.labelControl12.TabIndex = 45;
            this.labelControl12.Text = "Randevu ID";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(26, 414);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(134, 25);
            this.labelControl11.TabIndex = 44;
            this.labelControl11.Text = "Randevu Sebebi";
            // 
            // memoRandevuSebep
            // 
            this.memoRandevuSebep.Enabled = false;
            this.memoRandevuSebep.Location = new System.Drawing.Point(168, 401);
            this.memoRandevuSebep.Name = "memoRandevuSebep";
            this.memoRandevuSebep.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.memoRandevuSebep.Properties.Appearance.Options.UseFont = true;
            this.memoRandevuSebep.Size = new System.Drawing.Size(334, 52);
            this.memoRandevuSebep.TabIndex = 39;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(66, 124);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 25);
            this.labelControl1.TabIndex = 22;
            this.labelControl1.Text = "Öğrenci Ad";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(39, 164);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(121, 25);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Öğrenci Soyad";
            // 
            // txtOgrSoyad
            // 
            this.txtOgrSoyad.Enabled = false;
            this.txtOgrSoyad.Location = new System.Drawing.Point(168, 161);
            this.txtOgrSoyad.Name = "txtOgrSoyad";
            this.txtOgrSoyad.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOgrSoyad.Properties.Appearance.Options.UseFont = true;
            this.txtOgrSoyad.Size = new System.Drawing.Size(333, 32);
            this.txtOgrSoyad.TabIndex = 24;
            // 
            // txtOgrAd
            // 
            this.txtOgrAd.Enabled = false;
            this.txtOgrAd.Location = new System.Drawing.Point(168, 121);
            this.txtOgrAd.Name = "txtOgrAd";
            this.txtOgrAd.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtOgrAd.Properties.Appearance.Options.UseFont = true;
            this.txtOgrAd.Size = new System.Drawing.Size(333, 32);
            this.txtOgrAd.TabIndex = 23;
            // 
            // txtRandevu
            // 
            this.txtRandevu.Enabled = false;
            this.txtRandevu.Location = new System.Drawing.Point(168, 361);
            this.txtRandevu.Name = "txtRandevu";
            this.txtRandevu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRandevu.Properties.Appearance.Options.UseFont = true;
            this.txtRandevu.Size = new System.Drawing.Size(333, 32);
            this.txtRandevu.TabIndex = 62;
            // 
            // RandevuBildir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 749);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "RandevuBildir";
            this.Text = "RandevuBildir";
            this.Load += new System.EventHandler(this.RandevuBildir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRehberEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoMesaj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRehber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoRandevuSebep.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrSoyad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOgrAd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRandevu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit memoMesaj;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.MaskedTextBox mskOgrTel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbRehber;
        private DevExpress.XtraEditors.SimpleButton btnKayit;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.MemoEdit memoRandevuSebep;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtOgrSoyad;
        private DevExpress.XtraEditors.TextEdit txtOgrAd;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtRehberEmail;
        private DevExpress.XtraEditors.TextEdit txtOgrEmail;
        private DevExpress.XtraEditors.TextEdit txtRandevu;
    }
}