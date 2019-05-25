namespace CS_coffeeMakerVer2.MainCode
{
    partial class Form_camSetting
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
            this.comboBox_cameraIndex = new System.Windows.Forms.ComboBox();
            this.imageBox_cam = new Emgu.CV.UI.ImageBox();
            this.button_set4point = new System.Windows.Forms.Button();
            this.button_setWorldpoint = new System.Windows.Forms.Button();
            this.textBox_WP0x = new System.Windows.Forms.TextBox();
            this.textBox_WP0y = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_WPz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_WP1x = new System.Windows.Forms.TextBox();
            this.textBox_WP1y = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_WP3x = new System.Windows.Forms.TextBox();
            this.textBox_WP3y = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_WP2x = new System.Windows.Forms.TextBox();
            this.textBox_WP2y = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox_PT = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_Wx = new System.Windows.Forms.TextBox();
            this.textBox_Wy = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_Ix = new System.Windows.Forms.TextBox();
            this.textBox_Iy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_I2W = new System.Windows.Forms.Button();
            this.button_W2I = new System.Windows.Forms.Button();
            this.textBox_PT_y = new System.Windows.Forms.TextBox();
            this.textBox_PT_x = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button_setPT_point = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_cam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_cameraIndex
            // 
            this.comboBox_cameraIndex.FormattingEnabled = true;
            this.comboBox_cameraIndex.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.comboBox_cameraIndex.Location = new System.Drawing.Point(15, 16);
            this.comboBox_cameraIndex.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_cameraIndex.Name = "comboBox_cameraIndex";
            this.comboBox_cameraIndex.Size = new System.Drawing.Size(140, 24);
            this.comboBox_cameraIndex.TabIndex = 0;
            this.comboBox_cameraIndex.SelectedIndexChanged += new System.EventHandler(this.comboBox_cameraIndex_SelectedIndexChanged);
            // 
            // imageBox_cam
            // 
            this.imageBox_cam.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.imageBox_cam.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.imageBox_cam.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox_cam.Location = new System.Drawing.Point(15, 48);
            this.imageBox_cam.Name = "imageBox_cam";
            this.imageBox_cam.Size = new System.Drawing.Size(640, 480);
            this.imageBox_cam.TabIndex = 2;
            this.imageBox_cam.TabStop = false;
            this.imageBox_cam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageBox_cam_MouseDown);
            this.imageBox_cam.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox_cam_MouseMove);
            this.imageBox_cam.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageBox_cam_MouseUp);
            this.imageBox_cam.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.imageBox_cam_MouseWheel);
            // 
            // button_set4point
            // 
            this.button_set4point.Location = new System.Drawing.Point(661, 48);
            this.button_set4point.Name = "button_set4point";
            this.button_set4point.Size = new System.Drawing.Size(146, 53);
            this.button_set4point.TabIndex = 4;
            this.button_set4point.Text = "Set 4 points";
            this.button_set4point.UseVisualStyleBackColor = true;
            this.button_set4point.Click += new System.EventHandler(this.button_set4point_Click);
            // 
            // button_setWorldpoint
            // 
            this.button_setWorldpoint.Location = new System.Drawing.Point(683, 343);
            this.button_setWorldpoint.Name = "button_setWorldpoint";
            this.button_setWorldpoint.Size = new System.Drawing.Size(318, 51);
            this.button_setWorldpoint.TabIndex = 5;
            this.button_setWorldpoint.Text = "Set world point";
            this.button_setWorldpoint.UseVisualStyleBackColor = true;
            this.button_setWorldpoint.Click += new System.EventHandler(this.button_setWorldpoint_Click);
            // 
            // textBox_WP0x
            // 
            this.textBox_WP0x.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP0x.Location = new System.Drawing.Point(36, 26);
            this.textBox_WP0x.Name = "textBox_WP0x";
            this.textBox_WP0x.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP0x.TabIndex = 6;
            this.textBox_WP0x.Text = "0";
            // 
            // textBox_WP0y
            // 
            this.textBox_WP0y.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP0y.Location = new System.Drawing.Point(36, 55);
            this.textBox_WP0y.Name = "textBox_WP0y";
            this.textBox_WP0y.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP0y.TabIndex = 6;
            this.textBox_WP0y.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y :";
            // 
            // textBox_WPz
            // 
            this.textBox_WPz.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WPz.Location = new System.Drawing.Point(784, 310);
            this.textBox_WPz.Name = "textBox_WPz";
            this.textBox_WPz.Size = new System.Drawing.Size(100, 27);
            this.textBox_WPz.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(756, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Z :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_WP0x);
            this.groupBox1.Controls.Add(this.textBox_WP0y);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(661, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 95);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_WP1x);
            this.groupBox2.Controls.Add(this.textBox_WP1y);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(663, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(159, 95);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1";
            // 
            // textBox_WP1x
            // 
            this.textBox_WP1x.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP1x.Location = new System.Drawing.Point(36, 26);
            this.textBox_WP1x.Name = "textBox_WP1x";
            this.textBox_WP1x.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP1x.TabIndex = 6;
            this.textBox_WP1x.Text = "0";
            // 
            // textBox_WP1y
            // 
            this.textBox_WP1y.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP1y.Location = new System.Drawing.Point(36, 55);
            this.textBox_WP1y.Name = "textBox_WP1y";
            this.textBox_WP1y.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP1y.TabIndex = 6;
            this.textBox_WP1y.Text = "-30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "X :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 19);
            this.label9.TabIndex = 7;
            this.label9.Text = "Y :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_WP3x);
            this.groupBox3.Controls.Add(this.textBox_WP3y);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(832, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(159, 95);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3";
            // 
            // textBox_WP3x
            // 
            this.textBox_WP3x.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP3x.Location = new System.Drawing.Point(36, 26);
            this.textBox_WP3x.Name = "textBox_WP3x";
            this.textBox_WP3x.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP3x.TabIndex = 6;
            this.textBox_WP3x.Text = "-30";
            // 
            // textBox_WP3y
            // 
            this.textBox_WP3y.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP3y.Location = new System.Drawing.Point(36, 55);
            this.textBox_WP3y.Name = "textBox_WP3y";
            this.textBox_WP3y.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP3y.TabIndex = 6;
            this.textBox_WP3y.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 19);
            this.label10.TabIndex = 7;
            this.label10.Text = "X :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 19);
            this.label11.TabIndex = 7;
            this.label11.Text = "Y :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_WP2x);
            this.groupBox4.Controls.Add(this.textBox_WP2y);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(832, 209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(159, 95);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2";
            // 
            // textBox_WP2x
            // 
            this.textBox_WP2x.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP2x.Location = new System.Drawing.Point(36, 26);
            this.textBox_WP2x.Name = "textBox_WP2x";
            this.textBox_WP2x.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP2x.TabIndex = 6;
            this.textBox_WP2x.Text = "-30";
            // 
            // textBox_WP2y
            // 
            this.textBox_WP2y.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_WP2y.Location = new System.Drawing.Point(36, 55);
            this.textBox_WP2y.Name = "textBox_WP2y";
            this.textBox_WP2y.Size = new System.Drawing.Size(100, 27);
            this.textBox_WP2y.TabIndex = 6;
            this.textBox_WP2y.Text = "-30";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 19);
            this.label12.TabIndex = 7;
            this.label12.Text = "X :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 19);
            this.label13.TabIndex = 7;
            this.label13.Text = "Y :";
            // 
            // checkBox_PT
            // 
            this.checkBox_PT.AutoSize = true;
            this.checkBox_PT.Location = new System.Drawing.Point(663, 23);
            this.checkBox_PT.Name = "checkBox_PT";
            this.checkBox_PT.Size = new System.Drawing.Size(75, 20);
            this.checkBox_PT.TabIndex = 10;
            this.checkBox_PT.Text = "顯示轉換";
            this.checkBox_PT.UseVisualStyleBackColor = true;
            this.checkBox_PT.CheckedChanged += new System.EventHandler(this.checkBox_PT_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_Wx);
            this.groupBox5.Controls.Add(this.textBox_Wy);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(683, 400);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(153, 95);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "W";
            // 
            // textBox_Wx
            // 
            this.textBox_Wx.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Wx.Location = new System.Drawing.Point(36, 26);
            this.textBox_Wx.Name = "textBox_Wx";
            this.textBox_Wx.Size = new System.Drawing.Size(100, 27);
            this.textBox_Wx.TabIndex = 6;
            // 
            // textBox_Wy
            // 
            this.textBox_Wy.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Wy.Location = new System.Drawing.Point(36, 55);
            this.textBox_Wy.Name = "textBox_Wy";
            this.textBox_Wy.Size = new System.Drawing.Size(100, 27);
            this.textBox_Wy.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 19);
            this.label14.TabIndex = 7;
            this.label14.Text = "X :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 58);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 19);
            this.label15.TabIndex = 7;
            this.label15.Text = "Y :";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox_Ix);
            this.groupBox6.Controls.Add(this.textBox_Iy);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(884, 400);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(159, 95);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "I";
            // 
            // textBox_Ix
            // 
            this.textBox_Ix.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ix.Location = new System.Drawing.Point(36, 26);
            this.textBox_Ix.Name = "textBox_Ix";
            this.textBox_Ix.Size = new System.Drawing.Size(100, 27);
            this.textBox_Ix.TabIndex = 6;
            // 
            // textBox_Iy
            // 
            this.textBox_Iy.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Iy.Location = new System.Drawing.Point(36, 55);
            this.textBox_Iy.Name = "textBox_Iy";
            this.textBox_Iy.Size = new System.Drawing.Size(100, 27);
            this.textBox_Iy.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "X :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Y :";
            // 
            // button_I2W
            // 
            this.button_I2W.Location = new System.Drawing.Point(839, 425);
            this.button_I2W.Name = "button_I2W";
            this.button_I2W.Size = new System.Drawing.Size(45, 23);
            this.button_I2W.TabIndex = 11;
            this.button_I2W.Text = "<<";
            this.button_I2W.UseVisualStyleBackColor = true;
            this.button_I2W.Click += new System.EventHandler(this.button_I2W_Click);
            // 
            // button_W2I
            // 
            this.button_W2I.Location = new System.Drawing.Point(839, 459);
            this.button_W2I.Name = "button_W2I";
            this.button_W2I.Size = new System.Drawing.Size(45, 23);
            this.button_W2I.TabIndex = 11;
            this.button_W2I.Text = ">>";
            this.button_W2I.UseVisualStyleBackColor = true;
            // 
            // textBox_PT_y
            // 
            this.textBox_PT_y.Location = new System.Drawing.Point(832, 76);
            this.textBox_PT_y.Name = "textBox_PT_y";
            this.textBox_PT_y.Size = new System.Drawing.Size(71, 23);
            this.textBox_PT_y.TabIndex = 12;
            this.textBox_PT_y.Text = "100";
            // 
            // textBox_PT_x
            // 
            this.textBox_PT_x.Location = new System.Drawing.Point(832, 48);
            this.textBox_PT_x.Name = "textBox_PT_x";
            this.textBox_PT_x.Size = new System.Drawing.Size(71, 23);
            this.textBox_PT_x.TabIndex = 13;
            this.textBox_PT_x.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(810, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "Y :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(810, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "X :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft JhengHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(810, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 19);
            this.label16.TabIndex = 7;
            this.label16.Text = "選取長寬比";
            // 
            // button_setPT_point
            // 
            this.button_setPT_point.Location = new System.Drawing.Point(909, 48);
            this.button_setPT_point.Name = "button_setPT_point";
            this.button_setPT_point.Size = new System.Drawing.Size(100, 53);
            this.button_setPT_point.TabIndex = 14;
            this.button_setPT_point.Text = "設定顯示座標";
            this.button_setPT_point.UseVisualStyleBackColor = true;
            this.button_setPT_point.Click += new System.EventHandler(this.button_setPT_point_Click);
            // 
            // Form_camSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 588);
            this.Controls.Add(this.button_setPT_point);
            this.Controls.Add(this.textBox_PT_x);
            this.Controls.Add(this.textBox_PT_y);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_W2I);
            this.Controls.Add(this.button_I2W);
            this.Controls.Add(this.checkBox_PT);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_WPz);
            this.Controls.Add(this.button_setWorldpoint);
            this.Controls.Add(this.button_set4point);
            this.Controls.Add(this.imageBox_cam);
            this.Controls.Add(this.comboBox_cameraIndex);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_camSetting";
            this.Text = "Form_camSetting";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox_cam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_cameraIndex;
        private Emgu.CV.UI.ImageBox imageBox_cam;
        private System.Windows.Forms.Button button_set4point;
        private System.Windows.Forms.Button button_setWorldpoint;
        private System.Windows.Forms.TextBox textBox_WP0x;
        private System.Windows.Forms.TextBox textBox_WP0y;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_WPz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_WP1x;
        private System.Windows.Forms.TextBox textBox_WP1y;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_WP3x;
        private System.Windows.Forms.TextBox textBox_WP3y;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_WP2x;
        private System.Windows.Forms.TextBox textBox_WP2y;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox_PT;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_Wx;
        private System.Windows.Forms.TextBox textBox_Wy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_Ix;
        private System.Windows.Forms.TextBox textBox_Iy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_I2W;
        private System.Windows.Forms.Button button_W2I;
        private System.Windows.Forms.TextBox textBox_PT_y;
        private System.Windows.Forms.TextBox textBox_PT_x;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button_setPT_point;
    }
}