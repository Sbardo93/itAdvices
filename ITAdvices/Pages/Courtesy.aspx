<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"
    CodeBehind="Courtesy.aspx.cs" Inherits="ITAdvices.Pages.Courtesy" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div style="margin: 0 auto; margin-top: 5px;" id="divWait" runat="server">
        <div runat="server" id="divSessioneScaduta" visible="false">
            <table style="width: 98%;">
                <tr>
                    <td style="width: 10%">
                        <img class='imgBase' alt="" src="../App_Themes/BlueINPS1/Images/Clock.png" />
                    </td>
                    <td class="Row1" style="width: 90%">
                        <asp:Label ID="lblSessioneScaduta" runat="server" SkinID="lblErrore"
                            meta:resourcekey="lblSessioneScadutaResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 125px;">
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="divSessioneDuplicata" visible="false">
            <table style="width: 98%">
                <tr>
                    <td style="width: 10%">
                        <img class='imgBase' alt="" src="../App_Themes/BlueINPS1/Images/sessioneDuplicata.png" />
                    </td>
                    <td class="Row1" style="width: 90%">
                        <asp:Label ID="lblSessioneDuplicata" runat="server" SkinID="lblErrore"
                            meta:resourcekey="lblSessioneDuplicataResource1"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 125px;">
                    </td>
                </tr>
            </table>
        </div>
        <div runat="server" id="divDefault" visible="false">
            <table style="width: 98%">
                <tr>
                    <td style="vertical-align: top; width: 10%">
                        <img class='imgBase' alt="" src="../App_Themes/BlueINPS1/Images/genericError.png" />
                    </td>
                    <td class="Row1" style="vertical-align: top; width: 90%">
                        <asp:Label ID="lblMsg" runat="server" SkinID="lblErrore" meta:resourcekey="lblMsgResource2"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="height: 125px;">
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
