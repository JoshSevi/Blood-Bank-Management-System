using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startpose = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpose += 1;
            MyProgress.Value = startpose;
            if(MyProgress.Value == 100)
            {
                MyProgress.Value = 0;
                timer1.Stop();
                login log = new login();
                log.Show();
                this.Hide();
            }
        }

        private void MyProgress_Click(object sender, EventArgs e)
        {

        }
        protected override CreateParams CreateParams
        {
            get
            {
                //const int CS_DROPSHADOW = 0x02000000;
                CreateParams handleParams = base.CreateParams;
                //handleParams.ClassStyle |= CS_DROPSHADOW;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
    }
}
