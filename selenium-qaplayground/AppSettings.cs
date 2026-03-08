namespace selenium_qaplayground;

public static class AppSettings
{
    public static string BaseUrl => "https://qaplayground.dev";

    public static class Routes
    {
        public static string DynamicTable => "/apps/dynamic-table";
        public static string VerifyAccount => "/apps/verify-account";
        public static string TagsInput => "/apps/tags-input-box";
        public static string SortableList => "/apps/sortable-list";
    }

    public static string GetUrl(string route)
    {
        return BaseUrl + route;
    }
}
