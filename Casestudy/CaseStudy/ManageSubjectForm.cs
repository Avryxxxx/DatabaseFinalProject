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
    public partial class ManageSubjectForm : Form
    {

        SubjectClass subject = new SubjectClass();

        public ManageSubjectForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void ManageSubjectForm_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            DataGridView_subject.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject`"));
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_id.Clear();
            textBox_Sname.Clear();
            textBox_Shour.Clear();
            textBox_description.Clear();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (textBox_Sname.Text == "" || textBox_Shour.Text == "" || textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need Subject Data", "Rield Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = Convert.ToInt32(textBox_id.Text);
                string sName = textBox_Sname.Text;
                int hr = Convert.ToInt32(textBox_Shour.Text);
                string desc = textBox_description.Text;

                if (subject.updateSubject(id, sName, hr, desc))
                {
                    showData();
                    button_clear.PerformClick();
                    MessageBox.Show("Subject Update Successfully", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show(" Error Subject not Edit", "Update Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text.Equals(""))
            {
                MessageBox.Show("Need Subject Id", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {


                    int id = Convert.ToInt32(textBox_id.Text);
                    if (subject.deleteSubject(id))
                    {
                        showData();
                        button_clear.PerformClick();
                        MessageBox.Show("Subject Deleted", "Delete Subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Remove Subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridView_subject_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_subject.CurrentRow.Cells[0].Value.ToString();
            textBox_Sname.Text = DataGridView_subject.CurrentRow.Cells[1].Value.ToString();
            textBox_Shour.Text = DataGridView_subject.CurrentRow.Cells[2].Value.ToString();
            textBox_description.Text = DataGridView_subject.CurrentRow.Cells[3].Value.ToString();
        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_subject.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject` WHERE CONCAT(`SubjectName`)LIKE '%"+textBox_search.Text+"%'"));
            textBox_search.Clear();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


