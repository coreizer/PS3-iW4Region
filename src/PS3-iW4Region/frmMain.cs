#region License Information (GPL v3)

/**
 * Copyright (C) 2024 coreizer
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

#endregion

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

		private void frmMain_KeyDown(object sender, KeyEventArgs e) {
			if (e.Control && e.KeyCode == Keys.O) {
				this.OpenFile();
			}
		}

		private void frmMain_DragDrop(object sender, DragEventArgs e) {
			try {
				var drops = e.Data?.GetData(DataFormats.FileDrop, false) as string[];
				if (drops != null) {
					foreach (var drop in drops) {
						if (File.Exists(drop)) {
							this.ReadFile(drop);
							break;
						}
					}
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
				this.ResetUI();
			}
		}

		private void frmMain_DragEnter(object sender, DragEventArgs e) {
			if (e.Data == null) return;
			e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ?
				DragDropEffects.Copy :
				DragDropEffects.None;
		}

		private void buttonOpen_Click(object sender, EventArgs e) {
			this.OpenFile();
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
				this.ResetUI();
			}
			finally {
				this.buttonPatcher.Visible = true;
				this.progressBar1.Visible = false;
			}
		}

		private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e) {
			this.buttonPatcher.Enabled = true;
		}

		private void OpenFile() {
			try {
				this.ResetUI();
				using var OFD = new OpenFileDialog {
					Filter = "Fast File (*.ff)|*.ff",
					FileName = "patch_mp.ff",
					Multiselect = false
				};

				if (OFD.ShowDialog() == DialogResult.OK) {
					this.ReadFile(OFD.FileName);
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
				this.ResetUI();
			}
		}

		private void ReadFile(string filename) {
			this._fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite, FileShare.None) {
				Position = 0x18
			};

			var region = this._fs.ReadByte();
			var titleId = (TitleId)Enum.ToObject(typeof(TitleId), region);
			if (!Enum.IsDefined(typeof(TitleId), (byte)region)) {
				throw new InvalidDataException("Invalid Data");
			}

			this.textBoxPath.Text = filename;
			this.textBoxPath.SelectionLength = filename.Length - 1;
			this.comboBoxRegion.Enabled = true;
			this.comboBoxRegion.SelectedItem = $"{titleId}";
			this.buttonPatcher.Enabled = (this.comboBoxRegion.SelectedIndex != -1);
			this.toolStripStatusLabelRegion.Text = $"Current Region : {titleId}";
		}

		private void ResetUI() {
			this._fs?.Close();
			this._fs?.Dispose();
			this.textBoxPath.ResetText();
			this.buttonPatcher.Enabled = false;
			this.buttonPatcher.Visible = true;
			this.comboBoxRegion.Enabled = false;
			this.progressBar1.Visible = false;
		}
	}
}
