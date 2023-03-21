<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication2.Account.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="min_temp" HeaderText="min_temp" 
            ReadOnly="True" SortExpression="min_temp" />
        <asp:BoundField DataField="max_temp" HeaderText="max_temp" 
            SortExpression="max_temp" ReadOnly="True" />
    </Columns>
</asp:GridView>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
    SelectCommand="temp_min_max" SelectCommandType="StoredProcedure">
    <SelectParameters>
        <asp:ControlParameter ControlID="TextBox1" DbType="Date" 
            DefaultValue="2023-09-09" Name="temp_date1" PropertyName="Text" />
        <asp:ControlParameter ControlID="TextBox2" DbType="Date" 
            DefaultValue="2023-09-09" Name="temp_date2" PropertyName="Text" />
    </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:jkrdghsgghConnectionString %>" 
        SelectCommand="temperature_date" SelectCommandType="StoredProcedure">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBox3" DbType="Date" 
                DefaultValue="2023-09-09" Name="temp_date" PropertyName="Text" />
            <asp:ControlParameter ControlID="TextBox4" DbType="Time" 
                DefaultValue="10:00:00" Name="temp_time" PropertyName="Text" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource2">
        <Columns>
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="temperature" HeaderText="temperature" 
                SortExpression="temperature" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
</asp:Content>
