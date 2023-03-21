<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="statictic.aspx.cs" Inherits="WebApplication2.Account.statictic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="White" DataSourceID="SqlDataSource1" Width="219px">
    <Columns>
        <asp:BoundField DataField="min_temp" HeaderText="Minimum Temperature" ReadOnly="True" SortExpression="min_temp" />
        <asp:BoundField DataField="max_temp" HeaderText="Maximum temperature" ReadOnly="True" SortExpression="max_temp" />
    </Columns>
</asp:GridView>
<br />
<asp:Label ID="Label1" runat="server" Text="Start date"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label2" runat="server" Text="End Date"></asp:Label>
<br />
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="temp_min_max" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" DbType="Date" DefaultValue="2023-09-09" Name="temp_date1" PropertyName="Text" />
        <asp:ControlParameter ControlID="TextBox2" DbType="Date" DefaultValue="2023-09-09" Name="temp_date2" PropertyName="Text" />
    </SelectParameters>
</asp:SqlDataSource>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label3" runat="server" Text="Deviation"></asp:Label>
<br />
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Width="914px">
    <Columns>
        <asp:BoundField DataField="name_sensor" HeaderText="name_sensor" SortExpression="name_sensor" />
        <asp:BoundField DataField="temperature" HeaderText="temperature" SortExpression="temperature" />
        <asp:BoundField DataField="deviation" HeaderText="deviation" ReadOnly="True" SortExpression="deviation" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="temp_dev" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
<br />
</asp:Content>
