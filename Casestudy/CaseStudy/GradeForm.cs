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
    public partial class GradeForm : Form
    {   
        SubjectClass subject = new SubjectClass();
        StudentClass student = new StudentClass();
        GradeClass grade = new GradeClass ();

        public GradeForm()
        {
            InitializeComponent();
        }
        private void showGrade()
        {
            DataGridView_grade.DataSource = grade.getlist(new MySqlCommand("SELECT * FROM `grade`"));
        }
     
            private void GradeForm_Load(object sender, EventArgs e)
        {
            comboBox_subject.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject`"));
            comboBox_subject.DisplayMember = "SubjectName";
            comboBox_subject.ValueMember = "SubjectName";
            showGrade();
            
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_stdId.Text == "" || textBox_quiz.Text == "" || textBox_assessment.Text == "" || textBox_activity.Text == "" || textBox_project.Text == "" || textBox_final.Text == "" || textBox_midexam.Text == "")
            {
                MessageBox.Show("Need Grade Data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int stdId = Convert.ToInt32(textBox_stdId.Text);
                string sName = comboBox_subject.Text;
                int quiz = Convert.ToInt32(textBox_quiz.Text);
                int asmt = Convert.ToInt32(textBox_assessment.Text);
                int act = Convert.ToInt32(textBox_activity.Text);
                int proj = Convert.ToInt32(textBox_project.Text);
                int midex = Convert.ToInt32(textBox_midexam.Text);
                int finex = Convert.ToInt32(textBox_final.Text);
                if (!grade.checkGrade(stdId, sName))
                {




                    if (grade.insertGrade(stdId, sName, quiz, asmt, act, proj, midex, finex))
                    {
                        showGrade();
                        button_clear.PerformClick();
                        MessageBox.Show("New grade added", "Add Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Grade not added", "Add grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The grade for this course already exists", "Add Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            comboBox_subject.SelectedIndex = 0;
            textBox_quiz.Clear();
            textBox_assessment.Clear();
            textBox_activity.Clear();
            textBox_project.Clear();
            textBox_midexam.Clear();
            textBox_final.Clear();


        }

        private void DataGridView_grade_Click(object sender, EventArgs e)
        {
            textBox_stdId.Text = DataGridView_grade.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
