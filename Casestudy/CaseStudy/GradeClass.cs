using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class GradeClass
    {
        DBconnector connect = new DBconnector();

        public bool insertGrade(int stdId, string sName, int quiz, int asmt, int act, int proj, int midex, int finex)
        {
            double fingrd = calculateFinalGrade(quiz, asmt, act, proj, midex, finex);

            MySqlCommand command = new MySqlCommand("INSERT INTO `grade`(`StdId`, `SubjectName`, `Quiz`, `Assessment`, `Activity`, `Project`, `MidtermExam`, `FinalExam`,  `FinalGrade`) VALUES (@id, @sn, @qz, @ast, @act, @proj, @me, @fe, @fg)", connect.getconnection);
            
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = stdId;
            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = sName;
            command.Parameters.Add("@qz", MySqlDbType.Int32).Value = quiz;
            command.Parameters.Add("@ast", MySqlDbType.Int32).Value = asmt;
            command.Parameters.Add("@act", MySqlDbType.Int32).Value = act;
            command.Parameters.Add("@proj", MySqlDbType.Int32).Value = proj;
            command.Parameters.Add("@me", MySqlDbType.Int32).Value = midex;
            command.Parameters.Add("@fe", MySqlDbType.Int32).Value = finex;
            command.Parameters.Add("@fg", MySqlDbType.Double).Value = fingrd;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
        private double calculateFinalGrade(int quiz, int asmt, int act, int proj, int midex, int finex)
        {
            return (quiz * 0.2) + (asmt * 0.15) + (act * 0.1) + (proj * 0.25) + (midex * 0.15) + (finex * 0.15);
        }
        public DataTable getlist(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool checkGrade(int stdId, string sName)
        {
            DataTable table = getlist(new MySqlCommand("SELECT * FROM `grade` WHERE `StdId`= "+  stdId +" AND `SubjectName`= '"+ sName +"'"));
            if(table.Rows.Count > 0)
            { 
                return true;  
            }
            else
            {
                return false;
            }
        }
        public bool updateGrade(int stdId, string sName, int quiz, int asmt, int act, int proj, int midex, int finex)
        {
            double fingrd = calculateFinalGrade(quiz, asmt, act, proj, midex, finex);

            MySqlCommand command = new MySqlCommand("UPDATE `grade` SET `Quiz`=@qz,`Assessment`=@ast ,`Activity`=@act,`Project`=@proj,`MidtermExam`=@me,`FinalExam`=@fe,`FinalGrade`=@fg WHERE `StdId`=@id AND `SubjectName`=@sn", connect.getconnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = stdId;
            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = sName;
            command.Parameters.Add("@qz", MySqlDbType.Int32).Value = quiz;
            command.Parameters.Add("@ast", MySqlDbType.Int32).Value = asmt;
            command.Parameters.Add("@act", MySqlDbType.Int32).Value = act;
            command.Parameters.Add("@proj", MySqlDbType.Int32).Value = proj;
            command.Parameters.Add("@me", MySqlDbType.Int32).Value = midex;
            command.Parameters.Add("@fe", MySqlDbType.Int32).Value = finex;
            command.Parameters.Add("@fg", MySqlDbType.Double).Value = fingrd;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public bool deleteGrade(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `grade` WHERE `StdID`= @id", connect.getconnection);
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }

        }
    }
}
