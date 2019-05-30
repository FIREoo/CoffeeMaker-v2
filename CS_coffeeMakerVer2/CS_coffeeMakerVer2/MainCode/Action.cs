using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_coffeeMakerVer2
{
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
        public bool execute()
        {
            try
            {
                txt.Flush();
                txt.Close();
            }
            catch { }
            if (UR.serverRunning == false)
            {
                return false;
            }
            UR.goFilePath(fileName);
            return true;
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
            subactInfo rtn = new subactInfo();
            URCoordinates up = cup.gripPos();          
            URCoordinates down = new URCoordinates(up);
            down.Y += 0.07f;//下降5公分
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());

            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("0");

            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");

            rtn.infotxt.Add("position");
            rtn.infotxt.Add(down.ToPos());

            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("35");

            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");

            up.Y -= 0.02f;//上升
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());
            return rtn;
        }
        public static subactInfo Pick(string ThePlace)
        {
            subactInfo rtn = new subactInfo();
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("0");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            if (ThePlace == "outDripTray")
            {
                string[] file = System.IO.File.ReadAllLines($"Path//{ThePlace}.path");
                foreach (string line in file)
                    rtn.infotxt.Add(line);
            }

            return rtn;
        }
            public static subactInfo Place(URCoordinates Wpoint)
        {
            subactInfo rtn = new subactInfo();
            URCoordinates up = Wpoint;
            URCoordinates down = new URCoordinates(up);
            down.Y += 0.07f;//下降5公分

            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("35");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(down.ToPos());
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("0");

            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");

            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());
            return rtn;
        }
        public static subactInfo Place(string ThePlace)
        {
            subactInfo rtn = new subactInfo();
            if(ThePlace == "toDripTray")
            {
                string[] file = System.IO.File.ReadAllLines($"Path//{ThePlace}.path");
                foreach (string line in file)
                    rtn.infotxt.Add(line);
            }
            rtn.infotxt.Add("gripper");
            rtn.infotxt.Add("0");
            rtn.infotxt.Add("sleep");
            rtn.infotxt.Add("1000");
            return rtn;
        }
        public static subactInfo Pour(Object toCup)
        {
            subactInfo rtn = new subactInfo();
            URCoordinates up = toCup.gripPos();
            up.Y -= 0.03f;//上升5公分
            URCoordinates now = new URCoordinates(up);
            rtn.infotxt.Add("position");
            rtn.infotxt.Add(up.ToPos());
            now.X -= 0.08f;
            rtn.infotxt.Add(now.ToPos());
            now.Rx -= 1.57f;
            now.Ry += 1.57f;
            rtn.infotxt.Add(now.ToPos());
            now.Rx -= 1.13f;
            now.Ry += 1.13f;
            now.X += 0.06f;
            rtn.infotxt.Add(now.ToPos());
            up.Y -= 0.02f;//上升
            rtn.infotxt.Add(up.ToPos());
            return rtn;
        }
        public static subactInfo Trigger()
        {
            subactInfo rtn = new subactInfo();
            string[] file = System.IO.File.ReadAllLines($"Path//trigger.path");
            foreach (string line in file)
                rtn.infotxt.Add(line);
            return rtn;
        }
    }
    class subactInfo
    {
        public List<string> infotxt = new List<string>();
        public int Count()
        {
            return infotxt.Count();
        }
    }
}
