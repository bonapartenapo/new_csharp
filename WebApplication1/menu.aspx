<%@ Page Title="menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="WebApplication1.admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style>
    .btn-custom {
        width: var(--btn-size);
    }

</style>

<div class="text-center ">
    <div style="
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;

">
        <a href="/admin" type="button" class="btn btn-warning btn-custom">SESSION ADMINISTRATEUR</a> <br /><br />
        <a href="/user" type="button" class="btn btn-warning btn-custom">SESSION UTILISATEUR</a> <br /><br />            
        <a href="/affichage" type="button" class="btn btn-warning btn-custom">AFFICHER LES INFORMATIONS DES EMPLOYÉS</a> <br /><br />
        <a href="/Default" type="button" class="btn btn-warning btn-custom">QUITTER LE MENU</a> <br /><br />
    </div>
</div>

    <script>
    // Modifier la taille des boutons
    var btns = document.querySelectorAll('.btn-custom');

    function setButtonSize(size) {
        for (var i = 0; i < btns.length; i++) {
            btns[i].style.setProperty('width', size);
        }
    }

    // Exemple de modification de la taille des boutons à 250px
    setButtonSize('450px');
    </script>

</asp:Content>
