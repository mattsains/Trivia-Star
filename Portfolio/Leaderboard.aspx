<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="Leaderboard.aspx.cs" Inherits="Portfolio.Leaderboard" %>

<asp:Content ID="Header1" ContentPlaceHolderID="Head" Runat="Server" >

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <section class="container">
    <h2>Top 100 Players:</h2>
    <asp:Repeater ID="leaderboard"  runat="server">
        <HeaderTemplate><ol></HeaderTemplate>
        <ItemTemplate>
            <li><%# Container.DataItem %></li>
        </ItemTemplate>
        <FooterTemplate></ol></FooterTemplate>
    </asp:Repeater>

    </section>
</asp:Content>
    

