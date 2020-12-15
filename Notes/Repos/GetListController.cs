using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Notes.Repos
{
    public class GetListController
    {

        public static List<SelectListItem> GetCategoryList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["NoteModels"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT NoteCategory_ID,Description FROM NoteCategory";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Description"].ToString(),
                                Value = sdr["NoteCategory_ID"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }
    }
}