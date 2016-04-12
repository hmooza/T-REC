using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_T_REC
{
    public class BasePage : System.Web.UI.Page
    {
        protected Web_T_REC.DataModel.Entities context;

        protected override void OnInit(EventArgs e)
        {
            // DB Context
            context = NewEntities();
            
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated == false)
            {
                Response.Redirect("~/Login.aspx");
            }

            base.OnLoad(e);
        }

        protected Web_T_REC.DataModel.Entities NewEntities()
        {
            var dbContext = new Web_T_REC.DataModel.Entities();
            // Default Connection String
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;

            //dbContext.Database.Connection.ConnectionString = this.ConnectionString;
            dbContext.Database.Connection.ConnectionString = connectionString;
            dbContext.Configuration.LazyLoadingEnabled = true;
            return dbContext;
        }
    }
}