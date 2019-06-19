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

public partial class editteacher : System.Web.UI.Page
{

    private static readonly string DBName = ConfigurationManager.AppSettings.Get("DBName").ToString();
    private static readonly string DBDriver = ConfigurationManager.AppSettings.Get("DBDriver").ToString();
    private static string DBConnectionString = DBDriver + HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath + "/App_Data/") + DBName;
    private static readonly int roleType = 1;
    public static OleDbConnection getconnection()
    {
        OleDbConnection conn = new OleDbConnection(DBConnectionString);
        return conn;
    }

    protected void bind()
    {
        OleDbConnection conn = getconnection();
        string sql = "SELECT TID, TNAME, TPHONE FROM [TEACHER]";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        OleDbDataReader dr;
        dr = cmd.ExecuteReader();
        TeacherView.DataSource = dr;
        TeacherView.DataKeyNames = new string[] { "TID" };
        TeacherView.DataBind();
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


    protected void TeacherView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#ff0000';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor;");
            e.Row.Attributes.Add("onclick", "$('#TID').val(" + e.Row.Cells[0].Text + ");$('#TNAME').val('" + e.Row.Cells[1].Text + "');$('#TPHONE').val(" + e.Row.Cells[2].Text + ");");
        }

    }


    protected void TeacherView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int tID = Convert.ToInt32(TeacherView.DataKeys[e.RowIndex].Value);

        OleDbConnection conn = getconnection();
        conn.Open();
        string sql = "delete from [TEACHER] where TID=" + tID;
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        DialogResult i = MessageBox.Show("您确定要删除ID为" + tID + "的记录吗？", "删除确认", MessageBoxButtons.OKCancel);
        if (i == DialogResult.OK)
        {
            cmd.ExecuteNonQuery();
            deleteAccount(tID);
        }

        cmd.Dispose();
        conn.Close();
        Response.Redirect("editteacher.aspx");
    }


    protected void TeacherView_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }


    protected void Save_course(object sender, EventArgs e)
    {

        int tid = 0;

        if (TID != null && !TID.Text.Equals(""))
        {
            tid = int.Parse(TID.Text);
        }

      
        string sql = "";
        if (tid > 0)
        {
            sql = "update [TEACHER] set TNAME='" + TNAME.Text + "' , TPHONE = '" +TPHONE.Text +"' where TID=" + tid;
            updateAccount(tid, TNAME.Text, password.Text);
        }
        else
        {
            sql = "insert into [TEACHER] (TNAME,TPHONE) values('" + TNAME.Text + "','" + TPHONE.Text + "')";
            saveAccount(tid, TNAME.Text, password.Text);
        }
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        Response.Redirect("editteacher.aspx");

    }

    protected void Reset_course(object sender, EventArgs e)
    {
        Response.Redirect("editteacher.aspx");
    }

    private Boolean deleteAccount(int roleId) {
        string sql = "delete from [user] where ROLEID=" + roleId + " and  UROLE=" + roleType;
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        return true;
    }

    private Boolean updateAccount(int roleId,string uname ,string password) {
        string sql = "update [user] set uname ='"+uname+"',upassword='"+password+"' where ROLEID=" + roleId + " and  UROLE=" + roleType;
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();

        return true;
    }

    private Boolean saveAccount(int roleid, string uname, string password) {
        string sql = "insert into [USER] (UNAME,UPASSWORD,UROLE,ROLEID) values ('"+uname+"','"+password+"',"+roleType+","+roleid+")";
        OleDbConnection conn = getconnection();
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        conn.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        conn.Close();
        return true;
    }
}