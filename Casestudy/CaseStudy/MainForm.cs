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
    public partial class MainForm : Form
    {
        StudentClass student = new StudentClass();
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            studentcount();        }
        private void studentcount()
        {
            label_totalStd.Text = "Total Students :" + student.totalStudent();
            label_maleStd.Text = "Male :" + student.maleStudent();
            label_femaleStd.Text = "Female :" + student.femaleStudent();
        }
        private void customizeDesign()
        {
            panel_stdsubmenu.Visible = false;
            panel_subjsubmenu.Visible = false;
            panel_grdsubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_stdsubmenu.Visible == true) 
                panel_stdsubmenu.Visible = false;

            if (panel_subjsubmenu.Visible == true) 
                panel_subjsubmenu.Visible = false;

            if (panel_grdsubmenu.Visible == true) 
                panel_grdsubmenu.Visible = false;
        }

        private void showSubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdsubmenu);
        }
        #region StdSubmenu
        private void button_registration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterForm());
            
            hideSubmenu();
        }

        private void button_manageStd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageStudentForm());
            
            hideSubmenu();
        }
 
        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudent());
            
            hideSubmenu();
        }
        #endregion StdSubmenu
        private void button_subj_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_subjsubmenu);
        }

        #region SubjSubmenu
        private void button_newSubj_Click(object sender, EventArgs e)
        {
            openChildForm(new SubjectForm());
            
            hideSubmenu();
        }

        private void button_manageSubj_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageSubjectForm()); 
            hideSubmenu();
        }

        private void button_subjPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintSubjectForm());
            hideSubmenu();
        }
        #endregion SubjSubmenu

        private void button10_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_grdsubmenu);
        }

        #region GrdSubmenu
        private void button_newGrd_Click(object sender, EventArgs e)
        {
            openChildForm(new GradeForm());
            hideSubmenu();
        }

        private void button_manageGrd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageGradeForm());
            hideSubmenu();
        }

        private void button_grdPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintGrade());
            hideSubmenu();
        }
        #endregion GrdSubmenu

        private void button7_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_main.Controls.Add(panel_cover);
            studentcount();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(activeForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {

        }
    }
}
