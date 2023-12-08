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

    public partial class PrintSubjectForm : Form
    {
        SubjectClass subject = new SubjectClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintSubjectForm()
        {
            InitializeComponent();
        }

        private void PrintSubjectForm_Load(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject`"));
        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = subject.getSubject(new MySqlCommand("SELECT * FROM `subject` WHERE CONCAT(`SubjectName`)LIKE '%" + textBox_search.Text + "%'"));
            textBox_search.Clear();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "SpongeBob University Course List";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "SBUniversity";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_student);
        }
    }
}
