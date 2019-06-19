<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editcource.aspx.cs" Inherits="editcource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>课程</title>
<script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <div style="float:left;margin-top:60px">
        <ul>
            <li><a href="editcource.aspx">编辑课程</a></li>
            <li><a href="editteacher.aspx">编辑教师</a></li>
        </ul>
    </div>
    <div style="float:left;margin-left:400px" >
     <form id="form1" runat="server">
    <div>
        <table class="style1" align="center" style=" border:2px;border-width: 2px;border-color: #666666;border-collapse: collapse;color:#333333;">
            <tr>
                <td>
                    <asp:GridView ID="CourceView" runat="server" CaptionAlign="Bottom"  OnRowDataBound="CourceView_RowDataBound" 
                        onrowdeleting="CourceView_RowDeleting" onrowcommand="CourceView_RowCommand"
                        CellPadding="10" ForeColor="#333333" GridLines="both" BorderStyle="Dashed"  AutoGenerateColumns="false">
                    <RowStyle BackColor="#FFFbd6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="CID" HeaderText="课程ID" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CNAME" HeaderText="课程名称" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CCREDIT"  HeaderText="学分"  ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CTID"  HeaderText="教师id" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CSNUM"  HeaderText="总数" ReadOnly="true" InsertVisible="false" /> 
                        <asp:BoundField DataField="CSTART"  HeaderText="状态" ReadOnly="true" InsertVisible="false" /> 
                        <asp:CommandField HeaderText="删除" ShowDeleteButton="true" />
                    </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
       <div style="margin-top:20px">
        <table align="center" cellpadding="5" cellspacing="5" class="style1">
            <tr style="display:none">
                <td class="style2">
                    课程ID：</td>
                <td>
                    <asp:TextBox ID="CID" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    课程名称：</td>
                <td>
                    <asp:TextBox ID="CNAME" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="style2">
                    学分：</td>
                <td>
                    <asp:TextBox ID="CCREDIT" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    教师id：</td>
                <td>
                    <asp:TextBox ID="CTID" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    总数：</td>
                <td>
                    <asp:TextBox ID="CSNUM" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="text-align: right">
                    课程状态：</td>
                <td> 
                    <asp:RadioButton ID="not_start" runat="server" Text="未开始" Checked="true" GroupName="cstart" />
                    <asp:RadioButton ID="start" runat="server"  Text="开始" GroupName="cstart"/>
                    <asp:RadioButton ID="end" runat="server" Text="结束" GroupName="cstart" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="SaveCourse" runat="server" onclick="Save_course" Text="保存" />
                    <asp:Button ID="ResetCourse" runat="server" onclick="Reset_course" Text="重置 " />
                </td>
            </tr>
        </table>
       </div>
    </form>
        </div>
</body>
</html>
