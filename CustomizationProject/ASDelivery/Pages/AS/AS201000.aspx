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
            <px:PXLayoutRule ID="PXLayoutRule1" runat="server" LabelsWidth="" ControlSize="" StartRow="True"></px:PXLayoutRule>
            <px:PXSelector runat="server" ID="CstPXSelector3" DataField="RefNbr"></px:PXSelector>
            <px:PXTextEdit CommitChanges="True" runat="server" ID="PXTextEdit3" DataField="RecName"></px:PXTextEdit>
	        <px:PXDateTimeEdit Enabled="False" Width="200" LabelWidth="" runat="server" ID="CstPXDateTimeEdit22" DataField="CreatedDateTime" ></px:PXDateTimeEdit>
            <px:PXLayoutRule StartColumn="True" runat="server" ID="CstPXLayoutRule8" StartRow="False"></px:PXLayoutRule>
            <px:PXSegmentMask CommitChanges="True" runat="server" ID="CstPXSegmentMask17" DataField="DishID"></px:PXSegmentMask>
            <px:PXTextEdit runat="server" ID="CstPXTextEdit21" DataField="DishID_InventoryItem_descr" ></px:PXTextEdit></Template>
    </px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server">
    <px:PXGrid SkinID="Details" Width="100%" runat="server" ID="Ingredients">
        <Levels>
            <px:PXGridLevel DataMember="Ingredients">
                <Columns>
	<px:PXGridColumn CommitChanges="True" DataField="IngredientsID" Width="200" ></px:PXGridColumn>
	<px:PXGridColumn DataField="IngredientsID_InventoryItem_descr" Width="200" ></px:PXGridColumn>
	<px:PXGridColumn CommitChanges="True" DataField="Count" Width="200" ></px:PXGridColumn></Columns>
            </px:PXGridLevel>
        </Levels>
        <AutoSize Enabled="True"></AutoSize>
    </px:PXGrid>
</asp:Content>
