<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="style1">
            <tr>
                <td colspan="2" style="text-align: center">
                    用户登录</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    用户名：</td>
                <td>
                    <asp:TextBox ID="username" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    密码：</td>
                <td>
                    <asp:TextBox TextMode="Password" ID="password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    角色：</td>
                <td> 
                    <asp:RadioButton Checked="true" ID="system" runat="server" Text="管理员" GroupName="role" />
                    <asp:RadioButton ID="teacher" runat="server"  Text="老师" GroupName="role"/>
                    <asp:RadioButton ID="student" runat="server" Text="学生" GroupName="role" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Login" runat="server" onclick="login_click" Text="登录" />
                    <asp:Button ID="Reset" runat="server" onclick="reset_click" Text="忘记密码" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
