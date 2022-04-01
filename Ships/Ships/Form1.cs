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

namespace Ships
{
    using System.Data;
    using System.Data.SqlClient;

    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        SqlDataAdapter dataAdapterVoyage;

        SqlCommandBuilder cb;

        DataSet dataSet = new DataSet();

        BindingSource bindingSourceVoyage= new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection("Data Source = DESKTOP-B3OL4T0; Initial Catalog = ShipsMonitoringSystem; Integrated Security=True");

            dataAdapterVoyage = new SqlDataAdapter("Select * from Voyage", sqlConnection);

            cb = new SqlCommandBuilder(dataAdapterVoyage);

            dataAdapterVoyage.Fill(dataSet, "Voyage");

            bindingSourceVoyage.DataSource = dataSet;
            bindingSourceVoyage.DataMember = "Voyage";

            dataGridViewVoyage.DataSource = bindingSourceVoyage;

            dataGridViewVoyage.ClearSelection();
            dataGridViewVoyage.Rows[bindingSourceVoyage.Position].Selected = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create a command object identifying the stored procedure
            SqlCommand command = new SqlCommand("ship_avg_voyage_days", sqlConnection);

            DataTable dt = new DataTable();

            try
            {            // set the command object so it knows to execute a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                if (textBoxShipId.Text == ""){
                    dataAdapterVoyage = new SqlDataAdapter("Select * from Voyage", sqlConnection);

                    cb = new SqlCommandBuilder(dataAdapterVoyage);

                    dataAdapterVoyage.Fill(dataSet, "Voyage");

                    bindingSourceVoyage.DataSource = dataSet;
                    bindingSourceVoyage.DataMember = "Voyage";

                    dataGridViewVoyage.DataSource = bindingSourceVoyage;

                    dataGridViewVoyage.ClearSelection();
                    dataGridViewVoyage.Rows[bindingSourceVoyage.Position].Selected = true;


                }

                else
                {
                    command.Parameters.Add("@voyage_ship_id", SqlDbType.Int).Value = textBoxShipId.Text;

                    sqlConnection.Open();
                    dataAdapterVoyage.SelectCommand = command;
                    dataAdapterVoyage.Fill(dt);
                    dataGridViewVoyage.DataSource = dt;
                    sqlConnection.Close();
                }

            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
