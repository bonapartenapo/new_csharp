<%@ Page Title="affichage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="affichage.aspx.cs" Inherits="WebApplication1.affichage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="assets/css/admin.css" rel="stylesheet" />
    </head>

<div class="container register">
                <div class="row">
                    <br /><br />

    <table>
    <tr>
        <th>Nom de l'entreprise</th>
        <th>Nom des employes</th>
        <th>Prenom des employes</th>
        <th>Matricule</th>
        <th>Date de recrutement</th>
        <th>Poste</th>
        <th>Salaire</th>
    </tr>

    <asp:Label ID="htmlTable" runat="server" Text="Label"></asp:Label>

   <%-- %> <% for ( int i= 0; i < WebApplication1.Class1.nbre_employe; i++ ) { %>
        <tr>
            <td><%= WebApplication1.Class1.name_entreprise %></td>
            <td><%= WebApplication1.Class1.dat %></td>
            <td><%= WebApplication1.Class1.dat %></td>
            <td><%=WebApplication1.Class1.tableau_postes[i] %></td>
            <td><%=WebApplication1.Class1.tableau_salaires[i] %></td> 
        </tr>
    <% } %>
--%>

</table>
            </div>

    <asp:Label ID="sqlErr" runat="server" Text="Label"></asp:Label>

</asp:Content>


<%--
    <div class="tab-content" id="myTabContent">
    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
        <h3 class="register-heading">Apply as a Employee</h3>
        <div class="row register-form">
            <div class="col-md-6">
                <div class="form-group">                                  
                    <asp:TextBox class="form-control" placeholder="Nom de l'entreprise *" runat="server" ID="nomE"></asp:TextBox>
                </div><br />
                <div class="form-group">
                    <asp:TextBox placeholder="date de creation *" runat="server" class="form-control" ></asp:TextBox>
                </div><br />
                <div class="form-group">
                    <asp:TextBox class="form-control" placeholder="nombre de poste *" runat="server"></asp:TextBox>
                </div><br />
                <div class="form-group">
                    <asp:TextBox class="form-control"  placeholder="Confirm Password *" runat="server"></asp:TextBox>
                </div><br />
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:TextBox runat="server" ID="coef" class="form-control" placeholder="Coeficient *"></asp:TextBox>
                </div><br />
    
                <div class="form-group">
                    <asp:TextBox runat="server" ID="nbre_employe" class="form-control" placeholder="nombre d'employe *"></asp:TextBox>
                    
                </div><br />

                <input type="submit" class="btnRegister"  value="Register"/>
            </div>
        </div>
    </div>
</div>
    --%>