using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using WebService1.DataSet1TableAdapters;

namespace WebService1
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {



        [WebMethod]
        public string getUsers()
        {
           tblUserTableAdapter tbl = new tblUserTableAdapter();

           List<user> items = new List<user>();

         
            user u;
            foreach (DataSet1.tblUserRow row in tbl.GetData())
            {
                u = new user();
                u.firstName = row.firstName;
                u.lastName = row.lastName;
                items.Add (u);
                
            }

            return serialize(items);
        }

        public String serialize(Object o)
        {
            try { return new JavaScriptSerializer().Serialize(o); }
            catch (Exception e) { return "error converting data to Json"; }
        }
    
    }
}