using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CaseStudy
{
    public partial class SubjectForm : Form
    {
        SubjectClass subject = new SubjectClass();
        public SubjectForm()
        {
            InitializeComponent();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_Sname.Text == "" || textBox_Shour.Text == "")
            {
                MessageBox.Show("Need Subject Data", "Rield Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string sName = textBox_Sname.Text;
                int hr = Convert.ToInt32(textBox_Shour.Text);
                string desc = textBox_description.Text;

                if (subject.insertSubject(sName, hr, desc))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("New Subject Inserted", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Subject not inserted", "Add Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Sname.Clear();
            textBox_Shour.Clear();
            textBox_description.Clear();
           
        }

        private void SubjectForm_Load(object sender, EventArgs e)
        {
            showData();        }

        private void showData()
        {
            DataGridView_subject.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject`"));
        }

        private void DataGridView_subject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
