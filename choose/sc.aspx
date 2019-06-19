<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sc.aspx.cs" Inherits="editcource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>课程</title>
<script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
     <form id="form1" runat="server">
        <table  class="style1" align="center" style=" border:2px;border-width: 2px;border-color: #666666;border-collapse: collapse;color:#333333;">
            <tr>
                <td>
                    <asp:GridView ID="CourceView" runat="server" CaptionAlign="Bottom"  CellPadding="10" ForeColor="#333333" GridLines="both" BorderStyle="Dashed"  AutoGenerateColumns="false">
                    <RowStyle BackColor="#FFFbd6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="SCID" HeaderText="选课ID" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CID" HeaderText="课程ID" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="SID"  HeaderText="学生ID"  ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CNAME"  HeaderText="课程名称" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="SNAME"  HeaderText="学生姓名" ReadOnly="true" InsertVisible="false" /> 
                        <asp:BoundField DataField="GRADE"  HeaderText="成绩" ReadOnly="true" InsertVisible="false" /> 
                    </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
