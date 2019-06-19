<%@ Page Language="C#" AutoEventWireup="true" CodeFile="teacher.aspx.cs" Inherits="editcource" %>

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
    <script type="text/javascript">

        $(function () {
            console.log(window.location.search);
            var search = window.location.search;
            if (search == '' || search == undefined || search == null) {
                $("#teacher_edit").show();
                $("#password").show();
            } else {
                $("#password").hide();
                $("#teacher_edit").hide();
            }
        });


    </script>
    <div style="float:left;margin-left:400px" >
     <form id="form1" runat="server">

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
            <tr id="password">
                <td class="style2">
                    初始密码：</td>
                <td>
                    <asp:TextBox TextMode="Password" ID="password" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
            <tr id="teacher_edit">
            <td >
                    &nbsp;</td>
                <td>
                    <asp:Button ID="SaveTeacher" runat="server" onclick="Save_teacher" Text="保存" />
                    <asp:Button ID="ResetTeacher" runat="server" onclick="Reset_teacher" Text="重置 " />
                </td>
             </tr>
        </table>

    </form>
        </div>
</body>
</html>
