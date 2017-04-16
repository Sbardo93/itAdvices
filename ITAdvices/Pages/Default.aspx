<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITAdvices.Pages.Default" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        Ciao
            <asp:Label ID="lblprova" runat="server"></asp:Label>
    </div>
    <%--<ucSmartGrid:ucSmartGrid ID="ucSmartGrid" runat="server"></ucSmartGrid:ucSmartGrid>--%>
</asp:Content>
