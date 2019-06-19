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

public partial class editcource : System.Web.UI.Page
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
        if (Session["uname"] == null)
            Response.Redirect("login.aspx");

        string sid = HttpContext.Current.Session["roleid"].ToString();

        OleDbConnection conn = getconnection();
         
        string sql = "SELECT   SID, SNAME, SSEX, SAGE, SDEPT, SPHONE FROM STUDENT WHERE SID =" + sid;
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataReader dr;
        conn.Open();
        dr = cmd.ExecuteReader();

        if (dr.Read()) {
            SID.Text = dr["SID"].ToString();
            SNAME.Text = dr["SNAME"].ToString();
            SPHONE.Text = dr["SPHONE"].ToString();
            SAGE.Text = dr["SAGE"].ToString();
            SDEPT.Text = dr["SDEPT"].ToString();
        }

        dr.Dispose();
        cmd.Dispose();
        conn.Close();

    }

    protected void Save_student(object sender, EventArgs e)
    {

        int sid = 0;

        if (SID != null && !SID.Text.Equals(""))
        {
            sid = int.Parse(SID.Text);
        }


        string sql = "";
        if (sid > 0)
        {
            sql = "update [STUDENT] set SNAME='" + SNAME.Text + "' , SPHONE = '" + SPHONE.Text + "',SAGE="+SAGE.Text+",SDEPT='"+SDEPT.Text
                +"' where SID=" + sid;
        }
       
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        Response.Redirect("student.aspx");

    }

    protected void Reset_student(object sender, EventArgs e)
    {
        Response.Redirect("student.aspx");
    }

    /**
  
    private Boolean updateAccount(int roleId, string uname, string password)
    {
        string sql = "update [user] set uname ='" + uname + "',upassword='" + password + "' where ROLEID=" + roleId + " and  UROLE=" + roleType;
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        return true;
    }
    

    private Boolean saveAccount(int roleid, string uname, string password)
    {
        string sql = "insert into [USER] (UNAME,UPASSWORD,UROLE,ROLEID) values ('" + uname + "','" + password + "'," + roleType + "," + roleid + ")";
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        return true;
    }
    */

}