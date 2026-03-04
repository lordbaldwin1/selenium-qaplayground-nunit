using System;
using System.Collections.Generic;
using System.Text;

namespace selenium_qaplayground;

public static class AppSettings
{
    public static string BaseUrl => "https://qaplayground.dev";

    public static class Routes
    {
        public static string DynamicTable => "/apps/dynamic-table";
    }

    public static string GetUrl(string route)
    {
        return BaseUrl + route;
    }
}
