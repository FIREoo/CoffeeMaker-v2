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
        }


        private void button_setCam_Click(object sender, EventArgs e)
        {
            MainCode.Form_camSetting setForm = new MainCode.Form_camSetting();
            setForm.ShowDialog();
        }

    }
}
