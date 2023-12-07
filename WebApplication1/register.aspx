<%@ Page Title="register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="WebApplication1.register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>register</title>
    <link rel="stylesheet" href="assets/css/main.css">
</head>

    <section class="section-register">
        <br />
        <div class="div-1-register">
            <div class="google-register deplacement-div-register">
                <label for="nom">Nom</label><br>
                <asp:TextBox ID="nom" placeholder="Entrer votre nom" class="zone-text-L2" runat="server"></asp:TextBox>
                 <asp:Label ID="err_nom" runat="server" Text=""></asp:Label>                
            </div><br>

            <div class="google-register deplacement-div-register">
                <label for="prenom">Prenom</label><br>
                <asp:TextBox ID="prenom" placeholder="Entrer votre nom" class="zone-text-L2" runat="server"></asp:TextBox>
                <asp:Label ID="err_prenom" runat="server" Text=""></asp:Label>


            </div><br>

            <div class=" deplacement-div-register">
                <label for="email">email</label><br>
                <asp:TextBox ID="email" placeholder="example@gmail.com" class="zone-text-L2" runat="server"></asp:TextBox>
                <asp:Label ID="err_email" runat="server" Text=""></asp:Label>
            </div><br>
            <div class=" deplacement-div-register">
                <label for="email">Mot de passe</label><br>
                <asp:TextBox ID="mdp" placeholder="Mot de passe" class="zone-text-L2" runat="server"></asp:TextBox>
                <asp:Label ID="err_mdp" runat="server" Text=""></asp:Label>

            </div><br>
            <div class="link-register">
                <asp:Button ID="Btn" class="btn-secondary send-forgot" runat="server" Text="creer mon compte" OnClick="Button1_Click" />
            </div>

            <div class="top-already-compte">
                <b class="already-compte">vous avez deja un compte?</b> <a href="./login">Connexion</a>
            </div>
        </div>
        <div class="img-register dim-img-register">
            <img src="assets/images/body/authentification/register/register.png" alt="" class="">
                <asp:Label ID="err_sql" runat="server" Text=""></asp:Label>

        </div>
    </section>


</asp:Content>
