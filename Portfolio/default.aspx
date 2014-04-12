<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Portfolio.Default" %>

<asp:Content ID="Header1" ContentPlaceHolderID="Head" Runat="Server" >

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">
    <section class="container">
        <h2>How to play</h2>
        
        <p>This is a competitive quiz game. Answer as high a ratio of questions correctly as possible to rise up the leaderboard. Quizzes keep going as long as you want, so click "finish" when you're done or you're in for a long session!</p>
        <% if (Session["uid"] == null)
           { %>
            <h3><a href="Register.aspx">Click here to register</a></h3><br />
           <%} %>
        <h3><a href="Quiz.aspx">Click here to play!</a></h3>
        <h4>Technologies used in this project which go above and beyond the course content:</h4>
        <ul>
            <li>ASP.net
                <ul>
                    <li>WebMethods</li>
                    <li>BulletedList</li>
                    <li>WebRepeater</li>
                </ul>
            </li>
            <li>jQuery
                <ul>
                    <li>Framework</li>
                    <li>UI library</li>
                    <li>transition effects</li>
                </ul>
            </li>
            <li>CSS3
                <ul>
                    <li>box-shadow</li>
                    <li>background-position</li>
                    <li>text-shadow</li>
                </ul>
            </li>
            <li>Linq</li>
            <li>Data Classes</li>
            <li>Automatic primary key</li>
            <li>Ajax</li>
            <li>Manipulation of trees other than the DOM</li>
            <li>Javascript as a functional language</li>
            <li>Sessioning</li>
            <li>Best-practice password storage (Salting and SHA hashing)</li>
        </ul>
        <cite>Images in this project are property of their respective owners.</cite>
    </section>
</asp:Content>
    

