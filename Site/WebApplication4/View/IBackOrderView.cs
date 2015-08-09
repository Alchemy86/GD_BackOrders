using System;

namespace WebApplication4.View
{
    public interface IBackOrderView
    {
        string DomainName { get; }
        int CreditstoUse { get; }
        string AlertEmail1 { get; }
        string AlertEmail2 { get; }
        DateTime DateToPlaceOrder { get; }
    }
}
