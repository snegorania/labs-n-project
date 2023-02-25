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
    SelectCommand="SELECT * FROM [indication]"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
    
    SelectCommand="SELECT id_sensor, temperature FROM indication WHERE time_indication = '10:00:00'" 
    onselecting="SqlDataSource2_Selecting">
</asp:SqlDataSource>
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="id" DataSourceID="SqlDataSource1" style="margin-right: 38px">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
            ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="id_sensor" HeaderText="id_sensor" 
            SortExpression="id_sensor" />
        <asp:BoundField DataField="date_indication" HeaderText="date_indication" 
            SortExpression="date_indication" />
        <asp:BoundField DataField="time_indication" HeaderText="time_indication" 
            SortExpression="time_indication" />
        <asp:BoundField DataField="temperature" HeaderText="temperature" 
            SortExpression="temperature" />
    </Columns>
</asp:GridView>
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
</asp:Content>
