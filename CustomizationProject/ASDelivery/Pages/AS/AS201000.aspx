<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS201000.aspx.cs" Inherits="Page_AS201000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="ASDelivery.ASRecipeMaint"
        PrimaryView="Recipe">
        <CallbackCommands>
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Recipe" Width="100%" Height="" AllowAutoHide="false">
        <Template>
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" StartRow="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" ID="CstPXSelector3" DataField="RefNbr"></px:PXSelector>
            <px:PXNumberEdit runat="server" ID="CstPXNumberEdit2" DataField="DishID" Width="200"></px:PXNumberEdit>
            <px:PXLayoutRule StartColumn="True" runat="server" ID="CstPXLayoutRule8" StartRow="False"></px:PXLayoutRule>
            <px:PXTextEdit runat="server" ID="CstPXTextEdit1" DataField="Description"></px:PXTextEdit>
        </Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid SkinID="Details" Width="100%" runat="server" ID="Ingredients">
        <Levels>
            <px:PXGridLevel DataMember="Ingredients">
                <Columns>
                    <px:PXGridColumn DataField="InventoryID" Width="220" />
                    <px:PXGridColumn DataField="Description" Width="220" />
                    <px:PXGridColumn DataField="Count" Width="70" />
                </Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Enabled="True"></AutoSize>
    </px:PXGrid>
</asp:Content>
