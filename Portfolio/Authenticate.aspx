<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="Authenticate.aspx.cs" Inherits="Portfolio.Authenticate" %>

<asp:Content ID="Header1" ContentPlaceHolderID="Head" Runat="Server" >

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <section class="container">
        <h2>Login</h2>
        <asp:Label ID="err" runat="server" CssClass="err"></asp:Label>
        <div><label for="uname">Username:</label><asp:TextBox ID="uname" placeholder="Username" runat="server"></asp:TextBox></div>
        <div><label for="password">Password:</label><asp:TextBox ID="password" placeholder="Password"
                runat="server" TextMode="Password"></asp:TextBox></div>

        <input type="submit" id="next" class="submit" value="Log in" />
    </section>
</asp:Content>
    

