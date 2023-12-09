using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["constr"].ToString());
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
              GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //go button
            getMemberById();
        }

        void getMemberById()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='" + TextBox1.Text.Trim()+"'", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox7.Text = dr.GetValue(10).ToString();
                        TextBox3.Text = dr.GetValue(1).ToString();
                        TextBox4.Text = dr.GetValue(2).ToString();
                        TextBox8.Text = dr.GetValue(3).ToString();
                        TextBox5.Text = dr.GetValue(4).ToString();
                        TextBox6.Text = dr.GetValue(5).ToString();
                        TextBox9.Text = dr.GetValue(6).ToString();
                        TextBox10.Text = dr.GetValue(7).ToString();
                        
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //add fuck
            updateMemberStatusById("active");
        }
        
        void updateMemberStatusById(string status)
        {
            if (!checkMemberExists())
            {
                Response.Write("<script>alert('Please Check Credentails')</script>");
            }
            else
            {
                try
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Member Status Updated')</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("pending");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("deactive");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteMemberById();
        }

        void deleteMemberById()
        {
            if (!checkMemberExists())
            {
                Response.Write("<script>alert('Please Check Credentails')</script>");
            }
            else
            {
                try
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearForm();
                    Response.Write("<script>alert('Member Deleted Updated')</script>");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                }
            }
        }

        void clearForm() 
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = ""; 
            TextBox3.Text = ""; 
            TextBox4.Text = ""; 
            TextBox8.Text = ""; 
            TextBox5.Text = ""; 
            TextBox6.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";

        }

        bool checkMemberExists()
        {
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd = new SqlCommand("SELECT * from  member_master_tbl where member_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}