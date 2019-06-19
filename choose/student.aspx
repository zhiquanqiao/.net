<%@ Page Language="C#" AutoEventWireup="true" CodeFile="student.aspx.cs" Inherits="editcource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>课程</title>
<script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <!--script type="text/javascript">
        
    </!--script>


    <div style="float:left;margin-top:60px">
        <ul>
            <li><a href="teachereditcource.aspx">选课</a></li>
            <li><a href="teachereditteacher.aspx">修改信息</a></li>
        </ul>
    </!div-->
     <div style="float:left;margin-top:60px">
        <ul>
            <li><a href="teachereditcource.aspx">选课</a></li>
            <li><a href="student.aspx">修改信息</a></li>
        </ul>
    </div>
    <div style="float:left;margin-left:400px" >
     <form id="form1" runat="server">

        <table align="center" cellpadding="5" cellspacing="5" class="style1">
            <tr style="display:none">
                <td class="style2">
                    学生ID：</td>
                <td>
                    <asp:TextBox ID="SID" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    学生名称：</td>
                <td>
                    <asp:TextBox ID="SNAME" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    手机号码：</td>
                <td>
                    <asp:TextBox ID="SPHONE" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    专业：</td>
                <td>
                    <asp:TextBox ID="SDEPT" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    年龄：</td>
                <td>
                    <asp:TextBox ID="SAGE" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td style="text-align: right">
                    角色：</td>
                <td> 
                    <asp:RadioButton Checked="true" ID="male" runat="server" Text="男" GroupName="role" />
                    <asp:RadioButton ID="female" runat="server"  Text="女" GroupName="role"/>
                  
                </td>
             </tr>
            <tr id="password">
                <td class="style2">
                    初始密码：</td>
                <td>
                    <asp:TextBox TextMode="Password" ID="password" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr id="student_edit">
            <td >
                    &nbsp;</td>
                <td>
                    <asp:Button ID="SaveStudent" runat="server" onclick="Save_student" Text="保存" />
                    <asp:Button ID="ResetStudent" runat="server" onclick="Reset_student" Text="重置 " />
                </td>
             </tr>
        </table>

    </form>
        </div>
</body>
</html>
