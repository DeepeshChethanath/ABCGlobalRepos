using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace ABCGlobal.Models
{
    public class CandidateModel
    {
        public int id { get; set; }
        public string candiName { get; set; }
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
        public string profilePic { get; set; }
        public string workExp { get; set; }
        public string address { get; set; }

        public List<CandidateModel> lstCandidates = new List<CandidateModel>();

        public List<string> lstCountry = new List<string>();

        DBConnection dbconn = new DBConnection();

        public List<CandidateModel> GetCandidateList()
        {
            MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringMySql"].ConnectionString);
            conn.Open();
            string strCandidates = "SELECT * FROM candidate_details";
            MySqlCommand cmdComm = new MySqlCommand(strCandidates, conn);
            MySqlDataReader dr = cmdComm.ExecuteReader();
            lstCandidates.Clear();
            CandidateModel candi = null;

            while (dr.Read())
            {
                candi = new CandidateModel();
                candi.id = Convert.ToInt32(dr["id"]);
                candi.candiName = dr["FirstName"].ToString() +" "+ dr["LastName"].ToString();
                candi.firstName = dr["FirstName"].ToString();
                candi.lastName = dr["LastName"].ToString();
                candi.email = dr["Email"].ToString();
                candi.phCode = dr["PhCode"].ToString();
                candi.mobile = dr["Mobile"].ToString();
                candi.city = dr["City"].ToString();
                candi.state = dr["State"].ToString();
                candi.country = dr["Country"].ToString();
                candi.pincode = dr["Pincode"].ToString();
                candi.workExp = dr["WorkExp"].ToString();
                candi.address = dr["State"].ToString() + ", " + dr["Country"].ToString();
                lstCandidates.Add(candi);
            }

            return lstCandidates;
        }

        public int AddCandidate(CandidateModel candiModel)
        {
            string insCandidate = "INSERT INTO `candidate_details` (`FirstName`, `LastName`, `Email`, `PhCode`, `Mobile`, `City`, `State`, `Country`, `Pincode`,`ProfilePic`, `WorkExp`) VALUES ('" + candiModel.firstName + "','" + candiModel.lastName + "','" + candiModel.email + "','" + candiModel.phCode + "','" + candiModel.mobile + "','" + candiModel.city + "','" + candiModel.state + "','" + candiModel.country + "','" + candiModel.pincode + "','" + candiModel.profilePic + "','" + candiModel.workExp + "')";
            int i = dbconn.ExecuteQueryMySql(insCandidate);
            return i;
        }

        public bool DeleteCandidate(string id)
        {
            bool success = false;
            string insCandidate = "DELETE FROM `candidate_details` WHERE (`Id`='" + id + "')";
            int i = dbconn.ExecuteQueryMySql(insCandidate);
            if (i > 0)
                success = true;
            return success;
        }

        public CandidateModel GetCandidate(int id)
        {
            MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringMySql"].ConnectionString);
            conn.Open();
            string strCandidates = "SELECT * FROM candidate_details where id= "+ id;
            MySqlCommand cmdComm = new MySqlCommand(strCandidates, conn);
            MySqlDataReader dr = cmdComm.ExecuteReader();
            lstCandidates.Clear();
            CandidateModel candi = null;

            while (dr.Read())
            {
                candi = new CandidateModel();
                candi.id = Convert.ToInt32(dr["id"]);
                candi.candiName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                candi.firstName = dr["FirstName"].ToString();
                candi.lastName = dr["LastName"].ToString();
                candi.email = dr["Email"].ToString();
                candi.phCode = dr["PhCode"].ToString();
                candi.mobile = dr["Mobile"].ToString();
                candi.city = dr["City"].ToString();
                candi.state = dr["State"].ToString();
                candi.country = dr["Country"].ToString();
                candi.pincode = dr["Pincode"].ToString();
                candi.workExp = dr["WorkExp"].ToString();
                candi.address = dr["State"].ToString() + ", " + dr["Country"].ToString();
               
            }

            return candi;
        }


        public void GetCountry()
        {
            CandidateModel candi = new CandidateModel();
            string str = "https://restcountries.eu/rest/v2/all";
            WebClient webClient = new WebClient();
            if (webClient == null)
            {
                webClient = new WebClient();
            }
            else
            {
                webClient.Dispose();
                webClient = null;
                webClient = new WebClient();
            }
            //Set Header  
            webClient.Headers["User-Agent"] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            //Download Content  
            string JsonSting = webClient.DownloadString(str);
            //Convert JSON to Datatable  
            dynamic country = JsonConvert.DeserializeObject(JsonSting);
            foreach (var obj in country)
            {
                candi.lstCountry.Add(obj.name.Value);
            }
            //
        }
    }
}