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
        OleDbConnection conn = getconnection();
        string uname = Convert.ToString(HttpContext.Current.Session["uname"]);
        string sid = Convert.ToString(HttpContext.Current.Session["roleid"]);
        string roletype = Convert.ToString(HttpContext.Current.Session["role_type"]);
        string sql = "SELECT   COURSE.CID, COURSE.CNAME, COURSE.CCREDIT, COURSE.CTID, COURSE.CSNUM, COURSE.CSTART, \n" +
            "                COURSE.CPERFECT, COURSE.CFULL, b.total, iif(c.SID, '已选', '可选') AS CSTATE\n" +
            "FROM      ((COURSE LEFT OUTER JOIN\n" +
            "                    (SELECT   COUNT(SID) AS total, CID\n" +
            "                     FROM      SC\n" +
            "                     GROUP BY CID) b ON b.CID = COURSE.CID) LEFT OUTER JOIN\n" +
            "                    (SELECT   CID, SID\n" +
            "                     FROM      SC SC_1\n" +
            "                     WHERE   (SID = "+sid+")) c ON c.CID = COURSE.CID)";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr;
        dr = cmd.ExecuteReader();
        CourceView.DataSource = dr;
        CourceView.DataKeyNames = new string[] { "CID" };
        CourceView.DataBind();
        dr.Dispose();
        cmd.Dispose();
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uname"] == null)
             Response.Redirect("login.aspx");
        bind();

    }

   
    protected void CourceView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ff0000';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            e.Row.Attributes.Add("onclick", "$('#CID').val("+ e.Row.Cells[0].Text + ");$('#CNAME').val('" + e.Row.Cells[1].Text + "');$('#CCREDIT').val(" + e.Row.Cells[2].Text + ");$('#CTID').val(" + e.Row.Cells[3].Text + ");$('#TOTAL').val('" + e.Row.Cells[5].Text + "');$('#CSNUM').val(" + e.Row.Cells[4].Text + ");showButton('"+ e.Row.Cells[6].Text + "')");
        }
    }

    
    
   protected void CourceView_RowCommand(object sender, GridViewCommandEventArgs e)
   {
        
        string uname = Convert.ToString(HttpContext.Current.Session["uname"]);
        string sid = Convert.ToString(HttpContext.Current.Session["roleid"]);
        string roletype = Convert.ToString(HttpContext.Current.Session["role_type"]);
        string sql = "";

       
        OleDbConnection conn = getconnection();
        conn.Open();
        string cID = Convert.ToString(CourceView.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
        OleDbCommand cmd = null;
        if (e.CommandName == "choose")
        {
            sql = "insert into sc(CID,SID) values ('" + cID + "','" + sid + "')";
            cmd = new OleDbCommand(sql, conn);
        }
        else if(e.CommandName == "revert")
        {
            sql ="delete from sc where CID="+cID+" and SID ="+sid;
            cmd = new OleDbCommand(sql, conn);
        }
    
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        Response.Redirect("studentcource.aspx");
    }
    protected void Reset_course(object sender, EventArgs e) {
        Response.Redirect("studentcource.aspx");
    }

    private int getTotal(string cid) {
        OleDbConnection conn = getconnection();
        int total = 0;
        string sql = "SELECT   COUNT(SCID) AS TOTAL, CID\n" +
            "FROM      SC\n" +
            "WHERE   (CID = '"+cid+"')\n" +
            "GROUP BY CID";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr;
        dr = cmd.ExecuteReader();
        total = int.Parse(dr["TOTAL"].ToString());
        dr.Dispose();
        cmd.Dispose();
        conn.Close();
        return total;
    }

    private int getSNUM(string cid)
    {
        int snum = 0;
        OleDbConnection conn = getconnection();
        string sql = "SELECT   CSNUM FROM COURSE WHERE(CID = "+cid+")";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr;
        dr = cmd.ExecuteReader();
        snum = int.Parse(dr["CSNUM"].ToString());
        dr.Dispose();
        cmd.Dispose();
        conn.Close();
        return snum;
    }

}