﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApp.Admin.Security;
using WestWindSystem.DataModels;

namespace WebApp.Sales
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated || !User.IsInRole(Settings.SupplierRole))
                Response.Redirect("~", true);
            if(!IsPostBack)
            {
                // Load up the info on the supplier
                // TODO: Replce hard-coded supplier ID with the user's supplierID
                SupplierInfo.Text = "Temp Supplier: ID 2";
            }
        }

        protected void CurrentOrders_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Ship")
            {
                // Gather information from the form to sent to the BLL for shipping
                // ShipOrder(int orderId, ShippingDirections shipping, List<ShippedItem> items)
                int orderId = 0;
                Label orderIdLabel = e.Item.FindControl("OrderIdLabel") as Label; // Safe cast the Control object to a Label object
                if (orderIdLabel != null)
                    orderId = int.Parse(orderIdLabel.Text);

                ShippingDirections shipInfo = new ShippingDirections(); // black object
                DropDownList shipViaDropDown = e.Item.FindControl("") as DropDownList;
                if (shipViaDropDown != null) //  If I got the control
                    shipInfo.ShipperId = int.Parse(shipViaDropDown.SelectedValue);

                TextBox tracking = e.Item.FindControl("TrackingCode") as TextBox;
                if (tracking != null)
                    shipInfo.TrackingCode = tracking.Text;

                decimal price;
                TextBox frieght = e.Item.FindControl("FreightCharge") as TextBox;
                if (frieght != null && decimal.TryParse(frieght.Text, out price))
                    shipInfo.FreightCharge = price;
            }
        }
    }
}