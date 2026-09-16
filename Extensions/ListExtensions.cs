namespace AjaxSergey.Extensions;

public static class ListExtensions
{
    public static string WriteList(this List<string> list, string separator = ", ") => string.Join(separator, list);
}
