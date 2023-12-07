<%@ Page Title="user" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="WebApplication1.user" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="assets/css/admin.css" rel="stylesheet" />
    </head>

        
    <asp:Label ID="user_error" runat="server"></asp:Label>
    <div ID="divUser" runat="server"></div>

     
        <asp:Label ID="SQLerr" runat="server"></asp:Label>




</asp:Content>