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
using DGVPrinterHelper;

namespace CaseStudy
{
    
    public partial class PrintGrade : Form
    {
        GradeClass grade = new GradeClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintGrade()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_grade.DataSource = grade.getlist(new MySqlCommand("SELECT grade.`StdId`, student.StdFirstName, student.StdLastName, grade.`SubjectName`, grade.`Quiz`, grade.`Assessment`, grade.`Activity`, grade.`Project`, grade.`MidtermExam`, grade.`FinalExam`, grade.`FinalGrade` FROM student INNER JOIN grade ON grade.`StdId`=student.StdId WHERE CONCAT(`SubjectName`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }

        private void PrintGrade_Load(object sender, EventArgs e)
        {
            showGrade();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "SpongeBob University Grade List";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "SBUniversity";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_grade);
        }
        private void showGrade()
        {
            DataGridView_grade.DataSource = grade.getlist(new MySqlCommand("SELECT grade.`StdId`, student.StdFirstName, student.StdLastName, grade.`SubjectName`, grade.`Quiz`, grade.`Assessment`, grade.`Activity`, grade.`Project`, grade.`MidtermExam`, grade.`FinalExam`, grade.`FinalGrade` FROM student INNER JOIN grade ON grade.`StdId`=student.StdId"));
        }
    }
}
