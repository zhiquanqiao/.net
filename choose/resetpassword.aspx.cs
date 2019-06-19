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

public partial class resetpassword : System.Web.UI.Page
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


    protected void reset_password(object sender, EventArgs e) {

        if (!String.Equals(password.Text, password_again.Text)) {
            MessageBox.Show("俩次密码输入不一致，请再次输入");
            password.Text = "";
            password_again.Text = "";
            password.Focus();
            return;

        }


        OleDbConnection conn = getconnection();
        string selectSql = "select UNAME from [USER] where UNAME ='" + username.Text + "'  and ROLEID= "+roleid.Text+"" ;
        OleDbCommand cmd = new OleDbCommand(selectSql, conn);
        OleDbDataReader dr;
        conn.Open();
        dr = cmd.ExecuteReader();

        if (dr.Read() && username.Text.Equals(dr.GetString(0))) {
            if (updateUser(username.Text, roleid.Text, password.Text)){
                MessageBox.Show("密码修改成功");
            }

        } else {
            MessageBox.Show("通过用户名和证件号码找不到用户");
            username.Text = "";
            roleid.Text = "";
            username.Focus();
        }

        dr.Dispose();
        cmd.Dispose();
        conn.Close();

    }

    private Boolean updateUser(string username, string roleid, string password) {
      
        OleDbConnection conn = getconnection();
        string updateSql = "update [USER] set UPASSWORD='"+password+"' where UNAME ='" + username + "'  and  ROLEID= " + roleid ;
        OleDbCommand cmd = new OleDbCommand(updateSql, conn);
        conn.Open();
        cmd.Dispose();
        conn.Close();
        return true;
    }



    protected void redirect_login(object sender, EventArgs e) {
        Response.Redirect("login.aspx");
    }
}