<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Portfolio.Register" %>

<asp:Content ID="Header1" ContentPlaceHolderID="Head" Runat="Server" >

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <section class="container">
        <h2>Register</h2>
        <asp:Label ID="unameerr" runat="server" Text="" CssClass="err"></asp:Label>
        <div><label for="uname">Username:</label><asp:TextBox ID="uname" runat="server"></asp:TextBox></div>

        <div><label for="firstname">First Name:</label><asp:TextBox ID="firstname" runat="server"></asp:TextBox></div>
        <div><label for="lastname">Last Name:</label><asp:TextBox ID="lastname" runat="server"></asp:TextBox></div>

        <asp:Label ID="emailerr" runat="server" Text="" CssClass="err"></asp:Label>
        <div><label for="email">Email:</label><asp:TextBox ID="email" runat="server"></asp:TextBox></div>

        <asp:Label ID="passworderr" runat="server" Text="" CssClass="err"></asp:Label>
        <div><label for="password">Password:</label><asp:TextBox ID="password" 
                runat="server" TextMode="Password"></asp:TextBox></div>
        <div><label for="password2">Confirm Password:</label><asp:TextBox ID="password2" 
        runat="server" TextMode="Password"></asp:TextBox></div>

        <input id="next" class="submit" type="submit" value="Register" />
    </section>
</asp:Content>
    

