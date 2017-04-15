<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITAdvices.Pages.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        Ciao
            <asp:Label ID="lblprova" runat="server"></asp:Label>
    </div>
    <%--<ucSmartGrid:ucSmartGrid ID="ucSmartGrid" runat="server"></ucSmartGrid:ucSmartGrid>--%>
</asp:Content>
