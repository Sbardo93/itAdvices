﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ITAdvices.Pages.Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-6">
            <div class="form-signin">
                <h2 class="form-signin-heading">Effettua l'accesso</h2>
                <label for="inputEmail" class="sr-only">Email</label>
                <input type="email" id="inputEmail" class="form-control" placeholder="Email" required autofocus>
                <label for="inputPassword" class="sr-only">Password</label>
                <input type="password" id="inputPassword" class="form-control" placeholder="Password" required>

                <label class="custom-control custom-checkbox">
                    <input id="chkRicordami" runat="server" type="checkbox" class="custom-control-input">
                    <span class="custom-control-indicator"></span>
                    <span class="custom-control-description">Ricordami</span>
                </label>

                <button id="btnLogin" class="btn btn-lg btn-primary btn-block" onclick="return doLogin();">Accedi</button>
            </div>
        </div>
        <div class="col-lg-3"></div>
    </div>
    <script type='text/javascript'>
        function doLogin() {
            var email = $('#inputEmail').val();
            var password = $('#inputPassword').val();
            doAjax('Login.aspx/TryLogin', "{email:" + JSON.stringify(email) + ", password:" + JSON.stringify(password) + "}");
            return false;
        }
    </script>
</asp:Content>
