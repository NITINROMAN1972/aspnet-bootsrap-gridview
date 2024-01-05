using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridVIew_GridViewBootstrap : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dtResp = GetResponsibilitiesData();
            BindGridView(dtResp);
        }
    }

    private DataTable GetResponsibilitiesData()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select MenuText, MenuParent, MenuCode, Publish from MenuBars867";
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            con.Close();

            return dt;
        }
    }

    protected void BindGridView(DataTable dtResp)
    {
        GridMenu.DataSource = dtResp;
        GridMenu.DataBind();
    }
}