using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;
using Microsoft.VisualBasic;

public partial class login : System.Web.UI.Page
{

    private static readonly string DBName = ConfigurationManager.AppSettings.Get("DBName").ToString();
    private static readonly string DBDriver = ConfigurationManager.AppSettings.Get("DBDriver").ToString();
    private static string DBConnectionString = DBDriver + HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath + "/App_Data/") + DBName;
    
    public static OleDbConnection getconnection()
    {
        OleDbConnection conn = new OleDbConnection(DBConnectionString);
        return conn;
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_click(object sender, EventArgs e)
    {
        int role = -1;

        if (student.Checked)
        {
            role = 2;
        }
        else if (system.Checked)
        {
            role = 0;
        }
        else if (teacher.Checked) {
            role = 1;
        }
        
       
        OleDbConnection conn1 = getconnection();
        string sql = "select UNAME,ROLEID,UROLE from [USER] where UNAME ='" + username.Text + "' and UPASSWORD='" + password.Text + "'" + " and UROLE= " + role ;
        OleDbCommand cmd = new OleDbCommand(sql, conn1);
        OleDbDataReader dr;
        conn1.Open();
        dr = cmd.ExecuteReader();

        int i = 0;
        while (dr.Read())
        {
            System.Web.HttpContext.Current.Session["uname"] = dr["UNAME"].ToString();
            System.Web.HttpContext.Current.Session["roleid"] = dr["ROLEID"].ToString();
            System.Web.HttpContext.Current.Session["role_type"] = dr["UROLE"].ToString();
            i++;
        }
   
        if (i == 0)
        {
            MessageBox.Show("用户名或密码错误！");
            username.Text = "";
            password.Text = "";
            username.Focus();
        }

        else {

            if (role == 0)
            {
                Response.Redirect("editcource.aspx");
            }
            else if (role == 1)
            {
                Response.Redirect("teachereditcource.aspx");
            }
            else if (role == 2) {
                Response.Redirect("studentcource.aspx");
            }
        
        }
            
        
        dr.Dispose();
        cmd.Dispose();
        conn1.Close();

    }
    protected void reset_click(object sender, EventArgs e)
    {
        Response.Redirect("resetpassword.aspx");
    }
}