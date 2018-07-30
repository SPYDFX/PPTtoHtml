using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wolfy.OfficePreview;

public partial class Office2Html : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnWord_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        switch (btn.CommandArgument)
        {
            case "docx":
                Office2HtmlHelper.Word2Html(MapPath("/Doc/1.doc"), MapPath("/Html/"), DateTime.Now.ToString("yyyyMMddHHmmss")+"_doc");
                break;
            case "xlsx":
                Office2HtmlHelper.Excel2Html(MapPath("/Excel/1.xlsx"), MapPath("/Html/"), DateTime.Now.ToString("yyyyMMddHHmmss") + "_excel");
                break;
            case "ppt":
                Office2HtmlHelper.PPT2Html(MapPath("/PPT/JavaScript.pptx"), MapPath("/Html/"), DateTime.Now.ToString("yyyyMMddHHmmss") + "_ppt");
                break;
            default:
                break;
        }
    }
}