using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using FftSharp;
using System.Xml.Linq;
using System.Linq;
using System.Reflection.Emit;
using System.Drawing;


namespace _03251
{
    public partial class Chartview : Form
    {
        Test test;
        APP app;
        private bool isStart = true;
        private Thread dataThread;
        private Thread ChartThread;
        byte[] c = { 0xAB, 0xBA, 0xA1, 0x01, 0x08, 0x00 };
        Thread chartdata;
        private int time = 0;
        Chart chart1;
        Chart chartFFT;
        private bool beginMove = false;
        private int currentXPosition;
        private int currentYPosition;
        int Yrange = 70000;
        int Xrange = 400;
        double xx, yy, zz;
        const double adxlscale = 0.0000039 * 9.81;
        int chartcount = 0;
        private readonly object chartLock = new object();
        private bool isFFT = false;

        public Chartview(string n)
        { 
            InitializeComponent();
            app = new();
           // app.selectPort();
            switch (n)
            {
                case "Chart":
                    Thread.Sleep(50);
                    initchart();
                    break;
                case "FFT":
                    initchart(1);
                    Thread.Sleep(50);
                    InitFFTChart();
                    isFFT = true;
                    break;
            }
        }
        /*......................................init...................................*/
        private void getValue(byte[] c)
        {
            try
            {
                app.WriteByte(c);
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("0" + ex.ToString());
            }
        }

        private void StartChart()
        {
            dataThread = new Thread(ReadDataLoop);
            dataThread.IsBackground = true;
            dataThread.Start();
        }
        private void StartFFTChart()
        {
            ChartThread = new Thread(FFTLoop);
            ChartThread.IsBackground = true;
            ChartThread.Start();
        }
        private void StopChart()
        {
            byte[] c = { 0xAB, 0xBA, 0xA1, 0x00, 0x08, 0x00 };
            app.WriteByte(c);

            Thread.Sleep(50);
            // 停止執行緒
            if (dataThread != null && dataThread.IsAlive)
            {
                isStart = false;
                dataThread.Abort();
            }
            if (isFFT == true)
            {
                if (ChartThread != null && ChartThread.IsAlive)
                {
                    isStart = false;
                    ChartThread.Abort();
                }
            }
        }
        /*.....................................chart....................................*/
        private void initchart(int n = 0)
        {
            switch (n)
            {
                case 0:
                    chart1 = new Chart();
                    chart1.Dock = DockStyle.Fill;

                    // 添加時間軸
                    chart1.ChartAreas.Add(new ChartArea("MainArea"));
                    chart1.ChartAreas["MainArea"].AxisX.Title = "Time";
                    chart1.ChartAreas["MainArea"].AxisY.Title = "Value";

                    chart1.ChartAreas["MainArea"].AxisX.Enabled = AxisEnabled.True;
                    chart1.ChartAreas["MainArea"].AxisY.Enabled = AxisEnabled.True;

                    // 添加系列
                    chart1.Series.Add("X");
                    chart1.Series.Add("Y");
                    chart1.Series.Add("Z");

                    // 設置系列類型
                    chart1.Series["X"].ChartType = SeriesChartType.FastLine;
                    chart1.Series["Y"].ChartType = SeriesChartType.FastLine;
                    chart1.Series["Z"].ChartType = SeriesChartType.FastLine;

                    // 設置系列顏色
                    chart1.Series["X"].Color = System.Drawing.Color.Red;
                    chart1.Series["Y"].Color = System.Drawing.Color.Green;
                    chart1.Series["Z"].Color = System.Drawing.Color.Blue;
                    chart1.Series["X"].BorderWidth = 1;
                    chart1.Series["Y"].BorderWidth = 1;
                    chart1.Series["Z"].BorderWidth = 1;

                    // 添加橫軸最小值和最大值
                    chart1.ChartAreas["MainArea"].AxisX.Minimum = 0;
                    chart1.ChartAreas["MainArea"].AxisX.Maximum = 400;

                    // 添加縱軸最小值和最大值
                    chart1.ChartAreas["MainArea"].AxisY.Minimum = -70000;
                    chart1.ChartAreas["MainArea"].AxisY.Maximum = Yrange;
                    chart1.ChartAreas["MainArea"].AxisY.LabelStyle.Enabled = false;
                    // 添加到窗體控制項
                    pnl_main.Controls.Add(chart1);
                    btn_down.FlatStyle = FlatStyle.Flat;
                    btn_exit.FlatStyle = FlatStyle.Flat;
                    btn_stop.FlatStyle = FlatStyle.Flat;
                    btn_xu.FlatStyle = FlatStyle.Flat;
                    btn_xd.FlatStyle = FlatStyle.Flat;
                    btn_UP.FlatStyle = FlatStyle.Flat;
                    break;
                case 1:
                    chart1 = new Chart();
                    chart1.Dock = DockStyle.Fill;

                    // 添加時間軸
                    chart1.ChartAreas.Add(new ChartArea("MainArea"));
                    chart1.ChartAreas["MainArea"].AxisX.Title = "Time";
                    chart1.ChartAreas["MainArea"].AxisY.Title = "Value";

                    chart1.ChartAreas["MainArea"].AxisX.Enabled = AxisEnabled.True;
                    chart1.ChartAreas["MainArea"].AxisY.Enabled = AxisEnabled.True;

                    // 添加系列
                    chart1.Series.Add("X");
                    chart1.Series.Add("Y");
                    chart1.Series.Add("Z");

                    // 設置系列類型
                    chart1.Series["X"].ChartType = SeriesChartType.FastLine;
                    chart1.Series["Y"].ChartType = SeriesChartType.FastLine;
                    chart1.Series["Z"].ChartType = SeriesChartType.FastLine;

                    // 設置系列顏色
                    chart1.Series["X"].Color = System.Drawing.Color.Red;
                    chart1.Series["Y"].Color = System.Drawing.Color.Green;
                    chart1.Series["Z"].Color = System.Drawing.Color.Blue;
                    chart1.Series["X"].BorderWidth = 1;
                    chart1.Series["Y"].BorderWidth = 1;
                    chart1.Series["Z"].BorderWidth = 1;

                    // 添加橫軸最小值和最大值
                    chart1.ChartAreas["MainArea"].AxisX.Minimum = 0;
                    chart1.ChartAreas["MainArea"].AxisX.Maximum = 400;

                    // 添加縱軸最小值和最大值
                    chart1.ChartAreas["MainArea"].AxisY.Minimum = -70000;
                    chart1.ChartAreas["MainArea"].AxisY.Maximum = Yrange;
                    chart1.ChartAreas["MainArea"].AxisY.LabelStyle.Enabled = false;
                    // 添加到窗體控制項
                    pnl_main.Controls.Add(chart1);
                    chart1.Visible = false;
                    btn_down.FlatStyle = FlatStyle.Flat;
                    btn_exit.FlatStyle = FlatStyle.Flat;
                    btn_stop.FlatStyle = FlatStyle.Flat;
                    btn_xu.FlatStyle = FlatStyle.Flat;
                    btn_xd.FlatStyle = FlatStyle.Flat;
                    btn_UP.FlatStyle = FlatStyle.Flat;
                    lbl_ax.Text = "X-FT:";
                    lbl_ay.Text = "Y-FT:";
                    lbl_az.Text = "Z-FT:";
                    break;
            }
        }
        private void ReadDataLoop()
        {
            byte[] tempX = new byte[4];
            byte[] tempY = new byte[4];
            byte[] tempZ = new byte[4];
            int readCounter = 0;
            try
            {
                APP.serialport.DiscardInBuffer();
                Console.WriteLine("DiscardInBufferFinish");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            while (isStart)
            {
                if (APP.temp != null)
                {
                    byte[] combinedBuffer = app.GetXYZ();
                    if (combinedBuffer.Length > 8)
                    {
                        for (int i = 0; i < combinedBuffer.Length / 3 / 3; i++)
                        {
                            byte[] temp = new byte[4];
                            temp[3] = combinedBuffer[i * 9];
                            temp[2] = combinedBuffer[i * 9 + 1];
                            temp[1] = combinedBuffer[i * 9 + 2];
                            temp[0] = 0;
                            tempX = temp;
                            temp = new byte[4];
                            temp[3] = combinedBuffer[i * 9 + 3];
                            temp[2] = combinedBuffer[i * 9 + 4];
                            temp[1] = combinedBuffer[i * 9 + 5];
                            temp[0] = 0;
                            tempY = temp;
                            temp = new byte[4];
                            temp[3] = combinedBuffer[i * 9 + 6];
                            temp[2] = combinedBuffer[i * 9 + 7];
                            temp[1] = combinedBuffer[i * 9 + 8];
                            temp[0] = 0;
                            tempZ = temp;
                            //if (readCounter > 0)
                            //{
                                int x = BitConverter.ToInt32(tempX, 0);// 1750999;
                                int y = BitConverter.ToInt32(tempY, 0);// 1750999;
                                int z = BitConverter.ToInt32(tempZ, 0);// 1750999;
                                
                                xx = x * adxlscale;
                                yy = y * adxlscale;
                                zz = z * adxlscale;
                                chartthedata(xx, yy, zz);
                          //  }
                        }
                    }
                    //double x = test.GenerateNextSample();

                    //double x = 20000 * Math.Sin(Radians((1) * time));
                    //double y = 20000 * Math.Sin(Radians((2) * time));
                    //tchartthedata(x,y);
                    //Console.WriteLine("x:" + x + ",y:" + y);
                    //for (int i = 0; i < 128; i++)
                    //{
                    //    double y = 20000 * Math.Sin(2 * Math.PI * 40 * 0.01 * i);
                    //    tchartthedata(y);
                    //}
                    //// 每次迴圈增加時間
                    //time += 1;
                    //  Thread.Sleep(10);// 假設每次增加 0.1 秒
                    //  Thread.Sleep(100);
                    readCounter++;
                }
                else
                {
                    Console.WriteLine("NoDataToChart");
                }
            }
        }
        //const double pi = Math.PI;
        //private double Radians(double x)
        //{
        //    return x * pi / 180;
        //}
        //private void tchartthedata(double x)
        //{
        //    lock (chartLock)
        //    {
        //        chart1.Invoke((MethodInvoker)delegate
        //        {
        //            chart1.Series["X"].Points.Add(x);
        //            chart1.Series["Y"].Points.Add(0);
        //            chart1.Series["Z"].Points.Add(0);

        //            if (chart1.Series["X"].Points.Count > Xrange)
        //            {
        //                chart1.Series["X"].Points.RemoveAt(0);
        //                chart1.Series["Y"].Points.RemoveAt(0);
        //                chart1.Series["Z"].Points.RemoveAt(0);
        //            }
        //            time++;
        //            chart1.Update();
        //            chartcount++;
        //        });
        //    }
        //}
        private void chartthedata(double x, double y, double z)
        {
            lock (chartLock)
            {
                chart1.Invoke((MethodInvoker)delegate
                {
                    chart1.Series["X"].Points.Add(x);
                    chart1.Series["Y"].Points.Add(y);
                    chart1.Series["Z"].Points.Add(z);

                    if (chart1.Series["X"].Points.Count > Xrange)
                    {
                        chart1.Series["X"].Points.RemoveAt(0);
                        chart1.Series["Y"].Points.RemoveAt(0);
                        chart1.Series["Z"].Points.RemoveAt(0);
                    }
                    time++;
                    chart1.Update();
                    chartcount++;
                });
            }
        }
        /*......................................FFT.....................................*/
        double FFTXrange=512;
        int FFTYrange = 2000000;
        private void InitFFTChart()
        {
            tbx_fft.Text = "5";
            chartFFT = new Chart();
            chartFFT.Dock = DockStyle.Fill;
            chartFFT.ChartAreas.Add(new ChartArea("FFTArea"));
            chartFFT.ChartAreas["FFTArea"].AxisX.Title = "Frequency";
            chartFFT.ChartAreas["FFTArea"].AxisX.Maximum=FFTXrange;
            // chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = FFTXrange;
            chartFFT.ChartAreas["FFTArea"].AxisX.Interval = 50;
            chartFFT.ChartAreas["FFTArea"].AxisY.Title = "Amplitude";
            chartFFT.ChartAreas["FFTArea"].AxisY.Maximum = FFTYrange*5;
            tbx_fft.Visible = true;
            btn_xl.Visible= true;
            btn_xr.Visible= true;
            // 添加到窗体控件
            pnl_main.Controls.Add(chartFFT);
        }
        private void DisplayFrequencyDomain(double[] xData, double[] yData, double[] zData)
        {
            lock (chartLock)
            {
                chartFFT.Invoke((MethodInvoker)delegate
                {
                    chartFFT.Series.Clear();

                    Series seriesX = new Series();
                    seriesX.ChartType = SeriesChartType.Line;
                    seriesX.Color = System.Drawing.Color.Red;

                    Series seriesY = new Series();
                    seriesY.ChartType = SeriesChartType.Line;
                    seriesY.Color = System.Drawing.Color.Green;

                    Series seriesZ = new Series();
                    seriesZ.ChartType = SeriesChartType.Line;
                    seriesZ.Color = System.Drawing.Color.Blue;

                    Complex[] fftResult_X = ZeroPadData(xData);
                    Complex[] fftResult_Y = ZeroPadData(yData);
                    Complex[] fftResult_Z = ZeroPadData(zData);

                    if (fftResult_X.Length >= 512)
                    {
                        FourierTransform(fftResult_X);
                        FourierTransform(fftResult_Y);
                        FourierTransform(fftResult_Z);

                        for (int i = 0; i < fftResult_X.Length; i++)
                        {
                            seriesX.Points.AddXY(i * 1000 / 512, fftResult_X[i].Magnitude);
                            seriesY.Points.AddXY(i * 1000 / 512, fftResult_Y[i].Magnitude);
                            seriesZ.Points.AddXY(i * 1000 / 512, fftResult_Z[i].Magnitude);
                        }
                        chartFFT.Series.Add(seriesX);
                        chartFFT.Series.Add(seriesY);
                        chartFFT.Series.Add(seriesZ);
                    }
                });
            }
        }
        private Complex[] ZeroPadData(double[] data)
        {
            int originalLength = data.Length;
            int paddedLength = 1;
            while (paddedLength < originalLength)
            {
                paddedLength *= 2;
            }
            Complex[] paddedData = new Complex[paddedLength];
            for (int i = 0; i < originalLength; i++)
            {
                    paddedData[i] = new Complex(data[i], 0);
            }
            return paddedData;
        }
        private void FourierTransform(Complex[] data)
        {
            FftSharp.Transform.FFT(data);
        }
        private void FFTLoop()
        {
            while (isStart)
            {
                try
                {
                    // 获取X、Y、Z轴数据
                    double[] xData = chart1.Series["X"].Points.Select(point => point.YValues[0]).ToArray();
                    double[] yData = chart1.Series["Y"].Points.Select(point => point.YValues[0]).ToArray();
                    double[] zData = chart1.Series["Z"].Points.Select(point => point.YValues[0]).ToArray();
                    // 在FFT图表上显示结果
                        DisplayFrequencyDomain(xData, yData, zData);
                }
                catch (Exception e)
                {
                    Console.WriteLine("0");
                    //MessageBox.Show(e.Message);
                }
            }
        }
        /*...................................UI.........................................*/
        private void btn_Start_Click(object sender, EventArgs e)
        {
            getValue(c);
            Thread.Sleep(50);
            if (isFFT == false)
            {
                StartChart();
            }
            if (isFFT == true)
            {
                StartChart();
                StartFFTChart();
            }
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
            StopChart();
        }
        private void btn_UP_Click(object sender, EventArgs e)
        {
            if (isFFT == false)
            {
                Yrange = Yrange + 3000;
                chart1.ChartAreas["MainArea"].AxisY.Maximum = Yrange;
                chart1.Invalidate();
            }
            if (isFFT == true)
            {
                FFTYrange =FFTYrange+2000000;
                chartFFT.ChartAreas["FFTArea"].AxisY.Maximum = FFTYrange;
                chartFFT.Invalidate();
            }
        }
        private void btn_down_Click(object sender, EventArgs e)
        {
            if (isFFT == false)
            {
                if (Yrange > 69999)
                {
                    Yrange = Yrange - 3000;
                }
                chart1.ChartAreas["MainArea"].AxisY.Maximum = Yrange;
                chart1.Invalidate();
            }
            if (isFFT == true)
            {
                if (FFTYrange > 10000000)
                {
                    FFTYrange=FFTYrange-2000000;
                }
                chartFFT.ChartAreas["FFTArea"].AxisY.Maximum = FFTYrange;
                chartFFT.Invalidate();
            }
        }
        private void btn_xd_Click(object sender, EventArgs e)
        {
            if (isFFT == false)
            {
                if (Xrange > 100)
                {
                    Xrange = Xrange - 100;
                }
                chart1.ChartAreas["MainArea"].AxisX.Maximum = Xrange;
                chart1.Invalidate();
            }
            if (isFFT == true)
            {
                if (FFTXrange > 0)
                {
                    FFTXrange = FFTXrange - Int32.Parse(tbx_fft.Text);
                }
                // 設置滾動軸的最大值和位置
                chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = FFTXrange;
                chartFFT.ChartAreas["FFTArea"].AxisX.ScaleView.Position = FFTXrange;
                // 重繪圖表
                chartFFT.Invalidate();
            }
        }
        private void btn_xu_Click(object sender, EventArgs e)
        {
            if (isFFT == false)
            {
                if (Xrange < 1001)
                {
                    Xrange = Xrange + 100;
                }
                chart1.ChartAreas["MainArea"].AxisX.Maximum = Xrange;
                chart1.Invalidate();
            }
            if (isFFT == true)
            {
                if (FFTXrange < 255)
                {
                    FFTXrange = FFTXrange + 3;
                }
                chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = FFTXrange;
                chartFFT.Invalidate();
            }
        }
        private void btn_xl_Click(object sender, EventArgs e)
        {
            if (isFFT == true)
            {
                double n = chartFFT.ChartAreas["FFTArea"].AxisX.Minimum;
                double nn = chartFFT.ChartAreas["FFTArea"].AxisX.Maximum;
                chartFFT.ChartAreas["FFTArea"].AxisX.Minimum = n - 5;
                chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = nn - 5;
            }
            // 設置滾動軸的最大值和位置
            //chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = FFTXrange;
            //chartFFT.ChartAreas["FFTArea"].AxisX.ScaleView.Position = FFTXrange;
            // 重繪圖表
            chartFFT.Invalidate();
        }
        private void btn_xr_Click(object sender, EventArgs e)
        {
            if (isFFT == true)
            {
                double n = chartFFT.ChartAreas["FFTArea"].AxisX.Minimum;
                double nn = chartFFT.ChartAreas["FFTArea"].AxisX.Maximum;
                chartFFT.ChartAreas["FFTArea"].AxisX.Minimum = n + 5;
                chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = nn + 5;
            }
            // 設置滾動軸的最大值和位置
            //chartFFT.ChartAreas["FFTArea"].AxisX.Maximum = FFTXrange;
            //chartFFT.ChartAreas["FFTArea"].AxisX.ScaleView.Position = FFTXrange;
            // 重繪圖表
            chartFFT.Invalidate();
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lbl_x_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void RichtextboxScroll()
        {
            chart1.Invoke((MethodInvoker)delegate
            {
                rtb_console.Select();
                rtb_console.Select(rtb_console.TextLength, 0);
                rtb_console.ScrollToCaret();
            });
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
        private void Chartview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStart != false)
            {
                StopChart();
            }
            Thread.Sleep(50);
        }
    }
}
