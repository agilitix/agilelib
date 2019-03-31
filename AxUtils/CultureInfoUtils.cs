using System.Globalization;
using System.Threading;

namespace AxUtils
{
    public static class CultureInfoUtils
    {
        public static void SetDefaultCultureInfo_en_US()
        {
            SetDefaultCultureInfo(CultureInfo.GetCultureInfo("en-US"));
        }

        public static void SetDefaultCultureInfo(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
