using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BEL;
using System.Data;
using System.Data.SqlClient;


namespace BAL
{
    public class Operations
    {
        public Dbconnection db = new Dbconnection();
        public Informations info = new Informations();

        public int insert(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO EmpTable (Name, Gender, DOB, Address, Username, Password, Type) VALUES ('"+info.name+"', '"+info.gender+"', '"+info.dob+"', '"+info.address+"','"+info.username+"', '"+info.password+"', '"+info.type+"')";
            return db.ExeNonQuery(cmd);
        }

        public DataTable login(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EmpTable WHERE Username='" + info.username + "' AND Password='"+info.password+"'";
            return db.ExeReader(cmd);
        }

        public DataTable viewEmployee(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EmpTable WHERE Type='U'";
            return db.ExeReader(cmd);
        }

        public int update(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE EmpTable SET Gender = '"+info.gender+"', DOB = '"+info.dob+"', Address = '"+info.address+"', Username = '"+info.username+"', Password = '"+info.password+"', Type = '"+info.type+"' WHERE (Name = '"+info.name+"')";
            return db.ExeNonQuery(cmd);
        }

        public DataTable show(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM EmpTable";
            return db.ExeReader(cmd);
        }

        public int delete(Informations info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM EmpTable WHERE Name = '"+info.name+"'";
            return db.ExeNonQuery(cmd);
        }
    }
}
