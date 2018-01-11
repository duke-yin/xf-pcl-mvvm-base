namespace BaseSolution.Domain
{
    public static class WellKnown
    {
        public static string FriendlyApiError400 { get; set; } = "400 Error";
        public static string FriendlyApiError401 { get; set; } = "401 Error";
        public static string FriendlyApiError404 { get; set; } = "404 Error";
        public static string FriendlyApiError50X { get; set; } = "50X Error";
        public static string FriendlyApiErrorOther { get; set; } = "Other Error";
        public static string FriendlyApiErrorTimeout { get; set; } = "Timeout Error";
    }
}