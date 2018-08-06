using Word = Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Office.Core;

namespace PPTShowHtml.Common
{
    public class Office2HtmlHelper
    {
        /// <summary>
        /// Word转成Html
        /// </summary>
        /// <param name="path">要转换的文档的路径</param>
        /// <param name="savePath">转换成html的保存路径</param>
        /// <param name="wordFileName">转换成html的文件名字</param>
        public static void Word2Html(string path, string savePath, string wordFileName)
        {

            Word.Application word = new Word.Application();
            Type wordType = word.GetType();
            Word.Documents docs = word.Documents;
            Type docsType = docs.GetType();
            Word.Document doc = (Word.Document)docsType.InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod, null, docs, new Object[] { (object)path, true, true });
            Type docType = doc.GetType();
            string strSaveFileName = savePath + wordFileName + ".html";
            object saveFileName = (object)strSaveFileName;
            docType.InvokeMember("SaveAs", System.Reflection.BindingFlags.InvokeMethod, null, doc, new object[] { saveFileName, Word.WdSaveFormat.wdFormatFilteredHTML });
            docType.InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod, null, doc, null);
            wordType.InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod, null, word, null);

        }
        /// <summary>
        /// Excel转成Html
        /// </summary>
        /// <param name="path">要转换的文档的路径</param>
        /// <param name="savePath">转换成html的保存路径</param>
        /// <param name="wordFileName">转换成html的文件名字</param>
        public static void Excel2Html(string path, string savePath, string wordFileName)
        {
            string str = string.Empty;
            Microsoft.Office.Interop.Excel.Application repExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            workbook = repExcel.Application.Workbooks.Open(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            object htmlFile = savePath + wordFileName + ".html";
            object ofmt = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
            workbook.SaveAs(htmlFile, ofmt, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            object osave = false;
            workbook.Close(osave, Type.Missing, Type.Missing);
            repExcel.Quit();
        }
        /// <summary>
        /// ppt转成Html
        /// </summary>
        /// <param name="path">要转换的文档的路径</param>
        /// <param name="savePath">转换成html的保存路径</param>
        /// <param name="wordFileName">转换成html的文件名字</param>
        public static void PPT2Html(string path, string savePath, string wordFileName)
        {
            Microsoft.Office.Interop.PowerPoint.Application ppApp = new Microsoft.Office.Interop.PowerPoint.Application();
            string strSourceFile = path;
            string strDestinationFile = savePath + wordFileName;
            Microsoft.Office.Interop.PowerPoint.Presentation prsPres = ppApp.Presentations.Open(strSourceFile, Microsoft.Office.Core.MsoTriState.msoTrue, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse);

            prsPres.SaveAs(strDestinationFile, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsHTML, MsoTriState.msoTrue);
            prsPres.Close();
            ppApp.Quit();
            writeHtml(strDestinationFile);
        }

        public static string writeHtml(string path,string htmlName="")
        {
            if(string.IsNullOrWhiteSpace(htmlName))
            {
                htmlName = DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            DirectoryInfo dir = new DirectoryInfo(path);   //你的文件夹未知
            FileStream fs = new FileStream(dir.FullName + "\\"+ htmlName+ ".html", FileMode.Create, FileAccess.Write);//创建HTML文件
            StreamWriter sw = new StreamWriter(fs);
            FileInfo[] files = dir.GetFiles();

            sw.Write("<!DOCTYPE HTML><html></html><head><meta charset = \"utf-8\" />");//写入头文件和编码声明
            sw.Write("<link rel=\"stylesheet\" type=\"text / css\" href=\"../Content/bootstrap.css\">");//写入头文件和编码声明
            sw.Write("<link rel=\"stylesheet\" type=\"text / css\" href=\"../Content/bootstrap.min.css\">");//写入头文件和编码声明
            //sw.Write("<script type=\"text / javascript\" src=\"attack.js\"></script>");//写入头文件和编码声明
            sw.Write("</head><body>");//写入头文件和编码声明
            foreach (FileInfo f in files)    //遍历文件
            {

                var strExtension = f.Extension.ToLower();
                if (strExtension == ".png" || strExtension == ".jpg" || strExtension == ".bmp")    //如果是图片 则写入HTML代码
                {
                    sw.Write("<img src=\"" + f.Name + "\" />\r\n");
                }
            }
            sw.Write("</body></html>"); //写入结束标签
            sw.Close();
            fs.Close();//关闭文件流
            return htmlName + ".html";
            
        }
    }
}