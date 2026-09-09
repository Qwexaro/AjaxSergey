namespace AjaxSergey.Extensions;

public static class ListExtensions
{
    public static string ForEach(this List<string> list, string separator = ", ") => string.Join(separator, list);
}
