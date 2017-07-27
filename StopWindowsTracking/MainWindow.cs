using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Controls;
using StopWindowsTracking.Base;

namespace StopWindowsTracking
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        public MainWindow()
        {
            InitializeComponent();
            MaximizeBox = false;

            BloatList.BeginUpdate();
            BloatList.View = View.List;
            BloatList.ShowGroups = false;
            BloatList.CheckBoxes = true;
            BloatList.ItemChecked += ItemChecked;
            BloatList.ItemSelectionChanged += ItemSelectionChanged;

            ColumnHeader program = BloatList.Columns.Add("Program");
            program.Width = 107;

            foreach (WSBloatware v in WSBloatware.All)
            {
                bool canrun = v.IsInstalled();
                BloatList.Items.Add(new ListViewItem($"{v.Name}{(canrun ? "" : " - N/A")}")
                {
                    Tag = canrun ? v : null,
                });
            }

            BloatList.EndUpdate();

            MiscList.BeginUpdate();
            MiscList.View = View.Details;
            MiscList.CheckBoxes = true;
            MiscList.HeaderStyle = ColumnHeaderStyle.None;
            MiscList.ItemChecked += ItemChecked;
            MiscList.ItemSelectionChanged += ItemSelectionChanged;

            ColumnHeader info = MiscList.Columns.Add("Info");
            info.Width = 325;

            foreach (ICustom v in Method.GetCustom())
            {
                bool canrun = v.CanRun();

                MiscList.Items.Add(new ListViewItem($"{v.GetName()} - {(canrun ? v.GetInfo() : "Method unavailable on this computer")}")
                {
                    Tag = canrun ? v : null,
                    Checked = true
                });
            }

            foreach (IRegEdit v in Method.GetRegEdits())
            {
                bool canrun = false;

                foreach (RegEdit reg in v.GetRegEdits())
                    if (reg.CanRun())
                    {
                        canrun = true;
                        break;
                    }

                MiscList.Items.Add(new ListViewItem($"{v.GetName()} - {(canrun ? v.GetInfo() : "Method unavailable on this computer")}")
                {
                    Tag = canrun ? v : null,
                    Checked = canrun
                });
            }

            MiscList.EndUpdate();
        }

        private void ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Selected)
                e.Item.Selected = false;
        }

        private void ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag == null && e.Item.Checked)
                e.Item.Checked = false;
        }

        private void SelectAll1_CheckedChanged(object sender, EventArgs e)
        {
            bool selected = sender.ToString().EndsWith("1"); // ????

            SelectAll1.Text = selected ? "Deselect all" : "Select all";

            foreach (ListViewItem v in BloatList.Items)
                v.Checked = selected;
        }

        private void SelectAll2_CheckedChanged(object sender, EventArgs e)
        {
            bool selected = sender.ToString().EndsWith("1"); // ????

            SelectAll2.Text = selected ? "Deselect all" : "Select all";

            foreach (ListViewItem v in MiscList.Items)
                v.Checked = selected;
        }

        private void run_Click(object sender, EventArgs e)
        {
            MakeLoadScreen();

            foreach (ListViewItem v in BloatList.CheckedItems)
                (v.Tag as WSBloatware).Uninstall();


            foreach (ListViewItem v in MiscList.CheckedItems)
            {
                Console.WriteLine(v.Tag.GetType());
                foreach (Type iface in v.Tag.GetType().GetInterfaces())
                {
                    if (iface == typeof(ICustom))
                    {
                        ICustom custom = (v.Tag as ICustom);
                        if (custom.CanRun())
                            custom.Run();
                    }
                    else if (iface == typeof(IRegEdit))
                    {
                        foreach (RegEdit reg in (v.Tag as IRegEdit).GetRegEdits())
                            if (reg.CanRun())
                                reg.Run();
                    }
                    break;
                }
            }

            ExitLoadScreen();

            DialogResult res = MessageBox.Show("You need to restart for the changes to take affect. Would you like to restart now?", "Restart?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
                Process.Start(new ProcessStartInfo("shutdown.exe", "-r -t 2"));
            else
                Application.Exit();
        }

        private MetroPanel LoadPanel;
        private MetroProgressSpinner LoadSpinner;
        private MetroLabel LoadLabel;
        private MetroLabel LoadLabel2;

        private void MakeLoadScreen()
        {
            LoadPanel = new MetroPanel();
            LoadSpinner = new MetroProgressSpinner();
            LoadLabel = new MetroLabel();
            LoadLabel2 = new MetroLabel();

            LoadPanel.HorizontalScrollbarBarColor = true;
            LoadPanel.HorizontalScrollbarHighlightOnWheel = false;
            LoadPanel.HorizontalScrollbarSize = 10;
            LoadPanel.Location = new System.Drawing.Point(5, 60);
            LoadPanel.Name = "metroPanel1";
            LoadPanel.Size = new System.Drawing.Size(740, 440);
            LoadPanel.TabIndex = 10;
            LoadPanel.VerticalScrollbarBarColor = true;
            LoadPanel.VerticalScrollbarHighlightOnWheel = false;
            LoadPanel.VerticalScrollbarSize = 10;

            LoadSpinner.Location = new System.Drawing.Point(326, 123);
            LoadSpinner.Maximum = 100;
            LoadSpinner.Name = "metroProgressSpinner1";
            LoadSpinner.Size = new System.Drawing.Size(48, 48);
            LoadSpinner.TabIndex = 2;
            LoadSpinner.UseSelectable = true;

            LoadLabel.AutoSize = true;
            LoadLabel.Location = new System.Drawing.Point(323, 174);
            LoadLabel.Name = "label1";
            LoadLabel.Size = new System.Drawing.Size(55, 15);
            LoadLabel.TabIndex = 3;
            LoadLabel.Text = "Working!";

            LoadLabel2.AutoSize = true;
            LoadLabel2.Location = new System.Drawing.Point(170, 189);
            LoadLabel2.Name = "metroLabel1";
            LoadLabel2.Size = new System.Drawing.Size(367, 19);
            LoadLabel2.TabIndex = 4;
            LoadLabel2.Text = "Please do not exit this program or restart until this is finished!";

            LoadPanel.Controls.Add(LoadSpinner);
            LoadPanel.Controls.Add(LoadLabel);
            LoadPanel.Controls.Add(LoadLabel2);
            Controls.Add(LoadPanel);
            LoadPanel.BringToFront();
        }

        private void ExitLoadScreen()
        {
            LoadSpinner.Dispose();

            LoadLabel.Text = "Finished";
            LoadLabel2.Text = "You need to restart for the changes to take affect!";
        }
    }
}
