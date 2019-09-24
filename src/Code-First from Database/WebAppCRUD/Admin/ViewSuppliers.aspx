﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewSuppliers.aspx.cs" Inherits="WebAppCRUD.Admin.ViewSuppliers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>View Suppliers</h1>

    <asp:Label ID="MessageLabel" runat="server"></asp:Label>

    <asp:ListView ID="SupplierListView" runat="server" OnItemInserting="SupplierListView_ItemInserting" OnItemInserted="SupplierListView_ItemInserted"
        DataSourceID="SupplierDataSource" InsertItemPosition="FirstItem" ItemType="WestWindSystem.Entities.Supplier">

        <LayoutTemplate>
            <table class="table table-hover table-condensed">
                <thead>
                    <tr>
                        <th>Supplier ID</th>
                        <th>Company Name</th>
                        <th>Contact </th>
                        <th>Address</th>
                        <th>Phone / Fax</th>
                    </tr>
                </thead>
                <tbody>
                    <tr id="itemPlaceholder" runat="server"></tr>
                </tbody>
            </table>
        </LayoutTemplate>

        <InsertItemTemplate>
            <tr class="bg-success">
                <td>
                    <asp:LinkButton ID="AddSupplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-plus" CommandName="Insert">Add</asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="CompanyName" runat="server" Text="<%# BindItem.CompanyName %>" placeholder="Enter company name" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Contact" runat="server" Text="<%# BindItem.ContactName %>" placeholder="Contact Name" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="JobTitle" runat="server" Text="<%# BindItem.ContactTitle %>" placeholder="Job Title" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Email" runat="server" Text="<%# BindItem.Email %>" TextMode="Email" placeholder="Email" ></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="AddressDropDown" runat="server" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="FullAddress" DataValueField="AddressID" SelectedValue="<%# BindItem.AddressID %>">
                        <asp:ListItem Value="">[Select address on file]</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" Text="<%# BindItem.Phone %>" TextMode="Phone" placeholder="Phone #" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Fax" runat="server" Text="<%# BindItem.Fax %>" TextMode="Phone" placeholder="Fax" ></asp:TextBox>
                </td>
            </tr>
        </InsertItemTemplate>

        <EditItemTemplate>
            <tr class="bg-info">
                <td>
                    <asp:LinkButton ID="UpdateSuspplier" runat="server" CssClass="btn btn-success glyphicon glyphicon-ok" CommandName="Update">Save</asp:LinkButton>
                </td>
                <td>
                    <asp:TextBox ID="CompanyName" runat="server" Text="<%# BindItem.CompanyName %>" placeholder="Enter company name" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="Contact" runat="server" Text="<%# BindItem.ContactName %>" placeholder="Contact Name" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="JobTitle" runat="server" Text="<%# BindItem.ContactTitle %>" placeholder="Job Title" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Email" runat="server" Text="<%# BindItem.Email %>" TextMode="Email" placeholder="Email" ></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="AddressDropDown" runat="server" DataSourceID="AddressDataSource" AppendDataBoundItems="true" DataTextField="FullAddress" DataValueField="AddressID" SelectedValue="<%# BindItem.AddressID %>">
                        <asp:ListItem Value="">[Select address on file]</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="Phone" runat="server" Text="<%# BindItem.Phone %>" TextMode="Phone" placeholder="Phone #" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="Fax" runat="server" Text="<%# BindItem.Fax %>" TextMode="Phone" placeholder="Fax" ></asp:TextBox>
                </td>
            </tr>
        </EditItemTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:LinkButton ID="EditSupplier" runat="server" CssClass="btn btn-info glyphicon glyphicon-pencil" CommandName="Edit">Edit</asp:LinkButton>

                </td>
                <td><%# Item.CompanyName %></td>
                <td>
                    <%# Item.ContactName %>
                    &ndash;
                    <%# Item.ContactTitle %>
                    <br />
                    <%# Item.Email %>
                </td>
                <td>
                    <%# Item.Address.Address1 %>
                    <br />
                    <%# Item.Address.City %>
                    <%# Item.Address.Region %>
                    &nbsp;&nbsp;
                    <%# Item.Address.PostalCode %>
                    <%# Item.Address.Country %>
                </td>
                <td><%# Item.Phone %>
                    <br />
                    <%# Item.Fax %></td>
            </tr>
        </ItemTemplate>

    </asp:ListView>

    <asp:ObjectDataSource ID="SupplierDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListSuppliers" TypeName="WestWindSystem.BLL.CRUDController" DataObjectTypeName="WestWindSystem.Entities.Supplier" InsertMethod="AddSupplier"
      OnInserting="SupplierDataSource_Inserting"
      OnInserted="SupplierDataSource_Inserted"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="AddressDataSource" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ListAddresses" TypeName="WestWindSystem.BLL.CRUDController"></asp:ObjectDataSource>
</asp:Content>
