<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sensors.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource1" Height="373px" Width="396px">
        <Series>
            <asp:Series ChartType="Point" Name="Series1" XValueMember="latitude" YValueMembers="longitude">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" Width="905px">
    <Columns>
        <asp:BoundField DataField="name_sensor" HeaderText="name_sensor" SortExpression="name_sensor" />
        <asp:BoundField DataField="latitude" HeaderText="latitude" 
            SortExpression="latitude" />
        <asp:BoundField DataField="longitude" HeaderText="longitude" 
            SortExpression="longitude" />
    </Columns>
</asp:GridView>
    <asp:TextBox ID="TextBox11111" runat="server"></asp:TextBox>
<asp:Button ID="Button1" runat="server" Text="Change Data" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="temp_loc" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox11111" DefaultValue="Minsk" 
            Name="name_region" PropertyName="Text" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2">
    <Columns>
        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        <asp:BoundField DataField="region" HeaderText="region" SortExpression="region" />
        <asp:BoundField DataField="latitude" HeaderText="latitude" SortExpression="latitude" />
        <asp:BoundField DataField="longitude" HeaderText="longitude" SortExpression="longitude" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" 
    ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
    SelectCommand="SELECT sensor.id, sensor.name_sensor AS name, region.name AS region, sensor.latitude, sensor.longitude  FROM sensor INNER JOIN region ON sensor.id_region = region.id;">
</asp:SqlDataSource>
<asp:Button ID="Button2" runat="server" Text="Save Data" OnClick="Button2_Click" />
</asp:Content>
