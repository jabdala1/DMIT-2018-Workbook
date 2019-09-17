<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="WebAppCRUD.Admin.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Products</h1>

    <asp:GridView ID="ProductGridView" runat="server" DataSourceID="ProductsDataSource" ItemType="WestWindSystem.Entities.Product" AutoGenerateColumns="False" CssClass="table tabl-hover">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID"></asp:BoundField>
            <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName"></asp:BoundField>

            <asp:TemplateField HeaderText="Supplier">
                <ItemTemplate>
                    <asp:DropDownList ID="SupplierDropDown" runat="server" SelectedValue="<%# Item.SupplierID %>" DataSourceID="SupplierDataSource" DataTextField="CompanyName" DataValueField="SupplierID" Enabled="false"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category">
                <ItemTemplate>
                    <asp:DropDownList ID="CategoryDropDown" runat="server" SelectedValue="<%# Item.CategoryID %>" DataSourceID="CategoryDateSouce" DataTextField="CategoryName" DataValueField="CategoryID"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CategoryID" HeaderText="Category ID" SortExpression="CategoryID"></asp:BoundField> 
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="Quantity Per Unit" SortExpression="QuantityPerUnit"></asp:BoundField>
            <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Minimum Order Quantity" SortExpression="MinimumOrderQuantity"></asp:BoundField>
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" SortExpression="UnitPrice"></asp:BoundField>
            <asp:BoundField DataField="UnitsOnOrder" HeaderText="Units On Order" SortExpression="UnitsOnOrder"></asp:BoundField>
            <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" SortExpression="Discontinued"></asp:CheckBoxField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource runat="server" ID="ProductsDataSource" OldValuesParameterFormatString="original_{0}" SelectMethod="ListProducts" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="CategoryDateSouce" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListCategories" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
