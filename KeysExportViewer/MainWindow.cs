using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace KeysExportViewer
{
	[SuppressMessage("ReSharper", "HeapView.ObjectAllocation.Possible")]
	public partial class MainWindow : Form
	{
		#region Data Members
		/// <summary>
		/// The key dictionary
		/// </summary>
		private IReadOnlyDictionary<string, MsdnKey> _keys;
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
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.MessageBox.Show(System.String,System.String,System.Windows.Forms.MessageBoxButtons,System.Windows.Forms.MessageBoxIcon,System.Windows.Forms.MessageBoxDefaultButton,System.Windows.Forms.MessageBoxOptions)"), SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "KeysExport"), SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.MessageBox.Show(System.String)")]
		[SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
		private void OpenFile()
		{
			if (DialogResult.OK != openFileDialog.ShowDialog())
				return;
			
			Cursor.Current = Cursors.WaitCursor;

			productsListView.Items.Clear();
			webBrowser.Visible = false;
			panel.Visible = false;

			try
			{
				var collection = new KeysCollection(openFileDialog.FileName);
				_keys = collection.Keys;

				foreach (var key in _keys.Keys)
				{
					// Get the actual data we care about
					var val = _keys[key];

                    // Add the item to the ListView
                    productsListView.Items.Add(new ListViewItem(val.Name) { Tag = key });
                }
			}
			catch (FileNotFoundException)
			{
				MessageBox.Show("File " + openFileDialog.FileName + " does not exist.", "KeysExport Viewer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
			}

			Cursor.Current = Cursors.Default;
		}

		/// <summary>
		/// Goes to previous record.
		/// </summary>
		private void GoToPreviousRecord()
		{
			try
			{
				var selected = productsListView.SelectedIndices[0];
				if (0 == selected)
				{
					selected = productsListView.Items.Count - 1;
				}
				else
				{
					selected--;
				}

				productsListView.Focus();
				productsListView.Items[selected].Selected = true;
			}
			catch (ArgumentOutOfRangeException)
			{
				if (productsListView.Items.Count > 0)
				{
					productsListView.Focus();
					productsListView.Items[productsListView.Items.Count - 1].Selected = true;
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
				var selected = productsListView.SelectedIndices[0];
				if (productsListView.Items.Count - 1 == selected)
				{
					selected = 0;
				}
				else
				{
					selected++;
				}

				productsListView.Focus();
				productsListView.Items[selected].Selected = true;
			}
			catch (ArgumentOutOfRangeException)
			{
				if (productsListView.Items.Count > 0)
				{
					productsListView.Focus();
					productsListView.Items[0].Selected = true;
				}
			}
		}

		/// <summary>
		/// Shows the current record.
		/// </summary>
		private void ShowCurrentRecord()
		{
			if (null == _keys)
				return;
			
			foreach (ListViewItem item in productsListView.SelectedItems)
			{
				var selectedKey = _keys[(string)item.Tag];

				if (null == selectedKey)
					continue;
				
				if (selectedKey.HasKey)
				{
					productNameValueLabel.Text = selectedKey.Name;
					keyIdValueLabel.Text = selectedKey.Id.ToString(CultureInfo.InvariantCulture);
					keysListView.Items.Clear();

					foreach (var key in selectedKey.Keys)
					{
						var keyItem = new ListViewItem(key.KeyType);
						keyItem.SubItems.Add(null == key.ClaimedDate ? "" : ((DateTime)key.ClaimedDate).ToShortDateString());
						keyItem.SubItems.Add(key.Key);
						keyItem.Tag = key;

						keysListView.Items.Add(keyItem);
					}
					CopyAllKeysOfProductToClipboard(selectedKey.Name, selectedKey.Keys);
				}
				else
				{
					webBrowser.Navigate(new Uri("about:blank"));
					if (null != webBrowser.Document)
					{
						webBrowser.Document.Write(string.Empty);
					}
					webBrowser.DocumentText = "<html>" + selectedKey.CDATA + "</html>";
				}

				webBrowser.Visible = !selectedKey.HasKey;
				panel.Visible = selectedKey.HasKey;
			}
		}

		/// <summary>
		/// Copies the product name and all keys of the product to the clipboard.
		/// </summary>
		/// <param name="productName"></param>
		/// <param name="keys"></param>
        private static void CopyAllKeysOfProductToClipboard(string productName, IEnumerable<MsdnKey.IndividualKey> keys)
        {
            var sb = new StringBuilder(256);
            sb.AppendFormat(Application.CurrentCulture, "{0}:{1}{2}", productName, Environment.NewLine, Environment.NewLine);
            foreach (var individualKey in keys)
            {
                sb.AppendFormat(Application.CurrentCulture, "{0} ({1}){2}", individualKey.Key, individualKey.KeyType, Environment.NewLine);
            }
            Clipboard.SetText(sb.ToString());
            sb.Clear();
        }
		
		/// <summary>
		/// Copies the current key to clipboard.
		/// </summary>
		private void CopyCurrentKeyToClipboard()
		{
			if (1 != keysListView.SelectedItems.Count) return;
			
			var key = (MsdnKey.IndividualKey)keysListView.SelectedItems[0].Tag;
			if (null != key)
			{
				Clipboard.SetText(key.Key);
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
			Exit();
		}

		/// <summary>
		/// Handles the Click event of the openToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFile();
		}

		/// <summary>
		/// Handles the Click event of the openToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			OpenFile();
		}

		/// <summary>
		/// Handles the Click event of the previousToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void previousToolStripButton_Click(object sender, EventArgs e)
		{
			GoToPreviousRecord();
		}

		/// <summary>
		/// Handles the Click event of the nextToolStripButton control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void nextToolStripButton_Click(object sender, EventArgs e)
		{
			GoToNextRecord();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the productsListView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void productsListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			ShowCurrentRecord();
		}

		/// <summary>
		/// Handles the SelectedIndexChanged event of the keysListView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void keysListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			CopyCurrentKeyToClipboard();
		}
		#endregion Event Handlers
	}
}
