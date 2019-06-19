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

    protected void bind()
    {
        string cid = Request.QueryString["cid"];
        OleDbConnection conn = getconnection();
        string uname = Convert.ToString(HttpContext.Current.Session["uname"]);
        string sid = Convert.ToString(HttpContext.Current.Session["roleid"]);
        string roletype = Convert.ToString(HttpContext.Current.Session["role_type"]);
        string sql = "SELECT   SC.SCID, SC.CID, SC.GRADE, SC.SID, COURSE.CNAME, STUDENT.SNAME\n" +
            "FROM      ((SC INNER JOIN\n" +
            "                COURSE ON SC.CID = COURSE.CID) INNER JOIN\n" +
            "                STUDENT ON SC.SID = STUDENT.SID)\n" +
            "WHERE   (SC.CID = "+cid+")";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr;
        dr = cmd.ExecuteReader();
        CourceView.DataSource = dr;
        CourceView.DataKeyNames = new string[] { "SCID" };
        CourceView.DataBind();
        dr.Dispose();
        cmd.Dispose();
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       // if (Session["uname"] == null)
           //  Response.Redirect("login.aspx");
        bind();

    }
}