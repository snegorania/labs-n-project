<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.Account.WebForm1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2" 
    Height="299px" Width="283px">
    <series>
        <asp:Series Name="Series1" XValueMember="id_sensor" YValueMembers="temperature">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </chartareas>
</asp:Chart>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
    SelectCommand="temp_dev" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
    
    SelectCommand="SELECT id_sensor, temperature FROM indication WHERE time_indication = '10:00:00'" 
    onselecting="SqlDataSource2_Selecting">
</asp:SqlDataSource>
    <asp:GridView ID="GridView2" runat="server">
    </asp:GridView>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" style="margin-right: 38px">
    <Columns>
        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        <asp:BoundField DataField="temperature" HeaderText="temperature" 
            SortExpression="temperature" />
        <asp:BoundField DataField="deviation" HeaderText="deviation" 
            SortExpression="deviation" ReadOnly="True" />
    </Columns>
</asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</asp:Content>
