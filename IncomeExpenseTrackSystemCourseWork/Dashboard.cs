using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace IncomeExpenseTrackSystemCourseWork
{
    public partial class Dashboard : UserControl
    {
        string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Egor\Documents\expense.mdf;Integrated Security=True;Connect Timeout=30";

        public Dashboard()
        {
            InitializeComponent();

            incomeTodayIncome();
        }

        public void incomeTodayIncome()
        {
            using(SqlConnection connect = new SqlConnection(stringConnection))
            {
                connect.Open();

                string query = "SELECT SUM(income) FROM income WHERE date_income = @date_in";

                using(SqlCommand cmd = new SqlCommand(query,connect))
                {

                    DateTime today = DateTime.Today;
                    cmd.Parameters.AddWithValue("@date_in", today);

                    object result = cmd.ExecuteScalar();

                    if(result != DBNull.Value)
                    {
                        decimal todayCost = Convert.ToDecimal(result);

                        income_totalIncome.Text = "₽" + todayCost.ToString("0.00");
                    }
                    else
                    {
                        income_totalIncome.Text = "₽0.00";
                    }
                }
            }
        }

        public void incomeYesterdayIncome()
        {
            using(SqlConnection connect = new SqlConnection(stringConnection))
            {
                connect.Open();

                string query = "SELECT SUM(income) FROM income WHERE CONVERT(DATE, TImestamp) = DATEADD(day,DATEDIFF(day, 0, GETDATE()), -1)";

                using(SqlCommand cmd = new SqlCommand(query, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if(result != DBNull.Value)
                    {
                        //decimal yesterdayCost = result
                    }

                }

            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
