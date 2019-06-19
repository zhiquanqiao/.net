<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentcource.aspx.cs" Inherits="editcource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>课程</title>
<script src="Scripts/jquery-1.10.2.min.js"></script>
</head>
<body>
    <script type="text/javascript">
        $(function () {
            $("#coursedata").find("tr").each(function () {
                var tdArr = $(this).children();
                var csum = tdArr.eq(4).text();
                var total = tdArr.eq(5).text();
                var state = tdArr.eq(7).text();
                
                if (csum == '总数' || csum == '' || csum == null || csum == undefined) {

                } else {

                    var tid = tdArr.eq(3).text();
                    tdArr.eq(3).text("");
                    tdArr.eq(3).html('<a href="teacher.aspx?tid='+tid+'" target="_blank">'+tid+'</a>');
                    if (state == "" || state == null || state == undefined)
                        if (csum > total) {
                            state = '可选';
                            tdArr.eq(7).text(state);
                        } else if (csum <= total) {
                            tdArr.eq(7).text('不可选');
                        }
                    if (state == '不可选' || state == '已选')
                        tdArr.eq(8).html('');

                    if (csum == total) {
                        tdArr.eq(9).html('');
                    }
                }


                
            });
        });
    </script>


    <div style="float:left;margin-top:60px">
        <ul>
            <li><a href="teachereditcource.aspx">选课</a></li>
            <li><a href="student.aspx">修改信息</a></li>
        </ul>
    </div>
    <div style="float:left;margin-left:400px" >
     <form id="form1" runat="server">
    <div>
        <table id="coursedata" class="style1" align="center" style=" border:2px;border-width: 2px;border-color: #666666;border-collapse: collapse;color:#333333;">
            <tr>
                <td>
                    <asp:GridView ID="CourceView" runat="server" CaptionAlign="Bottom"  OnRowDataBound="CourceView_RowDataBound" 
                        onrowcommand="CourceView_RowCommand" 
                        CellPadding="10" ForeColor="#333333" GridLines="both" BorderStyle="Dashed"  AutoGenerateColumns="false">
                    <RowStyle BackColor="#FFFbd6" ForeColor="#333333" />
                    <Columns>
                        <asp:BoundField DataField="CID" HeaderText="课程ID" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CNAME" HeaderText="课程名称" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CCREDIT"  HeaderText="学分"  ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CTID"  HeaderText="教师id" ReadOnly="true" InsertVisible="false"/>
                        <asp:BoundField DataField="CSNUM"  HeaderText="总数" ReadOnly="true" InsertVisible="false" /> 
                        <asp:BoundField DataField="TOTAL"  HeaderText="已报人数" ReadOnly="true" InsertVisible="false" /> 
                        <asp:BoundField DataField="CSTART"  HeaderText="是否开始填报" ReadOnly="true" InsertVisible="false" /> 
                        <asp:BoundField DataField="CSTATE"  HeaderText="填报状态" ReadOnly="true" InsertVisible="false" /> 
                        <asp:ButtonField ButtonType="Button" Text="选课"  HeaderText="选课" CommandName="choose"/>
                        <asp:ButtonField ButtonType="Button" Text="撤销"  HeaderText="撤销" CommandName="revert"/>

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
                <td class="style2">
                    已报人数：</td>
                <td>
                    <asp:TextBox ID="TOTAL" runat="server" Width="512px"></asp:TextBox>
                </td>
            </tr>
        </table>
       </div>
 
    </form>
        </div>
</body>
</html>
