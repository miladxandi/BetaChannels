namespace BetaChannels.Shared.Helpers;

public static class AppConstants
{
    public const string AppName = "Beta Channels";
    public const string AppVersion = "1.0.0";
    
    public static class SubscriptionPrices
    {
        public const decimal BasicMonthly = 299_000m;
        public const decimal PremiumMonthly = 599_000m;
        public const decimal VIPMonthly = 999_000m;
    }

    public static class Features
    {
        public static readonly List<string> BasicFeatures = new()
        {
            "نمایش در جستجو",
            "۵ نمونه کار",
            "تقویم محتوایی پایه"
        };

        public static readonly List<string> PremiumFeatures = new()
        {
            "نمایش ویژه در جستجو",
            "۲۰ نمونه کار",
            "تقویم محتوایی پیشرفته",
            "آمار و نمودار",
            "دریافت سناریو"
        };

        public static readonly List<string> VIPFeatures = new()
        {
            "نمایش ویژه + استوری",
            "نمونه کار نامحدود",
            "تمام امکانات تقویم",
            "آمار پیشرفته",
            "دریافت سناریو اختصاصی",
            "تبلیغات ویژه",
            "پشتیبانی اولویت‌دار"
        };
    }

    public static class Routes
    {
        public const string Home = "/";
        public const string Login = "/login";
        public const string Register = "/register";
        public const string Dashboard = "/dashboard";
        public const string Services = "/services";
        public const string Portfolio = "/portfolio";
        public const string Calendar = "/calendar";
        public const string Payments = "/payments";
        public const string Subscription = "/subscription";
        public const string Freelancers = "/freelancers";
        public const string Projects = "/projects";
        public const string Profile = "/profile";
        public const string Settings = "/settings";
    }
}
