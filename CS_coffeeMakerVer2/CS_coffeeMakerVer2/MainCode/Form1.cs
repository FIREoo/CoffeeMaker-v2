using Alturos.Yolo;
using Alturos.Yolo.Model;
using CS_coffeeMakerVer2.MainCode;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Intel.RealSense;
using myEmguLibrary;
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

            renameControl();

            cup[0].Name = "blue cup";
            cup[1].Name = "pink cup";
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

        #region video capture
        static Mat camImg1 = new Mat();
        VideoCapture webCam1;
        static YoloWrapper yoloWrapper;
        static IEnumerable<YoloItem> items;
       static int videoIndex = 10;
        private void correct(ref PointF P)
        {
            float v = 0;
            v = (320 - P.X) * 0.05f;
            P.X = P.X + v;
        }
        private static bool vidioLoop = false;
        private void YOLO_detect(bool isLive, string actTxtFile = "")
        {
            yoloWrapper = new YoloWrapper("modle\\yolov3-tiny-2obj.cfg", "modle\\yolov3-tiny-2obj_2cup.weights", "modle\\obj.names");
            string detectionSystemDetail = string.Empty;
            if (!string.IsNullOrEmpty(yoloWrapper.EnvironmentReport.GraphicDeviceName))
                detectionSystemDetail = $"({yoloWrapper.EnvironmentReport.GraphicDeviceName})";
            Console.WriteLine($"Detection System:{yoloWrapper.DetectionSystem}{detectionSystemDetail}");

            List<string> write = new List<string>();

            Form_camSetting fcs = new Form_camSetting();
            fcs.readSettings(1);
            cup[0].gripOffset_M_x = 0.035f;
            cup[1].gripOffset_M_x = 0.025f;
            int f = 1;
            vidioLoop = true;

            while (vidioLoop)
            {
                if (isLive)
                    camImg1 = webCam1.QueryFrame();
                else
                {
                    webCam1.Read(camImg1);
                    if (camImg1 == null)
                        break;
                }

                CvInvoke.Imwrite("yolo1.png", camImg1);
                try { items = yoloWrapper.Detect(@"yolo1.png"); }
                catch { break; }

                bool[] getCup = new bool[cup.Count()];
                try
                {
                    foreach (YoloItem item in items)
                    {
                        string name = item.Type;
                        int x = item.X;
                        int y = item.Y;
                        int H = item.Height;
                        int W = item.Width;

                        CvInvoke.PutText(camImg1, name, new Point(x, y), FontFace.HersheySimplex, 1, new MCvScalar(50, 230, 230));
                        CvInvoke.PutText(camImg1, item.Confidence.ToString("0.0"), new Point(x, y-10), FontFace.HersheySimplex, 0.5, new MCvScalar(50, 230, 230));
                        CvInvoke.Rectangle(camImg1, new Rectangle(x, y, W, H), new MCvScalar(50, 230, 230), 3);

                        if (item.Type == "blue cup")
                        {
                            getCup[0] = true;
                            PointF centerBottom = new PointF(x + (W / 2), y + (H));
                            CvInvoke.Circle(camImg1, new Point((int)centerBottom.X, (int)centerBottom.Y), 3, new MCvScalar(100, 230, 50), -1);
                            correct(ref centerBottom);
                            CvInvoke.Circle(camImg1, new Point((int)centerBottom.X, (int)centerBottom.Y), 3, new MCvScalar(50, 230, 50), -1);
                            PointF Wpoint = fcs.I2W(centerBottom.X, centerBottom.Y, 0);
                            cup[0].setZ_mm(Wpoint.X);
                            cup[0].setX_mm(Wpoint.Y);
                            cup[0].setY_mm(230);
                        }
                        else if (item.Type == "pink cup")
                        {
                            getCup[1] = true;
                            PointF centerBottom = new PointF(x + (W / 2), y + (H));
                            CvInvoke.Circle(camImg1, new Point((int)centerBottom.X, (int)centerBottom.Y), 3, new MCvScalar(100, 230, 50), -1);
                            correct(ref centerBottom);
                            CvInvoke.Circle(camImg1, new Point((int)centerBottom.X, (int)centerBottom.Y), 3, new MCvScalar(50, 230, 50), -1);
                            PointF Wpoint = fcs.I2W(centerBottom.X, centerBottom.Y, 0);
                            cup[1].setZ_mm(Wpoint.X);
                            cup[1].setX_mm(Wpoint.Y);
                            cup[1].setY_mm(230);
                        }
                    }
                    imageBox1.Image = camImg1;
                    CvInvoke.Imwrite("detect.png", camImg1);
                }
                catch { }

                //判斷物體有沒有移動 和 準備寫TXT
                string tmp_write = "";
                tmp_write += f.ToString() + "\t";
                if (getCup[0])
                    if (cup[0].State() == situation.move)
                    {
                        this.Invoke((MethodInvoker)(() => label_Cup1_info.Text = "Moving : " + cup[0].moveDistanse().ToString("0.000")));
                        tmp_write += "M";
                    }
                    else
                    {
                        string str = $"{cup[0].getX_m().ToString("0.000")},{cup[0].getY_m()},{cup[0].getZ_m().ToString("0.000")}";
                        this.Invoke((MethodInvoker)(() => label_Cup1_info.Text = $"({str})"));
                        tmp_write += str;
                    }
                else
                {
                    this.Invoke((MethodInvoker)(() => label_Cup1_info.Text = "Block"));
                    tmp_write += "B";
                }

                tmp_write += "\t";
                if (getCup[1])
                    if (cup[1].State() == situation.move)
                    {
                        this.Invoke((MethodInvoker)(() => label_Cup2_info.Text = "Moving : " + cup[1].moveDistanse().ToString("0.000")));
                        tmp_write += "M";
                    }
                    else
                    {
                        string str = $"{cup[1].getX_m().ToString("0.000")},{cup[1].getY_m()},{cup[1].getZ_m().ToString("0.000")}";
                        this.Invoke((MethodInvoker)(() => label_Cup2_info.Text = $"({str})"));
                        tmp_write += str;
                    }
                else
                {
                    this.Invoke((MethodInvoker)(() => label_Cup2_info.Text = "Block"));
                    tmp_write+="B";
                }
                if (isLive)
                    write.Clear();
                else
                    write.Add(tmp_write);
                f++;
            }//while true

            if (!isLive)
            {
                StreamWriter act_obj = new StreamWriter(actTxtFile, false);

                act_obj.Write(f.ToString() + "\t");
                foreach (string line in write)
                    act_obj.WriteLine(line);
                act_obj.Flush();
                act_obj.Close();
            }
        }


        private void liveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vidioLoop = false;
            bool Livecase = true;
            webCam1 = new VideoCapture(0);
            Task.Run(() => YOLO_detect(Livecase));
        }

        private void videoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem click = (ToolStripMenuItem)sender;
            videoIndex = int.Parse(click.Text.Split('_')[0]);

            vidioLoop = false;
            bool Livecase = false;
            webCam1 = new VideoCapture($"Act\\T{videoIndex}.avi");
            Task.Run(() => YOLO_detect(Livecase, $"Act\\{videoIndex}_act_obj.txt"));
        }
        private void contextMenuStrip_imgBox_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DirectoryInfo ActFolder = new DirectoryInfo(@"Act");
            FileInfo[] ActFiles = ActFolder.GetFiles("*_act_output.txt");
            foreach (FileInfo file in ActFiles)
            {
                ToolStripMenuItem tmp = new ToolStripMenuItem();
                tmp.Size = new System.Drawing.Size(180, 22);
                tmp.Text = file.Name;
                tmp.Click += new System.EventHandler(this.videoToolStripMenuItem_Click);

                videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tmp});
            }


          



        }
        #endregion video capture

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
            action.add(Subact.Pour(cup[1]));
            action.add(Subact.Place(cup[0],new URCoordinates(0.353f, 0.23f, -0.170f, (float)(Math.PI), 0, 0)));
            action.add(Subact.Pick(cup[1]));
            action.add(Subact.Place(subactInfo.place.DripTray));
            action.add(Subact.Trigger());
            action.add(Subact.Pick(subactInfo.place.DripTray));
            action.add(Subact.Place(cup[1],new URCoordinates(0.190f, 0.23f, -0.110f, (float)(Math.PI), 0, 0)));

            action.execute();
        }

        #region record
        private void button_startRecord_Click(object sender, EventArgs e)
        {
            string Arm = radioButton_record_L.Checked ? "L" : "R";
            UR.txt_record = new StreamWriter($"Path//{Arm}_{textBox_record_txtname.Text}.path", false);
            UR.cmd = mode.recordj;
        }

        private void button_recordWrite_Click(object sender, EventArgs e)
        {
            UR.txt_record.WriteLine(UR.Msg);
        }

        private void button_endRecord_Click(object sender, EventArgs e)
        {
            UR.cmd = mode.stop;
            UR.txt_record.Flush();
            UR.txt_record.Close();
        }
        #endregion record

        #region action
        private void button_simulateAddAct_Click(object sender, EventArgs e)
        {
            if (rb.Act.pick.Checked)
            {
                if (rb.Act.Pick.cup1.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Pick");
                    item1.SubItems.Add(cup[0].Name);
                    listView_actBase.Items.Add(item1);
                }
                else if (rb.Act.Pick.cup2.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Pick");
                    item1.SubItems.Add(cup[1].Name);
                    listView_actBase.Items.Add(item1);
                }
                else if(rb.Act.Pick.fromDrip.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Pick");
                    item1.SubItems.Add("from drip tray");
                    listView_actBase.Items.Add(item1);
                }
            }
            else if (rb.Act.place.Checked)
            {
                if (rb.Act.Place.toDrip.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Place");
                    item1.SubItems.Add("to drip tray");
                    listView_actBase.Items.Add(item1);
                }
                else if (radioButton_Act_place_pos.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Place");
                    item1.SubItems.Add($"to Pos {textBox_Px.Text} {textBox_Py.Text} {textBox_Pz.Text}");
                    listView_actBase.Items.Add(item1);
                }
            }
            else if (rb.Act.pour.Checked)
            {
                if (rb.Act.Pour.toCup1.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Pour");
                    item1.SubItems.Add("to "+ cup[0].Name);
                    listView_actBase.Items.Add(item1);
                }
                else if (rb.Act.Pour.toCup2.Checked)
                {
                    ListViewItem item1 = new ListViewItem();
                    item1.SubItems.Add("Pour");
                    item1.SubItems.Add("to "+cup[1].Name);
                    listView_actBase.Items.Add(item1);
                }
            }
            else if (rb.Act.trigger.Checked)
            {
                ListViewItem item1 = new ListViewItem();
                item1.SubItems.Add("Toggle");
                item1.SubItems.Add("coffee machine");
                listView_actBase.Items.Add(item1);
            }
        }

        private void button_clearActionBase_Click(object sender, EventArgs e)
        {
            listView_actBase.Items.Clear();
        }

        private void button_creatAction_Click(object sender, EventArgs e)
        {
            Action action = new Action(UR, "test.path");
            action.start(cup);
            Object gripObj = new Object();
            for (int i = 1; i < listView_actBase.Items.Count; i++)
            {
                string act = listView_actBase.Items[i].SubItems[1].Text;
                string obj = listView_actBase.Items[i].SubItems[2].Text;

               

                if (act == "Pick")
                {
                    if (obj == cup[0].Name)
                    {
                        action.add(Subact.Pick(cup[0]));
                        gripObj = cup[0];
                    }
                    else if (obj == cup[1].Name)
                    {
                        action.add(Subact.Pick(cup[1]));
                        gripObj = cup[1];
                    }
                    else if (obj == "from drip tray")
                        action.add(Subact.Pick(subactInfo.place.DripTray));
                }
                else if (act == "Place")
                {
                    if (obj == "to drip tray")
                        action.add(Subact.Place(subactInfo.place.DripTray));
                    else if ( obj.IndexOf("to Pos") >=0 )
                    {
                        string[] tmp = obj.Substring(7).Split(' ');
                        action.add(Subact.Place(gripObj, new URCoordinates(float.Parse(tmp[0]), float.Parse(tmp[1]), float.Parse(tmp[2]), (float)(Math.PI), 0, 0)));
                    }
                }
                else if (act == "Pour")
                {
                    if (obj == "to "+ cup[0].Name)
                        action.add(Subact.Pour(cup[0]));
                    else if (obj == "to "+ cup[1].Name)
                        action.add(Subact.Pour(cup[1]));
                }
                else if (act == "Toggle")
                {
                    action.add(Subact.Trigger());
                }
            }
            action.execute();

        }//action base list to action

        private void button_sumulateAround_Click(object sender, EventArgs e)
        {
            rb.Act.pick.Checked = true;
            rb.Act.Pick.cup2.Checked = true;
            button_simulateAddAct_Click(null, null);

            rb.Act.place.Checked = true;
            rb.Act.Place.toDrip.Checked = true;
            button_simulateAddAct_Click(null, null);

            rb.Act.trigger.Checked = true;
            button_simulateAddAct_Click(null, null);

            rb.Act.pick.Checked = true;
            rb.Act.Pick.fromDrip.Checked = true;
            button_simulateAddAct_Click(null, null);

            textBox_Px.Text = "0.355";
            textBox_Py.Text = "0.23";
            textBox_Pz.Text = "-0.12";
            rb.Act.place.Checked = true;
            rb.Act.Place.toPos.Checked = true;
            button_simulateAddAct_Click(null, null);

 
            rb.Act.pick.Checked = true;
            rb.Act.Pick.cup1.Checked = true;
            button_simulateAddAct_Click(null, null);

            rb.Act.pour.Checked = true;
            rb.Act.Pour.toCup2.Checked = true;
            button_simulateAddAct_Click(null, null);

            textBox_Px.Text = "0.285";
            textBox_Py.Text = "0.23";
            textBox_Pz.Text = "-0.311";
            rb.Act.place.Checked = true;
            rb.Act.Place.toPos.Checked = true;
            button_simulateAddAct_Click(null, null);
      
        }
        #endregion action

      
        private void imageBox3_Click(object sender, EventArgs e)
        {
            string[] file = File.ReadAllLines($"Act\\{videoIndex}_act_output.txt");
            Mat mat = new Mat(150, file.Count(), DepthType.Cv8U, 3);
            MyInvoke.setToZero(ref mat);
            for (int i = 0; i < file.Count(); i++)
            {
                int act = int.Parse(file[i].Split('\t')[1]);
                if (act == 0)//PP              
                    CvInvoke.Line(mat, new Point(10 + i, 25), new Point(10 + i, 75), new MCvScalar(200, 50, 50));
                else if (act == 1)//switch
                    CvInvoke.Line(mat, new Point(10 + i, 25), new Point(10 + i, 75), new MCvScalar(50, 200, 50));
                else if (act == 2)//pour
                    CvInvoke.Line(mat, new Point(10 + i, 25), new Point(10 + i, 75), new MCvScalar(50, 50, 200));
            }

            file = File.ReadAllLines($"Act\\10_act_obj.txt");
            for (int i = 0; i < file.Count(); i++)
            {
                string bCup = file[i].Split('\t')[1];
                string pCup = file[i].Split('\t')[2];
                if (bCup == "M")
                    CvInvoke.Line(mat, new Point(10 + i, 85), new Point(10 + i, 105), new MCvScalar(50, 200, 200));
                else if (bCup == "B") { }
                else
                    CvInvoke.Line(mat, new Point(10 + i, 85), new Point(10 + i, 105), new MCvScalar(100, 100, 100));

                if (pCup == "M")
                    CvInvoke.Line(mat, new Point(10 + i, 110), new Point(10 + i, 130), new MCvScalar(50, 200, 200));
                else if (pCup == "B") { }
                else
                    CvInvoke.Line(mat, new Point(10 + i, 110), new Point(10 + i, 130), new MCvScalar(100, 100, 100));
            }

            imageBox3.Image = mat;
        }

      


    }//class form




    enum situation
    {
        stop = 0,
        move = 1
    }
    class Object
    {
        public string Name = "";
        private const int fileterSize = 10;
        private List<float> x = new List<float>();//unit M
        private List<float> y = new List<float>();//unit M
        private List<float> z = new List<float>();//unit M
        private float moveD = 0.02f;
        private float lastx = 0;
        private float lasty = 0;
        private float lastz = 0;
        public float gripOffset_M_x = 0;
        public float gripOffset_M_y = 0;
        public float gripOffset_M_z = 0;
        private URCoordinates nowPos = new URCoordinates();//再action中 可能因為中間移動過 所以必須記錄移動後的位置 以免之後抓空

        public void saveNowPos()
        {
            nowPos =  new URCoordinates(getX_m(), getY_m() , getZ_m() , 0, 0, 0);
        }
        public void setNowPos(URCoordinates urc)
        {
            nowPos = new URCoordinates(urc);
        }


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
                return new URCoordinates(nowPos.X + gripOffset_M_x, nowPos.Y + gripOffset_M_y, nowPos.Z + gripOffset_M_z, (float)(Math.PI), 0, 0);
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
            float dx = (lastx - avgx) * (lastx - avgx);
            float dy = (lasty - avgy) * (lasty - avgy);
            float dz = (lastz - avgz) * (lastz - avgz);
            if ((dx + dy + dz) > moveD * moveD)
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
            double dx = (lastx - avgx) * (lastx - avgx);
            double dy = (lasty - avgy) * (lasty - avgy);
            double dz = (lastz - avgz) * (lastz - avgz);
            return (float)Math.Pow((dx + dy + dz), 0.5d);
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