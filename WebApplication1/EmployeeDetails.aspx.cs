using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ITD-LIS-WS-040\\SQLEXPRESS; initial catalog=DB11102024; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "D")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbdelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                display();
            }
            else if (e.CommandName == "E")
            {
                Response.Redirect("employee.aspx?id=" + e.CommandArgument);
            }

        }

        public void display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("dbdisplay", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            gv.DataSource = dt;
            gv.DataBind();
            
        }
    }
}