using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Web_T_REC.DataModel;

namespace Web_T_REC.Classes
{
    public class ClassPackage
    {
        public static void GetDate_Equipment_SET(out Packages[] Packagess, int? Pack_Id)
        {
            Web_T_REC.DataModel.Entities efen = new DataModel.Entities();

            if (Pack_Id != null)
            {
                Packagess = (from a in efen.Packages
                             where a.Pack_Id == Pack_Id
                             select a).ToArray();
            }
            else
            {
                Packagess = efen.Packages.ToArray();
            }
        }

        public static void GetEQForDDL_All(out ListItem[] lt)
        {
            lt = null;

            string strY = DateTime.Now.Year.ToString(new System.Globalization.CultureInfo("en-US"));
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.TypeName + ' => ' + b.TypeName + ' => ' + c.Name as Name ,c.ID");
            sql.AppendLine("from Equipment_Type a");
            sql.AppendLine("inner join Equipment_Type b on a.ID = b.ParentID");
            sql.AppendLine("inner join Equipment c on b.ID = c.Equip_type_id");

            DataTable dt = ClassMain.ExecuteComandTable(sql.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                List<ListItem> lstlt = new List<ListItem>();
                foreach (DataRow item in dt.Rows)
                {
                    ListItem en = new ListItem();
                    en.Text = item["ID"].ToString();
                    en.Value = item["Name"].ToString();

                    lstlt.Add(en);
                }

                if (lstlt != null && lstlt.Any())
                {
                    lt = lstlt.ToArray();
                }
            }
        }

    }
}