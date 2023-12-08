using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CaseStudy
{
    class SubjectClass
    {
        DBconnector connect = new DBconnector();
        public bool insertSubject(string sName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `subject`(`SubjectName`, `SubjectHour`, `Description`) VALUES (@sn,@sh,@desc)", connect.getconnection);

            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = sName;
            command.Parameters.Add("@sh", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
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

        public DataTable getSubject(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool updateSubject(int id, string sName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `subject` SET `SubjectName`=@sn,`SubjectHour`=@sh,`Description`=@desc WHERE `SubjectID`=@id", connect.getconnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@sn", MySqlDbType.VarChar).Value = sName;
            command.Parameters.Add("@sh", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
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

        public bool deleteSubject(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `subject` WHERE `SubjectID`= @id", connect.getconnection);
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
