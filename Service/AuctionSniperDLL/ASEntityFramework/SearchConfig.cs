//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASEntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class SearchConfig
    {
        public SearchConfig()
        {
            this.SearchType = "\'Keyword\'";
        }
    
        public System.Guid ID { get; set; }
        public System.Guid UserID { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public bool RequirePR { get; set; }
        public int PRMin { get; set; }
        public int PRMax { get; set; }
        public int MajesticBacklinksMin { get; set; }
        public int MajesticBacklinksMAX { get; set; }
        public int MajesticTrustFlowMin { get; set; }
        public int MajesticTrustFlowMax { get; set; }
        public int MajesticCitationFlowMax { get; set; }
        public int MajesticCitationFlowMin { get; set; }
        public bool MOZPA { get; set; }
        public int MOZPAMin { get; set; }
        public int MOZPAMax { get; set; }
        public bool MOZDA { get; set; }
        public int MOZDAMin { get; set; }
        public int MOZDAMax { get; set; }
        public bool MajesticIPS { get; set; }
        public int MajesticIPSMin { get; set; }
        public int MajesticIPSMax { get; set; }
        public int DomainAgeMin { get; set; }
        public int DomainAgeMax { get; set; }
        public bool DomainPrice { get; set; }
        public int DomainPriceMin { get; set; }
        public int DomainPriceMax { get; set; }
        public int FacebookLikesMin { get; set; }
        public int FacebookLikesMax { get; set; }
        public int FacebookSharesMin { get; set; }
        public int FacebookSharesMax { get; set; }
        public bool TwitterShares { get; set; }
        public int TwitterSharesMin { get; set; }
        public int TwitterSharesMax { get; set; }
        public bool RedditShares { get; set; }
        public int RedditSharesMin { get; set; }
        public int RedditSharesMax { get; set; }
        public bool PintrestShares { get; set; }
        public int PintrestSharesMin { get; set; }
        public int PintrestSharesMax { get; set; }
        public bool GPlusShares { get; set; }
        public int GPlusSharesMin { get; set; }
        public int GPlusSharesMax { get; set; }
        public bool Auction { get; set; }
        public bool BuyNow { get; set; }
        public bool BarginBin { get; set; }
        public bool CloseOut { get; set; }
        public bool PendingDelete { get; set; }
        public bool Expired { get; set; }
        public bool GoDaddy { get; set; }
        public bool NameJet { get; set; }
        public bool Dynadot { get; set; }
        public bool SnapName { get; set; }
        public bool Sedo { get; set; }
        public bool FakePR { get; set; }
        public bool FakeAlexa { get; set; }
        public bool RequireSemrushKey { get; set; }
        public bool MajMillion { get; set; }
        public bool QuantMillion { get; set; }
        public bool AlexARankRequired { get; set; }
        public bool SemrushRankReq { get; set; }
        public bool SimilarWebRankReq { get; set; }
        public bool RequireAv { get; set; }
        public bool HideAdult { get; set; }
        public bool HideSpammy { get; set; }
        public bool HideBrand { get; set; }
        public int EndInLower { get; set; }
        public int EndInUpper { get; set; }
        public string ParentCat { get; set; }
        public string ChildCat { get; set; }
        public string ParentTopCat { get; set; }
        public string ChildTopCat { get; set; }
        public bool GoogleIndex { get; set; }
        public bool dmoz { get; set; }
        public bool AllowDash { get; set; }
        public bool AllowDigits { get; set; }
        public bool OnlyDigits { get; set; }
        public bool SalesTypeOffer { get; set; }
        public string SearchType { get; set; }
        public string Keyword { get; set; }
        public string KeywordSearchType { get; set; }
        public string Pattern { get; set; }
        public string PatternType { get; set; }
        public bool Droplists { get; set; }
        public bool RequireSemrushTraffic { get; set; }
        public bool end_asia { get; set; }
        public bool end_at { get; set; }
        public bool end_au { get; set; }
        public bool end_be { get; set; }
        public bool end_biz { get; set; }
        public bool end_ca { get; set; }
        public bool end_cc { get; set; }
        public bool end_ch { get; set; }
        public bool end_co { get; set; }
        public bool end_com { get; set; }
        public bool end_de { get; set; }
        public bool end_eu { get; set; }
        public bool end_fr { get; set; }
        public bool end_ie { get; set; }
        public bool end_in { get; set; }
        public bool end_info { get; set; }
        public bool end_it { get; set; }
        public bool end_me { get; set; }
        public bool end_mobi { get; set; }
        public bool end_mx { get; set; }
        public bool end_net { get; set; }
        public bool end_nl { get; set; }
        public bool end_nu { get; set; }
        public bool end_org { get; set; }
        public bool end_pl { get; set; }
        public bool end_ru { get; set; }
        public bool end_se { get; set; }
        public bool end_su { get; set; }
        public bool end_tv { get; set; }
        public bool end_uk { get; set; }
        public bool end_us { get; set; }
        public bool end_misc { get; set; }
    }
}
