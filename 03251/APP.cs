using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using NModbus;
using System.Windows.Forms;
using System.Data;
using Code4Bugs.Utils.Types;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;
using System.Threading;


namespace _03251
{
    
    public class Constants
    {
        public const byte HEADER_SIZE = 0x08;
        public const byte MAGIC1 = 0xab;
        public const byte MAGIC2 = 0xba;
        public const byte MASK_CMD = 0xa0;
        public const byte MASK_DATA = 0x30;
        public const byte MASK_CMD_RET_OK = 0x50;
        public const byte MASK_CMD_RET_ERR = 0x51;
        public const byte MASK_CMD_RET_BUSY = 0x52;
        public const byte MASK_CMD_RET_CFG = 0x5F;
        public const byte CMD_CONTROL = 0x01;
        public const byte CMD_SETUP = 0x02;
        public const byte CMD_FS = 0x03;
        public const byte CMD_SYS = 0x0C;
        public const byte NOCRC_MASK = 0x80;
        public const byte CONTROL_STOP = 0x00;
        public const byte CONTROL_START = 0x01;
        public const byte CMD_SETUP_SAVE = 0xff;
        public const byte MODE_SINGLE = 0x00;
        public const byte MODE_STREAMING = 0x01;
        public const byte MODE_CHARACTER = 0x02;
        public const byte MODE_INCLINE = 0x03;
        public const byte MODE_DISP = 0x04;
        public const byte Control = 0xA1;
        public const byte Setup = 0xA2;
        public const byte Storage = 0xA3;
        List<byte> DeviceData;
        public struct Header
        {
            public byte magic1;
            public byte magic2;
            public byte type;
            public byte pid;
            public byte lenlow;
            public byte lenhigh;
            public byte sumlow;
            public byte sumhigh;
            public int StartIndex;
        }
        public bool checkbyteLength(byte[] b)
        {
            if (b.Length > 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Header DataWork(byte[] b)
        {
            Header Dataheader;
            int headerStartIndex = 0;
            if ((b[0] == MAGIC1) && (b[1] == MAGIC2))
            {
                Dataheader.magic1 = b[headerStartIndex];
                Dataheader.magic2 = b[headerStartIndex + 1];
                Dataheader.type = b[headerStartIndex + 2];
                Dataheader.pid = b[headerStartIndex + 3];
                Dataheader.lenlow = b[headerStartIndex + 4];
                Dataheader.lenhigh = b[headerStartIndex + 5];
                Dataheader.sumlow = b[headerStartIndex + 6];
                Dataheader.sumhigh = b[headerStartIndex + 7];
                Dataheader.StartIndex = headerStartIndex;
                return Dataheader;
            }
            else
            {
                Console.WriteLine("Noheader");
                return new Header { magic1 = 0xFF, magic2 = 0xFF, type = 0xFF, pid = 0xFF, lenlow = 0xFF, lenhigh = 0xFF, sumlow = 0xFF, sumhigh = 0xFF, StartIndex = 0 };
            }
        }
        public static int loopcount = 0;
        public static Int64 InputDataCount = 0;
        public static int outputruscount = 0;
        public static int ReadHeader = 0;
        public bool islist;
        public void ListData(byte[] b)
        {
            DeviceData = new List<byte>(b);
            if (DeviceData != null)
            {
                if (DeviceData.Contains(MAGIC1) && HaveMagic(DeviceData))
                {
                    int Magic1index = DeviceData.IndexOf(MAGIC1);
                    if (Magic1index != 0)
                    {
     //                   Console.WriteLine("FirstMagicIndex: " + Magic1index);
                    }
                    int count = b.Length / 296;
                    byte[] rus = new byte[296];
                     //Console.WriteLine("List.Length: " + b.Length+" , Header Count: "+count);
     //               Thread.Sleep(512);
                    for (int i = 0; i < count; i++)
                    {
                        rus = DeviceData.GetRange(Magic1index,296).ToArray();
                        //Console.WriteLine(rus[3]);
                        if (DeviceData.IndexOf(MAGIC1, 0) == 0 && DeviceData.IndexOf(MAGIC2, 0) == 1)
                        {
                            // APP.temp=decodeData(rus);
                            
                            APP.SetTemp(decodeData(rus));
                            if (checkpid != 255)
                            {
                                checkpid++;
                            }
                            else if(checkpid ==255)
                            {
                                //Console.WriteLine("CheckPIDCount255NoLose");
                                checkpid = 0;
                            }
                            ReadHeader++;
                            loopcount++;
                            //Console.WriteLine("loop: " + loopcount);
                            //Console.WriteLine("list.NOW.length: " + DeviceData.Count + " Magic Count: " + ReadHeader);
                        }
                        DeviceData.RemoveRange(0, 296);
                    }
                    if (DeviceData.Count == 0)
                    {
                        //Console.WriteLine("FInish List THE DATA!!!!!!!!!!!!!!!!!!!");
                        //Console.WriteLine("Final loop: " + loopcount);
                        //Console.WriteLine("Final list.NOW.length: " + DeviceData.Count + " Magic Count: " + ReadHeader);
                    }
                    islist = true;
                    loopcount = 0;
                    ReadHeader = 0;
                }
            }

            InputDataCount++;
            Console.WriteLine("DeviceToPcCount : " + InputDataCount);
            Console.WriteLine("...............................................List...................................................");
            outputruscount = 0;
        }

        public bool HaveMagic(List<byte> L)
        {

            if (L.IndexOf(MAGIC1, 0) == L.IndexOf(MAGIC2, 0) - 1)
            {
                Console.WriteLine("ThisDataHaveMagic!!!");
                return true;
            }
            else
            {
                Console.WriteLine("ThisDataNOMAGIC!!QQ");
                return false;
            }
        }
        public int checklength(byte b4, byte b5)
        {
            int length = (b5 << 8) + b4;
            return length;
        }
        public int CheckDataLength(Header h)
        {
            if (h.lenlow != 0xFF && h.lenhigh != 0xFF)
            {
                byte b4 = h.lenlow;
                byte b5 = h.lenhigh;
                int dataLength = checklength(b4, b5);
                return dataLength;
            }
            else
            {
                return 0;
            }
        }
        public bool CompareChecksum(Header h, byte[] data, int datalength)
        {
            if (datalength != 0)
            {
                int sum = 0;

                for (int i = 0; i < 6; i++)
                {
                    sum += data[i];
                }
                ushort checksum = (ushort)sum;
                sum = 0;

                for (int i = 8; i < datalength; i++)
                {
                    sum += data[i];
                }
                checksum += (ushort)sum;

                byte calculatedB6 = (byte)(checksum & 0xFF);
                byte calculatedB7 = (byte)((checksum >> 8) & 0xFF);

                if (h.sumlow == calculatedB6 && h.sumhigh == calculatedB7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //.....................https://github.com/lifadog/iSenseConsole_test.git...........................//
        public string getV(byte a, byte b)
        {
            return "B4: " + a.ToString("X2") + ", B5: " + b.ToString("X2") + " .";
        }
        int checkpid = 0;
        public byte[] decodeData(byte[] c)
        {
            if (c == null || c.Length == 0 || c.All(x => x == 0))
            {
                Console.WriteLine("Input byte array is empty or all elements are zero.");
                byte[] e = new byte[] { 0x00 };
                return e;
            }
         //   byte[] b = new byte[296];
            Header h = DataWork(c);
            Console.WriteLine("PID: " +Convert.ToInt32(h.pid));
            if (h.pid != checkpid)
            {
                Console.WriteLine("LTP");
            }
            int length = CheckDataLength(h);
            int startindex = h.StartIndex;
            if (CompareChecksum(h, c, length) == true && length >= 296)
            {
                if (startindex + length <= c.Length)
                {
                    byte[] rus = new byte[length-8];
                    for (int i = startindex + 8; i < startindex + length; i++)
                    {                        
                        rus[i - 8] = c[i];
                    }
                    //       Thread.Sleep(10);
             //       Console.WriteLine(c[12] + "," + c[13]);
                    return rus;
                    
                }
                else
                {
                    byte[] e = new byte[0];
                    return e;
                }
            }
            else
            {
                byte[] e = new byte[0];
                return e;
            }
        }
    }
    internal class APP
    {
        public static SerialPort serialport;
        Constants constants = new Constants();
        public static byte[] temp= { 0x00 };
        public static byte[] t;
        public APP()
        {
        }
        public static string[] GetPort()
        {
            return SerialPort.GetPortNames();
        }
        private void Serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                t = new byte[sp.BytesToRead];
                int i =sp.BytesToRead;
                constants.islist = false;
                if (i % 296 == 0)
                {
                    Console.WriteLine("This Data is N*296");
                }
                if (i % 296 != 0)
                {
                    Console.WriteLine("Length:" + i + " This Data isn't N*296");
                }
                sp.Read(t, 0, t.Length);
        //        Thread.Sleep(110);
                if (t.Length > 8)
                {
                    Thread.Sleep(300);
                    constants.ListData(t);
                    if(constants.islist==true)
                    {
                        //Console.WriteLine("Read finish");
                        //Console.WriteLine("...................botton..................");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return;
            }
        }
        public void WriteByte(byte[] b)
        {
            try
            {
                byte[] rus = countsum(b);
                serialport.Write(rus, 0, 8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void SetTemp(byte[] b)
        {
            temp = b;
            Constants.outputruscount++;
           // Console.WriteLine("OupPutRusCount: " + Constants.outputruscount);
        }
        public byte[] GetXYZ()
        {
            return temp;
        }

        public string info(byte[] c)
        {
            byte[] command = c;
            if (serialport != null)
            {
                try
                {
                    serialport.Write(countsum(command), 0, 8);
                    System.Threading.Thread.Sleep(100);
                    byte[] responseData = new byte[serialport.BytesToRead];
                    serialport.Read(responseData, 0, responseData.Length);
                    //  string deviceName = ParseDeviceName(responseData);
                    DataNode d = new(responseData);
                    return d.getresult();
                }
                catch (Exception e)
                {
                    return "fail";
                }
            }
            else
            {
                return "fail";
            }
        }
        public byte[] countsum(byte[] b)
        {
            byte[] firstcom = b;
            int sum = 0;
            for (int i = 0; i < 6; i++)
            {
                sum += firstcom[i];
            }
            ushort checksum = (ushort)sum;
            byte[] completeCommand = new byte[firstcom.Length + 2];
            Array.Copy(firstcom, completeCommand, firstcom.Length);
            completeCommand[firstcom.Length] = (byte)(checksum & 0xFF);
            completeCommand[firstcom.Length + 1] = (byte)((checksum >> 8) & 0xFF);
            return completeCommand;
        }
        public string ParseDeviceName(byte[] responseData)
        {
            string asciiString = "";
            string hexString = "";
            for (int i = 0; i < responseData.Length; i++)
            {
                hexString += responseData[i].ToString("X2") + " ";
            }
            return hexString + "\n" + asciiString;
        }
        public void selectPort(string n = "COM12")
        {
            string selectport = n;
            serialport = new SerialPort(selectport);
            serialport.BaudRate = 115200;
            serialport.DataBits = 8;
            serialport.Parity = Parity.None;
            serialport.StopBits = StopBits.One;
            serialport.ReceivedBytesThreshold = 296;
            serialport.WriteTimeout = 500;
            serialport.RtsEnable = true;
            serialport.DataReceived += new SerialDataReceivedEventHandler(Serialport_DataReceived);
            Task connectTask = Task.Run(() => Connect());
            Task timeoutTask = Task.Delay(2000);
            Task result = Task.WhenAny(connectTask, timeoutTask).Result;
            if (result == timeoutTask)
            {
                MessageBox.Show("Connect Timeout","iSenseConsole",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void Connect()
        {
            try
            {
                serialport.Open();
              //  MessageBox.Show(serialport.ToString());
                if (serialport.IsOpen == false)
                {
                    Console.WriteLine("TimeOut");
                    return;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("TimeOut");
                return;
            }
        }
    }
    public class DataNode
    {
        string res;
        public DataNode(byte[] b)
        {
            res = switchcase(b);
        }
        public string getresult()
        {
            return res;
        }
        private string switchcase(byte[] b)
        {
            string result = "";

            switch (b[3]) // 假設根據第一個字節進行判斷
            {
                case 0x40:
                    result = ModuleSet(b);
                    break;
                case 0x43:
                    result = WlanSet(b);
                    break;
                case 0x01:
                    result = Accel(b);
                    break;
                case 0x02:
                    result = Timeset(b);
                    break;
                case 0x04:
                    result = FFTset(b);
                    break;
                case 0x00:
                    result = ParseSensorConfig(b);
                    break;
                default:
                    MessageBox.Show("Unknown command.");
                    break;
            }
            return result;
        }
        private static string DeviceName;
        public static string redevicename()
        {
            return DeviceName;
        }
        private string ModuleSet(byte[] b)
        {
            string result = "";

            string EPROMv = BitConverter.ToString(b.Skip(8).Take(4).ToArray()).Replace("-", "");
            string devicename = Encoding.ASCII.GetString(b, 12, 32).TrimEnd('\0');
            DeviceName = devicename;
            string vernum = BitConverter.ToInt32(b, 44).ToString("X8");
            string serialnumber = BitConverter.ToInt32(b, 48).ToString("X8");
            string vender = Encoding.ASCII.GetString(b, 52, 32).TrimEnd('\0');
            string user = Encoding.ASCII.GetString(b, 84, 32).TrimEnd('\0');

            // 構建返回字符串，包含標題和資料
            result += $"EPROM version:\t{EPROMv.PadLeft(12)}\n";
            result += $"Device name:\t{devicename.PadLeft(19)}\n";
            result += $"VerNum number:\t{vernum.PadLeft(12)}\n";
            result += $"Serial number:\t{serialnumber.PadLeft(12)}\n";
            result += $"Vender:\t\t{vender.PadLeft(12)}\n";
            result += $"User:\t\t{user.PadLeft(19)}\n";


            return result;
        }
        private string WlanSet(byte[] b)
        {
            string result = "";

            // 根據說明，從字節數組中提取各個字段的數據
            string wlanMode = b[8] == 0x00 ? "AP" : "STA";
            string apModeSsidPrefix = Encoding.ASCII.GetString(b, 9, 16).TrimEnd('\0');
            string apModePassword = Encoding.ASCII.GetString(b, 25, 16).TrimEnd('\0');
            string staModeSsid = Encoding.ASCII.GetString(b, 41, 16).TrimEnd('\0');
            string staModePassword = Encoding.ASCII.GetString(b, 57, 16).TrimEnd('\0');
            short connectionTimeout = BitConverter.ToInt16(b, 74);
            byte secType = b[75];
            string pairedInfo = BitConverter.ToString(b, 76, 32).TrimEnd('\0');

            // 構建返回字符串，包含標題和資料
            result += $"Mode:" + $"{wlanMode.PadLeft(30)}\n";
            result += $"AP SSID:" + $"{apModeSsidPrefix.PadLeft(27)}\n";
            result += $"AP Password:" + $"{apModePassword.PadLeft(23)}\n";
            result += $"STA SSID:" + $"{staModeSsid.PadLeft(26)}\n";
            result += $"STA Ppassword:" + $"{staModePassword.PadLeft(21)}\n";
            result += $"Timeout:" + $"{connectionTimeout.ToString().PadLeft(19)} seconds\n";
            result += $"Sec type:" + $"{secType.ToString().PadLeft(26)}\n\n";
            //    result += $"Paired info:\n" + $"{pairedInfo}\n";



            // result += $"Paired info:\n";
            //  result += $"{pairedInfo}\n";

            return result;
        }
        private string Accel(byte[] b)
        {
            string result = "";

            // 根據說明，從字節數組中提取各個字段的數據
            byte fullScale = b[8];
            byte rate = b[9];
            byte highPassFilter = b[10];
            // Int Mask、Offset、Sensitivity、Bias 這幾個資料暫時還不知道如何處理，先忽略

            // 解析 Full Scale
            string fullScaleString = "";
            switch (fullScale)
            {
                case 1:
                    fullScaleString = "2G";
                    break;
                case 2:
                    fullScaleString = "4G";
                    break;
                case 3:
                    fullScaleString = "8G";
                    break;
                default:
                    fullScaleString = "Unknown";
                    break;
            }

            // 解析 Rate
            string rateString = "";
            switch (rate)
            {
                case 0:
                    rateString = "4000 SPS";
                    break;
                case 1:
                    rateString = "2000 SPS";
                    break;
                case 2:
                    rateString = "1000 SPS";
                    break;
                case 3:
                    rateString = "500 SPS";
                    break;
                case 4:
                    rateString = "250 SPS";
                    break;
                case 5:
                    rateString = "125 SPS";
                    break;
                default:
                    rateString = "Unknown";
                    break;
            }

            // 解析 High Pass Filter
            string highPassFilterString = "";
            switch (highPassFilter)
            {
                case 0:
                    highPassFilterString = "OFF";
                    break;
                case 16:
                    highPassFilterString = "24.7e-4";
                    break;
                case 32:
                    highPassFilterString = "6.2048e-4";
                    break;
                case 48:
                    highPassFilterString = "1.5545e-4";
                    break;
                case 64:
                    highPassFilterString = "3.862e-5";
                    break;
                case 80:
                    highPassFilterString = "9.54e-6";
                    break;
                case 96:
                    highPassFilterString = "2.38e-6";
                    break;
                default:
                    highPassFilterString = "Unknown";
                    break;
            }

            result += $"Full scale:\t{fullScaleString.PadLeft(22)}\n";
            result += $"Rate:\t\t{rateString.PadLeft(22)}\n";
            result += $"High pass filter:\t{highPassFilterString.PadLeft(15)}\n";
            // Int Mask、Offset、Sensitivity、Bias 暫時略過

            return result;
        }
        private string ParseSensorConfig(byte[] configData)
        {
            string result = "";

            // 解析操作模式
            byte operationMode = configData[6];
            string operationModeString = "";
            switch (operationMode)
            {
                case 0:
                    operationModeString = "STREAM";
                    break;
                case 1:
                    operationModeString = "VNODE";
                    break;
                case 2:
                    operationModeString = "FNODE";
                    break;
                case 3:
                    operationModeString = "OLED";
                    break;
                case 4:
                    operationModeString = "SD LOG";
                    break;
                default:
                    operationModeString = "Unknown";
                    break;
            }

            // 解析通訊類型
            byte commType = (byte)(configData[7] & 0xF0);
            string commTypeString = "";
            switch (commType)
            {
                case 0x40:
                    commTypeString = "BT";
                    break;
                case 0x80:
                    commTypeString = "WIFI";
                    break;
                default:
                    commTypeString = "Unknown";
                    break;
            }

            // 解析啟用的感應器
            byte activeSensor = (byte)(configData[7] & 0x0F);
            string activeSensorString = "";
            switch (activeSensor)
            {
                case 1:
                    activeSensorString = "ADXL";
                    break;
                case 2:
                    activeSensorString = "BMI160";
                    break;
                case 4:
                    activeSensorString = "ISM330";
                    break;
                default:
                    activeSensorString = "Unknown";
                    break;
            }

            result += $"Operation mode:\t{operationModeString.PadLeft(15)}\n";
            result += $"Comm type:\t{commTypeString.PadLeft(22)}\n";
            result += $"Active sensor:\t{activeSensorString.PadLeft(14)}\n";

            return result;
        }
        private string Timeset(byte[] b)
        {
            string result = "";

            // 根據說明，從字節數組中提取各個字段的數據
            ushort sampleNumber = BitConverter.ToUInt16(b, 8);
            ushort samplePeriod = BitConverter.ToUInt16(b, 10);

            // 構建返回字符串，包含標題和資料
            result += $"Sample number:".PadRight(25) + $"\t{sampleNumber}\n";
            result += $"Sample period:".PadRight(25) + $"\t{samplePeriod} ms\n";

            return result;
        }
        private string FFTset(byte[] b)
        {
            string result = "";

            // 根據說明，從字節數組中提取各個字段的數據
            byte windowType = b[8];
            byte overlap = b[9];
            ushort bins = BitConverter.ToUInt16(b, 10);

            // 構建返回字符串，包含標題和資料

            result += $"Window type:".PadRight(27) + $"\t{windowType}\n";
            result += $"Overlap:".PadRight(25) + $"\t{overlap}%\n";
            result += $"Bins:\t".PadRight(25) + $"\t{bins}\n";

            return result;
        }
    }
    public class ComboBoxItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public ComboBoxItem(string value, string text)
        {
            Value = value;
            Text = text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
    public class ComboUtil
    {
        public static void SetItemValue(ComboBox cbo, string value)
        {
            var selectedObject = cbo.Items.Cast<ComboBoxItem>().SingleOrDefault(i => i.Value.Equals(value));
            if (selectedObject != null)
                cbo.SelectedIndex = cbo.FindStringExact(selectedObject.Text.ToString());
            else
                cbo.SelectedIndex = -1;
        }
        public static ComboBoxItem GetItem(ComboBox cbo)
        {
            ComboBoxItem item = new ComboBoxItem("", "");
            if (cbo.SelectedIndex > -1)
            {
                item = cbo.Items[cbo.SelectedIndex] as ComboBoxItem;
            }
            return item;
        }
        public static ComboBoxItem GetItem(ComboBox cbo, int index)
        {
            ComboBoxItem item = null;
            if (index > -1)
            {
                item = cbo.Items[index] as ComboBoxItem;
            }
            return item;
        }
        public static void RemoveItem(ComboBox cbo, string value)
        {
            ComboBoxItem selectedObject = cbo.Items.Cast<ComboBoxItem>().SingleOrDefault(i => i.Value.Equals(value));
            cbo.Items.Remove(selectedObject);
        }
        public static void BindTableToDDL(ComboBox cbo, DataTable dt, string valueColumn, string textColumn, bool addEmpty)
        {
            cbo.Items.Clear();
            if (addEmpty)
            {
                cbo.Items.Add(new ComboBoxItem("", ""));
            }
            foreach (DataRow dr in dt.Rows)
            {
                cbo.Items.Add(new ComboBoxItem(dr[valueColumn].ToString(), dr[textColumn].ToString()));
            }
            if (cbo.Items.Count > 0)
                cbo.SelectedIndex = 0;
        }
    }
}
