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
            // By reflection for .NET 4.0 and onward.
            Thread.CurrentThread.CurrentCulture.GetType().GetProperty("DefaultThreadCurrentCulture")?.SetValue(Thread.CurrentThread.CurrentCulture, culture, null);
            Thread.CurrentThread.CurrentCulture.GetType().GetProperty("DefaultThreadCurrentUICulture")?.SetValue(Thread.CurrentThread.CurrentCulture, culture, null);
        }
    }
}
