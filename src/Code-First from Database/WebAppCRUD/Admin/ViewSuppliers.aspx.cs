using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCRUD.Admin
{
    public partial class ViewSuppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SupplierListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            // This fires just before the ListView calls the ObjectDataSource control to do an Insert.
            ; // no-op
        }

        protected void SupplierListView_ItemInserted(object sender, ListViewInsertedEventArgs e)
        {
            // This event is fired after the ObjectDataSource has returned from performing an Insert.
            ;
        }

        protected void SupplierDataSource_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            ; // Before calling the BLL
        }

        protected void SupplierDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            ; // After calling the BLL
            if(e.Exception != null)
            {
                // $"message" = String Interpolation
                Exception inner = e.Exception;
                while (inner.InnerException != null)
                    inner = inner.InnerException;

                string message = $"Problem inserting: { inner.GetType().Name } <blockquote>{ inner.Message }</blockquote>";

                if(inner is DbEntityValidationException)
                {
                    // Safe Type-Cast
                    var actual = inner as DbEntityValidationException;
                    message += "<ul>";
                    foreach(var detail in actual.EntityValidationErrors)
                    {
                        message += $"<li>{detail.Entry.Entity.GetType().Name}";

                        message += "<ol>";

                        foreach (var error in detail.ValidationErrors)
                        {
                            message += $"<li>{error.ErrorMessage}</li>";
                        }
                        message += "</ol></li>";
                    }
                }

                MessageLabel.Text = message;

                e.ExceptionHandled = true;
            }
        }
    }
}