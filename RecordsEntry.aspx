<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecordsEntry.aspx.cs" Inherits="COVID19GuestWeb.RecordsEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="Label1" runat="server" Font-Size="50px" Height="50px" Text="Temperature Records Entry"></asp:Label>
        </p>
        <div style="height: 315px">
            Location Level:
            <asp:DropDownList ID="ddlLocationLevel" runat="server" Height="20px" 
                OnSelectedIndexChanged="ddlLocationLevel_SelectedIndexChanged" Width="120px"
                AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            Location Name:
            <asp:DropDownList ID="ddlLocationName" runat="server" Height="20px"  Width="218px">
            </asp:DropDownList>
            <br />
            <br />
            Full Name:&nbsp; <asp:TextBox ID="tbFullName" runat="server" Height="20px" Width="474px"></asp:TextBox>
            <br />
            <br />
            Email:
            <asp:TextBox ID="tbEmail" runat="server" Height="20px" Width="442px"></asp:TextBox>
            <br />
            <br />
            Contact:
            <asp:TextBox ID="tbContact" runat="server" Height="20px" Width="442px"></asp:TextBox>
            <br />
            <br />
            Temperature:
            <asp:TextBox ID="tbTemp" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="btnSubmit" runat="server" Height="45px" Text="Submit" Width="125px" OnClick="btnSubmit_Click" />
        </p>
    </form>
</body>
</html>
