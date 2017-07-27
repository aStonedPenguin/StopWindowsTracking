namespace StopWindowsTracking
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.RunButton = new MetroFramework.Controls.MetroButton();
            this.BloatwareLabel = new MetroFramework.Controls.MetroLabel();
            this.MiscLabel = new MetroFramework.Controls.MetroLabel();
            this.MiscList = new MetroFramework.Controls.MetroListView();
            this.BloatList = new MetroFramework.Controls.MetroListView();
            this.SelectAll1 = new MetroFramework.Controls.MetroCheckBox();
            this.SelectAll2 = new MetroFramework.Controls.MetroCheckBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(7, 475);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(732, 20);
            this.RunButton.TabIndex = 0;
            this.RunButton.Text = "Run";
            this.RunButton.UseSelectable = true;
            this.RunButton.Click += new System.EventHandler(this.run_Click);
            // 
            // BloatwareLabel
            // 
            this.BloatwareLabel.AutoSize = true;
            this.BloatwareLabel.Location = new System.Drawing.Point(7, 60);
            this.BloatwareLabel.Name = "BloatwareLabel";
            this.BloatwareLabel.Size = new System.Drawing.Size(119, 19);
            this.BloatwareLabel.TabIndex = 3;
            this.BloatwareLabel.Text = "Uninstall Bloatware";
            // 
            // MiscLabel
            // 
            this.MiscLabel.AutoSize = true;
            this.MiscLabel.Location = new System.Drawing.Point(375, 60);
            this.MiscLabel.Name = "MiscLabel";
            this.MiscLabel.Size = new System.Drawing.Size(35, 19);
            this.MiscLabel.TabIndex = 1;
            this.MiscLabel.Text = "Misc";
            // 
            // MiscList
            // 
            this.MiscList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MiscList.FullRowSelect = true;
            this.MiscList.Location = new System.Drawing.Point(375, 82);
            this.MiscList.Name = "MiscList";
            this.MiscList.OwnerDraw = true;
            this.MiscList.Size = new System.Drawing.Size(364, 387);
            this.MiscList.TabIndex = 6;
            this.MiscList.UseCompatibleStateImageBehavior = false;
            this.MiscList.UseSelectable = true;
            // 
            // BloatList
            // 
            this.BloatList.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BloatList.FullRowSelect = true;
            this.BloatList.Location = new System.Drawing.Point(7, 82);
            this.BloatList.Name = "BloatList";
            this.BloatList.OwnerDraw = true;
            this.BloatList.Size = new System.Drawing.Size(364, 387);
            this.BloatList.TabIndex = 7;
            this.BloatList.UseCompatibleStateImageBehavior = false;
            this.BloatList.UseSelectable = true;
            // 
            // SelectAll1
            // 
            this.SelectAll1.AutoSize = true;
            this.SelectAll1.Location = new System.Drawing.Point(132, 63);
            this.SelectAll1.Name = "SelectAll1";
            this.SelectAll1.Size = new System.Drawing.Size(71, 15);
            this.SelectAll1.TabIndex = 8;
            this.SelectAll1.Text = "Select All";
            this.SelectAll1.UseSelectable = true;
            this.SelectAll1.CheckStateChanged += new System.EventHandler(this.SelectAll1_CheckedChanged);
            // 
            // SelectAll2
            // 
            this.SelectAll2.AutoSize = true;
            this.SelectAll2.Checked = true;
            this.SelectAll2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectAll2.Location = new System.Drawing.Point(416, 63);
            this.SelectAll2.Name = "SelectAll2";
            this.SelectAll2.Size = new System.Drawing.Size(84, 15);
            this.SelectAll2.TabIndex = 9;
            this.SelectAll2.Text = "Deselect All";
            this.SelectAll2.UseSelectable = true;
            this.SelectAll2.CheckStateChanged += new System.EventHandler(this.SelectAll2_CheckedChanged);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 500);
            this.Controls.Add(this.SelectAll2);
            this.Controls.Add(this.SelectAll1);
            this.Controls.Add(this.BloatList);
            this.Controls.Add(this.MiscList);
            this.Controls.Add(this.BloatwareLabel);
            this.Controls.Add(this.MiscLabel);
            this.Controls.Add(this.RunButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.ShowIcon = false;
            this.Text = "StopWindowsTracking";
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton RunButton;
        private MetroFramework.Controls.MetroLabel BloatwareLabel;
        private MetroFramework.Controls.MetroLabel MiscLabel;
        private MetroFramework.Controls.MetroListView MiscList;
        private MetroFramework.Controls.MetroListView BloatList;
        private MetroFramework.Controls.MetroCheckBox SelectAll1;
        private MetroFramework.Controls.MetroCheckBox SelectAll2;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
    }
}

