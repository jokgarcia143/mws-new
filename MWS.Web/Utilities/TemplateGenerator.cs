using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Text;
using MWS.Web.Models;

namespace MWS.Web.Utilities
{
    public static class TemplateGenerator
    {

        public static string GetDisconnectionNoticeHTMLString(string imagePath, IEnumerable<Disconnection> disconnections)
        {


            //var htmlDoc = new StringBuilder();
            //htmlDoc.AppendLine("<td>");
            //var path = _webHostEnvironment.WebRootPath + "\\1.png";//It fetches files under wwwroot
            //htmlDoc.AppendLine($"<img src=\"{path}\" />");
            //htmlDoc.AppendLine("</td>");

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"<img width='80' height='80' src=\"{imagePath}\" />");
            stringBuilder.Append(@"<html> 
                                    <head></head>
                                    <body>
                                        <table>
                                            <tr>
                                            </tr>
                                        </table>
            ");
            foreach(var disconnection in disconnections)
            {
                stringBuilder.AppendFormat(@"<tr>
                                                <td>{0}</td>
                                            </tr>", disconnection.AcctNo);
            }
            stringBuilder.Append(@"
                                    </body>
                                </html>
            ");

            return stringBuilder.ToString();
        }
    }
}
