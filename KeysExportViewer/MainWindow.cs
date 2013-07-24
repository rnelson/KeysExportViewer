using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace KeysExportViewer
{
	public partial class MainWindow : Form
	{
		#region Data Members
		/// <summary>
		/// The key dictionary
		/// </summary>
		private IReadOnlyDictionary<Guid, MsdnKey> _dict;
		#endregion Data Members

		#region Constructors
		public MainWindow()
		{
			InitializeComponent();
		}
		#endregion Constructors

		#region Private Methods
		/// <summary>
		/// Exits this instance.
		/// </summary>
		private static void Exit()
		{
			Application.Exit();
		}

		/// <summary>
		/// Opens a file.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "KeysExport"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.MessageBox.Show(System.String)")]
		private void OpenFile()
		{
			if (DialogResult.OK == this.openFileDialog.ShowDialog())
			{
				Cursor.Current = Cursors.WaitCursor;

				this.productsListView.Items.Clear();
				this.webBrowser.Visible = false;
				this.panel.Visible = false;

				try
				{
					KeysCollection collection = new KeysCollection(this.openFileDialog.FileName);
					this._dict = collection.Keys;

					foreach (Guid key in _dict.Keys)
					{
						// Get the actual data we care about
						MsdnKey val = _dict[key];
						
						// Create a new ListViewItem for this product
						ListViewItem item = new ListViewItem(val.Name);
						item.Tag = key;

						// Add the item to the ListView
						this.productsListView.Items.Add(item);
					}
				}
				catch (FileNotFoundException)
				{
					MessageBox.Show("File " + this.openFileDialog.FileName + " does not exist.", "KeysExport Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
				}

				Cursor.Current = Cursors.Default;
			}
		}

		/// <summary>
		/// Goes to previous record.
		/// </summary>
		private void GoToPreviousRecord()
		{
			try
			{
				int selected = this.productsListView.SelectedIndices[0];
				if (0 == selected)
				{
					selected = this.productsListView.Items.Count - 1;
				}
				else
				{
					selected--;
				}

				this.productsListView.Focus();
				this.productsListView.Items[selected].Selected = true;
			}
			catch (ArgumentOutOfRangeException)
			{
				if (this.productsListView.Items.Count > 0)
				{
					this.productsListView.Focus();
					this.productsListView.Items[this.productsListView.Items.Count - 1].Selected = true;
				}
			}
		}

		/// <summary>
		/// Goes to next record.
		/// </summary>
		private void GoToNextRecord()
		{
			try
			{
				int selected = this.productsListView.SelectedIndices[0];
				if (this.productsListView.Items.Count - 1 == selected)
				{
					selected = 0;
				}
				else
				{
					selected++;
				}

				this.productsListView.Focus();
				this.productsListView.Items[selected].Selected = true;
			}
			catch (ArgumentOutOfRangeException)
			{
				if (this.productsListView.Items.Count > 0)
				{
					this.productsListView.Focus();
					this.productsListView.Items[0].Selected = true;
				}
			}
		}

		/// <summary>
		/// Shows the current record.
		/// </summary>
		private void ShowCurrentRecord()
		{
			if (null != this._dict)
			{
				foreach (ListViewItem item in this.productsListView.SelectedItems)
				{
					MsdnKey selectedKey = this._dict[(Guid)item.Tag];
					if (null != selectedKey)
					{
						if (selectedKey.HasKey)
						{
							this.productNameValueLabel.Text = selectedKey.Name;
							this.keyIdValueLabel.Text = selectedKey.Id.ToString(CultureInfo.InvariantCulture);
							this.keysListView.Items.Clear();

							foreach (MsdnKey.IndividualKey key in selectedKey.Keys)
							{
								ListViewItem keyItem = new ListViewItem(key.KeyType);
								keyItem.SubItems.Add(null == key.ClaimedDate ? "" : ((DateTime)key.ClaimedDate).ToShortDateString());
								keyItem.SubItems.Add(key.Key);
								keyItem.Tag = key;

								this.keysListView.Items.Add(keyItem);
							}
						}
						else
						{
							this.webBrowser.Navigate("about:blank");
							if (null != webBrowser.Document)
							{
								this.webBrowser.Document.Write(string.Empty);
							}
							this.webBrowser.DocumentText = "<html>" + selectedKey.CDATA + "</html>";
						}

						this.webBrowser.Visible = !selectedKey.HasKey;
						this.panel.Visible = selectedKey.HasKey;
					}
				}
			}
		}

		/// <summary>
		/// Copies the current key to clipboard.
		/// </summary>
		private void CopyCurrentKeyToClipboard()
		{
			if (1 == this.keysListView.SelectedItems.Count)
			{
				MsdnKey.IndividualKey key = (MsdnKey.IndividualKey)this.keysListView.SelectedItems[0].Tag;
				if (null != key)
				{
					Clipboard.SetText(key.Key);
				}
			}
		}
		#endregion Private Methods

		#region Event Handlers
		/// <summary>
		/// Handles the Click event of the exitToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MainWindow.Exit();
		}

		/// <summary>
		/// Handles the Click event of the openToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.OpenFile();
		}

		/// <summary>
		/// Handles the Click event of the openToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			this.OpenFile();
		}

		/// <summary>
		/// Handles the Click event of the previousToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void previousToolStripButton_Click(object sender, EventArgs e)
		{
			this.GoToPreviousRecord();
		}

		/// <summary>
		/// Handles the Click event of the nextToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void nextToolStripButton_Click(object sender, EventArgs e)
		{
			this.GoToNextRecord();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the productsListView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void productsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ShowCurrentRecord();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the keysListView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void keysListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.CopyCurrentKeyToClipboard();
		}
		#endregion Event Handlers
	}
}
