using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _005_SpaceTrade_Shane_Johannes
{
    public partial class Interface : Form
    {
        public Interface(string type)
        {
            InitializeComponent();
            Type = type;
        }

        public string Action { get; set; }
        public List<int> i_Result1 { get; set; }
        public List<int> i_Result2 { get; set; }
        string Type;
        List<Button> btns = new List<Button>();
        Timer Add = new Timer();
        Random rnd = new Random();
        List<string> Erze = new List<string>();
        ClientDB conof = new ClientDB();

        private void Interface_Load(object sender, EventArgs e)
        {
            i_Result1 = new List<int>();
            i_Result2 = new List<int>();
            Add.Interval = 1000;
            Add.Tick += new EventHandler(Add_Tick);
            Add.Enabled = true;
            Add.Stop();
            btns.Add(btn_1);
            btns.Add(btn_2);
            btns.Add(btn_3);
            btns.Add(btn_4);
            btns.Add(btn_5);

            if(Type == "Bridge")
            {
                Bridge();
            }

            if(Type == "Planet")
            {
                Planet();
            }

            if(Type == "Station")
            {
                Station();
            }
        }

        private void Add_Tick(object sender, EventArgs e)
        {
            int num = rnd.Next(0, 3);
            int i = rnd.Next(0, Erze.Count());
            lbl_2.Text = lbl_1.Text;
            lbl_1.Text = "+ "+num+Erze[i];
            i_Result1[i] += num;
        }

        private void Show_Buttons(int Count)
        {
            for(int i = 0; i<Count;i++)
            {
                btns[i].Enabled = true;
                btns[i].Visible = true;
            }
        }

        private void Bridge()
        {
            this.BackgroundImage = _005_SpaceTrade_Shane_Johannes.Properties.Resources.mission_control;
            Show_Buttons(1);
            btn_1.Text = "Start Resource gathering!";
        }

        private void Planet()
        {
            Show_Buttons(2);
            btn_1.Text = "Start Mining!";
            btn_2.Text = "Start Exploring!";
            conof.connect();
            Erze = conof.Select("Select name from Erze", 0);
            conof.disconnect();
            for(int i = 0; i<Erze.Count();i++)
            {
                i_Result1.Add(0);
            }
        }

        private void Station()
        {
            Show_Buttons(2);
            for(int i = 0; i<Erze.Count();i++)
            {
                cmb_1.Items.Add(Erze[i]);
            }
            btn_1.Text = "Buy!";
            btn_2.Text = "Sell!";
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            if(Type == "Planet")
            {
                Show_Buttons(3);
                Add.Start();
                btn_2.Enabled = false;
                btn_2.Visible = false;
                btn_3.Text = "Stop Mining!";

            }
            if(Type == "Bridge")
            {
                this.DialogResult = DialogResult.OK;
                Action = "newsys";
                this.Close();
            }
            if(Type == "Station")
            {

            }
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            if(Type == "Planet")
            {
                Show_Buttons(3);
                Add.Start();
                btn_1.Enabled = false;
                btn_1.Visible = false;
                btn_3.Text = "Stop Exploring!";
            }
            if(Type == "Station")
            {

            }
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            if(Type == "Planet")
            {
                btn_3.Hide();
                Add.Stop();
                lbl_2.Text = "";
                lbl_1.Text = "";
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {

        }
    }
}
