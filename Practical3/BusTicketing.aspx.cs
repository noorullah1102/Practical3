using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practical3
{
    public partial class BusTicketing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == true) //You can also type as - if (!IsPostBack)
            {
                lblTime.Text = "You are accessing this page on " +
                DateTime.Now.ToString();
            }
            if (!IsPostBack)
            {
               
                txtDepartDt.Text = DateTime.Today.ToShortDateString();
            }

        }

        protected void calDepartDt_SelectionChanged(object sender, EventArgs e)
        {
            txtDepartDt.Text = calDepartDt.SelectedDate.ToShortDateString();
        }

        protected void ddlTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlTo.SelectedIndex != ddlFrom.SelectedIndex) {
                lblError.Text = "Sorry, we do not provide service from " +
                    ddlFrom.SelectedItem.Text + " to " + ddlTo.SelectedItem.Text + ".";
                return;

            }
            else
            {
                lblError.Text = string.Empty;
            }

            if(txtAdult.Text == string.Empty)
            {
                lblError.Text = "Please enter number of adult.";
                return;
            }
            if (txtChild.Text == string.Empty)
            {
                lblError.Text = "Please enter number of child.";
                return;
            }

            float price = 0.00f;
            int adult, child;
            adult = Convert.ToInt16(txtAdult.Text);
            child = Convert.ToInt16(txtChild.Text);
            if (ddlFrom.SelectedIndex == 1 && ddlTo.SelectedIndex == 1)
            {
                price = adult * 34.00f + child * 25.50f;
            }
            if (ddlFrom.SelectedIndex == 2 && ddlTo.SelectedIndex == 2)
            {
                price = adult * 24.00f + child * 15.50f;
            }
            

            txtPrice.Text = price.ToString("C2");

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtAdult.Text = string.Empty;
            txtChild.Text = string.Empty;
            txtDepartDt.Text = string.Empty;
            txtPrice.Text = string.Empty;
            ddlFrom.SelectedIndex = 0;
        }
    }
}