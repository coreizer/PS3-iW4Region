namespace PS3_iW4Region
{
	public partial class frmMain : Form
	{
		private FileStream _fs;

		public frmMain() {
			this.InitializeComponent();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			this._fs?.Close();
			this._fs?.Dispose();
		}

		private void buttonOpen_Click(object sender, EventArgs e) {
			try {
				this.Reset();
				using var OFD = new OpenFileDialog {
					Filter = "Fast File (*.ff)|*.ff",
					FileName = "patch_mp.ff",
					Multiselect = false
				};

				if (OFD.ShowDialog() == DialogResult.OK) {
					this._fs = new FileStream(OFD.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None) {
						Position = 0x18
					};

					var region = this._fs.ReadByte();
					var titleId = (TitleId)Enum.ToObject(typeof(TitleId), region);
					if (!Enum.IsDefined(typeof(TitleId), (byte)region)) {
						throw new InvalidDataException("Invalid Data");
					}

					this.textBoxPath.Text = OFD.FileName;
					this.textBoxPath.SelectionLength = OFD.FileName.Length - 1;
					this.comboBoxRegion.Enabled = true;
					this.comboBoxRegion.SelectedItem = $"{titleId}";
					this.buttonPatcher.Enabled = (this.comboBoxRegion.SelectedIndex != -1);
					this.toolStripStatusLabelRegion.Text = $"Current Region : {titleId}";
				}
			}
			catch (Exception ex) {
				TaskDialog.ShowDialog(this, new TaskDialogPage {
					Icon = TaskDialogIcon.Error,
					Text = ex.Message,
					Caption = Application.ProductName,
					Heading = "Error",
					Buttons = { TaskDialogButton.OK }
				});
			}
		}

		private async void buttonPatcher_Click(object sender, EventArgs e) {
			try {
				this.buttonPatcher.Visible = false;
				this.progressBar1.Visible = true;
				this.progressBar1.Value = 0;

				for (var i = 0; i <= 100; i++) {
					await Task.Delay(10);
					this.progressBar1.Value = i;
				}

				var titleId = Enum.Parse<TitleId>(this.comboBoxRegion.Text);
				this._fs.Position = 0x18;
				this._fs.WriteByte((byte)titleId);

				this.toolStripStatusLabelRegion.Text = $"Current Region : {titleId}";
				await Task.Delay(100);
			}
			catch (Exception ex) {
				TaskDialog.ShowDialog(this, new TaskDialogPage {
					Icon = TaskDialogIcon.Error,
					Text = ex.Message,
					Caption = Application.ProductName,
					Heading = "Error",
					Buttons = { TaskDialogButton.OK }
				});
			}
			finally {
				this.buttonPatcher.Visible = true;
				this.progressBar1.Visible = false;
			}
		}

		private void Reset() {
			this._fs?.Close();
			this._fs?.Dispose();
			this.textBoxPath.ResetText();
			this.buttonPatcher.Enabled = false;
			this.comboBoxRegion.Enabled = false;
		}

		private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e) {
			this.buttonPatcher.Enabled = true;
		}
	}
}
