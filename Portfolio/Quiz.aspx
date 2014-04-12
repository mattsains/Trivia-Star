<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="Portfolio.Quiz" %>

<asp:Content ID="Header1" ContentPlaceHolderID="Head" Runat="Server" >
    <script type="text/javascript" src="scripts/quizlogic.js"></script>
    <script type="text/javascript">var uid=<%= Session["uid"] %>;</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <section id="placeholder" class="container">
        <img src="images/loading.gif" alt="Loading..." />
    </section>

    <section id="question1" style="display:none;" class="container">
    </section>
    <section id="question2" style="display:none;" class="container">
    </section>
</asp:Content>
    

