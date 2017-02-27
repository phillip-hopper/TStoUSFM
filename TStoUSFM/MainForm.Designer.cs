namespace TS2USFM
{
	partial class MainForm
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this._removeButton = new System.Windows.Forms.Button();
			this._repositoryURL = new System.Windows.Forms.TextBox();
			this._browseButton = new System.Windows.Forms.Button();
			this._repositoryList = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this._outputDirectory = new System.Windows.Forms.TextBox();
			this._goButton = new System.Windows.Forms.Button();
			this._addButton = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this._statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tableLayoutPanel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.CausesValidation = false;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this._removeButton, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this._repositoryURL, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this._browseButton, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this._repositoryList, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this._outputDirectory, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this._goButton, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this._addButton, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 4);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(14, 16, 14, 16);
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 306);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 25);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Repository URL";
			// 
			// _removeButton
			// 
			this._removeButton.AutoSize = true;
			this._removeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._removeButton.Location = new System.Drawing.Point(546, 55);
			this._removeButton.Margin = new System.Windows.Forms.Padding(4);
			this._removeButton.Name = "_removeButton";
			this._removeButton.Size = new System.Drawing.Size(65, 27);
			this._removeButton.TabIndex = 1;
			this._removeButton.Text = "Remove";
			this._removeButton.UseVisualStyleBackColor = true;
			this._removeButton.Click += new System.EventHandler(this._removeButton_Click);
			// 
			// _repositoryURL
			// 
			this._repositoryURL.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._repositoryURL.HideSelection = false;
			this._repositoryURL.Location = new System.Drawing.Point(131, 21);
			this._repositoryURL.Margin = new System.Windows.Forms.Padding(4);
			this._repositoryURL.Multiline = true;
			this._repositoryURL.Name = "_repositoryURL";
			this._repositoryURL.Size = new System.Drawing.Size(407, 25);
			this._repositoryURL.TabIndex = 1;
			// 
			// _browseButton
			// 
			this._browseButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._browseButton.AutoSize = true;
			this._browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._browseButton.Location = new System.Drawing.Point(546, 203);
			this._browseButton.Margin = new System.Windows.Forms.Padding(4);
			this._browseButton.Name = "_browseButton";
			this._browseButton.Size = new System.Drawing.Size(60, 27);
			this._browseButton.TabIndex = 2;
			this._browseButton.Text = "Browse";
			this._browseButton.UseVisualStyleBackColor = true;
			this._browseButton.Click += new System.EventHandler(this._browseButton_Click);
			// 
			// _repositoryList
			// 
			this._repositoryList.Dock = System.Windows.Forms.DockStyle.Top;
			this._repositoryList.FormattingEnabled = true;
			this._repositoryList.ItemHeight = 17;
			this._repositoryList.Location = new System.Drawing.Point(131, 55);
			this._repositoryList.Margin = new System.Windows.Forms.Padding(4);
			this._repositoryList.Name = "_repositoryList";
			this._repositoryList.Size = new System.Drawing.Size(407, 140);
			this._repositoryList.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 208);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Output Directory";
			// 
			// _outputDirectory
			// 
			this._outputDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._outputDirectory.HideSelection = false;
			this._outputDirectory.Location = new System.Drawing.Point(131, 204);
			this._outputDirectory.Margin = new System.Windows.Forms.Padding(4);
			this._outputDirectory.Name = "_outputDirectory";
			this._outputDirectory.Size = new System.Drawing.Size(407, 25);
			this._outputDirectory.TabIndex = 5;
			// 
			// _goButton
			// 
			this._goButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._goButton.AutoSize = true;
			this._goButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._goButton.Location = new System.Drawing.Point(131, 238);
			this._goButton.Margin = new System.Windows.Forms.Padding(4);
			this._goButton.Name = "_goButton";
			this._goButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this._goButton.Size = new System.Drawing.Size(45, 27);
			this._goButton.TabIndex = 6;
			this._goButton.Text = "Go";
			this._goButton.UseVisualStyleBackColor = true;
			this._goButton.Click += new System.EventHandler(this._goButton_Click);
			// 
			// _addButton
			// 
			this._addButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this._addButton.AutoSize = true;
			this._addButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this._addButton.Location = new System.Drawing.Point(546, 20);
			this._addButton.Margin = new System.Windows.Forms.Padding(4);
			this._addButton.Name = "_addButton";
			this._addButton.Size = new System.Drawing.Size(42, 27);
			this._addButton.TabIndex = 0;
			this._addButton.Text = "Add";
			this._addButton.UseVisualStyleBackColor = true;
			this._addButton.Click += new System.EventHandler(this._addButton_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 279);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._statusLabel});
			this.statusStrip1.Location = new System.Drawing.Point(0, 341);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
			this.statusStrip1.Size = new System.Drawing.Size(669, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// _statusLabel
			// 
			this._statusLabel.Name = "_statusLabel";
			this._statusLabel.Size = new System.Drawing.Size(47, 17);
			this._statusLabel.Text = "Ready.";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(669, 363);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Convert tS Repositories to USFM";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox _repositoryURL;
		private System.Windows.Forms.Button _browseButton;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button _addButton;
		private System.Windows.Forms.Button _removeButton;
		private System.Windows.Forms.ListBox _repositoryList;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox _outputDirectory;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel _statusLabel;
		private System.Windows.Forms.Button _goButton;
	}
}