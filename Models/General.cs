using System.Globalization;
using System.Security.Claims;

namespace FMS.Models
{
    public static class General
    {
        public static IHttpContextAccessor _httpContextAccessor { get; private set; }
        public static IConfiguration _configuration;
        public static IWebHostEnvironment _iHostingEnvironment;
        public static int PgSize { get; private set; }

        public static void Configure(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment iHostingEnvironment)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _iHostingEnvironment = iHostingEnvironment;
            PgSize = General.ConvertToInt(Setting("AppSetting:PgSize"));
        }

        public static string Setting(string key)
        {
            return _configuration.GetSection(key).Value;
        }

        public static int GetUserID()
        {
            return General.ConvertToInt(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name));
        }

        public static bool IsAdministrator()
        {
            return _httpContextAccessor.HttpContext.User.IsInRole("SuperAdmin");
        }

        public static bool IsZonalHead()
        {
            return _httpContextAccessor.HttpContext.User.IsInRole("ZonalHead");
        }

        public static bool IsLocal()
        {
            return _httpContextAccessor.HttpContext.Request.Host.Host.Contains("localhost") ? true : false;
        }

        public static string GetISTDateTime(DateTime? dt)
        {
            if (dt == null) return "";
            var passdt = dt ?? DateTime.Now;
            if (passdt.Year <= 1900) return "";
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            return TimeZoneInfo.ConvertTime(passdt.AddMinutes(330), easternZone).ToString("dd/MM/yyyy HH:mm tt");
        }

        public static string GetISTDateTime(DateTime? dt, string format)
        {
            if (dt == null) return "";
            var passdt = dt ?? DateTime.Now;
            if (passdt.Year <= 1900) return "";
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            return TimeZoneInfo.ConvertTime(passdt.AddMinutes(330), easternZone).ToString(format);
            //return passdt.ToString(format);
        }

        public static DateTime ConvertDateToMmddyyyy(string dt)
        {
            return Convert.ToDateTime(DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
        }

        public static bool HasRights(List<string> allright, string findright)
        {
            return allright.Contains(findright);
        }

        public static string GetWebRootPath()
        {
            return _iHostingEnvironment.WebRootPath;
        }

        public static int ConvertToInt(dynamic data)
        {
            int.TryParse(data, out int result);
            return result;
        }

        public static string CommaSeparatedString(List<string> data)
        {
            if (data == null) return "";
            else return string.Join(",", data);
        }
    }
}