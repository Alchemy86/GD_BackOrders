using System;

namespace AuctionSniperDLL.Business
{
    public static class Settings
    {
        public static DateTime GetDateTimeOffSet()
        {
            return DateTime.Now.AddHours(-8);
        }

        /// <summary>
        /// Returns the Pacific time
        /// </summary>
        /// <returns></returns>
        public static DateTime GetPacificTime()
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tzi);

            return localDateTime;
        }
    }
}
