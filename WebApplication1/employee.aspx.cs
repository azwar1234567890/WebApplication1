using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class employee : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=ITD-LIS-WS-040\\SQLEXPRESS; initial catalog=DB11102024; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
                {
                    dbedit();
                }
                displaygender();
                displaydesignation();
                

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(btnSubmit.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbinsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NAME", txtname.Text);
                cmd.Parameters.AddWithValue("@GENDER", rbl.Text);
                cmd.Parameters.AddWithValue("@DESIGNATION", ddl.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("EmployeeDetails.aspx");
            }
            else if (btnSubmit.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("dbupdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ViewState["r"]);
                cmd.Parameters.AddWithValue("@NAME", txtname.Text);
                cmd.Parameters.AddWithValue("@GENDER", rbl.SelectedValue);
                cmd.Parameters.AddWithValue("@DESIGNATION", ddl.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                btnSubmit.Text = "Submit";
                Response.Redirect("EmployeeDetails.aspx");
            }
            
           
        }

        public void displaygender()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("displaygender", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            rbl.DataTextField = "G_NAME";
            rbl.DataValueField = "G_ID";
            rbl.DataSource = dt;
            rbl.DataBind();
        }

        public void displaydesignation()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("displaydesignation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();            
            ddl.DataTextField = "D_NAME";
            ddl.DataValueField = "D_ID";
            ddl.DataSource = dt;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        public void dbedit()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("dbedit",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", Request.QueryString["id"]);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);   
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            txtname.Text  = dt.Rows[0][1].ToString();
            rbl.Text = dt.Rows[0][2].ToString();
            ddl.Text = dt.Rows[0][3].ToString();
            btnSubmit.Text = "Update";
            ViewState["r"] = Request.QueryString["id"];
        }
    }
}