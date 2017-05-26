using System.Globalization;
using System.Threading;

namespace AxUtils
{
    public static class CultureInfoUtils
    {
        public static void SetDefaultCultureInfo_en_US()
        {
            var culture = new CultureInfo("en-US");
            SetDefaultCultureInfo(culture);
        }

        public static void SetDefaultCultureInfo(CultureInfo culture)
        {
            // Should work for all frameworks.
            Thread.CurrentThread.CurrentCulture.GetType().GetProperty("DefaultThreadCurrentCulture")?.SetValue(Thread.CurrentThread.CurrentCulture, culture, null);
            Thread.CurrentThread.CurrentCulture.GetType().GetProperty("DefaultThreadCurrentUICulture")?.SetValue(Thread.CurrentThread.CurrentCulture, culture, null);
        }
    }
}
