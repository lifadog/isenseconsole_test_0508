using Code4Bugs.Utils.Types;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Windows.Forms.DataVisualization.Charting;

namespace _03251
{
    public partial class iSenseConsole : Form
    {
        APP app = new APP();
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        private static string port;
        bool isconnect = false;
        byte[] moduleset = { 0xAB, 0xBA, 0xA2, 0x40, 0x08, 0x00 };
        byte[] wlanset = { 0xAB, 0xBA, 0xA2, 0x43, 0x08, 0x00 };
        byte[] NODEset = { 0xAB, 0xBA, 0xA2, 0x00, 0x08, 0x00 };
        byte[] accelset = { 0xAB, 0xBA, 0xA2, 0x01, 0x08, 0x00 };
        byte[] timeset = { 0xAB, 0xBA, 0xA2, 0x02, 0x08, 0x00 };
        byte[] fftset = { 0xAB, 0xBA, 0xA2, 0x04, 0x08, 0x00 };

        public iSenseConsole()
        {
            InitializeComponent();
            initForm();
         //   initColor_1();
          //  initdgv();
            initrtb();
            initdgvitem();
            dgv_control.CellContentClick += Dgv_control_CellContentClick;
            dgv_control.EditingControlShowing += dgv_control_EditingControlShowing;
        }
        private void initdgvitem()
        {
            dgv_control.RowHeadersVisible = false;
            dgv_control.AllowUserToResizeColumns = false;
            dgv_control.AllowUserToResizeRows = false;
            int dgvw = dgv_control.Width * 1 / 11;
            dgv_control.Columns.AddRange
              (
              new DataGridViewTextBoxColumn() { HeaderText = "Action", Name = "col_Action", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Cstr", Name = "col_Cstr", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Model", Name = "col_Model", Width = dgvw + 4 },
              new DataGridViewTextBoxColumn() { HeaderText = "Config", Name = "col_Config", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Get", Name = "col_Get", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Set", Name = "col_Set", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Operation", Name = "col_Operation", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Chart", Name = "col_Chart", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "Log", Name = "col_Log", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "FFT", Name = "col_FFT", Width = dgvw },
              new DataGridViewTextBoxColumn() { HeaderText = "PID", Name = "col_PID", Width = dgvw }
             );
            addItem();
            initcbb();
        }
        private void addItem()
        {
            dgv_control.Rows.Add();
            dgv_control.Rows[0].Cells["col_Action"] = new DataGridViewButtonCell() { Value = "connect", Tag = "btn_connect" };
            dgv_control.Rows[0].Cells["col_Cstr"] = new DataGridViewComboBoxCell() { Tag = "cbb_com" };
            dgv_control.Rows[0].Cells["col_Model"] = new DataGridViewTextBoxCell();
            dgv_control.Rows[0].Cells["col_Config"] = new DataGridViewComboBoxCell() { Tag = "cbb_config" };
            DataGridViewComboBoxCell configComboBoxCell = (DataGridViewComboBoxCell)dgv_control.Rows[0].Cells["col_Config"];
            configComboBoxCell.Items.Add("Module");
            configComboBoxCell.Items.Add("Wlan Set");
            configComboBoxCell.Items.Add("Accel");
            configComboBoxCell.Items.Add("NODE");
            configComboBoxCell.Items.Add("Time Set");
            configComboBoxCell.Items.Add("FREQ");
            for (int i = 4; i < dgv_control.Columns.Count - 1; i++) // 第四列开始是按钮列，不包括最后一列的文本框列
            {
                string buttonName = "";
                string buttonText = "";
                switch (dgv_control.Columns[i].Name)
                {
                    case "col_Get":
                        buttonName = "btn_refresh";
                        buttonText = "Refresh";
                        break;
                    case "col_Set":
                        buttonName = "btn_set";
                        buttonText = "Set";
                        break;
                    case "col_Operation":
                        buttonName = "btn_start";
                        buttonText = "Start";
                        break;
                    case "col_Chart":
                        buttonName = "btn_chartview";
                        buttonText = "ChartView";
                        break;
                    case "col_Log":
                        buttonName = "btn_log";
                        buttonText = "Log";
                        break;
                    case "col_FFT":
                        buttonName = "btn_fft";
                        buttonText = "FFT";
                        break;
                }
                dgv_control.Rows[0].Cells[i] = new DataGridViewButtonCell() { Value = buttonText, Tag = buttonName ,FlatStyle=FlatStyle.Flat};
            }
            dgv_control.Rows[0].Cells["col_PID"] = new DataGridViewTextBoxCell() { Value = "Text" };
        }
        private void btnadditem()
        {
            int newRowIdx = dgv_control.Rows.AddCopy(0);
            dgv_control.Rows[newRowIdx].Cells["col_Action"] = new DataGridViewButtonCell() { Value = "connect", Tag = "btn_connect" };
            dgv_control.Rows[newRowIdx].Cells["col_Cstr"] = new DataGridViewComboBoxCell() { Tag = "cbb_com" };
            dgv_control.Rows[newRowIdx].Cells["col_Model"] = new DataGridViewTextBoxCell();
            dgv_control.Rows[newRowIdx].Cells["col_Config"] = new DataGridViewComboBoxCell() { Tag = "cbb_config" };
            DataGridViewComboBoxCell configComboBoxCell = (DataGridViewComboBoxCell)dgv_control.Rows[newRowIdx].Cells["col_Config"];
            configComboBoxCell.Items.Add("Module");
            configComboBoxCell.Items.Add("Wlan Set");
            configComboBoxCell.Items.Add("Accel");
            configComboBoxCell.Items.Add("NODE");
            configComboBoxCell.Items.Add("Time Set");
            configComboBoxCell.Items.Add("FREQ");
            for (int i = 4; i < dgv_control.Columns.Count - 1; i++)
            {
                string buttonName = "";
                string buttonText = "";
                switch (dgv_control.Columns[i].Name)
                {
                    case "col_Get":
                        buttonName = "btn_refresh";
                        buttonText = "Refresh";
                        break;
                    case "col_Set":
                        buttonName = "btn_set";
                        buttonText = "Set";
                        break;
                    case "col_Operation":
                        buttonName = "btn_start";
                        buttonText = "Start";
                        break;
                    case "col_Chart":
                        buttonName = "btn_chartview";
                        buttonText = "ChartView";
                        break;
                    case "col_Log":
                        buttonName = "btn_log";
                        buttonText = "Log";
                        break;
                    case "col_FFT":
                        buttonName = "btn_fft";
                        buttonText = "FFT";
                        break;
                }
                dgv_control.Rows[newRowIdx].Cells[i] = new DataGridViewButtonCell() { Value = buttonText, Tag = buttonName , FlatStyle = FlatStyle.Flat };
            }
            dgv_control.Rows[newRowIdx].Cells["col_PID"] = new DataGridViewTextBoxCell() { Value = "Text" };
            initcbb(newRowIdx);
        }
        private void initForm()
        {
            pnl_main.Height = 30;
            msp_main.Location = new Point(0, 30);
            msp_main.Width = pnl_main.Width;
            this.Font = new Font("Courier New", 9);
            lbl_title.Location = new Point(1, 4);
            lbl_title.Font = new Font(lbl_exit.Font, FontStyle.Bold);
            lbl_exit.Location = new Point(ClientSize.Width - 30, 5);
            lbl_exit.Font = new Font(lbl_exit.Font, FontStyle.Bold);
            dgv_control.Location = new Point(0, pnl_main.Height + msp_main.Height);
            dgv_control.Size = new Size(ClientSize.Width * 4 / 5, ClientSize.Height * 1 / 2);
            pnl_info.Location = new Point(dgv_control.Width + 1, pnl_main.Height + msp_main.Height);
            pnl_info.Size = new Size(ClientSize.Width - dgv_control.Width, dgv_control.Height);
            pnl_console.Location = new Point(0, pnl_main.Height + msp_main.Height + dgv_control.Height + 1);
            pnl_console.Size = new Size(ClientSize.Width * 4 / 5, ClientSize.Height - dgv_control.Height - msp_main.Height - pnl_main.Height - 3);
            btn_exit.Location = new Point(ClientSize.Width - btn_exit.Width - 75, ClientSize.Height - btn_exit.Height - 30);
            rtb_info.Location = new Point(1, 1);
            rtb_info.Size = new Size(ClientSize.Width - dgv_control.Width - 4, dgv_control.Height - 4);
            rtb_console.Location = new Point(1, 1);
            rtb_console.Size = new Size(pnl_console.Size.Width - 4, pnl_console.Size.Height - 4);
            pnl_console.Controls.Add(rtb_console);
            pnl_info.Controls.Add(rtb_info);
            lbl_by.Location = new Point(btn_exit.Location.X, btn_exit.Location.Y - 40);
        }
        private void initdgv()
        {
            DataGridViewCellStyle headstyle = new DataGridViewCellStyle();
            headstyle.BackColor = Color.DarkSlateGray;
            headstyle.ForeColor = Color.White;
        }
        private void initColor_1()
        {
            dgv_control.BackgroundColor = Color.LightSeaGreen;
            this.BackColor = Color.LightSeaGreen;
            pnl_main.BackColor = Color.DarkSlateGray;
            pnl_main.ForeColor = Color.White;
            pnl_console.BackColor = Color.Black;
            pnl_console.BorderStyle = BorderStyle.FixedSingle;
            pnl_info.BackColor = Color.Black;
            pnl_info.BorderStyle = BorderStyle.FixedSingle;
            rtb_console.BackColor = Color.DarkSlateGray;
            rtb_console.ForeColor = Color.White;
            rtb_info.BackColor = Color.DarkSlateGray;
            rtb_info.ForeColor = Color.White;
            msp_main.BackColor= Color.LightSeaGreen;
        }
        private void initrtb()
        {
            pnl_console.Controls.Add(rtb_console);
            pnl_info.Controls.Add(rtb_info);

        }
        private void initcbb(int index = 0)
        {
            string[] ports = APP.GetPort();
            DataGridViewComboBoxCell cbbcom = new DataGridViewComboBoxCell();

            if (ports.Length == 0)
            {
                cbbcom.Items.Add("No SerialPorts Found");
            }
            else
            {
                foreach (string port in ports)
                {
                    cbbcom.Items.Add(port);
                }
            }
            foreach (DataGridViewRow row in dgv_control.Rows)
            {
                if (row.Index == index)
                {
                    row.Cells["col_Cstr"] = cbbcom.Clone() as DataGridViewComboBoxCell;
                }
            }
            dgv_control.CellValueChanged += dgv_control_CellValueChanged; // 添加事件处理程序

            // 如果 ComboBox 儲存格不為空並且有選中的項目，則顯示所選內容
            DataGridViewComboBoxCell comboBoxCell = dgv_control.Rows[index].Cells["col_Cstr"] as DataGridViewComboBoxCell;
            if (comboBoxCell != null && comboBoxCell.Items.Count > 0)
            {
                dgv_control.Rows[index].Cells["col_Cstr"].Value = comboBoxCell.Items[0];
            }
            // 更新 port 的值为所选串口
            UpdatePortValue(index);
        }
        private void dgv_control_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_control.Columns["col_Cstr"].Index && e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell comboBoxCell = dgv_control.Rows[e.RowIndex].Cells["col_Cstr"] as DataGridViewComboBoxCell;
                if (comboBoxCell != null && comboBoxCell.Value != null)
                {
                    port = comboBoxCell.Value.ToString();
                }
            }
        }
        private void UpdatePortValue(int index = 0)
        {
            DataGridViewComboBoxCell comboBoxCell = dgv_control.Rows[index].Cells["col_Cstr"] as DataGridViewComboBoxCell;
            if (comboBoxCell != null && comboBoxCell.Value != null)
            {
                port = comboBoxCell.Value.ToString();
            }
        }
        private void dgv_control_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= comboBox_SelectedIndexChanged; // 先取消訂閱事件，以避免重複訂閱
                comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged; // 訂閱事件
            }
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //app.countsum(command);

            ComboBox comboBox = sender as ComboBox;

            string selectedValue = comboBox.SelectedItem.ToString(); // 獲取選擇的項目值
            if (selectedValue == "Module")
            {
                rtb_info.Clear();
                rtb_info.AppendText(app.info(moduleset));
            }
            if (selectedValue == "Wlan Set")
            {
                rtb_info.Clear();
                rtb_info.AppendText(app.info(wlanset));
            }
            if (selectedValue == "Accel")
            {
                rtb_info.Clear();
                rtb_info.AppendText(app.info(accelset));
            }
            if (selectedValue == "NODE")
            {
                rtb_info.Clear();
                rtb_info.AppendText(app.info(NODEset));
            }
            if (selectedValue == "Time Set")
            {
                rtb_info.Clear();
                rtb_info.AppendText(app.info(timeset));
            }
            if (selectedValue == "FREQ")
            {
                rtb_info.Clear();
                rtb_info.AppendText(app.info(fftset));
            }
        }
        private void Dgv_control_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // 确保点击的是单元格而不是表头
            {
                // 获取点击的单元格
                DataGridViewCell cell = dgv_control.Rows[e.RowIndex].Cells[e.ColumnIndex];

                // 检查单元格是否为按钮单元格，并且是 btn_connect 按钮
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_connect")
                {
                    if (isconnect == false)
                    {
                        app.selectPort(port);
                        if (APP.serialport.IsOpen)
                        {
                            rtb_console.AppendText(port.ToString() + " Connect" + Environment.NewLine);
                            isconnect = true;
                            cell.Value = "Disconnect";

                            DataGridViewComboBoxCell configComboBoxCell = dgv_control.Rows[e.RowIndex].Cells["col_Config"] as DataGridViewComboBoxCell;
                            if (configComboBoxCell != null && configComboBoxCell.Items.Count > 0)
                            {
                                configComboBoxCell.Value = configComboBoxCell.Items[0];
                            }

                            rtb_info.Clear();
                            rtb_info.AppendText(app.info(moduleset));

                            Thread.Sleep(10);
                            dgv_control.Rows[e.RowIndex].Cells["col_Model"].Value = DataNode.redevicename();
                            return;
                        }
                        else
                        {
                            rtb_console.AppendText(port.ToString() + " Connect Fail" + Environment.NewLine);
                            isconnect = false;
                            return;
                        }
                    }
                    if (APP.serialport.IsOpen && isconnect == true)
                    {
                        rtb_console.AppendText(port.ToString() + " DisConnect" + Environment.NewLine);
                        APP.serialport.Close();
                        dgv_control.Rows[e.RowIndex].Cells["col_Model"].Value = "";
                        cell.Value = "Connect";
                        isconnect = false;
                    }
                }
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_refresh")
                {

                }
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_set")
                {

                    MessageBox.Show("test");
                }
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_start")
                {

                    MessageBox.Show("test");
                }
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_chartview")
                {
                    Chartview c = new("Chart");
                    c.Show();
                }
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_log")
                {

                    MessageBox.Show("test");
                }
                if (cell is DataGridViewButtonCell && cell.Tag != null && cell.Tag.ToString() == "btn_fft")
                {
                    Chartview c = new("FFT");
                    c.Show();
                }
            }
        }
        private void Exit()
        {
            this.Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                beginMove = true;
                currentXPosition = MousePosition.X; //滑鼠的 X 座標為當前窗體左上角 X 座標參考
                currentYPosition = MousePosition.Y; //滑鼠的 Y 座標為當前窗體左上角 Y 座標參考
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition; //根據滑鼠的 X 座標確定窗體的 X 座標
                this.Top += MousePosition.Y - currentYPosition; //根據滑鼠的 Y 座標確定窗體的 Y 座標
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //設定初始狀態
                currentYPosition = 0; //設定初始狀態
                beginMove = false;
            }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void lbl_exit_Click(object sender, EventArgs e)
        {
            Exit();
        }
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnadditem();
        }
        private void tsm_file_MouseMove(object sender, MouseEventArgs e)
        {
            tsm_file.ForeColor = Color.Black;
        }
        private void tsm_file_MouseLeave(object sender, EventArgs e)
        {
            tsm_file.ForeColor = Color.White;
        }
        private void tsm_file_DropDownOpened(object sender, EventArgs e)
        {
            tsm_file.ForeColor = Color.Black;
        }
        private void tsm_file_DropDownClosed(object sender, EventArgs e)
        {
            tsm_file.ForeColor = Color.White;
        }
        private void tsm_interface_MouseMove(object sender, MouseEventArgs e)
        {
            tsm_interface.ForeColor = Color.Black;
        }
        private void tsm_interface_MouseLeave(object sender, EventArgs e)
        {
            tsm_interface.ForeColor = Color.White;
        }
        private void tsm_interface_DropDownClosed(object sender, EventArgs e)
        {
            tsm_interface.ForeColor = Color.White;
        }
        private void tsm_interface_DropDownOpened(object sender, EventArgs e)
        {
            tsm_interface.ForeColor = Color.Black;
        }
        private void tsm_interface_DropDownOpening(object sender, EventArgs e)
        {
            tsm_interface.ForeColor = Color.Black;
        }
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_control.Rows.Count > 1)
            {
                dgv_control.Rows.RemoveAt(dgv_control.Rows.Count - 1);
            }
        }
    }
}
