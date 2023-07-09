namespace KeysExportViewer
{
	partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.previousToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.nextToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabelQuery = new System.Windows.Forms.ToolStripLabel();
            this.TextBoxQuery = new System.Windows.Forms.ToolStripTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.productsListView = new System.Windows.Forms.ListView();
            this.productColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel = new System.Windows.Forms.Panel();
            this.copyNoteLabel = new System.Windows.Forms.Label();
            this.keysListView = new System.Windows.Forms.ListView();
            this.typeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.keyIdValueLabel = new System.Windows.Forms.Label();
            this.keyIdLabel = new System.Windows.Forms.Label();
            this.productNameValueLabel = new System.Windows.Forms.Label();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.noteColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(606, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.previousToolStripButton,
            this.nextToolStripButton,
            this.toolStripLabelQuery,
            this.TextBoxQuery});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(606, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = global::KeysExportViewer.Properties.Resources.Open_6529;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // previousToolStripButton
            // 
            this.previousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.previousToolStripButton.Image = global::KeysExportViewer.Properties.Resources.NavigateBackwards_6270;
            this.previousToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.previousToolStripButton.Name = "previousToolStripButton";
            this.previousToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.previousToolStripButton.Text = "Previous";
            this.previousToolStripButton.Click += new System.EventHandler(this.previousToolStripButton_Click);
            // 
            // nextToolStripButton
            // 
            this.nextToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nextToolStripButton.Image = global::KeysExportViewer.Properties.Resources.NavigateForward_6271;
            this.nextToolStripButton.ImageTransparentColor = System.Drawing.Color.White;
            this.nextToolStripButton.Name = "nextToolStripButton";
            this.nextToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.nextToolStripButton.Text = "Next";
            this.nextToolStripButton.Click += new System.EventHandler(this.nextToolStripButton_Click);
            // 
            // toolStripLabelQuery
            // 
            this.toolStripLabelQuery.Name = "toolStripLabelQuery";
            this.toolStripLabelQuery.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabelQuery.Text = "Filter:";
            this.toolStripLabelQuery.ToolTipText = "Filter keys by names and notes";
            // 
            // TextBoxQuery
            // 
            this.TextBoxQuery.Name = "TextBoxQuery";
            this.TextBoxQuery.Size = new System.Drawing.Size(100, 25);
            this.TextBoxQuery.ToolTipText = "Filter keys by names and notes";
            this.TextBoxQuery.TextChanged += new System.EventHandler(this.textBoxQuery_TextChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "xml";
            this.openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Open File";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 49);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.productsListView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panel);
            this.splitContainer.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer.Size = new System.Drawing.Size(606, 471);
            this.splitContainer.SplitterDistance = 202;
            this.splitContainer.TabIndex = 2;
            // 
            // productsListView
            // 
            this.productsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.productColumnHeader});
            this.productsListView.FullRowSelect = true;
            this.productsListView.HideSelection = false;
            this.productsListView.Location = new System.Drawing.Point(0, 3);
            this.productsListView.MultiSelect = false;
            this.productsListView.Name = "productsListView";
            this.productsListView.Size = new System.Drawing.Size(199, 465);
            this.productsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.productsListView.TabIndex = 1;
            this.productsListView.UseCompatibleStateImageBehavior = false;
            this.productsListView.View = System.Windows.Forms.View.Details;
            this.productsListView.SelectedIndexChanged += new System.EventHandler(this.productsListView_SelectedIndexChanged);
            this.productsListView.Resize += new System.EventHandler(this.productsListView_Resize);
            // 
            // productColumnHeader
            // 
            this.productColumnHeader.Text = "Product";
            this.productColumnHeader.Width = 190;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.copyNoteLabel);
            this.panel.Controls.Add(this.keysListView);
            this.panel.Controls.Add(this.keyIdValueLabel);
            this.panel.Controls.Add(this.keyIdLabel);
            this.panel.Controls.Add(this.productNameValueLabel);
            this.panel.Controls.Add(this.productNameLabel);
            this.panel.Location = new System.Drawing.Point(3, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(394, 465);
            this.panel.TabIndex = 1;
            this.panel.Visible = false;
            // 
            // copyNoteLabel
            // 
            this.copyNoteLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.copyNoteLabel.AutoSize = true;
            this.copyNoteLabel.Location = new System.Drawing.Point(3, 447);
            this.copyNoteLabel.Name = "copyNoteLabel";
            this.copyNoteLabel.Size = new System.Drawing.Size(307, 13);
            this.copyNoteLabel.TabIndex = 5;
            this.copyNoteLabel.Text = "Note: Selecting a row above will copy the key to your clipboard.";
            // 
            // keysListView
            // 
            this.keysListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keysListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.typeColumnHeader,
            this.dateColumnHeader,
            this.keyColumnHeader,
            this.noteColumnHeader});
            this.keysListView.FullRowSelect = true;
            this.keysListView.GridLines = true;
            this.keysListView.HideSelection = false;
            this.keysListView.Location = new System.Drawing.Point(3, 29);
            this.keysListView.MultiSelect = false;
            this.keysListView.Name = "keysListView";
            this.keysListView.Size = new System.Drawing.Size(388, 415);
            this.keysListView.TabIndex = 4;
            this.keysListView.UseCompatibleStateImageBehavior = false;
            this.keysListView.View = System.Windows.Forms.View.Details;
            this.keysListView.SelectedIndexChanged += new System.EventHandler(this.keysListView_SelectedIndexChanged);
            // 
            // typeColumnHeader
            // 
            this.typeColumnHeader.Text = "Type";
            this.typeColumnHeader.Width = 80;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 70;
            // 
            // keyColumnHeader
            // 
            this.keyColumnHeader.Text = "Key";
            this.keyColumnHeader.Width = 173;
            // 
            // keyIdValueLabel
            // 
            this.keyIdValueLabel.AutoSize = true;
            this.keyIdValueLabel.Location = new System.Drawing.Point(56, 13);
            this.keyIdValueLabel.Name = "keyIdValueLabel";
            this.keyIdValueLabel.Size = new System.Drawing.Size(66, 13);
            this.keyIdValueLabel.TabIndex = 3;
            this.keyIdValueLabel.Text = "#MISSING#";
            // 
            // keyIdLabel
            // 
            this.keyIdLabel.AutoSize = true;
            this.keyIdLabel.Location = new System.Drawing.Point(3, 13);
            this.keyIdLabel.Name = "keyIdLabel";
            this.keyIdLabel.Size = new System.Drawing.Size(21, 13);
            this.keyIdLabel.TabIndex = 2;
            this.keyIdLabel.Text = "ID:";
            // 
            // productNameValueLabel
            // 
            this.productNameValueLabel.AutoSize = true;
            this.productNameValueLabel.Location = new System.Drawing.Point(56, 0);
            this.productNameValueLabel.Name = "productNameValueLabel";
            this.productNameValueLabel.Size = new System.Drawing.Size(66, 13);
            this.productNameValueLabel.TabIndex = 1;
            this.productNameValueLabel.Text = "#MISSING#";
            // 
            // productNameLabel
            // 
            this.productNameLabel.AutoSize = true;
            this.productNameLabel.Location = new System.Drawing.Point(3, 0);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(47, 13);
            this.productNameLabel.TabIndex = 0;
            this.productNameLabel.Text = "Product:";
            // 
            // webBrowser
            // 
            this.webBrowser.AllowWebBrowserDrop = false;
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(394, 465);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // noteColumnHeader
            // 
            this.noteColumnHeader.Text = "Note";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 520);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(622, 558);
            this.Name = "MainWindow";
            this.Text = "KeysExport Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton previousToolStripButton;
		private System.Windows.Forms.ToolStripButton nextToolStripButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.ListView productsListView;
		private System.Windows.Forms.ColumnHeader productColumnHeader;
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.ListView keysListView;
		private System.Windows.Forms.Label keyIdValueLabel;
		private System.Windows.Forms.Label keyIdLabel;
		private System.Windows.Forms.Label productNameValueLabel;
		private System.Windows.Forms.Label productNameLabel;
		private System.Windows.Forms.Label copyNoteLabel;
		private System.Windows.Forms.ColumnHeader typeColumnHeader;
		private System.Windows.Forms.ColumnHeader dateColumnHeader;
		private System.Windows.Forms.ColumnHeader keyColumnHeader;
        private System.Windows.Forms.ToolStripLabel toolStripLabelQuery;
        private System.Windows.Forms.ToolStripTextBox TextBoxQuery;
        private System.Windows.Forms.ColumnHeader noteColumnHeader;
    }
}

