<%@ Page Title="admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebApplication1.admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <head>
        <link href="assets/css/admin.css" rel="stylesheet" />
    </head>

<div class="container register">
                <div class="row">
                    <br /><br />
                    <div class="col-md-3 register-left">
                        <h3>Welcome</h3>
                        <p>prenez votre temps administrateur, nous somme la pour vous servir</p> <br /><br /><br />
                        <a href="/menu"><button type="button" class="btn btn-light" style="width: 150px; border-radius: 15px;">Retour</button></a> 
                        
                    </div>
                    <div class="col-md-9 register-right">
                        <ul class="nav nav-tabs nav-justified" id="myTab" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Admin</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="profile-tab" data-toggle="tab" href="/user" role="tab" aria-controls="profile" aria-selected="false">Utilisateur</a>
                            </li>
                        </ul>

                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                <h3 class="register-heading">Apply as a Employee</h3>
                                <div class="row register-form">
                                    <asp:Label runat="server" ID="poste_salaire" Text="Label"></asp:Label>
                                    <div class="col-md-6">
   
                                        <div class="form-group">                                  
                                            <asp:TextBox class="form-control" placeholder="Nom de l'entreprise *" runat="server" ID="nomE"></asp:TextBox>
                                            <asp:Label ID="label_nom_entreprise" runat="server" Width="90%"></asp:Label>
                                        </div><br />
    
                                        <div class="form-group">      
                                            <asp:TextBox runat="server" class="form-control" placeholder="Date de creation *" ID="date_creation"></asp:TextBox>
                                            <asp:Label ID="label_creation" runat="server" Width="90%"></asp:Label>
                                        </div><br />
                                       
                                            <div class="form-group">
                                                <asp:TextBox runat="server" ID="coef" class="form-control" placeholder="Coeficient *"></asp:TextBox>
                                                <asp:Label ID="label_coeficient" runat="server" Width="90%"></asp:Label>
                                            </div><br />

                                    </div>
    
                                     <div class="col-md-6"> 
    
                                        <div class="form-group">
                                            <asp:TextBox runat="server" ID="nbre_employe" class="form-control" placeholder="nombre d'employe *"></asp:TextBox>
                                            <asp:Label ID="label_nbre_employe" runat="server" Width="100%"></asp:Label>


                                        </div><br />
                                            <asp:TextBox runat="server" class="form-control" placeholder="Poste *" ID="Type_poste"></asp:TextBox> <br /><br />
                                            <asp:TextBox runat="server" class="form-control" placeholder="Salaire *" ID="salaire"></asp:TextBox> <br />
                                            <asp:Label ID="label_nbre_poste" runat="server" Width="100%"></asp:Label>
                                            <asp:Button runat="server" class="form-control" Text="Enregistrer" OnClick="Unnamed4_Click" ID="Button1"></asp:Button>
                                            <div ID="divTableau" runat="server"></div>
                                            <div ID="pan" runat="server"></div>
                                        <asp:Button runat="server" class="btnRegister" Text="Valider" OnClick="Unnamed5_Click"></asp:Button>

                                         <asp:Label ID="label_valider" runat="server" Width="100%"></asp:Label>

                                    </div>
    
    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

</asp:Content>
