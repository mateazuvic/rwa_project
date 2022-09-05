using Aplikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplikacija
{
    public partial class EditKupac : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("https://localhost:44353/Account/Login");
                }
            }
        }

        protected void ddlRowsCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlRowsCount.SelectedIndex)
            {
                case 0:
                    gvCustomers.PageSize = 10;
                    break; 
                case 1:
                    gvCustomers.PageSize = 20;
                    break; 
                case 2:
                    gvCustomers.PageSize = 30;
                    break;               
                case 3:
                    gvCustomers.PageSize = 40;
                    break;               
                case 4:
                    gvCustomers.PageSize = 50;
                    break;
                default:
                    break;
            }

            
        }
    }
}