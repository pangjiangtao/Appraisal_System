﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appraisal_System.Utility;

namespace Appraisal_System.Models
{
    public class UserAppraisalBases
    {
        public int Id { get; set; }
        public string UserName{ get; set; }
        public string Sex { get; set; }
        public int BaseTypeId{ get; set; }
        public string BaseType{ get; set; }
        public int AppraisalBase{ get; set; }
        public bool IsDel{ get; set; }

        public static DataTable GetDtJoinAppraisal()
        {
            DataTable dt = SqlHelper.ExecuteTable(
                "SELECT u.Id,u.UserName,u.Sex,u.BaseTypeId,u.IsDel,a.AppraisalBase,a.BaseType" +
                " From USers u Left JOIN AppraisalBases a ON u.BaseTypeId=a.Id");
            return dt;
        }
        public static List<UserAppraisalBases> GetListJoinAppraisal()
        {
            List<UserAppraisalBases> userAppraisalBases= new List<UserAppraisalBases>();
            DataTable dt = GetDtJoinAppraisal();
            foreach(DataRow dr in dt.Rows)
            {
                userAppraisalBases.Add(ToModel(dr));

            }
            return userAppraisalBases;
        }
        private static UserAppraisalBases ToModel(DataRow dr)
        {
            UserAppraisalBases userAppraisalBases = new UserAppraisalBases();
            userAppraisalBases.Id = (int)dr["Id"];
            userAppraisalBases.UserName = dr["UserName"].ToString();
            userAppraisalBases.Sex = dr["Sex"].ToString();
            userAppraisalBases.BaseTypeId = (int)dr["BaseTypeId"];
            userAppraisalBases.BaseType = dr["BaseType"].ToString();
            userAppraisalBases.AppraisalBase = (int)dr["AppraisalBase"];
            userAppraisalBases.IsDel = (bool)dr["IsDel"];
            return userAppraisalBases;
        }
    }
}
