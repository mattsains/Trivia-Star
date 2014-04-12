<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Portfolio.User1" %>

<asp:Content ID="Header1" ContentPlaceHolderID="Head" Runat="Server" >

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <section class="container">
        <h2 runat="server" id="name"></h2>
        <cite runat="server" id="uname"></cite>
        <p></p>
        <h3 runat="server" id="percent"></h3>
        <p runat="server" id="count"></p>
        <h4>Worst Questions:</h4>
        <asp:BulletedList ID="worstlist" runat="server" BulletStyle="Numbered"></asp:BulletedList>
    </section>
</asp:Content>
    

