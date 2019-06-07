using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_coffeeMakerVer2
{
    public partial class Form1 : Form
    {
        static class rb
        {
            public static class Act
            {
                static public RadioButton pick = new RadioButton();
                public static class Pick
                {
                    static public RadioButton cup1 = new RadioButton();
                    static public RadioButton cup2 = new RadioButton();
                    static public RadioButton fromDrip = new RadioButton();
                }

                static public RadioButton place = new RadioButton();
                public static class Place
                {
                    static public RadioButton toDrip = new RadioButton();
                    static public RadioButton toPos = new RadioButton();
                }
                static public RadioButton pour = new RadioButton();
                public static class Pour
                {
                    static public RadioButton toCup1 = new RadioButton();
                    static public RadioButton toCup2 = new RadioButton();
                }
                static public RadioButton trigger = new RadioButton();

                static public RadioButton scoop = new RadioButton();

                static public RadioButton addaSpoon = new RadioButton();
                public static class AddaSpoon
                {
                    static public RadioButton toCup1 = new RadioButton();
                    static public RadioButton toCup2 = new RadioButton();
                }
                static public RadioButton stir = new RadioButton();
                public static class Stir
                {
                    static public RadioButton toCup1 = new RadioButton();
                    static public RadioButton toCup2 = new RadioButton();
                }
                }
        }

        private void renameControl()
        {
            rb.Act.pick = radioButton_Act_pick;
            rb.Act.Pick.cup1 = radioButton_Act_pick_cup1;
            rb.Act.Pick.cup2 = radioButton_Act_pick_cup2;
            rb.Act.Pick.fromDrip = radioButton_Act_pick_drip;

            rb.Act.place = radioButton_Act_place;
            rb.Act.Place.toDrip = radioButton_Act_place_drip;
            rb.Act.Place.toPos = radioButton_Act_place_pos;

            rb.Act.pour = radioButton_Act_pour;
            rb.Act.Pour.toCup1 = radioButton_Act_pour_to1;
            rb.Act.Pour.toCup2 = radioButton_Act_pour_to2;
            rb.Act.trigger = radioButton_Act_trigger;

            rb.Act.scoop = radioButton_Act_scoop;
            rb.Act.addaSpoon = radioButton_Act_addaSpoon;
            rb.Act.AddaSpoon.toCup1 = radioButton_Act_addaSpoon_toCup1;
            rb.Act.AddaSpoon.toCup2 = radioButton_Act_addaSpoon_toCup2;

            rb.Act.stir = radioButton_Act_stir;
            rb.Act.Stir.toCup1 = radioButton_Act_stir_cup1;
            rb.Act.Stir.toCup2 = radioButton_Act_stir_cup2;
        }
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

        #region select combobox
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
        private void comboBox_selectPos_DropDown(object sender, EventArgs e)
        {
            ((ComboBox)sender).BackColor = Color.White;
            readPosPathFile();
        }
        #endregion select combobox


        private void button_setCam_Click(object sender, EventArgs e)
        {
            MainCode.Form_camSetting setForm = new MainCode.Form_camSetting();
            setForm.ShowDialog();
        }

    }
}