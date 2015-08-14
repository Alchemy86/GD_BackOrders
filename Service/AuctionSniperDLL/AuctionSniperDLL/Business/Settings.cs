using System;

namespace AuctionSniperDLL.Business
{
    public static class Settings
    {
        public static DateTime GetDateTimeOffSet()
        {
            return DateTime.Now.AddHours(-8);
        }
    }
}
