using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appraisal_System.Utility;

namespace Appraisal_System.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Sex { get; set; }
        public int BaseTypeId { get; set; }
       
        public bool IsDel { get; set; }


        public static List<Users> ListAll()
        {
            DataTable dt = SqlHelper.ExecuteTable("SELECT u.Id,u.PassWord,u.BaseTypeId,u.UserName," +
                "u.Sex,u.IsDel FROM Users u");
            List<Users> users = new List<Users>();
            foreach (DataRow dr in dt.Rows )
            {
                users.Add(dr.DataRowToModel<Users>());
            }
            return users;
        }
        public static int Insert(Users user)
        {
            //@+传参是SQL server特有的
            //"INSERT SET Users(UserName,PassWord,Sex,BaseTypeId,IsDel) VALUES(@UserName,@PassWord,@Sex,@BaseTypeId,@IsDel)",
            return SqlHelper.ExecuteNonQuers($"INSERT INTO Users(UserName,PassWord,Sex,BaseTypeId,IsDel) VALUES" +
                 "(@UserName,@PassWord,@Sex,@BaseTypeId,@IsDel)",
                 new SqlParameter("@UserName",user.UserName),
                 new SqlParameter("@PassWord",user.PassWord),
                 new SqlParameter("@Sex",user.Sex),               
                 new SqlParameter("@BaseTypeId",user.BaseTypeId),               
                 new SqlParameter("@IsDel",user.IsDel)
                 );
        } 
        public static int Update(Users user)
        { 
            int rows =  SqlHelper.ExecuteNonQuers("UPDATE Users SET " +
                "PassWord = @PassWord,BaseTypeId= @BaseTypeId,UserName = @UserName,Sex = @Sex,IsDel = @IsDel WHERE Id=@Id",
                 new SqlParameter("@Id",user.Id),
                 new SqlParameter("@PassWord",user.PassWord),
                 new SqlParameter("@BaseTypeId",user.BaseTypeId),
                 new SqlParameter("@UserName",user.UserName),               
                 new SqlParameter("@Sex",user.Sex),               
                 new SqlParameter("@IsDel",user.IsDel)
                 );
            return rows;
        }
       
    }
}
