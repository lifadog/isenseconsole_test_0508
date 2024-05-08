using System.Windows.Forms.VisualStyles;

namespace _03251
{
    partial class Chartview
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.rtb_console = new System.Windows.Forms.RichTextBox();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.lbl_azz = new System.Windows.Forms.Label();
            this.lbl_az = new System.Windows.Forms.Label();
            this.lbl_ayy = new System.Windows.Forms.Label();
            this.lbl_ay = new System.Windows.Forms.Label();
            this.lbl_axx = new System.Windows.Forms.Label();
            this.lbl_ax = new System.Windows.Forms.Label();
            this.pnl_title = new System.Windows.Forms.Panel();
            this.lbl_x = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_UP = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_xd = new System.Windows.Forms.Button();
            this.btn_xu = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_xl = new System.Windows.Forms.Button();
            this.btn_xr = new System.Windows.Forms.Button();
            this.tbx_fft = new System.Windows.Forms.TextBox();
            this.pnl_title.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(230, 570);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(94, 47);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stop.Location = new System.Drawing.Point(121, 570);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(94, 47);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // rtb_console
            // 
            this.rtb_console.Enabled = false;
            this.rtb_console.Location = new System.Drawing.Point(1091, 159);
            this.rtb_console.Name = "rtb_console";
            this.rtb_console.Size = new System.Drawing.Size(39, 20);
            this.rtb_console.TabIndex = 3;
            this.rtb_console.Text = "";
            this.rtb_console.Visible = false;
            // 
            // pnl_main
            // 
            this.pnl_main.Location = new System.Drawing.Point(12, 50);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1076, 514);
            this.pnl_main.TabIndex = 4;
            // 
            // lbl_azz
            // 
            this.lbl_azz.AutoSize = true;
            this.lbl_azz.BackColor = System.Drawing.Color.Blue;
            this.lbl_azz.Location = new System.Drawing.Point(621, 587);
            this.lbl_azz.Name = "lbl_azz";
            this.lbl_azz.Size = new System.Drawing.Size(8, 12);
            this.lbl_azz.TabIndex = 5;
            this.lbl_azz.Text = " ";
            // 
            // lbl_az
            // 
            this.lbl_az.AutoSize = true;
            this.lbl_az.Location = new System.Drawing.Point(592, 587);
            this.lbl_az.Name = "lbl_az";
            this.lbl_az.Size = new System.Drawing.Size(23, 12);
            this.lbl_az.TabIndex = 4;
            this.lbl_az.Text = "AZ:";
            // 
            // lbl_ayy
            // 
            this.lbl_ayy.AutoSize = true;
            this.lbl_ayy.BackColor = System.Drawing.Color.Green;
            this.lbl_ayy.Location = new System.Drawing.Point(578, 587);
            this.lbl_ayy.Name = "lbl_ayy";
            this.lbl_ayy.Size = new System.Drawing.Size(8, 12);
            this.lbl_ayy.TabIndex = 3;
            this.lbl_ayy.Text = " ";
            // 
            // lbl_ay
            // 
            this.lbl_ay.AutoSize = true;
            this.lbl_ay.Location = new System.Drawing.Point(548, 587);
            this.lbl_ay.Name = "lbl_ay";
            this.lbl_ay.Size = new System.Drawing.Size(24, 12);
            this.lbl_ay.TabIndex = 2;
            this.lbl_ay.Text = "AY:";
            // 
            // lbl_axx
            // 
            this.lbl_axx.AutoSize = true;
            this.lbl_axx.BackColor = System.Drawing.Color.Red;
            this.lbl_axx.Location = new System.Drawing.Point(534, 587);
            this.lbl_axx.Name = "lbl_axx";
            this.lbl_axx.Size = new System.Drawing.Size(8, 12);
            this.lbl_axx.TabIndex = 1;
            this.lbl_axx.Text = " ";
            // 
            // lbl_ax
            // 
            this.lbl_ax.AutoSize = true;
            this.lbl_ax.Location = new System.Drawing.Point(504, 587);
            this.lbl_ax.Name = "lbl_ax";
            this.lbl_ax.Size = new System.Drawing.Size(24, 12);
            this.lbl_ax.TabIndex = 0;
            this.lbl_ax.Text = "AX:";
            // 
            // pnl_title
            // 
            this.pnl_title.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnl_title.Controls.Add(this.lbl_x);
            this.pnl_title.Controls.Add(this.lbl_title);
            this.pnl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_title.Location = new System.Drawing.Point(0, 0);
            this.pnl_title.Name = "pnl_title";
            this.pnl_title.Size = new System.Drawing.Size(1139, 27);
            this.pnl_title.TabIndex = 5;
            this.pnl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.pnl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.pnl_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lbl_x
            // 
            this.lbl_x.AutoSize = true;
            this.lbl_x.Font = new System.Drawing.Font("Century Schoolbook", 11F);
            this.lbl_x.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_x.Location = new System.Drawing.Point(1120, 3);
            this.lbl_x.Name = "lbl_x";
            this.lbl_x.Size = new System.Drawing.Size(19, 18);
            this.lbl_x.TabIndex = 1;
            this.lbl_x.Text = "X";
            this.lbl_x.Click += new System.EventHandler(this.lbl_x_Click);
            this.lbl_x.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lbl_x.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.lbl_x.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Century Schoolbook", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(3, 3);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(49, 18);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Chart";
            this.lbl_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.lbl_title.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.lbl_title.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btn_UP
            // 
            this.btn_UP.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_UP.Location = new System.Drawing.Point(1094, 185);
            this.btn_UP.Name = "btn_UP";
            this.btn_UP.Size = new System.Drawing.Size(36, 39);
            this.btn_UP.TabIndex = 6;
            this.btn_UP.Text = "十";
            this.btn_UP.UseVisualStyleBackColor = true;
            this.btn_UP.Click += new System.EventHandler(this.btn_UP_Click);
            // 
            // btn_down
            // 
            this.btn_down.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_down.Location = new System.Drawing.Point(1094, 230);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(36, 39);
            this.btn_down.TabIndex = 7;
            this.btn_down.Text = "一";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_xd
            // 
            this.btn_xd.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_xd.Location = new System.Drawing.Point(1052, 578);
            this.btn_xd.Name = "btn_xd";
            this.btn_xd.Size = new System.Drawing.Size(36, 39);
            this.btn_xd.TabIndex = 8;
            this.btn_xd.Text = "一";
            this.btn_xd.UseVisualStyleBackColor = true;
            this.btn_xd.Click += new System.EventHandler(this.btn_xd_Click);
            // 
            // btn_xu
            // 
            this.btn_xu.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_xu.Location = new System.Drawing.Point(1094, 578);
            this.btn_xu.Name = "btn_xu";
            this.btn_xu.Size = new System.Drawing.Size(36, 39);
            this.btn_xu.TabIndex = 9;
            this.btn_xu.Text = "十";
            this.btn_xu.UseVisualStyleBackColor = true;
            this.btn_xu.Click += new System.EventHandler(this.btn_xu_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Location = new System.Drawing.Point(12, 570);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(94, 47);
            this.btn_Start.TabIndex = 10;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_xl
            // 
            this.btn_xl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xl.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_xl.Location = new System.Drawing.Point(401, 578);
            this.btn_xl.Name = "btn_xl";
            this.btn_xl.Size = new System.Drawing.Size(36, 39);
            this.btn_xl.TabIndex = 11;
            this.btn_xl.Text = "←";
            this.btn_xl.UseVisualStyleBackColor = true;
            this.btn_xl.Visible = false;
            this.btn_xl.Click += new System.EventHandler(this.btn_xl_Click);
            // 
            // btn_xr
            // 
            this.btn_xr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_xr.Font = new System.Drawing.Font("微軟正黑體", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_xr.Location = new System.Drawing.Point(443, 578);
            this.btn_xr.Name = "btn_xr";
            this.btn_xr.Size = new System.Drawing.Size(36, 39);
            this.btn_xr.TabIndex = 12;
            this.btn_xr.Text = "→";
            this.btn_xr.UseVisualStyleBackColor = true;
            this.btn_xr.Visible = false;
            this.btn_xr.Click += new System.EventHandler(this.btn_xr_Click);
            // 
            // tbx_fft
            // 
            this.tbx_fft.Location = new System.Drawing.Point(998, 587);
            this.tbx_fft.Name = "tbx_fft";
            this.tbx_fft.Size = new System.Drawing.Size(48, 22);
            this.tbx_fft.TabIndex = 13;
            this.tbx_fft.Visible = false;
            // 
            // Chartview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(1139, 629);
            this.Controls.Add(this.tbx_fft);
            this.Controls.Add(this.btn_xr);
            this.Controls.Add(this.btn_xl);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_xu);
            this.Controls.Add(this.btn_xd);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_UP);
            this.Controls.Add(this.lbl_azz);
            this.Controls.Add(this.pnl_title);
            this.Controls.Add(this.lbl_az);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.lbl_ayy);
            this.Controls.Add(this.rtb_console);
            this.Controls.Add(this.lbl_ay);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lbl_axx);
            this.Controls.Add(this.lbl_ax);
            this.Controls.Add(this.btn_exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Chartview";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chartview_FormClosing);
            this.pnl_title.ResumeLayout(false);
            this.pnl_title.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ChartFFT_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.RichTextBox rtb_console;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Panel pnl_title;
        private System.Windows.Forms.Label lbl_azz;
        private System.Windows.Forms.Label lbl_az;
        private System.Windows.Forms.Label lbl_ayy;
        private System.Windows.Forms.Label lbl_ay;
        private System.Windows.Forms.Label lbl_axx;
        private System.Windows.Forms.Label lbl_ax;
        private System.Windows.Forms.Label lbl_x;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button btn_UP;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_xd;
        private System.Windows.Forms.Button btn_xu;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_xl;
        private System.Windows.Forms.Button btn_xr;
        private System.Windows.Forms.TextBox tbx_fft;
    }
}