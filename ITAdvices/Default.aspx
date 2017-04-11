<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ITAdvices.Default" %>

<%@ Register Src="~/UserControl/ucSmartGrid.ascx" TagName="ucSmartGrid" TagPrefix="ucSmartGrid" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="<%=ResolveUrl("~/js/datatables.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/bootstrap.min.js")%>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/bootstrap-toggle.js")%>" type="text/javascript"></script>
    <link href="<%=ResolveUrl("~/style/dataTables.min.css")%>" rel="stylesheet" />
    <link href="<%=ResolveUrl("~/style/bootstrap-toggle.css")%>" rel="stylesheet" />
    <link href="<%=ResolveUrl("~/style/font-awesome/css/font-awesome.css")%>" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ciao
            <asp:Label ID="lblprova" runat="server"></asp:Label>
        </div>
        <ucSmartGrid:ucSmartGrid ID="ucSmartGrid" runat="server"></ucSmartGrid:ucSmartGrid>
    </form>
</body>
</html>
