namespace MWS.Web.Interfaces
{
    public interface IRazorRendererHelper
    {
        string RenderPartialToString<TModel>(string partialName, TModel model);
        //string RenderPartialToString<TModel>(string partialName);
    }
}
