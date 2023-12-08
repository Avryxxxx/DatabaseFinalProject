using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaseStudy
{
    public partial class ManageGradeForm : Form
    {
        SubjectClass subject = new SubjectClass();
        GradeClass grade = new GradeClass();
        public ManageGradeForm()
        {
            InitializeComponent();
        }

        private void ManageGradeForm_Load(object sender, EventArgs e)
        {
            comboBox_subject.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject`"));
            comboBox_subject.DisplayMember = "SubjectName";
            comboBox_subject.ValueMember = "SubjectName";
            showGrade();
        }
        private void showGrade()
        {
            DataGridView_grade.DataSource = grade.getlist(new MySqlCommand("SELECT grade.`StdId`, student.StdFirstName, student.StdLastName, grade.`SubjectName`, grade.`Quiz`, grade.`Assessment`, grade.`Activity`, grade.`Project`, grade.`MidtermExam`, grade.`FinalExam`, grade.`FinalGrade` FROM student INNER JOIN grade ON grade.`StdId`=student.StdId"));
        }

        private void button_update_Click(object sender, EventArgs e)
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



                    if (grade.updateGrade(stdId, sName, quiz, asmt, act, proj, midex, finex))
                    {
                        showGrade();
                        button_clear.PerformClick();
                        MessageBox.Show("Grade edited complete", "Update Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Grade not edit", "Update grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (textBox_stdId.Text == (""))
            {
                MessageBox.Show("Field Error- we need student Id", "Delete Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               
                    int id = Convert.ToInt32(textBox_stdId.Text);
                    if (MessageBox.Show("Are you sure you want to remove this grade", "Delete Grade", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (grade.deleteGrade(id))
                        {
                            showGrade();
                            MessageBox.Show("Grade Removed", "Delete Grade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            button_clear.PerformClick();
                        }
                    }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_quiz.Clear();
            textBox_assessment.Clear();
            textBox_activity.Clear();
            textBox_project.Clear();
            textBox_midexam.Clear();
            textBox_final.Clear();
            textBox_search.Clear();
        }

        private void DataGridView_grade_Click(object sender, EventArgs e)
        {
            textBox_stdId.Text = DataGridView_grade.CurrentRow.Cells[0].Value.ToString();
            comboBox_subject.Text = DataGridView_grade.CurrentRow.Cells[3].Value.ToString();
            textBox_quiz.Text = DataGridView_grade.CurrentRow.Cells[4].Value.ToString();
            textBox_assessment.Text = DataGridView_grade.CurrentRow.Cells[5].Value.ToString();
            textBox_activity.Text = DataGridView_grade.CurrentRow.Cells[6].Value.ToString();
            textBox_project.Text = DataGridView_grade.CurrentRow.Cells[7].Value.ToString();
            textBox_midexam.Text = DataGridView_grade.CurrentRow.Cells[8].Value.ToString();
            textBox_final.Text = DataGridView_grade.CurrentRow.Cells[9].Value.ToString();
        }
        
        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_grade.DataSource = grade.getlist(new MySqlCommand("SELECT grade.`StdId`, student.StdFirstName, student.StdLastName, grade.`SubjectName`, grade.`Quiz`, grade.`Assessment`, grade.`Activity`, grade.`Project`, grade.`MidtermExam`, grade.`FinalExam`, grade.`FinalGrade` FROM student INNER JOIN grade ON grade.`StdId`=student.StdId WHERE CONCAT(`SubjectName`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }
    }
}
