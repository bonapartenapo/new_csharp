<%@ Page Title="choix" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="choix.aspx.cs" Inherits="WebApplication1.choix" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>login</title>
    <link rel="stylesheet" href="assets/css/main.css">
</head>

    <section class="section-login">

        <div class="div-1-login">
            <div class="top-div-identifier">
                <h1 class="h1">S'identifier</h1>
                
            </div>
            <div class="google-login deplacement-div-login">
                <img src="assets/images/body/authentification/login/admin.svg" alt="google" class="icon-L2 icon-login">
                <a href="./register.aspx" class="btn-third"><button class="btn-third">Connexion au compte admin</button></a>
            </div>
            <div class="email-login deplacement-div-login">
                <img src="assets/images/body/authentification/login/usrs.svg" alt="email" class="icon-L2 icon-login">
                <a href="/register" type="button" class="btn-third">Connexion au compte utilisateur</a>
            </div>
            <div class="link-login">
                <b>vous avez pas encore de compte?</b><a href="/register"> inscrivez vous</a><br>
                <b>Mot de passe oublie ?</b> <a href="./forgot-password.html">Reinitialiser le mot de passe</a>
            </div>
        </div>
        <div class="img-login">
            <img src="assets/images/body/authentification/login/login.svg" alt="" class="">
        </div>
    </section>

</asp:Content>
