namespace PS3_iW4Region
{
   partial class frmMain
   {
      /// <summary>
      ///  Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			var resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.statusStrip1 = new StatusStrip();
			this.toolStripStatusLabelRegion = new ToolStripStatusLabel();
			this.buttonOpen = new Button();
			this.textBoxPath = new TextBox();
			this.labelRegion = new Label();
			this.comboBoxRegion = new ComboBox();
			this.buttonPatcher = new Button();
			this.labelFile = new Label();
			this.pictureBox1 = new PictureBox();
			this.progressBar1 = new ProgressBar();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.AutoSize = false;
			this.statusStrip1.Items.AddRange(new ToolStripItem[] { this.toolStripStatusLabelRegion });
			this.statusStrip1.Location = new Point(0, 316);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(342, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabelRegion
			// 
			this.toolStripStatusLabelRegion.Name = "toolStripStatusLabelRegion";
			this.toolStripStatusLabelRegion.Size = new Size(104, 17);
			this.toolStripStatusLabelRegion.Text = "Current Region : ...";
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new Point(237, 141);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new Size(75, 23);
			this.buttonOpen.TabIndex = 0;
			this.buttonOpen.Text = "Open...";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += this.buttonOpen_Click;
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new Point(30, 141);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.ReadOnly = true;
			this.textBoxPath.Size = new Size(201, 23);
			this.textBoxPath.TabIndex = 1;
			// 
			// labelRegion
			// 
			this.labelRegion.AutoSize = true;
			this.labelRegion.Location = new Point(30, 183);
			this.labelRegion.Name = "labelRegion";
			this.labelRegion.Size = new Size(87, 15);
			this.labelRegion.TabIndex = 12;
			this.labelRegion.Text = "Select Region : ";
			// 
			// comboBoxRegion
			// 
			this.comboBoxRegion.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxRegion.Enabled = false;
			this.comboBoxRegion.FormattingEnabled = true;
			this.comboBoxRegion.Items.AddRange(new object[] { "BLUS30377orBLES00683", "BLES00684", "BLES00685", "BLES00686", "BLES00687", "BLES00690", "BLES00691" });
			this.comboBoxRegion.Location = new Point(30, 201);
			this.comboBoxRegion.Name = "comboBoxRegion";
			this.comboBoxRegion.Size = new Size(282, 23);
			this.comboBoxRegion.TabIndex = 11;
			this.comboBoxRegion.SelectedIndexChanged += this.comboBoxRegion_SelectedIndexChanged;
			// 
			// buttonPatcher
			// 
			this.buttonPatcher.Enabled = false;
			this.buttonPatcher.Location = new Point(30, 246);
			this.buttonPatcher.Name = "buttonPatcher";
			this.buttonPatcher.Size = new Size(282, 41);
			this.buttonPatcher.TabIndex = 10;
			this.buttonPatcher.Text = "Patcher";
			this.buttonPatcher.UseVisualStyleBackColor = true;
			this.buttonPatcher.Click += this.buttonPatcher_Click;
			// 
			// labelFile
			// 
			this.labelFile.AutoSize = true;
			this.labelFile.Location = new Point(30, 123);
			this.labelFile.Name = "labelFile";
			this.labelFile.Size = new Size(34, 15);
			this.labelFile.TabIndex = 13;
			this.labelFile.Text = "File : ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = Color.Black;
			this.pictureBox1.Image = Properties.Resources.logo;
			this.pictureBox1.Location = new Point(0, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(343, 101);
			this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new Point(30, 255);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new Size(282, 23);
			this.progressBar1.TabIndex = 15;
			this.progressBar1.Visible = false;
			// 
			// frmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new SizeF(7F, 15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(342, 338);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.labelFile);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.labelRegion);
			this.Controls.Add(this.textBoxPath);
			this.Controls.Add(this.comboBoxRegion);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.buttonPatcher);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.Icon = (Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "PS3 - iW4 Region";
			this.FormClosing += this.frmMain_FormClosing;
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion
		private TextBox textBoxPath;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabelRegion;
		private Button buttonOpen;
		private Label labelRegion;
		private ComboBox comboBoxRegion;
		private Button buttonPatcher;
		private Label labelFile;
		private PictureBox pictureBox1;
		private ProgressBar progressBar1;
	}
}
