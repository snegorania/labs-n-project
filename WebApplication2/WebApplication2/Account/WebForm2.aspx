<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="id" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
            ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="id_region" HeaderText="id_region" 
            SortExpression="id_region" />
        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        <asp:BoundField DataField="latitude" HeaderText="latitude" 
            SortExpression="latitude" />
        <asp:BoundField DataField="longitude" HeaderText="longitude" 
            SortExpression="longitude" />
    </Columns>
</asp:GridView>
<asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource2">
    <Series>
        <asp:Series ChartType="Point" Name="Series1" XValueMember="latitude" 
            YValueMembers="longitude">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
    SelectCommand="SELECT * FROM [sensor]"></asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
    SelectCommand="SELECT [latitude], [longitude] FROM [sensor]">
</asp:SqlDataSource>
</asp:Content>
