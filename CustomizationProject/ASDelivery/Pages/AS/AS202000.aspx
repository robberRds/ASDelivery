<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true" ValidateRequest="false" CodeFile="AS202000.aspx.cs" Inherits="Page_AS202000" Title="Untitled Page" %>
<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" Runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%"
        TypeName="ASDelivery.ASPreparationMaint"
        PrimaryView="Preparation"
        >
		<CallbackCommands>

		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>
<asp:Content ID="cont2" ContentPlaceHolderID="phF" Runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" DataMember="Preparation" Width="100%" Height="100px" AllowAutoHide="false">
		<Template>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule14" StartColumn="True" />
			<px:PXSelector runat="server" ID="CstPXSelector6" DataField="RefNbr" ></px:PXSelector>
			<px:PXSelector runat="server" ID="CstPXSelector1" DataField="EmployerID" ></px:PXSelector>
			<px:PXDropDown runat="server" ID="CstPXDropDown7" DataField="Status" ></px:PXDropDown>
			<px:PXLayoutRule runat="server" ID="CstPXLayoutRule15" StartColumn="True" />
			<px:PXDateTimeEdit Enabled="False" Size="15px" runat="server" ID="CstPXDateTimeEdit10" DataField="StartOfPreparation" ></px:PXDateTimeEdit>
			<px:PXDateTimeEdit Enabled="False" Size="15px" runat="server" ID="CstPXDateTimeEdit9" DataField="FinishOfPreparation" ></px:PXDateTimeEdit></Template>
	</px:PXFormView>
</asp:Content>
<asp:Content ID="cont3" ContentPlaceHolderID="phG" Runat="Server">
	<px:PXTab runat="server" ID="tab">
		<Items>
			<px:PXTabItem Text="Dishes" >
				<Template>
					<px:PXGrid runat="server" ID="CstPXGrid17" Height="150px" SkinID="Details" Width="100%">
						<Levels>
							<px:PXGridLevel DataMember="Order" >
								<Columns>
									<px:PXGridColumn CommitChanges="True" DataField="OrderID" Width="200px" ></px:PXGridColumn>
									<px:PXGridColumn DataField="RecipeID" Width="200px" ></px:PXGridColumn>
									<px:PXGridColumn DataField="Count" Width="150px" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels></px:PXGrid></Template></px:PXTabItem>
			<px:PXTabItem Text="History">
				<Template>
					<px:PXGrid Height="150px" SkinID="Details" Width="100%" runat="server" ID="CstPXGrid18">
						<Levels>
							<px:PXGridLevel DataMember="History" >
								<Columns>
									<px:PXGridColumn DataField="EmployerID" Width="100" ></px:PXGridColumn>
									<px:PXGridColumn DataField="StartOfPreparation" Width="150" ></px:PXGridColumn>
									<px:PXGridColumn DataField="FinishOfPreparation" Width="150" ></px:PXGridColumn></Columns></px:PXGridLevel></Levels></px:PXGrid></Template></px:PXTabItem></Items></px:PXTab></asp:Content>
