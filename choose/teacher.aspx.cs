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

        string tid = "";
        string urltid  = Request.QueryString["tid"];
        if (urltid == null || "".Equals(urltid))
        {
            tid = HttpContext.Current.Session["roleid"].ToString();
        }
        else {
            tid = urltid;
        }

        OleDbConnection conn = getconnection();

        string sql = "SELECT   TID, TNAME, TPHONE FROM TEACHER WHERE TID=" + tid;
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        OleDbDataReader dr;
        conn.Open();
        dr = cmd.ExecuteReader();

        if (dr.Read()) {
            TID.Text = dr["TID"].ToString();
            TNAME.Text = dr["TNAME"].ToString();
            TPHONE.Text = dr["TPHONE"].ToString();
        }

        dr.Dispose();
        cmd.Dispose();
        conn.Close();

    }

    protected void Save_teacher(object sender, EventArgs e)
    {

        int tid = 0;

        if (TID != null && !TID.Text.Equals(""))
        {
            tid = int.Parse(TID.Text);
        }


        string sql = "";
        if (tid > 0)
        {
            sql = "update [TEACHER] set TNAME='" + TNAME.Text + "' , TPHONE = '" + TPHONE.Text + "' where TID=" + tid;
            //updateAccount(tid, TNAME.Text, password.Text);
        }
       
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        Response.Redirect("teacher.aspx");

    }

    protected void Reset_teacher(object sender, EventArgs e)
    {
        Response.Redirect("teacher.aspx");
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