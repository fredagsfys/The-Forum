using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    #region
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var di = new DirectoryInfo(Server.MapPath("~/Content/Files/"));
            var files = di.GetFiles();
            FileRepeater.DataSource = files;
            FileRepeater.DataBind();

            if (Request.QueryString["Name"] != null)
                {
                    Image1.ImageUrl = "~/Content/Files/" + Request.QueryString["Name"];
                }
            
        }
    }
    #endregion
    #region
    protected void FileUpload_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Gallery file = new Gallery();

            file.SaveImage(FileUpload.PostedFile.InputStream, FileUpload.PostedFile.FileName);

            var di = new DirectoryInfo(Server.MapPath("~/Content/Files/"));
            var files = di.GetFiles();

            FileRepeater.DataSource = files;
            FileRepeater.DataBind();

            Response.Redirect("Default.aspx?Name=" + FileUpload.PostedFile.FileName);

            

        }
    }
    #endregion
}