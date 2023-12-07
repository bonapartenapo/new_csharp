<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


        <div>
            <h1>Page adminstrateur</h1>
            
 
            
            <label>Nombre de postes :</label>
            <asp:TextBox ID="poste" runat="server"></asp:TextBox>
            <br /><br />
            
            <h3>Saisir les informations pour chaque poste :</h3>
            <asp:GridView runat="server">

            </asp:GridView>
            
            <asp:Button ID="btnSave" runat="server" Text="afficher" OnClick="btnSave_Click" />
        </div>


</asp:Content>
