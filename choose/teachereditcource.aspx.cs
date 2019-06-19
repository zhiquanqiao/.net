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
        string tid = Convert.ToString(HttpContext.Current.Session["roleid"]);
        string roletype = Convert.ToString(HttpContext.Current.Session["role_type"]);
        string sql = "SELECT CID, CNAME, CCREDIT, CTID, CSNUM, CSTART,CPERFECT FROM COURSE where CTID =" +tid;
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
            e.Row.Attributes.Add("onclick", "$('#CID').val("+ e.Row.Cells[0].Text + ");$('#CNAME').val('" + e.Row.Cells[1].Text + "');$('#CCREDIT').val(" + e.Row.Cells[2].Text + ");$('#CTID').val(" + e.Row.Cells[3].Text + ");$('#CSNUM').val(" + e.Row.Cells[4].Text + ");showButton('"+ e.Row.Cells[6].Text + "')");
        }
    
    }

    
    
   protected void CourceView_RowCommand(object sender, GridViewCommandEventArgs e)
   {
      
   }
  

    protected void Save_course(object sender, EventArgs e) {

        int cid = 0;

        if (CID != null && !CID.Text.Equals("")) {
            cid = int.Parse(CID.Text);
        }

        string Cstart = "未开始";

        if (start.Checked) {
            Cstart = "开始";
        } else if (end.Checked) {
            Cstart = "结束";

        }

        string sql = "";
        if (cid > 0)
        {
            sql = "update [COURSE] set CNAME='" + CNAME.Text + "' , CCREDIT = " + CCREDIT.Text + ",CTID=" + CTID.Text + ",CSNUM=" + CSNUM.Text + ",CSTART='" + Cstart + "',CPERFECT="+"'已完善'"+" where CID=" + cid;
        }
       
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        Response.Redirect("teachereditcource.aspx");

    }

    protected void Reset_course(object sender, EventArgs e) {
        Response.Redirect("teachereditcource.aspx");
    }

}