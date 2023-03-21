<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Indications.aspx.cs" Inherits="WebApplication2.Account.WebForm1" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Height="464px" Width="892px">
        <Series>
            <asp:Series ChartType="Point" Name="Series1" XValueMember="name_sensor" YValueMembers="temperature">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Width="875px">
        <Columns>
            <asp:BoundField DataField="name_sensor" HeaderText="name_sensor" SortExpression="name_sensor" />
            <asp:BoundField DataField="temperature" HeaderText="temperature" SortExpression="temperature" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="temperature_date" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox1" DbType="Date" DefaultValue="2023-09-09" Name="temp_date" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBox2" DbType="Time" DefaultValue="10:00:00" Name="temp_time" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label2" runat="server" Text="Time"></asp:Label>
<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Change data" />
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" Width="879px">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="name_sensor" HeaderText="name_sensor" SortExpression="name_sensor" />
        <asp:BoundField DataField="date_indication" HeaderText="date_indication" SortExpression="date_indication" />
        <asp:BoundField DataField="time_indication" HeaderText="time_indication" SortExpression="time_indication" />
        <asp:BoundField DataField="temperature" HeaderText="temperature" SortExpression="temperature" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT indication.id, sensor.name_sensor, indication.date_indication, indication.time_indication, indication.temperature FROM indication INNER JOIN sensor ON indication.id_sensor = sensor.id"></asp:SqlDataSource>
<asp:Button ID="Button2" runat="server" Text="Save Data" OnClick="Button2_Click" />
</asp:Content>
