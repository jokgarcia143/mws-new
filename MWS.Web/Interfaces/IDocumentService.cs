
using System.Collections.Generic;

namespace MWS.Web.Interfaces
{
    public interface IDocumentService
    {

        byte[] GeneratePDF(string partialName);

        //byte[] GeneratePdfFromRazorViewList<TModel>(TModel models, string partialName);
    }
}
