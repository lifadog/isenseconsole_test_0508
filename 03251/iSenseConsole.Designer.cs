namespace _03251
{
    partial class iSenseConsole
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_main = new System.Windows.Forms.Panel();
            this.lbl_exit = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.msp_main = new System.Windows.Forms.MenuStrip();
            this.tsm_file = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batteryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getRTCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSenserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_interface = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_simulator = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_localserver = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_control = new System.Windows.Forms.DataGridView();
            this.rtb_info = new System.Windows.Forms.RichTextBox();
            this.rtb_console = new System.Windows.Forms.RichTextBox();
            this.pnl_console = new System.Windows.Forms.Panel();
            this.pnl_info = new System.Windows.Forms.Panel();
            this.lbl_by = new System.Windows.Forms.Label();
            this.pnl_main.SuspendLayout();
            this.msp_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_control)).BeginInit();
            this.pnl_console.SuspendLayout();
            this.pnl_info.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_main
            // 
            this.pnl_main.BackColor = System.Drawing.Color.White;
            this.pnl_main.Controls.Add(this.lbl_exit);
            this.pnl_main.Controls.Add(this.lbl_title);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_main.Location = new System.Drawing.Point(0, 0);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1116, 100);
            this.pnl_main.TabIndex = 0;
            this.pnl_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pnl_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pnl_main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lbl_exit
            // 
            this.lbl_exit.AutoSize = true;
            this.lbl_exit.Font = new System.Drawing.Font("Courier New", 20F);
            this.lbl_exit.Location = new System.Drawing.Point(724, 26);
            this.lbl_exit.Name = "lbl_exit";
            this.lbl_exit.Size = new System.Drawing.Size(29, 30);
            this.lbl_exit.TabIndex = 1;
            this.lbl_exit.Text = "X";
            this.lbl_exit.Click += new System.EventHandler(this.lbl_exit_Click);
            this.lbl_exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lbl_exit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.lbl_exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Courier New", 20F);
            this.lbl_title.Location = new System.Drawing.Point(28, 26);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(525, 30);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "iSenseConsole V1.0 beta 25032420";
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.lbl_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btn_exit
            // 
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(1019, 358);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(85, 80);
            this.btn_exit.TabIndex = 1;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // msp_main
            // 
            this.msp_main.AutoSize = false;
            this.msp_main.BackColor = System.Drawing.Color.Black;
            this.msp_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.msp_main.Dock = System.Windows.Forms.DockStyle.None;
            this.msp_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_file,
            this.tsm_interface,
            this.tsm_simulator,
            this.tsm_localserver});
            this.msp_main.Location = new System.Drawing.Point(0, 103);
            this.msp_main.Name = "msp_main";
            this.msp_main.Size = new System.Drawing.Size(304, 24);
            this.msp_main.TabIndex = 2;
            this.msp_main.Text = "menuStrip1";
            // 
            // tsm_file
            // 
            this.tsm_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.setRTCToolStripMenuItem,
            this.batteryToolStripMenuItem,
            this.getRTCToolStripMenuItem,
            this.getSenserToolStripMenuItem,
            this.setRateToolStripMenuItem});
            this.tsm_file.ForeColor = System.Drawing.Color.White;
            this.tsm_file.Name = "tsm_file";
            this.tsm_file.Size = new System.Drawing.Size(38, 20);
            this.tsm_file.Text = "File";
            this.tsm_file.DropDownClosed += new System.EventHandler(this.tsm_file_DropDownClosed);
            this.tsm_file.DropDownOpened += new System.EventHandler(this.tsm_file_DropDownOpened);
            this.tsm_file.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.tsm_file.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.minimizeToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.exitToolStripMenuItem.Text = "Transfer";
            this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.exitToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // setRTCToolStripMenuItem
            // 
            this.setRTCToolStripMenuItem.Name = "setRTCToolStripMenuItem";
            this.setRTCToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.setRTCToolStripMenuItem.Text = "SetRTC";
            this.setRTCToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.setRTCToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // batteryToolStripMenuItem
            // 
            this.batteryToolStripMenuItem.Name = "batteryToolStripMenuItem";
            this.batteryToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.batteryToolStripMenuItem.Text = "Battery";
            this.batteryToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.batteryToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // getRTCToolStripMenuItem
            // 
            this.getRTCToolStripMenuItem.Name = "getRTCToolStripMenuItem";
            this.getRTCToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.getRTCToolStripMenuItem.Text = "GetRTC";
            this.getRTCToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.getRTCToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // getSenserToolStripMenuItem
            // 
            this.getSenserToolStripMenuItem.Name = "getSenserToolStripMenuItem";
            this.getSenserToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.getSenserToolStripMenuItem.Text = "GetSensor";
            this.getSenserToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.getSenserToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // setRateToolStripMenuItem
            // 
            this.setRateToolStripMenuItem.Name = "setRateToolStripMenuItem";
            this.setRateToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.setRateToolStripMenuItem.Text = "Set Rate";
            this.setRateToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_file_MouseLeave);
            this.setRateToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_file_MouseMove);
            // 
            // tsm_interface
            // 
            this.tsm_interface.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.viewRecordToolStripMenuItem});
            this.tsm_interface.ForeColor = System.Drawing.Color.White;
            this.tsm_interface.Name = "tsm_interface";
            this.tsm_interface.Size = new System.Drawing.Size(68, 20);
            this.tsm_interface.Text = "Interface";
            this.tsm_interface.DropDownClosed += new System.EventHandler(this.tsm_interface_DropDownClosed);
            this.tsm_interface.DropDownOpening += new System.EventHandler(this.tsm_interface_DropDownOpening);
            this.tsm_interface.DropDownOpened += new System.EventHandler(this.tsm_interface_DropDownOpened);
            this.tsm_interface.MouseLeave += new System.EventHandler(this.tsm_interface_MouseLeave);
            this.tsm_interface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_interface_MouseMove);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            this.addToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_interface_MouseLeave);
            this.addToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_interface_MouseMove);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            this.removeToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_interface_MouseLeave);
            this.removeToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_interface_MouseMove);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_interface_MouseLeave);
            this.loadToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_interface_MouseMove);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_interface_MouseLeave);
            this.saveToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_interface_MouseMove);
            // 
            // viewRecordToolStripMenuItem
            // 
            this.viewRecordToolStripMenuItem.Name = "viewRecordToolStripMenuItem";
            this.viewRecordToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.viewRecordToolStripMenuItem.Text = "View Record";
            this.viewRecordToolStripMenuItem.MouseLeave += new System.EventHandler(this.tsm_interface_MouseLeave);
            this.viewRecordToolStripMenuItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tsm_interface_MouseMove);
            // 
            // tsm_simulator
            // 
            this.tsm_simulator.Enabled = false;
            this.tsm_simulator.ForeColor = System.Drawing.Color.White;
            this.tsm_simulator.Name = "tsm_simulator";
            this.tsm_simulator.Size = new System.Drawing.Size(73, 20);
            this.tsm_simulator.Text = "Simulator";
            // 
            // tsm_localserver
            // 
            this.tsm_localserver.Enabled = false;
            this.tsm_localserver.ForeColor = System.Drawing.Color.White;
            this.tsm_localserver.Name = "tsm_localserver";
            this.tsm_localserver.Size = new System.Drawing.Size(88, 20);
            this.tsm_localserver.Text = "Locat Server";
            // 
            // dgv_control
            // 
            this.dgv_control.AllowUserToAddRows = false;
            this.dgv_control.AllowUserToDeleteRows = false;
            this.dgv_control.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_control.Location = new System.Drawing.Point(12, 143);
            this.dgv_control.Name = "dgv_control";
            this.dgv_control.RowTemplate.Height = 24;
            this.dgv_control.Size = new System.Drawing.Size(459, 150);
            this.dgv_control.TabIndex = 3;
            // 
            // rtb_info
            // 
            this.rtb_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_info.Font = new System.Drawing.Font("Courier New", 9F);
            this.rtb_info.Location = new System.Drawing.Point(25, 3);
            this.rtb_info.Name = "rtb_info";
            this.rtb_info.ReadOnly = true;
            this.rtb_info.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_info.Size = new System.Drawing.Size(204, 196);
            this.rtb_info.TabIndex = 4;
            this.rtb_info.Text = "";
            // 
            // rtb_console
            // 
            this.rtb_console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_console.Location = new System.Drawing.Point(60, 16);
            this.rtb_console.Name = "rtb_console";
            this.rtb_console.ReadOnly = true;
            this.rtb_console.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_console.Size = new System.Drawing.Size(335, 76);
            this.rtb_console.TabIndex = 5;
            this.rtb_console.Text = "";
            // 
            // pnl_console
            // 
            this.pnl_console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_console.Controls.Add(this.rtb_console);
            this.pnl_console.Location = new System.Drawing.Point(31, 311);
            this.pnl_console.Name = "pnl_console";
            this.pnl_console.Size = new System.Drawing.Size(440, 112);
            this.pnl_console.TabIndex = 6;
            // 
            // pnl_info
            // 
            this.pnl_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_info.Controls.Add(this.rtb_info);
            this.pnl_info.Location = new System.Drawing.Point(497, 106);
            this.pnl_info.Name = "pnl_info";
            this.pnl_info.Size = new System.Drawing.Size(256, 205);
            this.pnl_info.TabIndex = 7;
            // 
            // lbl_by
            // 
            this.lbl_by.AutoSize = true;
            this.lbl_by.Font = new System.Drawing.Font("Forte", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_by.Location = new System.Drawing.Point(1004, 328);
            this.lbl_by.Name = "lbl_by";
            this.lbl_by.Size = new System.Drawing.Size(89, 22);
            this.lbl_by.TabIndex = 8;
            this.lbl_by.Text = "BYCDEV";
            // 
            // iSenseConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 450);
            this.Controls.Add(this.lbl_by);
            this.Controls.Add(this.pnl_info);
            this.Controls.Add(this.pnl_console);
            this.Controls.Add(this.dgv_control);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.msp_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.msp_main;
            this.Name = "iSenseConsole";
            this.Text = "iSenseConsole";
            this.pnl_main.ResumeLayout(false);
            this.pnl_main.PerformLayout();
            this.msp_main.ResumeLayout(false);
            this.msp_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_control)).EndInit();
            this.pnl_console.ResumeLayout(false);
            this.pnl_info.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lbl_exit;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.MenuStrip msp_main;
        private System.Windows.Forms.ToolStripMenuItem tsm_file;
        private System.Windows.Forms.ToolStripMenuItem tsm_interface;
        private System.Windows.Forms.ToolStripMenuItem tsm_simulator;
        private System.Windows.Forms.ToolStripMenuItem tsm_localserver;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setRTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batteryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getRTCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSenserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRecordToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgv_control;
        private System.Windows.Forms.RichTextBox rtb_info;
        private System.Windows.Forms.RichTextBox rtb_console;
        private System.Windows.Forms.Panel pnl_console;
        private System.Windows.Forms.Panel pnl_info;
        private System.Windows.Forms.Label lbl_by;
    }
}

