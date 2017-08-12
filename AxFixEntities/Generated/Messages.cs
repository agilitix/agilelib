using System;
using System.Linq;
using System.Collections.Generic;

// Generated file

namespace FIX44.Entities
{
    public class Heartbeat
    {
        public string TestReqID { get; set; }
    }

    public class Logon
    {
        public EncryptMethod EncryptMethod { get; set; }
        public int HeartBtInt { get; set; }
        public int? RawDataLength { get; set; }
        public string RawData { get; set; }
        public bool? ResetSeqNumFlag { get; set; }
        public int? NextExpectedMsgSeqNum { get; set; }
        public int? MaxMessageSize { get; set; }
        public bool? TestMessageIndicator { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public NoMsgTypesItem[] NoMsgTypes { get; set; }

        public struct NoMsgTypesItem
        {
            public string RefMsgType { get; set; }
            public MsgDirection MsgDirection { get; set; }
        }
    }

    public class TestRequest
    {
        public string TestReqID { get; set; }
    }

    public class ResendRequest
    {
        public int BeginSeqNo { get; set; }
        public int EndSeqNo { get; set; }
    }

    public class Reject
    {
        public int RefSeqNum { get; set; }
        public int? RefTagID { get; set; }
        public string RefMsgType { get; set; }
        public SessionRejectReason SessionRejectReason { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class SequenceReset
    {
        public bool? GapFillFlag { get; set; }
        public int NewSeqNo { get; set; }
    }

    public class Logout
    {
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class BusinessMessageReject
    {
        public int? RefSeqNum { get; set; }
        public string RefMsgType { get; set; }
        public string BusinessRejectRefID { get; set; }
        public BusinessRejectReason BusinessRejectReason { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class UserRequest
    {
        public string UserRequestID { get; set; }
        public UserRequestType UserRequestType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public int? RawDataLength { get; set; }
        public string RawData { get; set; }
    }

    public class UserResponse
    {
        public string UserRequestID { get; set; }
        public string Username { get; set; }
        public UserStatus UserStatus { get; set; }
        public string UserStatusText { get; set; }
    }

    public class Advertisement
    {
        public string AdvId { get; set; }
        public AdvTransType AdvTransType { get; set; }
        public string AdvRefID { get; set; }
        public AdvSide AdvSide { get; set; }
        public int Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public DateTime? TradeDate { get; set; }
        public DateTime? TransactTime { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public string URLLink { get; set; }
        public string LastMkt { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Instrument Instrument { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument UnderlyingInstrument { get; set; }
        }
    }

    public class IndicationOfInterest
    {
        public string IOIid { get; set; }
        public IOITransType IOITransType { get; set; }
        public string IOIRefID { get; set; }
        public Side Side { get; set; }
        public QtyType QtyType { get; set; }
        public string IOIQty { get; set; }
        public string Currency { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ValidUntilTime { get; set; }
        public IOIQltyInd IOIQltyInd { get; set; }
        public bool? IOINaturalFlag { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public DateTime? TransactTime { get; set; }
        public string URLLink { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData? OrderQtyData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public string LegIOIQty { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
        }

        public NoIOIQualifiersItem[] NoIOIQualifiers { get; set; }

        public struct NoIOIQualifiersItem
        {
            public IOIQualifier IOIQualifier { get; set; }
        }

        public NoRoutingIDsItem[] NoRoutingIDs { get; set; }

        public struct NoRoutingIDsItem
        {
            public RoutingType RoutingType { get; set; }
            public string RoutingID { get; set; }
        }
    }

    public class News
    {
        public DateTime? OrigTime { get; set; }
        public Urgency Urgency { get; set; }
        public string Headline { get; set; }
        public int? EncodedHeadlineLen { get; set; }
        public string EncodedHeadline { get; set; }
        public string URLLink { get; set; }
        public int? RawDataLength { get; set; }
        public string RawData { get; set; }
        public NoRoutingIDsItem[] NoRoutingIDs { get; set; }

        public struct NoRoutingIDsItem
        {
            public RoutingType RoutingType { get; set; }
            public string RoutingID { get; set; }
        }

        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public Instrument? Instrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public LinesOfTextItem[] LinesOfText { get; set; }

        public struct LinesOfTextItem
        {
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
        }
    }

    public class Email
    {
        public string EmailThreadID { get; set; }
        public EmailType EmailType { get; set; }
        public DateTime? OrigTime { get; set; }
        public string Subject { get; set; }
        public int? EncodedSubjectLen { get; set; }
        public string EncodedSubject { get; set; }
        public string OrderID { get; set; }
        public string ClOrdID { get; set; }
        public int? RawDataLength { get; set; }
        public string RawData { get; set; }
        public NoRoutingIDsItem[] NoRoutingIDs { get; set; }

        public struct NoRoutingIDsItem
        {
            public RoutingType RoutingType { get; set; }
            public string RoutingID { get; set; }
        }

        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public Instrument? Instrument { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public LinesOfTextItem[] LinesOfText { get; set; }

        public struct LinesOfTextItem
        {
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
        }
    }

    public class QuoteRequest
    {
        public string QuoteReqID { get; set; }
        public string RFQReqID { get; set; }
        public string ClOrdID { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public decimal? PrevClosePx { get; set; }
            public QuoteRequestType QuoteRequestType { get; set; }
            public QuoteType QuoteType { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public DateTime? TradeOriginationDate { get; set; }
            public Side Side { get; set; }
            public QtyType QtyType { get; set; }
            public SettlType SettlType { get; set; }
            public DateTime? SettlDate { get; set; }
            public DateTime? SettlDate2 { get; set; }
            public int? OrderQty2 { get; set; }
            public string Currency { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
            public AccountType AccountType { get; set; }
            public QuotePriceType QuotePriceType { get; set; }
            public OrdType OrdType { get; set; }
            public DateTime? ValidUntilTime { get; set; }
            public DateTime? ExpireTime { get; set; }
            public DateTime? TransactTime { get; set; }
            public PriceType PriceType { get; set; }
            public decimal? Price { get; set; }
            public decimal? Price2 { get; set; }
            public Instrument Instrument { get; set; }
            public FinancingDetails? FinancingDetails { get; set; }
            public OrderQtyData? OrderQtyData { get; set; }
            public Stipulations? Stipulations { get; set; }
            public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
            public YieldData? YieldData { get; set; }
            public Parties? Parties { get; set; }
        }
    }

    public class QuoteResponse
    {
        public string QuoteRespID { get; set; }
        public string QuoteID { get; set; }
        public QuoteRespType QuoteRespType { get; set; }
        public string ClOrdID { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public string IOIid { get; set; }
        public QuoteType QuoteType { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Side Side { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public DateTime? SettlDate2 { get; set; }
        public int? OrderQty2 { get; set; }
        public string Currency { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public decimal? BidPx { get; set; }
        public decimal? OfferPx { get; set; }
        public decimal? MktBidPx { get; set; }
        public decimal? MktOfferPx { get; set; }
        public int? MinBidSize { get; set; }
        public int? BidSize { get; set; }
        public int? MinOfferSize { get; set; }
        public int? OfferSize { get; set; }
        public DateTime? ValidUntilTime { get; set; }
        public decimal? BidSpotRate { get; set; }
        public decimal? OfferSpotRate { get; set; }
        public decimal? BidForwardPoints { get; set; }
        public decimal? OfferForwardPoints { get; set; }
        public decimal? MidPx { get; set; }
        public decimal? BidYield { get; set; }
        public decimal? MidYield { get; set; }
        public decimal? OfferYield { get; set; }
        public DateTime? TransactTime { get; set; }
        public OrdType OrdType { get; set; }
        public decimal? BidForwardPoints2 { get; set; }
        public decimal? OfferForwardPoints2 { get; set; }
        public decimal? SettlCurrBidFxRate { get; set; }
        public decimal? SettlCurrOfferFxRate { get; set; }
        public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
        public decimal? Commission { get; set; }
        public CommType CommType { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public string ExDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData? OrderQtyData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public NoQuoteQualifiersItem[] NoQuoteQualifiers { get; set; }

        public struct NoQuoteQualifiersItem
        {
            public char? QuoteQualifier { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public int? LegPriceType { get; set; }
            public decimal? LegBidPx { get; set; }
            public decimal? LegOfferPx { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
            public LegBenchmarkCurveData? LegBenchmarkCurveData { get; set; }
        }
    }

    public class QuoteRequestReject
    {
        public string QuoteReqID { get; set; }
        public string RFQReqID { get; set; }
        public QuoteRequestRejectReason QuoteRequestRejectReason { get; set; }
        public QuotePriceType QuotePriceType { get; set; }
        public OrdType OrdType { get; set; }
        public DateTime? ExpireTime { get; set; }
        public DateTime? TransactTime { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? Price2 { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public Parties? Parties { get; set; }
        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public decimal? PrevClosePx { get; set; }
            public QuoteRequestType QuoteRequestType { get; set; }
            public QuoteType QuoteType { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public DateTime? TradeOriginationDate { get; set; }
            public Side Side { get; set; }
            public QtyType QtyType { get; set; }
            public SettlType SettlType { get; set; }
            public DateTime? SettlDate { get; set; }
            public DateTime? SettlDate2 { get; set; }
            public int? OrderQty2 { get; set; }
            public string Currency { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
            public AccountType AccountType { get; set; }
            public Instrument Instrument { get; set; }
            public FinancingDetails? FinancingDetails { get; set; }
            public OrderQtyData? OrderQtyData { get; set; }
            public Stipulations? Stipulations { get; set; }
        }

        public NoQuoteQualifiersItem[] NoQuoteQualifiers { get; set; }

        public struct NoQuoteQualifiersItem
        {
            public char? QuoteQualifier { get; set; }
        }
    }

    public class RFQRequest
    {
        public string RFQReqID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public decimal? PrevClosePx { get; set; }
            public QuoteRequestType QuoteRequestType { get; set; }
            public QuoteType QuoteType { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public Instrument Instrument { get; set; }
        }
    }

    public class Quote
    {
        public string QuoteReqID { get; set; }
        public string QuoteID { get; set; }
        public string QuoteRespID { get; set; }
        public QuoteType QuoteType { get; set; }
        public QuoteResponseLevel QuoteResponseLevel { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Side Side { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public DateTime? SettlDate2 { get; set; }
        public int? OrderQty2 { get; set; }
        public string Currency { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public decimal? BidPx { get; set; }
        public decimal? OfferPx { get; set; }
        public decimal? MktBidPx { get; set; }
        public decimal? MktOfferPx { get; set; }
        public int? MinBidSize { get; set; }
        public int? BidSize { get; set; }
        public int? MinOfferSize { get; set; }
        public int? OfferSize { get; set; }
        public DateTime? ValidUntilTime { get; set; }
        public decimal? BidSpotRate { get; set; }
        public decimal? OfferSpotRate { get; set; }
        public decimal? BidForwardPoints { get; set; }
        public decimal? OfferForwardPoints { get; set; }
        public decimal? MidPx { get; set; }
        public decimal? BidYield { get; set; }
        public decimal? MidYield { get; set; }
        public decimal? OfferYield { get; set; }
        public DateTime? TransactTime { get; set; }
        public OrdType OrdType { get; set; }
        public decimal? BidForwardPoints2 { get; set; }
        public decimal? OfferForwardPoints2 { get; set; }
        public decimal? SettlCurrBidFxRate { get; set; }
        public decimal? SettlCurrOfferFxRate { get; set; }
        public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
        public CommType CommType { get; set; }
        public decimal? Commission { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public string ExDestination { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public PriceType PriceType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData? OrderQtyData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public NoQuoteQualifiersItem[] NoQuoteQualifiers { get; set; }

        public struct NoQuoteQualifiersItem
        {
            public char? QuoteQualifier { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public int? LegPriceType { get; set; }
            public decimal? LegBidPx { get; set; }
            public decimal? LegOfferPx { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
            public LegBenchmarkCurveData? LegBenchmarkCurveData { get; set; }
        }
    }

    public class QuoteCancel
    {
        public string QuoteReqID { get; set; }
        public string QuoteID { get; set; }
        public QuoteCancelType QuoteCancelType { get; set; }
        public QuoteResponseLevel QuoteResponseLevel { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Parties? Parties { get; set; }
        public NoQuoteEntriesItem[] NoQuoteEntries { get; set; }

        public struct NoQuoteEntriesItem
        {
            public Instrument? Instrument { get; set; }
            public FinancingDetails? FinancingDetails { get; set; }
        }
    }

    public class QuoteStatusRequest
    {
        public string QuoteStatusReqID { get; set; }
        public string QuoteID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public Parties? Parties { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class QuoteStatusReport
    {
        public string QuoteStatusReqID { get; set; }
        public string QuoteReqID { get; set; }
        public string QuoteID { get; set; }
        public string QuoteRespID { get; set; }
        public QuoteType QuoteType { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Side Side { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public DateTime? SettlDate2 { get; set; }
        public int? OrderQty2 { get; set; }
        public string Currency { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime? ExpireTime { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? BidPx { get; set; }
        public decimal? OfferPx { get; set; }
        public decimal? MktBidPx { get; set; }
        public decimal? MktOfferPx { get; set; }
        public int? MinBidSize { get; set; }
        public int? BidSize { get; set; }
        public int? MinOfferSize { get; set; }
        public int? OfferSize { get; set; }
        public DateTime? ValidUntilTime { get; set; }
        public decimal? BidSpotRate { get; set; }
        public decimal? OfferSpotRate { get; set; }
        public decimal? BidForwardPoints { get; set; }
        public decimal? OfferForwardPoints { get; set; }
        public decimal? MidPx { get; set; }
        public decimal? BidYield { get; set; }
        public decimal? MidYield { get; set; }
        public decimal? OfferYield { get; set; }
        public DateTime? TransactTime { get; set; }
        public OrdType OrdType { get; set; }
        public decimal? BidForwardPoints2 { get; set; }
        public decimal? OfferForwardPoints2 { get; set; }
        public decimal? SettlCurrBidFxRate { get; set; }
        public decimal? SettlCurrOfferFxRate { get; set; }
        public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
        public CommType CommType { get; set; }
        public decimal? Commission { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public string ExDestination { get; set; }
        public QuoteStatus QuoteStatus { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData? OrderQtyData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoQuoteQualifiersItem[] NoQuoteQualifiers { get; set; }

        public struct NoQuoteQualifiersItem
        {
            public char? QuoteQualifier { get; set; }
        }
    }

    public class MassQuote
    {
        public string QuoteReqID { get; set; }
        public string QuoteID { get; set; }
        public QuoteType QuoteType { get; set; }
        public QuoteResponseLevel QuoteResponseLevel { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public int? DefBidSize { get; set; }
        public int? DefOfferSize { get; set; }
        public Parties? Parties { get; set; }
        public NoQuoteSetsItem[] NoQuoteSets { get; set; }

        public struct NoQuoteSetsItem
        {
            public string QuoteSetID { get; set; }
            public DateTime? QuoteSetValidUntilTime { get; set; }
            public int TotNoQuoteEntries { get; set; }
            public bool? LastFragment { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class MassQuoteAcknowledgement
    {
        public string QuoteReqID { get; set; }
        public string QuoteID { get; set; }
        public QuoteStatus QuoteStatus { get; set; }
        public QuoteRejectReason QuoteRejectReason { get; set; }
        public QuoteResponseLevel QuoteResponseLevel { get; set; }
        public QuoteType QuoteType { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public NoQuoteSetsItem[] NoQuoteSets { get; set; }

        public struct NoQuoteSetsItem
        {
            public string QuoteSetID { get; set; }
            public int? TotNoQuoteEntries { get; set; }
            public bool? LastFragment { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class MarketDataRequest
    {
        public string MDReqID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public int MarketDepth { get; set; }
        public MDUpdateType MDUpdateType { get; set; }
        public bool? AggregatedBook { get; set; }
        public OpenCloseSettlFlag OpenCloseSettlFlag { get; set; }
        public Scope Scope { get; set; }
        public bool? MDImplicitDelete { get; set; }
        public ApplQueueAction ApplQueueAction { get; set; }
        public int? ApplQueueMax { get; set; }
        public NoMDEntryTypesItem[] NoMDEntryTypes { get; set; }

        public struct NoMDEntryTypesItem
        {
            public MDEntryType MDEntryType { get; set; }
        }

        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public Instrument Instrument { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }
    }

    public class MarketDataSnapshotFullRefresh
    {
        public string MDReqID { get; set; }
        public FinancialStatus FinancialStatus { get; set; }
        public CorporateAction CorporateAction { get; set; }
        public decimal? NetChgPrevDay { get; set; }
        public int? ApplQueueDepth { get; set; }
        public ApplQueueResolution ApplQueueResolution { get; set; }
        public Instrument Instrument { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoMDEntriesItem[] NoMDEntries { get; set; }

        public struct NoMDEntriesItem
        {
            public MDEntryType MDEntryType { get; set; }
            public decimal? MDEntryPx { get; set; }
            public string Currency { get; set; }
            public int? MDEntrySize { get; set; }
            public DateTime? MDEntryDate { get; set; }
            public DateTime? MDEntryTime { get; set; }
            public TickDirection TickDirection { get; set; }
            public string MDMkt { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public QuoteCondition QuoteCondition { get; set; }
            public TradeCondition TradeCondition { get; set; }
            public string MDEntryOriginator { get; set; }
            public string LocationID { get; set; }
            public string DeskID { get; set; }
            public OpenCloseSettlFlag OpenCloseSettlFlag { get; set; }
            public TimeInForce TimeInForce { get; set; }
            public DateTime? ExpireDate { get; set; }
            public DateTime? ExpireTime { get; set; }
            public int? MinQty { get; set; }
            public ExecInst ExecInst { get; set; }
            public int? SellerDays { get; set; }
            public string OrderID { get; set; }
            public string QuoteEntryID { get; set; }
            public string MDEntryBuyer { get; set; }
            public string MDEntrySeller { get; set; }
            public int? NumberOfOrders { get; set; }
            public int? MDEntryPositionNo { get; set; }
            public Scope Scope { get; set; }
            public decimal? PriceDelta { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
        }
    }

    public class MarketDataIncrementalRefresh
    {
        public string MDReqID { get; set; }
        public int? ApplQueueDepth { get; set; }
        public ApplQueueResolution ApplQueueResolution { get; set; }
        public NoMDEntriesItem[] NoMDEntries { get; set; }

        public struct NoMDEntriesItem
        {
            public MDUpdateAction MDUpdateAction { get; set; }
            public DeleteReason DeleteReason { get; set; }
            public MDEntryType MDEntryType { get; set; }
            public string MDEntryID { get; set; }
            public string MDEntryRefID { get; set; }
            public FinancialStatus FinancialStatus { get; set; }
            public CorporateAction CorporateAction { get; set; }
            public decimal? MDEntryPx { get; set; }
            public string Currency { get; set; }
            public int? MDEntrySize { get; set; }
            public DateTime? MDEntryDate { get; set; }
            public DateTime? MDEntryTime { get; set; }
            public TickDirection TickDirection { get; set; }
            public string MDMkt { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public QuoteCondition QuoteCondition { get; set; }
            public TradeCondition TradeCondition { get; set; }
            public string MDEntryOriginator { get; set; }
            public string LocationID { get; set; }
            public string DeskID { get; set; }
            public OpenCloseSettlFlag OpenCloseSettlFlag { get; set; }
            public TimeInForce TimeInForce { get; set; }
            public DateTime? ExpireDate { get; set; }
            public DateTime? ExpireTime { get; set; }
            public int? MinQty { get; set; }
            public ExecInst ExecInst { get; set; }
            public int? SellerDays { get; set; }
            public string OrderID { get; set; }
            public string QuoteEntryID { get; set; }
            public string MDEntryBuyer { get; set; }
            public string MDEntrySeller { get; set; }
            public int? NumberOfOrders { get; set; }
            public int? MDEntryPositionNo { get; set; }
            public Scope Scope { get; set; }
            public decimal? PriceDelta { get; set; }
            public decimal? NetChgPrevDay { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public Instrument? Instrument { get; set; }
        }
    }

    public class MarketDataRequestReject
    {
        public string MDReqID { get; set; }
        public MDReqRejReason MDReqRejReason { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public NoAltMDSourceItem[] NoAltMDSource { get; set; }

        public struct NoAltMDSourceItem
        {
            public string AltMDSourceID { get; set; }
        }
    }

    public class SecurityDefinitionRequest
    {
        public string SecurityReqID { get; set; }
        public SecurityRequestType SecurityRequestType { get; set; }
        public string Currency { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public ExpirationCycle ExpirationCycle { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public Instrument? Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class SecurityDefinition
    {
        public string SecurityReqID { get; set; }
        public string SecurityResponseID { get; set; }
        public SecurityResponseType SecurityResponseType { get; set; }
        public string Currency { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public ExpirationCycle ExpirationCycle { get; set; }
        public int? RoundLot { get; set; }
        public int? MinTradeVol { get; set; }
        public Instrument? Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class SecurityTypeRequest
    {
        public string SecurityReqID { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Product Product { get; set; }
        public SecurityType SecurityType { get; set; }
        public string SecuritySubType { get; set; }
    }

    public class SecurityTypes
    {
        public string SecurityReqID { get; set; }
        public string SecurityResponseID { get; set; }
        public SecurityResponseType SecurityResponseType { get; set; }
        public int? TotNoSecurityTypes { get; set; }
        public bool? LastFragment { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public NoSecurityTypesItem[] NoSecurityTypes { get; set; }

        public struct NoSecurityTypesItem
        {
            public SecurityType SecurityType { get; set; }
            public string SecuritySubType { get; set; }
            public Product Product { get; set; }
            public string CFICode { get; set; }
        }
    }

    public class SecurityListRequest
    {
        public string SecurityReqID { get; set; }
        public SecurityListRequestType SecurityListRequestType { get; set; }
        public string Currency { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public Instrument? Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class SecurityList
    {
        public string SecurityReqID { get; set; }
        public string SecurityResponseID { get; set; }
        public SecurityRequestResult SecurityRequestResult { get; set; }
        public int? TotNoRelatedSym { get; set; }
        public bool? LastFragment { get; set; }
        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public string Currency { get; set; }
            public int? RoundLot { get; set; }
            public int? MinTradeVol { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public ExpirationCycle ExpirationCycle { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public Instrument? Instrument { get; set; }
            public InstrumentExtension? InstrumentExtension { get; set; }
            public FinancingDetails? FinancingDetails { get; set; }
            public Stipulations? Stipulations { get; set; }
            public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
            public YieldData? YieldData { get; set; }
        }
    }

    public class DerivativeSecurityListRequest
    {
        public string SecurityReqID { get; set; }
        public SecurityListRequestType SecurityListRequestType { get; set; }
        public string SecuritySubType { get; set; }
        public string Currency { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public UnderlyingInstrument? UnderlyingInstrument { get; set; }
    }

    public class DerivativeSecurityList
    {
        public string SecurityReqID { get; set; }
        public string SecurityResponseID { get; set; }
        public SecurityRequestResult SecurityRequestResult { get; set; }
        public int? TotNoRelatedSym { get; set; }
        public bool? LastFragment { get; set; }
        public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        public NoRelatedSymItem[] NoRelatedSym { get; set; }

        public struct NoRelatedSymItem
        {
            public string Currency { get; set; }
            public ExpirationCycle ExpirationCycle { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public Instrument? Instrument { get; set; }
            public InstrumentExtension? InstrumentExtension { get; set; }
        }
    }

    public class SecurityStatusRequest
    {
        public string SecurityStatusReqID { get; set; }
        public string Currency { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Instrument Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class SecurityStatus
    {
        public string SecurityStatusReqID { get; set; }
        public string Currency { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public bool? UnsolicitedIndicator { get; set; }
        public SecurityTradingStatus SecurityTradingStatus { get; set; }
        public FinancialStatus FinancialStatus { get; set; }
        public CorporateAction CorporateAction { get; set; }
        public HaltReason HaltReason { get; set; }
        public bool? InViewOfCommon { get; set; }
        public bool? DueToRelated { get; set; }
        public int? BuyVolume { get; set; }
        public int? SellVolume { get; set; }
        public decimal? HighPx { get; set; }
        public decimal? LowPx { get; set; }
        public decimal? LastPx { get; set; }
        public DateTime? TransactTime { get; set; }
        public Adjustment Adjustment { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Instrument Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class TradingSessionStatusRequest
    {
        public string TradSesReqID { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public TradSesMethod TradSesMethod { get; set; }
        public TradSesMode TradSesMode { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
    }

    public class TradingSessionStatus
    {
        public string TradSesReqID { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public TradSesMethod TradSesMethod { get; set; }
        public TradSesMode TradSesMode { get; set; }
        public bool? UnsolicitedIndicator { get; set; }
        public TradSesStatus TradSesStatus { get; set; }
        public TradSesStatusRejReason TradSesStatusRejReason { get; set; }
        public DateTime? TradSesStartTime { get; set; }
        public DateTime? TradSesOpenTime { get; set; }
        public DateTime? TradSesPreCloseTime { get; set; }
        public DateTime? TradSesCloseTime { get; set; }
        public DateTime? TradSesEndTime { get; set; }
        public int? TotalVolumeTraded { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class NewOrderSingle
    {
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DayBookingInst DayBookingInst { get; set; }
        public BookingUnit BookingUnit { get; set; }
        public PreallocMethod PreallocMethod { get; set; }
        public string AllocID { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public CashMargin CashMargin { get; set; }
        public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
        public HandlInst HandlInst { get; set; }
        public ExecInst ExecInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public string ExDestination { get; set; }
        public ProcessCode ProcessCode { get; set; }
        public decimal? PrevClosePx { get; set; }
        public Side Side { get; set; }
        public bool? LocateReqd { get; set; }
        public DateTime TransactTime { get; set; }
        public QtyType QtyType { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public string Currency { get; set; }
        public string ComplianceID { get; set; }
        public bool? SolicitedFlag { get; set; }
        public string IOIid { get; set; }
        public string QuoteID { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public OrderRestrictions OrderRestrictions { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public bool? ForexReq { get; set; }
        public string SettlCurrency { get; set; }
        public BookingType BookingType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public DateTime? SettlDate2 { get; set; }
        public int? OrderQty2 { get; set; }
        public decimal? Price2 { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public CoveredOrUncovered CoveredOrUncovered { get; set; }
        public int? MaxShow { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public Stipulations? Stipulations { get; set; }
        public OrderQtyData OrderQtyData { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public CommissionData? CommissionData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public string AllocSettlCurrency { get; set; }
            public string IndividualAllocID { get; set; }
            public int? AllocQty { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class ExecutionReport
    {
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string SecondaryExecID { get; set; }
        public string ClOrdID { get; set; }
        public string OrigClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public string QuoteRespID { get; set; }
        public string OrdStatusReqID { get; set; }
        public string MassStatusReqID { get; set; }
        public int? TotNumReports { get; set; }
        public bool? LastRptRequested { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public string ListID { get; set; }
        public string CrossID { get; set; }
        public string OrigCrossID { get; set; }
        public CrossType CrossType { get; set; }
        public string ExecID { get; set; }
        public string ExecRefID { get; set; }
        public ExecType ExecType { get; set; }
        public OrdStatus OrdStatus { get; set; }
        public bool? WorkingIndicator { get; set; }
        public OrdRejReason OrdRejReason { get; set; }
        public ExecRestatementReason ExecRestatementReason { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DayBookingInst DayBookingInst { get; set; }
        public BookingUnit BookingUnit { get; set; }
        public PreallocMethod PreallocMethod { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public CashMargin CashMargin { get; set; }
        public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
        public Side Side { get; set; }
        public QtyType QtyType { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public decimal? PeggedPrice { get; set; }
        public decimal? DiscretionPrice { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public decimal? TargetStrategyPerformance { get; set; }
        public string Currency { get; set; }
        public string ComplianceID { get; set; }
        public bool? SolicitedFlag { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public ExecInst ExecInst { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public OrderRestrictions OrderRestrictions { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public int? LastQty { get; set; }
        public int? UnderlyingLastQty { get; set; }
        public decimal? LastPx { get; set; }
        public decimal? UnderlyingLastPx { get; set; }
        public decimal? LastParPx { get; set; }
        public decimal? LastSpotRate { get; set; }
        public decimal? LastForwardPoints { get; set; }
        public string LastMkt { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string TimeBracket { get; set; }
        public LastCapacity LastCapacity { get; set; }
        public int LeavesQty { get; set; }
        public int CumQty { get; set; }
        public decimal AvgPx { get; set; }
        public int? DayOrderQty { get; set; }
        public int? DayCumQty { get; set; }
        public decimal? DayAvgPx { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public DateTime? TradeDate { get; set; }
        public DateTime? TransactTime { get; set; }
        public bool? ReportToExch { get; set; }
        public decimal? GrossTradeAmt { get; set; }
        public int? NumDaysInterest { get; set; }
        public DateTime? ExDate { get; set; }
        public decimal? AccruedInterestRate { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? InterestAtMaturity { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public bool? TradedFlatSwitch { get; set; }
        public DateTime? BasisFeatureDate { get; set; }
        public decimal? BasisFeaturePrice { get; set; }
        public decimal? Concession { get; set; }
        public decimal? TotalTakedown { get; set; }
        public decimal? NetMoney { get; set; }
        public decimal? SettlCurrAmt { get; set; }
        public string SettlCurrency { get; set; }
        public decimal? SettlCurrFxRate { get; set; }
        public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
        public HandlInst HandlInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public int? MaxShow { get; set; }
        public BookingType BookingType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public DateTime? SettlDate2 { get; set; }
        public int? OrderQty2 { get; set; }
        public decimal? LastForwardPoints2 { get; set; }
        public MultiLegReportingType MultiLegReportingType { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public DateTime? TransBkdTime { get; set; }
        public DateTime? ExecValuationPoint { get; set; }
        public ExecPriceType ExecPriceType { get; set; }
        public decimal? ExecPriceAdjustment { get; set; }
        public PriorityIndicator PriorityIndicator { get; set; }
        public decimal? PriceImprovement { get; set; }
        public LastLiquidityInd LastLiquidityInd { get; set; }
        public bool? CopyMsgIndicator { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public Stipulations? Stipulations { get; set; }
        public OrderQtyData? OrderQtyData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public CommissionData? CommissionData { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public NoContraBrokersItem[] NoContraBrokers { get; set; }

        public struct NoContraBrokersItem
        {
            public string ContraBroker { get; set; }
            public string ContraTrader { get; set; }
            public int? ContraTradeQty { get; set; }
            public DateTime? ContraTradeTime { get; set; }
            public string ContraLegRefID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoContAmtsItem[] NoContAmts { get; set; }

        public struct NoContAmtsItem
        {
            public ContAmtType ContAmtType { get; set; }
            public decimal? ContAmtValue { get; set; }
            public string ContAmtCurr { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegPositionEffect { get; set; }
            public int? LegCoveredOrUncovered { get; set; }
            public string LegRefID { get; set; }
            public decimal? LegPrice { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public decimal? LegLastPx { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoMiscFeesItem[] NoMiscFees { get; set; }

        public struct NoMiscFeesItem
        {
            public decimal? MiscFeeAmt { get; set; }
            public string MiscFeeCurr { get; set; }
            public MiscFeeType MiscFeeType { get; set; }
            public MiscFeeBasis MiscFeeBasis { get; set; }
        }
    }

    public class DontKnowTrade
    {
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string ExecID { get; set; }
        public DKReason DKReason { get; set; }
        public Side Side { get; set; }
        public int? LastQty { get; set; }
        public decimal? LastPx { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Instrument Instrument { get; set; }
        public OrderQtyData OrderQtyData { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class OrderCancelReplaceRequest
    {
        public string OrderID { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public string OrigClOrdID { get; set; }
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public string ListID { get; set; }
        public DateTime? OrigOrdModTime { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DayBookingInst DayBookingInst { get; set; }
        public BookingUnit BookingUnit { get; set; }
        public PreallocMethod PreallocMethod { get; set; }
        public string AllocID { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public CashMargin CashMargin { get; set; }
        public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
        public HandlInst HandlInst { get; set; }
        public ExecInst ExecInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public string ExDestination { get; set; }
        public Side Side { get; set; }
        public DateTime TransactTime { get; set; }
        public QtyType QtyType { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public string ComplianceID { get; set; }
        public bool? SolicitedFlag { get; set; }
        public string Currency { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public OrderRestrictions OrderRestrictions { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public bool? ForexReq { get; set; }
        public string SettlCurrency { get; set; }
        public BookingType BookingType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public DateTime? SettlDate2 { get; set; }
        public int? OrderQty2 { get; set; }
        public decimal? Price2 { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public CoveredOrUncovered CoveredOrUncovered { get; set; }
        public int? MaxShow { get; set; }
        public bool? LocateReqd { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData OrderQtyData { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public CommissionData? CommissionData { get; set; }
        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public string AllocSettlCurrency { get; set; }
            public string IndividualAllocID { get; set; }
            public int? AllocQty { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class OrderCancelRequest
    {
        public string OrigClOrdID { get; set; }
        public string OrderID { get; set; }
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public string ListID { get; set; }
        public DateTime? OrigOrdModTime { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public Side Side { get; set; }
        public DateTime TransactTime { get; set; }
        public string ComplianceID { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData OrderQtyData { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class OrderCancelReject
    {
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public string OrigClOrdID { get; set; }
        public OrdStatus OrdStatus { get; set; }
        public bool? WorkingIndicator { get; set; }
        public DateTime? OrigOrdModTime { get; set; }
        public string ListID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public DateTime? TransactTime { get; set; }
        public CxlRejResponseTo CxlRejResponseTo { get; set; }
        public CxlRejReason CxlRejReason { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class OrderStatusRequest
    {
        public string OrderID { get; set; }
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public string OrdStatusReqID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public Side Side { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class OrderMassCancelRequest
    {
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public MassCancelRequestType MassCancelRequestType { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Side Side { get; set; }
        public DateTime TransactTime { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Instrument? Instrument { get; set; }
        public UnderlyingInstrument? UnderlyingInstrument { get; set; }
    }

    public class OrderMassCancelReport
    {
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public MassCancelRequestType MassCancelRequestType { get; set; }
        public MassCancelResponse MassCancelResponse { get; set; }
        public MassCancelRejectReason MassCancelRejectReason { get; set; }
        public int? TotalAffectedOrders { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Side Side { get; set; }
        public DateTime? TransactTime { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Instrument? Instrument { get; set; }
        public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        public NoAffectedOrdersItem[] NoAffectedOrders { get; set; }

        public struct NoAffectedOrdersItem
        {
            public string OrigClOrdID { get; set; }
            public string AffectedOrderID { get; set; }
            public string AffectedSecondaryOrderID { get; set; }
        }
    }

    public class OrderMassStatusRequest
    {
        public string MassStatusReqID { get; set; }
        public MassStatusReqType MassStatusReqType { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public Side Side { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public UnderlyingInstrument? UnderlyingInstrument { get; set; }
    }

    public class NewOrderCross
    {
        public string CrossID { get; set; }
        public CrossType CrossType { get; set; }
        public CrossPrioritization CrossPrioritization { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public HandlInst HandlInst { get; set; }
        public ExecInst ExecInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public string ExDestination { get; set; }
        public ProcessCode ProcessCode { get; set; }
        public decimal? PrevClosePx { get; set; }
        public bool? LocateReqd { get; set; }
        public DateTime TransactTime { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public string Currency { get; set; }
        public string ComplianceID { get; set; }
        public string IOIid { get; set; }
        public string QuoteID { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public int? MaxShow { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public Instrument Instrument { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public NoSidesItem[] NoSides { get; set; }

        public struct NoSidesItem
        {
            public Side Side { get; set; }
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ClOrdLinkID { get; set; }
            public DateTime? TradeOriginationDate { get; set; }
            public DateTime? TradeDate { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
            public AccountType AccountType { get; set; }
            public DayBookingInst DayBookingInst { get; set; }
            public BookingUnit BookingUnit { get; set; }
            public PreallocMethod PreallocMethod { get; set; }
            public string AllocID { get; set; }
            public QtyType QtyType { get; set; }
            public OrderCapacity OrderCapacity { get; set; }
            public OrderRestrictions OrderRestrictions { get; set; }
            public CustOrderCapacity CustOrderCapacity { get; set; }
            public bool? ForexReq { get; set; }
            public string SettlCurrency { get; set; }
            public BookingType BookingType { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public PositionEffect PositionEffect { get; set; }
            public CoveredOrUncovered CoveredOrUncovered { get; set; }
            public CashMargin CashMargin { get; set; }
            public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
            public bool? SolicitedFlag { get; set; }
            public string SideComplianceID { get; set; }
            public Parties? Parties { get; set; }
            public OrderQtyData OrderQtyData { get; set; }
            public CommissionData? CommissionData { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }
    }

    public class CrossOrderCancelReplaceRequest
    {
        public string OrderID { get; set; }
        public string CrossID { get; set; }
        public string OrigCrossID { get; set; }
        public CrossType CrossType { get; set; }
        public CrossPrioritization CrossPrioritization { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public HandlInst HandlInst { get; set; }
        public ExecInst ExecInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public string ExDestination { get; set; }
        public ProcessCode ProcessCode { get; set; }
        public decimal? PrevClosePx { get; set; }
        public bool? LocateReqd { get; set; }
        public DateTime TransactTime { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public string Currency { get; set; }
        public string ComplianceID { get; set; }
        public string IOIid { get; set; }
        public string QuoteID { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public int? MaxShow { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public Instrument Instrument { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public YieldData? YieldData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public NoSidesItem[] NoSides { get; set; }

        public struct NoSidesItem
        {
            public Side Side { get; set; }
            public string OrigClOrdID { get; set; }
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ClOrdLinkID { get; set; }
            public DateTime? OrigOrdModTime { get; set; }
            public DateTime? TradeOriginationDate { get; set; }
            public DateTime? TradeDate { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
            public AccountType AccountType { get; set; }
            public DayBookingInst DayBookingInst { get; set; }
            public BookingUnit BookingUnit { get; set; }
            public PreallocMethod PreallocMethod { get; set; }
            public string AllocID { get; set; }
            public QtyType QtyType { get; set; }
            public OrderCapacity OrderCapacity { get; set; }
            public OrderRestrictions OrderRestrictions { get; set; }
            public CustOrderCapacity CustOrderCapacity { get; set; }
            public bool? ForexReq { get; set; }
            public string SettlCurrency { get; set; }
            public BookingType BookingType { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public PositionEffect PositionEffect { get; set; }
            public CoveredOrUncovered CoveredOrUncovered { get; set; }
            public CashMargin CashMargin { get; set; }
            public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
            public bool? SolicitedFlag { get; set; }
            public string SideComplianceID { get; set; }
            public Parties? Parties { get; set; }
            public OrderQtyData OrderQtyData { get; set; }
            public CommissionData? CommissionData { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }
    }

    public class CrossOrderCancelRequest
    {
        public string OrderID { get; set; }
        public string CrossID { get; set; }
        public string OrigCrossID { get; set; }
        public CrossType CrossType { get; set; }
        public CrossPrioritization CrossPrioritization { get; set; }
        public DateTime TransactTime { get; set; }
        public Instrument Instrument { get; set; }
        public NoSidesItem[] NoSides { get; set; }

        public struct NoSidesItem
        {
            public Side Side { get; set; }
            public string OrigClOrdID { get; set; }
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ClOrdLinkID { get; set; }
            public DateTime? OrigOrdModTime { get; set; }
            public DateTime? TradeOriginationDate { get; set; }
            public DateTime? TradeDate { get; set; }
            public string ComplianceID { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public Parties? Parties { get; set; }
            public OrderQtyData OrderQtyData { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class NewOrderMultileg
    {
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DayBookingInst DayBookingInst { get; set; }
        public BookingUnit BookingUnit { get; set; }
        public PreallocMethod PreallocMethod { get; set; }
        public string AllocID { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public CashMargin CashMargin { get; set; }
        public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
        public HandlInst HandlInst { get; set; }
        public ExecInst ExecInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public string ExDestination { get; set; }
        public ProcessCode ProcessCode { get; set; }
        public Side Side { get; set; }
        public decimal? PrevClosePx { get; set; }
        public bool? LocateReqd { get; set; }
        public DateTime TransactTime { get; set; }
        public QtyType QtyType { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public string Currency { get; set; }
        public string ComplianceID { get; set; }
        public bool? SolicitedFlag { get; set; }
        public string IOIid { get; set; }
        public string QuoteID { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public OrderRestrictions OrderRestrictions { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public bool? ForexReq { get; set; }
        public string SettlCurrency { get; set; }
        public BookingType BookingType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public CoveredOrUncovered CoveredOrUncovered { get; set; }
        public int? MaxShow { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public MultiLegRptTypeReq MultiLegRptTypeReq { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public OrderQtyData OrderQtyData { get; set; }
        public CommissionData? CommissionData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public string AllocSettlCurrency { get; set; }
            public string IndividualAllocID { get; set; }
            public int? AllocQty { get; set; }
            public NestedParties3? NestedParties3 { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegPositionEffect { get; set; }
            public int? LegCoveredOrUncovered { get; set; }
            public string LegRefID { get; set; }
            public decimal? LegPrice { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
        }
    }

    public class MultilegOrderCancelReplaceRequest
    {
        public string OrderID { get; set; }
        public string OrigClOrdID { get; set; }
        public string ClOrdID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public string ClOrdLinkID { get; set; }
        public DateTime? OrigOrdModTime { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public DayBookingInst DayBookingInst { get; set; }
        public BookingUnit BookingUnit { get; set; }
        public PreallocMethod PreallocMethod { get; set; }
        public string AllocID { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public CashMargin CashMargin { get; set; }
        public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
        public HandlInst HandlInst { get; set; }
        public ExecInst ExecInst { get; set; }
        public int? MinQty { get; set; }
        public int? MaxFloor { get; set; }
        public string ExDestination { get; set; }
        public ProcessCode ProcessCode { get; set; }
        public Side Side { get; set; }
        public decimal? PrevClosePx { get; set; }
        public bool? LocateReqd { get; set; }
        public DateTime TransactTime { get; set; }
        public QtyType QtyType { get; set; }
        public OrdType OrdType { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? Price { get; set; }
        public decimal? StopPx { get; set; }
        public string Currency { get; set; }
        public string ComplianceID { get; set; }
        public bool? SolicitedFlag { get; set; }
        public string IOIid { get; set; }
        public string QuoteID { get; set; }
        public TimeInForce TimeInForce { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireDate { get; set; }
        public DateTime? ExpireTime { get; set; }
        public GTBookingInst GTBookingInst { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public OrderRestrictions OrderRestrictions { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public bool? ForexReq { get; set; }
        public string SettlCurrency { get; set; }
        public BookingType BookingType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public CoveredOrUncovered CoveredOrUncovered { get; set; }
        public int? MaxShow { get; set; }
        public int? TargetStrategy { get; set; }
        public string TargetStrategyParameters { get; set; }
        public decimal? ParticipationRate { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public string Designation { get; set; }
        public MultiLegRptTypeReq MultiLegRptTypeReq { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public OrderQtyData OrderQtyData { get; set; }
        public CommissionData? CommissionData { get; set; }
        public PegInstructions? PegInstructions { get; set; }
        public DiscretionInstructions? DiscretionInstructions { get; set; }
        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public string AllocSettlCurrency { get; set; }
            public string IndividualAllocID { get; set; }
            public int? AllocQty { get; set; }
            public NestedParties3? NestedParties3 { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegPositionEffect { get; set; }
            public int? LegCoveredOrUncovered { get; set; }
            public string LegRefID { get; set; }
            public decimal? LegPrice { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
        }
    }

    public class BidRequest
    {
        public string BidID { get; set; }
        public string ClientBidID { get; set; }
        public BidRequestTransType BidRequestTransType { get; set; }
        public string ListName { get; set; }
        public int TotNoRelatedSym { get; set; }
        public BidType BidType { get; set; }
        public int? NumTickets { get; set; }
        public string Currency { get; set; }
        public decimal? SideValue1 { get; set; }
        public decimal? SideValue2 { get; set; }
        public LiquidityIndType LiquidityIndType { get; set; }
        public decimal? WtAverageLiquidity { get; set; }
        public bool? ExchangeForPhysical { get; set; }
        public decimal? OutMainCntryUIndex { get; set; }
        public decimal? CrossPercent { get; set; }
        public ProgRptReqs ProgRptReqs { get; set; }
        public int? ProgPeriodInterval { get; set; }
        public IncTaxInd IncTaxInd { get; set; }
        public bool? ForexReq { get; set; }
        public int? NumBidders { get; set; }
        public DateTime? TradeDate { get; set; }
        public BidTradeType BidTradeType { get; set; }
        public BasisPxType BasisPxType { get; set; }
        public DateTime? StrikeTime { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public NoBidDescriptorsItem[] NoBidDescriptors { get; set; }

        public struct NoBidDescriptorsItem
        {
            public BidDescriptorType BidDescriptorType { get; set; }
            public string BidDescriptor { get; set; }
            public SideValueInd SideValueInd { get; set; }
            public decimal? LiquidityValue { get; set; }
            public int? LiquidityNumSecurities { get; set; }
            public decimal? LiquidityPctLow { get; set; }
            public decimal? LiquidityPctHigh { get; set; }
            public decimal? EFPTrackingError { get; set; }
            public decimal? FairValue { get; set; }
            public decimal? OutsideIndexPct { get; set; }
            public decimal? ValueOfFutures { get; set; }
        }

        public NoBidComponentsItem[] NoBidComponents { get; set; }

        public struct NoBidComponentsItem
        {
            public string ListID { get; set; }
            public Side Side { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public NetGrossInd NetGrossInd { get; set; }
            public SettlType SettlType { get; set; }
            public DateTime? SettlDate { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
        }
    }

    public class BidResponse
    {
        public string BidID { get; set; }
        public string ClientBidID { get; set; }
        public NoBidComponentsItem[] NoBidComponents { get; set; }

        public struct NoBidComponentsItem
        {
            public string ListID { get; set; }
            public string Country { get; set; }
            public Side Side { get; set; }
            public decimal? Price { get; set; }
            public PriceType PriceType { get; set; }
            public decimal? FairValue { get; set; }
            public NetGrossInd NetGrossInd { get; set; }
            public SettlType SettlType { get; set; }
            public DateTime? SettlDate { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public CommissionData CommissionData { get; set; }
        }
    }

    public class NewOrderList
    {
        public string ListID { get; set; }
        public string BidID { get; set; }
        public string ClientBidID { get; set; }
        public ProgRptReqs ProgRptReqs { get; set; }
        public BidType BidType { get; set; }
        public int? ProgPeriodInterval { get; set; }
        public CancellationRights CancellationRights { get; set; }
        public MoneyLaunderingStatus MoneyLaunderingStatus { get; set; }
        public string RegistID { get; set; }
        public ListExecInstType ListExecInstType { get; set; }
        public string ListExecInst { get; set; }
        public int? EncodedListExecInstLen { get; set; }
        public string EncodedListExecInst { get; set; }
        public decimal? AllowableOneSidednessPct { get; set; }
        public decimal? AllowableOneSidednessValue { get; set; }
        public string AllowableOneSidednessCurr { get; set; }
        public int TotNoOrders { get; set; }
        public bool? LastFragment { get; set; }
        public NoOrdersItem[] NoOrders { get; set; }

        public struct NoOrdersItem
        {
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public int ListSeqNo { get; set; }
            public string ClOrdLinkID { get; set; }
            public SettlInstMode SettlInstMode { get; set; }
            public DateTime? TradeOriginationDate { get; set; }
            public DateTime? TradeDate { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
            public AccountType AccountType { get; set; }
            public DayBookingInst DayBookingInst { get; set; }
            public BookingUnit BookingUnit { get; set; }
            public string AllocID { get; set; }
            public PreallocMethod PreallocMethod { get; set; }
            public SettlType SettlType { get; set; }
            public DateTime? SettlDate { get; set; }
            public CashMargin CashMargin { get; set; }
            public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
            public HandlInst HandlInst { get; set; }
            public ExecInst ExecInst { get; set; }
            public int? MinQty { get; set; }
            public int? MaxFloor { get; set; }
            public string ExDestination { get; set; }
            public ProcessCode ProcessCode { get; set; }
            public decimal? PrevClosePx { get; set; }
            public Side Side { get; set; }
            public SideValueInd SideValueInd { get; set; }
            public bool? LocateReqd { get; set; }
            public DateTime? TransactTime { get; set; }
            public QtyType QtyType { get; set; }
            public OrdType OrdType { get; set; }
            public PriceType PriceType { get; set; }
            public decimal? Price { get; set; }
            public decimal? StopPx { get; set; }
            public string Currency { get; set; }
            public string ComplianceID { get; set; }
            public bool? SolicitedFlag { get; set; }
            public string IOIid { get; set; }
            public string QuoteID { get; set; }
            public TimeInForce TimeInForce { get; set; }
            public DateTime? EffectiveTime { get; set; }
            public DateTime? ExpireDate { get; set; }
            public DateTime? ExpireTime { get; set; }
            public GTBookingInst GTBookingInst { get; set; }
            public OrderCapacity OrderCapacity { get; set; }
            public OrderRestrictions OrderRestrictions { get; set; }
            public CustOrderCapacity CustOrderCapacity { get; set; }
            public bool? ForexReq { get; set; }
            public string SettlCurrency { get; set; }
            public BookingType BookingType { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public DateTime? SettlDate2 { get; set; }
            public int? OrderQty2 { get; set; }
            public decimal? Price2 { get; set; }
            public PositionEffect PositionEffect { get; set; }
            public CoveredOrUncovered CoveredOrUncovered { get; set; }
            public int? MaxShow { get; set; }
            public int? TargetStrategy { get; set; }
            public string TargetStrategyParameters { get; set; }
            public decimal? ParticipationRate { get; set; }
            public string Designation { get; set; }
            public Parties? Parties { get; set; }
            public Instrument Instrument { get; set; }
            public Stipulations? Stipulations { get; set; }
            public OrderQtyData OrderQtyData { get; set; }
            public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
            public YieldData? YieldData { get; set; }
            public CommissionData? CommissionData { get; set; }
            public PegInstructions? PegInstructions { get; set; }
            public DiscretionInstructions? DiscretionInstructions { get; set; }
        }
    }

    public class ListStrikePrice
    {
        public string ListID { get; set; }
        public int TotNoStrikes { get; set; }
        public bool? LastFragment { get; set; }
        public NoStrikesItem[] NoStrikes { get; set; }

        public struct NoStrikesItem
        {
            public Instrument Instrument { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public decimal? PrevClosePx { get; set; }
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public Side Side { get; set; }
            public decimal Price { get; set; }
            public string Currency { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class ListStatus
    {
        public string ListID { get; set; }
        public ListStatusType ListStatusType { get; set; }
        public int NoRpts { get; set; }
        public ListOrderStatus ListOrderStatus { get; set; }
        public int RptSeq { get; set; }
        public string ListStatusText { get; set; }
        public int? EncodedListStatusTextLen { get; set; }
        public string EncodedListStatusText { get; set; }
        public DateTime? TransactTime { get; set; }
        public int TotNoOrders { get; set; }
        public bool? LastFragment { get; set; }
        public NoOrdersItem[] NoOrders { get; set; }

        public struct NoOrdersItem
        {
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public int CumQty { get; set; }
            public OrdStatus OrdStatus { get; set; }
            public bool? WorkingIndicator { get; set; }
            public int LeavesQty { get; set; }
            public int CxlQty { get; set; }
            public decimal AvgPx { get; set; }
            public OrdRejReason OrdRejReason { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
        }
    }

    public class ListExecute
    {
        public string ListID { get; set; }
        public string ClientBidID { get; set; }
        public string BidID { get; set; }
        public DateTime TransactTime { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class ListCancelRequest
    {
        public string ListID { get; set; }
        public DateTime TransactTime { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public DateTime? TradeDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class ListStatusRequest
    {
        public string ListID { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class AllocationInstruction
    {
        public string AllocID { get; set; }
        public AllocTransType AllocTransType { get; set; }
        public AllocType AllocType { get; set; }
        public string SecondaryAllocID { get; set; }
        public string RefAllocID { get; set; }
        public AllocCancReplaceReason AllocCancReplaceReason { get; set; }
        public AllocIntermedReqType AllocIntermedReqType { get; set; }
        public string AllocLinkID { get; set; }
        public AllocLinkType AllocLinkType { get; set; }
        public string BookingRefID { get; set; }
        public AllocNoOrdersType AllocNoOrdersType { get; set; }
        public bool? PreviouslyReported { get; set; }
        public bool? ReversalIndicator { get; set; }
        public string MatchType { get; set; }
        public Side Side { get; set; }
        public int Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string LastMkt { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public PriceType PriceType { get; set; }
        public decimal AvgPx { get; set; }
        public decimal? AvgParPx { get; set; }
        public string Currency { get; set; }
        public int? AvgPxPrecision { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime? TransactTime { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public BookingType BookingType { get; set; }
        public decimal? GrossTradeAmt { get; set; }
        public decimal? Concession { get; set; }
        public decimal? TotalTakedown { get; set; }
        public decimal? NetMoney { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public bool? AutoAcceptIndicator { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public int? NumDaysInterest { get; set; }
        public decimal? AccruedInterestRate { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? TotalAccruedInterestAmt { get; set; }
        public decimal? InterestAtMaturity { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public bool? LegalConfirm { get; set; }
        public int? TotNoAllocs { get; set; }
        public bool? LastFragment { get; set; }
        public Instrument Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Parties? Parties { get; set; }
        public Stipulations? Stipulations { get; set; }
        public YieldData? YieldData { get; set; }
        public NoOrdersItem[] NoOrders { get; set; }

        public struct NoOrdersItem
        {
            public string ClOrdID { get; set; }
            public string OrderID { get; set; }
            public string SecondaryOrderID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ListID { get; set; }
            public int? OrderQty { get; set; }
            public decimal? OrderAvgPx { get; set; }
            public int? OrderBookingQty { get; set; }
            public NestedParties2? NestedParties2 { get; set; }
        }

        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public int? LastQty { get; set; }
            public string ExecID { get; set; }
            public string SecondaryExecID { get; set; }
            public decimal? LastPx { get; set; }
            public decimal? LastParPx { get; set; }
            public LastCapacity LastCapacity { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public MatchStatus MatchStatus { get; set; }
            public decimal? AllocPrice { get; set; }
            public int? AllocQty { get; set; }
            public string IndividualAllocID { get; set; }
            public ProcessCode ProcessCode { get; set; }
            public bool? NotifyBrokerOfCredit { get; set; }
            public AllocHandlInst AllocHandlInst { get; set; }
            public string AllocText { get; set; }
            public int? EncodedAllocTextLen { get; set; }
            public string EncodedAllocText { get; set; }
            public decimal? AllocAvgPx { get; set; }
            public decimal? AllocNetMoney { get; set; }
            public decimal? SettlCurrAmt { get; set; }
            public decimal? AllocSettlCurrAmt { get; set; }
            public string SettlCurrency { get; set; }
            public string AllocSettlCurrency { get; set; }
            public decimal? SettlCurrFxRate { get; set; }
            public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
            public decimal? AccruedInterestAmt { get; set; }
            public decimal? AllocAccruedInterestAmt { get; set; }
            public decimal? AllocInterestAtMaturity { get; set; }
            public SettlInstMode SettlInstMode { get; set; }
            public int? NoClearingInstructions { get; set; }
            public ClearingInstruction ClearingInstruction { get; set; }
            public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
            public AllocSettlInstType AllocSettlInstType { get; set; }
            public NestedParties? NestedParties { get; set; }
            public CommissionData? CommissionData { get; set; }
            public SettlInstructionsData? SettlInstructionsData { get; set; }
        }
    }

    public class AllocationInstructionAck
    {
        public string AllocID { get; set; }
        public string SecondaryAllocID { get; set; }
        public DateTime? TradeDate { get; set; }
        public DateTime TransactTime { get; set; }
        public AllocStatus AllocStatus { get; set; }
        public AllocRejCode AllocRejCode { get; set; }
        public AllocType AllocType { get; set; }
        public AllocIntermedReqType AllocIntermedReqType { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public Product Product { get; set; }
        public SecurityType SecurityType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public decimal? AllocPrice { get; set; }
            public string IndividualAllocID { get; set; }
            public int? IndividualAllocRejCode { get; set; }
            public string AllocText { get; set; }
            public int? EncodedAllocTextLen { get; set; }
            public string EncodedAllocText { get; set; }
        }
    }

    public class AllocationReport
    {
        public string AllocReportID { get; set; }
        public string AllocID { get; set; }
        public AllocTransType AllocTransType { get; set; }
        public string AllocReportRefID { get; set; }
        public AllocCancReplaceReason AllocCancReplaceReason { get; set; }
        public string SecondaryAllocID { get; set; }
        public AllocReportType AllocReportType { get; set; }
        public AllocStatus AllocStatus { get; set; }
        public AllocRejCode AllocRejCode { get; set; }
        public string RefAllocID { get; set; }
        public AllocIntermedReqType AllocIntermedReqType { get; set; }
        public string AllocLinkID { get; set; }
        public AllocLinkType AllocLinkType { get; set; }
        public string BookingRefID { get; set; }
        public AllocNoOrdersType AllocNoOrdersType { get; set; }
        public bool? PreviouslyReported { get; set; }
        public bool? ReversalIndicator { get; set; }
        public string MatchType { get; set; }
        public Side Side { get; set; }
        public int Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string LastMkt { get; set; }
        public DateTime? TradeOriginationDate { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public PriceType PriceType { get; set; }
        public decimal AvgPx { get; set; }
        public decimal? AvgParPx { get; set; }
        public string Currency { get; set; }
        public int? AvgPxPrecision { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime? TransactTime { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public BookingType BookingType { get; set; }
        public decimal? GrossTradeAmt { get; set; }
        public decimal? Concession { get; set; }
        public decimal? TotalTakedown { get; set; }
        public decimal? NetMoney { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public bool? AutoAcceptIndicator { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public int? NumDaysInterest { get; set; }
        public decimal? AccruedInterestRate { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? TotalAccruedInterestAmt { get; set; }
        public decimal? InterestAtMaturity { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public bool? LegalConfirm { get; set; }
        public int? TotNoAllocs { get; set; }
        public bool? LastFragment { get; set; }
        public Instrument Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Parties? Parties { get; set; }
        public Stipulations? Stipulations { get; set; }
        public YieldData? YieldData { get; set; }
        public NoOrdersItem[] NoOrders { get; set; }

        public struct NoOrdersItem
        {
            public string ClOrdID { get; set; }
            public string OrderID { get; set; }
            public string SecondaryOrderID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ListID { get; set; }
            public int? OrderQty { get; set; }
            public decimal? OrderAvgPx { get; set; }
            public int? OrderBookingQty { get; set; }
            public NestedParties2? NestedParties2 { get; set; }
        }

        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public int? LastQty { get; set; }
            public string ExecID { get; set; }
            public string SecondaryExecID { get; set; }
            public decimal? LastPx { get; set; }
            public decimal? LastParPx { get; set; }
            public LastCapacity LastCapacity { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public MatchStatus MatchStatus { get; set; }
            public decimal? AllocPrice { get; set; }
            public int AllocQty { get; set; }
            public string IndividualAllocID { get; set; }
            public ProcessCode ProcessCode { get; set; }
            public bool? NotifyBrokerOfCredit { get; set; }
            public AllocHandlInst AllocHandlInst { get; set; }
            public string AllocText { get; set; }
            public int? EncodedAllocTextLen { get; set; }
            public string EncodedAllocText { get; set; }
            public decimal? AllocAvgPx { get; set; }
            public decimal? AllocNetMoney { get; set; }
            public decimal? SettlCurrAmt { get; set; }
            public decimal? AllocSettlCurrAmt { get; set; }
            public string SettlCurrency { get; set; }
            public string AllocSettlCurrency { get; set; }
            public decimal? SettlCurrFxRate { get; set; }
            public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
            public decimal? AllocAccruedInterestAmt { get; set; }
            public decimal? AllocInterestAtMaturity { get; set; }
            public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
            public AllocSettlInstType AllocSettlInstType { get; set; }
            public NestedParties? NestedParties { get; set; }
            public CommissionData? CommissionData { get; set; }
            public SettlInstructionsData? SettlInstructionsData { get; set; }
        }
    }

    public class AllocationReportAck
    {
        public string AllocReportID { get; set; }
        public string AllocID { get; set; }
        public string SecondaryAllocID { get; set; }
        public DateTime? TradeDate { get; set; }
        public DateTime TransactTime { get; set; }
        public AllocStatus AllocStatus { get; set; }
        public AllocRejCode AllocRejCode { get; set; }
        public AllocReportType AllocReportType { get; set; }
        public AllocIntermedReqType AllocIntermedReqType { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public Product Product { get; set; }
        public SecurityType SecurityType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public decimal? AllocPrice { get; set; }
            public string IndividualAllocID { get; set; }
            public int? IndividualAllocRejCode { get; set; }
            public string AllocText { get; set; }
            public int? EncodedAllocTextLen { get; set; }
            public string EncodedAllocText { get; set; }
        }
    }

    public class Confirmation
    {
        public string ConfirmID { get; set; }
        public string ConfirmRefID { get; set; }
        public string ConfirmReqID { get; set; }
        public ConfirmTransType ConfirmTransType { get; set; }
        public ConfirmType ConfirmType { get; set; }
        public bool? CopyMsgIndicator { get; set; }
        public bool? LegalConfirm { get; set; }
        public ConfirmStatus ConfirmStatus { get; set; }
        public string AllocID { get; set; }
        public string SecondaryAllocID { get; set; }
        public string IndividualAllocID { get; set; }
        public DateTime TransactTime { get; set; }
        public DateTime TradeDate { get; set; }
        public int AllocQty { get; set; }
        public QtyType QtyType { get; set; }
        public Side Side { get; set; }
        public string Currency { get; set; }
        public string LastMkt { get; set; }
        public string AllocAccount { get; set; }
        public int? AllocAcctIDSource { get; set; }
        public AllocAccountType AllocAccountType { get; set; }
        public decimal AvgPx { get; set; }
        public int? AvgPxPrecision { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? AvgParPx { get; set; }
        public decimal? ReportedPx { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public ProcessCode ProcessCode { get; set; }
        public decimal GrossTradeAmt { get; set; }
        public int? NumDaysInterest { get; set; }
        public DateTime? ExDate { get; set; }
        public decimal? AccruedInterestRate { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? InterestAtMaturity { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public decimal? Concession { get; set; }
        public decimal? TotalTakedown { get; set; }
        public decimal NetMoney { get; set; }
        public decimal? MaturityNetMoney { get; set; }
        public decimal? SettlCurrAmt { get; set; }
        public string SettlCurrency { get; set; }
        public decimal? SettlCurrFxRate { get; set; }
        public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public decimal? SharedCommission { get; set; }
        public Parties? Parties { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public Instrument Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public YieldData? YieldData { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public SettlInstructionsData? SettlInstructionsData { get; set; }
        public CommissionData? CommissionData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public NoOrdersItem[] NoOrders { get; set; }

        public struct NoOrdersItem
        {
            public string ClOrdID { get; set; }
            public string OrderID { get; set; }
            public string SecondaryOrderID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ListID { get; set; }
            public int? OrderQty { get; set; }
            public decimal? OrderAvgPx { get; set; }
            public int? OrderBookingQty { get; set; }
            public NestedParties2? NestedParties2 { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoCapacitiesItem[] NoCapacities { get; set; }

        public struct NoCapacitiesItem
        {
            public OrderCapacity OrderCapacity { get; set; }
            public OrderRestrictions OrderRestrictions { get; set; }
            public int OrderCapacityQty { get; set; }
        }

        public NoMiscFeesItem[] NoMiscFees { get; set; }

        public struct NoMiscFeesItem
        {
            public decimal? MiscFeeAmt { get; set; }
            public string MiscFeeCurr { get; set; }
            public MiscFeeType MiscFeeType { get; set; }
            public MiscFeeBasis MiscFeeBasis { get; set; }
        }
    }

    public class ConfirmationAck
    {
        public string ConfirmID { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime TransactTime { get; set; }
        public AffirmStatus AffirmStatus { get; set; }
        public ConfirmRejReason ConfirmRejReason { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
    }

    public class ConfirmationRequest
    {
        public string ConfirmReqID { get; set; }
        public ConfirmType ConfirmType { get; set; }
        public string AllocID { get; set; }
        public string SecondaryAllocID { get; set; }
        public string IndividualAllocID { get; set; }
        public DateTime TransactTime { get; set; }
        public string AllocAccount { get; set; }
        public int? AllocAcctIDSource { get; set; }
        public AllocAccountType AllocAccountType { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public NoOrdersItem[] NoOrders { get; set; }

        public struct NoOrdersItem
        {
            public string ClOrdID { get; set; }
            public string OrderID { get; set; }
            public string SecondaryOrderID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ListID { get; set; }
            public int? OrderQty { get; set; }
            public decimal? OrderAvgPx { get; set; }
            public int? OrderBookingQty { get; set; }
            public NestedParties2? NestedParties2 { get; set; }
        }
    }

    public class SettlementInstructions
    {
        public string SettlInstMsgID { get; set; }
        public string SettlInstReqID { get; set; }
        public SettlInstMode SettlInstMode { get; set; }
        public SettlInstReqRejCode SettlInstReqRejCode { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public SettlInstSource SettlInstSource { get; set; }
        public string ClOrdID { get; set; }
        public DateTime TransactTime { get; set; }
        public NoSettlInstItem[] NoSettlInst { get; set; }

        public struct NoSettlInstItem
        {
            public string SettlInstID { get; set; }
            public SettlInstTransType SettlInstTransType { get; set; }
            public string SettlInstRefID { get; set; }
            public Side Side { get; set; }
            public Product Product { get; set; }
            public SecurityType SecurityType { get; set; }
            public string CFICode { get; set; }
            public DateTime? EffectiveTime { get; set; }
            public DateTime? ExpireTime { get; set; }
            public DateTime? LastUpdateTime { get; set; }
            public PaymentMethod PaymentMethod { get; set; }
            public string PaymentRef { get; set; }
            public string CardHolderName { get; set; }
            public string CardNumber { get; set; }
            public DateTime? CardStartDate { get; set; }
            public DateTime? CardExpDate { get; set; }
            public string CardIssNum { get; set; }
            public DateTime? PaymentDate { get; set; }
            public string PaymentRemitterID { get; set; }
            public Parties? Parties { get; set; }
            public SettlInstructionsData? SettlInstructionsData { get; set; }
        }
    }

    public class SettlementInstructionRequest
    {
        public string SettlInstReqID { get; set; }
        public DateTime TransactTime { get; set; }
        public string AllocAccount { get; set; }
        public int? AllocAcctIDSource { get; set; }
        public Side Side { get; set; }
        public Product Product { get; set; }
        public SecurityType SecurityType { get; set; }
        public string CFICode { get; set; }
        public DateTime? EffectiveTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public StandInstDbType StandInstDbType { get; set; }
        public string StandInstDbName { get; set; }
        public string StandInstDbID { get; set; }
        public Parties? Parties { get; set; }
    }

    public class TradeCaptureReportRequest
    {
        public string TradeRequestID { get; set; }
        public TradeRequestType TradeRequestType { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public string TradeReportID { get; set; }
        public string SecondaryTradeReportID { get; set; }
        public string ExecID { get; set; }
        public ExecType ExecType { get; set; }
        public string OrderID { get; set; }
        public string ClOrdID { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public TrdType TrdType { get; set; }
        public int? TrdSubType { get; set; }
        public string TransferReason { get; set; }
        public int? SecondaryTrdType { get; set; }
        public string TradeLinkID { get; set; }
        public string TrdMatchID { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string TimeBracket { get; set; }
        public Side Side { get; set; }
        public MultiLegReportingType MultiLegReportingType { get; set; }
        public string TradeInputSource { get; set; }
        public string TradeInputDevice { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public InstrumentExtension? InstrumentExtension { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoDatesItem[] NoDates { get; set; }

        public struct NoDatesItem
        {
            public DateTime? TradeDate { get; set; }
            public DateTime? TransactTime { get; set; }
        }
    }

    public class TradeCaptureReportRequestAck
    {
        public string TradeRequestID { get; set; }
        public TradeRequestType TradeRequestType { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public int? TotNumTradeReports { get; set; }
        public TradeRequestResult TradeRequestResult { get; set; }
        public TradeRequestStatus TradeRequestStatus { get; set; }
        public MultiLegReportingType MultiLegReportingType { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Instrument? Instrument { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }
    }

    public class TradeCaptureReport
    {
        public string TradeReportID { get; set; }
        public TradeReportTransType TradeReportTransType { get; set; }
        public TradeReportType TradeReportType { get; set; }
        public string TradeRequestID { get; set; }
        public TrdType TrdType { get; set; }
        public int? TrdSubType { get; set; }
        public int? SecondaryTrdType { get; set; }
        public string TransferReason { get; set; }
        public ExecType ExecType { get; set; }
        public int? TotNumTradeReports { get; set; }
        public bool? LastRptRequested { get; set; }
        public bool? UnsolicitedIndicator { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public string TradeReportRefID { get; set; }
        public string SecondaryTradeReportRefID { get; set; }
        public string SecondaryTradeReportID { get; set; }
        public string TradeLinkID { get; set; }
        public string TrdMatchID { get; set; }
        public string ExecID { get; set; }
        public OrdStatus OrdStatus { get; set; }
        public string SecondaryExecID { get; set; }
        public ExecRestatementReason ExecRestatementReason { get; set; }
        public bool PreviouslyReported { get; set; }
        public PriceType PriceType { get; set; }
        public QtyType QtyType { get; set; }
        public string UnderlyingTradingSessionID { get; set; }
        public string UnderlyingTradingSessionSubID { get; set; }
        public int LastQty { get; set; }
        public decimal LastPx { get; set; }
        public decimal? LastParPx { get; set; }
        public decimal? LastSpotRate { get; set; }
        public decimal? LastForwardPoints { get; set; }
        public string LastMkt { get; set; }
        public DateTime TradeDate { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public decimal? AvgPx { get; set; }
        public AvgPxIndicator AvgPxIndicator { get; set; }
        public MultiLegReportingType MultiLegReportingType { get; set; }
        public string TradeLegRefID { get; set; }
        public DateTime TransactTime { get; set; }
        public SettlType SettlType { get; set; }
        public DateTime? SettlDate { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public string MatchType { get; set; }
        public bool? CopyMsgIndicator { get; set; }
        public bool? PublishTrdIndicator { get; set; }
        public ShortSaleReason ShortSaleReason { get; set; }
        public Instrument Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public OrderQtyData? OrderQtyData { get; set; }
        public YieldData? YieldData { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public PositionAmountData? PositionAmountData { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegPositionEffect { get; set; }
            public int? LegCoveredOrUncovered { get; set; }
            public string LegRefID { get; set; }
            public decimal? LegPrice { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public decimal? LegLastPx { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoSidesItem[] NoSides { get; set; }

        public struct NoSidesItem
        {
            public Side Side { get; set; }
            public string OrderID { get; set; }
            public string SecondaryOrderID { get; set; }
            public string ClOrdID { get; set; }
            public string SecondaryClOrdID { get; set; }
            public string ListID { get; set; }
            public string Account { get; set; }
            public AcctIDSource AcctIDSource { get; set; }
            public AccountType AccountType { get; set; }
            public ProcessCode ProcessCode { get; set; }
            public bool? OddLot { get; set; }
            public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
            public string TradeInputSource { get; set; }
            public string TradeInputDevice { get; set; }
            public string OrderInputDevice { get; set; }
            public string Currency { get; set; }
            public string ComplianceID { get; set; }
            public bool? SolicitedFlag { get; set; }
            public OrderCapacity OrderCapacity { get; set; }
            public OrderRestrictions OrderRestrictions { get; set; }
            public CustOrderCapacity CustOrderCapacity { get; set; }
            public OrdType OrdType { get; set; }
            public ExecInst ExecInst { get; set; }
            public DateTime? TransBkdTime { get; set; }
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
            public string TimeBracket { get; set; }
            public decimal? GrossTradeAmt { get; set; }
            public int? NumDaysInterest { get; set; }
            public DateTime? ExDate { get; set; }
            public decimal? AccruedInterestRate { get; set; }
            public decimal? AccruedInterestAmt { get; set; }
            public decimal? InterestAtMaturity { get; set; }
            public decimal? EndAccruedInterestAmt { get; set; }
            public decimal? StartCash { get; set; }
            public decimal? EndCash { get; set; }
            public decimal? Concession { get; set; }
            public decimal? TotalTakedown { get; set; }
            public decimal? NetMoney { get; set; }
            public decimal? SettlCurrAmt { get; set; }
            public string SettlCurrency { get; set; }
            public decimal? SettlCurrFxRate { get; set; }
            public SettlCurrFxRateCalc SettlCurrFxRateCalc { get; set; }
            public PositionEffect PositionEffect { get; set; }
            public string Text { get; set; }
            public int? EncodedTextLen { get; set; }
            public string EncodedText { get; set; }
            public SideMultiLegReportingType SideMultiLegReportingType { get; set; }
            public string ExchangeRule { get; set; }
            public TradeAllocIndicator TradeAllocIndicator { get; set; }
            public PreallocMethod PreallocMethod { get; set; }
            public string AllocID { get; set; }
            public Parties? Parties { get; set; }
            public CommissionData? CommissionData { get; set; }
            public Stipulations? Stipulations { get; set; }
        }
    }

    public class TradeCaptureReportAck
    {
        public string TradeReportID { get; set; }
        public TradeReportTransType TradeReportTransType { get; set; }
        public TradeReportType TradeReportType { get; set; }
        public TrdType TrdType { get; set; }
        public int? TrdSubType { get; set; }
        public int? SecondaryTrdType { get; set; }
        public string TransferReason { get; set; }
        public ExecType ExecType { get; set; }
        public string TradeReportRefID { get; set; }
        public string SecondaryTradeReportRefID { get; set; }
        public TrdRptStatus TrdRptStatus { get; set; }
        public TradeReportRejectReason TradeReportRejectReason { get; set; }
        public string SecondaryTradeReportID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public string TradeLinkID { get; set; }
        public string TrdMatchID { get; set; }
        public string ExecID { get; set; }
        public string SecondaryExecID { get; set; }
        public DateTime? TransactTime { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public ClearingFeeIndicator ClearingFeeIndicator { get; set; }
        public OrderCapacity OrderCapacity { get; set; }
        public OrderRestrictions OrderRestrictions { get; set; }
        public CustOrderCapacity CustOrderCapacity { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public PositionEffect PositionEffect { get; set; }
        public PreallocMethod PreallocMethod { get; set; }
        public Instrument Instrument { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public int? LegQty { get; set; }
            public LegSwapType LegSwapType { get; set; }
            public char? LegPositionEffect { get; set; }
            public int? LegCoveredOrUncovered { get; set; }
            public string LegRefID { get; set; }
            public decimal? LegPrice { get; set; }
            public char? LegSettlType { get; set; }
            public DateTime? LegSettlDate { get; set; }
            public decimal? LegLastPx { get; set; }
            public InstrumentLeg? InstrumentLeg { get; set; }
            public LegStipulations? LegStipulations { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoAllocsItem[] NoAllocs { get; set; }

        public struct NoAllocsItem
        {
            public string AllocAccount { get; set; }
            public int? AllocAcctIDSource { get; set; }
            public string AllocSettlCurrency { get; set; }
            public string IndividualAllocID { get; set; }
            public int? AllocQty { get; set; }
            public NestedParties2? NestedParties2 { get; set; }
        }
    }

    public class RegistrationInstructions
    {
        public string RegistID { get; set; }
        public RegistTransType RegistTransType { get; set; }
        public string RegistRefID { get; set; }
        public string ClOrdID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public string RegistAcctType { get; set; }
        public TaxAdvantageType TaxAdvantageType { get; set; }
        public OwnershipType OwnershipType { get; set; }
        public Parties? Parties { get; set; }
        public NoRegistDtlsItem[] NoRegistDtls { get; set; }

        public struct NoRegistDtlsItem
        {
            public string RegistDtls { get; set; }
            public string RegistEmail { get; set; }
            public string MailingDtls { get; set; }
            public string MailingInst { get; set; }
            public OwnerType OwnerType { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string InvestorCountryOfResidence { get; set; }
            public NestedParties? NestedParties { get; set; }
        }

        public NoDistribInstsItem[] NoDistribInsts { get; set; }

        public struct NoDistribInstsItem
        {
            public DistribPaymentMethod DistribPaymentMethod { get; set; }
            public decimal? DistribPercentage { get; set; }
            public string CashDistribCurr { get; set; }
            public string CashDistribAgentName { get; set; }
            public string CashDistribAgentCode { get; set; }
            public string CashDistribAgentAcctNumber { get; set; }
            public string CashDistribPayRef { get; set; }
            public string CashDistribAgentAcctName { get; set; }
        }
    }

    public class RegistrationInstructionsResponse
    {
        public string RegistID { get; set; }
        public RegistTransType RegistTransType { get; set; }
        public string RegistRefID { get; set; }
        public string ClOrdID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public RegistStatus RegistStatus { get; set; }
        public RegistRejReasonCode RegistRejReasonCode { get; set; }
        public string RegistRejReasonText { get; set; }
        public Parties? Parties { get; set; }
    }

    public class PositionMaintenanceRequest
    {
        public string PosReqID { get; set; }
        public PosTransType PosTransType { get; set; }
        public PosMaintAction PosMaintAction { get; set; }
        public string OrigPosReqRefID { get; set; }
        public string PosMaintRptRefID { get; set; }
        public DateTime ClearingBusinessDate { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string Currency { get; set; }
        public DateTime TransactTime { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public bool? ContraryInstructionIndicator { get; set; }
        public bool? PriorSpreadIndicator { get; set; }
        public decimal? ThresholdAmount { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties Parties { get; set; }
        public Instrument Instrument { get; set; }
        public PositionQty PositionQty { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }
    }

    public class PositionMaintenanceReport
    {
        public string PosMaintRptID { get; set; }
        public PosTransType PosTransType { get; set; }
        public string PosReqID { get; set; }
        public PosMaintAction PosMaintAction { get; set; }
        public string OrigPosReqRefID { get; set; }
        public PosMaintStatus PosMaintStatus { get; set; }
        public PosMaintResult PosMaintResult { get; set; }
        public DateTime ClearingBusinessDate { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string Currency { get; set; }
        public DateTime TransactTime { get; set; }
        public AdjustmentType AdjustmentType { get; set; }
        public decimal? ThresholdAmount { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument Instrument { get; set; }
        public PositionQty PositionQty { get; set; }
        public PositionAmountData PositionAmountData { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }
    }

    public class RequestForPositions
    {
        public string PosReqID { get; set; }
        public PosReqType PosReqType { get; set; }
        public MatchStatus MatchStatus { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string Currency { get; set; }
        public DateTime ClearingBusinessDate { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime TransactTime { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoTradingSessionsItem[] NoTradingSessions { get; set; }

        public struct NoTradingSessionsItem
        {
            public string TradingSessionID { get; set; }
            public string TradingSessionSubID { get; set; }
        }
    }

    public class RequestForPositionsAck
    {
        public string PosMaintRptID { get; set; }
        public string PosReqID { get; set; }
        public int? TotalNumPosReports { get; set; }
        public bool? UnsolicitedIndicator { get; set; }
        public PosReqResult PosReqResult { get; set; }
        public PosReqStatus PosReqStatus { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string Currency { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class PositionReport
    {
        public string PosMaintRptID { get; set; }
        public string PosReqID { get; set; }
        public PosReqType PosReqType { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public int? TotalNumPosReports { get; set; }
        public bool? UnsolicitedIndicator { get; set; }
        public PosReqResult PosReqResult { get; set; }
        public DateTime ClearingBusinessDate { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public string Account { get; set; }
        public AcctIDSource AcctIDSource { get; set; }
        public AccountType AccountType { get; set; }
        public string Currency { get; set; }
        public decimal SettlPrice { get; set; }
        public SettlPriceType SettlPriceType { get; set; }
        public decimal PriorSettlPrice { get; set; }
        public RegistStatus RegistStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public PositionQty PositionQty { get; set; }
        public PositionAmountData PositionAmountData { get; set; }
        public NoLegsItem[] NoLegs { get; set; }

        public struct NoLegsItem
        {
            public InstrumentLeg? InstrumentLeg { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public decimal UnderlyingSettlPrice { get; set; }
            public int UnderlyingSettlPriceType { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class AssignmentReport
    {
        public string AsgnRptID { get; set; }
        public int? TotNumAssignmentReports { get; set; }
        public bool? LastRptRequested { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public decimal? ThresholdAmount { get; set; }
        public decimal SettlPrice { get; set; }
        public SettlPriceType SettlPriceType { get; set; }
        public decimal UnderlyingSettlPrice { get; set; }
        public DateTime? ExpireDate { get; set; }
        public AssignmentMethod AssignmentMethod { get; set; }
        public int? AssignmentUnit { get; set; }
        public decimal OpenInterest { get; set; }
        public ExerciseMethod ExerciseMethod { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime ClearingBusinessDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public PositionQty PositionQty { get; set; }
        public PositionAmountData PositionAmountData { get; set; }
        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class CollateralRequest
    {
        public string CollReqID { get; set; }
        public CollAsgnReason CollAsgnReason { get; set; }
        public DateTime TransactTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string ClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public DateTime? SettlDate { get; set; }
        public int? Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public decimal? MarginExcess { get; set; }
        public decimal? TotalNetValue { get; set; }
        public decimal? CashOutstanding { get; set; }
        public Side Side { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public string ExecID { get; set; }
        }

        public NoTradesItem[] NoTrades { get; set; }

        public struct NoTradesItem
        {
            public string TradeReportID { get; set; }
            public string SecondaryTradeReportID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public CollAction CollAction { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoMiscFeesItem[] NoMiscFees { get; set; }

        public struct NoMiscFeesItem
        {
            public decimal? MiscFeeAmt { get; set; }
            public string MiscFeeCurr { get; set; }
            public MiscFeeType MiscFeeType { get; set; }
            public MiscFeeBasis MiscFeeBasis { get; set; }
        }
    }

    public class CollateralAssignment
    {
        public string CollAsgnID { get; set; }
        public string CollReqID { get; set; }
        public CollAsgnReason CollAsgnReason { get; set; }
        public CollAsgnTransType CollAsgnTransType { get; set; }
        public string CollAsgnRefID { get; set; }
        public DateTime TransactTime { get; set; }
        public DateTime? ExpireTime { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string ClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public DateTime? SettlDate { get; set; }
        public int? Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public decimal? MarginExcess { get; set; }
        public decimal? TotalNetValue { get; set; }
        public decimal? CashOutstanding { get; set; }
        public Side Side { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SettlInstructionsData? SettlInstructionsData { get; set; }
        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public string ExecID { get; set; }
        }

        public NoTradesItem[] NoTrades { get; set; }

        public struct NoTradesItem
        {
            public string TradeReportID { get; set; }
            public string SecondaryTradeReportID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public CollAction CollAction { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoMiscFeesItem[] NoMiscFees { get; set; }

        public struct NoMiscFeesItem
        {
            public decimal? MiscFeeAmt { get; set; }
            public string MiscFeeCurr { get; set; }
            public MiscFeeType MiscFeeType { get; set; }
            public MiscFeeBasis MiscFeeBasis { get; set; }
        }
    }

    public class CollateralResponse
    {
        public string CollRespID { get; set; }
        public string CollAsgnID { get; set; }
        public string CollReqID { get; set; }
        public CollAsgnReason CollAsgnReason { get; set; }
        public CollAsgnTransType CollAsgnTransType { get; set; }
        public CollAsgnRespType CollAsgnRespType { get; set; }
        public CollAsgnRejectReason CollAsgnRejectReason { get; set; }
        public DateTime TransactTime { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string ClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public DateTime? SettlDate { get; set; }
        public int? Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public decimal? MarginExcess { get; set; }
        public decimal? TotalNetValue { get; set; }
        public decimal? CashOutstanding { get; set; }
        public Side Side { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public string ExecID { get; set; }
        }

        public NoTradesItem[] NoTrades { get; set; }

        public struct NoTradesItem
        {
            public string TradeReportID { get; set; }
            public string SecondaryTradeReportID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public CollAction CollAction { get; set; }
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoMiscFeesItem[] NoMiscFees { get; set; }

        public struct NoMiscFeesItem
        {
            public decimal? MiscFeeAmt { get; set; }
            public string MiscFeeCurr { get; set; }
            public MiscFeeType MiscFeeType { get; set; }
            public MiscFeeBasis MiscFeeBasis { get; set; }
        }
    }

    public class CollateralReport
    {
        public string CollRptID { get; set; }
        public string CollInquiryID { get; set; }
        public CollStatus CollStatus { get; set; }
        public int? TotNumReports { get; set; }
        public bool? LastRptRequested { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string ClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public DateTime? SettlDate { get; set; }
        public int? Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public decimal? MarginExcess { get; set; }
        public decimal? TotalNetValue { get; set; }
        public decimal? CashOutstanding { get; set; }
        public Side Side { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SettlInstructionsData? SettlInstructionsData { get; set; }
        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public string ExecID { get; set; }
        }

        public NoTradesItem[] NoTrades { get; set; }

        public struct NoTradesItem
        {
            public string TradeReportID { get; set; }
            public string SecondaryTradeReportID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }

        public NoMiscFeesItem[] NoMiscFees { get; set; }

        public struct NoMiscFeesItem
        {
            public decimal? MiscFeeAmt { get; set; }
            public string MiscFeeCurr { get; set; }
            public MiscFeeType MiscFeeType { get; set; }
            public MiscFeeBasis MiscFeeBasis { get; set; }
        }
    }

    public class CollateralInquiry
    {
        public string CollInquiryID { get; set; }
        public SubscriptionRequestType SubscriptionRequestType { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string ClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public DateTime? SettlDate { get; set; }
        public int? Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public decimal? MarginExcess { get; set; }
        public decimal? TotalNetValue { get; set; }
        public decimal? CashOutstanding { get; set; }
        public Side Side { get; set; }
        public decimal? Price { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? AccruedInterestAmt { get; set; }
        public decimal? EndAccruedInterestAmt { get; set; }
        public decimal? StartCash { get; set; }
        public decimal? EndCash { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public TrdRegTimestamps? TrdRegTimestamps { get; set; }
        public SpreadOrBenchmarkCurveData? SpreadOrBenchmarkCurveData { get; set; }
        public Stipulations? Stipulations { get; set; }
        public SettlInstructionsData? SettlInstructionsData { get; set; }
        public NoCollInquiryQualifierItem[] NoCollInquiryQualifier { get; set; }

        public struct NoCollInquiryQualifierItem
        {
            public CollInquiryQualifier CollInquiryQualifier { get; set; }
        }

        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public string ExecID { get; set; }
        }

        public NoTradesItem[] NoTrades { get; set; }

        public struct NoTradesItem
        {
            public string TradeReportID { get; set; }
            public string SecondaryTradeReportID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }

    public class NetworkStatusRequest
    {
        public NetworkRequestType NetworkRequestType { get; set; }
        public string NetworkRequestID { get; set; }
        public NoCompIDsItem[] NoCompIDs { get; set; }

        public struct NoCompIDsItem
        {
            public string RefCompID { get; set; }
            public string RefSubID { get; set; }
            public string LocationID { get; set; }
            public string DeskID { get; set; }
        }
    }

    public class NetworkStatusResponse
    {
        public NetworkStatusResponseType NetworkStatusResponseType { get; set; }
        public string NetworkRequestID { get; set; }
        public string NetworkResponseID { get; set; }
        public string LastNetworkResponseID { get; set; }
        public NoCompIDsItem[] NoCompIDs { get; set; }

        public struct NoCompIDsItem
        {
            public string RefCompID { get; set; }
            public string RefSubID { get; set; }
            public string LocationID { get; set; }
            public string DeskID { get; set; }
            public StatusValue StatusValue { get; set; }
            public string StatusText { get; set; }
        }
    }

    public class CollateralInquiryAck
    {
        public string CollInquiryID { get; set; }
        public CollInquiryStatus CollInquiryStatus { get; set; }
        public CollInquiryResult CollInquiryResult { get; set; }
        public int? TotNumReports { get; set; }
        public string Account { get; set; }
        public AccountType AccountType { get; set; }
        public string ClOrdID { get; set; }
        public string OrderID { get; set; }
        public string SecondaryOrderID { get; set; }
        public string SecondaryClOrdID { get; set; }
        public DateTime? SettlDate { get; set; }
        public int? Quantity { get; set; }
        public QtyType QtyType { get; set; }
        public string Currency { get; set; }
        public int? NoLegs { get; set; }
        public string TradingSessionID { get; set; }
        public string TradingSessionSubID { get; set; }
        public string SettlSessID { get; set; }
        public string SettlSessSubID { get; set; }
        public DateTime? ClearingBusinessDate { get; set; }
        public ResponseTransportType ResponseTransportType { get; set; }
        public string ResponseDestination { get; set; }
        public string Text { get; set; }
        public int? EncodedTextLen { get; set; }
        public string EncodedText { get; set; }
        public Parties? Parties { get; set; }
        public Instrument? Instrument { get; set; }
        public FinancingDetails? FinancingDetails { get; set; }
        public InstrumentLeg? InstrumentLeg { get; set; }
        public NoCollInquiryQualifierItem[] NoCollInquiryQualifier { get; set; }

        public struct NoCollInquiryQualifierItem
        {
            public CollInquiryQualifier CollInquiryQualifier { get; set; }
        }

        public NoExecsItem[] NoExecs { get; set; }

        public struct NoExecsItem
        {
            public string ExecID { get; set; }
        }

        public NoTradesItem[] NoTrades { get; set; }

        public struct NoTradesItem
        {
            public string TradeReportID { get; set; }
            public string SecondaryTradeReportID { get; set; }
        }

        public NoUnderlyingsItem[] NoUnderlyings { get; set; }

        public struct NoUnderlyingsItem
        {
            public UnderlyingInstrument? UnderlyingInstrument { get; set; }
        }
    }
}
