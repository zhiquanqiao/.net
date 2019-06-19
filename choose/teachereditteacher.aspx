<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teachereditteacher.aspx.cs" Inherits="editteacher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>老师</title>
<script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <div style="float:left;margin-top:60px">
        <ul>
            <li><a href="editcource.aspx">查看课程</a></li>
            <li><a href="editteacher.aspx">修改信息</a></li>
        </ul>
    </div>
    <div style="float:left;margin-left:400px" >
     <form id="form1" runat="server">
    <div>
        <table class="style1" align="center" style=" border:2px;border-width: 2px;border-color: #666666;border-collapse: collapse;color:#333333;">
            <tr>
                <td>
                    <asp:GridView ID="TeacherView" runat="server" CaptionAlign="Bottom"  OnRowDataBound="TeacherView_RowDataBound" 
                        onrowdeleting="TeacherView_RowDeleting" onrowcommand="TeacherView_RowCommand"
                        CellPadding="10" ForeColor="#333333" GridLines="both" BorderStyle="Dashed"  AutoGenerateColumns="false">
                    <RowStyle BackColor="#FFFbd6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="TID" HeaderText="老师ID" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="TNAME" HeaderText="姓名" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="TPHONE"  HeaderText="手机号码"  ReadOnly="true" InsertVisible="false"/>
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
                    老师ID：</td>
                <td>
                    <asp:TextBox ID="TID" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    老师名称：</td>
                <td>
                    <asp:TextBox ID="TNAME" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    手机号码：</td>
                <td>
                    <asp:TextBox ID="TPHONE" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    初始密码：</td>
                <td>
                    <asp:TextBox TextMode="Password" ID="password" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="SaveCourse" runat="server" onclick="Save_course" Text="保存"  />
                    <asp:Button ID="ResetCourse" runat="server" onclick="Reset_course" Text="重置 " />
                </td>
            </tr>
        </table>
       </div>
    </form>
        </div>
</body>
</html>
