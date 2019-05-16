namespace Lab6
{
    partial class SettingsDialog
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
            this.penColor = new System.Windows.Forms.ListBox();
            this.fillColor = new System.Windows.Forms.ListBox();
            this.penWidth = new System.Windows.Forms.ListBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.fillBox = new System.Windows.Forms.CheckBox();
            this.outlineBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // penColor
            // 
            this.penColor.FormattingEnabled = true;
            this.penColor.ItemHeight = 20;
            this.penColor.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.penColor.Location = new System.Drawing.Point(34, 86);
            this.penColor.Name = "penColor";
            this.penColor.Size = new System.Drawing.Size(120, 104);
            this.penColor.TabIndex = 0;
            this.penColor.SelectedIndexChanged += new System.EventHandler(this.penColor_SelectedIndexChanged);
            // 
            // fillColor
            // 
            this.fillColor.FormattingEnabled = true;
            this.fillColor.ItemHeight = 20;
            this.fillColor.Items.AddRange(new object[] {
            "White",
            "Black",
            "Red",
            "Blue",
            "Green"});
            this.fillColor.Location = new System.Drawing.Point(205, 86);
            this.fillColor.Name = "fillColor";
            this.fillColor.Size = new System.Drawing.Size(120, 104);
            this.fillColor.TabIndex = 1;
            this.fillColor.SelectedIndexChanged += new System.EventHandler(this.fillColor_SelectedIndexChanged);
            // 
            // penWidth
            // 
            this.penWidth.FormattingEnabled = true;
            this.penWidth.ItemHeight = 20;
            this.penWidth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.penWidth.Location = new System.Drawing.Point(380, 86);
            this.penWidth.Name = "penWidth";
            this.penWidth.Size = new System.Drawing.Size(120, 204);
            this.penWidth.TabIndex = 2;
            this.penWidth.SelectedIndexChanged += new System.EventHandler(this.penWidth_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(198, 362);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(127, 31);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(373, 362);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 31);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // fillBox
            // 
            this.fillBox.AutoSize = true;
            this.fillBox.Location = new System.Drawing.Point(137, 266);
            this.fillBox.Name = "fillBox";
            this.fillBox.Size = new System.Drawing.Size(54, 24);
            this.fillBox.TabIndex = 6;
            this.fillBox.Text = "Fill";
            this.fillBox.UseVisualStyleBackColor = true;
            this.fillBox.CheckedChanged += new System.EventHandler(this.fillBox_CheckedChanged);
            // 
            // outlineBox
            // 
            this.outlineBox.AutoSize = true;
            this.outlineBox.Checked = true;
            this.outlineBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outlineBox.Location = new System.Drawing.Point(137, 306);
            this.outlineBox.Name = "outlineBox";
            this.outlineBox.Size = new System.Drawing.Size(85, 24);
            this.outlineBox.TabIndex = 7;
            this.outlineBox.Text = "Outline";
            this.outlineBox.UseVisualStyleBackColor = true;
            this.outlineBox.CheckedChanged += new System.EventHandler(this.outlineBox_CheckedChanged);
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 450);
            this.ControlBox = false;
            this.Controls.Add(this.outlineBox);
            this.Controls.Add(this.fillBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.penWidth);
            this.Controls.Add(this.fillColor);
            this.Controls.Add(this.penColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SettingsDialog_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox penColor;
        private System.Windows.Forms.ListBox fillColor;
        private System.Windows.Forms.ListBox penWidth;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox fillBox;
        private System.Windows.Forms.CheckBox outlineBox;
    }
}