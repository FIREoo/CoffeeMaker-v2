using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;
using System.IO;

namespace CS_coffeeMakerVer2.MainCode
{
    public partial class Form_camSetting : Form
    {

        enum State
        {
            none = 0,
            vectorX = 1,
            vectorY = 2,
            points = 3,
            worldPoint = 4,
            setP0 = 5
        }
        const int MAXCAM = 4;

        static State state = State.none;
        static bool KeepCapture = true;
        static Mat imgCam = new Mat();
        static Mat imgDraw = new Mat(new Size(640, 480), DepthType.Cv8U, 3);
        static Mat imgDraw_guide = new Mat(new Size(640, 480), DepthType.Cv8U, 3);

        static Point[] vectorX = new Point[2];
        static int OpenCamIndex = 0;
        static int pointClick = 0;

        //轉換矩陣參數
        static Point[,] cam_points = new Point[MAXCAM, 4];
        static Point[,] world_points = new Point[MAXCAM, 4];//世界座標的4個點

        public Mat[] matrix = new Mat[MAXCAM];
        public float[] Xscale = new float[MAXCAM];//影像與世界座標的比例(image * scale = world)
        public float[] Yscale = new float[MAXCAM];

        //顯示轉換後的參數
        int[] p0x = new int[MAXCAM];//轉換後 位移的 P0x
        int[] p0y = new int[MAXCAM];
        float[] w = new float[MAXCAM];//轉換後的影像寬
        float[] h = new float[MAXCAM];
        float[] zoom = new float[MAXCAM];

        public Form_camSetting()
        {
            InitializeComponent();
            Directory.CreateDirectory(@"PerspectiveData");
            for (int i = 0; i < MAXCAM; i++)
            {
                p0x[i] = 150;
                p0y[i] = 150;
                w[i] = 100;
                h[i] = 100;
                zoom[i] = 1.0f;
            }
            try
            {
                readSettings(MAXCAM);
            }
            catch { }
        }
        private void Txt_TranImage(string RW, int camIndex)
        {
            if (RW == "R")//read
            {
                string[] allString = System.IO.File.ReadAllLines($"PerspectiveData//PerspectiveData_scale{camIndex}.txt");
                Xscale[camIndex] = float.Parse(allString[0]);
                Yscale[camIndex] = float.Parse(allString[1]);
                p0x[camIndex] = int.Parse(allString[2]);
                p0y[camIndex] = int.Parse(allString[3]);
                w[camIndex] = int.Parse(allString[4]);
                h[camIndex] = int.Parse(allString[5]);
                zoom[camIndex] = float.Parse(allString[6]);
            }
            else if (RW == "W")
            {
                StreamWriter sw = new StreamWriter($"PerspectiveData//PerspectiveData_scale{camIndex}.txt", false);
                sw.WriteLine($"{Xscale[camIndex]}");
                sw.WriteLine($"{Yscale[camIndex]}");
                sw.WriteLine($"{p0x[camIndex]}");
                sw.WriteLine($"{p0y[camIndex]}");
                sw.WriteLine($"{w[camIndex]}");
                sw.WriteLine($"{h[camIndex]}");
                sw.WriteLine($"{zoom[camIndex]}");
                sw.Flush();
                sw.Close();
            }
            else
                throw new System.ArgumentException("RW error", "read or write?? (R/W)");
        }
        private void Txt_camPoint(string RW, int camIndex)
        {
            if (RW == "R")//read
            {
                string[] allString = System.IO.File.ReadAllLines($"PerspectiveData//PerspectiveData_cam{camIndex}.txt");
                for (int L = 0; L < MAXCAM; L++)
                    cam_points[camIndex, L] = new Point(int.Parse(allString[L].Split('\t')[0]), int.Parse(allString[L].Split('\t')[1]));
            }
            else if (RW == "W")
            {
                StreamWriter sw = new StreamWriter($"PerspectiveData//PerspectiveData_cam{camIndex}.txt", false);
                sw.WriteLine($"{cam_points[camIndex, 0].X}\t{cam_points[camIndex, 0].Y}");
                sw.WriteLine($"{cam_points[camIndex, 1].X}\t{cam_points[camIndex, 1].Y}");
                sw.WriteLine($"{cam_points[camIndex, 2].X}\t{cam_points[camIndex, 2].Y}");
                sw.WriteLine($"{cam_points[camIndex, 3].X}\t{cam_points[camIndex, 3].Y}");
                sw.Flush();
                sw.Close();
            }
            else
                throw new System.ArgumentException("RW error", "read or write?? (R/W)");
        }
        private void Txt_worldPoint(string RW, int camIndex)
        {
            if (RW == "R")//read
            {
                string[] allString = System.IO.File.ReadAllLines($"PerspectiveData//PerspectiveData_world{camIndex}.txt");
                for (int L = 0; L < 4; L++)
                    world_points[camIndex, L] = new Point(int.Parse(allString[L].Split('\t')[0]), int.Parse(allString[L].Split('\t')[1]));
            }
            else if (RW == "W")
            {
                StreamWriter sw = new StreamWriter($"PerspectiveData//PerspectiveData_world{OpenCamIndex}.txt", false);
                sw.WriteLine($"{world_points[camIndex, 0].X}\t{world_points[camIndex, 0].Y}");
                sw.WriteLine($"{world_points[camIndex, 1].X}\t{world_points[camIndex, 1].Y}");
                sw.WriteLine($"{world_points[camIndex, 2].X}\t{world_points[camIndex, 2].Y}");
                sw.WriteLine($"{world_points[camIndex, 3].X}\t{world_points[camIndex, 3].Y}");
                sw.Flush();
                sw.Close();
            }
            else
            {

            }
        }
        private PointF[] PT_Points(string CSYS, int camIndex)
        {
            if (CSYS == "after")//need file: TImage
            {
                return new[] {
                    new PointF(p0x[camIndex], p0y[camIndex]),
                    new PointF(p0x[camIndex], p0y[camIndex] + (h[camIndex] * zoom[camIndex])),
                    new PointF(p0x[camIndex] + (w[camIndex] * zoom[camIndex]), p0y[camIndex] + (h[camIndex] * zoom[camIndex])),
                    new PointF(p0x[camIndex] + (w[camIndex] * zoom[camIndex]), p0y[camIndex]) };
            }
            else if (CSYS == "before")//need file: camPoint
            {
                PointF[] dst = new PointF[4];
                for (int i = 0; i < 4; i++)
                    dst[i] = new PointF(cam_points[camIndex, i].X, cam_points[camIndex, i].Y);
                return dst;
            }
            else
                throw new System.ArgumentException("CSYS error", "before or after??");
        }
        public void readSettings(int maxfile)
        {
            for (int f = 0; f < maxfile; f++)
            {
                Txt_worldPoint("R", f);
                Txt_TranImage("R", f);
                Txt_camPoint("R", f);
                PointF[] src = PT_Points("after", f);
                PointF[] dst = PT_Points("before", f);
                matrix[f] = CvInvoke.GetPerspectiveTransform(dst, src);
            }
        }
        private void comboBox_cameraIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoCapture webCam;
            try
            {
                KeepCapture = false;
                Thread.Sleep(1000);
                OpenCamIndex = int.Parse(comboBox_cameraIndex.SelectedItem.ToString());
                webCam = new VideoCapture(OpenCamIndex);
            }
            catch
            {
                MessageBox.Show("VideoCapture error!");
                return;
            }
            imgCam = webCam.QueryFrame();
            if (imgCam.Size.Height != 480 || imgCam.Size.Width != 640)
            {
                MessageBox.Show("image size 640x480 only!");
                return;
            }
            Task.Run(() => webCamCapture());
            void webCamCapture()
            {
                KeepCapture = true;
                while (KeepCapture)
                {
                    imgCam = webCam.QueryFrame();
                    if (checkBox_PT.Checked == false)
                    {
                        Mat mask = new Mat();
                        CvInvoke.CvtColor(imgDraw, mask, ColorConversion.Bgr2Gray);
                        CvInvoke.Threshold(mask, mask, 1, 255, ThresholdType.Binary);
                        imgDraw.CopyTo(imgCam, mask);

                        CvInvoke.CvtColor(imgDraw_guide, mask, ColorConversion.Bgr2Gray);
                        CvInvoke.Threshold(mask, mask, 1, 255, ThresholdType.Binary);
                        imgDraw_guide.CopyTo(imgCam, mask);
                    }
                    else
                    {
                        try
                        {
                            CvInvoke.WarpPerspective(imgCam, imgCam, matrix[OpenCamIndex], new Size(640, 480));
                        }
                        catch { }
                    }
                    imageBox_cam.Image = imgCam;
                }
            }
        }

        //---
        #region mouse event
        private void imageBox_cam_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == State.points)
            {
                cam_points[OpenCamIndex, pointClick] = new Point(e.X, e.Y);
                CvInvoke.Circle(imgDraw, cam_points[OpenCamIndex, pointClick], 5, new MCvScalar(50, 50, 200), -1);
                CvInvoke.PutText(imgDraw, pointClick.ToString(), cam_points[OpenCamIndex, pointClick], FontFace.HersheySimplex, 1.3, new MCvScalar(50, 50, 200), 2);
                pointClick++;
                if (pointClick == 4)
                {//設定結束
                    pointClick = 0;
                    CvInvoke.Line(imgDraw, cam_points[OpenCamIndex, 0], cam_points[OpenCamIndex, 1], new MCvScalar(50, 50, 200), 3);
                    CvInvoke.Line(imgDraw, cam_points[OpenCamIndex, 1], cam_points[OpenCamIndex, 2], new MCvScalar(50, 50, 200), 3);
                    CvInvoke.Line(imgDraw, cam_points[OpenCamIndex, 2], cam_points[OpenCamIndex, 3], new MCvScalar(50, 50, 200), 3);
                    CvInvoke.Line(imgDraw, cam_points[OpenCamIndex, 3], cam_points[OpenCamIndex, 0], new MCvScalar(50, 50, 200), 3);

                    button_set4point.BackColor = Color.Transparent;

                    Txt_camPoint("W", OpenCamIndex);

                    state = State.none;
                }

            }
            else if (state == State.setP0)
            {
                p0x[OpenCamIndex] = e.X;
                p0y[OpenCamIndex] = e.Y;
                state = State.none;
                button_setPT_point.BackColor = Color.Transparent;
            }
            else if (state == State.none)
            {
                textBox_Ix.Text = e.X.ToString();
                textBox_Iy.Text = e.Y.ToString();
            }
        }
        private void imageBox_cam_MouseMove(object sender, MouseEventArgs e)
        {
            if (state == State.points || state == State.setP0)
            {
                setToZero(ref imgDraw_guide);
                CvInvoke.Line(imgDraw_guide, new Point(e.X, 0), new Point(e.X, 480), new MCvScalar(50, 50, 200), 1);
                CvInvoke.Line(imgDraw_guide, new Point(0, e.Y), new Point(640, e.Y), new MCvScalar(50, 50, 200), 1);
            }

            if (state == State.setP0)
            {
                p0x[OpenCamIndex] = e.X;
                p0y[OpenCamIndex] = e.Y;
                calculateMatrix(false);
            }
        }
        private void imageBox_cam_MouseUp(object sender, MouseEventArgs e)
        {

        }
        private void imageBox_cam_MouseWheel(object sender, MouseEventArgs e)
        {
            if (state == State.setP0)
            {
                if (e.Delta > 0)//上滾
                {
                    zoom[OpenCamIndex] += 0.1f;
                    calculateMatrix(false);
                    Console.WriteLine(zoom[OpenCamIndex].ToString());
                }
                else if (e.Delta < 0)
                {
                    if (zoom[OpenCamIndex] > 0.1f)
                        zoom[OpenCamIndex] -= 0.1f;
                    calculateMatrix(false);
                    Console.WriteLine(zoom[OpenCamIndex].ToString());
                }

            }
        }
        #endregion
        //--
        private void button_set4point_Click(object sender, EventArgs e)
        {
            button_set4point.BackColor = Color.LightSalmon;
            for (int i = 0; i < 4; i++)
                cam_points[OpenCamIndex, i] = new Point();
            state = State.points;
            setToZero(ref imgDraw);
        }

        private void button_setWorldpoint_Click(object sender, EventArgs e)
        {
            world_points[OpenCamIndex, 0] = new Point(int.Parse(textBox_WP0x.Text), int.Parse(textBox_WP0y.Text));
            world_points[OpenCamIndex, 1] = new Point(int.Parse(textBox_WP1x.Text), int.Parse(textBox_WP1y.Text));
            world_points[OpenCamIndex, 2] = new Point(int.Parse(textBox_WP2x.Text), int.Parse(textBox_WP2y.Text));
            world_points[OpenCamIndex, 3] = new Point(int.Parse(textBox_WP3x.Text), int.Parse(textBox_WP3y.Text));
            Txt_worldPoint("W", OpenCamIndex);
            //必須用轉換後的ix iy
            Yscale[OpenCamIndex] = ((float)world_points[OpenCamIndex, 1].Y - (float)world_points[OpenCamIndex, 0].Y) / (float)(w[OpenCamIndex] * zoom[OpenCamIndex]);
            Xscale[OpenCamIndex] = ((float)world_points[OpenCamIndex, 3].X - (float)world_points[OpenCamIndex, 0].X) / (float)(h[OpenCamIndex] * zoom[OpenCamIndex]);
            Txt_TranImage("W", OpenCamIndex);
        }

        private void checkBox_PT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_PT.Checked == true)
                calculateMatrix();
        }

        private void button_setPT_point_Click(object sender, EventArgs e)
        {
            p0x[OpenCamIndex] = 0;
            p0y[OpenCamIndex] = 0;
            state = State.setP0;
            w[OpenCamIndex] = int.Parse(textBox_PT_x.Text);
            h[OpenCamIndex] = int.Parse(textBox_PT_y.Text);
            button_setPT_point.BackColor = Color.LightSalmon;
        }

        private void calculateMatrix(bool reReadTxt = true)
        {
            string[] allString = new string[0];
            if (reReadTxt)
            {
                Txt_camPoint("R", OpenCamIndex);
                Txt_TranImage("R", OpenCamIndex);
            }
            PointF[] src = PT_Points("after", OpenCamIndex);
            PointF[] dst = PT_Points("before", OpenCamIndex);
            matrix[OpenCamIndex] = CvInvoke.GetPerspectiveTransform(dst, src);
        }

        private void button_I2W_Click(object sender, EventArgs e)
        {
            if (checkBox_PT.Checked == false)
            {
                MessageBox.Show("需要勾選轉換影像");
                return;
            }
            PointF pf = ptI2W(float.Parse(textBox_Ix.Text), float.Parse(textBox_Iy.Text), OpenCamIndex);
            textBox_Wx.Text = pf.X.ToString("0.00");
            textBox_Wy.Text = pf.Y.ToString("0.00");
        }

        public PointF ptI2W(float PT_Ix, float PT_Iy, int txtCamIndex, bool reReadTxt = false)
        {
            if (reReadTxt)
            {
                Txt_camPoint("R", txtCamIndex);
                Txt_TranImage("R", txtCamIndex);
                Txt_worldPoint("R", txtCamIndex);
            }
            return new PointF(((PT_Ix - p0x[txtCamIndex]) * Xscale[txtCamIndex]) + world_points[txtCamIndex, 0].X, ((PT_Iy - p0y[txtCamIndex]) * Yscale[txtCamIndex]) + world_points[txtCamIndex, 0].Y);
        }
        public PointF I2W(float Ix, float Iy, int txtCamIndex, bool reReadTxt = false)
        {
            if (reReadTxt)
            {
                Txt_camPoint("R", txtCamIndex);
                Txt_TranImage("R", txtCamIndex);
                Txt_worldPoint("R", txtCamIndex);
                PointF[] src = PT_Points("after", txtCamIndex);
                PointF[] dst = PT_Points("before", txtCamIndex);
                matrix[txtCamIndex] = CvInvoke.GetPerspectiveTransform(dst, src);
            }
            PointF[] inpf = new[] { new PointF(Ix, Iy) };
            PointF[] output = CvInvoke.PerspectiveTransform(inpf, matrix[txtCamIndex]);
            return new PointF(((output[0].X - p0x[txtCamIndex]) * Xscale[txtCamIndex]) + world_points[txtCamIndex, 0].X, ((output[0].Y - p0y[txtCamIndex]) * Yscale[txtCamIndex]) + world_points[txtCamIndex, 0].Y);
        }

        private static void setToZero(ref Mat mat)
        {
            byte[] value = new byte[mat.Rows * mat.Cols * mat.ElementSize];
            Marshal.Copy(value, 0, mat.DataPointer, mat.Rows * mat.Cols * mat.ElementSize);
        }
    }//form1 class

}//namespace
