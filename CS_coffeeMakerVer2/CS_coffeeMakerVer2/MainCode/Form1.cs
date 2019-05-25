using Alturos.Yolo;
using Alturos.Yolo.Model;
using CS_coffeeMakerVer2.MainCode;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Intel.RealSense;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_coffeeMakerVer2
{
    public partial class Form1 : Form
    {
        robotControl UR = new robotControl();
        Object[] cup = new Object[2];


        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < cup.Count(); i++)
                cup[i] = new Object();
        }

        //UI
        public void creatJogButton()
        {
            //Right
            Button[] btn_Rjog = new Button[7];
            btn_Rjog[0] = new Button();
            btn_Rjog[0].Text = "+  ||  –";
            btn_Rjog[0].Size = new Size(55, 23);
            btn_Rjog[0].Location = new Point(textBox_Rarm_Xpos.Location.X + textBox_Rarm_Xpos.Size.Width, textBox_Rarm_Xpos.Location.Y);
            tabPage1.Controls.Add(btn_Rjog[0]);
            btn_Rjog[0].MouseDown += new MouseEventHandler(OnClick_jog);
            for (int i = 1; i < 7; i++)
            {
                btn_Rjog[i] = new Button();
                btn_Rjog[i].Text = "+  ||  –";
                btn_Rjog[i].Size = new Size(55, 23);
                btn_Rjog[i].Location = new Point(btn_Rjog[i - 1].Location.X, btn_Rjog[i - 1].Location.Y + btn_Rjog[i - 1].Size.Height + 3);
                tabPage1.Controls.Add(btn_Rjog[i]);
                btn_Rjog[i].MouseDown += new MouseEventHandler(OnClick_jog);
            }
            //Left
            Button[] btn_Ljog = new Button[7];
            btn_Ljog[0] = new Button();
            btn_Ljog[0].Text = "+  ||  –";
            btn_Ljog[0].Size = new Size(55, 23);
            btn_Ljog[0].Location = new Point(textBox_Larm_Xpos.Location.X + textBox_Larm_Xpos.Size.Width, textBox_Larm_Xpos.Location.Y);
            tabPage1.Controls.Add(btn_Ljog[0]);
            btn_Ljog[0].MouseDown += new MouseEventHandler(OnClick_jog);
            for (int i = 1; i < 7; i++)
            {
                btn_Ljog[i] = new Button();
                btn_Ljog[i].Text = "+  ||  –";
                btn_Ljog[i].Size = new Size(55, 23);
                btn_Ljog[i].Location = new Point(btn_Ljog[i - 1].Location.X, btn_Ljog[i - 1].Location.Y + btn_Ljog[i - 1].Size.Height + 3);
                tabPage1.Controls.Add(btn_Ljog[i]);
                btn_Ljog[i].MouseDown += new MouseEventHandler(OnClick_jog);
            }
        }


        private void readPosPathFile()
        {
            comboBox_LselectPos.Items.Clear();
            comboBox_RselectPos.Items.Clear();
            comboBox_LselectPos.Items.Add("goPos");
            comboBox_RselectPos.Items.Add("goPos");
            DirectoryInfo PosFolder = new DirectoryInfo(@"Pos");
            FileInfo[] PosFilesL = PosFolder.GetFiles("L_*.pos");
            FileInfo[] PosFilesR = PosFolder.GetFiles("R_*.pos");
            foreach (FileInfo file in PosFilesL)
            {
                comboBox_LselectPos.Items.Add(file.Name);
            }
            foreach (FileInfo file in PosFilesR)
            {
                comboBox_RselectPos.Items.Add(file.Name);
            }

            DirectoryInfo PathFolder = new DirectoryInfo(@"Path");
            FileInfo[] PathFilesL = PathFolder.GetFiles("L_*.path");
            FileInfo[] PathFilesR = PathFolder.GetFiles("R_*.path");
            foreach (FileInfo file in PathFilesL)
            {
                comboBox_LselectPos.Items.Add(file.Name);
            }
            foreach (FileInfo file in PathFilesR)
            {
                comboBox_RselectPos.Items.Add(file.Name);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            creatJogButton();

            comboBox_LselectPos.Items.Clear();
            comboBox_RselectPos.Items.Clear();

            readPosPathFile();



            UR.URstate_Handler += OnUR_LinkInfo;



            //Task.Run(() => webCamCapture1());
            //camImg1 = webCam1.QueryFrame();
            //imageBox1.Image = camImg1;



            //camImg2 = webCam2.QueryFrame();
            //imageBox2.Image = camImg2;

            //VideoCapture webCam3 = new VideoCapture(2);
            //Task.Run(() => webCamCapture3());
            //camImg3 = webCam3.QueryFrame();
            //imageBox3.Image = camImg3;

            //void webCamCapture1()
            //{
            //    while (true)
            //    {
            //        camImg1 = webCam1.QueryFrame();
            //        //imageBox1.Image = camImg1;
            //        //CvInvoke.Imwrite("yolo.png",camImg);
            //    }
            //}
            //void webCamCapture2()
            //{
            //    while (true)
            //    {
            //        camImg2 = webCam2.QueryFrame();
            //        //imageBox2.Image = camImg2;
            //        //CvInvoke.Imwrite("yolo.png", camImg2);
            //    }
            //}
            //void webCamCapture3()
            //{
            //    while (true)
            //    {
            //        camImg3 = webCam3.QueryFrame();
            //        imageBox3.Image = camImg3;
            //        //CvInvoke.Imwrite("yolo.png",camImg);
            //    }
            //}
        }//form load
        public void OnClick_jog(object sender, MouseEventArgs e)
        {
            MessageBox.Show("尚未開啟\n因為之前用的不太算是jog，只是小移動而已");
        }

        private void OnUR_LinkInfo(object sender, LinkArgs e)
        {

            this.Invoke((MethodInvoker)(() => label_LserverState.Text = e.state));
            if (e.state == "Connect")
                this.Invoke((MethodInvoker)(() => panel_Larm.BackColor = Color.YellowGreen));
            else
                this.Invoke((MethodInvoker)(() => panel_Larm.BackColor = Color.Salmon));
        }

        private void button_ServerOn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                UR.ServerOn("192.168.1.101", 881);

            }//if(button left click)
            else if (e.Button == MouseButtons.Right)
            {
                UR.ServerOff();
            }
        }//on click


        private void comboBox_selectPos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = ((ComboBox)sender).Text;
            if (str == "goPos")
                ((ComboBox)sender).BackColor = Color.HotPink;
            else
            {
                string Extension = str.Substring(str.IndexOf("."));
                if (Extension == ".pos")
                {
                    ((ComboBox)sender).BackColor = Color.Aquamarine;
                }
                if (Extension == ".path")
                {
                    ((ComboBox)sender).BackColor = Color.LemonChiffon;
                }
            }

        }
        private void button_Larm_goPos_Click(object sender, EventArgs e)
        {
            if (comboBox_LselectPos.Text == "" || comboBox_LselectPos.Text == "goPos")
            {
                URCoordinates goC = new URCoordinates(textBox_Larm_Xpos.toPos_M(), textBox_Larm_Ypos.toPos_M(), textBox_Larm_Zpos.toPos_M(), textBox_Larm_Rxrad.toRad(), textBox_Larm_Ryrad.toRad(), textBox_Larm_Rzrad.toRad());
                if (textBox_endDeg.Text == "0")//水平
                {
                    goC.Rx = (float)(Math.PI);
                    goC.Ry = 0;
                    goC.Rz = 0;
                }
                else if (textBox_endDeg.Text == "1")//垂直
                {
                    goC.Rx = (float)(Math.PI * 1.5);
                    goC.Ry = 0;
                    goC.Rz = 0;
                }
                else if (textBox_endDeg.Text == "2")//45度
                {
                    goC.Rx = (float)(Math.PI * 1.75);
                    goC.Ry = 0;
                    goC.Rz = 0;
                }

                UR.goToPos(goC);
            }
            else//看檔案
            {
                string Extension = comboBox_LselectPos.Text.Substring(comboBox_LselectPos.Text.IndexOf("."));
                if (Extension == ".pos")
                {
                    UR.goToFilePos(comboBox_LselectPos.Text);
                }
                if (Extension == ".path")
                {
                    UR.goFilePath(comboBox_LselectPos.Text);
                }

            }
        }

        static Mat camImg1 = new Mat();
        static Mat camImg2 = new Mat();
        static Mat camImg3 = new Mat();
        VideoCapture webCam1 = new VideoCapture(0);
        VideoCapture webCam2 = new VideoCapture(1);
        static YoloWrapper yoloWrapper;
        static IEnumerable<YoloItem> items;
        private void imageBox1_Click(object sender, EventArgs e)
        {
            yoloWrapper = new YoloWrapper("yolov3.cfg", "yolov3.weights", "coco.names");
            string detectionSystemDetail = string.Empty;
            if (!string.IsNullOrEmpty(yoloWrapper.EnvironmentReport.GraphicDeviceName))
                detectionSystemDetail = $"({yoloWrapper.EnvironmentReport.GraphicDeviceName})";
            Console.WriteLine($"Detection System:{yoloWrapper.DetectionSystem}{detectionSystemDetail}");

            Task.Run(() => loop1());
            //Task.Run(() => loop2());

            void loop1()
            {
                Form_camSetting fcs = new Form_camSetting();
                fcs.readSettings(1);

                while (true)
                {
                    camImg1 = webCam1.QueryFrame();
                    CvInvoke.Imwrite("yolo1.png", camImg1);
                    items = yoloWrapper.Detect(@"yolo1.png");
                    bool getCup = false;
                    try
                    {
                        foreach (YoloItem item in items)
                        {
                            string name = item.Type;
                            if (name != "cup")
                                continue;
                            int x = item.X;
                            int y = item.Y;
                            int H = item.Height;
                            int W = item.Width;
                            getCup = true;

                            CvInvoke.PutText(camImg1, name, new Point(x, y), FontFace.HersheySimplex, 1, new MCvScalar(50, 50, 200));
                            CvInvoke.Rectangle(camImg1, new Rectangle(x, y, W, H), new MCvScalar(50, 50, 200), 2);

                            PointF[] centerBottom = new[] { new PointF(x + (W / 2), y + (H)) };
                            PointF Wpoint = fcs.I2W(centerBottom[0].X, centerBottom[0].Y, 0);
                            cup.setZ_mm(Wpoint.X);
                            cup.setX_mm(Wpoint.Y);
                            cup.setY_mm(250);
                        }
                        imageBox1.Image = camImg1;
                    }
                    catch
                    {
                        //Console.WriteLine("items null");
                    }

                    if (getCup)
                        if (cup.State() == situation.move)
                            this.Invoke((MethodInvoker)(() => label_Cup1_info.Text = "Moving : " + cup.moveDistanse().ToString("0.000")));
                        else
                            this.Invoke((MethodInvoker)(() => label_Cup1_info.Text = $"({cup.getX_m().ToString("0.000")},{cup.getY_m()},{cup.getZ_m().ToString("0.000")})"));
                    else
                        this.Invoke((MethodInvoker)(() => label_Cup1_info.Text = "Block"));
                }
            }

        }
        private void button_setCam_Click(object sender, EventArgs e)
        {
            MainCode.Form_camSetting setForm = new MainCode.Form_camSetting();
            setForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pipe = new Pipeline();
            PipelineProfile selection = pipe.Start();

            //Mat mat = new Mat(720, 1280, DepthType.Cv16U, 1);
            Mat mat_show = new Mat(720, 1280, DepthType.Cv8U, 1);
            Mat cmat = new Mat(720, 1280, DepthType.Cv8U, 3);
            Task.Run(() =>
            {
                //Colorizer colorizer = new Colorizer();
                while (true)
                {
                    using (var frames = pipe.WaitForFrames())
                    {
                        var depth = frames.DepthFrame;
                        //var depthFrame = frames.DepthFrame.DisposeWith(frames);
                        // var colorizedDepth = colorizer.Process(depthFrame).DisposeWith(frames);//<VideoFrame>

                        ushort[] udepth = new ushort[1280 * 720];
                        byte[] bdepth = new byte[1280 * 720];

                        //depth.CopyTo(mat.DataPointer);
                        depth.CopyTo(udepth);

                        for (int y = 0; y < 720; ++y)
                            for (int x = 0; x < 1280; ++x)
                            {
                                float max = 1000;
                                if (udepth[x + y * 1280] > max)
                                    bdepth[x + y * 1280] = 0;
                                else
                                    bdepth[x + y * 1280] = (byte)(udepth[x + y * 1280] * (255.0f / max));
                            }
                        Marshal.Copy(bdepth, 0, mat_show.DataPointer, 720 * 1280);

                        imageBox3.Image = mat_show;


                        var colorFrame = frames.ColorFrame.DisposeWith(frames);
                        byte[] bcolor = new byte[1280 * 720 * 3];
                        Marshal.Copy(colorFrame.Data, bcolor, 0, 720 * 1280 * 3);
                        Marshal.Copy(bcolor, 0, cmat.DataPointer, 720 * 1280 * 3);
                        CvInvoke.CvtColor(cmat, cmat, ColorConversion.Bgr2Rgb);
                        imageBox2.Image = cmat;

                    }
                }
            });
        }

        private void button_testGrabcup_Click(object sender, EventArgs e)
        {
            //float cupoffsetx = 0.030f;
            //float cupoffsetz = 0.008f;
            //URCoordinates goC = new URCoordinates(cup.getX_m() + cupoffsetx, 0.250f, cup.getZ_m() + cupoffsetz, (float)(Math.PI), 0, 0);
            //URCoordinates goC2 = new URCoordinates(cup.getX_m() + cupoffsetx, 0.310f, cup.getZ_m() + cupoffsetz, (float)(Math.PI), 0, 0);
            //UR.goToPos(goC);

            Action action = new Action(UR, "test.path");
            action.add(Subact.Pick(cup[0]));
            action.add(Subact.Place(new URCoordinates(0.360f, 0.250f, -0.110f, (float)(Math.PI), 0, 0)));
            action.execute();
        }

    }//class form

    enum situation
    {
        stop = 0,
        move = 1
    }
    public static class tmp
    {
        public static int a = 0;
    }
    class Action
    {
        private static robotControl UR;
        private static StreamWriter txt;
        private static string fileName;
        //public static tmp aaa;
        public Action(robotControl _UR, string file)
        {
            UR = _UR;
            fileName = file;
            txt = new StreamWriter($"Path//{file}", false);
        }
        public void end()
        {
            txt.Flush();
            txt.Close();
        }
        public void execute()
        {
            try
            {
                txt.Flush();
                txt.Close();
            }
            catch { }
            if (UR.serverRunning == false)
            {
                MessageBox.Show("server is off");
                return;
            }
            UR.goFilePath(fileName);
        }
        public void add(subactInfo subact)
        {
            for (int i = 0; i < subact.Count(); i++)
                txt.WriteLine(subact.infotxt[i]);
        }       
    }
    class Subact
    {
        public static subactInfo Pick(Object cup)
        {
            subactInfo rtn =new subactInfo();
            URCoordinates down = cup.gripPos();
            URCoordinates up = new URCoordinates(down);
            up.Y -= 0.05f;//上升5公分
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("0");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(down.ToPos());
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("50");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            return rtn;
        }
        public static subactInfo Place(URCoordinates Wpoint)
        {
            subactInfo rtn = new subactInfo();
            URCoordinates down = Wpoint;
            URCoordinates up = down;
            up.Y -= 0.05f;//上升5公分

            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("50");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(down.ToPos());
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("0");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            return rtn;
        }
        public subactInfo Pour(Object toCup)
        {
            return new subactInfo();
        }
        public subactInfo Trigger()
        {
            return new subactInfo();
        }
    }
    class subactInfo
    {
      public  List<string> infotxt = new List<string>();
        public int Count()
        {
            return infotxt.Count();
        }
    }


    class Object
    {
        private const int fileterSize = 10;
        private List<float> x = new List<float>();//unit M
        private List<float> y = new List<float>();//unit M
        private List<float> z = new List<float>();//unit M
        private float moveD = 0.05f;
        private float lastx = 0;
        private float lasty = 0;
        private float lastz = 0;
        public float gripOffset_M_x = 0;
        public float gripOffset_M_y = 0;
        public float gripOffset_M_z = 0;
        private int[] filterIndex = new[] { 0, 0, 0 };
        public void setX_mm(float x_mm)
        {
            x.Add(x_mm / 1000f);
            if (x.Count > fileterSize)
                x.RemoveAt(0);

        }
        public void setY_mm(float y_mm)
        {
            y.Add(y_mm / 1000f);
            if (y.Count > fileterSize)
                y.RemoveAt(0);
        }
        public void setZ_mm(float z_mm)
        {
            z.Add(z_mm / 1000f);
            if (z.Count > fileterSize)
                z.RemoveAt(0);

        }
        public float getX_m()
        {
            return avg(x, fileterSize / 2, fileterSize / 2);
        }
        public float getY_m()
        {
            return avg(y, fileterSize / 2, fileterSize / 2);
        }
        public float getZ_m()
        {
            return avg(z, fileterSize / 2, fileterSize / 2);
        }

        public URCoordinates gripPos(int deg = 0)
        {
            if (deg == 0)
                return new URCoordinates(getX_m() + gripOffset_M_x, getY_m() + gripOffset_M_y, getZ_m() + gripOffset_M_z, (float)(Math.PI), 0, 0);
            throw new System.ArgumentException("未完成", "現在只能水平");
        }
        private float avg(List<float> v, int startIndex, int count)
        {
            if (v.Count < 10)
                return 0;
            float sum = 0;
            for (int i = 0; i < count; i++)
                sum += v[i + startIndex];
            return sum / (float)count;
        }

        public situation State()
        {
            lastx = avg(x, 0, fileterSize / 2);
            lasty = avg(y, 0, fileterSize / 2);
            lastz = avg(z, 0, fileterSize / 2);
            float avgx = avg(x, fileterSize / 2, fileterSize / 2);
            float avgy = avg(y, fileterSize / 2, fileterSize / 2);
            float avgz = avg(z, fileterSize / 2, fileterSize / 2);
            if (Math.Abs((lastx * lastx + lasty * lasty + lastz * lastz) - (avgx * avgx + avgy * avgy + avgz * avgz)) > moveD * moveD)
                return situation.move;
            else
                return situation.stop;
        }
        public float moveDistanse()
        {
            lastx = avg(x, 0, fileterSize / 2);
            lasty = avg(y, 0, fileterSize / 2);
            lastz = avg(z, 0, fileterSize / 2);
            float avgx = avg(x, fileterSize / 2, fileterSize / 2);
            float avgy = avg(y, fileterSize / 2, fileterSize / 2);
            float avgz = avg(z, fileterSize / 2, fileterSize / 2);
            return Math.Abs((lastx * lastx + lasty * lasty + lastz * lastz) - (avgx * avgx + avgy * avgy + avgz * avgz));
        }
        public situation S = situation.stop;
    }

    static class ex
    {
        static public int toInt(this string str)
        {
            if (str == "-∞")
                return int.MinValue;
            if (str == "∞")
                return int.MaxValue;

            return int.Parse(str);
        }
        static public float toPos_M(this TextBox tb)
        {
            return float.Parse(tb.Text);
        }
        static public float toRad(this TextBox tb)
        {
            return float.Parse(tb.Text);
        }

        static public byte[] toByte(this Mat mat)
        {
            ImageCodecInfo bmpEncoder = ImageCodecInfo.GetImageEncoders().Single(x => x.FormatDescription == "BMP");
            System.Drawing.Imaging.Encoder encoder2 = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters parameters = new System.Drawing.Imaging.EncoderParameters(1);
            EncoderParameter parameter = new EncoderParameter(encoder2, 50L);
            parameters.Param[0] = parameter;

            System.IO.Stream stream = new MemoryStream();
            mat.Bitmap.Save(stream, bmpEncoder, parameters);
            byte[] bytes = ((MemoryStream)stream).ToArray();
            return bytes;
        }
    }

}//namespace