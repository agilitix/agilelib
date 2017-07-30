using System;
using System.Linq;
using System.Collections.Generic;

// Generated file

namespace AxFixEntities
{
  public class Instrument
  {
    public string Symbol { get; set; }
    public SymbolSfx SymbolSfx { get; set; }
    public string SecurityID { get; set; }
    public SecurityIDSource SecurityIDSource { get; set; }
    public Product Product { get; set; }
    public string CFICode { get; set; }
    public SecurityType SecurityType { get; set; }
    public string SecuritySubType { get; set; }
    public DateTime? MaturityMonthYear { get; set; }
    public DateTime? MaturityDate { get; set; }
    public PutOrCall PutOrCall { get; set; }
    public DateTime? CouponPaymentDate { get; set; }
    public DateTime? IssueDate { get; set; }
    public int? RepoCollateralSecurityType { get; set; }
    public int? RepurchaseTerm { get; set; }
    public decimal? RepurchaseRate { get; set; }
    public decimal? Factor { get; set; }
    public string CreditRating { get; set; }
    public string InstrRegistry { get; set; }
    public string CountryOfIssue { get; set; }
    public string StateOrProvinceOfIssue { get; set; }
    public string LocaleOfIssue { get; set; }
    public DateTime? RedemptionDate { get; set; }
    public decimal? StrikePrice { get; set; }
    public string StrikeCurrency { get; set; }
    public char? OptAttribute { get; set; }
    public decimal? ContractMultiplier { get; set; }
    public decimal? CouponRate { get; set; }
    public string SecurityExchange { get; set; }
    public string Issuer { get; set; }
    public int? EncodedIssuerLen { get; set; }
    public string EncodedIssuer { get; set; }
    public string SecurityDesc { get; set; }
    public int? EncodedSecurityDescLen { get; set; }
    public string EncodedSecurityDesc { get; set; }
    public string Pool { get; set; }
    public DateTime? ContractSettlMonth { get; set; }
    public int? CPProgram { get; set; }
    public string CPRegType { get; set; }
    public DateTime? DatedDate { get; set; }
    public DateTime? InterestAccrualDate { get; set; }
    public NoSecurityAltIDItem[] NoSecurityAltID { get; set; }
    public class NoSecurityAltIDItem
    {
      public string SecurityAltID { get; set; }
      public string SecurityAltIDSource { get; set; }
    }
    public NoEventsItem[] NoEvents { get; set; }
    public class NoEventsItem
    {
      public EventType EventType { get; set; }
      public DateTime? EventDate { get; set; }
      public decimal? EventPx { get; set; }
      public string EventText { get; set; }
    }
  }

  public class UnderlyingInstrument
  {
    public string UnderlyingSymbol { get; set; }
    public string UnderlyingSymbolSfx { get; set; }
    public string UnderlyingSecurityID { get; set; }
    public string UnderlyingSecurityIDSource { get; set; }
    public int? UnderlyingProduct { get; set; }
    public string UnderlyingCFICode { get; set; }
    public string UnderlyingSecurityType { get; set; }
    public string UnderlyingSecuritySubType { get; set; }
    public DateTime? UnderlyingMaturityMonthYear { get; set; }
    public DateTime? UnderlyingMaturityDate { get; set; }
    public UnderlyingPutOrCall UnderlyingPutOrCall { get; set; }
    public DateTime? UnderlyingCouponPaymentDate { get; set; }
    public DateTime? UnderlyingIssueDate { get; set; }
    public int? UnderlyingRepoCollateralSecurityType { get; set; }
    public int? UnderlyingRepurchaseTerm { get; set; }
    public decimal? UnderlyingRepurchaseRate { get; set; }
    public decimal? UnderlyingFactor { get; set; }
    public string UnderlyingCreditRating { get; set; }
    public string UnderlyingInstrRegistry { get; set; }
    public string UnderlyingCountryOfIssue { get; set; }
    public string UnderlyingStateOrProvinceOfIssue { get; set; }
    public string UnderlyingLocaleOfIssue { get; set; }
    public DateTime? UnderlyingRedemptionDate { get; set; }
    public decimal? UnderlyingStrikePrice { get; set; }
    public string UnderlyingStrikeCurrency { get; set; }
    public char? UnderlyingOptAttribute { get; set; }
    public decimal? UnderlyingContractMultiplier { get; set; }
    public decimal? UnderlyingCouponRate { get; set; }
    public string UnderlyingSecurityExchange { get; set; }
    public string UnderlyingIssuer { get; set; }
    public int? EncodedUnderlyingIssuerLen { get; set; }
    public string EncodedUnderlyingIssuer { get; set; }
    public string UnderlyingSecurityDesc { get; set; }
    public int? EncodedUnderlyingSecurityDescLen { get; set; }
    public string EncodedUnderlyingSecurityDesc { get; set; }
    public string UnderlyingCPProgram { get; set; }
    public string UnderlyingCPRegType { get; set; }
    public string UnderlyingCurrency { get; set; }
    public int? UnderlyingQty { get; set; }
    public decimal? UnderlyingPx { get; set; }
    public decimal? UnderlyingDirtyPrice { get; set; }
    public decimal? UnderlyingEndPrice { get; set; }
    public decimal? UnderlyingStartValue { get; set; }
    public decimal? UnderlyingCurrentValue { get; set; }
    public decimal? UnderlyingEndValue { get; set; }
    public NoUnderlyingSecurityAltIDItem[] NoUnderlyingSecurityAltID { get; set; }
    public class NoUnderlyingSecurityAltIDItem
    {
      public string UnderlyingSecurityAltID { get; set; }
      public string UnderlyingSecurityAltIDSource { get; set; }
    }
  }

  public class InstrumentLeg
  {
    public string LegSymbol { get; set; }
    public string LegSymbolSfx { get; set; }
    public string LegSecurityID { get; set; }
    public string LegSecurityIDSource { get; set; }
    public int? LegProduct { get; set; }
    public string LegCFICode { get; set; }
    public string LegSecurityType { get; set; }
    public string LegSecuritySubType { get; set; }
    public DateTime? LegMaturityMonthYear { get; set; }
    public DateTime? LegMaturityDate { get; set; }
    public DateTime? LegCouponPaymentDate { get; set; }
    public DateTime? LegIssueDate { get; set; }
    public int? LegRepoCollateralSecurityType { get; set; }
    public int? LegRepurchaseTerm { get; set; }
    public decimal? LegRepurchaseRate { get; set; }
    public decimal? LegFactor { get; set; }
    public string LegCreditRating { get; set; }
    public string LegInstrRegistry { get; set; }
    public string LegCountryOfIssue { get; set; }
    public string LegStateOrProvinceOfIssue { get; set; }
    public string LegLocaleOfIssue { get; set; }
    public DateTime? LegRedemptionDate { get; set; }
    public decimal? LegStrikePrice { get; set; }
    public string LegStrikeCurrency { get; set; }
    public char? LegOptAttribute { get; set; }
    public decimal? LegContractMultiplier { get; set; }
    public decimal? LegCouponRate { get; set; }
    public string LegSecurityExchange { get; set; }
    public string LegIssuer { get; set; }
    public int? EncodedLegIssuerLen { get; set; }
    public string EncodedLegIssuer { get; set; }
    public string LegSecurityDesc { get; set; }
    public int? EncodedLegSecurityDescLen { get; set; }
    public string EncodedLegSecurityDesc { get; set; }
    public decimal? LegRatioQty { get; set; }
    public char? LegSide { get; set; }
    public string LegCurrency { get; set; }
    public string LegPool { get; set; }
    public DateTime? LegDatedDate { get; set; }
    public DateTime? LegContractSettlMonth { get; set; }
    public DateTime? LegInterestAccrualDate { get; set; }
    public NoLegSecurityAltIDItem[] NoLegSecurityAltID { get; set; }
    public class NoLegSecurityAltIDItem
    {
      public string LegSecurityAltID { get; set; }
      public string LegSecurityAltIDSource { get; set; }
    }
  }

  public class InstrumentExtension
  {
    public DeliveryForm DeliveryForm { get; set; }
    public decimal? PctAtRisk { get; set; }
    public NoInstrAttribItem[] NoInstrAttrib { get; set; }
    public class NoInstrAttribItem
    {
      public InstrAttribType InstrAttribType { get; set; }
      public string InstrAttribValue { get; set; }
    }
  }

  public class OrderQtyData
  {
    public int? OrderQty { get; set; }
    public int? CashOrderQty { get; set; }
    public decimal? OrderPercent { get; set; }
    public RoundingDirection RoundingDirection { get; set; }
    public decimal? RoundingModulus { get; set; }
  }

  public class CommissionData
  {
    public decimal? Commission { get; set; }
    public CommType CommType { get; set; }
    public string CommCurrency { get; set; }
    public FundRenewWaiv FundRenewWaiv { get; set; }
  }

  public class Parties
  {
    public NoPartyIDsItem[] NoPartyIDs { get; set; }
    public class NoPartyIDsItem
    {
      public string PartyID { get; set; }
      public PartyIDSource PartyIDSource { get; set; }
      public PartyRole PartyRole { get; set; }
    }
  }

  public class NestedParties
  {
    public NoNestedPartyIDsItem[] NoNestedPartyIDs { get; set; }
    public class NoNestedPartyIDsItem
    {
      public string NestedPartyID { get; set; }
      public char? NestedPartyIDSource { get; set; }
      public int? NestedPartyRole { get; set; }
    }
  }

  public class NestedParties2
  {
    public NoNested2PartyIDsItem[] NoNested2PartyIDs { get; set; }
    public class NoNested2PartyIDsItem
    {
      public string Nested2PartyID { get; set; }
      public char? Nested2PartyIDSource { get; set; }
      public int? Nested2PartyRole { get; set; }
    }
  }

  public class NestedParties3
  {
    public NoNested3PartyIDsItem[] NoNested3PartyIDs { get; set; }
    public class NoNested3PartyIDsItem
    {
      public string Nested3PartyID { get; set; }
      public char? Nested3PartyIDSource { get; set; }
      public int? Nested3PartyRole { get; set; }
    }
  }

  public class SettlParties
  {
    public NoSettlPartyIDsItem[] NoSettlPartyIDs { get; set; }
    public class NoSettlPartyIDsItem
    {
      public string SettlPartyID { get; set; }
      public char? SettlPartyIDSource { get; set; }
      public int? SettlPartyRole { get; set; }
    }
  }

  public class SpreadOrBenchmarkCurveData
  {
    public decimal? Spread { get; set; }
    public string BenchmarkCurveCurrency { get; set; }
    public BenchmarkCurveName BenchmarkCurveName { get; set; }
    public string BenchmarkCurvePoint { get; set; }
    public decimal? BenchmarkPrice { get; set; }
    public int? BenchmarkPriceType { get; set; }
    public string BenchmarkSecurityID { get; set; }
    public string BenchmarkSecurityIDSource { get; set; }
  }

  public class LegBenchmarkCurveData
  {
    public string LegBenchmarkCurveCurrency { get; set; }
    public string LegBenchmarkCurveName { get; set; }
    public string LegBenchmarkCurvePoint { get; set; }
    public decimal? LegBenchmarkPrice { get; set; }
    public int? LegBenchmarkPriceType { get; set; }
  }

  public class Stipulations
  {
    public NoStipulationsItem[] NoStipulations { get; set; }
    public class NoStipulationsItem
    {
      public StipulationType StipulationType { get; set; }
      public StipulationValue StipulationValue { get; set; }
    }
  }

  public class UnderlyingStipulations
  {
    public NoUnderlyingStipsItem[] NoUnderlyingStips { get; set; }
    public class NoUnderlyingStipsItem
    {
      public string UnderlyingStipType { get; set; }
      public string UnderlyingStipValue { get; set; }
    }
  }

  public class LegStipulations
  {
    public NoLegStipulationsItem[] NoLegStipulations { get; set; }
    public class NoLegStipulationsItem
    {
      public string LegStipulationType { get; set; }
      public string LegStipulationValue { get; set; }
    }
  }

  public class YieldData
  {
    public YieldType YieldType { get; set; }
    public decimal? Yield { get; set; }
    public DateTime? YieldCalcDate { get; set; }
    public DateTime? YieldRedemptionDate { get; set; }
    public decimal? YieldRedemptionPrice { get; set; }
    public int? YieldRedemptionPriceType { get; set; }
  }

  public class PositionQty
  {
    public NoPositionsItem[] NoPositions { get; set; }
    public class NoPositionsItem
    {
      public PosType PosType { get; set; }
      public int? LongQty { get; set; }
      public int? ShortQty { get; set; }
      public PosQtyStatus PosQtyStatus { get; set; }
    }
  }

  public class PositionAmountData
  {
    public NoPosAmtItem[] NoPosAmt { get; set; }
    public class NoPosAmtItem
    {
      public PosAmtType PosAmtType { get; set; }
      public decimal PosAmt { get; set; }
    }
  }

  public class TrdRegTimestamps
  {
    public NoTrdRegTimestampsItem[] NoTrdRegTimestamps { get; set; }
    public class NoTrdRegTimestampsItem
    {
      public DateTime? TrdRegTimestamp { get; set; }
      public TrdRegTimestampType TrdRegTimestampType { get; set; }
      public string TrdRegTimestampOrigin { get; set; }
    }
  }

  public class SettlInstructionsData
  {
    public SettlDeliveryType SettlDeliveryType { get; set; }
    public StandInstDbType StandInstDbType { get; set; }
    public string StandInstDbName { get; set; }
    public string StandInstDbID { get; set; }
    public NoDlvyInstItem[] NoDlvyInst { get; set; }
    public class NoDlvyInstItem
    {
      public SettlInstSource SettlInstSource { get; set; }
      public DlvyInstType DlvyInstType { get; set; }
    }
  }

  public class PegInstructions
  {
    public decimal? PegOffsetValue { get; set; }
    public PegMoveType PegMoveType { get; set; }
    public PegOffsetType PegOffsetType { get; set; }
    public PegLimitType PegLimitType { get; set; }
    public PegRoundDirection PegRoundDirection { get; set; }
    public PegScope PegScope { get; set; }
  }

  public class DiscretionInstructions
  {
    public DiscretionInst DiscretionInst { get; set; }
    public decimal? DiscretionOffsetValue { get; set; }
    public DiscretionMoveType DiscretionMoveType { get; set; }
    public DiscretionOffsetType DiscretionOffsetType { get; set; }
    public DiscretionLimitType DiscretionLimitType { get; set; }
    public DiscretionRoundDirection DiscretionRoundDirection { get; set; }
    public DiscretionScope DiscretionScope { get; set; }
  }

  public class FinancingDetails
  {
    public string AgreementDesc { get; set; }
    public string AgreementID { get; set; }
    public DateTime? AgreementDate { get; set; }
    public string AgreementCurrency { get; set; }
    public TerminationType TerminationType { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public decimal? MarginRatio { get; set; }
  }

}
