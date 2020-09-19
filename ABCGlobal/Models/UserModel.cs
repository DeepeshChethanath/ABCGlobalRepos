using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ABCGlobal.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phCode { get; set; }
        public string mobile { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public string loginMsg { get; set; }

        DBConnection dbconn = new DBConnection();

        public int Register(UserModel candiModel)
        {
            string insCandidate = "INSERT INTO `user_details` (`FirstName`, `LastName`,`Password`, `Email`, `PhCode`, `Mobile`, `City`, `State`, `Country`, `Pincode`) VALUES ('" + candiModel.firstName + "','" + candiModel.lastName + "','','" + candiModel.email + "','" + candiModel.phCode + "','" + candiModel.mobile + "','" + candiModel.city + "','" + candiModel.state + "','" + candiModel.country + "','" + candiModel.pincode + "')";
            int i = dbconn.ExecuteQueryMySql(insCandidate);
            return i;
        }

        public bool CheckLogin(string email,string password)
        {
            bool chk = false;
            string check = "SELECT * from user_details where email='" + email + "' and password='" + password + "'";
            DataSet ds = dbconn.ReturnDataSet(check);
            if (ds.Tables[0] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    chk = true;
                }
            }
            return chk;
        }
    }
}