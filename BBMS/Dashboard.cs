using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\-\Documents\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from EmployeeTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserLbl.Text = dt2.Rows[0][0].ToString();

            //BLOOD STOCKS
            SqlDataAdapter sda3 = new SqlDataAdapter("Select Sum(BStock) from BloodTbl", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            int BStock = Convert.ToInt32(dt3.Rows[0][0].ToString());
            TotalBStockLbl.Text = "" + BStock;
            SqlDataAdapter sda4 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "A+" + "'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            PBStockALbl.Text = dt4.Rows[0][0].ToString();
            SqlDataAdapter sda5 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "B+" + "'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            PBStockBLbl.Text = dt5.Rows[0][0].ToString();
            SqlDataAdapter sda6 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "AB+" + "'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            PBStockABLbl.Text = dt6.Rows[0][0].ToString();
            SqlDataAdapter sda7 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "O+" + "'", Con);
            DataTable dt7 = new DataTable();
            sda7.Fill(dt7);
            PBStockOLbl.Text = dt7.Rows[0][0].ToString();
            SqlDataAdapter sda8 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "A-" + "'", Con);
            DataTable dt8 = new DataTable();
            sda8.Fill(dt8);
            NBStockALbl.Text = dt8.Rows[0][0].ToString();
            SqlDataAdapter sda9 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "B-" + "'", Con);
            DataTable dt9 = new DataTable();
            sda9.Fill(dt9);
            NBStockBLbl.Text = dt9.Rows[0][0].ToString();
            SqlDataAdapter sda10 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "AB-" + "'", Con);
            DataTable dt10 = new DataTable();
            sda10.Fill(dt10);
            NBStockABLbl.Text = dt10.Rows[0][0].ToString();
            SqlDataAdapter sda11 = new SqlDataAdapter("Select BStock from BloodTbl where BGroup='" + "O-" + "'", Con);
            DataTable dt11 = new DataTable();
            sda11.Fill(dt11);
            NBStockOLbl.Text = dt11.Rows[0][0].ToString();


            Con.Close();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            BloodTransfer bt = new BloodTransfer();
            bt.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            BloodStock bs = new BloodStock();
            bs.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewPatients vp = new ViewPatients();
            vp.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            DonateBlood db = new DonateBlood();
            db.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewDonor vd = new ViewDonor();
            vd.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor d = new Donor();
            d.Show();
            this.Hide();
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
