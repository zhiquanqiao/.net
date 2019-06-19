<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetpassword.aspx.cs" Inherits="resetpassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table align="center" class="style1">
            <tr>
                <td colspan="2" style="text-align: center">
                    修改密码</td>
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
                    请输入人员编号：</td>
                <td>
                    <asp:TextBox ID="roleid" runat="server"></asp:TextBox>
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
                   再次输入密码：</td>
                <td>
                    <asp:TextBox TextMode="Password" ID="password_again" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Reset_Password" runat="server" onclick="reset_password" Text="修改密码" />
                    <asp:Button ID="Redirect_login" runat="server" onclick="redirect_login" Text="跳转登录" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
