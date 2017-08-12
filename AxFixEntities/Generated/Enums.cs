using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

// Generated file

namespace FIX44.Entities
{
    [DebuggerDisplay("{ToEnumName()}")]
    public struct AdvSide : IEquatable<AdvSide>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'B', "Buy"}, {'S', "Sell"}, {'X', "Cross"}, {'T', "Trade"},};
        private readonly char? _value;

        private AdvSide(char value)
        {
            _value = value;
        }

        public bool Equals(AdvSide other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AdvSide && Equals((AdvSide) other);
        }

        public static bool operator ==(AdvSide left, AdvSide right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AdvSide left, AdvSide right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AdvSide FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AdvSide", nameof(value));

            return new AdvSide(value);
        }

        public static AdvSide FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AdvSide", nameof(value));

            return new AdvSide(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AdvSide FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AdvSide(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AdvSide Invalid
        {
            get { return new AdvSide(); }
        }

        public static AdvSide Buy
        {
            get { return new AdvSide('B'); }
        }

        public static AdvSide Sell
        {
            get { return new AdvSide('S'); }
        }

        public static AdvSide Cross
        {
            get { return new AdvSide('X'); }
        }

        public static AdvSide Trade
        {
            get { return new AdvSide('T'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AdvTransType : IEquatable<AdvTransType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"N", "New"}, {"C", "Cancel"}, {"R", "Replace"},};
        private readonly string _value;

        private AdvTransType(string value)
        {
            _value = value;
        }

        public bool Equals(AdvTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AdvTransType && Equals((AdvTransType) other);
        }

        public static bool operator ==(AdvTransType left, AdvTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AdvTransType left, AdvTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static AdvTransType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AdvTransType", nameof(value));

            return new AdvTransType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static AdvTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AdvTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AdvTransType Invalid
        {
            get { return new AdvTransType(); }
        }

        public static AdvTransType New
        {
            get { return new AdvTransType("N"); }
        }

        public static AdvTransType Cancel
        {
            get { return new AdvTransType("C"); }
        }

        public static AdvTransType Replace
        {
            get { return new AdvTransType("R"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CommType : IEquatable<CommType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "PerUnit"}, {'2', "Percentage"}, {'3', "Absolute"}, {'4', "PercentageWaivedCashDiscount"}, {'5', "PercentageWaivedEnhancedUnits"}, {'6', "PointsPerBondOrOrContract"},};
        private readonly char? _value;

        private CommType(char value)
        {
            _value = value;
        }

        public bool Equals(CommType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CommType && Equals((CommType) other);
        }

        public static bool operator ==(CommType left, CommType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CommType left, CommType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CommType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CommType", nameof(value));

            return new CommType(value);
        }

        public static CommType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CommType", nameof(value));

            return new CommType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CommType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CommType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CommType Invalid
        {
            get { return new CommType(); }
        }

        public static CommType PerUnit
        {
            get { return new CommType('1'); }
        }

        public static CommType Percentage
        {
            get { return new CommType('2'); }
        }

        public static CommType Absolute
        {
            get { return new CommType('3'); }
        }

        public static CommType PercentageWaivedCashDiscount
        {
            get { return new CommType('4'); }
        }

        public static CommType PercentageWaivedEnhancedUnits
        {
            get { return new CommType('5'); }
        }

        public static CommType PointsPerBondOrOrContract
        {
            get { return new CommType('6'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ExecInst : IEquatable<ExecInst>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string>
                                                                     {
                                                                         {"1", "NotHeld"},
                                                                         {"2", "Work"},
                                                                         {"3", "GoAlong"},
                                                                         {"4", "OverTheDay"},
                                                                         {"5", "Held"},
                                                                         {"6", "ParticipateDontInitiate"},
                                                                         {"7", "StrictScale"},
                                                                         {"8", "TryToScale"},
                                                                         {"9", "StayOnBidside"},
                                                                         {"0", "StayOnOfferside"},
                                                                         {"A", "NoCross"},
                                                                         {"B", "OkToCross"},
                                                                         {"C", "CallFirst"},
                                                                         {"D", "PercentOfVolume"},
                                                                         {"E", "DoNotIncrease"},
                                                                         {"F", "DoNotReduce"},
                                                                         {"G", "AllOrNone"},
                                                                         {"H", "ReinstateOnSystemFailure"},
                                                                         {"I", "InstitutionsOnly"},
                                                                         {"J", "ReinstateOnTradingHalt"},
                                                                         {"K", "CancelOnTradingHalt"},
                                                                         {"L", "LastPeg"},
                                                                         {"M", "MidPrice"},
                                                                         {"N", "NonNegotiable"},
                                                                         {"O", "OpeningPeg"},
                                                                         {"P", "MarketPeg"},
                                                                         {"Q", "CancelOnSystemFailure"},
                                                                         {"R", "PrimaryPeg"},
                                                                         {"S", "Suspend"},
                                                                         {"T", "FixedPegToLocalBestBidOrOfferAtTimeOfOrder"},
                                                                         {"U", "CustomerDisplayInstruction"},
                                                                         {"V", "Netting"},
                                                                         {"W", "PegToVwap"},
                                                                         {"X", "TradeAlong"},
                                                                         {"Y", "TryToStop"},
                                                                         {"Z", "CancelIfNotBest"},
                                                                         {"a", "TrailingStopPeg"},
                                                                         {"b", "StrictLimit"},
                                                                         {"c", "IgnorePriceValidityChecks"},
                                                                         {"d", "PegToLimitPrice"},
                                                                         {"e", "WorkToTargetStrategy"},
                                                                     };

        private readonly string _value;

        private ExecInst(string value)
        {
            _value = value;
        }

        public bool Equals(ExecInst other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ExecInst && Equals((ExecInst) other);
        }

        public static bool operator ==(ExecInst left, ExecInst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExecInst left, ExecInst right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static ExecInst FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExecInst", nameof(value));

            return new ExecInst(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static ExecInst FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ExecInst(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ExecInst Invalid
        {
            get { return new ExecInst(); }
        }

        public static ExecInst NotHeld
        {
            get { return new ExecInst("1"); }
        }

        public static ExecInst Work
        {
            get { return new ExecInst("2"); }
        }

        public static ExecInst GoAlong
        {
            get { return new ExecInst("3"); }
        }

        public static ExecInst OverTheDay
        {
            get { return new ExecInst("4"); }
        }

        public static ExecInst Held
        {
            get { return new ExecInst("5"); }
        }

        public static ExecInst ParticipateDontInitiate
        {
            get { return new ExecInst("6"); }
        }

        public static ExecInst StrictScale
        {
            get { return new ExecInst("7"); }
        }

        public static ExecInst TryToScale
        {
            get { return new ExecInst("8"); }
        }

        public static ExecInst StayOnBidside
        {
            get { return new ExecInst("9"); }
        }

        public static ExecInst StayOnOfferside
        {
            get { return new ExecInst("0"); }
        }

        public static ExecInst NoCross
        {
            get { return new ExecInst("A"); }
        }

        public static ExecInst OkToCross
        {
            get { return new ExecInst("B"); }
        }

        public static ExecInst CallFirst
        {
            get { return new ExecInst("C"); }
        }

        public static ExecInst PercentOfVolume
        {
            get { return new ExecInst("D"); }
        }

        public static ExecInst DoNotIncrease
        {
            get { return new ExecInst("E"); }
        }

        public static ExecInst DoNotReduce
        {
            get { return new ExecInst("F"); }
        }

        public static ExecInst AllOrNone
        {
            get { return new ExecInst("G"); }
        }

        public static ExecInst ReinstateOnSystemFailure
        {
            get { return new ExecInst("H"); }
        }

        public static ExecInst InstitutionsOnly
        {
            get { return new ExecInst("I"); }
        }

        public static ExecInst ReinstateOnTradingHalt
        {
            get { return new ExecInst("J"); }
        }

        public static ExecInst CancelOnTradingHalt
        {
            get { return new ExecInst("K"); }
        }

        public static ExecInst LastPeg
        {
            get { return new ExecInst("L"); }
        }

        public static ExecInst MidPrice
        {
            get { return new ExecInst("M"); }
        }

        public static ExecInst NonNegotiable
        {
            get { return new ExecInst("N"); }
        }

        public static ExecInst OpeningPeg
        {
            get { return new ExecInst("O"); }
        }

        public static ExecInst MarketPeg
        {
            get { return new ExecInst("P"); }
        }

        public static ExecInst CancelOnSystemFailure
        {
            get { return new ExecInst("Q"); }
        }

        public static ExecInst PrimaryPeg
        {
            get { return new ExecInst("R"); }
        }

        public static ExecInst Suspend
        {
            get { return new ExecInst("S"); }
        }

        public static ExecInst FixedPegToLocalBestBidOrOfferAtTimeOfOrder
        {
            get { return new ExecInst("T"); }
        }

        public static ExecInst CustomerDisplayInstruction
        {
            get { return new ExecInst("U"); }
        }

        public static ExecInst Netting
        {
            get { return new ExecInst("V"); }
        }

        public static ExecInst PegToVwap
        {
            get { return new ExecInst("W"); }
        }

        public static ExecInst TradeAlong
        {
            get { return new ExecInst("X"); }
        }

        public static ExecInst TryToStop
        {
            get { return new ExecInst("Y"); }
        }

        public static ExecInst CancelIfNotBest
        {
            get { return new ExecInst("Z"); }
        }

        public static ExecInst TrailingStopPeg
        {
            get { return new ExecInst("a"); }
        }

        public static ExecInst StrictLimit
        {
            get { return new ExecInst("b"); }
        }

        public static ExecInst IgnorePriceValidityChecks
        {
            get { return new ExecInst("c"); }
        }

        public static ExecInst PegToLimitPrice
        {
            get { return new ExecInst("d"); }
        }

        public static ExecInst WorkToTargetStrategy
        {
            get { return new ExecInst("e"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct HandlInst : IEquatable<HandlInst>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "AutomatedExecutionOrderPrivate"}, {'2', "AutomatedExecutionOrderPublic"}, {'3', "ManualOrder"},};
        private readonly char? _value;

        private HandlInst(char value)
        {
            _value = value;
        }

        public bool Equals(HandlInst other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is HandlInst && Equals((HandlInst) other);
        }

        public static bool operator ==(HandlInst left, HandlInst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HandlInst left, HandlInst right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static HandlInst FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for HandlInst", nameof(value));

            return new HandlInst(value);
        }

        public static HandlInst FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for HandlInst", nameof(value));

            return new HandlInst(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static HandlInst FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new HandlInst(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static HandlInst Invalid
        {
            get { return new HandlInst(); }
        }

        public static HandlInst AutomatedExecutionOrderPrivate
        {
            get { return new HandlInst('1'); }
        }

        public static HandlInst AutomatedExecutionOrderPublic
        {
            get { return new HandlInst('2'); }
        }

        public static HandlInst ManualOrder
        {
            get { return new HandlInst('3'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityIDSource : IEquatable<SecurityIDSource>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"1", "Cusip"}, {"2", "Sedol"}, {"3", "Quik"}, {"4", "IsinNumber"}, {"5", "RicCode"}, {"6", "IsoCurrencyCode"}, {"7", "IsoCountryCode"}, {"8", "ExchangeSymbol"}, {"9", "ConsolidatedTapeAssociation"}, {"A", "BloombergSymbol"}, {"B", "Wertpapier"}, {"C", "Dutch"}, {"D", "Valoren"}, {"E", "Sicovam"}, {"F", "Belgian"}, {"G", "Common"}, {"H", "ClearingHouseClearingOrganization"}, {"I", "IsdaFpmlProductSpecification"}, {"J", "OptionsPriceReportingAuthority"},};
        private readonly string _value;

        private SecurityIDSource(string value)
        {
            _value = value;
        }

        public bool Equals(SecurityIDSource other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityIDSource && Equals((SecurityIDSource) other);
        }

        public static bool operator ==(SecurityIDSource left, SecurityIDSource right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityIDSource left, SecurityIDSource right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static SecurityIDSource FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityIDSource", nameof(value));

            return new SecurityIDSource(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static SecurityIDSource FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityIDSource(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityIDSource Invalid
        {
            get { return new SecurityIDSource(); }
        }

        public static SecurityIDSource Cusip
        {
            get { return new SecurityIDSource("1"); }
        }

        public static SecurityIDSource Sedol
        {
            get { return new SecurityIDSource("2"); }
        }

        public static SecurityIDSource Quik
        {
            get { return new SecurityIDSource("3"); }
        }

        public static SecurityIDSource IsinNumber
        {
            get { return new SecurityIDSource("4"); }
        }

        public static SecurityIDSource RicCode
        {
            get { return new SecurityIDSource("5"); }
        }

        public static SecurityIDSource IsoCurrencyCode
        {
            get { return new SecurityIDSource("6"); }
        }

        public static SecurityIDSource IsoCountryCode
        {
            get { return new SecurityIDSource("7"); }
        }

        public static SecurityIDSource ExchangeSymbol
        {
            get { return new SecurityIDSource("8"); }
        }

        public static SecurityIDSource ConsolidatedTapeAssociation
        {
            get { return new SecurityIDSource("9"); }
        }

        public static SecurityIDSource BloombergSymbol
        {
            get { return new SecurityIDSource("A"); }
        }

        public static SecurityIDSource Wertpapier
        {
            get { return new SecurityIDSource("B"); }
        }

        public static SecurityIDSource Dutch
        {
            get { return new SecurityIDSource("C"); }
        }

        public static SecurityIDSource Valoren
        {
            get { return new SecurityIDSource("D"); }
        }

        public static SecurityIDSource Sicovam
        {
            get { return new SecurityIDSource("E"); }
        }

        public static SecurityIDSource Belgian
        {
            get { return new SecurityIDSource("F"); }
        }

        public static SecurityIDSource Common
        {
            get { return new SecurityIDSource("G"); }
        }

        public static SecurityIDSource ClearingHouseClearingOrganization
        {
            get { return new SecurityIDSource("H"); }
        }

        public static SecurityIDSource IsdaFpmlProductSpecification
        {
            get { return new SecurityIDSource("I"); }
        }

        public static SecurityIDSource OptionsPriceReportingAuthority
        {
            get { return new SecurityIDSource("J"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct IOIQltyInd : IEquatable<IOIQltyInd>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'L', "Low"}, {'M', "Medium"}, {'H', "High"},};
        private readonly char? _value;

        private IOIQltyInd(char value)
        {
            _value = value;
        }

        public bool Equals(IOIQltyInd other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is IOIQltyInd && Equals((IOIQltyInd) other);
        }

        public static bool operator ==(IOIQltyInd left, IOIQltyInd right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IOIQltyInd left, IOIQltyInd right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static IOIQltyInd FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IOIQltyInd", nameof(value));

            return new IOIQltyInd(value);
        }

        public static IOIQltyInd FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IOIQltyInd", nameof(value));

            return new IOIQltyInd(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static IOIQltyInd FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new IOIQltyInd(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static IOIQltyInd Invalid
        {
            get { return new IOIQltyInd(); }
        }

        public static IOIQltyInd Low
        {
            get { return new IOIQltyInd('L'); }
        }

        public static IOIQltyInd Medium
        {
            get { return new IOIQltyInd('M'); }
        }

        public static IOIQltyInd High
        {
            get { return new IOIQltyInd('H'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct IOITransType : IEquatable<IOITransType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'N', "New"}, {'C', "Cancel"}, {'R', "Replace"},};
        private readonly char? _value;

        private IOITransType(char value)
        {
            _value = value;
        }

        public bool Equals(IOITransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is IOITransType && Equals((IOITransType) other);
        }

        public static bool operator ==(IOITransType left, IOITransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IOITransType left, IOITransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static IOITransType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IOITransType", nameof(value));

            return new IOITransType(value);
        }

        public static IOITransType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IOITransType", nameof(value));

            return new IOITransType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static IOITransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new IOITransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static IOITransType Invalid
        {
            get { return new IOITransType(); }
        }

        public static IOITransType New
        {
            get { return new IOITransType('N'); }
        }

        public static IOITransType Cancel
        {
            get { return new IOITransType('C'); }
        }

        public static IOITransType Replace
        {
            get { return new IOITransType('R'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct LastCapacity : IEquatable<LastCapacity>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "Agent"}, {'2', "CrossAsAgent"}, {'3', "CrossAsPrincipal"}, {'4', "Principal"},};
        private readonly char? _value;

        private LastCapacity(char value)
        {
            _value = value;
        }

        public bool Equals(LastCapacity other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is LastCapacity && Equals((LastCapacity) other);
        }

        public static bool operator ==(LastCapacity left, LastCapacity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LastCapacity left, LastCapacity right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static LastCapacity FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for LastCapacity", nameof(value));

            return new LastCapacity(value);
        }

        public static LastCapacity FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for LastCapacity", nameof(value));

            return new LastCapacity(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static LastCapacity FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new LastCapacity(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static LastCapacity Invalid
        {
            get { return new LastCapacity(); }
        }

        public static LastCapacity Agent
        {
            get { return new LastCapacity('1'); }
        }

        public static LastCapacity CrossAsAgent
        {
            get { return new LastCapacity('2'); }
        }

        public static LastCapacity CrossAsPrincipal
        {
            get { return new LastCapacity('3'); }
        }

        public static LastCapacity Principal
        {
            get { return new LastCapacity('4'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MsgType : IEquatable<MsgType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string>
                                                                     {
                                                                         {"0", "Heartbeat"},
                                                                         {"1", "TestRequest"},
                                                                         {"2", "ResendRequest"},
                                                                         {"3", "Reject"},
                                                                         {"4", "SequenceReset"},
                                                                         {"5", "Logout"},
                                                                         {"6", "IndicationOfInterest"},
                                                                         {"7", "Advertisement"},
                                                                         {"8", "ExecutionReport"},
                                                                         {"9", "OrderCancelReject"},
                                                                         {"A", "Logon"},
                                                                         {"B", "News"},
                                                                         {"C", "Email"},
                                                                         {"D", "OrderSingle"},
                                                                         {"E", "OrderList"},
                                                                         {"F", "OrderCancelRequest"},
                                                                         {"G", "OrderCancelReplaceRequest"},
                                                                         {"H", "OrderStatusRequest"},
                                                                         {"J", "AllocationInstruction"},
                                                                         {"K", "ListCancelRequest"},
                                                                         {"L", "ListExecute"},
                                                                         {"M", "ListStatusRequest"},
                                                                         {"N", "ListStatus"},
                                                                         {"P", "AllocationInstructionAck"},
                                                                         {"Q", "DontKnowTrade"},
                                                                         {"R", "QuoteRequest"},
                                                                         {"S", "Quote"},
                                                                         {"T", "SettlementInstructions"},
                                                                         {"V", "MarketDataRequest"},
                                                                         {"W", "MarketDataSnapshotFullRefresh"},
                                                                         {"X", "MarketDataIncrementalRefresh"},
                                                                         {"Y", "MarketDataRequestReject"},
                                                                         {"Z", "QuoteCancel"},
                                                                         {"a", "QuoteStatusRequest"},
                                                                         {"b", "MassQuoteAcknowledgement"},
                                                                         {"c", "SecurityDefinitionRequest"},
                                                                         {"d", "SecurityDefinition"},
                                                                         {"e", "SecurityStatusRequest"},
                                                                         {"f", "SecurityStatus"},
                                                                         {"g", "TradingSessionStatusRequest"},
                                                                         {"h", "TradingSessionStatus"},
                                                                         {"i", "MassQuote"},
                                                                         {"j", "BusinessMessageReject"},
                                                                         {"k", "BidRequest"},
                                                                         {"l", "BidResponse"},
                                                                         {"m", "ListStrikePrice"},
                                                                         {"n", "XmlMessage"},
                                                                         {"o", "RegistrationInstructions"},
                                                                         {"p", "RegistrationInstructionsResponse"},
                                                                         {"q", "OrderMassCancelRequest"},
                                                                         {"r", "OrderMassCancelReport"},
                                                                         {"s", "NewOrderCross"},
                                                                         {"t", "CrossOrderCancelReplaceRequest"},
                                                                         {"u", "CrossOrderCancelRequest"},
                                                                         {"v", "SecurityTypeRequest"},
                                                                         {"w", "SecurityTypes"},
                                                                         {"x", "SecurityListRequest"},
                                                                         {"y", "SecurityList"},
                                                                         {"z", "DerivativeSecurityListRequest"},
                                                                         {"AA", "DerivativeSecurityList"},
                                                                         {"AB", "NewOrderMultileg"},
                                                                         {"AC", "MultilegOrderCancelReplace"},
                                                                         {"AD", "TradeCaptureReportRequest"},
                                                                         {"AE", "TradeCaptureReport"},
                                                                         {"AF", "OrderMassStatusRequest"},
                                                                         {"AG", "QuoteRequestReject"},
                                                                         {"AH", "RfqRequest"},
                                                                         {"AI", "QuoteStatusReport"},
                                                                         {"AJ", "QuoteResponse"},
                                                                         {"AK", "Confirmation"},
                                                                         {"AL", "PositionMaintenanceRequest"},
                                                                         {"AM", "PositionMaintenanceReport"},
                                                                         {"AN", "RequestForPositions"},
                                                                         {"AO", "RequestForPositionsAck"},
                                                                         {"AP", "PositionReport"},
                                                                         {"AQ", "TradeCaptureReportRequestAck"},
                                                                         {"AR", "TradeCaptureReportAck"},
                                                                         {"AS", "AllocationReport"},
                                                                         {"AT", "AllocationReportAck"},
                                                                         {"AU", "ConfirmationAck"},
                                                                         {"AV", "SettlementInstructionRequest"},
                                                                         {"AW", "AssignmentReport"},
                                                                         {"AX", "CollateralRequest"},
                                                                         {"AY", "CollateralAssignment"},
                                                                         {"AZ", "CollateralResponse"},
                                                                         {"BA", "CollateralReport"},
                                                                         {"BB", "CollateralInquiry"},
                                                                         {"BC", "NetworkStatusRequest"},
                                                                         {"BD", "NetworkStatusResponse"},
                                                                         {"BE", "UserRequest"},
                                                                         {"BF", "UserResponse"},
                                                                         {"BG", "CollateralInquiryAck"},
                                                                         {"BH", "ConfirmationRequest"},
                                                                     };

        private readonly string _value;

        private MsgType(string value)
        {
            _value = value;
        }

        public bool Equals(MsgType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MsgType && Equals((MsgType) other);
        }

        public static bool operator ==(MsgType left, MsgType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MsgType left, MsgType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static MsgType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MsgType", nameof(value));

            return new MsgType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static MsgType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MsgType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MsgType Invalid
        {
            get { return new MsgType(); }
        }

        public static MsgType Heartbeat
        {
            get { return new MsgType("0"); }
        }

        public static MsgType TestRequest
        {
            get { return new MsgType("1"); }
        }

        public static MsgType ResendRequest
        {
            get { return new MsgType("2"); }
        }

        public static MsgType Reject
        {
            get { return new MsgType("3"); }
        }

        public static MsgType SequenceReset
        {
            get { return new MsgType("4"); }
        }

        public static MsgType Logout
        {
            get { return new MsgType("5"); }
        }

        public static MsgType IndicationOfInterest
        {
            get { return new MsgType("6"); }
        }

        public static MsgType Advertisement
        {
            get { return new MsgType("7"); }
        }

        public static MsgType ExecutionReport
        {
            get { return new MsgType("8"); }
        }

        public static MsgType OrderCancelReject
        {
            get { return new MsgType("9"); }
        }

        public static MsgType Logon
        {
            get { return new MsgType("A"); }
        }

        public static MsgType News
        {
            get { return new MsgType("B"); }
        }

        public static MsgType Email
        {
            get { return new MsgType("C"); }
        }

        public static MsgType OrderSingle
        {
            get { return new MsgType("D"); }
        }

        public static MsgType OrderList
        {
            get { return new MsgType("E"); }
        }

        public static MsgType OrderCancelRequest
        {
            get { return new MsgType("F"); }
        }

        public static MsgType OrderCancelReplaceRequest
        {
            get { return new MsgType("G"); }
        }

        public static MsgType OrderStatusRequest
        {
            get { return new MsgType("H"); }
        }

        public static MsgType AllocationInstruction
        {
            get { return new MsgType("J"); }
        }

        public static MsgType ListCancelRequest
        {
            get { return new MsgType("K"); }
        }

        public static MsgType ListExecute
        {
            get { return new MsgType("L"); }
        }

        public static MsgType ListStatusRequest
        {
            get { return new MsgType("M"); }
        }

        public static MsgType ListStatus
        {
            get { return new MsgType("N"); }
        }

        public static MsgType AllocationInstructionAck
        {
            get { return new MsgType("P"); }
        }

        public static MsgType DontKnowTrade
        {
            get { return new MsgType("Q"); }
        }

        public static MsgType QuoteRequest
        {
            get { return new MsgType("R"); }
        }

        public static MsgType Quote
        {
            get { return new MsgType("S"); }
        }

        public static MsgType SettlementInstructions
        {
            get { return new MsgType("T"); }
        }

        public static MsgType MarketDataRequest
        {
            get { return new MsgType("V"); }
        }

        public static MsgType MarketDataSnapshotFullRefresh
        {
            get { return new MsgType("W"); }
        }

        public static MsgType MarketDataIncrementalRefresh
        {
            get { return new MsgType("X"); }
        }

        public static MsgType MarketDataRequestReject
        {
            get { return new MsgType("Y"); }
        }

        public static MsgType QuoteCancel
        {
            get { return new MsgType("Z"); }
        }

        public static MsgType QuoteStatusRequest
        {
            get { return new MsgType("a"); }
        }

        public static MsgType MassQuoteAcknowledgement
        {
            get { return new MsgType("b"); }
        }

        public static MsgType SecurityDefinitionRequest
        {
            get { return new MsgType("c"); }
        }

        public static MsgType SecurityDefinition
        {
            get { return new MsgType("d"); }
        }

        public static MsgType SecurityStatusRequest
        {
            get { return new MsgType("e"); }
        }

        public static MsgType SecurityStatus
        {
            get { return new MsgType("f"); }
        }

        public static MsgType TradingSessionStatusRequest
        {
            get { return new MsgType("g"); }
        }

        public static MsgType TradingSessionStatus
        {
            get { return new MsgType("h"); }
        }

        public static MsgType MassQuote
        {
            get { return new MsgType("i"); }
        }

        public static MsgType BusinessMessageReject
        {
            get { return new MsgType("j"); }
        }

        public static MsgType BidRequest
        {
            get { return new MsgType("k"); }
        }

        public static MsgType BidResponse
        {
            get { return new MsgType("l"); }
        }

        public static MsgType ListStrikePrice
        {
            get { return new MsgType("m"); }
        }

        public static MsgType XmlMessage
        {
            get { return new MsgType("n"); }
        }

        public static MsgType RegistrationInstructions
        {
            get { return new MsgType("o"); }
        }

        public static MsgType RegistrationInstructionsResponse
        {
            get { return new MsgType("p"); }
        }

        public static MsgType OrderMassCancelRequest
        {
            get { return new MsgType("q"); }
        }

        public static MsgType OrderMassCancelReport
        {
            get { return new MsgType("r"); }
        }

        public static MsgType NewOrderCross
        {
            get { return new MsgType("s"); }
        }

        public static MsgType CrossOrderCancelReplaceRequest
        {
            get { return new MsgType("t"); }
        }

        public static MsgType CrossOrderCancelRequest
        {
            get { return new MsgType("u"); }
        }

        public static MsgType SecurityTypeRequest
        {
            get { return new MsgType("v"); }
        }

        public static MsgType SecurityTypes
        {
            get { return new MsgType("w"); }
        }

        public static MsgType SecurityListRequest
        {
            get { return new MsgType("x"); }
        }

        public static MsgType SecurityList
        {
            get { return new MsgType("y"); }
        }

        public static MsgType DerivativeSecurityListRequest
        {
            get { return new MsgType("z"); }
        }

        public static MsgType DerivativeSecurityList
        {
            get { return new MsgType("AA"); }
        }

        public static MsgType NewOrderMultileg
        {
            get { return new MsgType("AB"); }
        }

        public static MsgType MultilegOrderCancelReplace
        {
            get { return new MsgType("AC"); }
        }

        public static MsgType TradeCaptureReportRequest
        {
            get { return new MsgType("AD"); }
        }

        public static MsgType TradeCaptureReport
        {
            get { return new MsgType("AE"); }
        }

        public static MsgType OrderMassStatusRequest
        {
            get { return new MsgType("AF"); }
        }

        public static MsgType QuoteRequestReject
        {
            get { return new MsgType("AG"); }
        }

        public static MsgType RfqRequest
        {
            get { return new MsgType("AH"); }
        }

        public static MsgType QuoteStatusReport
        {
            get { return new MsgType("AI"); }
        }

        public static MsgType QuoteResponse
        {
            get { return new MsgType("AJ"); }
        }

        public static MsgType Confirmation
        {
            get { return new MsgType("AK"); }
        }

        public static MsgType PositionMaintenanceRequest
        {
            get { return new MsgType("AL"); }
        }

        public static MsgType PositionMaintenanceReport
        {
            get { return new MsgType("AM"); }
        }

        public static MsgType RequestForPositions
        {
            get { return new MsgType("AN"); }
        }

        public static MsgType RequestForPositionsAck
        {
            get { return new MsgType("AO"); }
        }

        public static MsgType PositionReport
        {
            get { return new MsgType("AP"); }
        }

        public static MsgType TradeCaptureReportRequestAck
        {
            get { return new MsgType("AQ"); }
        }

        public static MsgType TradeCaptureReportAck
        {
            get { return new MsgType("AR"); }
        }

        public static MsgType AllocationReport
        {
            get { return new MsgType("AS"); }
        }

        public static MsgType AllocationReportAck
        {
            get { return new MsgType("AT"); }
        }

        public static MsgType ConfirmationAck
        {
            get { return new MsgType("AU"); }
        }

        public static MsgType SettlementInstructionRequest
        {
            get { return new MsgType("AV"); }
        }

        public static MsgType AssignmentReport
        {
            get { return new MsgType("AW"); }
        }

        public static MsgType CollateralRequest
        {
            get { return new MsgType("AX"); }
        }

        public static MsgType CollateralAssignment
        {
            get { return new MsgType("AY"); }
        }

        public static MsgType CollateralResponse
        {
            get { return new MsgType("AZ"); }
        }

        public static MsgType CollateralReport
        {
            get { return new MsgType("BA"); }
        }

        public static MsgType CollateralInquiry
        {
            get { return new MsgType("BB"); }
        }

        public static MsgType NetworkStatusRequest
        {
            get { return new MsgType("BC"); }
        }

        public static MsgType NetworkStatusResponse
        {
            get { return new MsgType("BD"); }
        }

        public static MsgType UserRequest
        {
            get { return new MsgType("BE"); }
        }

        public static MsgType UserResponse
        {
            get { return new MsgType("BF"); }
        }

        public static MsgType CollateralInquiryAck
        {
            get { return new MsgType("BG"); }
        }

        public static MsgType ConfirmationRequest
        {
            get { return new MsgType("BH"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OrdStatus : IEquatable<OrdStatus>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "New"}, {'1', "PartiallyFilled"}, {'2', "Filled"}, {'3', "DoneForDay"}, {'4', "Canceled"}, {'5', "Replaced"}, {'6', "PendingCancel"}, {'7', "Stopped"}, {'8', "Rejected"}, {'9', "Suspended"}, {'A', "PendingNew"}, {'B', "Calculated"}, {'C', "Expired"}, {'D', "AcceptedForBidding"}, {'E', "PendingReplace"},};
        private readonly char? _value;

        private OrdStatus(char value)
        {
            _value = value;
        }

        public bool Equals(OrdStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OrdStatus && Equals((OrdStatus) other);
        }

        public static bool operator ==(OrdStatus left, OrdStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OrdStatus left, OrdStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static OrdStatus FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrdStatus", nameof(value));

            return new OrdStatus(value);
        }

        public static OrdStatus FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrdStatus", nameof(value));

            return new OrdStatus(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static OrdStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OrdStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OrdStatus Invalid
        {
            get { return new OrdStatus(); }
        }

        public static OrdStatus New
        {
            get { return new OrdStatus('0'); }
        }

        public static OrdStatus PartiallyFilled
        {
            get { return new OrdStatus('1'); }
        }

        public static OrdStatus Filled
        {
            get { return new OrdStatus('2'); }
        }

        public static OrdStatus DoneForDay
        {
            get { return new OrdStatus('3'); }
        }

        public static OrdStatus Canceled
        {
            get { return new OrdStatus('4'); }
        }

        public static OrdStatus Replaced
        {
            get { return new OrdStatus('5'); }
        }

        public static OrdStatus PendingCancel
        {
            get { return new OrdStatus('6'); }
        }

        public static OrdStatus Stopped
        {
            get { return new OrdStatus('7'); }
        }

        public static OrdStatus Rejected
        {
            get { return new OrdStatus('8'); }
        }

        public static OrdStatus Suspended
        {
            get { return new OrdStatus('9'); }
        }

        public static OrdStatus PendingNew
        {
            get { return new OrdStatus('A'); }
        }

        public static OrdStatus Calculated
        {
            get { return new OrdStatus('B'); }
        }

        public static OrdStatus Expired
        {
            get { return new OrdStatus('C'); }
        }

        public static OrdStatus AcceptedForBidding
        {
            get { return new OrdStatus('D'); }
        }

        public static OrdStatus PendingReplace
        {
            get { return new OrdStatus('E'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OrdType : IEquatable<OrdType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "Market"}, {'2', "Limit"}, {'3', "Stop"}, {'4', "StopLimit"}, {'5', "MarketOnClose"}, {'6', "WithOrWithout"}, {'7', "LimitOrBetter"}, {'8', "LimitWithOrWithout"}, {'9', "OnBasis"}, {'A', "OnClose"}, {'B', "LimitOnClose"}, {'C', "ForexMarket"}, {'D', "PreviouslyQuoted"}, {'E', "PreviouslyIndicated"}, {'F', "ForexLimit"}, {'G', "ForexSwap"}, {'H', "ForexPreviouslyQuoted"}, {'I', "Funari"}, {'J', "MarketIfTouched"}, {'K', "MarketWithLeftoverAsLimit"}, {'L', "PreviousFundValuationPoint"}, {'M', "NextFundValuationPoint"}, {'P', "Pegged"},};
        private readonly char? _value;

        private OrdType(char value)
        {
            _value = value;
        }

        public bool Equals(OrdType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OrdType && Equals((OrdType) other);
        }

        public static bool operator ==(OrdType left, OrdType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OrdType left, OrdType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static OrdType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrdType", nameof(value));

            return new OrdType(value);
        }

        public static OrdType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrdType", nameof(value));

            return new OrdType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static OrdType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OrdType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OrdType Invalid
        {
            get { return new OrdType(); }
        }

        public static OrdType Market
        {
            get { return new OrdType('1'); }
        }

        public static OrdType Limit
        {
            get { return new OrdType('2'); }
        }

        public static OrdType Stop
        {
            get { return new OrdType('3'); }
        }

        public static OrdType StopLimit
        {
            get { return new OrdType('4'); }
        }

        public static OrdType MarketOnClose
        {
            get { return new OrdType('5'); }
        }

        public static OrdType WithOrWithout
        {
            get { return new OrdType('6'); }
        }

        public static OrdType LimitOrBetter
        {
            get { return new OrdType('7'); }
        }

        public static OrdType LimitWithOrWithout
        {
            get { return new OrdType('8'); }
        }

        public static OrdType OnBasis
        {
            get { return new OrdType('9'); }
        }

        public static OrdType OnClose
        {
            get { return new OrdType('A'); }
        }

        public static OrdType LimitOnClose
        {
            get { return new OrdType('B'); }
        }

        public static OrdType ForexMarket
        {
            get { return new OrdType('C'); }
        }

        public static OrdType PreviouslyQuoted
        {
            get { return new OrdType('D'); }
        }

        public static OrdType PreviouslyIndicated
        {
            get { return new OrdType('E'); }
        }

        public static OrdType ForexLimit
        {
            get { return new OrdType('F'); }
        }

        public static OrdType ForexSwap
        {
            get { return new OrdType('G'); }
        }

        public static OrdType ForexPreviouslyQuoted
        {
            get { return new OrdType('H'); }
        }

        public static OrdType Funari
        {
            get { return new OrdType('I'); }
        }

        public static OrdType MarketIfTouched
        {
            get { return new OrdType('J'); }
        }

        public static OrdType MarketWithLeftoverAsLimit
        {
            get { return new OrdType('K'); }
        }

        public static OrdType PreviousFundValuationPoint
        {
            get { return new OrdType('L'); }
        }

        public static OrdType NextFundValuationPoint
        {
            get { return new OrdType('M'); }
        }

        public static OrdType Pegged
        {
            get { return new OrdType('P'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct Side : IEquatable<Side>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "Buy"}, {'2', "Sell"}, {'3', "BuyMinus"}, {'4', "SellPlus"}, {'5', "SellShort"}, {'6', "SellShortExempt"}, {'7', "Undisclosed"}, {'8', "Cross"}, {'9', "CrossShort"}, {'A', "CrossShortExempt"}, {'B', "AsDefined"}, {'C', "Opposite"}, {'D', "Subscribe"}, {'E', "Redeem"}, {'F', "Lend"}, {'G', "Borrow"},};
        private readonly char? _value;

        private Side(char value)
        {
            _value = value;
        }

        public bool Equals(Side other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is Side && Equals((Side) other);
        }

        public static bool operator ==(Side left, Side right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Side left, Side right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static Side FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Side", nameof(value));

            return new Side(value);
        }

        public static Side FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Side", nameof(value));

            return new Side(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static Side FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new Side(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static Side Invalid
        {
            get { return new Side(); }
        }

        public static Side Buy
        {
            get { return new Side('1'); }
        }

        public static Side Sell
        {
            get { return new Side('2'); }
        }

        public static Side BuyMinus
        {
            get { return new Side('3'); }
        }

        public static Side SellPlus
        {
            get { return new Side('4'); }
        }

        public static Side SellShort
        {
            get { return new Side('5'); }
        }

        public static Side SellShortExempt
        {
            get { return new Side('6'); }
        }

        public static Side Undisclosed
        {
            get { return new Side('7'); }
        }

        public static Side Cross
        {
            get { return new Side('8'); }
        }

        public static Side CrossShort
        {
            get { return new Side('9'); }
        }

        public static Side CrossShortExempt
        {
            get { return new Side('A'); }
        }

        public static Side AsDefined
        {
            get { return new Side('B'); }
        }

        public static Side Opposite
        {
            get { return new Side('C'); }
        }

        public static Side Subscribe
        {
            get { return new Side('D'); }
        }

        public static Side Redeem
        {
            get { return new Side('E'); }
        }

        public static Side Lend
        {
            get { return new Side('F'); }
        }

        public static Side Borrow
        {
            get { return new Side('G'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TimeInForce : IEquatable<TimeInForce>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Day"}, {'1', "GoodTillCancel"}, {'2', "AtTheOpening"}, {'3', "ImmediateOrCancel"}, {'4', "FillOrKill"}, {'5', "GoodTillCrossing"}, {'6', "GoodTillDate"}, {'7', "AtTheClose"},};
        private readonly char? _value;

        private TimeInForce(char value)
        {
            _value = value;
        }

        public bool Equals(TimeInForce other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TimeInForce && Equals((TimeInForce) other);
        }

        public static bool operator ==(TimeInForce left, TimeInForce right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimeInForce left, TimeInForce right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TimeInForce FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TimeInForce", nameof(value));

            return new TimeInForce(value);
        }

        public static TimeInForce FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TimeInForce", nameof(value));

            return new TimeInForce(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TimeInForce FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TimeInForce(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TimeInForce Invalid
        {
            get { return new TimeInForce(); }
        }

        public static TimeInForce Day
        {
            get { return new TimeInForce('0'); }
        }

        public static TimeInForce GoodTillCancel
        {
            get { return new TimeInForce('1'); }
        }

        public static TimeInForce AtTheOpening
        {
            get { return new TimeInForce('2'); }
        }

        public static TimeInForce ImmediateOrCancel
        {
            get { return new TimeInForce('3'); }
        }

        public static TimeInForce FillOrKill
        {
            get { return new TimeInForce('4'); }
        }

        public static TimeInForce GoodTillCrossing
        {
            get { return new TimeInForce('5'); }
        }

        public static TimeInForce GoodTillDate
        {
            get { return new TimeInForce('6'); }
        }

        public static TimeInForce AtTheClose
        {
            get { return new TimeInForce('7'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct Urgency : IEquatable<Urgency>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Normal"}, {'1', "Flash"}, {'2', "Background"},};
        private readonly char? _value;

        private Urgency(char value)
        {
            _value = value;
        }

        public bool Equals(Urgency other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is Urgency && Equals((Urgency) other);
        }

        public static bool operator ==(Urgency left, Urgency right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Urgency left, Urgency right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static Urgency FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Urgency", nameof(value));

            return new Urgency(value);
        }

        public static Urgency FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Urgency", nameof(value));

            return new Urgency(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static Urgency FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new Urgency(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static Urgency Invalid
        {
            get { return new Urgency(); }
        }

        public static Urgency Normal
        {
            get { return new Urgency('0'); }
        }

        public static Urgency Flash
        {
            get { return new Urgency('1'); }
        }

        public static Urgency Background
        {
            get { return new Urgency('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlType : IEquatable<SettlType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Regular"}, {'1', "Cash"}, {'2', "NextDay"}, {'3', "TPlus2"}, {'4', "TPlus3"}, {'5', "TPlus4"}, {'6', "Future"}, {'7', "WhenAndIfIssued"}, {'8', "SellersOption"}, {'9', "TPlus5"},};
        private readonly char? _value;

        private SettlType(char value)
        {
            _value = value;
        }

        public bool Equals(SettlType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlType && Equals((SettlType) other);
        }

        public static bool operator ==(SettlType left, SettlType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlType left, SettlType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlType", nameof(value));

            return new SettlType(value);
        }

        public static SettlType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlType", nameof(value));

            return new SettlType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlType Invalid
        {
            get { return new SettlType(); }
        }

        public static SettlType Regular
        {
            get { return new SettlType('0'); }
        }

        public static SettlType Cash
        {
            get { return new SettlType('1'); }
        }

        public static SettlType NextDay
        {
            get { return new SettlType('2'); }
        }

        public static SettlType TPlus2
        {
            get { return new SettlType('3'); }
        }

        public static SettlType TPlus3
        {
            get { return new SettlType('4'); }
        }

        public static SettlType TPlus4
        {
            get { return new SettlType('5'); }
        }

        public static SettlType Future
        {
            get { return new SettlType('6'); }
        }

        public static SettlType WhenAndIfIssued
        {
            get { return new SettlType('7'); }
        }

        public static SettlType SellersOption
        {
            get { return new SettlType('8'); }
        }

        public static SettlType TPlus5
        {
            get { return new SettlType('9'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SymbolSfx : IEquatable<SymbolSfx>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"WI", "WhenIssued"}, {"CD", "AEucpWithLumpSumInterest"},};
        private readonly string _value;

        private SymbolSfx(string value)
        {
            _value = value;
        }

        public bool Equals(SymbolSfx other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SymbolSfx && Equals((SymbolSfx) other);
        }

        public static bool operator ==(SymbolSfx left, SymbolSfx right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SymbolSfx left, SymbolSfx right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static SymbolSfx FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SymbolSfx", nameof(value));

            return new SymbolSfx(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static SymbolSfx FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SymbolSfx(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SymbolSfx Invalid
        {
            get { return new SymbolSfx(); }
        }

        public static SymbolSfx WhenIssued
        {
            get { return new SymbolSfx("WI"); }
        }

        public static SymbolSfx AEucpWithLumpSumInterest
        {
            get { return new SymbolSfx("CD"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocTransType : IEquatable<AllocTransType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "New"}, {'1', "Replace"}, {'2', "Cancel"},};
        private readonly char? _value;

        private AllocTransType(char value)
        {
            _value = value;
        }

        public bool Equals(AllocTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocTransType && Equals((AllocTransType) other);
        }

        public static bool operator ==(AllocTransType left, AllocTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocTransType left, AllocTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocTransType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocTransType", nameof(value));

            return new AllocTransType(value);
        }

        public static AllocTransType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocTransType", nameof(value));

            return new AllocTransType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocTransType Invalid
        {
            get { return new AllocTransType(); }
        }

        public static AllocTransType New
        {
            get { return new AllocTransType('0'); }
        }

        public static AllocTransType Replace
        {
            get { return new AllocTransType('1'); }
        }

        public static AllocTransType Cancel
        {
            get { return new AllocTransType('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PositionEffect : IEquatable<PositionEffect>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'O', "Open"}, {'C', "Close"}, {'R', "Rolled"}, {'F', "Fifo"},};
        private readonly char? _value;

        private PositionEffect(char value)
        {
            _value = value;
        }

        public bool Equals(PositionEffect other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PositionEffect && Equals((PositionEffect) other);
        }

        public static bool operator ==(PositionEffect left, PositionEffect right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PositionEffect left, PositionEffect right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PositionEffect FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PositionEffect", nameof(value));

            return new PositionEffect(value);
        }

        public static PositionEffect FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PositionEffect", nameof(value));

            return new PositionEffect(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PositionEffect FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PositionEffect(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PositionEffect Invalid
        {
            get { return new PositionEffect(); }
        }

        public static PositionEffect Open
        {
            get { return new PositionEffect('O'); }
        }

        public static PositionEffect Close
        {
            get { return new PositionEffect('C'); }
        }

        public static PositionEffect Rolled
        {
            get { return new PositionEffect('R'); }
        }

        public static PositionEffect Fifo
        {
            get { return new PositionEffect('F'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ProcessCode : IEquatable<ProcessCode>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Regular"}, {'1', "SoftDollar"}, {'2', "StepIn"}, {'3', "StepOut"}, {'4', "SoftDollarStepIn"}, {'5', "SoftDollarStepOut"}, {'6', "PlanSponsor"},};
        private readonly char? _value;

        private ProcessCode(char value)
        {
            _value = value;
        }

        public bool Equals(ProcessCode other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ProcessCode && Equals((ProcessCode) other);
        }

        public static bool operator ==(ProcessCode left, ProcessCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ProcessCode left, ProcessCode right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ProcessCode FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ProcessCode", nameof(value));

            return new ProcessCode(value);
        }

        public static ProcessCode FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ProcessCode", nameof(value));

            return new ProcessCode(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ProcessCode FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ProcessCode(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ProcessCode Invalid
        {
            get { return new ProcessCode(); }
        }

        public static ProcessCode Regular
        {
            get { return new ProcessCode('0'); }
        }

        public static ProcessCode SoftDollar
        {
            get { return new ProcessCode('1'); }
        }

        public static ProcessCode StepIn
        {
            get { return new ProcessCode('2'); }
        }

        public static ProcessCode StepOut
        {
            get { return new ProcessCode('3'); }
        }

        public static ProcessCode SoftDollarStepIn
        {
            get { return new ProcessCode('4'); }
        }

        public static ProcessCode SoftDollarStepOut
        {
            get { return new ProcessCode('5'); }
        }

        public static ProcessCode PlanSponsor
        {
            get { return new ProcessCode('6'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocStatus : IEquatable<AllocStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Accepted"}, {1, "BlockLevelReject"}, {2, "AccountLevelReject"}, {3, "Received"}, {4, "Incomplete"}, {5, "RejectedByIntermediary"},};
        private readonly int? _value;

        private AllocStatus(int value)
        {
            _value = value;
        }

        public bool Equals(AllocStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocStatus && Equals((AllocStatus) other);
        }

        public static bool operator ==(AllocStatus left, AllocStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocStatus left, AllocStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocStatus", nameof(value));

            return new AllocStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocStatus Invalid
        {
            get { return new AllocStatus(); }
        }

        public static AllocStatus Accepted
        {
            get { return new AllocStatus(0); }
        }

        public static AllocStatus BlockLevelReject
        {
            get { return new AllocStatus(1); }
        }

        public static AllocStatus AccountLevelReject
        {
            get { return new AllocStatus(2); }
        }

        public static AllocStatus Received
        {
            get { return new AllocStatus(3); }
        }

        public static AllocStatus Incomplete
        {
            get { return new AllocStatus(4); }
        }

        public static AllocStatus RejectedByIntermediary
        {
            get { return new AllocStatus(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocRejCode : IEquatable<AllocRejCode>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "UnknownAccount"}, {1, "IncorrectQuantity"}, {2, "IncorrectAveragePrice"}, {3, "UnknownExecutingBrokerMnemonic"}, {4, "CommissionDifference"}, {5, "UnknownOrderid"}, {6, "UnknownListid"}, {7, "Other"}, {8, "IncorrectAllocatedQuantity"}, {9, "CalculationDifference"}, {10, "UnknownOrStaleExecId"}, {11, "MismatchedDataValue"}, {12, "UnknownClordid"}, {13, "WarehouseRequestRejected"},};
        private readonly int? _value;

        private AllocRejCode(int value)
        {
            _value = value;
        }

        public bool Equals(AllocRejCode other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocRejCode && Equals((AllocRejCode) other);
        }

        public static bool operator ==(AllocRejCode left, AllocRejCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocRejCode left, AllocRejCode right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocRejCode FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocRejCode", nameof(value));

            return new AllocRejCode(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocRejCode FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocRejCode(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocRejCode Invalid
        {
            get { return new AllocRejCode(); }
        }

        public static AllocRejCode UnknownAccount
        {
            get { return new AllocRejCode(0); }
        }

        public static AllocRejCode IncorrectQuantity
        {
            get { return new AllocRejCode(1); }
        }

        public static AllocRejCode IncorrectAveragePrice
        {
            get { return new AllocRejCode(2); }
        }

        public static AllocRejCode UnknownExecutingBrokerMnemonic
        {
            get { return new AllocRejCode(3); }
        }

        public static AllocRejCode CommissionDifference
        {
            get { return new AllocRejCode(4); }
        }

        public static AllocRejCode UnknownOrderid
        {
            get { return new AllocRejCode(5); }
        }

        public static AllocRejCode UnknownListid
        {
            get { return new AllocRejCode(6); }
        }

        public static AllocRejCode Other
        {
            get { return new AllocRejCode(7); }
        }

        public static AllocRejCode IncorrectAllocatedQuantity
        {
            get { return new AllocRejCode(8); }
        }

        public static AllocRejCode CalculationDifference
        {
            get { return new AllocRejCode(9); }
        }

        public static AllocRejCode UnknownOrStaleExecId
        {
            get { return new AllocRejCode(10); }
        }

        public static AllocRejCode MismatchedDataValue
        {
            get { return new AllocRejCode(11); }
        }

        public static AllocRejCode UnknownClordid
        {
            get { return new AllocRejCode(12); }
        }

        public static AllocRejCode WarehouseRequestRejected
        {
            get { return new AllocRejCode(13); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct EmailType : IEquatable<EmailType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "New"}, {'1', "Reply"}, {'2', "AdminReply"},};
        private readonly char? _value;

        private EmailType(char value)
        {
            _value = value;
        }

        public bool Equals(EmailType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is EmailType && Equals((EmailType) other);
        }

        public static bool operator ==(EmailType left, EmailType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EmailType left, EmailType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static EmailType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for EmailType", nameof(value));

            return new EmailType(value);
        }

        public static EmailType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for EmailType", nameof(value));

            return new EmailType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static EmailType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new EmailType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static EmailType Invalid
        {
            get { return new EmailType(); }
        }

        public static EmailType New
        {
            get { return new EmailType('0'); }
        }

        public static EmailType Reply
        {
            get { return new EmailType('1'); }
        }

        public static EmailType AdminReply
        {
            get { return new EmailType('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct EncryptMethod : IEquatable<EncryptMethod>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "NoneOther"}, {1, "Pkcs"}, {2, "Des"}, {3, "PkcsDes"}, {4, "PgpDes"}, {5, "PgpDesMd5"}, {6, "PemDesMd5"},};
        private readonly int? _value;

        private EncryptMethod(int value)
        {
            _value = value;
        }

        public bool Equals(EncryptMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is EncryptMethod && Equals((EncryptMethod) other);
        }

        public static bool operator ==(EncryptMethod left, EncryptMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EncryptMethod left, EncryptMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static EncryptMethod FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for EncryptMethod", nameof(value));

            return new EncryptMethod(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static EncryptMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new EncryptMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static EncryptMethod Invalid
        {
            get { return new EncryptMethod(); }
        }

        public static EncryptMethod NoneOther
        {
            get { return new EncryptMethod(0); }
        }

        public static EncryptMethod Pkcs
        {
            get { return new EncryptMethod(1); }
        }

        public static EncryptMethod Des
        {
            get { return new EncryptMethod(2); }
        }

        public static EncryptMethod PkcsDes
        {
            get { return new EncryptMethod(3); }
        }

        public static EncryptMethod PgpDes
        {
            get { return new EncryptMethod(4); }
        }

        public static EncryptMethod PgpDesMd5
        {
            get { return new EncryptMethod(5); }
        }

        public static EncryptMethod PemDesMd5
        {
            get { return new EncryptMethod(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CxlRejReason : IEquatable<CxlRejReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "TooLateToCancel"}, {1, "UnknownOrder"}, {2, "BrokerExchangeOption"}, {3, "OrderAlreadyInPendingCancelOrPendingReplaceStatus"}, {4, "UnableToProcessOrderMassCancelRequest"}, {5, "OrigordmodtimeDidNotMatchLastTransacttimeOfOrder"}, {6, "DuplicateClordidReceived"}, {99, "Other"},};
        private readonly int? _value;

        private CxlRejReason(int value)
        {
            _value = value;
        }

        public bool Equals(CxlRejReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CxlRejReason && Equals((CxlRejReason) other);
        }

        public static bool operator ==(CxlRejReason left, CxlRejReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CxlRejReason left, CxlRejReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CxlRejReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CxlRejReason", nameof(value));

            return new CxlRejReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CxlRejReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CxlRejReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CxlRejReason Invalid
        {
            get { return new CxlRejReason(); }
        }

        public static CxlRejReason TooLateToCancel
        {
            get { return new CxlRejReason(0); }
        }

        public static CxlRejReason UnknownOrder
        {
            get { return new CxlRejReason(1); }
        }

        public static CxlRejReason BrokerExchangeOption
        {
            get { return new CxlRejReason(2); }
        }

        public static CxlRejReason OrderAlreadyInPendingCancelOrPendingReplaceStatus
        {
            get { return new CxlRejReason(3); }
        }

        public static CxlRejReason UnableToProcessOrderMassCancelRequest
        {
            get { return new CxlRejReason(4); }
        }

        public static CxlRejReason OrigordmodtimeDidNotMatchLastTransacttimeOfOrder
        {
            get { return new CxlRejReason(5); }
        }

        public static CxlRejReason DuplicateClordidReceived
        {
            get { return new CxlRejReason(6); }
        }

        public static CxlRejReason Other
        {
            get { return new CxlRejReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OrdRejReason : IEquatable<OrdRejReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "BrokerExchangeOption"}, {1, "UnknownSymbol"}, {2, "ExchangeClosed"}, {3, "OrderExceedsLimit"}, {4, "TooLateToEnter"}, {5, "UnknownOrder"}, {6, "DuplicateOrder"}, {7, "DuplicateOfAVerballyCommunicatedOrder"}, {8, "StaleOrder"}, {9, "TradeAlongRequired"}, {10, "InvalidInvestorId"}, {11, "UnsupportedOrderCharacteristic"}, {12, "SurveillenceOption"}, {13, "IncorrectQuantity"}, {14, "IncorrectAllocatedQuantity"}, {15, "UnknownAccount"}, {99, "Other"},};
        private readonly int? _value;

        private OrdRejReason(int value)
        {
            _value = value;
        }

        public bool Equals(OrdRejReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OrdRejReason && Equals((OrdRejReason) other);
        }

        public static bool operator ==(OrdRejReason left, OrdRejReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OrdRejReason left, OrdRejReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static OrdRejReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrdRejReason", nameof(value));

            return new OrdRejReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static OrdRejReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OrdRejReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OrdRejReason Invalid
        {
            get { return new OrdRejReason(); }
        }

        public static OrdRejReason BrokerExchangeOption
        {
            get { return new OrdRejReason(0); }
        }

        public static OrdRejReason UnknownSymbol
        {
            get { return new OrdRejReason(1); }
        }

        public static OrdRejReason ExchangeClosed
        {
            get { return new OrdRejReason(2); }
        }

        public static OrdRejReason OrderExceedsLimit
        {
            get { return new OrdRejReason(3); }
        }

        public static OrdRejReason TooLateToEnter
        {
            get { return new OrdRejReason(4); }
        }

        public static OrdRejReason UnknownOrder
        {
            get { return new OrdRejReason(5); }
        }

        public static OrdRejReason DuplicateOrder
        {
            get { return new OrdRejReason(6); }
        }

        public static OrdRejReason DuplicateOfAVerballyCommunicatedOrder
        {
            get { return new OrdRejReason(7); }
        }

        public static OrdRejReason StaleOrder
        {
            get { return new OrdRejReason(8); }
        }

        public static OrdRejReason TradeAlongRequired
        {
            get { return new OrdRejReason(9); }
        }

        public static OrdRejReason InvalidInvestorId
        {
            get { return new OrdRejReason(10); }
        }

        public static OrdRejReason UnsupportedOrderCharacteristic
        {
            get { return new OrdRejReason(11); }
        }

        public static OrdRejReason SurveillenceOption
        {
            get { return new OrdRejReason(12); }
        }

        public static OrdRejReason IncorrectQuantity
        {
            get { return new OrdRejReason(13); }
        }

        public static OrdRejReason IncorrectAllocatedQuantity
        {
            get { return new OrdRejReason(14); }
        }

        public static OrdRejReason UnknownAccount
        {
            get { return new OrdRejReason(15); }
        }

        public static OrdRejReason Other
        {
            get { return new OrdRejReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct IOIQualifier : IEquatable<IOIQualifier>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'A', "AllOrNone"}, {'B', "MarketOnClose"}, {'C', "AtTheClose"}, {'D', "Vwap"}, {'I', "InTouchWith"}, {'L', "Limit"}, {'M', "MoreBehind"}, {'O', "AtTheOpen"}, {'P', "TakingAPosition"}, {'Q', "AtTheMarket"}, {'R', "ReadyToTrade"}, {'S', "PortfolioShown"}, {'T', "ThroughTheDay"}, {'V', "Versus"}, {'W', "IndicationWorkingAway"}, {'X', "CrossingOpportunity"}, {'Y', "AtTheMidpoint"}, {'Z', "PreOpen"},};
        private readonly char? _value;

        private IOIQualifier(char value)
        {
            _value = value;
        }

        public bool Equals(IOIQualifier other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is IOIQualifier && Equals((IOIQualifier) other);
        }

        public static bool operator ==(IOIQualifier left, IOIQualifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IOIQualifier left, IOIQualifier right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static IOIQualifier FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IOIQualifier", nameof(value));

            return new IOIQualifier(value);
        }

        public static IOIQualifier FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IOIQualifier", nameof(value));

            return new IOIQualifier(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static IOIQualifier FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new IOIQualifier(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static IOIQualifier Invalid
        {
            get { return new IOIQualifier(); }
        }

        public static IOIQualifier AllOrNone
        {
            get { return new IOIQualifier('A'); }
        }

        public static IOIQualifier MarketOnClose
        {
            get { return new IOIQualifier('B'); }
        }

        public static IOIQualifier AtTheClose
        {
            get { return new IOIQualifier('C'); }
        }

        public static IOIQualifier Vwap
        {
            get { return new IOIQualifier('D'); }
        }

        public static IOIQualifier InTouchWith
        {
            get { return new IOIQualifier('I'); }
        }

        public static IOIQualifier Limit
        {
            get { return new IOIQualifier('L'); }
        }

        public static IOIQualifier MoreBehind
        {
            get { return new IOIQualifier('M'); }
        }

        public static IOIQualifier AtTheOpen
        {
            get { return new IOIQualifier('O'); }
        }

        public static IOIQualifier TakingAPosition
        {
            get { return new IOIQualifier('P'); }
        }

        public static IOIQualifier AtTheMarket
        {
            get { return new IOIQualifier('Q'); }
        }

        public static IOIQualifier ReadyToTrade
        {
            get { return new IOIQualifier('R'); }
        }

        public static IOIQualifier PortfolioShown
        {
            get { return new IOIQualifier('S'); }
        }

        public static IOIQualifier ThroughTheDay
        {
            get { return new IOIQualifier('T'); }
        }

        public static IOIQualifier Versus
        {
            get { return new IOIQualifier('V'); }
        }

        public static IOIQualifier IndicationWorkingAway
        {
            get { return new IOIQualifier('W'); }
        }

        public static IOIQualifier CrossingOpportunity
        {
            get { return new IOIQualifier('X'); }
        }

        public static IOIQualifier AtTheMidpoint
        {
            get { return new IOIQualifier('Y'); }
        }

        public static IOIQualifier PreOpen
        {
            get { return new IOIQualifier('Z'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DKReason : IEquatable<DKReason>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'A', "UnknownSymbol"}, {'B', "WrongSide"}, {'C', "QuantityExceedsOrder"}, {'D', "NoMatchingOrder"}, {'E', "PriceExceedsLimit"}, {'F', "CalculationDifference"}, {'Z', "Other"},};
        private readonly char? _value;

        private DKReason(char value)
        {
            _value = value;
        }

        public bool Equals(DKReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DKReason && Equals((DKReason) other);
        }

        public static bool operator ==(DKReason left, DKReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DKReason left, DKReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DKReason FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DKReason", nameof(value));

            return new DKReason(value);
        }

        public static DKReason FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DKReason", nameof(value));

            return new DKReason(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DKReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DKReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DKReason Invalid
        {
            get { return new DKReason(); }
        }

        public static DKReason UnknownSymbol
        {
            get { return new DKReason('A'); }
        }

        public static DKReason WrongSide
        {
            get { return new DKReason('B'); }
        }

        public static DKReason QuantityExceedsOrder
        {
            get { return new DKReason('C'); }
        }

        public static DKReason NoMatchingOrder
        {
            get { return new DKReason('D'); }
        }

        public static DKReason PriceExceedsLimit
        {
            get { return new DKReason('E'); }
        }

        public static DKReason CalculationDifference
        {
            get { return new DKReason('F'); }
        }

        public static DKReason Other
        {
            get { return new DKReason('Z'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MiscFeeType : IEquatable<MiscFeeType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Regulatory"}, {2, "Tax"}, {3, "LocalCommission"}, {4, "ExchangeFees"}, {5, "Stamp"}, {6, "Levy"}, {7, "Other"}, {8, "Markup"}, {9, "ConsumptionTax"}, {10, "PerTransaction"}, {11, "Conversion"}, {12, "Agent"},};
        private readonly int? _value;

        private MiscFeeType(int value)
        {
            _value = value;
        }

        public bool Equals(MiscFeeType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MiscFeeType && Equals((MiscFeeType) other);
        }

        public static bool operator ==(MiscFeeType left, MiscFeeType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MiscFeeType left, MiscFeeType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MiscFeeType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MiscFeeType", nameof(value));

            return new MiscFeeType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MiscFeeType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MiscFeeType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MiscFeeType Invalid
        {
            get { return new MiscFeeType(); }
        }

        public static MiscFeeType Regulatory
        {
            get { return new MiscFeeType(1); }
        }

        public static MiscFeeType Tax
        {
            get { return new MiscFeeType(2); }
        }

        public static MiscFeeType LocalCommission
        {
            get { return new MiscFeeType(3); }
        }

        public static MiscFeeType ExchangeFees
        {
            get { return new MiscFeeType(4); }
        }

        public static MiscFeeType Stamp
        {
            get { return new MiscFeeType(5); }
        }

        public static MiscFeeType Levy
        {
            get { return new MiscFeeType(6); }
        }

        public static MiscFeeType Other
        {
            get { return new MiscFeeType(7); }
        }

        public static MiscFeeType Markup
        {
            get { return new MiscFeeType(8); }
        }

        public static MiscFeeType ConsumptionTax
        {
            get { return new MiscFeeType(9); }
        }

        public static MiscFeeType PerTransaction
        {
            get { return new MiscFeeType(10); }
        }

        public static MiscFeeType Conversion
        {
            get { return new MiscFeeType(11); }
        }

        public static MiscFeeType Agent
        {
            get { return new MiscFeeType(12); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ExecType : IEquatable<ExecType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "New"}, {'1', "PartialFill"}, {'2', "Fill"}, {'3', "DoneForDay"}, {'4', "Canceled"}, {'5', "Replace"}, {'6', "PendingCancel"}, {'7', "Stopped"}, {'8', "Rejected"}, {'9', "Suspended"}, {'A', "PendingNew"}, {'B', "Calculated"}, {'C', "Expired"}, {'D', "Restated"}, {'E', "PendingReplace"}, {'F', "Trade"}, {'G', "TradeCorrect"}, {'H', "TradeCancel"}, {'I', "OrderStatus"},};
        private readonly char? _value;

        private ExecType(char value)
        {
            _value = value;
        }

        public bool Equals(ExecType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ExecType && Equals((ExecType) other);
        }

        public static bool operator ==(ExecType left, ExecType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExecType left, ExecType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ExecType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExecType", nameof(value));

            return new ExecType(value);
        }

        public static ExecType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExecType", nameof(value));

            return new ExecType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ExecType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ExecType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ExecType Invalid
        {
            get { return new ExecType(); }
        }

        public static ExecType New
        {
            get { return new ExecType('0'); }
        }

        public static ExecType PartialFill
        {
            get { return new ExecType('1'); }
        }

        public static ExecType Fill
        {
            get { return new ExecType('2'); }
        }

        public static ExecType DoneForDay
        {
            get { return new ExecType('3'); }
        }

        public static ExecType Canceled
        {
            get { return new ExecType('4'); }
        }

        public static ExecType Replace
        {
            get { return new ExecType('5'); }
        }

        public static ExecType PendingCancel
        {
            get { return new ExecType('6'); }
        }

        public static ExecType Stopped
        {
            get { return new ExecType('7'); }
        }

        public static ExecType Rejected
        {
            get { return new ExecType('8'); }
        }

        public static ExecType Suspended
        {
            get { return new ExecType('9'); }
        }

        public static ExecType PendingNew
        {
            get { return new ExecType('A'); }
        }

        public static ExecType Calculated
        {
            get { return new ExecType('B'); }
        }

        public static ExecType Expired
        {
            get { return new ExecType('C'); }
        }

        public static ExecType Restated
        {
            get { return new ExecType('D'); }
        }

        public static ExecType PendingReplace
        {
            get { return new ExecType('E'); }
        }

        public static ExecType Trade
        {
            get { return new ExecType('F'); }
        }

        public static ExecType TradeCorrect
        {
            get { return new ExecType('G'); }
        }

        public static ExecType TradeCancel
        {
            get { return new ExecType('H'); }
        }

        public static ExecType OrderStatus
        {
            get { return new ExecType('I'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlCurrFxRateCalc : IEquatable<SettlCurrFxRateCalc>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'M', "Multiply"}, {'D', "Divide"},};
        private readonly char? _value;

        private SettlCurrFxRateCalc(char value)
        {
            _value = value;
        }

        public bool Equals(SettlCurrFxRateCalc other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlCurrFxRateCalc && Equals((SettlCurrFxRateCalc) other);
        }

        public static bool operator ==(SettlCurrFxRateCalc left, SettlCurrFxRateCalc right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlCurrFxRateCalc left, SettlCurrFxRateCalc right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlCurrFxRateCalc FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlCurrFxRateCalc", nameof(value));

            return new SettlCurrFxRateCalc(value);
        }

        public static SettlCurrFxRateCalc FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlCurrFxRateCalc", nameof(value));

            return new SettlCurrFxRateCalc(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlCurrFxRateCalc FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlCurrFxRateCalc(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlCurrFxRateCalc Invalid
        {
            get { return new SettlCurrFxRateCalc(); }
        }

        public static SettlCurrFxRateCalc Multiply
        {
            get { return new SettlCurrFxRateCalc('M'); }
        }

        public static SettlCurrFxRateCalc Divide
        {
            get { return new SettlCurrFxRateCalc('D'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlInstMode : IEquatable<SettlInstMode>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Default"}, {'1', "StandingInstructionsProvided"}, {'4', "SpecificOrderForASingleAccount"}, {'5', "RequestReject"},};
        private readonly char? _value;

        private SettlInstMode(char value)
        {
            _value = value;
        }

        public bool Equals(SettlInstMode other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlInstMode && Equals((SettlInstMode) other);
        }

        public static bool operator ==(SettlInstMode left, SettlInstMode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlInstMode left, SettlInstMode right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlInstMode FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstMode", nameof(value));

            return new SettlInstMode(value);
        }

        public static SettlInstMode FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstMode", nameof(value));

            return new SettlInstMode(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlInstMode FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlInstMode(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlInstMode Invalid
        {
            get { return new SettlInstMode(); }
        }

        public static SettlInstMode Default
        {
            get { return new SettlInstMode('0'); }
        }

        public static SettlInstMode StandingInstructionsProvided
        {
            get { return new SettlInstMode('1'); }
        }

        public static SettlInstMode SpecificOrderForASingleAccount
        {
            get { return new SettlInstMode('4'); }
        }

        public static SettlInstMode RequestReject
        {
            get { return new SettlInstMode('5'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlInstTransType : IEquatable<SettlInstTransType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'N', "New"}, {'C', "Cancel"}, {'R', "Replace"}, {'T', "Restate"},};
        private readonly char? _value;

        private SettlInstTransType(char value)
        {
            _value = value;
        }

        public bool Equals(SettlInstTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlInstTransType && Equals((SettlInstTransType) other);
        }

        public static bool operator ==(SettlInstTransType left, SettlInstTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlInstTransType left, SettlInstTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlInstTransType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstTransType", nameof(value));

            return new SettlInstTransType(value);
        }

        public static SettlInstTransType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstTransType", nameof(value));

            return new SettlInstTransType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlInstTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlInstTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlInstTransType Invalid
        {
            get { return new SettlInstTransType(); }
        }

        public static SettlInstTransType New
        {
            get { return new SettlInstTransType('N'); }
        }

        public static SettlInstTransType Cancel
        {
            get { return new SettlInstTransType('C'); }
        }

        public static SettlInstTransType Replace
        {
            get { return new SettlInstTransType('R'); }
        }

        public static SettlInstTransType Restate
        {
            get { return new SettlInstTransType('T'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlInstSource : IEquatable<SettlInstSource>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "BrokersInstructions"}, {'2', "InstitutionsInstructions"}, {'3', "Investor"},};
        private readonly char? _value;

        private SettlInstSource(char value)
        {
            _value = value;
        }

        public bool Equals(SettlInstSource other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlInstSource && Equals((SettlInstSource) other);
        }

        public static bool operator ==(SettlInstSource left, SettlInstSource right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlInstSource left, SettlInstSource right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlInstSource FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstSource", nameof(value));

            return new SettlInstSource(value);
        }

        public static SettlInstSource FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstSource", nameof(value));

            return new SettlInstSource(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlInstSource FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlInstSource(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlInstSource Invalid
        {
            get { return new SettlInstSource(); }
        }

        public static SettlInstSource BrokersInstructions
        {
            get { return new SettlInstSource('1'); }
        }

        public static SettlInstSource InstitutionsInstructions
        {
            get { return new SettlInstSource('2'); }
        }

        public static SettlInstSource Investor
        {
            get { return new SettlInstSource('3'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityType : IEquatable<SecurityType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string>
                                                                     {
                                                                         {"EUSUPRA", "EuroSupranationalCoupons"},
                                                                         {"FAC", "FederalAgencyCoupon"},
                                                                         {"FADN", "FederalAgencyDiscountNote"},
                                                                         {"PEF", "PrivateExportFunding"},
                                                                         {"SUPRA", "UsdSupranationalCoupons"},
                                                                         {"FUT", "Future"},
                                                                         {"OPT", "Option"},
                                                                         {"CORP", "CorporateBond"},
                                                                         {"CPP", "CorporatePrivatePlacement"},
                                                                         {"CB", "ConvertibleBond"},
                                                                         {"DUAL", "DualCurrency"},
                                                                         {"EUCORP", "EuroCorporateBond"},
                                                                         {"XLINKD", "IndexedLinked"},
                                                                         {"STRUCT", "StructuredNotes"},
                                                                         {"YANK", "YankeeCorporateBond"},
                                                                         {"FOR", "ForeignExchangeContract"},
                                                                         {"CS", "CommonStock"},
                                                                         {"PS", "PreferredStock"},
                                                                         {"BRADY", "BradyBond"},
                                                                         {"EUSOV", "EuroSovereigns"},
                                                                         {"TBOND", "UsTreasuryBond"},
                                                                         {"TINT", "InterestStripFromAnyBondOrNote"},
                                                                         {"TIPS", "TreasuryInflationProtectedSecurities"},
                                                                         {"TCAL", "PrincipalStripOfACallableBondOrNote"},
                                                                         {"TPRN", "PrincipalStripFromANonCallableBondOrNote"},
                                                                         {"TNOTE", "UsTreasuryNote"},
                                                                         {"TBILL", "UsTreasuryBill"},
                                                                         {"REPO", "Repurchase"},
                                                                         {"FORWARD", "Forward"},
                                                                         {"BUYSELL", "BuySellback"},
                                                                         {"SECLOAN", "SecuritiesLoan"},
                                                                         {"SECPLEDGE", "SecuritiesPledge"},
                                                                         {"TERM", "TermLoan"},
                                                                         {"RVLV", "RevolverLoan"},
                                                                         {"RVLVTRM", "RevolverTermLoan"},
                                                                         {"BRIDGE", "BridgeLoan"},
                                                                         {"LOFC", "LetterOfCredit"},
                                                                         {"SWING", "SwingLineFacility"},
                                                                         {"DINP", "DebtorInPossession"},
                                                                         {"DEFLTED", "Defaulted"},
                                                                         {"WITHDRN", "Withdrawn"},
                                                                         {"REPLACD", "Replaced"},
                                                                         {"MATURED", "Matured"},
                                                                         {"AMENDED", "AmendedAndRestated"},
                                                                         {"RETIRED", "Retired"},
                                                                         {"BA", "BankersAcceptance"},
                                                                         {"BN", "BankNotes"},
                                                                         {"BOX", "BillOfExchanges"},
                                                                         {"CD", "CertificateOfDeposit"},
                                                                         {"CL", "CallLoans"},
                                                                         {"CP", "CommercialPaper"},
                                                                         {"DN", "DepositNotes"},
                                                                         {"EUCD", "EuroCertificateOfDeposit"},
                                                                         {"EUCP", "EuroCommercialPaper"},
                                                                         {"LQN", "LiquidityNote"},
                                                                         {"MTN", "MediumTermNotes"},
                                                                         {"ONITE", "Overnight"},
                                                                         {"PN", "PromissoryNote"},
                                                                         {"PZFJ", "PlazosFijos"},
                                                                         {"STN", "ShortTermLoanNote"},
                                                                         {"TD", "TimeDeposit"},
                                                                         {"XCN", "ExtendedCommNote"},
                                                                         {"YCD", "YankeeCertificateOfDeposit"},
                                                                         {"ABS", "AssetBackedSecurities"},
                                                                         {"CMBS", "CorpMortgageBackedSecurities"},
                                                                         {"CMO", "CollateralizedMortgageObligation"},
                                                                         {"IET", "IoetteMortgage"},
                                                                         {"MBS", "MortgageBackedSecurities"},
                                                                         {"MIO", "MortgageInterestOnly"},
                                                                         {"MPO", "MortgagePrincipalOnly"},
                                                                         {"MPP", "MortgagePrivatePlacement"},
                                                                         {"MPT", "MiscellaneousPassThrough"},
                                                                         {"PFAND", "Pfandbriefe"},
                                                                         {"TBA", "ToBeAnnounced"},
                                                                         {"AN", "OtherAnticipationNotes"},
                                                                         {"COFO", "CertificateOfObligation"},
                                                                         {"COFP", "CertificateOfParticipation"},
                                                                         {"GO", "GeneralObligationBonds"},
                                                                         {"MT", "MandatoryTender"},
                                                                         {"RAN", "RevenueAnticipationNote"},
                                                                         {"REV", "RevenueBonds"},
                                                                         {"SPCLA", "SpecialAssessment"},
                                                                         {"SPCLO", "SpecialObligation"},
                                                                         {"SPCLT", "SpecialTax"},
                                                                         {"TAN", "TaxAnticipationNote"},
                                                                         {"TAXA", "TaxAllocation"},
                                                                         {"TECP", "TaxExemptCommercialPaper"},
                                                                         {"TRAN", "TaxAndRevenueAnticipationNote"},
                                                                         {"VRDN", "VariableRateDemandNote"},
                                                                         {"WAR", "Warrant"},
                                                                         {"MF", "MutualFund"},
                                                                         {"MLEG", "MultiLegInstrument"},
                                                                         {"NONE", "NoSecurityType"},
                                                                         {"?", "Wildcard"},
                                                                     };

        private readonly string _value;

        private SecurityType(string value)
        {
            _value = value;
        }

        public bool Equals(SecurityType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityType && Equals((SecurityType) other);
        }

        public static bool operator ==(SecurityType left, SecurityType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityType left, SecurityType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static SecurityType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityType", nameof(value));

            return new SecurityType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static SecurityType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityType Invalid
        {
            get { return new SecurityType(); }
        }

        public static SecurityType EuroSupranationalCoupons
        {
            get { return new SecurityType("EUSUPRA"); }
        }

        public static SecurityType FederalAgencyCoupon
        {
            get { return new SecurityType("FAC"); }
        }

        public static SecurityType FederalAgencyDiscountNote
        {
            get { return new SecurityType("FADN"); }
        }

        public static SecurityType PrivateExportFunding
        {
            get { return new SecurityType("PEF"); }
        }

        public static SecurityType UsdSupranationalCoupons
        {
            get { return new SecurityType("SUPRA"); }
        }

        public static SecurityType Future
        {
            get { return new SecurityType("FUT"); }
        }

        public static SecurityType Option
        {
            get { return new SecurityType("OPT"); }
        }

        public static SecurityType CorporateBond
        {
            get { return new SecurityType("CORP"); }
        }

        public static SecurityType CorporatePrivatePlacement
        {
            get { return new SecurityType("CPP"); }
        }

        public static SecurityType ConvertibleBond
        {
            get { return new SecurityType("CB"); }
        }

        public static SecurityType DualCurrency
        {
            get { return new SecurityType("DUAL"); }
        }

        public static SecurityType EuroCorporateBond
        {
            get { return new SecurityType("EUCORP"); }
        }

        public static SecurityType IndexedLinked
        {
            get { return new SecurityType("XLINKD"); }
        }

        public static SecurityType StructuredNotes
        {
            get { return new SecurityType("STRUCT"); }
        }

        public static SecurityType YankeeCorporateBond
        {
            get { return new SecurityType("YANK"); }
        }

        public static SecurityType ForeignExchangeContract
        {
            get { return new SecurityType("FOR"); }
        }

        public static SecurityType CommonStock
        {
            get { return new SecurityType("CS"); }
        }

        public static SecurityType PreferredStock
        {
            get { return new SecurityType("PS"); }
        }

        public static SecurityType BradyBond
        {
            get { return new SecurityType("BRADY"); }
        }

        public static SecurityType EuroSovereigns
        {
            get { return new SecurityType("EUSOV"); }
        }

        public static SecurityType UsTreasuryBond
        {
            get { return new SecurityType("TBOND"); }
        }

        public static SecurityType InterestStripFromAnyBondOrNote
        {
            get { return new SecurityType("TINT"); }
        }

        public static SecurityType TreasuryInflationProtectedSecurities
        {
            get { return new SecurityType("TIPS"); }
        }

        public static SecurityType PrincipalStripOfACallableBondOrNote
        {
            get { return new SecurityType("TCAL"); }
        }

        public static SecurityType PrincipalStripFromANonCallableBondOrNote
        {
            get { return new SecurityType("TPRN"); }
        }

        public static SecurityType UsTreasuryNote
        {
            get { return new SecurityType("TNOTE"); }
        }

        public static SecurityType UsTreasuryBill
        {
            get { return new SecurityType("TBILL"); }
        }

        public static SecurityType Repurchase
        {
            get { return new SecurityType("REPO"); }
        }

        public static SecurityType Forward
        {
            get { return new SecurityType("FORWARD"); }
        }

        public static SecurityType BuySellback
        {
            get { return new SecurityType("BUYSELL"); }
        }

        public static SecurityType SecuritiesLoan
        {
            get { return new SecurityType("SECLOAN"); }
        }

        public static SecurityType SecuritiesPledge
        {
            get { return new SecurityType("SECPLEDGE"); }
        }

        public static SecurityType TermLoan
        {
            get { return new SecurityType("TERM"); }
        }

        public static SecurityType RevolverLoan
        {
            get { return new SecurityType("RVLV"); }
        }

        public static SecurityType RevolverTermLoan
        {
            get { return new SecurityType("RVLVTRM"); }
        }

        public static SecurityType BridgeLoan
        {
            get { return new SecurityType("BRIDGE"); }
        }

        public static SecurityType LetterOfCredit
        {
            get { return new SecurityType("LOFC"); }
        }

        public static SecurityType SwingLineFacility
        {
            get { return new SecurityType("SWING"); }
        }

        public static SecurityType DebtorInPossession
        {
            get { return new SecurityType("DINP"); }
        }

        public static SecurityType Defaulted
        {
            get { return new SecurityType("DEFLTED"); }
        }

        public static SecurityType Withdrawn
        {
            get { return new SecurityType("WITHDRN"); }
        }

        public static SecurityType Replaced
        {
            get { return new SecurityType("REPLACD"); }
        }

        public static SecurityType Matured
        {
            get { return new SecurityType("MATURED"); }
        }

        public static SecurityType AmendedAndRestated
        {
            get { return new SecurityType("AMENDED"); }
        }

        public static SecurityType Retired
        {
            get { return new SecurityType("RETIRED"); }
        }

        public static SecurityType BankersAcceptance
        {
            get { return new SecurityType("BA"); }
        }

        public static SecurityType BankNotes
        {
            get { return new SecurityType("BN"); }
        }

        public static SecurityType BillOfExchanges
        {
            get { return new SecurityType("BOX"); }
        }

        public static SecurityType CertificateOfDeposit
        {
            get { return new SecurityType("CD"); }
        }

        public static SecurityType CallLoans
        {
            get { return new SecurityType("CL"); }
        }

        public static SecurityType CommercialPaper
        {
            get { return new SecurityType("CP"); }
        }

        public static SecurityType DepositNotes
        {
            get { return new SecurityType("DN"); }
        }

        public static SecurityType EuroCertificateOfDeposit
        {
            get { return new SecurityType("EUCD"); }
        }

        public static SecurityType EuroCommercialPaper
        {
            get { return new SecurityType("EUCP"); }
        }

        public static SecurityType LiquidityNote
        {
            get { return new SecurityType("LQN"); }
        }

        public static SecurityType MediumTermNotes
        {
            get { return new SecurityType("MTN"); }
        }

        public static SecurityType Overnight
        {
            get { return new SecurityType("ONITE"); }
        }

        public static SecurityType PromissoryNote
        {
            get { return new SecurityType("PN"); }
        }

        public static SecurityType PlazosFijos
        {
            get { return new SecurityType("PZFJ"); }
        }

        public static SecurityType ShortTermLoanNote
        {
            get { return new SecurityType("STN"); }
        }

        public static SecurityType TimeDeposit
        {
            get { return new SecurityType("TD"); }
        }

        public static SecurityType ExtendedCommNote
        {
            get { return new SecurityType("XCN"); }
        }

        public static SecurityType YankeeCertificateOfDeposit
        {
            get { return new SecurityType("YCD"); }
        }

        public static SecurityType AssetBackedSecurities
        {
            get { return new SecurityType("ABS"); }
        }

        public static SecurityType CorpMortgageBackedSecurities
        {
            get { return new SecurityType("CMBS"); }
        }

        public static SecurityType CollateralizedMortgageObligation
        {
            get { return new SecurityType("CMO"); }
        }

        public static SecurityType IoetteMortgage
        {
            get { return new SecurityType("IET"); }
        }

        public static SecurityType MortgageBackedSecurities
        {
            get { return new SecurityType("MBS"); }
        }

        public static SecurityType MortgageInterestOnly
        {
            get { return new SecurityType("MIO"); }
        }

        public static SecurityType MortgagePrincipalOnly
        {
            get { return new SecurityType("MPO"); }
        }

        public static SecurityType MortgagePrivatePlacement
        {
            get { return new SecurityType("MPP"); }
        }

        public static SecurityType MiscellaneousPassThrough
        {
            get { return new SecurityType("MPT"); }
        }

        public static SecurityType Pfandbriefe
        {
            get { return new SecurityType("PFAND"); }
        }

        public static SecurityType ToBeAnnounced
        {
            get { return new SecurityType("TBA"); }
        }

        public static SecurityType OtherAnticipationNotes
        {
            get { return new SecurityType("AN"); }
        }

        public static SecurityType CertificateOfObligation
        {
            get { return new SecurityType("COFO"); }
        }

        public static SecurityType CertificateOfParticipation
        {
            get { return new SecurityType("COFP"); }
        }

        public static SecurityType GeneralObligationBonds
        {
            get { return new SecurityType("GO"); }
        }

        public static SecurityType MandatoryTender
        {
            get { return new SecurityType("MT"); }
        }

        public static SecurityType RevenueAnticipationNote
        {
            get { return new SecurityType("RAN"); }
        }

        public static SecurityType RevenueBonds
        {
            get { return new SecurityType("REV"); }
        }

        public static SecurityType SpecialAssessment
        {
            get { return new SecurityType("SPCLA"); }
        }

        public static SecurityType SpecialObligation
        {
            get { return new SecurityType("SPCLO"); }
        }

        public static SecurityType SpecialTax
        {
            get { return new SecurityType("SPCLT"); }
        }

        public static SecurityType TaxAnticipationNote
        {
            get { return new SecurityType("TAN"); }
        }

        public static SecurityType TaxAllocation
        {
            get { return new SecurityType("TAXA"); }
        }

        public static SecurityType TaxExemptCommercialPaper
        {
            get { return new SecurityType("TECP"); }
        }

        public static SecurityType TaxAndRevenueAnticipationNote
        {
            get { return new SecurityType("TRAN"); }
        }

        public static SecurityType VariableRateDemandNote
        {
            get { return new SecurityType("VRDN"); }
        }

        public static SecurityType Warrant
        {
            get { return new SecurityType("WAR"); }
        }

        public static SecurityType MutualFund
        {
            get { return new SecurityType("MF"); }
        }

        public static SecurityType MultiLegInstrument
        {
            get { return new SecurityType("MLEG"); }
        }

        public static SecurityType NoSecurityType
        {
            get { return new SecurityType("NONE"); }
        }

        public static SecurityType Wildcard
        {
            get { return new SecurityType("?"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct StandInstDbType : IEquatable<StandInstDbType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Other"}, {1, "DtcSid"}, {2, "ThomsonAlert"}, {3, "AGlobalCustodian"}, {4, "Accountnet"},};
        private readonly int? _value;

        private StandInstDbType(int value)
        {
            _value = value;
        }

        public bool Equals(StandInstDbType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is StandInstDbType && Equals((StandInstDbType) other);
        }

        public static bool operator ==(StandInstDbType left, StandInstDbType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StandInstDbType left, StandInstDbType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static StandInstDbType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for StandInstDbType", nameof(value));

            return new StandInstDbType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static StandInstDbType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new StandInstDbType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static StandInstDbType Invalid
        {
            get { return new StandInstDbType(); }
        }

        public static StandInstDbType Other
        {
            get { return new StandInstDbType(0); }
        }

        public static StandInstDbType DtcSid
        {
            get { return new StandInstDbType(1); }
        }

        public static StandInstDbType ThomsonAlert
        {
            get { return new StandInstDbType(2); }
        }

        public static StandInstDbType AGlobalCustodian
        {
            get { return new StandInstDbType(3); }
        }

        public static StandInstDbType Accountnet
        {
            get { return new StandInstDbType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlDeliveryType : IEquatable<SettlDeliveryType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "VersusPayment"}, {1, "Free"}, {2, "TriParty"}, {3, "HoldInCustody"},};
        private readonly int? _value;

        private SettlDeliveryType(int value)
        {
            _value = value;
        }

        public bool Equals(SettlDeliveryType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlDeliveryType && Equals((SettlDeliveryType) other);
        }

        public static bool operator ==(SettlDeliveryType left, SettlDeliveryType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlDeliveryType left, SettlDeliveryType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlDeliveryType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlDeliveryType", nameof(value));

            return new SettlDeliveryType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlDeliveryType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlDeliveryType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlDeliveryType Invalid
        {
            get { return new SettlDeliveryType(); }
        }

        public static SettlDeliveryType VersusPayment
        {
            get { return new SettlDeliveryType(0); }
        }

        public static SettlDeliveryType Free
        {
            get { return new SettlDeliveryType(1); }
        }

        public static SettlDeliveryType TriParty
        {
            get { return new SettlDeliveryType(2); }
        }

        public static SettlDeliveryType HoldInCustody
        {
            get { return new SettlDeliveryType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocLinkType : IEquatable<AllocLinkType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "FXNetting"}, {1, "FXSwap"},};
        private readonly int? _value;

        private AllocLinkType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocLinkType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocLinkType && Equals((AllocLinkType) other);
        }

        public static bool operator ==(AllocLinkType left, AllocLinkType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocLinkType left, AllocLinkType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocLinkType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocLinkType", nameof(value));

            return new AllocLinkType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocLinkType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocLinkType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocLinkType Invalid
        {
            get { return new AllocLinkType(); }
        }

        public static AllocLinkType FXNetting
        {
            get { return new AllocLinkType(0); }
        }

        public static AllocLinkType FXSwap
        {
            get { return new AllocLinkType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PutOrCall : IEquatable<PutOrCall>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Put"}, {1, "Call"},};
        private readonly int? _value;

        private PutOrCall(int value)
        {
            _value = value;
        }

        public bool Equals(PutOrCall other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PutOrCall && Equals((PutOrCall) other);
        }

        public static bool operator ==(PutOrCall left, PutOrCall right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PutOrCall left, PutOrCall right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PutOrCall FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PutOrCall", nameof(value));

            return new PutOrCall(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PutOrCall FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PutOrCall(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PutOrCall Invalid
        {
            get { return new PutOrCall(); }
        }

        public static PutOrCall Put
        {
            get { return new PutOrCall(0); }
        }

        public static PutOrCall Call
        {
            get { return new PutOrCall(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CoveredOrUncovered : IEquatable<CoveredOrUncovered>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Covered"}, {1, "Uncovered"},};
        private readonly int? _value;

        private CoveredOrUncovered(int value)
        {
            _value = value;
        }

        public bool Equals(CoveredOrUncovered other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CoveredOrUncovered && Equals((CoveredOrUncovered) other);
        }

        public static bool operator ==(CoveredOrUncovered left, CoveredOrUncovered right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CoveredOrUncovered left, CoveredOrUncovered right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CoveredOrUncovered FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CoveredOrUncovered", nameof(value));

            return new CoveredOrUncovered(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CoveredOrUncovered FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CoveredOrUncovered(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CoveredOrUncovered Invalid
        {
            get { return new CoveredOrUncovered(); }
        }

        public static CoveredOrUncovered Covered
        {
            get { return new CoveredOrUncovered(0); }
        }

        public static CoveredOrUncovered Uncovered
        {
            get { return new CoveredOrUncovered(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocHandlInst : IEquatable<AllocHandlInst>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Match"}, {2, "Forward"}, {3, "ForwardAndMatch"},};
        private readonly int? _value;

        private AllocHandlInst(int value)
        {
            _value = value;
        }

        public bool Equals(AllocHandlInst other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocHandlInst && Equals((AllocHandlInst) other);
        }

        public static bool operator ==(AllocHandlInst left, AllocHandlInst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocHandlInst left, AllocHandlInst right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocHandlInst FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocHandlInst", nameof(value));

            return new AllocHandlInst(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocHandlInst FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocHandlInst(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocHandlInst Invalid
        {
            get { return new AllocHandlInst(); }
        }

        public static AllocHandlInst Match
        {
            get { return new AllocHandlInst(1); }
        }

        public static AllocHandlInst Forward
        {
            get { return new AllocHandlInst(2); }
        }

        public static AllocHandlInst ForwardAndMatch
        {
            get { return new AllocHandlInst(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct RoutingType : IEquatable<RoutingType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "TargetFirm"}, {2, "TargetList"}, {3, "BlockFirm"}, {4, "BlockList"},};
        private readonly int? _value;

        private RoutingType(int value)
        {
            _value = value;
        }

        public bool Equals(RoutingType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is RoutingType && Equals((RoutingType) other);
        }

        public static bool operator ==(RoutingType left, RoutingType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RoutingType left, RoutingType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static RoutingType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RoutingType", nameof(value));

            return new RoutingType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static RoutingType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new RoutingType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static RoutingType Invalid
        {
            get { return new RoutingType(); }
        }

        public static RoutingType TargetFirm
        {
            get { return new RoutingType(1); }
        }

        public static RoutingType TargetList
        {
            get { return new RoutingType(2); }
        }

        public static RoutingType BlockFirm
        {
            get { return new RoutingType(3); }
        }

        public static RoutingType BlockList
        {
            get { return new RoutingType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BenchmarkCurveName : IEquatable<BenchmarkCurveName>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"MuniAAA", "Muniaaa"}, {"FutureSWAP", "Futureswap"}, {"LIBID", "Libid"}, {"LIBOR", "Libor"}, {"OTHER", "Other"}, {"SWAP", "Swap"}, {"Treasury", "Treasury"}, {"Euribor", "Euribor"}, {"Pfandbriefe", "Pfandbriefe"}, {"EONIA", "Eonia"}, {"SONIA", "Sonia"}, {"EUREPO", "Eurepo"},};
        private readonly string _value;

        private BenchmarkCurveName(string value)
        {
            _value = value;
        }

        public bool Equals(BenchmarkCurveName other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BenchmarkCurveName && Equals((BenchmarkCurveName) other);
        }

        public static bool operator ==(BenchmarkCurveName left, BenchmarkCurveName right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BenchmarkCurveName left, BenchmarkCurveName right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static BenchmarkCurveName FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BenchmarkCurveName", nameof(value));

            return new BenchmarkCurveName(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static BenchmarkCurveName FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BenchmarkCurveName(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BenchmarkCurveName Invalid
        {
            get { return new BenchmarkCurveName(); }
        }

        public static BenchmarkCurveName Muniaaa
        {
            get { return new BenchmarkCurveName("MuniAAA"); }
        }

        public static BenchmarkCurveName Futureswap
        {
            get { return new BenchmarkCurveName("FutureSWAP"); }
        }

        public static BenchmarkCurveName Libid
        {
            get { return new BenchmarkCurveName("LIBID"); }
        }

        public static BenchmarkCurveName Libor
        {
            get { return new BenchmarkCurveName("LIBOR"); }
        }

        public static BenchmarkCurveName Other
        {
            get { return new BenchmarkCurveName("OTHER"); }
        }

        public static BenchmarkCurveName Swap
        {
            get { return new BenchmarkCurveName("SWAP"); }
        }

        public static BenchmarkCurveName Treasury
        {
            get { return new BenchmarkCurveName("Treasury"); }
        }

        public static BenchmarkCurveName Euribor
        {
            get { return new BenchmarkCurveName("Euribor"); }
        }

        public static BenchmarkCurveName Pfandbriefe
        {
            get { return new BenchmarkCurveName("Pfandbriefe"); }
        }

        public static BenchmarkCurveName Eonia
        {
            get { return new BenchmarkCurveName("EONIA"); }
        }

        public static BenchmarkCurveName Sonia
        {
            get { return new BenchmarkCurveName("SONIA"); }
        }

        public static BenchmarkCurveName Eurepo
        {
            get { return new BenchmarkCurveName("EUREPO"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct StipulationType : IEquatable<StipulationType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string>
                                                                     {
                                                                         {"AMT", "Amt"},
                                                                         {"AUTOREINV", "AutoReinvestmentAtOrBetter"},
                                                                         {"BANKQUAL", "BankQualified"},
                                                                         {"BGNCON", "BargainConditions"},
                                                                         {"COUPON", "CouponRange"},
                                                                         {"CURRENCY", "IsoCurrencyCode"},
                                                                         {"CUSTOMDATE", "CustomStartEndDate"},
                                                                         {"GEOG", "GeographicsAndPercentRange"},
                                                                         {"HAIRCUT", "ValuationDiscount"},
                                                                         {"INSURED", "Insured"},
                                                                         {"ISSUE", "YearOrYearMonthOfIssue"},
                                                                         {"ISSUER", "IssuersTicker"},
                                                                         {"ISSUESIZE", "IssueSizeRange"},
                                                                         {"LOOKBACK", "LookbackDays"},
                                                                         {"LOT", "ExplicitLotIdentifier"},
                                                                         {"LOTVAR", "LotVariance"},
                                                                         {"MAT", "MaturityYearAndMonth"},
                                                                         {"MATURITY", "MaturityRange"},
                                                                         {"MAXSUBS", "MaximumSubstitutions"},
                                                                         {"MINQTY", "MinimumQuantity"},
                                                                         {"MININCR", "MinimumIncrement"},
                                                                         {"MINDNOM", "MinimumDenomination"},
                                                                         {"PAYFREQ", "PaymentFrequencyCalendar"},
                                                                         {"PIECES", "NumberOfPieces"},
                                                                         {"PMAX", "PoolsMaximum"},
                                                                         {"PPM", "PoolsPerMillion"},
                                                                         {"PPL", "PoolsPerLot"},
                                                                         {"PPT", "PoolsPerTrade"},
                                                                         {"PRICE", "PriceRange"},
                                                                         {"PRICEFREQ", "PricingFrequency"},
                                                                         {"PROD", "ProductionYear"},
                                                                         {"PROTECT", "CallProtection"},
                                                                         {"PURPOSE", "Purpose"},
                                                                         {"PXSOURCE", "BenchmarkPriceSource"},
                                                                         {"RATING", "RatingSourceAndRange"},
                                                                         {"RESTRICTED", "Restricted"},
                                                                         {"SECTOR", "MarketSector"},
                                                                         {"SECTYPE", "SecuritytypeIncludedOrExcluded"},
                                                                         {"STRUCT", "Structure"},
                                                                         {"SUBSFREQ", "SubstitutionsFrequency"},
                                                                         {"SUBSLEFT", "SubstitutionsLeft"},
                                                                         {"TEXT", "FreeformText"},
                                                                         {"TRDVAR", "TradeVariance"},
                                                                         {"WAC", "WeightedAverageCoupon"},
                                                                         {"WAL", "WeightedAverageLifeCoupon"},
                                                                         {"WALA", "WeightedAverageLoanAge"},
                                                                         {"WAM", "WeightedAverageMaturity"},
                                                                         {"WHOLE", "WholePool"},
                                                                         {"YIELD", "YieldRange"},
                                                                         {"SMM", "SingleMonthlyMortality"},
                                                                         {"CPR", "ConstantPrepaymentRate"},
                                                                         {"CPY", "ConstantPrepaymentYield"},
                                                                         {"CPP", "ConstantPrepaymentPenalty"},
                                                                         {"ABS", "AbsolutePrepaymentSpeed"},
                                                                         {"MPR", "MonthlyPrepaymentRate"},
                                                                         {"PSA", "PercentOfBmaPrepaymentCurve"},
                                                                         {"PPC", "PercentOfProspectusPrepaymentCurve"},
                                                                         {"MHP", "PercentOfManufacturedHousingPrepaymentCurve"},
                                                                         {"HEP", "FinalCprOfHomeEquityPrepaymentCurve"},
                                                                     };

        private readonly string _value;

        private StipulationType(string value)
        {
            _value = value;
        }

        public bool Equals(StipulationType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is StipulationType && Equals((StipulationType) other);
        }

        public static bool operator ==(StipulationType left, StipulationType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StipulationType left, StipulationType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static StipulationType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for StipulationType", nameof(value));

            return new StipulationType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static StipulationType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new StipulationType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static StipulationType Invalid
        {
            get { return new StipulationType(); }
        }

        public static StipulationType Amt
        {
            get { return new StipulationType("AMT"); }
        }

        public static StipulationType AutoReinvestmentAtOrBetter
        {
            get { return new StipulationType("AUTOREINV"); }
        }

        public static StipulationType BankQualified
        {
            get { return new StipulationType("BANKQUAL"); }
        }

        public static StipulationType BargainConditions
        {
            get { return new StipulationType("BGNCON"); }
        }

        public static StipulationType CouponRange
        {
            get { return new StipulationType("COUPON"); }
        }

        public static StipulationType IsoCurrencyCode
        {
            get { return new StipulationType("CURRENCY"); }
        }

        public static StipulationType CustomStartEndDate
        {
            get { return new StipulationType("CUSTOMDATE"); }
        }

        public static StipulationType GeographicsAndPercentRange
        {
            get { return new StipulationType("GEOG"); }
        }

        public static StipulationType ValuationDiscount
        {
            get { return new StipulationType("HAIRCUT"); }
        }

        public static StipulationType Insured
        {
            get { return new StipulationType("INSURED"); }
        }

        public static StipulationType YearOrYearMonthOfIssue
        {
            get { return new StipulationType("ISSUE"); }
        }

        public static StipulationType IssuersTicker
        {
            get { return new StipulationType("ISSUER"); }
        }

        public static StipulationType IssueSizeRange
        {
            get { return new StipulationType("ISSUESIZE"); }
        }

        public static StipulationType LookbackDays
        {
            get { return new StipulationType("LOOKBACK"); }
        }

        public static StipulationType ExplicitLotIdentifier
        {
            get { return new StipulationType("LOT"); }
        }

        public static StipulationType LotVariance
        {
            get { return new StipulationType("LOTVAR"); }
        }

        public static StipulationType MaturityYearAndMonth
        {
            get { return new StipulationType("MAT"); }
        }

        public static StipulationType MaturityRange
        {
            get { return new StipulationType("MATURITY"); }
        }

        public static StipulationType MaximumSubstitutions
        {
            get { return new StipulationType("MAXSUBS"); }
        }

        public static StipulationType MinimumQuantity
        {
            get { return new StipulationType("MINQTY"); }
        }

        public static StipulationType MinimumIncrement
        {
            get { return new StipulationType("MININCR"); }
        }

        public static StipulationType MinimumDenomination
        {
            get { return new StipulationType("MINDNOM"); }
        }

        public static StipulationType PaymentFrequencyCalendar
        {
            get { return new StipulationType("PAYFREQ"); }
        }

        public static StipulationType NumberOfPieces
        {
            get { return new StipulationType("PIECES"); }
        }

        public static StipulationType PoolsMaximum
        {
            get { return new StipulationType("PMAX"); }
        }

        public static StipulationType PoolsPerMillion
        {
            get { return new StipulationType("PPM"); }
        }

        public static StipulationType PoolsPerLot
        {
            get { return new StipulationType("PPL"); }
        }

        public static StipulationType PoolsPerTrade
        {
            get { return new StipulationType("PPT"); }
        }

        public static StipulationType PriceRange
        {
            get { return new StipulationType("PRICE"); }
        }

        public static StipulationType PricingFrequency
        {
            get { return new StipulationType("PRICEFREQ"); }
        }

        public static StipulationType ProductionYear
        {
            get { return new StipulationType("PROD"); }
        }

        public static StipulationType CallProtection
        {
            get { return new StipulationType("PROTECT"); }
        }

        public static StipulationType Purpose
        {
            get { return new StipulationType("PURPOSE"); }
        }

        public static StipulationType BenchmarkPriceSource
        {
            get { return new StipulationType("PXSOURCE"); }
        }

        public static StipulationType RatingSourceAndRange
        {
            get { return new StipulationType("RATING"); }
        }

        public static StipulationType Restricted
        {
            get { return new StipulationType("RESTRICTED"); }
        }

        public static StipulationType MarketSector
        {
            get { return new StipulationType("SECTOR"); }
        }

        public static StipulationType SecuritytypeIncludedOrExcluded
        {
            get { return new StipulationType("SECTYPE"); }
        }

        public static StipulationType Structure
        {
            get { return new StipulationType("STRUCT"); }
        }

        public static StipulationType SubstitutionsFrequency
        {
            get { return new StipulationType("SUBSFREQ"); }
        }

        public static StipulationType SubstitutionsLeft
        {
            get { return new StipulationType("SUBSLEFT"); }
        }

        public static StipulationType FreeformText
        {
            get { return new StipulationType("TEXT"); }
        }

        public static StipulationType TradeVariance
        {
            get { return new StipulationType("TRDVAR"); }
        }

        public static StipulationType WeightedAverageCoupon
        {
            get { return new StipulationType("WAC"); }
        }

        public static StipulationType WeightedAverageLifeCoupon
        {
            get { return new StipulationType("WAL"); }
        }

        public static StipulationType WeightedAverageLoanAge
        {
            get { return new StipulationType("WALA"); }
        }

        public static StipulationType WeightedAverageMaturity
        {
            get { return new StipulationType("WAM"); }
        }

        public static StipulationType WholePool
        {
            get { return new StipulationType("WHOLE"); }
        }

        public static StipulationType YieldRange
        {
            get { return new StipulationType("YIELD"); }
        }

        public static StipulationType SingleMonthlyMortality
        {
            get { return new StipulationType("SMM"); }
        }

        public static StipulationType ConstantPrepaymentRate
        {
            get { return new StipulationType("CPR"); }
        }

        public static StipulationType ConstantPrepaymentYield
        {
            get { return new StipulationType("CPY"); }
        }

        public static StipulationType ConstantPrepaymentPenalty
        {
            get { return new StipulationType("CPP"); }
        }

        public static StipulationType AbsolutePrepaymentSpeed
        {
            get { return new StipulationType("ABS"); }
        }

        public static StipulationType MonthlyPrepaymentRate
        {
            get { return new StipulationType("MPR"); }
        }

        public static StipulationType PercentOfBmaPrepaymentCurve
        {
            get { return new StipulationType("PSA"); }
        }

        public static StipulationType PercentOfProspectusPrepaymentCurve
        {
            get { return new StipulationType("PPC"); }
        }

        public static StipulationType PercentOfManufacturedHousingPrepaymentCurve
        {
            get { return new StipulationType("MHP"); }
        }

        public static StipulationType FinalCprOfHomeEquityPrepaymentCurve
        {
            get { return new StipulationType("HEP"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct StipulationValue : IEquatable<StipulationValue>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"CD", "SpecialCumDividend"}, {"XD", "SpecialExDividend"}, {"CC", "SpecialCumCoupon"}, {"XC", "SpecialExCoupon"}, {"CB", "SpecialCumBonus"}, {"XB", "SpecialExBonus"}, {"CR", "SpecialCumRights"}, {"XR", "SpecialExRights"}, {"CP", "SpecialCumCapitalRepayments"}, {"XP", "SpecialExCapitalRepayments"}, {"CS", "CashSettlement"}, {"SP", "SpecialPrice"}, {"TR", "ReportForEuropeanEquityMarketSecurities"}, {"GD", "GuaranteedDelivery"},};
        private readonly string _value;

        private StipulationValue(string value)
        {
            _value = value;
        }

        public bool Equals(StipulationValue other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is StipulationValue && Equals((StipulationValue) other);
        }

        public static bool operator ==(StipulationValue left, StipulationValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StipulationValue left, StipulationValue right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static StipulationValue FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for StipulationValue", nameof(value));

            return new StipulationValue(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static StipulationValue FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new StipulationValue(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static StipulationValue Invalid
        {
            get { return new StipulationValue(); }
        }

        public static StipulationValue SpecialCumDividend
        {
            get { return new StipulationValue("CD"); }
        }

        public static StipulationValue SpecialExDividend
        {
            get { return new StipulationValue("XD"); }
        }

        public static StipulationValue SpecialCumCoupon
        {
            get { return new StipulationValue("CC"); }
        }

        public static StipulationValue SpecialExCoupon
        {
            get { return new StipulationValue("XC"); }
        }

        public static StipulationValue SpecialCumBonus
        {
            get { return new StipulationValue("CB"); }
        }

        public static StipulationValue SpecialExBonus
        {
            get { return new StipulationValue("XB"); }
        }

        public static StipulationValue SpecialCumRights
        {
            get { return new StipulationValue("CR"); }
        }

        public static StipulationValue SpecialExRights
        {
            get { return new StipulationValue("XR"); }
        }

        public static StipulationValue SpecialCumCapitalRepayments
        {
            get { return new StipulationValue("CP"); }
        }

        public static StipulationValue SpecialExCapitalRepayments
        {
            get { return new StipulationValue("XP"); }
        }

        public static StipulationValue CashSettlement
        {
            get { return new StipulationValue("CS"); }
        }

        public static StipulationValue SpecialPrice
        {
            get { return new StipulationValue("SP"); }
        }

        public static StipulationValue ReportForEuropeanEquityMarketSecurities
        {
            get { return new StipulationValue("TR"); }
        }

        public static StipulationValue GuaranteedDelivery
        {
            get { return new StipulationValue("GD"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct YieldType : IEquatable<YieldType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string>
                                                                     {
                                                                         {"AFTERTAX", "AfterTaxYield"},
                                                                         {"ANNUAL", "AnnualYield"},
                                                                         {"ATISSUE", "YieldAtIssue"},
                                                                         {"AVGMATURITY", "YieldToAverageMaturity"},
                                                                         {"BOOK", "BookYield"},
                                                                         {"CALL", "YieldToNextCall"},
                                                                         {"CHANGE", "YieldChangeSinceClose"},
                                                                         {"CLOSE", "ClosingYield"},
                                                                         {"COMPOUND", "CompoundYield"},
                                                                         {"CURRENT", "CurrentYield"},
                                                                         {"GROSS", "TrueGrossYield"},
                                                                         {"GOVTEQUIV", "GovernmentEquivalentYield"},
                                                                         {"INFLATION", "YieldWithInflationAssumption"},
                                                                         {"INVERSEFLOATER", "InverseFloaterBondYield"},
                                                                         {"LASTCLOSE", "MostRecentClosingYield"},
                                                                         {"LASTMONTH", "ClosingYieldMostRecentMonth"},
                                                                         {"LASTQUARTER", "ClosingYieldMostRecentQuarter"},
                                                                         {"LASTYEAR", "ClosingYieldMostRecentYear"},
                                                                         {"LONGAVGLIFE", "YieldToLongestAverageLife"},
                                                                         {"MARK", "MarkToMarketYield"},
                                                                         {"MATURITY", "YieldToMaturity"},
                                                                         {"NEXTREFUND", "YieldToNextRefund"},
                                                                         {"OPENAVG", "OpenAverageYield"},
                                                                         {"PUT", "YieldToNextPut"},
                                                                         {"PREVCLOSE", "PreviousCloseYield"},
                                                                         {"PROCEEDS", "ProceedsYield"},
                                                                         {"SEMIANNUAL", "SemiAnnualYield"},
                                                                         {"SHORTAVGLIFE", "YieldToShortestAverageLife"},
                                                                         {"SIMPLE", "SimpleYield"},
                                                                         {"TAXEQUIV", "TaxEquivalentYield"},
                                                                         {"TENDER", "YieldToTenderDate"},
                                                                         {"TRUE", "TrueYield"},
                                                                         {"VALUE1_32", "YieldValueOf132"},
                                                                         {"WORST", "YieldToWorst"},
                                                                     };

        private readonly string _value;

        private YieldType(string value)
        {
            _value = value;
        }

        public bool Equals(YieldType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is YieldType && Equals((YieldType) other);
        }

        public static bool operator ==(YieldType left, YieldType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(YieldType left, YieldType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static YieldType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for YieldType", nameof(value));

            return new YieldType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static YieldType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new YieldType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static YieldType Invalid
        {
            get { return new YieldType(); }
        }

        public static YieldType AfterTaxYield
        {
            get { return new YieldType("AFTERTAX"); }
        }

        public static YieldType AnnualYield
        {
            get { return new YieldType("ANNUAL"); }
        }

        public static YieldType YieldAtIssue
        {
            get { return new YieldType("ATISSUE"); }
        }

        public static YieldType YieldToAverageMaturity
        {
            get { return new YieldType("AVGMATURITY"); }
        }

        public static YieldType BookYield
        {
            get { return new YieldType("BOOK"); }
        }

        public static YieldType YieldToNextCall
        {
            get { return new YieldType("CALL"); }
        }

        public static YieldType YieldChangeSinceClose
        {
            get { return new YieldType("CHANGE"); }
        }

        public static YieldType ClosingYield
        {
            get { return new YieldType("CLOSE"); }
        }

        public static YieldType CompoundYield
        {
            get { return new YieldType("COMPOUND"); }
        }

        public static YieldType CurrentYield
        {
            get { return new YieldType("CURRENT"); }
        }

        public static YieldType TrueGrossYield
        {
            get { return new YieldType("GROSS"); }
        }

        public static YieldType GovernmentEquivalentYield
        {
            get { return new YieldType("GOVTEQUIV"); }
        }

        public static YieldType YieldWithInflationAssumption
        {
            get { return new YieldType("INFLATION"); }
        }

        public static YieldType InverseFloaterBondYield
        {
            get { return new YieldType("INVERSEFLOATER"); }
        }

        public static YieldType MostRecentClosingYield
        {
            get { return new YieldType("LASTCLOSE"); }
        }

        public static YieldType ClosingYieldMostRecentMonth
        {
            get { return new YieldType("LASTMONTH"); }
        }

        public static YieldType ClosingYieldMostRecentQuarter
        {
            get { return new YieldType("LASTQUARTER"); }
        }

        public static YieldType ClosingYieldMostRecentYear
        {
            get { return new YieldType("LASTYEAR"); }
        }

        public static YieldType YieldToLongestAverageLife
        {
            get { return new YieldType("LONGAVGLIFE"); }
        }

        public static YieldType MarkToMarketYield
        {
            get { return new YieldType("MARK"); }
        }

        public static YieldType YieldToMaturity
        {
            get { return new YieldType("MATURITY"); }
        }

        public static YieldType YieldToNextRefund
        {
            get { return new YieldType("NEXTREFUND"); }
        }

        public static YieldType OpenAverageYield
        {
            get { return new YieldType("OPENAVG"); }
        }

        public static YieldType YieldToNextPut
        {
            get { return new YieldType("PUT"); }
        }

        public static YieldType PreviousCloseYield
        {
            get { return new YieldType("PREVCLOSE"); }
        }

        public static YieldType ProceedsYield
        {
            get { return new YieldType("PROCEEDS"); }
        }

        public static YieldType SemiAnnualYield
        {
            get { return new YieldType("SEMIANNUAL"); }
        }

        public static YieldType YieldToShortestAverageLife
        {
            get { return new YieldType("SHORTAVGLIFE"); }
        }

        public static YieldType SimpleYield
        {
            get { return new YieldType("SIMPLE"); }
        }

        public static YieldType TaxEquivalentYield
        {
            get { return new YieldType("TAXEQUIV"); }
        }

        public static YieldType YieldToTenderDate
        {
            get { return new YieldType("TENDER"); }
        }

        public static YieldType TrueYield
        {
            get { return new YieldType("TRUE"); }
        }

        public static YieldType YieldValueOf132
        {
            get { return new YieldType("VALUE1_32"); }
        }

        public static YieldType YieldToWorst
        {
            get { return new YieldType("WORST"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SubscriptionRequestType : IEquatable<SubscriptionRequestType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Snapshot"}, {'1', "SnapshotPlusUpdates"}, {'2', "DisablePreviousSnapshotPlusUpdateRequest"},};
        private readonly char? _value;

        private SubscriptionRequestType(char value)
        {
            _value = value;
        }

        public bool Equals(SubscriptionRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SubscriptionRequestType && Equals((SubscriptionRequestType) other);
        }

        public static bool operator ==(SubscriptionRequestType left, SubscriptionRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SubscriptionRequestType left, SubscriptionRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SubscriptionRequestType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SubscriptionRequestType", nameof(value));

            return new SubscriptionRequestType(value);
        }

        public static SubscriptionRequestType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SubscriptionRequestType", nameof(value));

            return new SubscriptionRequestType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SubscriptionRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SubscriptionRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SubscriptionRequestType Invalid
        {
            get { return new SubscriptionRequestType(); }
        }

        public static SubscriptionRequestType Snapshot
        {
            get { return new SubscriptionRequestType('0'); }
        }

        public static SubscriptionRequestType SnapshotPlusUpdates
        {
            get { return new SubscriptionRequestType('1'); }
        }

        public static SubscriptionRequestType DisablePreviousSnapshotPlusUpdateRequest
        {
            get { return new SubscriptionRequestType('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MDUpdateType : IEquatable<MDUpdateType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "FullRefresh"}, {1, "IncrementalRefresh"},};
        private readonly int? _value;

        private MDUpdateType(int value)
        {
            _value = value;
        }

        public bool Equals(MDUpdateType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MDUpdateType && Equals((MDUpdateType) other);
        }

        public static bool operator ==(MDUpdateType left, MDUpdateType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MDUpdateType left, MDUpdateType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MDUpdateType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDUpdateType", nameof(value));

            return new MDUpdateType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MDUpdateType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MDUpdateType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MDUpdateType Invalid
        {
            get { return new MDUpdateType(); }
        }

        public static MDUpdateType FullRefresh
        {
            get { return new MDUpdateType(0); }
        }

        public static MDUpdateType IncrementalRefresh
        {
            get { return new MDUpdateType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MDEntryType : IEquatable<MDEntryType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "Bid"}, {'1', "Offer"}, {'2', "Trade"}, {'3', "IndexValue"}, {'4', "OpeningPrice"}, {'5', "ClosingPrice"}, {'6', "SettlementPrice"}, {'7', "TradingSessionHighPrice"}, {'8', "TradingSessionLowPrice"}, {'9', "TradingSessionVwapPrice"}, {'A', "Imbalance"}, {'B', "TradeVolume"}, {'C', "OpenInterest"},};
        private readonly char? _value;

        private MDEntryType(char value)
        {
            _value = value;
        }

        public bool Equals(MDEntryType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MDEntryType && Equals((MDEntryType) other);
        }

        public static bool operator ==(MDEntryType left, MDEntryType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MDEntryType left, MDEntryType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MDEntryType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDEntryType", nameof(value));

            return new MDEntryType(value);
        }

        public static MDEntryType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDEntryType", nameof(value));

            return new MDEntryType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MDEntryType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MDEntryType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MDEntryType Invalid
        {
            get { return new MDEntryType(); }
        }

        public static MDEntryType Bid
        {
            get { return new MDEntryType('0'); }
        }

        public static MDEntryType Offer
        {
            get { return new MDEntryType('1'); }
        }

        public static MDEntryType Trade
        {
            get { return new MDEntryType('2'); }
        }

        public static MDEntryType IndexValue
        {
            get { return new MDEntryType('3'); }
        }

        public static MDEntryType OpeningPrice
        {
            get { return new MDEntryType('4'); }
        }

        public static MDEntryType ClosingPrice
        {
            get { return new MDEntryType('5'); }
        }

        public static MDEntryType SettlementPrice
        {
            get { return new MDEntryType('6'); }
        }

        public static MDEntryType TradingSessionHighPrice
        {
            get { return new MDEntryType('7'); }
        }

        public static MDEntryType TradingSessionLowPrice
        {
            get { return new MDEntryType('8'); }
        }

        public static MDEntryType TradingSessionVwapPrice
        {
            get { return new MDEntryType('9'); }
        }

        public static MDEntryType Imbalance
        {
            get { return new MDEntryType('A'); }
        }

        public static MDEntryType TradeVolume
        {
            get { return new MDEntryType('B'); }
        }

        public static MDEntryType OpenInterest
        {
            get { return new MDEntryType('C'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TickDirection : IEquatable<TickDirection>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "PlusTick"}, {'1', "ZeroPlusTick"}, {'2', "MinusTick"}, {'3', "ZeroMinusTick"},};
        private readonly char? _value;

        private TickDirection(char value)
        {
            _value = value;
        }

        public bool Equals(TickDirection other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TickDirection && Equals((TickDirection) other);
        }

        public static bool operator ==(TickDirection left, TickDirection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TickDirection left, TickDirection right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TickDirection FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TickDirection", nameof(value));

            return new TickDirection(value);
        }

        public static TickDirection FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TickDirection", nameof(value));

            return new TickDirection(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TickDirection FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TickDirection(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TickDirection Invalid
        {
            get { return new TickDirection(); }
        }

        public static TickDirection PlusTick
        {
            get { return new TickDirection('0'); }
        }

        public static TickDirection ZeroPlusTick
        {
            get { return new TickDirection('1'); }
        }

        public static TickDirection MinusTick
        {
            get { return new TickDirection('2'); }
        }

        public static TickDirection ZeroMinusTick
        {
            get { return new TickDirection('3'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteCondition : IEquatable<QuoteCondition>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"A", "OpenActive"}, {"B", "ClosedInactive"}, {"C", "ExchangeBest"}, {"D", "ConsolidatedBest"}, {"E", "Locked"}, {"F", "Crossed"}, {"G", "Depth"}, {"H", "FastTrading"}, {"I", "NonFirm"},};
        private readonly string _value;

        private QuoteCondition(string value)
        {
            _value = value;
        }

        public bool Equals(QuoteCondition other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteCondition && Equals((QuoteCondition) other);
        }

        public static bool operator ==(QuoteCondition left, QuoteCondition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteCondition left, QuoteCondition right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static QuoteCondition FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteCondition", nameof(value));

            return new QuoteCondition(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static QuoteCondition FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteCondition(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteCondition Invalid
        {
            get { return new QuoteCondition(); }
        }

        public static QuoteCondition OpenActive
        {
            get { return new QuoteCondition("A"); }
        }

        public static QuoteCondition ClosedInactive
        {
            get { return new QuoteCondition("B"); }
        }

        public static QuoteCondition ExchangeBest
        {
            get { return new QuoteCondition("C"); }
        }

        public static QuoteCondition ConsolidatedBest
        {
            get { return new QuoteCondition("D"); }
        }

        public static QuoteCondition Locked
        {
            get { return new QuoteCondition("E"); }
        }

        public static QuoteCondition Crossed
        {
            get { return new QuoteCondition("F"); }
        }

        public static QuoteCondition Depth
        {
            get { return new QuoteCondition("G"); }
        }

        public static QuoteCondition FastTrading
        {
            get { return new QuoteCondition("H"); }
        }

        public static QuoteCondition NonFirm
        {
            get { return new QuoteCondition("I"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeCondition : IEquatable<TradeCondition>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"A", "CashMarket"}, {"B", "AveragePriceTrade"}, {"C", "CashTrade"}, {"D", "NextDayMarket"}, {"E", "OpeningReopeningTradeDetail"}, {"F", "IntradayTradeDetail"}, {"G", "Rule127"}, {"H", "Rule155"}, {"I", "SoldLast"}, {"J", "NextDayTrade"}, {"K", "Opened"}, {"L", "Seller"}, {"M", "Sold"}, {"N", "StoppedStock"}, {"P", "ImbalanceMoreBuyers"}, {"Q", "ImbalanceMoreSellers"}, {"R", "OpeningPrice"},};
        private readonly string _value;

        private TradeCondition(string value)
        {
            _value = value;
        }

        public bool Equals(TradeCondition other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeCondition && Equals((TradeCondition) other);
        }

        public static bool operator ==(TradeCondition left, TradeCondition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeCondition left, TradeCondition right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static TradeCondition FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeCondition", nameof(value));

            return new TradeCondition(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static TradeCondition FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeCondition(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeCondition Invalid
        {
            get { return new TradeCondition(); }
        }

        public static TradeCondition CashMarket
        {
            get { return new TradeCondition("A"); }
        }

        public static TradeCondition AveragePriceTrade
        {
            get { return new TradeCondition("B"); }
        }

        public static TradeCondition CashTrade
        {
            get { return new TradeCondition("C"); }
        }

        public static TradeCondition NextDayMarket
        {
            get { return new TradeCondition("D"); }
        }

        public static TradeCondition OpeningReopeningTradeDetail
        {
            get { return new TradeCondition("E"); }
        }

        public static TradeCondition IntradayTradeDetail
        {
            get { return new TradeCondition("F"); }
        }

        public static TradeCondition Rule127
        {
            get { return new TradeCondition("G"); }
        }

        public static TradeCondition Rule155
        {
            get { return new TradeCondition("H"); }
        }

        public static TradeCondition SoldLast
        {
            get { return new TradeCondition("I"); }
        }

        public static TradeCondition NextDayTrade
        {
            get { return new TradeCondition("J"); }
        }

        public static TradeCondition Opened
        {
            get { return new TradeCondition("K"); }
        }

        public static TradeCondition Seller
        {
            get { return new TradeCondition("L"); }
        }

        public static TradeCondition Sold
        {
            get { return new TradeCondition("M"); }
        }

        public static TradeCondition StoppedStock
        {
            get { return new TradeCondition("N"); }
        }

        public static TradeCondition ImbalanceMoreBuyers
        {
            get { return new TradeCondition("P"); }
        }

        public static TradeCondition ImbalanceMoreSellers
        {
            get { return new TradeCondition("Q"); }
        }

        public static TradeCondition OpeningPrice
        {
            get { return new TradeCondition("R"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MDUpdateAction : IEquatable<MDUpdateAction>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "New"}, {'1', "Change"}, {'2', "Delete"},};
        private readonly char? _value;

        private MDUpdateAction(char value)
        {
            _value = value;
        }

        public bool Equals(MDUpdateAction other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MDUpdateAction && Equals((MDUpdateAction) other);
        }

        public static bool operator ==(MDUpdateAction left, MDUpdateAction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MDUpdateAction left, MDUpdateAction right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MDUpdateAction FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDUpdateAction", nameof(value));

            return new MDUpdateAction(value);
        }

        public static MDUpdateAction FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDUpdateAction", nameof(value));

            return new MDUpdateAction(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MDUpdateAction FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MDUpdateAction(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MDUpdateAction Invalid
        {
            get { return new MDUpdateAction(); }
        }

        public static MDUpdateAction New
        {
            get { return new MDUpdateAction('0'); }
        }

        public static MDUpdateAction Change
        {
            get { return new MDUpdateAction('1'); }
        }

        public static MDUpdateAction Delete
        {
            get { return new MDUpdateAction('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MDReqRejReason : IEquatable<MDReqRejReason>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "UnknownSymbol"}, {'1', "DuplicateMdreqid"}, {'2', "InsufficientBandwidth"}, {'3', "InsufficientPermissions"}, {'4', "UnsupportedSubscriptionrequesttype"}, {'5', "UnsupportedMarketdepth"}, {'6', "UnsupportedMdupdatetype"}, {'7', "UnsupportedAggregatedbook"}, {'8', "UnsupportedMdentrytype"}, {'9', "UnsupportedTradingsessionid"}, {'A', "UnsupportedScope"}, {'B', "UnsupportedOpenclosesettleflag"}, {'C', "UnsupportedMdimplicitdelete"},};
        private readonly char? _value;

        private MDReqRejReason(char value)
        {
            _value = value;
        }

        public bool Equals(MDReqRejReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MDReqRejReason && Equals((MDReqRejReason) other);
        }

        public static bool operator ==(MDReqRejReason left, MDReqRejReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MDReqRejReason left, MDReqRejReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MDReqRejReason FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDReqRejReason", nameof(value));

            return new MDReqRejReason(value);
        }

        public static MDReqRejReason FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MDReqRejReason", nameof(value));

            return new MDReqRejReason(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MDReqRejReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MDReqRejReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MDReqRejReason Invalid
        {
            get { return new MDReqRejReason(); }
        }

        public static MDReqRejReason UnknownSymbol
        {
            get { return new MDReqRejReason('0'); }
        }

        public static MDReqRejReason DuplicateMdreqid
        {
            get { return new MDReqRejReason('1'); }
        }

        public static MDReqRejReason InsufficientBandwidth
        {
            get { return new MDReqRejReason('2'); }
        }

        public static MDReqRejReason InsufficientPermissions
        {
            get { return new MDReqRejReason('3'); }
        }

        public static MDReqRejReason UnsupportedSubscriptionrequesttype
        {
            get { return new MDReqRejReason('4'); }
        }

        public static MDReqRejReason UnsupportedMarketdepth
        {
            get { return new MDReqRejReason('5'); }
        }

        public static MDReqRejReason UnsupportedMdupdatetype
        {
            get { return new MDReqRejReason('6'); }
        }

        public static MDReqRejReason UnsupportedAggregatedbook
        {
            get { return new MDReqRejReason('7'); }
        }

        public static MDReqRejReason UnsupportedMdentrytype
        {
            get { return new MDReqRejReason('8'); }
        }

        public static MDReqRejReason UnsupportedTradingsessionid
        {
            get { return new MDReqRejReason('9'); }
        }

        public static MDReqRejReason UnsupportedScope
        {
            get { return new MDReqRejReason('A'); }
        }

        public static MDReqRejReason UnsupportedOpenclosesettleflag
        {
            get { return new MDReqRejReason('B'); }
        }

        public static MDReqRejReason UnsupportedMdimplicitdelete
        {
            get { return new MDReqRejReason('C'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DeleteReason : IEquatable<DeleteReason>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "CancelationTradeBust"}, {'1', "Error"},};
        private readonly char? _value;

        private DeleteReason(char value)
        {
            _value = value;
        }

        public bool Equals(DeleteReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DeleteReason && Equals((DeleteReason) other);
        }

        public static bool operator ==(DeleteReason left, DeleteReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DeleteReason left, DeleteReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DeleteReason FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DeleteReason", nameof(value));

            return new DeleteReason(value);
        }

        public static DeleteReason FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DeleteReason", nameof(value));

            return new DeleteReason(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DeleteReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DeleteReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DeleteReason Invalid
        {
            get { return new DeleteReason(); }
        }

        public static DeleteReason CancelationTradeBust
        {
            get { return new DeleteReason('0'); }
        }

        public static DeleteReason Error
        {
            get { return new DeleteReason('1'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OpenCloseSettlFlag : IEquatable<OpenCloseSettlFlag>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"0", "DailyOpenCloseSettlementEntry"}, {"1", "SessionOpenCloseSettlementEntry"}, {"2", "DeliverySettlementEntry"}, {"3", "ExpectedEntry"}, {"4", "EntryFromPreviousBusinessDay"}, {"5", "TheoreticalPriceValue"},};
        private readonly string _value;

        private OpenCloseSettlFlag(string value)
        {
            _value = value;
        }

        public bool Equals(OpenCloseSettlFlag other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OpenCloseSettlFlag && Equals((OpenCloseSettlFlag) other);
        }

        public static bool operator ==(OpenCloseSettlFlag left, OpenCloseSettlFlag right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OpenCloseSettlFlag left, OpenCloseSettlFlag right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static OpenCloseSettlFlag FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OpenCloseSettlFlag", nameof(value));

            return new OpenCloseSettlFlag(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static OpenCloseSettlFlag FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OpenCloseSettlFlag(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OpenCloseSettlFlag Invalid
        {
            get { return new OpenCloseSettlFlag(); }
        }

        public static OpenCloseSettlFlag DailyOpenCloseSettlementEntry
        {
            get { return new OpenCloseSettlFlag("0"); }
        }

        public static OpenCloseSettlFlag SessionOpenCloseSettlementEntry
        {
            get { return new OpenCloseSettlFlag("1"); }
        }

        public static OpenCloseSettlFlag DeliverySettlementEntry
        {
            get { return new OpenCloseSettlFlag("2"); }
        }

        public static OpenCloseSettlFlag ExpectedEntry
        {
            get { return new OpenCloseSettlFlag("3"); }
        }

        public static OpenCloseSettlFlag EntryFromPreviousBusinessDay
        {
            get { return new OpenCloseSettlFlag("4"); }
        }

        public static OpenCloseSettlFlag TheoreticalPriceValue
        {
            get { return new OpenCloseSettlFlag("5"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct FinancialStatus : IEquatable<FinancialStatus>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"1", "Bankrupt"}, {"2", "PendingDelisting"},};
        private readonly string _value;

        private FinancialStatus(string value)
        {
            _value = value;
        }

        public bool Equals(FinancialStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is FinancialStatus && Equals((FinancialStatus) other);
        }

        public static bool operator ==(FinancialStatus left, FinancialStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FinancialStatus left, FinancialStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static FinancialStatus FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for FinancialStatus", nameof(value));

            return new FinancialStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static FinancialStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new FinancialStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static FinancialStatus Invalid
        {
            get { return new FinancialStatus(); }
        }

        public static FinancialStatus Bankrupt
        {
            get { return new FinancialStatus("1"); }
        }

        public static FinancialStatus PendingDelisting
        {
            get { return new FinancialStatus("2"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CorporateAction : IEquatable<CorporateAction>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"A", "ExDividend"}, {"B", "ExDistribution"}, {"C", "ExRights"}, {"D", "New"}, {"E", "ExInterest"},};
        private readonly string _value;

        private CorporateAction(string value)
        {
            _value = value;
        }

        public bool Equals(CorporateAction other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CorporateAction && Equals((CorporateAction) other);
        }

        public static bool operator ==(CorporateAction left, CorporateAction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CorporateAction left, CorporateAction right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static CorporateAction FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CorporateAction", nameof(value));

            return new CorporateAction(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static CorporateAction FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CorporateAction(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CorporateAction Invalid
        {
            get { return new CorporateAction(); }
        }

        public static CorporateAction ExDividend
        {
            get { return new CorporateAction("A"); }
        }

        public static CorporateAction ExDistribution
        {
            get { return new CorporateAction("B"); }
        }

        public static CorporateAction ExRights
        {
            get { return new CorporateAction("C"); }
        }

        public static CorporateAction New
        {
            get { return new CorporateAction("D"); }
        }

        public static CorporateAction ExInterest
        {
            get { return new CorporateAction("E"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteStatus : IEquatable<QuoteStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Accepted"}, {1, "CanceledForSymbol"}, {2, "CanceledForSecurityType"}, {3, "CanceledForUnderlying"}, {4, "CanceledAll"}, {5, "Rejected"}, {6, "RemovedFromMarket"}, {7, "Expired"}, {8, "Query"}, {9, "QuoteNotFound"}, {10, "Pending"}, {11, "Pass"}, {12, "LockedMarketWarning"}, {13, "CrossMarketWarning"}, {14, "CanceledDueToLockMarket"}, {15, "CanceledDueToCrossMarket"},};
        private readonly int? _value;

        private QuoteStatus(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteStatus && Equals((QuoteStatus) other);
        }

        public static bool operator ==(QuoteStatus left, QuoteStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteStatus left, QuoteStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteStatus", nameof(value));

            return new QuoteStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteStatus Invalid
        {
            get { return new QuoteStatus(); }
        }

        public static QuoteStatus Accepted
        {
            get { return new QuoteStatus(0); }
        }

        public static QuoteStatus CanceledForSymbol
        {
            get { return new QuoteStatus(1); }
        }

        public static QuoteStatus CanceledForSecurityType
        {
            get { return new QuoteStatus(2); }
        }

        public static QuoteStatus CanceledForUnderlying
        {
            get { return new QuoteStatus(3); }
        }

        public static QuoteStatus CanceledAll
        {
            get { return new QuoteStatus(4); }
        }

        public static QuoteStatus Rejected
        {
            get { return new QuoteStatus(5); }
        }

        public static QuoteStatus RemovedFromMarket
        {
            get { return new QuoteStatus(6); }
        }

        public static QuoteStatus Expired
        {
            get { return new QuoteStatus(7); }
        }

        public static QuoteStatus Query
        {
            get { return new QuoteStatus(8); }
        }

        public static QuoteStatus QuoteNotFound
        {
            get { return new QuoteStatus(9); }
        }

        public static QuoteStatus Pending
        {
            get { return new QuoteStatus(10); }
        }

        public static QuoteStatus Pass
        {
            get { return new QuoteStatus(11); }
        }

        public static QuoteStatus LockedMarketWarning
        {
            get { return new QuoteStatus(12); }
        }

        public static QuoteStatus CrossMarketWarning
        {
            get { return new QuoteStatus(13); }
        }

        public static QuoteStatus CanceledDueToLockMarket
        {
            get { return new QuoteStatus(14); }
        }

        public static QuoteStatus CanceledDueToCrossMarket
        {
            get { return new QuoteStatus(15); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteCancelType : IEquatable<QuoteCancelType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "CancelForSymbol"}, {2, "CancelForSecurityType"}, {3, "CancelForUnderlyingSymbol"}, {4, "CancelAllQuotes"},};
        private readonly int? _value;

        private QuoteCancelType(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteCancelType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteCancelType && Equals((QuoteCancelType) other);
        }

        public static bool operator ==(QuoteCancelType left, QuoteCancelType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteCancelType left, QuoteCancelType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteCancelType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteCancelType", nameof(value));

            return new QuoteCancelType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteCancelType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteCancelType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteCancelType Invalid
        {
            get { return new QuoteCancelType(); }
        }

        public static QuoteCancelType CancelForSymbol
        {
            get { return new QuoteCancelType(1); }
        }

        public static QuoteCancelType CancelForSecurityType
        {
            get { return new QuoteCancelType(2); }
        }

        public static QuoteCancelType CancelForUnderlyingSymbol
        {
            get { return new QuoteCancelType(3); }
        }

        public static QuoteCancelType CancelAllQuotes
        {
            get { return new QuoteCancelType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteRejectReason : IEquatable<QuoteRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "UnknownSymbol"}, {2, "ExchangeClosed"}, {3, "QuoteRequestExceedsLimit"}, {4, "TooLateToEnter"}, {5, "UnknownQuote"}, {6, "DuplicateQuote"}, {7, "InvalidBidAskSpread"}, {8, "InvalidPrice"}, {9, "NotAuthorizedToQuoteSecurity"}, {99, "Other"},};
        private readonly int? _value;

        private QuoteRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteRejectReason && Equals((QuoteRejectReason) other);
        }

        public static bool operator ==(QuoteRejectReason left, QuoteRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteRejectReason left, QuoteRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteRejectReason", nameof(value));

            return new QuoteRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteRejectReason Invalid
        {
            get { return new QuoteRejectReason(); }
        }

        public static QuoteRejectReason UnknownSymbol
        {
            get { return new QuoteRejectReason(1); }
        }

        public static QuoteRejectReason ExchangeClosed
        {
            get { return new QuoteRejectReason(2); }
        }

        public static QuoteRejectReason QuoteRequestExceedsLimit
        {
            get { return new QuoteRejectReason(3); }
        }

        public static QuoteRejectReason TooLateToEnter
        {
            get { return new QuoteRejectReason(4); }
        }

        public static QuoteRejectReason UnknownQuote
        {
            get { return new QuoteRejectReason(5); }
        }

        public static QuoteRejectReason DuplicateQuote
        {
            get { return new QuoteRejectReason(6); }
        }

        public static QuoteRejectReason InvalidBidAskSpread
        {
            get { return new QuoteRejectReason(7); }
        }

        public static QuoteRejectReason InvalidPrice
        {
            get { return new QuoteRejectReason(8); }
        }

        public static QuoteRejectReason NotAuthorizedToQuoteSecurity
        {
            get { return new QuoteRejectReason(9); }
        }

        public static QuoteRejectReason Other
        {
            get { return new QuoteRejectReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteResponseLevel : IEquatable<QuoteResponseLevel>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "NoAcknowledgement"}, {1, "AcknowledgeOnlyNegativeOrErroneousQuotes"}, {2, "AcknowledgeEachQuoteMessages"},};
        private readonly int? _value;

        private QuoteResponseLevel(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteResponseLevel other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteResponseLevel && Equals((QuoteResponseLevel) other);
        }

        public static bool operator ==(QuoteResponseLevel left, QuoteResponseLevel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteResponseLevel left, QuoteResponseLevel right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteResponseLevel FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteResponseLevel", nameof(value));

            return new QuoteResponseLevel(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteResponseLevel FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteResponseLevel(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteResponseLevel Invalid
        {
            get { return new QuoteResponseLevel(); }
        }

        public static QuoteResponseLevel NoAcknowledgement
        {
            get { return new QuoteResponseLevel(0); }
        }

        public static QuoteResponseLevel AcknowledgeOnlyNegativeOrErroneousQuotes
        {
            get { return new QuoteResponseLevel(1); }
        }

        public static QuoteResponseLevel AcknowledgeEachQuoteMessages
        {
            get { return new QuoteResponseLevel(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteRequestType : IEquatable<QuoteRequestType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Manual"}, {2, "Automatic"},};
        private readonly int? _value;

        private QuoteRequestType(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteRequestType && Equals((QuoteRequestType) other);
        }

        public static bool operator ==(QuoteRequestType left, QuoteRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteRequestType left, QuoteRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteRequestType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteRequestType", nameof(value));

            return new QuoteRequestType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteRequestType Invalid
        {
            get { return new QuoteRequestType(); }
        }

        public static QuoteRequestType Manual
        {
            get { return new QuoteRequestType(1); }
        }

        public static QuoteRequestType Automatic
        {
            get { return new QuoteRequestType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct UnderlyingPutOrCall : IEquatable<UnderlyingPutOrCall>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Put"}, {1, "Call"},};
        private readonly int? _value;

        private UnderlyingPutOrCall(int value)
        {
            _value = value;
        }

        public bool Equals(UnderlyingPutOrCall other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is UnderlyingPutOrCall && Equals((UnderlyingPutOrCall) other);
        }

        public static bool operator ==(UnderlyingPutOrCall left, UnderlyingPutOrCall right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UnderlyingPutOrCall left, UnderlyingPutOrCall right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static UnderlyingPutOrCall FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for UnderlyingPutOrCall", nameof(value));

            return new UnderlyingPutOrCall(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static UnderlyingPutOrCall FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new UnderlyingPutOrCall(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static UnderlyingPutOrCall Invalid
        {
            get { return new UnderlyingPutOrCall(); }
        }

        public static UnderlyingPutOrCall Put
        {
            get { return new UnderlyingPutOrCall(0); }
        }

        public static UnderlyingPutOrCall Call
        {
            get { return new UnderlyingPutOrCall(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityRequestType : IEquatable<SecurityRequestType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "RequestSecurityIdentityAndSpecifications"}, {1, "RequestSecurityIdentityForTheSpecificationsProvided"}, {2, "RequestListSecurityTypes"}, {3, "RequestListSecurities"},};
        private readonly int? _value;

        private SecurityRequestType(int value)
        {
            _value = value;
        }

        public bool Equals(SecurityRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityRequestType && Equals((SecurityRequestType) other);
        }

        public static bool operator ==(SecurityRequestType left, SecurityRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityRequestType left, SecurityRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SecurityRequestType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityRequestType", nameof(value));

            return new SecurityRequestType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SecurityRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityRequestType Invalid
        {
            get { return new SecurityRequestType(); }
        }

        public static SecurityRequestType RequestSecurityIdentityAndSpecifications
        {
            get { return new SecurityRequestType(0); }
        }

        public static SecurityRequestType RequestSecurityIdentityForTheSpecificationsProvided
        {
            get { return new SecurityRequestType(1); }
        }

        public static SecurityRequestType RequestListSecurityTypes
        {
            get { return new SecurityRequestType(2); }
        }

        public static SecurityRequestType RequestListSecurities
        {
            get { return new SecurityRequestType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityResponseType : IEquatable<SecurityResponseType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "AcceptSecurityProposalAsIs"}, {2, "AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage"}, {3, "ListOfSecurityTypesReturnedPerRequest"}, {4, "ListOfSecuritiesReturnedPerRequest"}, {5, "RejectSecurityProposal"}, {6, "CanNotMatchSelectionCriteria"},};
        private readonly int? _value;

        private SecurityResponseType(int value)
        {
            _value = value;
        }

        public bool Equals(SecurityResponseType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityResponseType && Equals((SecurityResponseType) other);
        }

        public static bool operator ==(SecurityResponseType left, SecurityResponseType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityResponseType left, SecurityResponseType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SecurityResponseType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityResponseType", nameof(value));

            return new SecurityResponseType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SecurityResponseType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityResponseType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityResponseType Invalid
        {
            get { return new SecurityResponseType(); }
        }

        public static SecurityResponseType AcceptSecurityProposalAsIs
        {
            get { return new SecurityResponseType(1); }
        }

        public static SecurityResponseType AcceptSecurityProposalWithRevisionsAsIndicatedInTheMessage
        {
            get { return new SecurityResponseType(2); }
        }

        public static SecurityResponseType ListOfSecurityTypesReturnedPerRequest
        {
            get { return new SecurityResponseType(3); }
        }

        public static SecurityResponseType ListOfSecuritiesReturnedPerRequest
        {
            get { return new SecurityResponseType(4); }
        }

        public static SecurityResponseType RejectSecurityProposal
        {
            get { return new SecurityResponseType(5); }
        }

        public static SecurityResponseType CanNotMatchSelectionCriteria
        {
            get { return new SecurityResponseType(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityTradingStatus : IEquatable<SecurityTradingStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "OpeningDelay"}, {2, "TradingHalt"}, {3, "Resume"}, {4, "NoOpenNoResume"}, {5, "PriceIndication"}, {6, "TradingRangeIndication"}, {7, "MarketImbalanceBuy"}, {8, "MarketImbalanceSell"}, {9, "MarketOnCloseImbalanceBuy"}, {10, "MarketOnCloseImbalanceSell"}, {11, "NotAssigned"}, {12, "NoMarketImbalance"}, {13, "NoMarketOnCloseImbalance"}, {14, "ItsPreOpening"}, {15, "NewPriceIndication"}, {16, "TradeDisseminationTime"}, {17, "ReadyToTradeStartOfSession"}, {18, "NotAvailableForTradingEndOfSession"}, {19, "NotTradedOnThisMarket"}, {20, "UnknownOrInvalid"}, {21, "PreOpen"}, {22, "OpeningRotation"}, {23, "FastMarket"},};
        private readonly int? _value;

        private SecurityTradingStatus(int value)
        {
            _value = value;
        }

        public bool Equals(SecurityTradingStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityTradingStatus && Equals((SecurityTradingStatus) other);
        }

        public static bool operator ==(SecurityTradingStatus left, SecurityTradingStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityTradingStatus left, SecurityTradingStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SecurityTradingStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityTradingStatus", nameof(value));

            return new SecurityTradingStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SecurityTradingStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityTradingStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityTradingStatus Invalid
        {
            get { return new SecurityTradingStatus(); }
        }

        public static SecurityTradingStatus OpeningDelay
        {
            get { return new SecurityTradingStatus(1); }
        }

        public static SecurityTradingStatus TradingHalt
        {
            get { return new SecurityTradingStatus(2); }
        }

        public static SecurityTradingStatus Resume
        {
            get { return new SecurityTradingStatus(3); }
        }

        public static SecurityTradingStatus NoOpenNoResume
        {
            get { return new SecurityTradingStatus(4); }
        }

        public static SecurityTradingStatus PriceIndication
        {
            get { return new SecurityTradingStatus(5); }
        }

        public static SecurityTradingStatus TradingRangeIndication
        {
            get { return new SecurityTradingStatus(6); }
        }

        public static SecurityTradingStatus MarketImbalanceBuy
        {
            get { return new SecurityTradingStatus(7); }
        }

        public static SecurityTradingStatus MarketImbalanceSell
        {
            get { return new SecurityTradingStatus(8); }
        }

        public static SecurityTradingStatus MarketOnCloseImbalanceBuy
        {
            get { return new SecurityTradingStatus(9); }
        }

        public static SecurityTradingStatus MarketOnCloseImbalanceSell
        {
            get { return new SecurityTradingStatus(10); }
        }

        public static SecurityTradingStatus NotAssigned
        {
            get { return new SecurityTradingStatus(11); }
        }

        public static SecurityTradingStatus NoMarketImbalance
        {
            get { return new SecurityTradingStatus(12); }
        }

        public static SecurityTradingStatus NoMarketOnCloseImbalance
        {
            get { return new SecurityTradingStatus(13); }
        }

        public static SecurityTradingStatus ItsPreOpening
        {
            get { return new SecurityTradingStatus(14); }
        }

        public static SecurityTradingStatus NewPriceIndication
        {
            get { return new SecurityTradingStatus(15); }
        }

        public static SecurityTradingStatus TradeDisseminationTime
        {
            get { return new SecurityTradingStatus(16); }
        }

        public static SecurityTradingStatus ReadyToTradeStartOfSession
        {
            get { return new SecurityTradingStatus(17); }
        }

        public static SecurityTradingStatus NotAvailableForTradingEndOfSession
        {
            get { return new SecurityTradingStatus(18); }
        }

        public static SecurityTradingStatus NotTradedOnThisMarket
        {
            get { return new SecurityTradingStatus(19); }
        }

        public static SecurityTradingStatus UnknownOrInvalid
        {
            get { return new SecurityTradingStatus(20); }
        }

        public static SecurityTradingStatus PreOpen
        {
            get { return new SecurityTradingStatus(21); }
        }

        public static SecurityTradingStatus OpeningRotation
        {
            get { return new SecurityTradingStatus(22); }
        }

        public static SecurityTradingStatus FastMarket
        {
            get { return new SecurityTradingStatus(23); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct HaltReason : IEquatable<HaltReason>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'I', "OrderImbalance"}, {'X', "EquipmentChangeover"}, {'P', "NewsPending"}, {'D', "NewsDissemination"}, {'E', "OrderInflux"}, {'M', "AdditionalInformation"},};
        private readonly char? _value;

        private HaltReason(char value)
        {
            _value = value;
        }

        public bool Equals(HaltReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is HaltReason && Equals((HaltReason) other);
        }

        public static bool operator ==(HaltReason left, HaltReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HaltReason left, HaltReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static HaltReason FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for HaltReason", nameof(value));

            return new HaltReason(value);
        }

        public static HaltReason FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for HaltReason", nameof(value));

            return new HaltReason(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static HaltReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new HaltReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static HaltReason Invalid
        {
            get { return new HaltReason(); }
        }

        public static HaltReason OrderImbalance
        {
            get { return new HaltReason('I'); }
        }

        public static HaltReason EquipmentChangeover
        {
            get { return new HaltReason('X'); }
        }

        public static HaltReason NewsPending
        {
            get { return new HaltReason('P'); }
        }

        public static HaltReason NewsDissemination
        {
            get { return new HaltReason('D'); }
        }

        public static HaltReason OrderInflux
        {
            get { return new HaltReason('E'); }
        }

        public static HaltReason AdditionalInformation
        {
            get { return new HaltReason('M'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct Adjustment : IEquatable<Adjustment>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Cancel"}, {2, "Error"}, {3, "Correction"},};
        private readonly int? _value;

        private Adjustment(int value)
        {
            _value = value;
        }

        public bool Equals(Adjustment other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is Adjustment && Equals((Adjustment) other);
        }

        public static bool operator ==(Adjustment left, Adjustment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Adjustment left, Adjustment right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static Adjustment FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Adjustment", nameof(value));

            return new Adjustment(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static Adjustment FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new Adjustment(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static Adjustment Invalid
        {
            get { return new Adjustment(); }
        }

        public static Adjustment Cancel
        {
            get { return new Adjustment(1); }
        }

        public static Adjustment Error
        {
            get { return new Adjustment(2); }
        }

        public static Adjustment Correction
        {
            get { return new Adjustment(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradSesMethod : IEquatable<TradSesMethod>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Electronic"}, {2, "OpenOutcry"}, {3, "TwoParty"},};
        private readonly int? _value;

        private TradSesMethod(int value)
        {
            _value = value;
        }

        public bool Equals(TradSesMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradSesMethod && Equals((TradSesMethod) other);
        }

        public static bool operator ==(TradSesMethod left, TradSesMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradSesMethod left, TradSesMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradSesMethod FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradSesMethod", nameof(value));

            return new TradSesMethod(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradSesMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradSesMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradSesMethod Invalid
        {
            get { return new TradSesMethod(); }
        }

        public static TradSesMethod Electronic
        {
            get { return new TradSesMethod(1); }
        }

        public static TradSesMethod OpenOutcry
        {
            get { return new TradSesMethod(2); }
        }

        public static TradSesMethod TwoParty
        {
            get { return new TradSesMethod(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradSesMode : IEquatable<TradSesMode>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Testing"}, {2, "Simulated"}, {3, "Production"},};
        private readonly int? _value;

        private TradSesMode(int value)
        {
            _value = value;
        }

        public bool Equals(TradSesMode other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradSesMode && Equals((TradSesMode) other);
        }

        public static bool operator ==(TradSesMode left, TradSesMode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradSesMode left, TradSesMode right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradSesMode FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradSesMode", nameof(value));

            return new TradSesMode(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradSesMode FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradSesMode(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradSesMode Invalid
        {
            get { return new TradSesMode(); }
        }

        public static TradSesMode Testing
        {
            get { return new TradSesMode(1); }
        }

        public static TradSesMode Simulated
        {
            get { return new TradSesMode(2); }
        }

        public static TradSesMode Production
        {
            get { return new TradSesMode(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradSesStatus : IEquatable<TradSesStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Unknown"}, {1, "Halted"}, {2, "Open"}, {3, "Closed"}, {4, "PreOpen"}, {5, "PreClose"}, {6, "RequestRejected"},};
        private readonly int? _value;

        private TradSesStatus(int value)
        {
            _value = value;
        }

        public bool Equals(TradSesStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradSesStatus && Equals((TradSesStatus) other);
        }

        public static bool operator ==(TradSesStatus left, TradSesStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradSesStatus left, TradSesStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradSesStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradSesStatus", nameof(value));

            return new TradSesStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradSesStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradSesStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradSesStatus Invalid
        {
            get { return new TradSesStatus(); }
        }

        public static TradSesStatus Unknown
        {
            get { return new TradSesStatus(0); }
        }

        public static TradSesStatus Halted
        {
            get { return new TradSesStatus(1); }
        }

        public static TradSesStatus Open
        {
            get { return new TradSesStatus(2); }
        }

        public static TradSesStatus Closed
        {
            get { return new TradSesStatus(3); }
        }

        public static TradSesStatus PreOpen
        {
            get { return new TradSesStatus(4); }
        }

        public static TradSesStatus PreClose
        {
            get { return new TradSesStatus(5); }
        }

        public static TradSesStatus RequestRejected
        {
            get { return new TradSesStatus(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MessageEncoding : IEquatable<MessageEncoding>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"ISO-2022-JP", "Iso2022Jp"}, {"EUC-JP", "EucJp"}, {"SHIFT_JIS", "ShiftJis"}, {"UTF-8", "Utf8"},};
        private readonly string _value;

        private MessageEncoding(string value)
        {
            _value = value;
        }

        public bool Equals(MessageEncoding other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MessageEncoding && Equals((MessageEncoding) other);
        }

        public static bool operator ==(MessageEncoding left, MessageEncoding right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MessageEncoding left, MessageEncoding right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static MessageEncoding FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MessageEncoding", nameof(value));

            return new MessageEncoding(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static MessageEncoding FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MessageEncoding(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MessageEncoding Invalid
        {
            get { return new MessageEncoding(); }
        }

        public static MessageEncoding Iso2022Jp
        {
            get { return new MessageEncoding("ISO-2022-JP"); }
        }

        public static MessageEncoding EucJp
        {
            get { return new MessageEncoding("EUC-JP"); }
        }

        public static MessageEncoding ShiftJis
        {
            get { return new MessageEncoding("SHIFT_JIS"); }
        }

        public static MessageEncoding Utf8
        {
            get { return new MessageEncoding("UTF-8"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteEntryRejectReason : IEquatable<QuoteEntryRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "UnknownSymbol"}, {2, "ExchangeClosed"}, {3, "QuoteExceedsLimit"}, {4, "TooLateToEnter"}, {5, "UnknownQuote"}, {6, "DuplicateQuote"}, {7, "InvalidBidAskSpread"}, {8, "InvalidPrice"}, {9, "NotAuthorizedToQuoteSecurity"},};
        private readonly int? _value;

        private QuoteEntryRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteEntryRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteEntryRejectReason && Equals((QuoteEntryRejectReason) other);
        }

        public static bool operator ==(QuoteEntryRejectReason left, QuoteEntryRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteEntryRejectReason left, QuoteEntryRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteEntryRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteEntryRejectReason", nameof(value));

            return new QuoteEntryRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteEntryRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteEntryRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteEntryRejectReason Invalid
        {
            get { return new QuoteEntryRejectReason(); }
        }

        public static QuoteEntryRejectReason UnknownSymbol
        {
            get { return new QuoteEntryRejectReason(1); }
        }

        public static QuoteEntryRejectReason ExchangeClosed
        {
            get { return new QuoteEntryRejectReason(2); }
        }

        public static QuoteEntryRejectReason QuoteExceedsLimit
        {
            get { return new QuoteEntryRejectReason(3); }
        }

        public static QuoteEntryRejectReason TooLateToEnter
        {
            get { return new QuoteEntryRejectReason(4); }
        }

        public static QuoteEntryRejectReason UnknownQuote
        {
            get { return new QuoteEntryRejectReason(5); }
        }

        public static QuoteEntryRejectReason DuplicateQuote
        {
            get { return new QuoteEntryRejectReason(6); }
        }

        public static QuoteEntryRejectReason InvalidBidAskSpread
        {
            get { return new QuoteEntryRejectReason(7); }
        }

        public static QuoteEntryRejectReason InvalidPrice
        {
            get { return new QuoteEntryRejectReason(8); }
        }

        public static QuoteEntryRejectReason NotAuthorizedToQuoteSecurity
        {
            get { return new QuoteEntryRejectReason(9); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SessionRejectReason : IEquatable<SessionRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "InvalidTagNumber"}, {1, "RequiredTagMissing"}, {2, "TagNotDefinedForThisMessageType"}, {3, "UndefinedTag"}, {4, "TagSpecifiedWithoutAValue"}, {5, "ValueIsIncorrect"}, {6, "IncorrectDataFormatForValue"}, {7, "DecryptionProblem"}, {8, "SignatureProblem"}, {9, "CompidProblem"}, {10, "SendingtimeAccuracyProblem"}, {11, "InvalidMsgtype"}, {12, "XmlValidationError"}, {13, "TagAppearsMoreThanOnce"}, {14, "TagSpecifiedOutOfRequiredOrder"}, {15, "RepeatingGroupFieldsOutOfOrder"}, {16, "IncorrectNumingroupCountForRepeatingGroup"}, {17, "NonDataValueIncludesFieldDelimiter"}, {99, "Other"},};
        private readonly int? _value;

        private SessionRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(SessionRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SessionRejectReason && Equals((SessionRejectReason) other);
        }

        public static bool operator ==(SessionRejectReason left, SessionRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SessionRejectReason left, SessionRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SessionRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SessionRejectReason", nameof(value));

            return new SessionRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SessionRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SessionRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SessionRejectReason Invalid
        {
            get { return new SessionRejectReason(); }
        }

        public static SessionRejectReason InvalidTagNumber
        {
            get { return new SessionRejectReason(0); }
        }

        public static SessionRejectReason RequiredTagMissing
        {
            get { return new SessionRejectReason(1); }
        }

        public static SessionRejectReason TagNotDefinedForThisMessageType
        {
            get { return new SessionRejectReason(2); }
        }

        public static SessionRejectReason UndefinedTag
        {
            get { return new SessionRejectReason(3); }
        }

        public static SessionRejectReason TagSpecifiedWithoutAValue
        {
            get { return new SessionRejectReason(4); }
        }

        public static SessionRejectReason ValueIsIncorrect
        {
            get { return new SessionRejectReason(5); }
        }

        public static SessionRejectReason IncorrectDataFormatForValue
        {
            get { return new SessionRejectReason(6); }
        }

        public static SessionRejectReason DecryptionProblem
        {
            get { return new SessionRejectReason(7); }
        }

        public static SessionRejectReason SignatureProblem
        {
            get { return new SessionRejectReason(8); }
        }

        public static SessionRejectReason CompidProblem
        {
            get { return new SessionRejectReason(9); }
        }

        public static SessionRejectReason SendingtimeAccuracyProblem
        {
            get { return new SessionRejectReason(10); }
        }

        public static SessionRejectReason InvalidMsgtype
        {
            get { return new SessionRejectReason(11); }
        }

        public static SessionRejectReason XmlValidationError
        {
            get { return new SessionRejectReason(12); }
        }

        public static SessionRejectReason TagAppearsMoreThanOnce
        {
            get { return new SessionRejectReason(13); }
        }

        public static SessionRejectReason TagSpecifiedOutOfRequiredOrder
        {
            get { return new SessionRejectReason(14); }
        }

        public static SessionRejectReason RepeatingGroupFieldsOutOfOrder
        {
            get { return new SessionRejectReason(15); }
        }

        public static SessionRejectReason IncorrectNumingroupCountForRepeatingGroup
        {
            get { return new SessionRejectReason(16); }
        }

        public static SessionRejectReason NonDataValueIncludesFieldDelimiter
        {
            get { return new SessionRejectReason(17); }
        }

        public static SessionRejectReason Other
        {
            get { return new SessionRejectReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BidRequestTransType : IEquatable<BidRequestTransType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'N', "New"}, {'C', "Cancel"},};
        private readonly char? _value;

        private BidRequestTransType(char value)
        {
            _value = value;
        }

        public bool Equals(BidRequestTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BidRequestTransType && Equals((BidRequestTransType) other);
        }

        public static bool operator ==(BidRequestTransType left, BidRequestTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BidRequestTransType left, BidRequestTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BidRequestTransType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BidRequestTransType", nameof(value));

            return new BidRequestTransType(value);
        }

        public static BidRequestTransType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BidRequestTransType", nameof(value));

            return new BidRequestTransType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BidRequestTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BidRequestTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BidRequestTransType Invalid
        {
            get { return new BidRequestTransType(); }
        }

        public static BidRequestTransType New
        {
            get { return new BidRequestTransType('N'); }
        }

        public static BidRequestTransType Cancel
        {
            get { return new BidRequestTransType('C'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ExecRestatementReason : IEquatable<ExecRestatementReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "GtCorporateAction"}, {1, "GtRenewalRestatement"}, {2, "VerbalChange"}, {3, "RepricingOfOrder"}, {4, "BrokerOption"}, {5, "PartialDeclineOfOrderqty"}, {6, "CancelOnTradingHalt"}, {7, "CancelOnSystemFailure"}, {8, "MarketOption"}, {9, "CanceledNotBest"},};
        private readonly int? _value;

        private ExecRestatementReason(int value)
        {
            _value = value;
        }

        public bool Equals(ExecRestatementReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ExecRestatementReason && Equals((ExecRestatementReason) other);
        }

        public static bool operator ==(ExecRestatementReason left, ExecRestatementReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExecRestatementReason left, ExecRestatementReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ExecRestatementReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExecRestatementReason", nameof(value));

            return new ExecRestatementReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ExecRestatementReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ExecRestatementReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ExecRestatementReason Invalid
        {
            get { return new ExecRestatementReason(); }
        }

        public static ExecRestatementReason GtCorporateAction
        {
            get { return new ExecRestatementReason(0); }
        }

        public static ExecRestatementReason GtRenewalRestatement
        {
            get { return new ExecRestatementReason(1); }
        }

        public static ExecRestatementReason VerbalChange
        {
            get { return new ExecRestatementReason(2); }
        }

        public static ExecRestatementReason RepricingOfOrder
        {
            get { return new ExecRestatementReason(3); }
        }

        public static ExecRestatementReason BrokerOption
        {
            get { return new ExecRestatementReason(4); }
        }

        public static ExecRestatementReason PartialDeclineOfOrderqty
        {
            get { return new ExecRestatementReason(5); }
        }

        public static ExecRestatementReason CancelOnTradingHalt
        {
            get { return new ExecRestatementReason(6); }
        }

        public static ExecRestatementReason CancelOnSystemFailure
        {
            get { return new ExecRestatementReason(7); }
        }

        public static ExecRestatementReason MarketOption
        {
            get { return new ExecRestatementReason(8); }
        }

        public static ExecRestatementReason CanceledNotBest
        {
            get { return new ExecRestatementReason(9); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BusinessRejectReason : IEquatable<BusinessRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Other"}, {1, "UnkownId"}, {2, "UnknownSecurity"}, {3, "UnsupportedMessageType"}, {4, "ApplicationNotAvailable"}, {5, "ConditionallyRequiredFieldMissing"}, {6, "NotAuthorized"}, {7, "DelivertoFirmNotAvailableAtThisTime"},};
        private readonly int? _value;

        private BusinessRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(BusinessRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BusinessRejectReason && Equals((BusinessRejectReason) other);
        }

        public static bool operator ==(BusinessRejectReason left, BusinessRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BusinessRejectReason left, BusinessRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BusinessRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BusinessRejectReason", nameof(value));

            return new BusinessRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BusinessRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BusinessRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BusinessRejectReason Invalid
        {
            get { return new BusinessRejectReason(); }
        }

        public static BusinessRejectReason Other
        {
            get { return new BusinessRejectReason(0); }
        }

        public static BusinessRejectReason UnkownId
        {
            get { return new BusinessRejectReason(1); }
        }

        public static BusinessRejectReason UnknownSecurity
        {
            get { return new BusinessRejectReason(2); }
        }

        public static BusinessRejectReason UnsupportedMessageType
        {
            get { return new BusinessRejectReason(3); }
        }

        public static BusinessRejectReason ApplicationNotAvailable
        {
            get { return new BusinessRejectReason(4); }
        }

        public static BusinessRejectReason ConditionallyRequiredFieldMissing
        {
            get { return new BusinessRejectReason(5); }
        }

        public static BusinessRejectReason NotAuthorized
        {
            get { return new BusinessRejectReason(6); }
        }

        public static BusinessRejectReason DelivertoFirmNotAvailableAtThisTime
        {
            get { return new BusinessRejectReason(7); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MsgDirection : IEquatable<MsgDirection>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'S', "Send"}, {'R', "Receive"},};
        private readonly char? _value;

        private MsgDirection(char value)
        {
            _value = value;
        }

        public bool Equals(MsgDirection other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MsgDirection && Equals((MsgDirection) other);
        }

        public static bool operator ==(MsgDirection left, MsgDirection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MsgDirection left, MsgDirection right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MsgDirection FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MsgDirection", nameof(value));

            return new MsgDirection(value);
        }

        public static MsgDirection FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MsgDirection", nameof(value));

            return new MsgDirection(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MsgDirection FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MsgDirection(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MsgDirection Invalid
        {
            get { return new MsgDirection(); }
        }

        public static MsgDirection Send
        {
            get { return new MsgDirection('S'); }
        }

        public static MsgDirection Receive
        {
            get { return new MsgDirection('R'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DiscretionInst : IEquatable<DiscretionInst>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "RelatedToDisplayedPrice"}, {'1', "RelatedToMarketPrice"}, {'2', "RelatedToPrimaryPrice"}, {'3', "RelatedToLocalPrimaryPrice"}, {'4', "RelatedToMidpointPrice"}, {'5', "RelatedToLastTradePrice"}, {'6', "RelatedToVwap"},};
        private readonly char? _value;

        private DiscretionInst(char value)
        {
            _value = value;
        }

        public bool Equals(DiscretionInst other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DiscretionInst && Equals((DiscretionInst) other);
        }

        public static bool operator ==(DiscretionInst left, DiscretionInst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscretionInst left, DiscretionInst right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DiscretionInst FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionInst", nameof(value));

            return new DiscretionInst(value);
        }

        public static DiscretionInst FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionInst", nameof(value));

            return new DiscretionInst(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DiscretionInst FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DiscretionInst(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DiscretionInst Invalid
        {
            get { return new DiscretionInst(); }
        }

        public static DiscretionInst RelatedToDisplayedPrice
        {
            get { return new DiscretionInst('0'); }
        }

        public static DiscretionInst RelatedToMarketPrice
        {
            get { return new DiscretionInst('1'); }
        }

        public static DiscretionInst RelatedToPrimaryPrice
        {
            get { return new DiscretionInst('2'); }
        }

        public static DiscretionInst RelatedToLocalPrimaryPrice
        {
            get { return new DiscretionInst('3'); }
        }

        public static DiscretionInst RelatedToMidpointPrice
        {
            get { return new DiscretionInst('4'); }
        }

        public static DiscretionInst RelatedToLastTradePrice
        {
            get { return new DiscretionInst('5'); }
        }

        public static DiscretionInst RelatedToVwap
        {
            get { return new DiscretionInst('6'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BidType : IEquatable<BidType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "NonDisclosed"}, {2, "DisclosedStyle"}, {3, "NoBiddingProcess"},};
        private readonly int? _value;

        private BidType(int value)
        {
            _value = value;
        }

        public bool Equals(BidType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BidType && Equals((BidType) other);
        }

        public static bool operator ==(BidType left, BidType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BidType left, BidType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BidType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BidType", nameof(value));

            return new BidType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BidType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BidType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BidType Invalid
        {
            get { return new BidType(); }
        }

        public static BidType NonDisclosed
        {
            get { return new BidType(1); }
        }

        public static BidType DisclosedStyle
        {
            get { return new BidType(2); }
        }

        public static BidType NoBiddingProcess
        {
            get { return new BidType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BidDescriptorType : IEquatable<BidDescriptorType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Sector"}, {2, "Country"}, {3, "Index"},};
        private readonly int? _value;

        private BidDescriptorType(int value)
        {
            _value = value;
        }

        public bool Equals(BidDescriptorType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BidDescriptorType && Equals((BidDescriptorType) other);
        }

        public static bool operator ==(BidDescriptorType left, BidDescriptorType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BidDescriptorType left, BidDescriptorType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BidDescriptorType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BidDescriptorType", nameof(value));

            return new BidDescriptorType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BidDescriptorType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BidDescriptorType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BidDescriptorType Invalid
        {
            get { return new BidDescriptorType(); }
        }

        public static BidDescriptorType Sector
        {
            get { return new BidDescriptorType(1); }
        }

        public static BidDescriptorType Country
        {
            get { return new BidDescriptorType(2); }
        }

        public static BidDescriptorType Index
        {
            get { return new BidDescriptorType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SideValueInd : IEquatable<SideValueInd>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Sidevalue1"}, {2, "Sidevalue2"},};
        private readonly int? _value;

        private SideValueInd(int value)
        {
            _value = value;
        }

        public bool Equals(SideValueInd other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SideValueInd && Equals((SideValueInd) other);
        }

        public static bool operator ==(SideValueInd left, SideValueInd right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SideValueInd left, SideValueInd right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SideValueInd FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SideValueInd", nameof(value));

            return new SideValueInd(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SideValueInd FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SideValueInd(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SideValueInd Invalid
        {
            get { return new SideValueInd(); }
        }

        public static SideValueInd Sidevalue1
        {
            get { return new SideValueInd(1); }
        }

        public static SideValueInd Sidevalue2
        {
            get { return new SideValueInd(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct LiquidityIndType : IEquatable<LiquidityIndType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "FivedayMovingAverage"}, {2, "TwentydayMovingAverage"}, {3, "NormalMarketSize"}, {4, "Other"},};
        private readonly int? _value;

        private LiquidityIndType(int value)
        {
            _value = value;
        }

        public bool Equals(LiquidityIndType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is LiquidityIndType && Equals((LiquidityIndType) other);
        }

        public static bool operator ==(LiquidityIndType left, LiquidityIndType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LiquidityIndType left, LiquidityIndType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static LiquidityIndType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for LiquidityIndType", nameof(value));

            return new LiquidityIndType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static LiquidityIndType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new LiquidityIndType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static LiquidityIndType Invalid
        {
            get { return new LiquidityIndType(); }
        }

        public static LiquidityIndType FivedayMovingAverage
        {
            get { return new LiquidityIndType(1); }
        }

        public static LiquidityIndType TwentydayMovingAverage
        {
            get { return new LiquidityIndType(2); }
        }

        public static LiquidityIndType NormalMarketSize
        {
            get { return new LiquidityIndType(3); }
        }

        public static LiquidityIndType Other
        {
            get { return new LiquidityIndType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ProgRptReqs : IEquatable<ProgRptReqs>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "BuysideExplicitlyRequestsStatusUsingStatusrequest"}, {2, "SellsidePeriodicallySendsStatusUsingListstatus"}, {3, "RealTimeExecutionReports"},};
        private readonly int? _value;

        private ProgRptReqs(int value)
        {
            _value = value;
        }

        public bool Equals(ProgRptReqs other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ProgRptReqs && Equals((ProgRptReqs) other);
        }

        public static bool operator ==(ProgRptReqs left, ProgRptReqs right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ProgRptReqs left, ProgRptReqs right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ProgRptReqs FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ProgRptReqs", nameof(value));

            return new ProgRptReqs(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ProgRptReqs FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ProgRptReqs(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ProgRptReqs Invalid
        {
            get { return new ProgRptReqs(); }
        }

        public static ProgRptReqs BuysideExplicitlyRequestsStatusUsingStatusrequest
        {
            get { return new ProgRptReqs(1); }
        }

        public static ProgRptReqs SellsidePeriodicallySendsStatusUsingListstatus
        {
            get { return new ProgRptReqs(2); }
        }

        public static ProgRptReqs RealTimeExecutionReports
        {
            get { return new ProgRptReqs(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct IncTaxInd : IEquatable<IncTaxInd>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Net"}, {2, "Gross"},};
        private readonly int? _value;

        private IncTaxInd(int value)
        {
            _value = value;
        }

        public bool Equals(IncTaxInd other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is IncTaxInd && Equals((IncTaxInd) other);
        }

        public static bool operator ==(IncTaxInd left, IncTaxInd right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IncTaxInd left, IncTaxInd right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static IncTaxInd FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for IncTaxInd", nameof(value));

            return new IncTaxInd(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static IncTaxInd FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new IncTaxInd(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static IncTaxInd Invalid
        {
            get { return new IncTaxInd(); }
        }

        public static IncTaxInd Net
        {
            get { return new IncTaxInd(1); }
        }

        public static IncTaxInd Gross
        {
            get { return new IncTaxInd(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BidTradeType : IEquatable<BidTradeType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'R', "RiskTrade"}, {'G', "VwapGuarantee"}, {'A', "Agency"}, {'J', "GuaranteedClose"},};
        private readonly char? _value;

        private BidTradeType(char value)
        {
            _value = value;
        }

        public bool Equals(BidTradeType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BidTradeType && Equals((BidTradeType) other);
        }

        public static bool operator ==(BidTradeType left, BidTradeType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BidTradeType left, BidTradeType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BidTradeType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BidTradeType", nameof(value));

            return new BidTradeType(value);
        }

        public static BidTradeType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BidTradeType", nameof(value));

            return new BidTradeType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BidTradeType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BidTradeType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BidTradeType Invalid
        {
            get { return new BidTradeType(); }
        }

        public static BidTradeType RiskTrade
        {
            get { return new BidTradeType('R'); }
        }

        public static BidTradeType VwapGuarantee
        {
            get { return new BidTradeType('G'); }
        }

        public static BidTradeType Agency
        {
            get { return new BidTradeType('A'); }
        }

        public static BidTradeType GuaranteedClose
        {
            get { return new BidTradeType('J'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BasisPxType : IEquatable<BasisPxType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'2', "ClosingPriceAtMorningSession"}, {'3', "ClosingPrice"}, {'4', "CurrentPrice"}, {'5', "Sq"}, {'6', "VwapThroughADay"}, {'7', "VwapThroughAMorningSession"}, {'8', "VwapThroughAnAfternoonSession"}, {'9', "VwapThroughADayExceptYori"}, {'A', "VwapThroughAMorningSessionExceptYori"}, {'B', "VwapThroughAnAfternoonSessionExceptYori"}, {'C', "Strike"}, {'D', "Open"}, {'Z', "Others"},};
        private readonly char? _value;

        private BasisPxType(char value)
        {
            _value = value;
        }

        public bool Equals(BasisPxType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BasisPxType && Equals((BasisPxType) other);
        }

        public static bool operator ==(BasisPxType left, BasisPxType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BasisPxType left, BasisPxType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BasisPxType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BasisPxType", nameof(value));

            return new BasisPxType(value);
        }

        public static BasisPxType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BasisPxType", nameof(value));

            return new BasisPxType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BasisPxType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BasisPxType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BasisPxType Invalid
        {
            get { return new BasisPxType(); }
        }

        public static BasisPxType ClosingPriceAtMorningSession
        {
            get { return new BasisPxType('2'); }
        }

        public static BasisPxType ClosingPrice
        {
            get { return new BasisPxType('3'); }
        }

        public static BasisPxType CurrentPrice
        {
            get { return new BasisPxType('4'); }
        }

        public static BasisPxType Sq
        {
            get { return new BasisPxType('5'); }
        }

        public static BasisPxType VwapThroughADay
        {
            get { return new BasisPxType('6'); }
        }

        public static BasisPxType VwapThroughAMorningSession
        {
            get { return new BasisPxType('7'); }
        }

        public static BasisPxType VwapThroughAnAfternoonSession
        {
            get { return new BasisPxType('8'); }
        }

        public static BasisPxType VwapThroughADayExceptYori
        {
            get { return new BasisPxType('9'); }
        }

        public static BasisPxType VwapThroughAMorningSessionExceptYori
        {
            get { return new BasisPxType('A'); }
        }

        public static BasisPxType VwapThroughAnAfternoonSessionExceptYori
        {
            get { return new BasisPxType('B'); }
        }

        public static BasisPxType Strike
        {
            get { return new BasisPxType('C'); }
        }

        public static BasisPxType Open
        {
            get { return new BasisPxType('D'); }
        }

        public static BasisPxType Others
        {
            get { return new BasisPxType('Z'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PriceType : IEquatable<PriceType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Percentage"}, {2, "PerUnit"}, {3, "FixedAmount"}, {4, "Discount"}, {5, "Premium"}, {6, "Spread"}, {7, "TedPrice"}, {8, "TedYield"}, {9, "Yield"}, {10, "FixedCabinetTradePrice"}, {11, "VariableCabinetTradePrice"},};
        private readonly int? _value;

        private PriceType(int value)
        {
            _value = value;
        }

        public bool Equals(PriceType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PriceType && Equals((PriceType) other);
        }

        public static bool operator ==(PriceType left, PriceType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PriceType left, PriceType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PriceType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PriceType", nameof(value));

            return new PriceType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PriceType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PriceType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PriceType Invalid
        {
            get { return new PriceType(); }
        }

        public static PriceType Percentage
        {
            get { return new PriceType(1); }
        }

        public static PriceType PerUnit
        {
            get { return new PriceType(2); }
        }

        public static PriceType FixedAmount
        {
            get { return new PriceType(3); }
        }

        public static PriceType Discount
        {
            get { return new PriceType(4); }
        }

        public static PriceType Premium
        {
            get { return new PriceType(5); }
        }

        public static PriceType Spread
        {
            get { return new PriceType(6); }
        }

        public static PriceType TedPrice
        {
            get { return new PriceType(7); }
        }

        public static PriceType TedYield
        {
            get { return new PriceType(8); }
        }

        public static PriceType Yield
        {
            get { return new PriceType(9); }
        }

        public static PriceType FixedCabinetTradePrice
        {
            get { return new PriceType(10); }
        }

        public static PriceType VariableCabinetTradePrice
        {
            get { return new PriceType(11); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct GTBookingInst : IEquatable<GTBookingInst>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "BookOutAllTradesOnDayOfExecution"}, {1, "AccumulateExecutionsUntilOrderIsFilledOrExpires"}, {2, "AccumulateUntilVerballyNotifiedOtherwise"},};
        private readonly int? _value;

        private GTBookingInst(int value)
        {
            _value = value;
        }

        public bool Equals(GTBookingInst other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is GTBookingInst && Equals((GTBookingInst) other);
        }

        public static bool operator ==(GTBookingInst left, GTBookingInst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GTBookingInst left, GTBookingInst right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static GTBookingInst FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for GTBookingInst", nameof(value));

            return new GTBookingInst(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static GTBookingInst FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new GTBookingInst(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static GTBookingInst Invalid
        {
            get { return new GTBookingInst(); }
        }

        public static GTBookingInst BookOutAllTradesOnDayOfExecution
        {
            get { return new GTBookingInst(0); }
        }

        public static GTBookingInst AccumulateExecutionsUntilOrderIsFilledOrExpires
        {
            get { return new GTBookingInst(1); }
        }

        public static GTBookingInst AccumulateUntilVerballyNotifiedOtherwise
        {
            get { return new GTBookingInst(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ListStatusType : IEquatable<ListStatusType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Ack"}, {2, "Response"}, {3, "Timed"}, {4, "Execstarted"}, {5, "Alldone"}, {6, "Alert"},};
        private readonly int? _value;

        private ListStatusType(int value)
        {
            _value = value;
        }

        public bool Equals(ListStatusType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ListStatusType && Equals((ListStatusType) other);
        }

        public static bool operator ==(ListStatusType left, ListStatusType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ListStatusType left, ListStatusType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ListStatusType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ListStatusType", nameof(value));

            return new ListStatusType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ListStatusType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ListStatusType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ListStatusType Invalid
        {
            get { return new ListStatusType(); }
        }

        public static ListStatusType Ack
        {
            get { return new ListStatusType(1); }
        }

        public static ListStatusType Response
        {
            get { return new ListStatusType(2); }
        }

        public static ListStatusType Timed
        {
            get { return new ListStatusType(3); }
        }

        public static ListStatusType Execstarted
        {
            get { return new ListStatusType(4); }
        }

        public static ListStatusType Alldone
        {
            get { return new ListStatusType(5); }
        }

        public static ListStatusType Alert
        {
            get { return new ListStatusType(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct NetGrossInd : IEquatable<NetGrossInd>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Net"}, {2, "Gross"},};
        private readonly int? _value;

        private NetGrossInd(int value)
        {
            _value = value;
        }

        public bool Equals(NetGrossInd other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is NetGrossInd && Equals((NetGrossInd) other);
        }

        public static bool operator ==(NetGrossInd left, NetGrossInd right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NetGrossInd left, NetGrossInd right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static NetGrossInd FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for NetGrossInd", nameof(value));

            return new NetGrossInd(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static NetGrossInd FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new NetGrossInd(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static NetGrossInd Invalid
        {
            get { return new NetGrossInd(); }
        }

        public static NetGrossInd Net
        {
            get { return new NetGrossInd(1); }
        }

        public static NetGrossInd Gross
        {
            get { return new NetGrossInd(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ListOrderStatus : IEquatable<ListOrderStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Inbiddingprocess"}, {2, "Receivedforexecution"}, {3, "Executing"}, {4, "Canceling"}, {5, "Alert"}, {6, "AllDone"}, {7, "Reject"},};
        private readonly int? _value;

        private ListOrderStatus(int value)
        {
            _value = value;
        }

        public bool Equals(ListOrderStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ListOrderStatus && Equals((ListOrderStatus) other);
        }

        public static bool operator ==(ListOrderStatus left, ListOrderStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ListOrderStatus left, ListOrderStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ListOrderStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ListOrderStatus", nameof(value));

            return new ListOrderStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ListOrderStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ListOrderStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ListOrderStatus Invalid
        {
            get { return new ListOrderStatus(); }
        }

        public static ListOrderStatus Inbiddingprocess
        {
            get { return new ListOrderStatus(1); }
        }

        public static ListOrderStatus Receivedforexecution
        {
            get { return new ListOrderStatus(2); }
        }

        public static ListOrderStatus Executing
        {
            get { return new ListOrderStatus(3); }
        }

        public static ListOrderStatus Canceling
        {
            get { return new ListOrderStatus(4); }
        }

        public static ListOrderStatus Alert
        {
            get { return new ListOrderStatus(5); }
        }

        public static ListOrderStatus AllDone
        {
            get { return new ListOrderStatus(6); }
        }

        public static ListOrderStatus Reject
        {
            get { return new ListOrderStatus(7); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ListExecInstType : IEquatable<ListExecInstType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "Immediate"}, {'2', "WaitForExecuteInstruction"}, {'3', "ExchangeSwitchCivOrderSellDriven"}, {'4', "ExchangeSwitchCivOrderBuyDrivenCashTopUp"}, {'5', "ExchangeSwitchCivOrderBuyDrivenCashWithdraw"},};
        private readonly char? _value;

        private ListExecInstType(char value)
        {
            _value = value;
        }

        public bool Equals(ListExecInstType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ListExecInstType && Equals((ListExecInstType) other);
        }

        public static bool operator ==(ListExecInstType left, ListExecInstType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ListExecInstType left, ListExecInstType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ListExecInstType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ListExecInstType", nameof(value));

            return new ListExecInstType(value);
        }

        public static ListExecInstType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ListExecInstType", nameof(value));

            return new ListExecInstType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ListExecInstType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ListExecInstType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ListExecInstType Invalid
        {
            get { return new ListExecInstType(); }
        }

        public static ListExecInstType Immediate
        {
            get { return new ListExecInstType('1'); }
        }

        public static ListExecInstType WaitForExecuteInstruction
        {
            get { return new ListExecInstType('2'); }
        }

        public static ListExecInstType ExchangeSwitchCivOrderSellDriven
        {
            get { return new ListExecInstType('3'); }
        }

        public static ListExecInstType ExchangeSwitchCivOrderBuyDrivenCashTopUp
        {
            get { return new ListExecInstType('4'); }
        }

        public static ListExecInstType ExchangeSwitchCivOrderBuyDrivenCashWithdraw
        {
            get { return new ListExecInstType('5'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CxlRejResponseTo : IEquatable<CxlRejResponseTo>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "OrderCancelRequest"}, {'2', "OrderCancelReplaceRequest"},};
        private readonly char? _value;

        private CxlRejResponseTo(char value)
        {
            _value = value;
        }

        public bool Equals(CxlRejResponseTo other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CxlRejResponseTo && Equals((CxlRejResponseTo) other);
        }

        public static bool operator ==(CxlRejResponseTo left, CxlRejResponseTo right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CxlRejResponseTo left, CxlRejResponseTo right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CxlRejResponseTo FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CxlRejResponseTo", nameof(value));

            return new CxlRejResponseTo(value);
        }

        public static CxlRejResponseTo FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CxlRejResponseTo", nameof(value));

            return new CxlRejResponseTo(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CxlRejResponseTo FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CxlRejResponseTo(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CxlRejResponseTo Invalid
        {
            get { return new CxlRejResponseTo(); }
        }

        public static CxlRejResponseTo OrderCancelRequest
        {
            get { return new CxlRejResponseTo('1'); }
        }

        public static CxlRejResponseTo OrderCancelReplaceRequest
        {
            get { return new CxlRejResponseTo('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MultiLegReportingType : IEquatable<MultiLegReportingType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "SingleSecurity"}, {'2', "IndividualLegOfAMultiLegSecurity"}, {'3', "MultiLegSecurity"},};
        private readonly char? _value;

        private MultiLegReportingType(char value)
        {
            _value = value;
        }

        public bool Equals(MultiLegReportingType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MultiLegReportingType && Equals((MultiLegReportingType) other);
        }

        public static bool operator ==(MultiLegReportingType left, MultiLegReportingType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MultiLegReportingType left, MultiLegReportingType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MultiLegReportingType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MultiLegReportingType", nameof(value));

            return new MultiLegReportingType(value);
        }

        public static MultiLegReportingType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MultiLegReportingType", nameof(value));

            return new MultiLegReportingType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MultiLegReportingType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MultiLegReportingType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MultiLegReportingType Invalid
        {
            get { return new MultiLegReportingType(); }
        }

        public static MultiLegReportingType SingleSecurity
        {
            get { return new MultiLegReportingType('1'); }
        }

        public static MultiLegReportingType IndividualLegOfAMultiLegSecurity
        {
            get { return new MultiLegReportingType('2'); }
        }

        public static MultiLegReportingType MultiLegSecurity
        {
            get { return new MultiLegReportingType('3'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PartyIDSource : IEquatable<PartyIDSource>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'B', "Bic"}, {'C', "GenerallyAcceptedMarketParticipantIdentifier"}, {'D', "ProprietaryCustomCode"}, {'E', "IsoCountryCode"}, {'F', "SettlementEntityLocation"}, {'G', "Mic"}, {'H', "CsdParticipantMemberCode"}, {'1', "KoreanInvestorId"}, {'2', "TaiwaneseQualifiedForeignInvestorIdQfiiFid"}, {'3', "TaiwaneseTradingAccount"}, {'4', "MalaysianCentralDepositoryNumber"}, {'5', "ChineseBShare"}, {'6', "UkNationalInsuranceOrPensionNumber"}, {'7', "UsSocialSecurityNumber"}, {'8', "UsEmployerIdentificationNumber"}, {'9', "AustralianBusinessNumber"}, {'A', "AustralianTaxFileNumber"}, {'I', "DirectedBroker"},};
        private readonly char? _value;

        private PartyIDSource(char value)
        {
            _value = value;
        }

        public bool Equals(PartyIDSource other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PartyIDSource && Equals((PartyIDSource) other);
        }

        public static bool operator ==(PartyIDSource left, PartyIDSource right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PartyIDSource left, PartyIDSource right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PartyIDSource FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PartyIDSource", nameof(value));

            return new PartyIDSource(value);
        }

        public static PartyIDSource FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PartyIDSource", nameof(value));

            return new PartyIDSource(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PartyIDSource FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PartyIDSource(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PartyIDSource Invalid
        {
            get { return new PartyIDSource(); }
        }

        public static PartyIDSource Bic
        {
            get { return new PartyIDSource('B'); }
        }

        public static PartyIDSource GenerallyAcceptedMarketParticipantIdentifier
        {
            get { return new PartyIDSource('C'); }
        }

        public static PartyIDSource ProprietaryCustomCode
        {
            get { return new PartyIDSource('D'); }
        }

        public static PartyIDSource IsoCountryCode
        {
            get { return new PartyIDSource('E'); }
        }

        public static PartyIDSource SettlementEntityLocation
        {
            get { return new PartyIDSource('F'); }
        }

        public static PartyIDSource Mic
        {
            get { return new PartyIDSource('G'); }
        }

        public static PartyIDSource CsdParticipantMemberCode
        {
            get { return new PartyIDSource('H'); }
        }

        public static PartyIDSource KoreanInvestorId
        {
            get { return new PartyIDSource('1'); }
        }

        public static PartyIDSource TaiwaneseQualifiedForeignInvestorIdQfiiFid
        {
            get { return new PartyIDSource('2'); }
        }

        public static PartyIDSource TaiwaneseTradingAccount
        {
            get { return new PartyIDSource('3'); }
        }

        public static PartyIDSource MalaysianCentralDepositoryNumber
        {
            get { return new PartyIDSource('4'); }
        }

        public static PartyIDSource ChineseBShare
        {
            get { return new PartyIDSource('5'); }
        }

        public static PartyIDSource UkNationalInsuranceOrPensionNumber
        {
            get { return new PartyIDSource('6'); }
        }

        public static PartyIDSource UsSocialSecurityNumber
        {
            get { return new PartyIDSource('7'); }
        }

        public static PartyIDSource UsEmployerIdentificationNumber
        {
            get { return new PartyIDSource('8'); }
        }

        public static PartyIDSource AustralianBusinessNumber
        {
            get { return new PartyIDSource('9'); }
        }

        public static PartyIDSource AustralianTaxFileNumber
        {
            get { return new PartyIDSource('A'); }
        }

        public static PartyIDSource DirectedBroker
        {
            get { return new PartyIDSource('I'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PartyRole : IEquatable<PartyRole>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "ExecutingFirm"}, {2, "BrokerOfCredit"}, {3, "ClientId"}, {4, "ClearingFirm"}, {5, "InvestorId"}, {6, "IntroducingFirm"}, {7, "EnteringFirm"}, {8, "LocateLendingFirm"}, {9, "FundManagerClientId"}, {10, "SettlementLocation"}, {11, "OrderOriginationTrader"}, {12, "ExecutingTrader"}, {13, "OrderOriginationFirm"}, {14, "GiveupClearingFirm"}, {15, "CorrespondantClearingFirm"}, {16, "ExecutingSystem"}, {17, "ContraFirm"}, {18, "ContraClearingFirm"}, {19, "SponsoringFirm"}, {20, "UnderlyingContraFirm"}, {21, "ClearingOrganization"}, {22, "Exchange"}, {24, "CustomerAccount"}, {25, "CorrespondentClearingOrganization"}, {26, "CorrespondentBroker"}, {27, "BuyerSeller"}, {28, "Custodian"}, {29, "Intermediary"}, {30, "Agent"}, {31, "SubCustodian"}, {32, "Beneficiary"}, {33, "InterestedParty"}, {34, "RegulatoryBody"}, {35, "LiquidityProvider"}, {36, "EnteringTrader"}, {37, "ContraTrader"}, {38, "PositionAccount"},};
        private readonly int? _value;

        private PartyRole(int value)
        {
            _value = value;
        }

        public bool Equals(PartyRole other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PartyRole && Equals((PartyRole) other);
        }

        public static bool operator ==(PartyRole left, PartyRole right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PartyRole left, PartyRole right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PartyRole FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PartyRole", nameof(value));

            return new PartyRole(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PartyRole FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PartyRole(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PartyRole Invalid
        {
            get { return new PartyRole(); }
        }

        public static PartyRole ExecutingFirm
        {
            get { return new PartyRole(1); }
        }

        public static PartyRole BrokerOfCredit
        {
            get { return new PartyRole(2); }
        }

        public static PartyRole ClientId
        {
            get { return new PartyRole(3); }
        }

        public static PartyRole ClearingFirm
        {
            get { return new PartyRole(4); }
        }

        public static PartyRole InvestorId
        {
            get { return new PartyRole(5); }
        }

        public static PartyRole IntroducingFirm
        {
            get { return new PartyRole(6); }
        }

        public static PartyRole EnteringFirm
        {
            get { return new PartyRole(7); }
        }

        public static PartyRole LocateLendingFirm
        {
            get { return new PartyRole(8); }
        }

        public static PartyRole FundManagerClientId
        {
            get { return new PartyRole(9); }
        }

        public static PartyRole SettlementLocation
        {
            get { return new PartyRole(10); }
        }

        public static PartyRole OrderOriginationTrader
        {
            get { return new PartyRole(11); }
        }

        public static PartyRole ExecutingTrader
        {
            get { return new PartyRole(12); }
        }

        public static PartyRole OrderOriginationFirm
        {
            get { return new PartyRole(13); }
        }

        public static PartyRole GiveupClearingFirm
        {
            get { return new PartyRole(14); }
        }

        public static PartyRole CorrespondantClearingFirm
        {
            get { return new PartyRole(15); }
        }

        public static PartyRole ExecutingSystem
        {
            get { return new PartyRole(16); }
        }

        public static PartyRole ContraFirm
        {
            get { return new PartyRole(17); }
        }

        public static PartyRole ContraClearingFirm
        {
            get { return new PartyRole(18); }
        }

        public static PartyRole SponsoringFirm
        {
            get { return new PartyRole(19); }
        }

        public static PartyRole UnderlyingContraFirm
        {
            get { return new PartyRole(20); }
        }

        public static PartyRole ClearingOrganization
        {
            get { return new PartyRole(21); }
        }

        public static PartyRole Exchange
        {
            get { return new PartyRole(22); }
        }

        public static PartyRole CustomerAccount
        {
            get { return new PartyRole(24); }
        }

        public static PartyRole CorrespondentClearingOrganization
        {
            get { return new PartyRole(25); }
        }

        public static PartyRole CorrespondentBroker
        {
            get { return new PartyRole(26); }
        }

        public static PartyRole BuyerSeller
        {
            get { return new PartyRole(27); }
        }

        public static PartyRole Custodian
        {
            get { return new PartyRole(28); }
        }

        public static PartyRole Intermediary
        {
            get { return new PartyRole(29); }
        }

        public static PartyRole Agent
        {
            get { return new PartyRole(30); }
        }

        public static PartyRole SubCustodian
        {
            get { return new PartyRole(31); }
        }

        public static PartyRole Beneficiary
        {
            get { return new PartyRole(32); }
        }

        public static PartyRole InterestedParty
        {
            get { return new PartyRole(33); }
        }

        public static PartyRole RegulatoryBody
        {
            get { return new PartyRole(34); }
        }

        public static PartyRole LiquidityProvider
        {
            get { return new PartyRole(35); }
        }

        public static PartyRole EnteringTrader
        {
            get { return new PartyRole(36); }
        }

        public static PartyRole ContraTrader
        {
            get { return new PartyRole(37); }
        }

        public static PartyRole PositionAccount
        {
            get { return new PartyRole(38); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct Product : IEquatable<Product>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Agency"}, {2, "Commodity"}, {3, "Corporate"}, {4, "Currency"}, {5, "Equity"}, {6, "Government"}, {7, "Index"}, {8, "Loan"}, {9, "Moneymarket"}, {10, "Mortgage"}, {11, "Municipal"}, {12, "Other"}, {13, "Financing"},};
        private readonly int? _value;

        private Product(int value)
        {
            _value = value;
        }

        public bool Equals(Product other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is Product && Equals((Product) other);
        }

        public static bool operator ==(Product left, Product right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Product left, Product right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static Product FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Product", nameof(value));

            return new Product(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static Product FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new Product(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static Product Invalid
        {
            get { return new Product(); }
        }

        public static Product Agency
        {
            get { return new Product(1); }
        }

        public static Product Commodity
        {
            get { return new Product(2); }
        }

        public static Product Corporate
        {
            get { return new Product(3); }
        }

        public static Product Currency
        {
            get { return new Product(4); }
        }

        public static Product Equity
        {
            get { return new Product(5); }
        }

        public static Product Government
        {
            get { return new Product(6); }
        }

        public static Product Index
        {
            get { return new Product(7); }
        }

        public static Product Loan
        {
            get { return new Product(8); }
        }

        public static Product Moneymarket
        {
            get { return new Product(9); }
        }

        public static Product Mortgage
        {
            get { return new Product(10); }
        }

        public static Product Municipal
        {
            get { return new Product(11); }
        }

        public static Product Other
        {
            get { return new Product(12); }
        }

        public static Product Financing
        {
            get { return new Product(13); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuantityType : IEquatable<QuantityType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Shares"}, {2, "Bonds"}, {3, "Currentface"}, {4, "Originalface"}, {5, "Currency"}, {6, "Contracts"}, {7, "Other"}, {8, "Par"},};
        private readonly int? _value;

        private QuantityType(int value)
        {
            _value = value;
        }

        public bool Equals(QuantityType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuantityType && Equals((QuantityType) other);
        }

        public static bool operator ==(QuantityType left, QuantityType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuantityType left, QuantityType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuantityType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuantityType", nameof(value));

            return new QuantityType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuantityType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuantityType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuantityType Invalid
        {
            get { return new QuantityType(); }
        }

        public static QuantityType Shares
        {
            get { return new QuantityType(1); }
        }

        public static QuantityType Bonds
        {
            get { return new QuantityType(2); }
        }

        public static QuantityType Currentface
        {
            get { return new QuantityType(3); }
        }

        public static QuantityType Originalface
        {
            get { return new QuantityType(4); }
        }

        public static QuantityType Currency
        {
            get { return new QuantityType(5); }
        }

        public static QuantityType Contracts
        {
            get { return new QuantityType(6); }
        }

        public static QuantityType Other
        {
            get { return new QuantityType(7); }
        }

        public static QuantityType Par
        {
            get { return new QuantityType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct RoundingDirection : IEquatable<RoundingDirection>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "RoundToNearest"}, {'1', "RoundDown"}, {'2', "RoundUp"},};
        private readonly char? _value;

        private RoundingDirection(char value)
        {
            _value = value;
        }

        public bool Equals(RoundingDirection other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is RoundingDirection && Equals((RoundingDirection) other);
        }

        public static bool operator ==(RoundingDirection left, RoundingDirection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RoundingDirection left, RoundingDirection right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static RoundingDirection FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RoundingDirection", nameof(value));

            return new RoundingDirection(value);
        }

        public static RoundingDirection FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RoundingDirection", nameof(value));

            return new RoundingDirection(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static RoundingDirection FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new RoundingDirection(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static RoundingDirection Invalid
        {
            get { return new RoundingDirection(); }
        }

        public static RoundingDirection RoundToNearest
        {
            get { return new RoundingDirection('0'); }
        }

        public static RoundingDirection RoundDown
        {
            get { return new RoundingDirection('1'); }
        }

        public static RoundingDirection RoundUp
        {
            get { return new RoundingDirection('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DistribPaymentMethod : IEquatable<DistribPaymentMethod>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Crest"}, {2, "Nscc"}, {3, "Euroclear"}, {4, "Clearstream"}, {5, "Cheque"}, {6, "TelegraphicTransfer"}, {7, "Fedwire"}, {8, "DirectCredit"}, {9, "AchCredit"}, {10, "Bpay"}, {11, "HighValueClearingSystem"}, {12, "ReinvestInFund"},};
        private readonly int? _value;

        private DistribPaymentMethod(int value)
        {
            _value = value;
        }

        public bool Equals(DistribPaymentMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DistribPaymentMethod && Equals((DistribPaymentMethod) other);
        }

        public static bool operator ==(DistribPaymentMethod left, DistribPaymentMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DistribPaymentMethod left, DistribPaymentMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DistribPaymentMethod FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DistribPaymentMethod", nameof(value));

            return new DistribPaymentMethod(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DistribPaymentMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DistribPaymentMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DistribPaymentMethod Invalid
        {
            get { return new DistribPaymentMethod(); }
        }

        public static DistribPaymentMethod Crest
        {
            get { return new DistribPaymentMethod(1); }
        }

        public static DistribPaymentMethod Nscc
        {
            get { return new DistribPaymentMethod(2); }
        }

        public static DistribPaymentMethod Euroclear
        {
            get { return new DistribPaymentMethod(3); }
        }

        public static DistribPaymentMethod Clearstream
        {
            get { return new DistribPaymentMethod(4); }
        }

        public static DistribPaymentMethod Cheque
        {
            get { return new DistribPaymentMethod(5); }
        }

        public static DistribPaymentMethod TelegraphicTransfer
        {
            get { return new DistribPaymentMethod(6); }
        }

        public static DistribPaymentMethod Fedwire
        {
            get { return new DistribPaymentMethod(7); }
        }

        public static DistribPaymentMethod DirectCredit
        {
            get { return new DistribPaymentMethod(8); }
        }

        public static DistribPaymentMethod AchCredit
        {
            get { return new DistribPaymentMethod(9); }
        }

        public static DistribPaymentMethod Bpay
        {
            get { return new DistribPaymentMethod(10); }
        }

        public static DistribPaymentMethod HighValueClearingSystem
        {
            get { return new DistribPaymentMethod(11); }
        }

        public static DistribPaymentMethod ReinvestInFund
        {
            get { return new DistribPaymentMethod(12); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CancellationRights : IEquatable<CancellationRights>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'Y', "Yes"}, {'N', "NoExecutionOnly"}, {'M', "NoWaiverAgreement"}, {'O', "NoInstitutional"},};
        private readonly char? _value;

        private CancellationRights(char value)
        {
            _value = value;
        }

        public bool Equals(CancellationRights other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CancellationRights && Equals((CancellationRights) other);
        }

        public static bool operator ==(CancellationRights left, CancellationRights right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CancellationRights left, CancellationRights right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CancellationRights FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CancellationRights", nameof(value));

            return new CancellationRights(value);
        }

        public static CancellationRights FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CancellationRights", nameof(value));

            return new CancellationRights(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CancellationRights FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CancellationRights(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CancellationRights Invalid
        {
            get { return new CancellationRights(); }
        }

        public static CancellationRights Yes
        {
            get { return new CancellationRights('Y'); }
        }

        public static CancellationRights NoExecutionOnly
        {
            get { return new CancellationRights('N'); }
        }

        public static CancellationRights NoWaiverAgreement
        {
            get { return new CancellationRights('M'); }
        }

        public static CancellationRights NoInstitutional
        {
            get { return new CancellationRights('O'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MoneyLaunderingStatus : IEquatable<MoneyLaunderingStatus>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'Y', "Passed"}, {'N', "NotChecked"}, {'1', "ExemptBelowTheLimit"}, {'2', "ExemptClientMoneyTypeExemption"}, {'3', "ExemptAuthorisedCreditOrFinancialInstitution"},};
        private readonly char? _value;

        private MoneyLaunderingStatus(char value)
        {
            _value = value;
        }

        public bool Equals(MoneyLaunderingStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MoneyLaunderingStatus && Equals((MoneyLaunderingStatus) other);
        }

        public static bool operator ==(MoneyLaunderingStatus left, MoneyLaunderingStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MoneyLaunderingStatus left, MoneyLaunderingStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MoneyLaunderingStatus FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MoneyLaunderingStatus", nameof(value));

            return new MoneyLaunderingStatus(value);
        }

        public static MoneyLaunderingStatus FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MoneyLaunderingStatus", nameof(value));

            return new MoneyLaunderingStatus(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MoneyLaunderingStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MoneyLaunderingStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MoneyLaunderingStatus Invalid
        {
            get { return new MoneyLaunderingStatus(); }
        }

        public static MoneyLaunderingStatus Passed
        {
            get { return new MoneyLaunderingStatus('Y'); }
        }

        public static MoneyLaunderingStatus NotChecked
        {
            get { return new MoneyLaunderingStatus('N'); }
        }

        public static MoneyLaunderingStatus ExemptBelowTheLimit
        {
            get { return new MoneyLaunderingStatus('1'); }
        }

        public static MoneyLaunderingStatus ExemptClientMoneyTypeExemption
        {
            get { return new MoneyLaunderingStatus('2'); }
        }

        public static MoneyLaunderingStatus ExemptAuthorisedCreditOrFinancialInstitution
        {
            get { return new MoneyLaunderingStatus('3'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ExecPriceType : IEquatable<ExecPriceType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'B', "BidPrice"}, {'C', "CreationPrice"}, {'D', "CreationPricePlusAdjustmentPercent"}, {'E', "CreationPricePlusAdjustmentAmount"}, {'O', "OfferPrice"}, {'P', "OfferPriceMinusAdjustmentPercent"}, {'Q', "OfferPriceMinusAdjustmentAmount"}, {'S', "SinglePrice"},};
        private readonly char? _value;

        private ExecPriceType(char value)
        {
            _value = value;
        }

        public bool Equals(ExecPriceType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ExecPriceType && Equals((ExecPriceType) other);
        }

        public static bool operator ==(ExecPriceType left, ExecPriceType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExecPriceType left, ExecPriceType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ExecPriceType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExecPriceType", nameof(value));

            return new ExecPriceType(value);
        }

        public static ExecPriceType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExecPriceType", nameof(value));

            return new ExecPriceType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ExecPriceType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ExecPriceType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ExecPriceType Invalid
        {
            get { return new ExecPriceType(); }
        }

        public static ExecPriceType BidPrice
        {
            get { return new ExecPriceType('B'); }
        }

        public static ExecPriceType CreationPrice
        {
            get { return new ExecPriceType('C'); }
        }

        public static ExecPriceType CreationPricePlusAdjustmentPercent
        {
            get { return new ExecPriceType('D'); }
        }

        public static ExecPriceType CreationPricePlusAdjustmentAmount
        {
            get { return new ExecPriceType('E'); }
        }

        public static ExecPriceType OfferPrice
        {
            get { return new ExecPriceType('O'); }
        }

        public static ExecPriceType OfferPriceMinusAdjustmentPercent
        {
            get { return new ExecPriceType('P'); }
        }

        public static ExecPriceType OfferPriceMinusAdjustmentAmount
        {
            get { return new ExecPriceType('Q'); }
        }

        public static ExecPriceType SinglePrice
        {
            get { return new ExecPriceType('S'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeReportTransType : IEquatable<TradeReportTransType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "New"}, {1, "Cancel"}, {2, "Replace"}, {3, "Release"}, {4, "Reverse"},};
        private readonly int? _value;

        private TradeReportTransType(int value)
        {
            _value = value;
        }

        public bool Equals(TradeReportTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeReportTransType && Equals((TradeReportTransType) other);
        }

        public static bool operator ==(TradeReportTransType left, TradeReportTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeReportTransType left, TradeReportTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeReportTransType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeReportTransType", nameof(value));

            return new TradeReportTransType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeReportTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeReportTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeReportTransType Invalid
        {
            get { return new TradeReportTransType(); }
        }

        public static TradeReportTransType New
        {
            get { return new TradeReportTransType(0); }
        }

        public static TradeReportTransType Cancel
        {
            get { return new TradeReportTransType(1); }
        }

        public static TradeReportTransType Replace
        {
            get { return new TradeReportTransType(2); }
        }

        public static TradeReportTransType Release
        {
            get { return new TradeReportTransType(3); }
        }

        public static TradeReportTransType Reverse
        {
            get { return new TradeReportTransType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PaymentMethod : IEquatable<PaymentMethod>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Crest"}, {2, "Nscc"}, {3, "Euroclear"}, {4, "Clearstream"}, {5, "Cheque"}, {6, "TelegraphicTransfer"}, {7, "Fedwire"}, {8, "DebitCard"}, {9, "DirectDebit"}, {10, "DirectCredit"}, {11, "CreditCard"}, {12, "AchDebit"}, {13, "AchCredit"}, {14, "Bpay"}, {15, "HighValueClearingSystem"},};
        private readonly int? _value;

        private PaymentMethod(int value)
        {
            _value = value;
        }

        public bool Equals(PaymentMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PaymentMethod && Equals((PaymentMethod) other);
        }

        public static bool operator ==(PaymentMethod left, PaymentMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PaymentMethod left, PaymentMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PaymentMethod FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PaymentMethod", nameof(value));

            return new PaymentMethod(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PaymentMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PaymentMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PaymentMethod Invalid
        {
            get { return new PaymentMethod(); }
        }

        public static PaymentMethod Crest
        {
            get { return new PaymentMethod(1); }
        }

        public static PaymentMethod Nscc
        {
            get { return new PaymentMethod(2); }
        }

        public static PaymentMethod Euroclear
        {
            get { return new PaymentMethod(3); }
        }

        public static PaymentMethod Clearstream
        {
            get { return new PaymentMethod(4); }
        }

        public static PaymentMethod Cheque
        {
            get { return new PaymentMethod(5); }
        }

        public static PaymentMethod TelegraphicTransfer
        {
            get { return new PaymentMethod(6); }
        }

        public static PaymentMethod Fedwire
        {
            get { return new PaymentMethod(7); }
        }

        public static PaymentMethod DebitCard
        {
            get { return new PaymentMethod(8); }
        }

        public static PaymentMethod DirectDebit
        {
            get { return new PaymentMethod(9); }
        }

        public static PaymentMethod DirectCredit
        {
            get { return new PaymentMethod(10); }
        }

        public static PaymentMethod CreditCard
        {
            get { return new PaymentMethod(11); }
        }

        public static PaymentMethod AchDebit
        {
            get { return new PaymentMethod(12); }
        }

        public static PaymentMethod AchCredit
        {
            get { return new PaymentMethod(13); }
        }

        public static PaymentMethod Bpay
        {
            get { return new PaymentMethod(14); }
        }

        public static PaymentMethod HighValueClearingSystem
        {
            get { return new PaymentMethod(15); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TaxAdvantageType : IEquatable<TaxAdvantageType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "None"}, {1, "MaxiIsa"}, {2, "Tessa"}, {3, "MiniCashIsa"}, {4, "MiniStocksAndSharesIsa"}, {5, "MiniInsuranceIsa"}, {6, "CurrentYearPayment"}, {7, "PriorYearPayment"}, {8, "AssetTransfer"}, {9, "EmployeePriorYear"}, {999, "Other"},};
        private readonly int? _value;

        private TaxAdvantageType(int value)
        {
            _value = value;
        }

        public bool Equals(TaxAdvantageType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TaxAdvantageType && Equals((TaxAdvantageType) other);
        }

        public static bool operator ==(TaxAdvantageType left, TaxAdvantageType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TaxAdvantageType left, TaxAdvantageType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TaxAdvantageType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TaxAdvantageType", nameof(value));

            return new TaxAdvantageType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TaxAdvantageType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TaxAdvantageType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TaxAdvantageType Invalid
        {
            get { return new TaxAdvantageType(); }
        }

        public static TaxAdvantageType None
        {
            get { return new TaxAdvantageType(0); }
        }

        public static TaxAdvantageType MaxiIsa
        {
            get { return new TaxAdvantageType(1); }
        }

        public static TaxAdvantageType Tessa
        {
            get { return new TaxAdvantageType(2); }
        }

        public static TaxAdvantageType MiniCashIsa
        {
            get { return new TaxAdvantageType(3); }
        }

        public static TaxAdvantageType MiniStocksAndSharesIsa
        {
            get { return new TaxAdvantageType(4); }
        }

        public static TaxAdvantageType MiniInsuranceIsa
        {
            get { return new TaxAdvantageType(5); }
        }

        public static TaxAdvantageType CurrentYearPayment
        {
            get { return new TaxAdvantageType(6); }
        }

        public static TaxAdvantageType PriorYearPayment
        {
            get { return new TaxAdvantageType(7); }
        }

        public static TaxAdvantageType AssetTransfer
        {
            get { return new TaxAdvantageType(8); }
        }

        public static TaxAdvantageType EmployeePriorYear
        {
            get { return new TaxAdvantageType(9); }
        }

        public static TaxAdvantageType Other
        {
            get { return new TaxAdvantageType(999); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct FundRenewWaiv : IEquatable<FundRenewWaiv>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'Y', "Yes"}, {'N', "No"},};
        private readonly char? _value;

        private FundRenewWaiv(char value)
        {
            _value = value;
        }

        public bool Equals(FundRenewWaiv other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is FundRenewWaiv && Equals((FundRenewWaiv) other);
        }

        public static bool operator ==(FundRenewWaiv left, FundRenewWaiv right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FundRenewWaiv left, FundRenewWaiv right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static FundRenewWaiv FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for FundRenewWaiv", nameof(value));

            return new FundRenewWaiv(value);
        }

        public static FundRenewWaiv FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for FundRenewWaiv", nameof(value));

            return new FundRenewWaiv(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static FundRenewWaiv FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new FundRenewWaiv(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static FundRenewWaiv Invalid
        {
            get { return new FundRenewWaiv(); }
        }

        public static FundRenewWaiv Yes
        {
            get { return new FundRenewWaiv('Y'); }
        }

        public static FundRenewWaiv No
        {
            get { return new FundRenewWaiv('N'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct RegistStatus : IEquatable<RegistStatus>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'A', "Accepted"}, {'R', "Rejected"}, {'H', "Held"}, {'N', "Reminder"},};
        private readonly char? _value;

        private RegistStatus(char value)
        {
            _value = value;
        }

        public bool Equals(RegistStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is RegistStatus && Equals((RegistStatus) other);
        }

        public static bool operator ==(RegistStatus left, RegistStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RegistStatus left, RegistStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static RegistStatus FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RegistStatus", nameof(value));

            return new RegistStatus(value);
        }

        public static RegistStatus FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RegistStatus", nameof(value));

            return new RegistStatus(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static RegistStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new RegistStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static RegistStatus Invalid
        {
            get { return new RegistStatus(); }
        }

        public static RegistStatus Accepted
        {
            get { return new RegistStatus('A'); }
        }

        public static RegistStatus Rejected
        {
            get { return new RegistStatus('R'); }
        }

        public static RegistStatus Held
        {
            get { return new RegistStatus('H'); }
        }

        public static RegistStatus Reminder
        {
            get { return new RegistStatus('N'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct RegistRejReasonCode : IEquatable<RegistRejReasonCode>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "InvalidUnacceptableAccountType"}, {2, "InvalidUnacceptableTaxExemptType"}, {3, "InvalidUnacceptableOwnershipType"}, {4, "InvalidUnacceptableNoRegDetls"}, {5, "InvalidUnacceptableRegSeqNo"}, {6, "InvalidUnacceptableRegDtls"}, {7, "InvalidUnacceptableMailingDtls"}, {8, "InvalidUnacceptableMailingInst"}, {9, "InvalidUnacceptableInvestorId"}, {10, "InvalidUnacceptableInvestorIdSource"}, {11, "InvalidUnacceptableDateOfBirth"}, {12, "InvalidUnacceptableInvestorCountryOfResidence"}, {13, "InvalidUnacceptableNodistribinstns"}, {14, "InvalidUnacceptableDistribPercentage"}, {15, "InvalidUnacceptableDistribPaymentMethod"}, {16, "InvalidUnacceptableCashDistribAgentAcctName"}, {17, "InvalidUnacceptableCashDistribAgentCode"}, {18, "InvalidUnacceptableCashDistribAgentAcctNum"}, {99, "Other"},};
        private readonly int? _value;

        private RegistRejReasonCode(int value)
        {
            _value = value;
        }

        public bool Equals(RegistRejReasonCode other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is RegistRejReasonCode && Equals((RegistRejReasonCode) other);
        }

        public static bool operator ==(RegistRejReasonCode left, RegistRejReasonCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RegistRejReasonCode left, RegistRejReasonCode right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static RegistRejReasonCode FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RegistRejReasonCode", nameof(value));

            return new RegistRejReasonCode(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static RegistRejReasonCode FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new RegistRejReasonCode(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static RegistRejReasonCode Invalid
        {
            get { return new RegistRejReasonCode(); }
        }

        public static RegistRejReasonCode InvalidUnacceptableAccountType
        {
            get { return new RegistRejReasonCode(1); }
        }

        public static RegistRejReasonCode InvalidUnacceptableTaxExemptType
        {
            get { return new RegistRejReasonCode(2); }
        }

        public static RegistRejReasonCode InvalidUnacceptableOwnershipType
        {
            get { return new RegistRejReasonCode(3); }
        }

        public static RegistRejReasonCode InvalidUnacceptableNoRegDetls
        {
            get { return new RegistRejReasonCode(4); }
        }

        public static RegistRejReasonCode InvalidUnacceptableRegSeqNo
        {
            get { return new RegistRejReasonCode(5); }
        }

        public static RegistRejReasonCode InvalidUnacceptableRegDtls
        {
            get { return new RegistRejReasonCode(6); }
        }

        public static RegistRejReasonCode InvalidUnacceptableMailingDtls
        {
            get { return new RegistRejReasonCode(7); }
        }

        public static RegistRejReasonCode InvalidUnacceptableMailingInst
        {
            get { return new RegistRejReasonCode(8); }
        }

        public static RegistRejReasonCode InvalidUnacceptableInvestorId
        {
            get { return new RegistRejReasonCode(9); }
        }

        public static RegistRejReasonCode InvalidUnacceptableInvestorIdSource
        {
            get { return new RegistRejReasonCode(10); }
        }

        public static RegistRejReasonCode InvalidUnacceptableDateOfBirth
        {
            get { return new RegistRejReasonCode(11); }
        }

        public static RegistRejReasonCode InvalidUnacceptableInvestorCountryOfResidence
        {
            get { return new RegistRejReasonCode(12); }
        }

        public static RegistRejReasonCode InvalidUnacceptableNodistribinstns
        {
            get { return new RegistRejReasonCode(13); }
        }

        public static RegistRejReasonCode InvalidUnacceptableDistribPercentage
        {
            get { return new RegistRejReasonCode(14); }
        }

        public static RegistRejReasonCode InvalidUnacceptableDistribPaymentMethod
        {
            get { return new RegistRejReasonCode(15); }
        }

        public static RegistRejReasonCode InvalidUnacceptableCashDistribAgentAcctName
        {
            get { return new RegistRejReasonCode(16); }
        }

        public static RegistRejReasonCode InvalidUnacceptableCashDistribAgentCode
        {
            get { return new RegistRejReasonCode(17); }
        }

        public static RegistRejReasonCode InvalidUnacceptableCashDistribAgentAcctNum
        {
            get { return new RegistRejReasonCode(18); }
        }

        public static RegistRejReasonCode Other
        {
            get { return new RegistRejReasonCode(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct RegistTransType : IEquatable<RegistTransType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "New"}, {'1', "Replace"}, {'2', "Cancel"},};
        private readonly char? _value;

        private RegistTransType(char value)
        {
            _value = value;
        }

        public bool Equals(RegistTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is RegistTransType && Equals((RegistTransType) other);
        }

        public static bool operator ==(RegistTransType left, RegistTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(RegistTransType left, RegistTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static RegistTransType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RegistTransType", nameof(value));

            return new RegistTransType(value);
        }

        public static RegistTransType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for RegistTransType", nameof(value));

            return new RegistTransType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static RegistTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new RegistTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static RegistTransType Invalid
        {
            get { return new RegistTransType(); }
        }

        public static RegistTransType New
        {
            get { return new RegistTransType('0'); }
        }

        public static RegistTransType Replace
        {
            get { return new RegistTransType('1'); }
        }

        public static RegistTransType Cancel
        {
            get { return new RegistTransType('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OwnershipType : IEquatable<OwnershipType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'J', "JointInvestors"}, {'T', "TenantsInCommon"}, {'2', "JointTrustees"},};
        private readonly char? _value;

        private OwnershipType(char value)
        {
            _value = value;
        }

        public bool Equals(OwnershipType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OwnershipType && Equals((OwnershipType) other);
        }

        public static bool operator ==(OwnershipType left, OwnershipType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OwnershipType left, OwnershipType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static OwnershipType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OwnershipType", nameof(value));

            return new OwnershipType(value);
        }

        public static OwnershipType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OwnershipType", nameof(value));

            return new OwnershipType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static OwnershipType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OwnershipType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OwnershipType Invalid
        {
            get { return new OwnershipType(); }
        }

        public static OwnershipType JointInvestors
        {
            get { return new OwnershipType('J'); }
        }

        public static OwnershipType TenantsInCommon
        {
            get { return new OwnershipType('T'); }
        }

        public static OwnershipType JointTrustees
        {
            get { return new OwnershipType('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ContAmtType : IEquatable<ContAmtType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "CommissionAmount"}, {2, "CommissionPercent"}, {3, "InitialChargeAmount"}, {4, "InitialChargePercent"}, {5, "DiscountAmount"}, {6, "DiscountPercent"}, {7, "DilutionLevyAmount"}, {8, "DilutionLevyPercent"}, {9, "ExitChargeAmount"},};
        private readonly int? _value;

        private ContAmtType(int value)
        {
            _value = value;
        }

        public bool Equals(ContAmtType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ContAmtType && Equals((ContAmtType) other);
        }

        public static bool operator ==(ContAmtType left, ContAmtType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ContAmtType left, ContAmtType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ContAmtType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ContAmtType", nameof(value));

            return new ContAmtType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ContAmtType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ContAmtType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ContAmtType Invalid
        {
            get { return new ContAmtType(); }
        }

        public static ContAmtType CommissionAmount
        {
            get { return new ContAmtType(1); }
        }

        public static ContAmtType CommissionPercent
        {
            get { return new ContAmtType(2); }
        }

        public static ContAmtType InitialChargeAmount
        {
            get { return new ContAmtType(3); }
        }

        public static ContAmtType InitialChargePercent
        {
            get { return new ContAmtType(4); }
        }

        public static ContAmtType DiscountAmount
        {
            get { return new ContAmtType(5); }
        }

        public static ContAmtType DiscountPercent
        {
            get { return new ContAmtType(6); }
        }

        public static ContAmtType DilutionLevyAmount
        {
            get { return new ContAmtType(7); }
        }

        public static ContAmtType DilutionLevyPercent
        {
            get { return new ContAmtType(8); }
        }

        public static ContAmtType ExitChargeAmount
        {
            get { return new ContAmtType(9); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OwnerType : IEquatable<OwnerType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "IndividualInvestor"}, {2, "PublicCompany"}, {3, "PrivateCompany"}, {4, "IndividualTrustee"}, {5, "CompanyTrustee"}, {6, "PensionPlan"}, {7, "CustodianUnderGiftsToMinorsAct"}, {8, "Trusts"}, {9, "Fiduciaries"}, {10, "NetworkingSubAccount"}, {11, "NonProfitOrganization"}, {12, "CorporateBody"}, {13, "Nominee"},};
        private readonly int? _value;

        private OwnerType(int value)
        {
            _value = value;
        }

        public bool Equals(OwnerType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OwnerType && Equals((OwnerType) other);
        }

        public static bool operator ==(OwnerType left, OwnerType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OwnerType left, OwnerType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static OwnerType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OwnerType", nameof(value));

            return new OwnerType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static OwnerType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OwnerType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OwnerType Invalid
        {
            get { return new OwnerType(); }
        }

        public static OwnerType IndividualInvestor
        {
            get { return new OwnerType(1); }
        }

        public static OwnerType PublicCompany
        {
            get { return new OwnerType(2); }
        }

        public static OwnerType PrivateCompany
        {
            get { return new OwnerType(3); }
        }

        public static OwnerType IndividualTrustee
        {
            get { return new OwnerType(4); }
        }

        public static OwnerType CompanyTrustee
        {
            get { return new OwnerType(5); }
        }

        public static OwnerType PensionPlan
        {
            get { return new OwnerType(6); }
        }

        public static OwnerType CustodianUnderGiftsToMinorsAct
        {
            get { return new OwnerType(7); }
        }

        public static OwnerType Trusts
        {
            get { return new OwnerType(8); }
        }

        public static OwnerType Fiduciaries
        {
            get { return new OwnerType(9); }
        }

        public static OwnerType NetworkingSubAccount
        {
            get { return new OwnerType(10); }
        }

        public static OwnerType NonProfitOrganization
        {
            get { return new OwnerType(11); }
        }

        public static OwnerType CorporateBody
        {
            get { return new OwnerType(12); }
        }

        public static OwnerType Nominee
        {
            get { return new OwnerType(13); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OrderCapacity : IEquatable<OrderCapacity>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'A', "Agency"}, {'G', "Proprietary"}, {'I', "Individual"}, {'P', "Principal"}, {'R', "RisklessPrincipal"}, {'W', "AgentForOtherMember"},};
        private readonly char? _value;

        private OrderCapacity(char value)
        {
            _value = value;
        }

        public bool Equals(OrderCapacity other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OrderCapacity && Equals((OrderCapacity) other);
        }

        public static bool operator ==(OrderCapacity left, OrderCapacity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OrderCapacity left, OrderCapacity right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static OrderCapacity FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrderCapacity", nameof(value));

            return new OrderCapacity(value);
        }

        public static OrderCapacity FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrderCapacity", nameof(value));

            return new OrderCapacity(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static OrderCapacity FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OrderCapacity(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OrderCapacity Invalid
        {
            get { return new OrderCapacity(); }
        }

        public static OrderCapacity Agency
        {
            get { return new OrderCapacity('A'); }
        }

        public static OrderCapacity Proprietary
        {
            get { return new OrderCapacity('G'); }
        }

        public static OrderCapacity Individual
        {
            get { return new OrderCapacity('I'); }
        }

        public static OrderCapacity Principal
        {
            get { return new OrderCapacity('P'); }
        }

        public static OrderCapacity RisklessPrincipal
        {
            get { return new OrderCapacity('R'); }
        }

        public static OrderCapacity AgentForOtherMember
        {
            get { return new OrderCapacity('W'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct OrderRestrictions : IEquatable<OrderRestrictions>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"1", "ProgramTrade"}, {"2", "IndexArbitrage"}, {"3", "NonIndexArbitrage"}, {"4", "CompetingMarketMaker"}, {"5", "ActingAsMarketMakerOrSpecialistInTheSecurity"}, {"6", "ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity"}, {"7", "ForeignEntity"}, {"8", "ExternalMarketParticipant"}, {"9", "ExternalInterConnectedMarketLinkage"}, {"A", "RisklessArbitrage"},};
        private readonly string _value;

        private OrderRestrictions(string value)
        {
            _value = value;
        }

        public bool Equals(OrderRestrictions other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is OrderRestrictions && Equals((OrderRestrictions) other);
        }

        public static bool operator ==(OrderRestrictions left, OrderRestrictions right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OrderRestrictions left, OrderRestrictions right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static OrderRestrictions FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for OrderRestrictions", nameof(value));

            return new OrderRestrictions(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static OrderRestrictions FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new OrderRestrictions(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static OrderRestrictions Invalid
        {
            get { return new OrderRestrictions(); }
        }

        public static OrderRestrictions ProgramTrade
        {
            get { return new OrderRestrictions("1"); }
        }

        public static OrderRestrictions IndexArbitrage
        {
            get { return new OrderRestrictions("2"); }
        }

        public static OrderRestrictions NonIndexArbitrage
        {
            get { return new OrderRestrictions("3"); }
        }

        public static OrderRestrictions CompetingMarketMaker
        {
            get { return new OrderRestrictions("4"); }
        }

        public static OrderRestrictions ActingAsMarketMakerOrSpecialistInTheSecurity
        {
            get { return new OrderRestrictions("5"); }
        }

        public static OrderRestrictions ActingAsMarketMakerOrSpecialistInTheUnderlyingSecurityOfADerivativeSecurity
        {
            get { return new OrderRestrictions("6"); }
        }

        public static OrderRestrictions ForeignEntity
        {
            get { return new OrderRestrictions("7"); }
        }

        public static OrderRestrictions ExternalMarketParticipant
        {
            get { return new OrderRestrictions("8"); }
        }

        public static OrderRestrictions ExternalInterConnectedMarketLinkage
        {
            get { return new OrderRestrictions("9"); }
        }

        public static OrderRestrictions RisklessArbitrage
        {
            get { return new OrderRestrictions("A"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MassCancelRequestType : IEquatable<MassCancelRequestType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "CancelOrdersForASecurity"}, {'2', "CancelOrdersForAnUnderlyingSecurity"}, {'3', "CancelOrdersForAProduct"}, {'4', "CancelOrdersForACficode"}, {'5', "CancelOrdersForASecuritytype"}, {'6', "CancelOrdersForATradingSession"}, {'7', "CancelAllOrders"},};
        private readonly char? _value;

        private MassCancelRequestType(char value)
        {
            _value = value;
        }

        public bool Equals(MassCancelRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MassCancelRequestType && Equals((MassCancelRequestType) other);
        }

        public static bool operator ==(MassCancelRequestType left, MassCancelRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassCancelRequestType left, MassCancelRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MassCancelRequestType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MassCancelRequestType", nameof(value));

            return new MassCancelRequestType(value);
        }

        public static MassCancelRequestType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MassCancelRequestType", nameof(value));

            return new MassCancelRequestType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MassCancelRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MassCancelRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MassCancelRequestType Invalid
        {
            get { return new MassCancelRequestType(); }
        }

        public static MassCancelRequestType CancelOrdersForASecurity
        {
            get { return new MassCancelRequestType('1'); }
        }

        public static MassCancelRequestType CancelOrdersForAnUnderlyingSecurity
        {
            get { return new MassCancelRequestType('2'); }
        }

        public static MassCancelRequestType CancelOrdersForAProduct
        {
            get { return new MassCancelRequestType('3'); }
        }

        public static MassCancelRequestType CancelOrdersForACficode
        {
            get { return new MassCancelRequestType('4'); }
        }

        public static MassCancelRequestType CancelOrdersForASecuritytype
        {
            get { return new MassCancelRequestType('5'); }
        }

        public static MassCancelRequestType CancelOrdersForATradingSession
        {
            get { return new MassCancelRequestType('6'); }
        }

        public static MassCancelRequestType CancelAllOrders
        {
            get { return new MassCancelRequestType('7'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MassCancelResponse : IEquatable<MassCancelResponse>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "CancelRequestRejected"}, {'1', "CancelOrdersForASecurity"}, {'2', "CancelOrdersForAnUnderlyingSecurity"}, {'3', "CancelOrdersForAProduct"}, {'4', "CancelOrdersForACficode"}, {'5', "CancelOrdersForASecuritytype"}, {'6', "CancelOrdersForATradingSession"}, {'7', "CancelAllOrders"},};
        private readonly char? _value;

        private MassCancelResponse(char value)
        {
            _value = value;
        }

        public bool Equals(MassCancelResponse other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MassCancelResponse && Equals((MassCancelResponse) other);
        }

        public static bool operator ==(MassCancelResponse left, MassCancelResponse right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassCancelResponse left, MassCancelResponse right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MassCancelResponse FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MassCancelResponse", nameof(value));

            return new MassCancelResponse(value);
        }

        public static MassCancelResponse FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MassCancelResponse", nameof(value));

            return new MassCancelResponse(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MassCancelResponse FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MassCancelResponse(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MassCancelResponse Invalid
        {
            get { return new MassCancelResponse(); }
        }

        public static MassCancelResponse CancelRequestRejected
        {
            get { return new MassCancelResponse('0'); }
        }

        public static MassCancelResponse CancelOrdersForASecurity
        {
            get { return new MassCancelResponse('1'); }
        }

        public static MassCancelResponse CancelOrdersForAnUnderlyingSecurity
        {
            get { return new MassCancelResponse('2'); }
        }

        public static MassCancelResponse CancelOrdersForAProduct
        {
            get { return new MassCancelResponse('3'); }
        }

        public static MassCancelResponse CancelOrdersForACficode
        {
            get { return new MassCancelResponse('4'); }
        }

        public static MassCancelResponse CancelOrdersForASecuritytype
        {
            get { return new MassCancelResponse('5'); }
        }

        public static MassCancelResponse CancelOrdersForATradingSession
        {
            get { return new MassCancelResponse('6'); }
        }

        public static MassCancelResponse CancelAllOrders
        {
            get { return new MassCancelResponse('7'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MassCancelRejectReason : IEquatable<MassCancelRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "MassCancelNotSupported"}, {1, "InvalidOrUnknownSecurity"}, {2, "InvalidOrUnknownUnderlying"}, {3, "InvalidOrUnknownProduct"}, {4, "InvalidOrUnknownCficode"}, {5, "InvalidOrUnknownSecurityType"}, {6, "InvalidOrUnknownTradingSession"}, {99, "Other"},};
        private readonly int? _value;

        private MassCancelRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(MassCancelRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MassCancelRejectReason && Equals((MassCancelRejectReason) other);
        }

        public static bool operator ==(MassCancelRejectReason left, MassCancelRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassCancelRejectReason left, MassCancelRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MassCancelRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MassCancelRejectReason", nameof(value));

            return new MassCancelRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MassCancelRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MassCancelRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MassCancelRejectReason Invalid
        {
            get { return new MassCancelRejectReason(); }
        }

        public static MassCancelRejectReason MassCancelNotSupported
        {
            get { return new MassCancelRejectReason(0); }
        }

        public static MassCancelRejectReason InvalidOrUnknownSecurity
        {
            get { return new MassCancelRejectReason(1); }
        }

        public static MassCancelRejectReason InvalidOrUnknownUnderlying
        {
            get { return new MassCancelRejectReason(2); }
        }

        public static MassCancelRejectReason InvalidOrUnknownProduct
        {
            get { return new MassCancelRejectReason(3); }
        }

        public static MassCancelRejectReason InvalidOrUnknownCficode
        {
            get { return new MassCancelRejectReason(4); }
        }

        public static MassCancelRejectReason InvalidOrUnknownSecurityType
        {
            get { return new MassCancelRejectReason(5); }
        }

        public static MassCancelRejectReason InvalidOrUnknownTradingSession
        {
            get { return new MassCancelRejectReason(6); }
        }

        public static MassCancelRejectReason Other
        {
            get { return new MassCancelRejectReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteType : IEquatable<QuoteType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Indicative"}, {1, "Tradeable"}, {2, "RestrictedTradeable"}, {3, "Counter"},};
        private readonly int? _value;

        private QuoteType(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteType && Equals((QuoteType) other);
        }

        public static bool operator ==(QuoteType left, QuoteType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteType left, QuoteType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteType", nameof(value));

            return new QuoteType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteType Invalid
        {
            get { return new QuoteType(); }
        }

        public static QuoteType Indicative
        {
            get { return new QuoteType(0); }
        }

        public static QuoteType Tradeable
        {
            get { return new QuoteType(1); }
        }

        public static QuoteType RestrictedTradeable
        {
            get { return new QuoteType(2); }
        }

        public static QuoteType Counter
        {
            get { return new QuoteType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CashMargin : IEquatable<CashMargin>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'1', "Cash"}, {'2', "MarginOpen"}, {'3', "MarginClose"},};
        private readonly char? _value;

        private CashMargin(char value)
        {
            _value = value;
        }

        public bool Equals(CashMargin other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CashMargin && Equals((CashMargin) other);
        }

        public static bool operator ==(CashMargin left, CashMargin right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CashMargin left, CashMargin right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CashMargin FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CashMargin", nameof(value));

            return new CashMargin(value);
        }

        public static CashMargin FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CashMargin", nameof(value));

            return new CashMargin(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CashMargin FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CashMargin(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CashMargin Invalid
        {
            get { return new CashMargin(); }
        }

        public static CashMargin Cash
        {
            get { return new CashMargin('1'); }
        }

        public static CashMargin MarginOpen
        {
            get { return new CashMargin('2'); }
        }

        public static CashMargin MarginClose
        {
            get { return new CashMargin('3'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct Scope : IEquatable<Scope>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"1", "Local"}, {"2", "National"}, {"3", "Global"},};
        private readonly string _value;

        private Scope(string value)
        {
            _value = value;
        }

        public bool Equals(Scope other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is Scope && Equals((Scope) other);
        }

        public static bool operator ==(Scope left, Scope right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Scope left, Scope right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static Scope FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for Scope", nameof(value));

            return new Scope(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static Scope FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new Scope(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static Scope Invalid
        {
            get { return new Scope(); }
        }

        public static Scope Local
        {
            get { return new Scope("1"); }
        }

        public static Scope National
        {
            get { return new Scope("2"); }
        }

        public static Scope Global
        {
            get { return new Scope("3"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CrossType : IEquatable<CrossType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "CrossTradeWhichIsExecutedCompletelyOrNot"}, {2, "CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled"}, {3, "CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive"}, {4, "CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice"},};
        private readonly int? _value;

        private CrossType(int value)
        {
            _value = value;
        }

        public bool Equals(CrossType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CrossType && Equals((CrossType) other);
        }

        public static bool operator ==(CrossType left, CrossType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CrossType left, CrossType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CrossType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CrossType", nameof(value));

            return new CrossType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CrossType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CrossType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CrossType Invalid
        {
            get { return new CrossType(); }
        }

        public static CrossType CrossTradeWhichIsExecutedCompletelyOrNot
        {
            get { return new CrossType(1); }
        }

        public static CrossType CrossTradeWhichIsExecutedPartiallyAndTheRestIsCancelled
        {
            get { return new CrossType(2); }
        }

        public static CrossType CrossTradeWhichIsPartiallyExecutedWithTheUnfilledPortionsRemainingActive
        {
            get { return new CrossType(3); }
        }

        public static CrossType CrossTradeIsExecutedWithExistingOrdersWithTheSamePrice
        {
            get { return new CrossType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CrossPrioritization : IEquatable<CrossPrioritization>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "None"}, {1, "BuySideIsPrioritized"}, {2, "SellSideIsPrioritized"},};
        private readonly int? _value;

        private CrossPrioritization(int value)
        {
            _value = value;
        }

        public bool Equals(CrossPrioritization other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CrossPrioritization && Equals((CrossPrioritization) other);
        }

        public static bool operator ==(CrossPrioritization left, CrossPrioritization right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CrossPrioritization left, CrossPrioritization right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CrossPrioritization FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CrossPrioritization", nameof(value));

            return new CrossPrioritization(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CrossPrioritization FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CrossPrioritization(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CrossPrioritization Invalid
        {
            get { return new CrossPrioritization(); }
        }

        public static CrossPrioritization None
        {
            get { return new CrossPrioritization(0); }
        }

        public static CrossPrioritization BuySideIsPrioritized
        {
            get { return new CrossPrioritization(1); }
        }

        public static CrossPrioritization SellSideIsPrioritized
        {
            get { return new CrossPrioritization(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct NoSides : IEquatable<NoSides>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "OneSide"}, {2, "BothSides"},};
        private readonly int? _value;

        private NoSides(int value)
        {
            _value = value;
        }

        public bool Equals(NoSides other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is NoSides && Equals((NoSides) other);
        }

        public static bool operator ==(NoSides left, NoSides right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NoSides left, NoSides right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static NoSides FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for NoSides", nameof(value));

            return new NoSides(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static NoSides FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new NoSides(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static NoSides Invalid
        {
            get { return new NoSides(); }
        }

        public static NoSides OneSide
        {
            get { return new NoSides(1); }
        }

        public static NoSides BothSides
        {
            get { return new NoSides(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityListRequestType : IEquatable<SecurityListRequestType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Symbol"}, {1, "SecuritytypeAndOrCficode"}, {2, "Product"}, {3, "Tradingsessionid"}, {4, "AllSecurities"},};
        private readonly int? _value;

        private SecurityListRequestType(int value)
        {
            _value = value;
        }

        public bool Equals(SecurityListRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityListRequestType && Equals((SecurityListRequestType) other);
        }

        public static bool operator ==(SecurityListRequestType left, SecurityListRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityListRequestType left, SecurityListRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SecurityListRequestType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityListRequestType", nameof(value));

            return new SecurityListRequestType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SecurityListRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityListRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityListRequestType Invalid
        {
            get { return new SecurityListRequestType(); }
        }

        public static SecurityListRequestType Symbol
        {
            get { return new SecurityListRequestType(0); }
        }

        public static SecurityListRequestType SecuritytypeAndOrCficode
        {
            get { return new SecurityListRequestType(1); }
        }

        public static SecurityListRequestType Product
        {
            get { return new SecurityListRequestType(2); }
        }

        public static SecurityListRequestType Tradingsessionid
        {
            get { return new SecurityListRequestType(3); }
        }

        public static SecurityListRequestType AllSecurities
        {
            get { return new SecurityListRequestType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SecurityRequestResult : IEquatable<SecurityRequestResult>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "ValidRequest"}, {1, "InvalidOrUnsupportedRequest"}, {2, "NoInstrumentsFoundThatMatchSelectionCriteria"}, {3, "NotAuthorizedToRetrieveInstrumentData"}, {4, "InstrumentDataTemporarilyUnavailable"}, {5, "RequestForInstrumentDataNotSupported"},};
        private readonly int? _value;

        private SecurityRequestResult(int value)
        {
            _value = value;
        }

        public bool Equals(SecurityRequestResult other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SecurityRequestResult && Equals((SecurityRequestResult) other);
        }

        public static bool operator ==(SecurityRequestResult left, SecurityRequestResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SecurityRequestResult left, SecurityRequestResult right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SecurityRequestResult FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SecurityRequestResult", nameof(value));

            return new SecurityRequestResult(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SecurityRequestResult FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SecurityRequestResult(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SecurityRequestResult Invalid
        {
            get { return new SecurityRequestResult(); }
        }

        public static SecurityRequestResult ValidRequest
        {
            get { return new SecurityRequestResult(0); }
        }

        public static SecurityRequestResult InvalidOrUnsupportedRequest
        {
            get { return new SecurityRequestResult(1); }
        }

        public static SecurityRequestResult NoInstrumentsFoundThatMatchSelectionCriteria
        {
            get { return new SecurityRequestResult(2); }
        }

        public static SecurityRequestResult NotAuthorizedToRetrieveInstrumentData
        {
            get { return new SecurityRequestResult(3); }
        }

        public static SecurityRequestResult InstrumentDataTemporarilyUnavailable
        {
            get { return new SecurityRequestResult(4); }
        }

        public static SecurityRequestResult RequestForInstrumentDataNotSupported
        {
            get { return new SecurityRequestResult(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MultiLegRptTypeReq : IEquatable<MultiLegRptTypeReq>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "ReportByMulitlegSecurityOnly"}, {1, "ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity"}, {2, "ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly"},};
        private readonly int? _value;

        private MultiLegRptTypeReq(int value)
        {
            _value = value;
        }

        public bool Equals(MultiLegRptTypeReq other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MultiLegRptTypeReq && Equals((MultiLegRptTypeReq) other);
        }

        public static bool operator ==(MultiLegRptTypeReq left, MultiLegRptTypeReq right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MultiLegRptTypeReq left, MultiLegRptTypeReq right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MultiLegRptTypeReq FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MultiLegRptTypeReq", nameof(value));

            return new MultiLegRptTypeReq(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MultiLegRptTypeReq FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MultiLegRptTypeReq(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MultiLegRptTypeReq Invalid
        {
            get { return new MultiLegRptTypeReq(); }
        }

        public static MultiLegRptTypeReq ReportByMulitlegSecurityOnly
        {
            get { return new MultiLegRptTypeReq(0); }
        }

        public static MultiLegRptTypeReq ReportByMultilegSecurityAndByInstrumentLegsBelongingToTheMultilegSecurity
        {
            get { return new MultiLegRptTypeReq(1); }
        }

        public static MultiLegRptTypeReq ReportByInstrumentLegsBelongingToTheMultilegSecurityOnly
        {
            get { return new MultiLegRptTypeReq(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradSesStatusRejReason : IEquatable<TradSesStatusRejReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "UnknownOrInvalidTradingsessionid"},};
        private readonly int? _value;

        private TradSesStatusRejReason(int value)
        {
            _value = value;
        }

        public bool Equals(TradSesStatusRejReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradSesStatusRejReason && Equals((TradSesStatusRejReason) other);
        }

        public static bool operator ==(TradSesStatusRejReason left, TradSesStatusRejReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradSesStatusRejReason left, TradSesStatusRejReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradSesStatusRejReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradSesStatusRejReason", nameof(value));

            return new TradSesStatusRejReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradSesStatusRejReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradSesStatusRejReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradSesStatusRejReason Invalid
        {
            get { return new TradSesStatusRejReason(); }
        }

        public static TradSesStatusRejReason UnknownOrInvalidTradingsessionid
        {
            get { return new TradSesStatusRejReason(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeRequestType : IEquatable<TradeRequestType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "AllTrades"}, {1, "MatchedTradesMatchingCriteriaProvidedOnRequest"}, {2, "UnmatchedTradesThatMatchCriteria"}, {3, "UnreportedTradesThatMatchCriteria"}, {4, "AdvisoriesThatMatchCriteria"},};
        private readonly int? _value;

        private TradeRequestType(int value)
        {
            _value = value;
        }

        public bool Equals(TradeRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeRequestType && Equals((TradeRequestType) other);
        }

        public static bool operator ==(TradeRequestType left, TradeRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeRequestType left, TradeRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeRequestType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeRequestType", nameof(value));

            return new TradeRequestType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeRequestType Invalid
        {
            get { return new TradeRequestType(); }
        }

        public static TradeRequestType AllTrades
        {
            get { return new TradeRequestType(0); }
        }

        public static TradeRequestType MatchedTradesMatchingCriteriaProvidedOnRequest
        {
            get { return new TradeRequestType(1); }
        }

        public static TradeRequestType UnmatchedTradesThatMatchCriteria
        {
            get { return new TradeRequestType(2); }
        }

        public static TradeRequestType UnreportedTradesThatMatchCriteria
        {
            get { return new TradeRequestType(3); }
        }

        public static TradeRequestType AdvisoriesThatMatchCriteria
        {
            get { return new TradeRequestType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MatchStatus : IEquatable<MatchStatus>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "ComparedMatchedOrAffirmed"}, {'1', "UncomparedUnmatchedOrUnaffirmed"}, {'2', "AdvisoryOrAlert"},};
        private readonly char? _value;

        private MatchStatus(char value)
        {
            _value = value;
        }

        public bool Equals(MatchStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MatchStatus && Equals((MatchStatus) other);
        }

        public static bool operator ==(MatchStatus left, MatchStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MatchStatus left, MatchStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MatchStatus FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MatchStatus", nameof(value));

            return new MatchStatus(value);
        }

        public static MatchStatus FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MatchStatus", nameof(value));

            return new MatchStatus(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MatchStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MatchStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MatchStatus Invalid
        {
            get { return new MatchStatus(); }
        }

        public static MatchStatus ComparedMatchedOrAffirmed
        {
            get { return new MatchStatus('0'); }
        }

        public static MatchStatus UncomparedUnmatchedOrUnaffirmed
        {
            get { return new MatchStatus('1'); }
        }

        public static MatchStatus AdvisoryOrAlert
        {
            get { return new MatchStatus('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ClearingInstruction : IEquatable<ClearingInstruction>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "ProcessNormally"}, {1, "ExcludeFromAllNetting"}, {2, "BilateralNettingOnly"}, {3, "ExClearing"}, {4, "SpecialTrade"}, {5, "MultilateralNetting"}, {6, "ClearAgainstCentralCounterparty"}, {7, "ExcludeFromCentralCounterparty"}, {8, "ManualMode"}, {9, "AutomaticPostingMode"}, {10, "AutomaticGiveUpMode"}, {11, "QualifiedServiceRepresentative"}, {12, "CustomerTrade"}, {13, "SelfClearing"},};
        private readonly int? _value;

        private ClearingInstruction(int value)
        {
            _value = value;
        }

        public bool Equals(ClearingInstruction other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ClearingInstruction && Equals((ClearingInstruction) other);
        }

        public static bool operator ==(ClearingInstruction left, ClearingInstruction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ClearingInstruction left, ClearingInstruction right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ClearingInstruction FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ClearingInstruction", nameof(value));

            return new ClearingInstruction(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ClearingInstruction FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ClearingInstruction(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ClearingInstruction Invalid
        {
            get { return new ClearingInstruction(); }
        }

        public static ClearingInstruction ProcessNormally
        {
            get { return new ClearingInstruction(0); }
        }

        public static ClearingInstruction ExcludeFromAllNetting
        {
            get { return new ClearingInstruction(1); }
        }

        public static ClearingInstruction BilateralNettingOnly
        {
            get { return new ClearingInstruction(2); }
        }

        public static ClearingInstruction ExClearing
        {
            get { return new ClearingInstruction(3); }
        }

        public static ClearingInstruction SpecialTrade
        {
            get { return new ClearingInstruction(4); }
        }

        public static ClearingInstruction MultilateralNetting
        {
            get { return new ClearingInstruction(5); }
        }

        public static ClearingInstruction ClearAgainstCentralCounterparty
        {
            get { return new ClearingInstruction(6); }
        }

        public static ClearingInstruction ExcludeFromCentralCounterparty
        {
            get { return new ClearingInstruction(7); }
        }

        public static ClearingInstruction ManualMode
        {
            get { return new ClearingInstruction(8); }
        }

        public static ClearingInstruction AutomaticPostingMode
        {
            get { return new ClearingInstruction(9); }
        }

        public static ClearingInstruction AutomaticGiveUpMode
        {
            get { return new ClearingInstruction(10); }
        }

        public static ClearingInstruction QualifiedServiceRepresentative
        {
            get { return new ClearingInstruction(11); }
        }

        public static ClearingInstruction CustomerTrade
        {
            get { return new ClearingInstruction(12); }
        }

        public static ClearingInstruction SelfClearing
        {
            get { return new ClearingInstruction(13); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AccountType : IEquatable<AccountType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "AccountIsCarriedOnCustomerSideOfBooks"}, {2, "AccountIsCarriedOnNonCustomerSideOfBooks"}, {3, "HouseTrader"}, {4, "FloorTrader"}, {6, "AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined"}, {7, "AccountIsHouseTraderAndIsCrossMargined"}, {8, "JointBackofficeAccount"},};
        private readonly int? _value;

        private AccountType(int value)
        {
            _value = value;
        }

        public bool Equals(AccountType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AccountType && Equals((AccountType) other);
        }

        public static bool operator ==(AccountType left, AccountType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AccountType left, AccountType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AccountType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AccountType", nameof(value));

            return new AccountType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AccountType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AccountType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AccountType Invalid
        {
            get { return new AccountType(); }
        }

        public static AccountType AccountIsCarriedOnCustomerSideOfBooks
        {
            get { return new AccountType(1); }
        }

        public static AccountType AccountIsCarriedOnNonCustomerSideOfBooks
        {
            get { return new AccountType(2); }
        }

        public static AccountType HouseTrader
        {
            get { return new AccountType(3); }
        }

        public static AccountType FloorTrader
        {
            get { return new AccountType(4); }
        }

        public static AccountType AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
        {
            get { return new AccountType(6); }
        }

        public static AccountType AccountIsHouseTraderAndIsCrossMargined
        {
            get { return new AccountType(7); }
        }

        public static AccountType JointBackofficeAccount
        {
            get { return new AccountType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CustOrderCapacity : IEquatable<CustOrderCapacity>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "MemberTradingForTheirOwnAccount"}, {2, "ClearingFirmTradingForItsProprietaryAccount"}, {3, "MemberTradingForAnotherMember"}, {4, "AllOther"},};
        private readonly int? _value;

        private CustOrderCapacity(int value)
        {
            _value = value;
        }

        public bool Equals(CustOrderCapacity other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CustOrderCapacity && Equals((CustOrderCapacity) other);
        }

        public static bool operator ==(CustOrderCapacity left, CustOrderCapacity right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CustOrderCapacity left, CustOrderCapacity right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CustOrderCapacity FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CustOrderCapacity", nameof(value));

            return new CustOrderCapacity(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CustOrderCapacity FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CustOrderCapacity(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CustOrderCapacity Invalid
        {
            get { return new CustOrderCapacity(); }
        }

        public static CustOrderCapacity MemberTradingForTheirOwnAccount
        {
            get { return new CustOrderCapacity(1); }
        }

        public static CustOrderCapacity ClearingFirmTradingForItsProprietaryAccount
        {
            get { return new CustOrderCapacity(2); }
        }

        public static CustOrderCapacity MemberTradingForAnotherMember
        {
            get { return new CustOrderCapacity(3); }
        }

        public static CustOrderCapacity AllOther
        {
            get { return new CustOrderCapacity(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MassStatusReqType : IEquatable<MassStatusReqType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "StatusForOrdersForASecurity"}, {2, "StatusForOrdersForAnUnderlyingSecurity"}, {3, "StatusForOrdersForAProduct"}, {4, "StatusForOrdersForACficode"}, {5, "StatusForOrdersForASecuritytype"}, {6, "StatusForOrdersForATradingSession"}, {7, "StatusForAllOrders"}, {8, "StatusForOrdersForAPartyid"},};
        private readonly int? _value;

        private MassStatusReqType(int value)
        {
            _value = value;
        }

        public bool Equals(MassStatusReqType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MassStatusReqType && Equals((MassStatusReqType) other);
        }

        public static bool operator ==(MassStatusReqType left, MassStatusReqType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassStatusReqType left, MassStatusReqType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MassStatusReqType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MassStatusReqType", nameof(value));

            return new MassStatusReqType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MassStatusReqType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MassStatusReqType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MassStatusReqType Invalid
        {
            get { return new MassStatusReqType(); }
        }

        public static MassStatusReqType StatusForOrdersForASecurity
        {
            get { return new MassStatusReqType(1); }
        }

        public static MassStatusReqType StatusForOrdersForAnUnderlyingSecurity
        {
            get { return new MassStatusReqType(2); }
        }

        public static MassStatusReqType StatusForOrdersForAProduct
        {
            get { return new MassStatusReqType(3); }
        }

        public static MassStatusReqType StatusForOrdersForACficode
        {
            get { return new MassStatusReqType(4); }
        }

        public static MassStatusReqType StatusForOrdersForASecuritytype
        {
            get { return new MassStatusReqType(5); }
        }

        public static MassStatusReqType StatusForOrdersForATradingSession
        {
            get { return new MassStatusReqType(6); }
        }

        public static MassStatusReqType StatusForAllOrders
        {
            get { return new MassStatusReqType(7); }
        }

        public static MassStatusReqType StatusForOrdersForAPartyid
        {
            get { return new MassStatusReqType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DayBookingInst : IEquatable<DayBookingInst>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "CanTriggerBookingWithoutReferenceToTheOrderInitiator"}, {'1', "SpeakWithOrderInitiatorBeforeBooking"}, {'2', "Accumulate"},};
        private readonly char? _value;

        private DayBookingInst(char value)
        {
            _value = value;
        }

        public bool Equals(DayBookingInst other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DayBookingInst && Equals((DayBookingInst) other);
        }

        public static bool operator ==(DayBookingInst left, DayBookingInst right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DayBookingInst left, DayBookingInst right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DayBookingInst FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DayBookingInst", nameof(value));

            return new DayBookingInst(value);
        }

        public static DayBookingInst FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DayBookingInst", nameof(value));

            return new DayBookingInst(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DayBookingInst FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DayBookingInst(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DayBookingInst Invalid
        {
            get { return new DayBookingInst(); }
        }

        public static DayBookingInst CanTriggerBookingWithoutReferenceToTheOrderInitiator
        {
            get { return new DayBookingInst('0'); }
        }

        public static DayBookingInst SpeakWithOrderInitiatorBeforeBooking
        {
            get { return new DayBookingInst('1'); }
        }

        public static DayBookingInst Accumulate
        {
            get { return new DayBookingInst('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BookingUnit : IEquatable<BookingUnit>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "EachPartialExecutionIsABookableUnit"}, {'1', "AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder"}, {'2', "AggregateExecutionsForThisSymbolSideAndSettlementDate"},};
        private readonly char? _value;

        private BookingUnit(char value)
        {
            _value = value;
        }

        public bool Equals(BookingUnit other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BookingUnit && Equals((BookingUnit) other);
        }

        public static bool operator ==(BookingUnit left, BookingUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BookingUnit left, BookingUnit right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BookingUnit FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BookingUnit", nameof(value));

            return new BookingUnit(value);
        }

        public static BookingUnit FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BookingUnit", nameof(value));

            return new BookingUnit(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BookingUnit FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BookingUnit(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BookingUnit Invalid
        {
            get { return new BookingUnit(); }
        }

        public static BookingUnit EachPartialExecutionIsABookableUnit
        {
            get { return new BookingUnit('0'); }
        }

        public static BookingUnit AggregatePartialExecutionsOnThisOrderAndBookOneTradePerOrder
        {
            get { return new BookingUnit('1'); }
        }

        public static BookingUnit AggregateExecutionsForThisSymbolSideAndSettlementDate
        {
            get { return new BookingUnit('2'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PreallocMethod : IEquatable<PreallocMethod>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'0', "ProRata"}, {'1', "DoNotProRata"},};
        private readonly char? _value;

        private PreallocMethod(char value)
        {
            _value = value;
        }

        public bool Equals(PreallocMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PreallocMethod && Equals((PreallocMethod) other);
        }

        public static bool operator ==(PreallocMethod left, PreallocMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PreallocMethod left, PreallocMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PreallocMethod FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PreallocMethod", nameof(value));

            return new PreallocMethod(value);
        }

        public static PreallocMethod FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PreallocMethod", nameof(value));

            return new PreallocMethod(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PreallocMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PreallocMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PreallocMethod Invalid
        {
            get { return new PreallocMethod(); }
        }

        public static PreallocMethod ProRata
        {
            get { return new PreallocMethod('0'); }
        }

        public static PreallocMethod DoNotProRata
        {
            get { return new PreallocMethod('1'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocType : IEquatable<AllocType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Calculated"}, {2, "Preliminary"}, {5, "ReadyToBookSingleOrder"}, {7, "WarehouseInstruction"}, {8, "RequestToIntermediary"},};
        private readonly int? _value;

        private AllocType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocType && Equals((AllocType) other);
        }

        public static bool operator ==(AllocType left, AllocType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocType left, AllocType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocType", nameof(value));

            return new AllocType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocType Invalid
        {
            get { return new AllocType(); }
        }

        public static AllocType Calculated
        {
            get { return new AllocType(1); }
        }

        public static AllocType Preliminary
        {
            get { return new AllocType(2); }
        }

        public static AllocType ReadyToBookSingleOrder
        {
            get { return new AllocType(5); }
        }

        public static AllocType WarehouseInstruction
        {
            get { return new AllocType(7); }
        }

        public static AllocType RequestToIntermediary
        {
            get { return new AllocType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ClearingFeeIndicator : IEquatable<ClearingFeeIndicator>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"B", "CboeMember"}, {"C", "NonMemberAndCustomer"}, {"E", "EquityMemberAndClearingMember"}, {"F", "FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers"}, {"H", "Firms106HAnd106J"}, {"I", "GimIdemAndComMembershipInterestHolders"}, {"L", "LesseeAnd106FEmployees"}, {"M", "AllOtherOwnershipTypes"},};
        private readonly string _value;

        private ClearingFeeIndicator(string value)
        {
            _value = value;
        }

        public bool Equals(ClearingFeeIndicator other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ClearingFeeIndicator && Equals((ClearingFeeIndicator) other);
        }

        public static bool operator ==(ClearingFeeIndicator left, ClearingFeeIndicator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ClearingFeeIndicator left, ClearingFeeIndicator right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static ClearingFeeIndicator FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ClearingFeeIndicator", nameof(value));

            return new ClearingFeeIndicator(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static ClearingFeeIndicator FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ClearingFeeIndicator(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ClearingFeeIndicator Invalid
        {
            get { return new ClearingFeeIndicator(); }
        }

        public static ClearingFeeIndicator CboeMember
        {
            get { return new ClearingFeeIndicator("B"); }
        }

        public static ClearingFeeIndicator NonMemberAndCustomer
        {
            get { return new ClearingFeeIndicator("C"); }
        }

        public static ClearingFeeIndicator EquityMemberAndClearingMember
        {
            get { return new ClearingFeeIndicator("E"); }
        }

        public static ClearingFeeIndicator FullAndAssociateMemberTradingForOwnAccountAndAsFloorBrokers
        {
            get { return new ClearingFeeIndicator("F"); }
        }

        public static ClearingFeeIndicator Firms106HAnd106J
        {
            get { return new ClearingFeeIndicator("H"); }
        }

        public static ClearingFeeIndicator GimIdemAndComMembershipInterestHolders
        {
            get { return new ClearingFeeIndicator("I"); }
        }

        public static ClearingFeeIndicator LesseeAnd106FEmployees
        {
            get { return new ClearingFeeIndicator("L"); }
        }

        public static ClearingFeeIndicator AllOtherOwnershipTypes
        {
            get { return new ClearingFeeIndicator("M"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PriorityIndicator : IEquatable<PriorityIndicator>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "PriorityUnchanged"}, {1, "LostPriorityAsResultOfOrderChange"},};
        private readonly int? _value;

        private PriorityIndicator(int value)
        {
            _value = value;
        }

        public bool Equals(PriorityIndicator other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PriorityIndicator && Equals((PriorityIndicator) other);
        }

        public static bool operator ==(PriorityIndicator left, PriorityIndicator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PriorityIndicator left, PriorityIndicator right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PriorityIndicator FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PriorityIndicator", nameof(value));

            return new PriorityIndicator(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PriorityIndicator FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PriorityIndicator(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PriorityIndicator Invalid
        {
            get { return new PriorityIndicator(); }
        }

        public static PriorityIndicator PriorityUnchanged
        {
            get { return new PriorityIndicator(0); }
        }

        public static PriorityIndicator LostPriorityAsResultOfOrderChange
        {
            get { return new PriorityIndicator(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteRequestRejectReason : IEquatable<QuoteRequestRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "UnknownSymbol"}, {2, "ExchangeClosed"}, {3, "QuoteRequestExceedsLimit"}, {4, "TooLateToEnter"}, {5, "InvalidPrice"}, {6, "NotAuthorizedToRequestQuote"}, {7, "NoMatchForInquiry"}, {8, "NoMarketForInstrument"}, {9, "NoInventory"}, {10, "Pass"}, {99, "Other"},};
        private readonly int? _value;

        private QuoteRequestRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteRequestRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteRequestRejectReason && Equals((QuoteRequestRejectReason) other);
        }

        public static bool operator ==(QuoteRequestRejectReason left, QuoteRequestRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteRequestRejectReason left, QuoteRequestRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteRequestRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteRequestRejectReason", nameof(value));

            return new QuoteRequestRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteRequestRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteRequestRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteRequestRejectReason Invalid
        {
            get { return new QuoteRequestRejectReason(); }
        }

        public static QuoteRequestRejectReason UnknownSymbol
        {
            get { return new QuoteRequestRejectReason(1); }
        }

        public static QuoteRequestRejectReason ExchangeClosed
        {
            get { return new QuoteRequestRejectReason(2); }
        }

        public static QuoteRequestRejectReason QuoteRequestExceedsLimit
        {
            get { return new QuoteRequestRejectReason(3); }
        }

        public static QuoteRequestRejectReason TooLateToEnter
        {
            get { return new QuoteRequestRejectReason(4); }
        }

        public static QuoteRequestRejectReason InvalidPrice
        {
            get { return new QuoteRequestRejectReason(5); }
        }

        public static QuoteRequestRejectReason NotAuthorizedToRequestQuote
        {
            get { return new QuoteRequestRejectReason(6); }
        }

        public static QuoteRequestRejectReason NoMatchForInquiry
        {
            get { return new QuoteRequestRejectReason(7); }
        }

        public static QuoteRequestRejectReason NoMarketForInstrument
        {
            get { return new QuoteRequestRejectReason(8); }
        }

        public static QuoteRequestRejectReason NoInventory
        {
            get { return new QuoteRequestRejectReason(9); }
        }

        public static QuoteRequestRejectReason Pass
        {
            get { return new QuoteRequestRejectReason(10); }
        }

        public static QuoteRequestRejectReason Other
        {
            get { return new QuoteRequestRejectReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AcctIDSource : IEquatable<AcctIDSource>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Bic"}, {2, "SidCode"}, {3, "Tfm"}, {4, "Omgeo"}, {5, "DtccCode"}, {99, "Other"},};
        private readonly int? _value;

        private AcctIDSource(int value)
        {
            _value = value;
        }

        public bool Equals(AcctIDSource other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AcctIDSource && Equals((AcctIDSource) other);
        }

        public static bool operator ==(AcctIDSource left, AcctIDSource right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AcctIDSource left, AcctIDSource right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AcctIDSource FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AcctIDSource", nameof(value));

            return new AcctIDSource(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AcctIDSource FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AcctIDSource(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AcctIDSource Invalid
        {
            get { return new AcctIDSource(); }
        }

        public static AcctIDSource Bic
        {
            get { return new AcctIDSource(1); }
        }

        public static AcctIDSource SidCode
        {
            get { return new AcctIDSource(2); }
        }

        public static AcctIDSource Tfm
        {
            get { return new AcctIDSource(3); }
        }

        public static AcctIDSource Omgeo
        {
            get { return new AcctIDSource(4); }
        }

        public static AcctIDSource DtccCode
        {
            get { return new AcctIDSource(5); }
        }

        public static AcctIDSource Other
        {
            get { return new AcctIDSource(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ConfirmStatus : IEquatable<ConfirmStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Received"}, {2, "MismatchedAccount"}, {3, "MissingSettlementInstructions"}, {4, "Confirmed"}, {5, "RequestRejected"},};
        private readonly int? _value;

        private ConfirmStatus(int value)
        {
            _value = value;
        }

        public bool Equals(ConfirmStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ConfirmStatus && Equals((ConfirmStatus) other);
        }

        public static bool operator ==(ConfirmStatus left, ConfirmStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConfirmStatus left, ConfirmStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ConfirmStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ConfirmStatus", nameof(value));

            return new ConfirmStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ConfirmStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ConfirmStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ConfirmStatus Invalid
        {
            get { return new ConfirmStatus(); }
        }

        public static ConfirmStatus Received
        {
            get { return new ConfirmStatus(1); }
        }

        public static ConfirmStatus MismatchedAccount
        {
            get { return new ConfirmStatus(2); }
        }

        public static ConfirmStatus MissingSettlementInstructions
        {
            get { return new ConfirmStatus(3); }
        }

        public static ConfirmStatus Confirmed
        {
            get { return new ConfirmStatus(4); }
        }

        public static ConfirmStatus RequestRejected
        {
            get { return new ConfirmStatus(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ConfirmTransType : IEquatable<ConfirmTransType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "New"}, {1, "Replace"}, {2, "Cancel"},};
        private readonly int? _value;

        private ConfirmTransType(int value)
        {
            _value = value;
        }

        public bool Equals(ConfirmTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ConfirmTransType && Equals((ConfirmTransType) other);
        }

        public static bool operator ==(ConfirmTransType left, ConfirmTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConfirmTransType left, ConfirmTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ConfirmTransType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ConfirmTransType", nameof(value));

            return new ConfirmTransType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ConfirmTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ConfirmTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ConfirmTransType Invalid
        {
            get { return new ConfirmTransType(); }
        }

        public static ConfirmTransType New
        {
            get { return new ConfirmTransType(0); }
        }

        public static ConfirmTransType Replace
        {
            get { return new ConfirmTransType(1); }
        }

        public static ConfirmTransType Cancel
        {
            get { return new ConfirmTransType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DeliveryForm : IEquatable<DeliveryForm>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Bookentry"}, {2, "Bearer"},};
        private readonly int? _value;

        private DeliveryForm(int value)
        {
            _value = value;
        }

        public bool Equals(DeliveryForm other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DeliveryForm && Equals((DeliveryForm) other);
        }

        public static bool operator ==(DeliveryForm left, DeliveryForm right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DeliveryForm left, DeliveryForm right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DeliveryForm FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DeliveryForm", nameof(value));

            return new DeliveryForm(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DeliveryForm FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DeliveryForm(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DeliveryForm Invalid
        {
            get { return new DeliveryForm(); }
        }

        public static DeliveryForm Bookentry
        {
            get { return new DeliveryForm(1); }
        }

        public static DeliveryForm Bearer
        {
            get { return new DeliveryForm(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct LegSwapType : IEquatable<LegSwapType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "ParForPar"}, {2, "ModifiedDuration"}, {4, "Risk"}, {5, "Proceeds"},};
        private readonly int? _value;

        private LegSwapType(int value)
        {
            _value = value;
        }

        public bool Equals(LegSwapType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is LegSwapType && Equals((LegSwapType) other);
        }

        public static bool operator ==(LegSwapType left, LegSwapType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LegSwapType left, LegSwapType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static LegSwapType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for LegSwapType", nameof(value));

            return new LegSwapType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static LegSwapType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new LegSwapType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static LegSwapType Invalid
        {
            get { return new LegSwapType(); }
        }

        public static LegSwapType ParForPar
        {
            get { return new LegSwapType(1); }
        }

        public static LegSwapType ModifiedDuration
        {
            get { return new LegSwapType(2); }
        }

        public static LegSwapType Risk
        {
            get { return new LegSwapType(4); }
        }

        public static LegSwapType Proceeds
        {
            get { return new LegSwapType(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuotePriceType : IEquatable<QuotePriceType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Percent"}, {2, "PerShare"}, {3, "FixedAmount"}, {4, "Discount"}, {5, "Premium"}, {6, "BasisPointsRelativeToBenchmark"}, {7, "TedPrice"}, {8, "TedYield"}, {9, "YieldSpread"}, {10, "Yield"},};
        private readonly int? _value;

        private QuotePriceType(int value)
        {
            _value = value;
        }

        public bool Equals(QuotePriceType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuotePriceType && Equals((QuotePriceType) other);
        }

        public static bool operator ==(QuotePriceType left, QuotePriceType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuotePriceType left, QuotePriceType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuotePriceType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuotePriceType", nameof(value));

            return new QuotePriceType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuotePriceType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuotePriceType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuotePriceType Invalid
        {
            get { return new QuotePriceType(); }
        }

        public static QuotePriceType Percent
        {
            get { return new QuotePriceType(1); }
        }

        public static QuotePriceType PerShare
        {
            get { return new QuotePriceType(2); }
        }

        public static QuotePriceType FixedAmount
        {
            get { return new QuotePriceType(3); }
        }

        public static QuotePriceType Discount
        {
            get { return new QuotePriceType(4); }
        }

        public static QuotePriceType Premium
        {
            get { return new QuotePriceType(5); }
        }

        public static QuotePriceType BasisPointsRelativeToBenchmark
        {
            get { return new QuotePriceType(6); }
        }

        public static QuotePriceType TedPrice
        {
            get { return new QuotePriceType(7); }
        }

        public static QuotePriceType TedYield
        {
            get { return new QuotePriceType(8); }
        }

        public static QuotePriceType YieldSpread
        {
            get { return new QuotePriceType(9); }
        }

        public static QuotePriceType Yield
        {
            get { return new QuotePriceType(10); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QuoteRespType : IEquatable<QuoteRespType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "HitLift"}, {2, "Counter"}, {3, "Expired"}, {4, "Cover"}, {5, "DoneAway"}, {6, "Pass"},};
        private readonly int? _value;

        private QuoteRespType(int value)
        {
            _value = value;
        }

        public bool Equals(QuoteRespType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QuoteRespType && Equals((QuoteRespType) other);
        }

        public static bool operator ==(QuoteRespType left, QuoteRespType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QuoteRespType left, QuoteRespType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QuoteRespType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QuoteRespType", nameof(value));

            return new QuoteRespType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QuoteRespType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QuoteRespType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QuoteRespType Invalid
        {
            get { return new QuoteRespType(); }
        }

        public static QuoteRespType HitLift
        {
            get { return new QuoteRespType(1); }
        }

        public static QuoteRespType Counter
        {
            get { return new QuoteRespType(2); }
        }

        public static QuoteRespType Expired
        {
            get { return new QuoteRespType(3); }
        }

        public static QuoteRespType Cover
        {
            get { return new QuoteRespType(4); }
        }

        public static QuoteRespType DoneAway
        {
            get { return new QuoteRespType(5); }
        }

        public static QuoteRespType Pass
        {
            get { return new QuoteRespType(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosType : IEquatable<PosType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"TQ", "TransactionQuantity"}, {"IAS", "IntraSpreadQty"}, {"IES", "InterSpreadQty"}, {"FIN", "EndOfDayQty"}, {"SOD", "StartOfDayQty"}, {"EX", "OptionExerciseQty"}, {"AS", "OptionAssignment"}, {"TX", "TransactionFromExercise"}, {"TA", "TransactionFromAssignment"}, {"PIT", "PitTradeQty"}, {"TRF", "TransferTradeQty"}, {"ETR", "ElectronicTradeQty"}, {"ALC", "AllocationTradeQty"}, {"PA", "AdjustmentQty"}, {"ASF", "AsOfTradeQty"}, {"DLV", "DeliveryQty"}, {"TOT", "TotalTransactionQty"}, {"XM", "CrossMarginQty"}, {"SPL", "IntegralSplit"},};
        private readonly string _value;

        private PosType(string value)
        {
            _value = value;
        }

        public bool Equals(PosType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosType && Equals((PosType) other);
        }

        public static bool operator ==(PosType left, PosType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosType left, PosType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static PosType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosType", nameof(value));

            return new PosType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static PosType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosType Invalid
        {
            get { return new PosType(); }
        }

        public static PosType TransactionQuantity
        {
            get { return new PosType("TQ"); }
        }

        public static PosType IntraSpreadQty
        {
            get { return new PosType("IAS"); }
        }

        public static PosType InterSpreadQty
        {
            get { return new PosType("IES"); }
        }

        public static PosType EndOfDayQty
        {
            get { return new PosType("FIN"); }
        }

        public static PosType StartOfDayQty
        {
            get { return new PosType("SOD"); }
        }

        public static PosType OptionExerciseQty
        {
            get { return new PosType("EX"); }
        }

        public static PosType OptionAssignment
        {
            get { return new PosType("AS"); }
        }

        public static PosType TransactionFromExercise
        {
            get { return new PosType("TX"); }
        }

        public static PosType TransactionFromAssignment
        {
            get { return new PosType("TA"); }
        }

        public static PosType PitTradeQty
        {
            get { return new PosType("PIT"); }
        }

        public static PosType TransferTradeQty
        {
            get { return new PosType("TRF"); }
        }

        public static PosType ElectronicTradeQty
        {
            get { return new PosType("ETR"); }
        }

        public static PosType AllocationTradeQty
        {
            get { return new PosType("ALC"); }
        }

        public static PosType AdjustmentQty
        {
            get { return new PosType("PA"); }
        }

        public static PosType AsOfTradeQty
        {
            get { return new PosType("ASF"); }
        }

        public static PosType DeliveryQty
        {
            get { return new PosType("DLV"); }
        }

        public static PosType TotalTransactionQty
        {
            get { return new PosType("TOT"); }
        }

        public static PosType CrossMarginQty
        {
            get { return new PosType("XM"); }
        }

        public static PosType IntegralSplit
        {
            get { return new PosType("SPL"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosQtyStatus : IEquatable<PosQtyStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Submitted"}, {1, "Accepted"}, {2, "Rejected"},};
        private readonly int? _value;

        private PosQtyStatus(int value)
        {
            _value = value;
        }

        public bool Equals(PosQtyStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosQtyStatus && Equals((PosQtyStatus) other);
        }

        public static bool operator ==(PosQtyStatus left, PosQtyStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosQtyStatus left, PosQtyStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosQtyStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosQtyStatus", nameof(value));

            return new PosQtyStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosQtyStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosQtyStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosQtyStatus Invalid
        {
            get { return new PosQtyStatus(); }
        }

        public static PosQtyStatus Submitted
        {
            get { return new PosQtyStatus(0); }
        }

        public static PosQtyStatus Accepted
        {
            get { return new PosQtyStatus(1); }
        }

        public static PosQtyStatus Rejected
        {
            get { return new PosQtyStatus(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosAmtType : IEquatable<PosAmtType>
    {
        private static IDictionary<string, string> _possibleValues = new Dictionary<string, string> {{"FMTM", "FinalMarkToMarketAmount"}, {"IMTM", "IncrementalMarkToMarketAmount"}, {"TVAR", "TradeVariationAmount"}, {"SMTM", "StartOfDayMarkToMarketAmount"}, {"PREM", "PremiumAmount"}, {"CRES", "CashResidualAmount"}, {"CASH", "CashAmount"}, {"VADJ", "ValueAdjustedAmount"},};
        private readonly string _value;

        private PosAmtType(string value)
        {
            _value = value;
        }

        public bool Equals(PosAmtType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosAmtType && Equals((PosAmtType) other);
        }

        public static bool operator ==(PosAmtType left, PosAmtType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosAmtType left, PosAmtType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value?.GetHashCode() ?? 0;
        }

        public static PosAmtType FromValue(string value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosAmtType", nameof(value));

            return new PosAmtType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value, out name) ? name : null;
        }

        public static PosAmtType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosAmtType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosAmtType Invalid
        {
            get { return new PosAmtType(); }
        }

        public static PosAmtType FinalMarkToMarketAmount
        {
            get { return new PosAmtType("FMTM"); }
        }

        public static PosAmtType IncrementalMarkToMarketAmount
        {
            get { return new PosAmtType("IMTM"); }
        }

        public static PosAmtType TradeVariationAmount
        {
            get { return new PosAmtType("TVAR"); }
        }

        public static PosAmtType StartOfDayMarkToMarketAmount
        {
            get { return new PosAmtType("SMTM"); }
        }

        public static PosAmtType PremiumAmount
        {
            get { return new PosAmtType("PREM"); }
        }

        public static PosAmtType CashResidualAmount
        {
            get { return new PosAmtType("CRES"); }
        }

        public static PosAmtType CashAmount
        {
            get { return new PosAmtType("CASH"); }
        }

        public static PosAmtType ValueAdjustedAmount
        {
            get { return new PosAmtType("VADJ"); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosTransType : IEquatable<PosTransType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Exercise"}, {2, "DoNotExercise"}, {3, "PositionAdjustment"}, {4, "PositionChangeSubmissionMarginDisposition"}, {5, "Pledge"},};
        private readonly int? _value;

        private PosTransType(int value)
        {
            _value = value;
        }

        public bool Equals(PosTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosTransType && Equals((PosTransType) other);
        }

        public static bool operator ==(PosTransType left, PosTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosTransType left, PosTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosTransType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosTransType", nameof(value));

            return new PosTransType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosTransType Invalid
        {
            get { return new PosTransType(); }
        }

        public static PosTransType Exercise
        {
            get { return new PosTransType(1); }
        }

        public static PosTransType DoNotExercise
        {
            get { return new PosTransType(2); }
        }

        public static PosTransType PositionAdjustment
        {
            get { return new PosTransType(3); }
        }

        public static PosTransType PositionChangeSubmissionMarginDisposition
        {
            get { return new PosTransType(4); }
        }

        public static PosTransType Pledge
        {
            get { return new PosTransType(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosMaintAction : IEquatable<PosMaintAction>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "New"}, {2, "Replace"}, {3, "Cancel"},};
        private readonly int? _value;

        private PosMaintAction(int value)
        {
            _value = value;
        }

        public bool Equals(PosMaintAction other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosMaintAction && Equals((PosMaintAction) other);
        }

        public static bool operator ==(PosMaintAction left, PosMaintAction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosMaintAction left, PosMaintAction right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosMaintAction FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosMaintAction", nameof(value));

            return new PosMaintAction(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosMaintAction FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosMaintAction(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosMaintAction Invalid
        {
            get { return new PosMaintAction(); }
        }

        public static PosMaintAction New
        {
            get { return new PosMaintAction(1); }
        }

        public static PosMaintAction Replace
        {
            get { return new PosMaintAction(2); }
        }

        public static PosMaintAction Cancel
        {
            get { return new PosMaintAction(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AdjustmentType : IEquatable<AdjustmentType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "ProcessRequestAsMarginDisposition"}, {1, "DeltaPlus"}, {2, "DeltaMinus"}, {3, "Final"},};
        private readonly int? _value;

        private AdjustmentType(int value)
        {
            _value = value;
        }

        public bool Equals(AdjustmentType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AdjustmentType && Equals((AdjustmentType) other);
        }

        public static bool operator ==(AdjustmentType left, AdjustmentType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AdjustmentType left, AdjustmentType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AdjustmentType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AdjustmentType", nameof(value));

            return new AdjustmentType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AdjustmentType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AdjustmentType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AdjustmentType Invalid
        {
            get { return new AdjustmentType(); }
        }

        public static AdjustmentType ProcessRequestAsMarginDisposition
        {
            get { return new AdjustmentType(0); }
        }

        public static AdjustmentType DeltaPlus
        {
            get { return new AdjustmentType(1); }
        }

        public static AdjustmentType DeltaMinus
        {
            get { return new AdjustmentType(2); }
        }

        public static AdjustmentType Final
        {
            get { return new AdjustmentType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosMaintStatus : IEquatable<PosMaintStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Accepted"}, {1, "AcceptedWithWarnings"}, {2, "Rejected"}, {3, "Completed"}, {4, "CompletedWithWarnings"},};
        private readonly int? _value;

        private PosMaintStatus(int value)
        {
            _value = value;
        }

        public bool Equals(PosMaintStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosMaintStatus && Equals((PosMaintStatus) other);
        }

        public static bool operator ==(PosMaintStatus left, PosMaintStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosMaintStatus left, PosMaintStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosMaintStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosMaintStatus", nameof(value));

            return new PosMaintStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosMaintStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosMaintStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosMaintStatus Invalid
        {
            get { return new PosMaintStatus(); }
        }

        public static PosMaintStatus Accepted
        {
            get { return new PosMaintStatus(0); }
        }

        public static PosMaintStatus AcceptedWithWarnings
        {
            get { return new PosMaintStatus(1); }
        }

        public static PosMaintStatus Rejected
        {
            get { return new PosMaintStatus(2); }
        }

        public static PosMaintStatus Completed
        {
            get { return new PosMaintStatus(3); }
        }

        public static PosMaintStatus CompletedWithWarnings
        {
            get { return new PosMaintStatus(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosMaintResult : IEquatable<PosMaintResult>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "SuccessfulCompletionNoWarningsOrErrors"}, {1, "Rejected"}, {99, "Other"},};
        private readonly int? _value;

        private PosMaintResult(int value)
        {
            _value = value;
        }

        public bool Equals(PosMaintResult other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosMaintResult && Equals((PosMaintResult) other);
        }

        public static bool operator ==(PosMaintResult left, PosMaintResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosMaintResult left, PosMaintResult right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosMaintResult FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosMaintResult", nameof(value));

            return new PosMaintResult(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosMaintResult FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosMaintResult(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosMaintResult Invalid
        {
            get { return new PosMaintResult(); }
        }

        public static PosMaintResult SuccessfulCompletionNoWarningsOrErrors
        {
            get { return new PosMaintResult(0); }
        }

        public static PosMaintResult Rejected
        {
            get { return new PosMaintResult(1); }
        }

        public static PosMaintResult Other
        {
            get { return new PosMaintResult(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosReqType : IEquatable<PosReqType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Positions"}, {1, "Trades"}, {2, "Exercises"}, {3, "Assignments"},};
        private readonly int? _value;

        private PosReqType(int value)
        {
            _value = value;
        }

        public bool Equals(PosReqType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosReqType && Equals((PosReqType) other);
        }

        public static bool operator ==(PosReqType left, PosReqType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosReqType left, PosReqType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosReqType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosReqType", nameof(value));

            return new PosReqType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosReqType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosReqType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosReqType Invalid
        {
            get { return new PosReqType(); }
        }

        public static PosReqType Positions
        {
            get { return new PosReqType(0); }
        }

        public static PosReqType Trades
        {
            get { return new PosReqType(1); }
        }

        public static PosReqType Exercises
        {
            get { return new PosReqType(2); }
        }

        public static PosReqType Assignments
        {
            get { return new PosReqType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ResponseTransportType : IEquatable<ResponseTransportType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Inband"}, {1, "OutOfBand"},};
        private readonly int? _value;

        private ResponseTransportType(int value)
        {
            _value = value;
        }

        public bool Equals(ResponseTransportType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ResponseTransportType && Equals((ResponseTransportType) other);
        }

        public static bool operator ==(ResponseTransportType left, ResponseTransportType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ResponseTransportType left, ResponseTransportType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ResponseTransportType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ResponseTransportType", nameof(value));

            return new ResponseTransportType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ResponseTransportType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ResponseTransportType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ResponseTransportType Invalid
        {
            get { return new ResponseTransportType(); }
        }

        public static ResponseTransportType Inband
        {
            get { return new ResponseTransportType(0); }
        }

        public static ResponseTransportType OutOfBand
        {
            get { return new ResponseTransportType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosReqResult : IEquatable<PosReqResult>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "ValidRequest"}, {1, "InvalidOrUnsupportedRequest"}, {2, "NoPositionsFoundThatMatchCriteria"}, {3, "NotAuthorizedToRequestPositions"}, {4, "RequestForPositionNotSupported"}, {99, "Other"},};
        private readonly int? _value;

        private PosReqResult(int value)
        {
            _value = value;
        }

        public bool Equals(PosReqResult other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosReqResult && Equals((PosReqResult) other);
        }

        public static bool operator ==(PosReqResult left, PosReqResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosReqResult left, PosReqResult right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosReqResult FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosReqResult", nameof(value));

            return new PosReqResult(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosReqResult FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosReqResult(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosReqResult Invalid
        {
            get { return new PosReqResult(); }
        }

        public static PosReqResult ValidRequest
        {
            get { return new PosReqResult(0); }
        }

        public static PosReqResult InvalidOrUnsupportedRequest
        {
            get { return new PosReqResult(1); }
        }

        public static PosReqResult NoPositionsFoundThatMatchCriteria
        {
            get { return new PosReqResult(2); }
        }

        public static PosReqResult NotAuthorizedToRequestPositions
        {
            get { return new PosReqResult(3); }
        }

        public static PosReqResult RequestForPositionNotSupported
        {
            get { return new PosReqResult(4); }
        }

        public static PosReqResult Other
        {
            get { return new PosReqResult(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PosReqStatus : IEquatable<PosReqStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Completed"}, {1, "CompletedWithWarnings"}, {2, "Rejected"},};
        private readonly int? _value;

        private PosReqStatus(int value)
        {
            _value = value;
        }

        public bool Equals(PosReqStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PosReqStatus && Equals((PosReqStatus) other);
        }

        public static bool operator ==(PosReqStatus left, PosReqStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PosReqStatus left, PosReqStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PosReqStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PosReqStatus", nameof(value));

            return new PosReqStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PosReqStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PosReqStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PosReqStatus Invalid
        {
            get { return new PosReqStatus(); }
        }

        public static PosReqStatus Completed
        {
            get { return new PosReqStatus(0); }
        }

        public static PosReqStatus CompletedWithWarnings
        {
            get { return new PosReqStatus(1); }
        }

        public static PosReqStatus Rejected
        {
            get { return new PosReqStatus(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlPriceType : IEquatable<SettlPriceType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Final"}, {2, "Theoretical"},};
        private readonly int? _value;

        private SettlPriceType(int value)
        {
            _value = value;
        }

        public bool Equals(SettlPriceType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlPriceType && Equals((SettlPriceType) other);
        }

        public static bool operator ==(SettlPriceType left, SettlPriceType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlPriceType left, SettlPriceType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlPriceType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlPriceType", nameof(value));

            return new SettlPriceType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlPriceType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlPriceType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlPriceType Invalid
        {
            get { return new SettlPriceType(); }
        }

        public static SettlPriceType Final
        {
            get { return new SettlPriceType(1); }
        }

        public static SettlPriceType Theoretical
        {
            get { return new SettlPriceType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AssignmentMethod : IEquatable<AssignmentMethod>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'R', "Random"}, {'P', "Prorata"},};
        private readonly char? _value;

        private AssignmentMethod(char value)
        {
            _value = value;
        }

        public bool Equals(AssignmentMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AssignmentMethod && Equals((AssignmentMethod) other);
        }

        public static bool operator ==(AssignmentMethod left, AssignmentMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AssignmentMethod left, AssignmentMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AssignmentMethod FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AssignmentMethod", nameof(value));

            return new AssignmentMethod(value);
        }

        public static AssignmentMethod FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AssignmentMethod", nameof(value));

            return new AssignmentMethod(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AssignmentMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AssignmentMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AssignmentMethod Invalid
        {
            get { return new AssignmentMethod(); }
        }

        public static AssignmentMethod Random
        {
            get { return new AssignmentMethod('R'); }
        }

        public static AssignmentMethod Prorata
        {
            get { return new AssignmentMethod('P'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ExerciseMethod : IEquatable<ExerciseMethod>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'A', "Automatic"}, {'M', "Manual"},};
        private readonly char? _value;

        private ExerciseMethod(char value)
        {
            _value = value;
        }

        public bool Equals(ExerciseMethod other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ExerciseMethod && Equals((ExerciseMethod) other);
        }

        public static bool operator ==(ExerciseMethod left, ExerciseMethod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExerciseMethod left, ExerciseMethod right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ExerciseMethod FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExerciseMethod", nameof(value));

            return new ExerciseMethod(value);
        }

        public static ExerciseMethod FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExerciseMethod", nameof(value));

            return new ExerciseMethod(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ExerciseMethod FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ExerciseMethod(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ExerciseMethod Invalid
        {
            get { return new ExerciseMethod(); }
        }

        public static ExerciseMethod Automatic
        {
            get { return new ExerciseMethod('A'); }
        }

        public static ExerciseMethod Manual
        {
            get { return new ExerciseMethod('M'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeRequestResult : IEquatable<TradeRequestResult>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Successful"}, {1, "InvalidOrUnknownInstrument"}, {2, "InvalidTypeOfTradeRequested"}, {3, "InvalidParties"}, {4, "InvalidTransportTypeRequested"}, {5, "InvalidDestinationRequested"}, {8, "TraderequesttypeNotSupported"}, {9, "UnauthorizedForTradeCaptureReportRequest"}, {10, "Yield"},};
        private readonly int? _value;

        private TradeRequestResult(int value)
        {
            _value = value;
        }

        public bool Equals(TradeRequestResult other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeRequestResult && Equals((TradeRequestResult) other);
        }

        public static bool operator ==(TradeRequestResult left, TradeRequestResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeRequestResult left, TradeRequestResult right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeRequestResult FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeRequestResult", nameof(value));

            return new TradeRequestResult(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeRequestResult FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeRequestResult(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeRequestResult Invalid
        {
            get { return new TradeRequestResult(); }
        }

        public static TradeRequestResult Successful
        {
            get { return new TradeRequestResult(0); }
        }

        public static TradeRequestResult InvalidOrUnknownInstrument
        {
            get { return new TradeRequestResult(1); }
        }

        public static TradeRequestResult InvalidTypeOfTradeRequested
        {
            get { return new TradeRequestResult(2); }
        }

        public static TradeRequestResult InvalidParties
        {
            get { return new TradeRequestResult(3); }
        }

        public static TradeRequestResult InvalidTransportTypeRequested
        {
            get { return new TradeRequestResult(4); }
        }

        public static TradeRequestResult InvalidDestinationRequested
        {
            get { return new TradeRequestResult(5); }
        }

        public static TradeRequestResult TraderequesttypeNotSupported
        {
            get { return new TradeRequestResult(8); }
        }

        public static TradeRequestResult UnauthorizedForTradeCaptureReportRequest
        {
            get { return new TradeRequestResult(9); }
        }

        public static TradeRequestResult Yield
        {
            get { return new TradeRequestResult(10); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeRequestStatus : IEquatable<TradeRequestStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Accepted"}, {1, "Completed"}, {2, "Rejected"},};
        private readonly int? _value;

        private TradeRequestStatus(int value)
        {
            _value = value;
        }

        public bool Equals(TradeRequestStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeRequestStatus && Equals((TradeRequestStatus) other);
        }

        public static bool operator ==(TradeRequestStatus left, TradeRequestStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeRequestStatus left, TradeRequestStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeRequestStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeRequestStatus", nameof(value));

            return new TradeRequestStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeRequestStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeRequestStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeRequestStatus Invalid
        {
            get { return new TradeRequestStatus(); }
        }

        public static TradeRequestStatus Accepted
        {
            get { return new TradeRequestStatus(0); }
        }

        public static TradeRequestStatus Completed
        {
            get { return new TradeRequestStatus(1); }
        }

        public static TradeRequestStatus Rejected
        {
            get { return new TradeRequestStatus(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeReportRejectReason : IEquatable<TradeReportRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Successful"}, {1, "InvalidPartyInformation"}, {2, "UnknownInstrument"}, {3, "UnauthorizedToReportTrades"}, {4, "InvalidTradeType"}, {10, "Yield"},};
        private readonly int? _value;

        private TradeReportRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(TradeReportRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeReportRejectReason && Equals((TradeReportRejectReason) other);
        }

        public static bool operator ==(TradeReportRejectReason left, TradeReportRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeReportRejectReason left, TradeReportRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeReportRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeReportRejectReason", nameof(value));

            return new TradeReportRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeReportRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeReportRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeReportRejectReason Invalid
        {
            get { return new TradeReportRejectReason(); }
        }

        public static TradeReportRejectReason Successful
        {
            get { return new TradeReportRejectReason(0); }
        }

        public static TradeReportRejectReason InvalidPartyInformation
        {
            get { return new TradeReportRejectReason(1); }
        }

        public static TradeReportRejectReason UnknownInstrument
        {
            get { return new TradeReportRejectReason(2); }
        }

        public static TradeReportRejectReason UnauthorizedToReportTrades
        {
            get { return new TradeReportRejectReason(3); }
        }

        public static TradeReportRejectReason InvalidTradeType
        {
            get { return new TradeReportRejectReason(4); }
        }

        public static TradeReportRejectReason Yield
        {
            get { return new TradeReportRejectReason(10); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SideMultiLegReportingType : IEquatable<SideMultiLegReportingType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "SingleSecurity"}, {2, "IndividualLegOfAMultiLegSecurity"}, {3, "MultiLegSecurity"},};
        private readonly int? _value;

        private SideMultiLegReportingType(int value)
        {
            _value = value;
        }

        public bool Equals(SideMultiLegReportingType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SideMultiLegReportingType && Equals((SideMultiLegReportingType) other);
        }

        public static bool operator ==(SideMultiLegReportingType left, SideMultiLegReportingType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SideMultiLegReportingType left, SideMultiLegReportingType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SideMultiLegReportingType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SideMultiLegReportingType", nameof(value));

            return new SideMultiLegReportingType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SideMultiLegReportingType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SideMultiLegReportingType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SideMultiLegReportingType Invalid
        {
            get { return new SideMultiLegReportingType(); }
        }

        public static SideMultiLegReportingType SingleSecurity
        {
            get { return new SideMultiLegReportingType(1); }
        }

        public static SideMultiLegReportingType IndividualLegOfAMultiLegSecurity
        {
            get { return new SideMultiLegReportingType(2); }
        }

        public static SideMultiLegReportingType MultiLegSecurity
        {
            get { return new SideMultiLegReportingType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TrdRegTimestampType : IEquatable<TrdRegTimestampType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "ExecutionTime"}, {2, "TimeIn"}, {3, "TimeOut"}, {4, "BrokerReceipt"}, {5, "BrokerExecution"},};
        private readonly int? _value;

        private TrdRegTimestampType(int value)
        {
            _value = value;
        }

        public bool Equals(TrdRegTimestampType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TrdRegTimestampType && Equals((TrdRegTimestampType) other);
        }

        public static bool operator ==(TrdRegTimestampType left, TrdRegTimestampType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TrdRegTimestampType left, TrdRegTimestampType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TrdRegTimestampType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TrdRegTimestampType", nameof(value));

            return new TrdRegTimestampType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TrdRegTimestampType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TrdRegTimestampType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TrdRegTimestampType Invalid
        {
            get { return new TrdRegTimestampType(); }
        }

        public static TrdRegTimestampType ExecutionTime
        {
            get { return new TrdRegTimestampType(1); }
        }

        public static TrdRegTimestampType TimeIn
        {
            get { return new TrdRegTimestampType(2); }
        }

        public static TrdRegTimestampType TimeOut
        {
            get { return new TrdRegTimestampType(3); }
        }

        public static TrdRegTimestampType BrokerReceipt
        {
            get { return new TrdRegTimestampType(4); }
        }

        public static TrdRegTimestampType BrokerExecution
        {
            get { return new TrdRegTimestampType(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ConfirmType : IEquatable<ConfirmType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Status"}, {2, "Confirmation"}, {3, "ConfirmationRequestRejected"},};
        private readonly int? _value;

        private ConfirmType(int value)
        {
            _value = value;
        }

        public bool Equals(ConfirmType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ConfirmType && Equals((ConfirmType) other);
        }

        public static bool operator ==(ConfirmType left, ConfirmType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConfirmType left, ConfirmType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ConfirmType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ConfirmType", nameof(value));

            return new ConfirmType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ConfirmType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ConfirmType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ConfirmType Invalid
        {
            get { return new ConfirmType(); }
        }

        public static ConfirmType Status
        {
            get { return new ConfirmType(1); }
        }

        public static ConfirmType Confirmation
        {
            get { return new ConfirmType(2); }
        }

        public static ConfirmType ConfirmationRequestRejected
        {
            get { return new ConfirmType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ConfirmRejReason : IEquatable<ConfirmRejReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "MismatchedAccount"}, {2, "MissingSettlementInstructions"}, {99, "Other"},};
        private readonly int? _value;

        private ConfirmRejReason(int value)
        {
            _value = value;
        }

        public bool Equals(ConfirmRejReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ConfirmRejReason && Equals((ConfirmRejReason) other);
        }

        public static bool operator ==(ConfirmRejReason left, ConfirmRejReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ConfirmRejReason left, ConfirmRejReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ConfirmRejReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ConfirmRejReason", nameof(value));

            return new ConfirmRejReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ConfirmRejReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ConfirmRejReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ConfirmRejReason Invalid
        {
            get { return new ConfirmRejReason(); }
        }

        public static ConfirmRejReason MismatchedAccount
        {
            get { return new ConfirmRejReason(1); }
        }

        public static ConfirmRejReason MissingSettlementInstructions
        {
            get { return new ConfirmRejReason(2); }
        }

        public static ConfirmRejReason Other
        {
            get { return new ConfirmRejReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct BookingType : IEquatable<BookingType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "RegularBooking"}, {1, "Cfd"}, {2, "TotalReturnSwap"},};
        private readonly int? _value;

        private BookingType(int value)
        {
            _value = value;
        }

        public bool Equals(BookingType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is BookingType && Equals((BookingType) other);
        }

        public static bool operator ==(BookingType left, BookingType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BookingType left, BookingType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static BookingType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for BookingType", nameof(value));

            return new BookingType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static BookingType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new BookingType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static BookingType Invalid
        {
            get { return new BookingType(); }
        }

        public static BookingType RegularBooking
        {
            get { return new BookingType(0); }
        }

        public static BookingType Cfd
        {
            get { return new BookingType(1); }
        }

        public static BookingType TotalReturnSwap
        {
            get { return new BookingType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocSettlInstType : IEquatable<AllocSettlInstType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "UseDefaultInstructions"}, {1, "DeriveFromParametersProvided"}, {2, "FullDetailsProvided"}, {3, "SsiDbIdsProvided"}, {4, "PhoneForInstructions"},};
        private readonly int? _value;

        private AllocSettlInstType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocSettlInstType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocSettlInstType && Equals((AllocSettlInstType) other);
        }

        public static bool operator ==(AllocSettlInstType left, AllocSettlInstType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocSettlInstType left, AllocSettlInstType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocSettlInstType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocSettlInstType", nameof(value));

            return new AllocSettlInstType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocSettlInstType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocSettlInstType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocSettlInstType Invalid
        {
            get { return new AllocSettlInstType(); }
        }

        public static AllocSettlInstType UseDefaultInstructions
        {
            get { return new AllocSettlInstType(0); }
        }

        public static AllocSettlInstType DeriveFromParametersProvided
        {
            get { return new AllocSettlInstType(1); }
        }

        public static AllocSettlInstType FullDetailsProvided
        {
            get { return new AllocSettlInstType(2); }
        }

        public static AllocSettlInstType SsiDbIdsProvided
        {
            get { return new AllocSettlInstType(3); }
        }

        public static AllocSettlInstType PhoneForInstructions
        {
            get { return new AllocSettlInstType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DlvyInstType : IEquatable<DlvyInstType>
    {
        private static IDictionary<char, string> _possibleValues = new Dictionary<char, string> {{'S', "Securities"}, {'C', "Cash"},};
        private readonly char? _value;

        private DlvyInstType(char value)
        {
            _value = value;
        }

        public bool Equals(DlvyInstType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DlvyInstType && Equals((DlvyInstType) other);
        }

        public static bool operator ==(DlvyInstType left, DlvyInstType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DlvyInstType left, DlvyInstType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DlvyInstType FromValue(char value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DlvyInstType", nameof(value));

            return new DlvyInstType(value);
        }

        public static DlvyInstType FromValue(string value)
        {
            if (value.Length != 1 || _possibleValues.ContainsKey(value[0]) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DlvyInstType", nameof(value));

            return new DlvyInstType(value[0]);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DlvyInstType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DlvyInstType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DlvyInstType Invalid
        {
            get { return new DlvyInstType(); }
        }

        public static DlvyInstType Securities
        {
            get { return new DlvyInstType('S'); }
        }

        public static DlvyInstType Cash
        {
            get { return new DlvyInstType('C'); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TerminationType : IEquatable<TerminationType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Overnight"}, {2, "Term"}, {3, "Flexible"}, {4, "Open"},};
        private readonly int? _value;

        private TerminationType(int value)
        {
            _value = value;
        }

        public bool Equals(TerminationType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TerminationType && Equals((TerminationType) other);
        }

        public static bool operator ==(TerminationType left, TerminationType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TerminationType left, TerminationType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TerminationType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TerminationType", nameof(value));

            return new TerminationType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TerminationType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TerminationType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TerminationType Invalid
        {
            get { return new TerminationType(); }
        }

        public static TerminationType Overnight
        {
            get { return new TerminationType(1); }
        }

        public static TerminationType Term
        {
            get { return new TerminationType(2); }
        }

        public static TerminationType Flexible
        {
            get { return new TerminationType(3); }
        }

        public static TerminationType Open
        {
            get { return new TerminationType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct SettlInstReqRejCode : IEquatable<SettlInstReqRejCode>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "UnableToProcessRequest"}, {1, "UnknownAccount"}, {2, "NoMatchingSettlementInstructionsFound"}, {99, "Other"},};
        private readonly int? _value;

        private SettlInstReqRejCode(int value)
        {
            _value = value;
        }

        public bool Equals(SettlInstReqRejCode other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is SettlInstReqRejCode && Equals((SettlInstReqRejCode) other);
        }

        public static bool operator ==(SettlInstReqRejCode left, SettlInstReqRejCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SettlInstReqRejCode left, SettlInstReqRejCode right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static SettlInstReqRejCode FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for SettlInstReqRejCode", nameof(value));

            return new SettlInstReqRejCode(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static SettlInstReqRejCode FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new SettlInstReqRejCode(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static SettlInstReqRejCode Invalid
        {
            get { return new SettlInstReqRejCode(); }
        }

        public static SettlInstReqRejCode UnableToProcessRequest
        {
            get { return new SettlInstReqRejCode(0); }
        }

        public static SettlInstReqRejCode UnknownAccount
        {
            get { return new SettlInstReqRejCode(1); }
        }

        public static SettlInstReqRejCode NoMatchingSettlementInstructionsFound
        {
            get { return new SettlInstReqRejCode(2); }
        }

        public static SettlInstReqRejCode Other
        {
            get { return new SettlInstReqRejCode(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocReportType : IEquatable<AllocReportType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{3, "SellsideCalculatedUsingPreliminary"}, {4, "SellsideCalculatedWithoutPreliminary"}, {5, "WarehouseRecap"}, {8, "RequestToIntermediary"},};
        private readonly int? _value;

        private AllocReportType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocReportType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocReportType && Equals((AllocReportType) other);
        }

        public static bool operator ==(AllocReportType left, AllocReportType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocReportType left, AllocReportType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocReportType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocReportType", nameof(value));

            return new AllocReportType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocReportType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocReportType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocReportType Invalid
        {
            get { return new AllocReportType(); }
        }

        public static AllocReportType SellsideCalculatedUsingPreliminary
        {
            get { return new AllocReportType(3); }
        }

        public static AllocReportType SellsideCalculatedWithoutPreliminary
        {
            get { return new AllocReportType(4); }
        }

        public static AllocReportType WarehouseRecap
        {
            get { return new AllocReportType(5); }
        }

        public static AllocReportType RequestToIntermediary
        {
            get { return new AllocReportType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocCancReplaceReason : IEquatable<AllocCancReplaceReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "OriginalDetailsIncompleteIncorrect"}, {2, "ChangeInUnderlyingOrderDetails"},};
        private readonly int? _value;

        private AllocCancReplaceReason(int value)
        {
            _value = value;
        }

        public bool Equals(AllocCancReplaceReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocCancReplaceReason && Equals((AllocCancReplaceReason) other);
        }

        public static bool operator ==(AllocCancReplaceReason left, AllocCancReplaceReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocCancReplaceReason left, AllocCancReplaceReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocCancReplaceReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocCancReplaceReason", nameof(value));

            return new AllocCancReplaceReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocCancReplaceReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocCancReplaceReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocCancReplaceReason Invalid
        {
            get { return new AllocCancReplaceReason(); }
        }

        public static AllocCancReplaceReason OriginalDetailsIncompleteIncorrect
        {
            get { return new AllocCancReplaceReason(1); }
        }

        public static AllocCancReplaceReason ChangeInUnderlyingOrderDetails
        {
            get { return new AllocCancReplaceReason(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocAccountType : IEquatable<AllocAccountType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "AccountIsCarriedOnCustomerSideOfBooks"}, {2, "AccountIsCarriedOnNonCustomerSideOfBooks"}, {3, "HouseTrader"}, {4, "FloorTrader"}, {6, "AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined"}, {7, "AccountIsHouseTraderAndIsCrossMargined"}, {8, "JointBackofficeAccount"},};
        private readonly int? _value;

        private AllocAccountType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocAccountType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocAccountType && Equals((AllocAccountType) other);
        }

        public static bool operator ==(AllocAccountType left, AllocAccountType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocAccountType left, AllocAccountType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocAccountType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocAccountType", nameof(value));

            return new AllocAccountType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocAccountType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocAccountType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocAccountType Invalid
        {
            get { return new AllocAccountType(); }
        }

        public static AllocAccountType AccountIsCarriedOnCustomerSideOfBooks
        {
            get { return new AllocAccountType(1); }
        }

        public static AllocAccountType AccountIsCarriedOnNonCustomerSideOfBooks
        {
            get { return new AllocAccountType(2); }
        }

        public static AllocAccountType HouseTrader
        {
            get { return new AllocAccountType(3); }
        }

        public static AllocAccountType FloorTrader
        {
            get { return new AllocAccountType(4); }
        }

        public static AllocAccountType AccountIsCarriedOnNonCustomerSideOfBooksAndIsCrossMargined
        {
            get { return new AllocAccountType(6); }
        }

        public static AllocAccountType AccountIsHouseTraderAndIsCrossMargined
        {
            get { return new AllocAccountType(7); }
        }

        public static AllocAccountType JointBackofficeAccount
        {
            get { return new AllocAccountType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocIntermedReqType : IEquatable<AllocIntermedReqType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "PendingAccept"}, {2, "PendingRelease"}, {3, "PendingReversal"}, {4, "Accept"}, {5, "BlockLevelReject"}, {6, "AccountLevelReject"},};
        private readonly int? _value;

        private AllocIntermedReqType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocIntermedReqType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocIntermedReqType && Equals((AllocIntermedReqType) other);
        }

        public static bool operator ==(AllocIntermedReqType left, AllocIntermedReqType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocIntermedReqType left, AllocIntermedReqType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocIntermedReqType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocIntermedReqType", nameof(value));

            return new AllocIntermedReqType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocIntermedReqType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocIntermedReqType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocIntermedReqType Invalid
        {
            get { return new AllocIntermedReqType(); }
        }

        public static AllocIntermedReqType PendingAccept
        {
            get { return new AllocIntermedReqType(1); }
        }

        public static AllocIntermedReqType PendingRelease
        {
            get { return new AllocIntermedReqType(2); }
        }

        public static AllocIntermedReqType PendingReversal
        {
            get { return new AllocIntermedReqType(3); }
        }

        public static AllocIntermedReqType Accept
        {
            get { return new AllocIntermedReqType(4); }
        }

        public static AllocIntermedReqType BlockLevelReject
        {
            get { return new AllocIntermedReqType(5); }
        }

        public static AllocIntermedReqType AccountLevelReject
        {
            get { return new AllocIntermedReqType(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ApplQueueResolution : IEquatable<ApplQueueResolution>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "NoActionTaken"}, {1, "QueueFlushed"}, {2, "OverlayLast"}, {3, "EndSession"},};
        private readonly int? _value;

        private ApplQueueResolution(int value)
        {
            _value = value;
        }

        public bool Equals(ApplQueueResolution other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ApplQueueResolution && Equals((ApplQueueResolution) other);
        }

        public static bool operator ==(ApplQueueResolution left, ApplQueueResolution right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ApplQueueResolution left, ApplQueueResolution right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ApplQueueResolution FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ApplQueueResolution", nameof(value));

            return new ApplQueueResolution(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ApplQueueResolution FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ApplQueueResolution(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ApplQueueResolution Invalid
        {
            get { return new ApplQueueResolution(); }
        }

        public static ApplQueueResolution NoActionTaken
        {
            get { return new ApplQueueResolution(0); }
        }

        public static ApplQueueResolution QueueFlushed
        {
            get { return new ApplQueueResolution(1); }
        }

        public static ApplQueueResolution OverlayLast
        {
            get { return new ApplQueueResolution(2); }
        }

        public static ApplQueueResolution EndSession
        {
            get { return new ApplQueueResolution(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ApplQueueAction : IEquatable<ApplQueueAction>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "NoActionTaken"}, {1, "QueueFlushed"}, {2, "OverlayLast"}, {3, "EndSession"},};
        private readonly int? _value;

        private ApplQueueAction(int value)
        {
            _value = value;
        }

        public bool Equals(ApplQueueAction other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ApplQueueAction && Equals((ApplQueueAction) other);
        }

        public static bool operator ==(ApplQueueAction left, ApplQueueAction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ApplQueueAction left, ApplQueueAction right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ApplQueueAction FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ApplQueueAction", nameof(value));

            return new ApplQueueAction(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ApplQueueAction FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ApplQueueAction(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ApplQueueAction Invalid
        {
            get { return new ApplQueueAction(); }
        }

        public static ApplQueueAction NoActionTaken
        {
            get { return new ApplQueueAction(0); }
        }

        public static ApplQueueAction QueueFlushed
        {
            get { return new ApplQueueAction(1); }
        }

        public static ApplQueueAction OverlayLast
        {
            get { return new ApplQueueAction(2); }
        }

        public static ApplQueueAction EndSession
        {
            get { return new ApplQueueAction(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AvgPxIndicator : IEquatable<AvgPxIndicator>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "NoAveragePricing"}, {1, "TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid"}, {2, "LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid"},};
        private readonly int? _value;

        private AvgPxIndicator(int value)
        {
            _value = value;
        }

        public bool Equals(AvgPxIndicator other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AvgPxIndicator && Equals((AvgPxIndicator) other);
        }

        public static bool operator ==(AvgPxIndicator left, AvgPxIndicator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AvgPxIndicator left, AvgPxIndicator right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AvgPxIndicator FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AvgPxIndicator", nameof(value));

            return new AvgPxIndicator(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AvgPxIndicator FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AvgPxIndicator(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AvgPxIndicator Invalid
        {
            get { return new AvgPxIndicator(); }
        }

        public static AvgPxIndicator NoAveragePricing
        {
            get { return new AvgPxIndicator(0); }
        }

        public static AvgPxIndicator TradeIsPartOfAnAveragePriceGroupIdentifiedByTheTradelinkid
        {
            get { return new AvgPxIndicator(1); }
        }

        public static AvgPxIndicator LastTradeInTheAveragePriceGroupIdentifiedByTheTradelinkid
        {
            get { return new AvgPxIndicator(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeAllocIndicator : IEquatable<TradeAllocIndicator>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "AllocationNotRequired"}, {1, "AllocationRequired"}, {2, "UseAllocationProvidedWithTheTrade"},};
        private readonly int? _value;

        private TradeAllocIndicator(int value)
        {
            _value = value;
        }

        public bool Equals(TradeAllocIndicator other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeAllocIndicator && Equals((TradeAllocIndicator) other);
        }

        public static bool operator ==(TradeAllocIndicator left, TradeAllocIndicator right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeAllocIndicator left, TradeAllocIndicator right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeAllocIndicator FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeAllocIndicator", nameof(value));

            return new TradeAllocIndicator(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeAllocIndicator FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeAllocIndicator(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeAllocIndicator Invalid
        {
            get { return new TradeAllocIndicator(); }
        }

        public static TradeAllocIndicator AllocationNotRequired
        {
            get { return new TradeAllocIndicator(0); }
        }

        public static TradeAllocIndicator AllocationRequired
        {
            get { return new TradeAllocIndicator(1); }
        }

        public static TradeAllocIndicator UseAllocationProvidedWithTheTrade
        {
            get { return new TradeAllocIndicator(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ExpirationCycle : IEquatable<ExpirationCycle>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "ExpireOnTradingSessionClose"}, {1, "ExpireOnTradingSessionOpen"},};
        private readonly int? _value;

        private ExpirationCycle(int value)
        {
            _value = value;
        }

        public bool Equals(ExpirationCycle other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ExpirationCycle && Equals((ExpirationCycle) other);
        }

        public static bool operator ==(ExpirationCycle left, ExpirationCycle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ExpirationCycle left, ExpirationCycle right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ExpirationCycle FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ExpirationCycle", nameof(value));

            return new ExpirationCycle(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ExpirationCycle FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ExpirationCycle(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ExpirationCycle Invalid
        {
            get { return new ExpirationCycle(); }
        }

        public static ExpirationCycle ExpireOnTradingSessionClose
        {
            get { return new ExpirationCycle(0); }
        }

        public static ExpirationCycle ExpireOnTradingSessionOpen
        {
            get { return new ExpirationCycle(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TrdType : IEquatable<TrdType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "RegularTrade"}, {1, "BlockTrade"}, {2, "Efp"}, {3, "Transfer"}, {4, "LateTrade"}, {5, "TTrade"}, {6, "WeightedAveragePriceTrade"}, {7, "BunchedTrade"}, {8, "LateBunchedTrade"}, {9, "PriorReferencePriceTrade"}, {10, "AfterHoursTrade"},};
        private readonly int? _value;

        private TrdType(int value)
        {
            _value = value;
        }

        public bool Equals(TrdType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TrdType && Equals((TrdType) other);
        }

        public static bool operator ==(TrdType left, TrdType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TrdType left, TrdType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TrdType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TrdType", nameof(value));

            return new TrdType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TrdType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TrdType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TrdType Invalid
        {
            get { return new TrdType(); }
        }

        public static TrdType RegularTrade
        {
            get { return new TrdType(0); }
        }

        public static TrdType BlockTrade
        {
            get { return new TrdType(1); }
        }

        public static TrdType Efp
        {
            get { return new TrdType(2); }
        }

        public static TrdType Transfer
        {
            get { return new TrdType(3); }
        }

        public static TrdType LateTrade
        {
            get { return new TrdType(4); }
        }

        public static TrdType TTrade
        {
            get { return new TrdType(5); }
        }

        public static TrdType WeightedAveragePriceTrade
        {
            get { return new TrdType(6); }
        }

        public static TrdType BunchedTrade
        {
            get { return new TrdType(7); }
        }

        public static TrdType LateBunchedTrade
        {
            get { return new TrdType(8); }
        }

        public static TrdType PriorReferencePriceTrade
        {
            get { return new TrdType(9); }
        }

        public static TrdType AfterHoursTrade
        {
            get { return new TrdType(10); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PegMoveType : IEquatable<PegMoveType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Floating"}, {1, "Fixed"},};
        private readonly int? _value;

        private PegMoveType(int value)
        {
            _value = value;
        }

        public bool Equals(PegMoveType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PegMoveType && Equals((PegMoveType) other);
        }

        public static bool operator ==(PegMoveType left, PegMoveType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PegMoveType left, PegMoveType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PegMoveType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PegMoveType", nameof(value));

            return new PegMoveType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PegMoveType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PegMoveType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PegMoveType Invalid
        {
            get { return new PegMoveType(); }
        }

        public static PegMoveType Floating
        {
            get { return new PegMoveType(0); }
        }

        public static PegMoveType Fixed
        {
            get { return new PegMoveType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PegOffsetType : IEquatable<PegOffsetType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Price"}, {1, "BasisPoints"}, {2, "Ticks"}, {3, "PriceTierLevel"},};
        private readonly int? _value;

        private PegOffsetType(int value)
        {
            _value = value;
        }

        public bool Equals(PegOffsetType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PegOffsetType && Equals((PegOffsetType) other);
        }

        public static bool operator ==(PegOffsetType left, PegOffsetType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PegOffsetType left, PegOffsetType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PegOffsetType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PegOffsetType", nameof(value));

            return new PegOffsetType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PegOffsetType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PegOffsetType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PegOffsetType Invalid
        {
            get { return new PegOffsetType(); }
        }

        public static PegOffsetType Price
        {
            get { return new PegOffsetType(0); }
        }

        public static PegOffsetType BasisPoints
        {
            get { return new PegOffsetType(1); }
        }

        public static PegOffsetType Ticks
        {
            get { return new PegOffsetType(2); }
        }

        public static PegOffsetType PriceTierLevel
        {
            get { return new PegOffsetType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PegLimitType : IEquatable<PegLimitType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "OrBetter"}, {1, "Strict"}, {2, "OrWorse"},};
        private readonly int? _value;

        private PegLimitType(int value)
        {
            _value = value;
        }

        public bool Equals(PegLimitType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PegLimitType && Equals((PegLimitType) other);
        }

        public static bool operator ==(PegLimitType left, PegLimitType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PegLimitType left, PegLimitType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PegLimitType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PegLimitType", nameof(value));

            return new PegLimitType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PegLimitType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PegLimitType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PegLimitType Invalid
        {
            get { return new PegLimitType(); }
        }

        public static PegLimitType OrBetter
        {
            get { return new PegLimitType(0); }
        }

        public static PegLimitType Strict
        {
            get { return new PegLimitType(1); }
        }

        public static PegLimitType OrWorse
        {
            get { return new PegLimitType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PegRoundDirection : IEquatable<PegRoundDirection>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "MoreAggressive"}, {2, "MorePassive"},};
        private readonly int? _value;

        private PegRoundDirection(int value)
        {
            _value = value;
        }

        public bool Equals(PegRoundDirection other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PegRoundDirection && Equals((PegRoundDirection) other);
        }

        public static bool operator ==(PegRoundDirection left, PegRoundDirection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PegRoundDirection left, PegRoundDirection right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PegRoundDirection FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PegRoundDirection", nameof(value));

            return new PegRoundDirection(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PegRoundDirection FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PegRoundDirection(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PegRoundDirection Invalid
        {
            get { return new PegRoundDirection(); }
        }

        public static PegRoundDirection MoreAggressive
        {
            get { return new PegRoundDirection(1); }
        }

        public static PegRoundDirection MorePassive
        {
            get { return new PegRoundDirection(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct PegScope : IEquatable<PegScope>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Local"}, {2, "National"}, {3, "Global"}, {4, "NationalExcludingLocal"},};
        private readonly int? _value;

        private PegScope(int value)
        {
            _value = value;
        }

        public bool Equals(PegScope other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is PegScope && Equals((PegScope) other);
        }

        public static bool operator ==(PegScope left, PegScope right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PegScope left, PegScope right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static PegScope FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for PegScope", nameof(value));

            return new PegScope(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static PegScope FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new PegScope(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static PegScope Invalid
        {
            get { return new PegScope(); }
        }

        public static PegScope Local
        {
            get { return new PegScope(1); }
        }

        public static PegScope National
        {
            get { return new PegScope(2); }
        }

        public static PegScope Global
        {
            get { return new PegScope(3); }
        }

        public static PegScope NationalExcludingLocal
        {
            get { return new PegScope(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DiscretionMoveType : IEquatable<DiscretionMoveType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Floating"}, {1, "Fixed"},};
        private readonly int? _value;

        private DiscretionMoveType(int value)
        {
            _value = value;
        }

        public bool Equals(DiscretionMoveType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DiscretionMoveType && Equals((DiscretionMoveType) other);
        }

        public static bool operator ==(DiscretionMoveType left, DiscretionMoveType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscretionMoveType left, DiscretionMoveType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DiscretionMoveType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionMoveType", nameof(value));

            return new DiscretionMoveType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DiscretionMoveType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DiscretionMoveType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DiscretionMoveType Invalid
        {
            get { return new DiscretionMoveType(); }
        }

        public static DiscretionMoveType Floating
        {
            get { return new DiscretionMoveType(0); }
        }

        public static DiscretionMoveType Fixed
        {
            get { return new DiscretionMoveType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DiscretionOffsetType : IEquatable<DiscretionOffsetType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Price"}, {1, "BasisPoints"}, {2, "Ticks"}, {3, "PriceTierLevel"},};
        private readonly int? _value;

        private DiscretionOffsetType(int value)
        {
            _value = value;
        }

        public bool Equals(DiscretionOffsetType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DiscretionOffsetType && Equals((DiscretionOffsetType) other);
        }

        public static bool operator ==(DiscretionOffsetType left, DiscretionOffsetType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscretionOffsetType left, DiscretionOffsetType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DiscretionOffsetType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionOffsetType", nameof(value));

            return new DiscretionOffsetType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DiscretionOffsetType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DiscretionOffsetType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DiscretionOffsetType Invalid
        {
            get { return new DiscretionOffsetType(); }
        }

        public static DiscretionOffsetType Price
        {
            get { return new DiscretionOffsetType(0); }
        }

        public static DiscretionOffsetType BasisPoints
        {
            get { return new DiscretionOffsetType(1); }
        }

        public static DiscretionOffsetType Ticks
        {
            get { return new DiscretionOffsetType(2); }
        }

        public static DiscretionOffsetType PriceTierLevel
        {
            get { return new DiscretionOffsetType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DiscretionLimitType : IEquatable<DiscretionLimitType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "OrBetter"}, {1, "Strict"}, {2, "OrWorse"},};
        private readonly int? _value;

        private DiscretionLimitType(int value)
        {
            _value = value;
        }

        public bool Equals(DiscretionLimitType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DiscretionLimitType && Equals((DiscretionLimitType) other);
        }

        public static bool operator ==(DiscretionLimitType left, DiscretionLimitType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscretionLimitType left, DiscretionLimitType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DiscretionLimitType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionLimitType", nameof(value));

            return new DiscretionLimitType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DiscretionLimitType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DiscretionLimitType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DiscretionLimitType Invalid
        {
            get { return new DiscretionLimitType(); }
        }

        public static DiscretionLimitType OrBetter
        {
            get { return new DiscretionLimitType(0); }
        }

        public static DiscretionLimitType Strict
        {
            get { return new DiscretionLimitType(1); }
        }

        public static DiscretionLimitType OrWorse
        {
            get { return new DiscretionLimitType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DiscretionRoundDirection : IEquatable<DiscretionRoundDirection>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "MoreAggressive"}, {2, "MorePassive"},};
        private readonly int? _value;

        private DiscretionRoundDirection(int value)
        {
            _value = value;
        }

        public bool Equals(DiscretionRoundDirection other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DiscretionRoundDirection && Equals((DiscretionRoundDirection) other);
        }

        public static bool operator ==(DiscretionRoundDirection left, DiscretionRoundDirection right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscretionRoundDirection left, DiscretionRoundDirection right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DiscretionRoundDirection FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionRoundDirection", nameof(value));

            return new DiscretionRoundDirection(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DiscretionRoundDirection FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DiscretionRoundDirection(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DiscretionRoundDirection Invalid
        {
            get { return new DiscretionRoundDirection(); }
        }

        public static DiscretionRoundDirection MoreAggressive
        {
            get { return new DiscretionRoundDirection(1); }
        }

        public static DiscretionRoundDirection MorePassive
        {
            get { return new DiscretionRoundDirection(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DiscretionScope : IEquatable<DiscretionScope>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Local"}, {2, "National"}, {3, "Global"}, {4, "NationalExcludingLocal"},};
        private readonly int? _value;

        private DiscretionScope(int value)
        {
            _value = value;
        }

        public bool Equals(DiscretionScope other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DiscretionScope && Equals((DiscretionScope) other);
        }

        public static bool operator ==(DiscretionScope left, DiscretionScope right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiscretionScope left, DiscretionScope right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DiscretionScope FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DiscretionScope", nameof(value));

            return new DiscretionScope(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DiscretionScope FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DiscretionScope(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DiscretionScope Invalid
        {
            get { return new DiscretionScope(); }
        }

        public static DiscretionScope Local
        {
            get { return new DiscretionScope(1); }
        }

        public static DiscretionScope National
        {
            get { return new DiscretionScope(2); }
        }

        public static DiscretionScope Global
        {
            get { return new DiscretionScope(3); }
        }

        public static DiscretionScope NationalExcludingLocal
        {
            get { return new DiscretionScope(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct LastLiquidityInd : IEquatable<LastLiquidityInd>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "AddedLiquidity"}, {2, "RemovedLiquidity"}, {3, "LiquidityRoutedOut"},};
        private readonly int? _value;

        private LastLiquidityInd(int value)
        {
            _value = value;
        }

        public bool Equals(LastLiquidityInd other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is LastLiquidityInd && Equals((LastLiquidityInd) other);
        }

        public static bool operator ==(LastLiquidityInd left, LastLiquidityInd right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LastLiquidityInd left, LastLiquidityInd right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static LastLiquidityInd FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for LastLiquidityInd", nameof(value));

            return new LastLiquidityInd(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static LastLiquidityInd FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new LastLiquidityInd(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static LastLiquidityInd Invalid
        {
            get { return new LastLiquidityInd(); }
        }

        public static LastLiquidityInd AddedLiquidity
        {
            get { return new LastLiquidityInd(1); }
        }

        public static LastLiquidityInd RemovedLiquidity
        {
            get { return new LastLiquidityInd(2); }
        }

        public static LastLiquidityInd LiquidityRoutedOut
        {
            get { return new LastLiquidityInd(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct ShortSaleReason : IEquatable<ShortSaleReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "DealerSoldShort"}, {1, "DealerSoldShortExempt"}, {2, "SellingCustomerSoldShort"}, {3, "SellingCustomerSoldShortExempt"}, {4, "QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort"}, {5, "QsrOrAguContraSideSoldShortExempt"},};
        private readonly int? _value;

        private ShortSaleReason(int value)
        {
            _value = value;
        }

        public bool Equals(ShortSaleReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is ShortSaleReason && Equals((ShortSaleReason) other);
        }

        public static bool operator ==(ShortSaleReason left, ShortSaleReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ShortSaleReason left, ShortSaleReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static ShortSaleReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for ShortSaleReason", nameof(value));

            return new ShortSaleReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static ShortSaleReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new ShortSaleReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static ShortSaleReason Invalid
        {
            get { return new ShortSaleReason(); }
        }

        public static ShortSaleReason DealerSoldShort
        {
            get { return new ShortSaleReason(0); }
        }

        public static ShortSaleReason DealerSoldShortExempt
        {
            get { return new ShortSaleReason(1); }
        }

        public static ShortSaleReason SellingCustomerSoldShort
        {
            get { return new ShortSaleReason(2); }
        }

        public static ShortSaleReason SellingCustomerSoldShortExempt
        {
            get { return new ShortSaleReason(3); }
        }

        public static ShortSaleReason QualifedServiceRepresentativeOrAutomaticGiveupContraSideSoldShort
        {
            get { return new ShortSaleReason(4); }
        }

        public static ShortSaleReason QsrOrAguContraSideSoldShortExempt
        {
            get { return new ShortSaleReason(5); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct QtyType : IEquatable<QtyType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Units"}, {1, "Contracts"},};
        private readonly int? _value;

        private QtyType(int value)
        {
            _value = value;
        }

        public bool Equals(QtyType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is QtyType && Equals((QtyType) other);
        }

        public static bool operator ==(QtyType left, QtyType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(QtyType left, QtyType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static QtyType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for QtyType", nameof(value));

            return new QtyType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static QtyType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new QtyType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static QtyType Invalid
        {
            get { return new QtyType(); }
        }

        public static QtyType Units
        {
            get { return new QtyType(0); }
        }

        public static QtyType Contracts
        {
            get { return new QtyType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TradeReportType : IEquatable<TradeReportType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Submit"}, {1, "Alleged"}, {2, "Accept"}, {3, "Decline"}, {4, "Addendum"}, {5, "NoWas"}, {6, "TradeReportCancel"}, {7, "LockedInTradeBreak"},};
        private readonly int? _value;

        private TradeReportType(int value)
        {
            _value = value;
        }

        public bool Equals(TradeReportType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TradeReportType && Equals((TradeReportType) other);
        }

        public static bool operator ==(TradeReportType left, TradeReportType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TradeReportType left, TradeReportType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TradeReportType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TradeReportType", nameof(value));

            return new TradeReportType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TradeReportType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TradeReportType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TradeReportType Invalid
        {
            get { return new TradeReportType(); }
        }

        public static TradeReportType Submit
        {
            get { return new TradeReportType(0); }
        }

        public static TradeReportType Alleged
        {
            get { return new TradeReportType(1); }
        }

        public static TradeReportType Accept
        {
            get { return new TradeReportType(2); }
        }

        public static TradeReportType Decline
        {
            get { return new TradeReportType(3); }
        }

        public static TradeReportType Addendum
        {
            get { return new TradeReportType(4); }
        }

        public static TradeReportType NoWas
        {
            get { return new TradeReportType(5); }
        }

        public static TradeReportType TradeReportCancel
        {
            get { return new TradeReportType(6); }
        }

        public static TradeReportType LockedInTradeBreak
        {
            get { return new TradeReportType(7); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AllocNoOrdersType : IEquatable<AllocNoOrdersType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "NotSpecified"}, {1, "ExplicitListProvided"},};
        private readonly int? _value;

        private AllocNoOrdersType(int value)
        {
            _value = value;
        }

        public bool Equals(AllocNoOrdersType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AllocNoOrdersType && Equals((AllocNoOrdersType) other);
        }

        public static bool operator ==(AllocNoOrdersType left, AllocNoOrdersType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AllocNoOrdersType left, AllocNoOrdersType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AllocNoOrdersType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AllocNoOrdersType", nameof(value));

            return new AllocNoOrdersType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AllocNoOrdersType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AllocNoOrdersType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AllocNoOrdersType Invalid
        {
            get { return new AllocNoOrdersType(); }
        }

        public static AllocNoOrdersType NotSpecified
        {
            get { return new AllocNoOrdersType(0); }
        }

        public static AllocNoOrdersType ExplicitListProvided
        {
            get { return new AllocNoOrdersType(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct EventType : IEquatable<EventType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Put"}, {2, "Call"}, {3, "Tender"}, {4, "SinkingFundCall"}, {99, "Other"},};
        private readonly int? _value;

        private EventType(int value)
        {
            _value = value;
        }

        public bool Equals(EventType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is EventType && Equals((EventType) other);
        }

        public static bool operator ==(EventType left, EventType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EventType left, EventType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static EventType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for EventType", nameof(value));

            return new EventType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static EventType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new EventType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static EventType Invalid
        {
            get { return new EventType(); }
        }

        public static EventType Put
        {
            get { return new EventType(1); }
        }

        public static EventType Call
        {
            get { return new EventType(2); }
        }

        public static EventType Tender
        {
            get { return new EventType(3); }
        }

        public static EventType SinkingFundCall
        {
            get { return new EventType(4); }
        }

        public static EventType Other
        {
            get { return new EventType(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct InstrAttribType : IEquatable<InstrAttribType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Flat"}, {2, "ZeroCoupon"}, {3, "InterestBearing"}, {4, "NoPeriodicPayments"}, {5, "VariableRate"}, {6, "LessFeeForPut"}, {7, "SteppedCoupon"}, {8, "CouponPeriod"}, {9, "WhenAndIfIssued"}, {10, "OriginalIssueDiscount"}, {11, "CallablePuttable"}, {12, "EscrowedToMaturity"}, {13, "EscrowedToRedemptionDate"}, {14, "PreRefunded"}, {15, "InDefault"}, {16, "Unrated"}, {17, "Taxable"}, {18, "Indexed"}, {19, "SubjectToAlternativeMinimumTax"}, {20, "OriginalIssueDiscountPrice"}, {21, "CallableBelowMaturityValue"}, {22, "CallableWithoutNoticeByMailToHolderUnlessRegistered"}, {99, "Text"},};
        private readonly int? _value;

        private InstrAttribType(int value)
        {
            _value = value;
        }

        public bool Equals(InstrAttribType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is InstrAttribType && Equals((InstrAttribType) other);
        }

        public static bool operator ==(InstrAttribType left, InstrAttribType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InstrAttribType left, InstrAttribType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static InstrAttribType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for InstrAttribType", nameof(value));

            return new InstrAttribType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static InstrAttribType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new InstrAttribType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static InstrAttribType Invalid
        {
            get { return new InstrAttribType(); }
        }

        public static InstrAttribType Flat
        {
            get { return new InstrAttribType(1); }
        }

        public static InstrAttribType ZeroCoupon
        {
            get { return new InstrAttribType(2); }
        }

        public static InstrAttribType InterestBearing
        {
            get { return new InstrAttribType(3); }
        }

        public static InstrAttribType NoPeriodicPayments
        {
            get { return new InstrAttribType(4); }
        }

        public static InstrAttribType VariableRate
        {
            get { return new InstrAttribType(5); }
        }

        public static InstrAttribType LessFeeForPut
        {
            get { return new InstrAttribType(6); }
        }

        public static InstrAttribType SteppedCoupon
        {
            get { return new InstrAttribType(7); }
        }

        public static InstrAttribType CouponPeriod
        {
            get { return new InstrAttribType(8); }
        }

        public static InstrAttribType WhenAndIfIssued
        {
            get { return new InstrAttribType(9); }
        }

        public static InstrAttribType OriginalIssueDiscount
        {
            get { return new InstrAttribType(10); }
        }

        public static InstrAttribType CallablePuttable
        {
            get { return new InstrAttribType(11); }
        }

        public static InstrAttribType EscrowedToMaturity
        {
            get { return new InstrAttribType(12); }
        }

        public static InstrAttribType EscrowedToRedemptionDate
        {
            get { return new InstrAttribType(13); }
        }

        public static InstrAttribType PreRefunded
        {
            get { return new InstrAttribType(14); }
        }

        public static InstrAttribType InDefault
        {
            get { return new InstrAttribType(15); }
        }

        public static InstrAttribType Unrated
        {
            get { return new InstrAttribType(16); }
        }

        public static InstrAttribType Taxable
        {
            get { return new InstrAttribType(17); }
        }

        public static InstrAttribType Indexed
        {
            get { return new InstrAttribType(18); }
        }

        public static InstrAttribType SubjectToAlternativeMinimumTax
        {
            get { return new InstrAttribType(19); }
        }

        public static InstrAttribType OriginalIssueDiscountPrice
        {
            get { return new InstrAttribType(20); }
        }

        public static InstrAttribType CallableBelowMaturityValue
        {
            get { return new InstrAttribType(21); }
        }

        public static InstrAttribType CallableWithoutNoticeByMailToHolderUnlessRegistered
        {
            get { return new InstrAttribType(22); }
        }

        public static InstrAttribType Text
        {
            get { return new InstrAttribType(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct MiscFeeBasis : IEquatable<MiscFeeBasis>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Absolute"}, {1, "PerUnit"}, {2, "Percentage"},};
        private readonly int? _value;

        private MiscFeeBasis(int value)
        {
            _value = value;
        }

        public bool Equals(MiscFeeBasis other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is MiscFeeBasis && Equals((MiscFeeBasis) other);
        }

        public static bool operator ==(MiscFeeBasis left, MiscFeeBasis right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MiscFeeBasis left, MiscFeeBasis right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static MiscFeeBasis FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for MiscFeeBasis", nameof(value));

            return new MiscFeeBasis(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static MiscFeeBasis FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new MiscFeeBasis(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static MiscFeeBasis Invalid
        {
            get { return new MiscFeeBasis(); }
        }

        public static MiscFeeBasis Absolute
        {
            get { return new MiscFeeBasis(0); }
        }

        public static MiscFeeBasis PerUnit
        {
            get { return new MiscFeeBasis(1); }
        }

        public static MiscFeeBasis Percentage
        {
            get { return new MiscFeeBasis(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollAsgnReason : IEquatable<CollAsgnReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Initial"}, {1, "Scheduled"}, {2, "TimeWarning"}, {3, "MarginDeficiency"}, {4, "MarginExcess"}, {5, "ForwardCollateralDemand"}, {6, "EventOfDefault"}, {7, "AdverseTaxEvent"},};
        private readonly int? _value;

        private CollAsgnReason(int value)
        {
            _value = value;
        }

        public bool Equals(CollAsgnReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollAsgnReason && Equals((CollAsgnReason) other);
        }

        public static bool operator ==(CollAsgnReason left, CollAsgnReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollAsgnReason left, CollAsgnReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollAsgnReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollAsgnReason", nameof(value));

            return new CollAsgnReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollAsgnReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollAsgnReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollAsgnReason Invalid
        {
            get { return new CollAsgnReason(); }
        }

        public static CollAsgnReason Initial
        {
            get { return new CollAsgnReason(0); }
        }

        public static CollAsgnReason Scheduled
        {
            get { return new CollAsgnReason(1); }
        }

        public static CollAsgnReason TimeWarning
        {
            get { return new CollAsgnReason(2); }
        }

        public static CollAsgnReason MarginDeficiency
        {
            get { return new CollAsgnReason(3); }
        }

        public static CollAsgnReason MarginExcess
        {
            get { return new CollAsgnReason(4); }
        }

        public static CollAsgnReason ForwardCollateralDemand
        {
            get { return new CollAsgnReason(5); }
        }

        public static CollAsgnReason EventOfDefault
        {
            get { return new CollAsgnReason(6); }
        }

        public static CollAsgnReason AdverseTaxEvent
        {
            get { return new CollAsgnReason(7); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollInquiryQualifier : IEquatable<CollInquiryQualifier>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Tradedate"}, {1, "GcInstrument"}, {2, "Collateralinstrument"}, {3, "SubstitutionEligible"}, {4, "NotAssigned"}, {5, "PartiallyAssigned"}, {6, "FullyAssigned"}, {7, "OutstandingTrades"},};
        private readonly int? _value;

        private CollInquiryQualifier(int value)
        {
            _value = value;
        }

        public bool Equals(CollInquiryQualifier other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollInquiryQualifier && Equals((CollInquiryQualifier) other);
        }

        public static bool operator ==(CollInquiryQualifier left, CollInquiryQualifier right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollInquiryQualifier left, CollInquiryQualifier right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollInquiryQualifier FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollInquiryQualifier", nameof(value));

            return new CollInquiryQualifier(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollInquiryQualifier FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollInquiryQualifier(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollInquiryQualifier Invalid
        {
            get { return new CollInquiryQualifier(); }
        }

        public static CollInquiryQualifier Tradedate
        {
            get { return new CollInquiryQualifier(0); }
        }

        public static CollInquiryQualifier GcInstrument
        {
            get { return new CollInquiryQualifier(1); }
        }

        public static CollInquiryQualifier Collateralinstrument
        {
            get { return new CollInquiryQualifier(2); }
        }

        public static CollInquiryQualifier SubstitutionEligible
        {
            get { return new CollInquiryQualifier(3); }
        }

        public static CollInquiryQualifier NotAssigned
        {
            get { return new CollInquiryQualifier(4); }
        }

        public static CollInquiryQualifier PartiallyAssigned
        {
            get { return new CollInquiryQualifier(5); }
        }

        public static CollInquiryQualifier FullyAssigned
        {
            get { return new CollInquiryQualifier(6); }
        }

        public static CollInquiryQualifier OutstandingTrades
        {
            get { return new CollInquiryQualifier(7); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollAsgnTransType : IEquatable<CollAsgnTransType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "New"}, {1, "Replace"}, {2, "Cancel"}, {3, "Release"}, {4, "Reverse"},};
        private readonly int? _value;

        private CollAsgnTransType(int value)
        {
            _value = value;
        }

        public bool Equals(CollAsgnTransType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollAsgnTransType && Equals((CollAsgnTransType) other);
        }

        public static bool operator ==(CollAsgnTransType left, CollAsgnTransType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollAsgnTransType left, CollAsgnTransType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollAsgnTransType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollAsgnTransType", nameof(value));

            return new CollAsgnTransType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollAsgnTransType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollAsgnTransType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollAsgnTransType Invalid
        {
            get { return new CollAsgnTransType(); }
        }

        public static CollAsgnTransType New
        {
            get { return new CollAsgnTransType(0); }
        }

        public static CollAsgnTransType Replace
        {
            get { return new CollAsgnTransType(1); }
        }

        public static CollAsgnTransType Cancel
        {
            get { return new CollAsgnTransType(2); }
        }

        public static CollAsgnTransType Release
        {
            get { return new CollAsgnTransType(3); }
        }

        public static CollAsgnTransType Reverse
        {
            get { return new CollAsgnTransType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollAsgnRespType : IEquatable<CollAsgnRespType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Received"}, {1, "Accepted"}, {2, "Declined"}, {3, "Rejected"},};
        private readonly int? _value;

        private CollAsgnRespType(int value)
        {
            _value = value;
        }

        public bool Equals(CollAsgnRespType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollAsgnRespType && Equals((CollAsgnRespType) other);
        }

        public static bool operator ==(CollAsgnRespType left, CollAsgnRespType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollAsgnRespType left, CollAsgnRespType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollAsgnRespType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollAsgnRespType", nameof(value));

            return new CollAsgnRespType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollAsgnRespType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollAsgnRespType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollAsgnRespType Invalid
        {
            get { return new CollAsgnRespType(); }
        }

        public static CollAsgnRespType Received
        {
            get { return new CollAsgnRespType(0); }
        }

        public static CollAsgnRespType Accepted
        {
            get { return new CollAsgnRespType(1); }
        }

        public static CollAsgnRespType Declined
        {
            get { return new CollAsgnRespType(2); }
        }

        public static CollAsgnRespType Rejected
        {
            get { return new CollAsgnRespType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollAsgnRejectReason : IEquatable<CollAsgnRejectReason>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "UnknownDeal"}, {1, "UnknownOrInvalidInstrument"}, {2, "UnauthorizedTransaction"}, {3, "InsufficientCollateral"}, {4, "InvalidTypeOfCollateral"}, {5, "ExcessiveSubstitution"}, {99, "Other"},};
        private readonly int? _value;

        private CollAsgnRejectReason(int value)
        {
            _value = value;
        }

        public bool Equals(CollAsgnRejectReason other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollAsgnRejectReason && Equals((CollAsgnRejectReason) other);
        }

        public static bool operator ==(CollAsgnRejectReason left, CollAsgnRejectReason right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollAsgnRejectReason left, CollAsgnRejectReason right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollAsgnRejectReason FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollAsgnRejectReason", nameof(value));

            return new CollAsgnRejectReason(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollAsgnRejectReason FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollAsgnRejectReason(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollAsgnRejectReason Invalid
        {
            get { return new CollAsgnRejectReason(); }
        }

        public static CollAsgnRejectReason UnknownDeal
        {
            get { return new CollAsgnRejectReason(0); }
        }

        public static CollAsgnRejectReason UnknownOrInvalidInstrument
        {
            get { return new CollAsgnRejectReason(1); }
        }

        public static CollAsgnRejectReason UnauthorizedTransaction
        {
            get { return new CollAsgnRejectReason(2); }
        }

        public static CollAsgnRejectReason InsufficientCollateral
        {
            get { return new CollAsgnRejectReason(3); }
        }

        public static CollAsgnRejectReason InvalidTypeOfCollateral
        {
            get { return new CollAsgnRejectReason(4); }
        }

        public static CollAsgnRejectReason ExcessiveSubstitution
        {
            get { return new CollAsgnRejectReason(5); }
        }

        public static CollAsgnRejectReason Other
        {
            get { return new CollAsgnRejectReason(99); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollStatus : IEquatable<CollStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Unassigned"}, {1, "PartiallyAssigned"}, {2, "AssignmentProposed"}, {3, "Assigned"}, {4, "Challenged"},};
        private readonly int? _value;

        private CollStatus(int value)
        {
            _value = value;
        }

        public bool Equals(CollStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollStatus && Equals((CollStatus) other);
        }

        public static bool operator ==(CollStatus left, CollStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollStatus left, CollStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollStatus", nameof(value));

            return new CollStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollStatus Invalid
        {
            get { return new CollStatus(); }
        }

        public static CollStatus Unassigned
        {
            get { return new CollStatus(0); }
        }

        public static CollStatus PartiallyAssigned
        {
            get { return new CollStatus(1); }
        }

        public static CollStatus AssignmentProposed
        {
            get { return new CollStatus(2); }
        }

        public static CollStatus Assigned
        {
            get { return new CollStatus(3); }
        }

        public static CollStatus Challenged
        {
            get { return new CollStatus(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct DeliveryType : IEquatable<DeliveryType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "VersusPayment"}, {1, "Free"}, {2, "TriParty"}, {3, "HoldInCustody"},};
        private readonly int? _value;

        private DeliveryType(int value)
        {
            _value = value;
        }

        public bool Equals(DeliveryType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is DeliveryType && Equals((DeliveryType) other);
        }

        public static bool operator ==(DeliveryType left, DeliveryType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DeliveryType left, DeliveryType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static DeliveryType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for DeliveryType", nameof(value));

            return new DeliveryType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static DeliveryType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new DeliveryType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static DeliveryType Invalid
        {
            get { return new DeliveryType(); }
        }

        public static DeliveryType VersusPayment
        {
            get { return new DeliveryType(0); }
        }

        public static DeliveryType Free
        {
            get { return new DeliveryType(1); }
        }

        public static DeliveryType TriParty
        {
            get { return new DeliveryType(2); }
        }

        public static DeliveryType HoldInCustody
        {
            get { return new DeliveryType(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct UserRequestType : IEquatable<UserRequestType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Logonuser"}, {2, "Logoffuser"}, {3, "Changepasswordforuser"}, {4, "RequestIndividualUserStatus"},};
        private readonly int? _value;

        private UserRequestType(int value)
        {
            _value = value;
        }

        public bool Equals(UserRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is UserRequestType && Equals((UserRequestType) other);
        }

        public static bool operator ==(UserRequestType left, UserRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UserRequestType left, UserRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static UserRequestType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for UserRequestType", nameof(value));

            return new UserRequestType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static UserRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new UserRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static UserRequestType Invalid
        {
            get { return new UserRequestType(); }
        }

        public static UserRequestType Logonuser
        {
            get { return new UserRequestType(1); }
        }

        public static UserRequestType Logoffuser
        {
            get { return new UserRequestType(2); }
        }

        public static UserRequestType Changepasswordforuser
        {
            get { return new UserRequestType(3); }
        }

        public static UserRequestType RequestIndividualUserStatus
        {
            get { return new UserRequestType(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct UserStatus : IEquatable<UserStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "LoggedIn"}, {2, "NotLoggedIn"}, {3, "UserNotRecognised"}, {4, "PasswordIncorrect"}, {5, "PasswordChanged"}, {6, "Other"},};
        private readonly int? _value;

        private UserStatus(int value)
        {
            _value = value;
        }

        public bool Equals(UserStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is UserStatus && Equals((UserStatus) other);
        }

        public static bool operator ==(UserStatus left, UserStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UserStatus left, UserStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static UserStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for UserStatus", nameof(value));

            return new UserStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static UserStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new UserStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static UserStatus Invalid
        {
            get { return new UserStatus(); }
        }

        public static UserStatus LoggedIn
        {
            get { return new UserStatus(1); }
        }

        public static UserStatus NotLoggedIn
        {
            get { return new UserStatus(2); }
        }

        public static UserStatus UserNotRecognised
        {
            get { return new UserStatus(3); }
        }

        public static UserStatus PasswordIncorrect
        {
            get { return new UserStatus(4); }
        }

        public static UserStatus PasswordChanged
        {
            get { return new UserStatus(5); }
        }

        public static UserStatus Other
        {
            get { return new UserStatus(6); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct StatusValue : IEquatable<StatusValue>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Connected"}, {2, "NotConnectedDownExpectedUp"}, {3, "NotConnectedDownExpectedDown"}, {4, "InProcess"},};
        private readonly int? _value;

        private StatusValue(int value)
        {
            _value = value;
        }

        public bool Equals(StatusValue other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is StatusValue && Equals((StatusValue) other);
        }

        public static bool operator ==(StatusValue left, StatusValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StatusValue left, StatusValue right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static StatusValue FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for StatusValue", nameof(value));

            return new StatusValue(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static StatusValue FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new StatusValue(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static StatusValue Invalid
        {
            get { return new StatusValue(); }
        }

        public static StatusValue Connected
        {
            get { return new StatusValue(1); }
        }

        public static StatusValue NotConnectedDownExpectedUp
        {
            get { return new StatusValue(2); }
        }

        public static StatusValue NotConnectedDownExpectedDown
        {
            get { return new StatusValue(3); }
        }

        public static StatusValue InProcess
        {
            get { return new StatusValue(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct NetworkRequestType : IEquatable<NetworkRequestType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Snapshot"}, {2, "Subscribe"}, {4, "StopSubscribing"}, {8, "LevelOfDetail"},};
        private readonly int? _value;

        private NetworkRequestType(int value)
        {
            _value = value;
        }

        public bool Equals(NetworkRequestType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is NetworkRequestType && Equals((NetworkRequestType) other);
        }

        public static bool operator ==(NetworkRequestType left, NetworkRequestType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NetworkRequestType left, NetworkRequestType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static NetworkRequestType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for NetworkRequestType", nameof(value));

            return new NetworkRequestType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static NetworkRequestType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new NetworkRequestType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static NetworkRequestType Invalid
        {
            get { return new NetworkRequestType(); }
        }

        public static NetworkRequestType Snapshot
        {
            get { return new NetworkRequestType(1); }
        }

        public static NetworkRequestType Subscribe
        {
            get { return new NetworkRequestType(2); }
        }

        public static NetworkRequestType StopSubscribing
        {
            get { return new NetworkRequestType(4); }
        }

        public static NetworkRequestType LevelOfDetail
        {
            get { return new NetworkRequestType(8); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct NetworkStatusResponseType : IEquatable<NetworkStatusResponseType>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Full"}, {2, "IncrementalUpdate"},};
        private readonly int? _value;

        private NetworkStatusResponseType(int value)
        {
            _value = value;
        }

        public bool Equals(NetworkStatusResponseType other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is NetworkStatusResponseType && Equals((NetworkStatusResponseType) other);
        }

        public static bool operator ==(NetworkStatusResponseType left, NetworkStatusResponseType right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NetworkStatusResponseType left, NetworkStatusResponseType right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static NetworkStatusResponseType FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for NetworkStatusResponseType", nameof(value));

            return new NetworkStatusResponseType(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static NetworkStatusResponseType FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new NetworkStatusResponseType(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static NetworkStatusResponseType Invalid
        {
            get { return new NetworkStatusResponseType(); }
        }

        public static NetworkStatusResponseType Full
        {
            get { return new NetworkStatusResponseType(1); }
        }

        public static NetworkStatusResponseType IncrementalUpdate
        {
            get { return new NetworkStatusResponseType(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct TrdRptStatus : IEquatable<TrdRptStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Accepted"}, {1, "Rejected"},};
        private readonly int? _value;

        private TrdRptStatus(int value)
        {
            _value = value;
        }

        public bool Equals(TrdRptStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is TrdRptStatus && Equals((TrdRptStatus) other);
        }

        public static bool operator ==(TrdRptStatus left, TrdRptStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TrdRptStatus left, TrdRptStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static TrdRptStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for TrdRptStatus", nameof(value));

            return new TrdRptStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static TrdRptStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new TrdRptStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static TrdRptStatus Invalid
        {
            get { return new TrdRptStatus(); }
        }

        public static TrdRptStatus Accepted
        {
            get { return new TrdRptStatus(0); }
        }

        public static TrdRptStatus Rejected
        {
            get { return new TrdRptStatus(1); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct AffirmStatus : IEquatable<AffirmStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{1, "Received"}, {2, "ConfirmRejected"}, {3, "Affirmed"},};
        private readonly int? _value;

        private AffirmStatus(int value)
        {
            _value = value;
        }

        public bool Equals(AffirmStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is AffirmStatus && Equals((AffirmStatus) other);
        }

        public static bool operator ==(AffirmStatus left, AffirmStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AffirmStatus left, AffirmStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static AffirmStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for AffirmStatus", nameof(value));

            return new AffirmStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static AffirmStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new AffirmStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static AffirmStatus Invalid
        {
            get { return new AffirmStatus(); }
        }

        public static AffirmStatus Received
        {
            get { return new AffirmStatus(1); }
        }

        public static AffirmStatus ConfirmRejected
        {
            get { return new AffirmStatus(2); }
        }

        public static AffirmStatus Affirmed
        {
            get { return new AffirmStatus(3); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollAction : IEquatable<CollAction>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Retain"}, {1, "Add"}, {2, "Remove"},};
        private readonly int? _value;

        private CollAction(int value)
        {
            _value = value;
        }

        public bool Equals(CollAction other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollAction && Equals((CollAction) other);
        }

        public static bool operator ==(CollAction left, CollAction right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollAction left, CollAction right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollAction FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollAction", nameof(value));

            return new CollAction(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollAction FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollAction(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollAction Invalid
        {
            get { return new CollAction(); }
        }

        public static CollAction Retain
        {
            get { return new CollAction(0); }
        }

        public static CollAction Add
        {
            get { return new CollAction(1); }
        }

        public static CollAction Remove
        {
            get { return new CollAction(2); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollInquiryStatus : IEquatable<CollInquiryStatus>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Accepted"}, {1, "AcceptedWithWarnings"}, {2, "Completed"}, {3, "CompletedWithWarnings"}, {4, "Rejected"},};
        private readonly int? _value;

        private CollInquiryStatus(int value)
        {
            _value = value;
        }

        public bool Equals(CollInquiryStatus other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollInquiryStatus && Equals((CollInquiryStatus) other);
        }

        public static bool operator ==(CollInquiryStatus left, CollInquiryStatus right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollInquiryStatus left, CollInquiryStatus right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollInquiryStatus FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollInquiryStatus", nameof(value));

            return new CollInquiryStatus(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollInquiryStatus FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollInquiryStatus(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollInquiryStatus Invalid
        {
            get { return new CollInquiryStatus(); }
        }

        public static CollInquiryStatus Accepted
        {
            get { return new CollInquiryStatus(0); }
        }

        public static CollInquiryStatus AcceptedWithWarnings
        {
            get { return new CollInquiryStatus(1); }
        }

        public static CollInquiryStatus Completed
        {
            get { return new CollInquiryStatus(2); }
        }

        public static CollInquiryStatus CompletedWithWarnings
        {
            get { return new CollInquiryStatus(3); }
        }

        public static CollInquiryStatus Rejected
        {
            get { return new CollInquiryStatus(4); }
        }
    }

    [DebuggerDisplay("{ToEnumName()}")]
    public struct CollInquiryResult : IEquatable<CollInquiryResult>
    {
        private static IDictionary<int, string> _possibleValues = new Dictionary<int, string> {{0, "Successful"}, {1, "InvalidOrUnknownInstrument"}, {2, "InvalidOrUnknownCollateralType"}, {3, "InvalidParties"}, {4, "InvalidTransportTypeRequested"}, {5, "InvalidDestinationRequested"}, {6, "NoCollateralFoundForTheTradeSpecified"}, {7, "NoCollateralFoundForTheOrderSpecified"}, {8, "CollateralInquiryTypeNotSupported"}, {9, "UnauthorizedForCollateralInquiry"}, {99, "Other"},};
        private readonly int? _value;

        private CollInquiryResult(int value)
        {
            _value = value;
        }

        public bool Equals(CollInquiryResult other)
        {
            return _value == other._value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;

            return other is CollInquiryResult && Equals((CollInquiryResult) other);
        }

        public static bool operator ==(CollInquiryResult left, CollInquiryResult right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CollInquiryResult left, CollInquiryResult right)
        {
            return !left.Equals(right);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static CollInquiryResult FromValue(int value)
        {
            if (_possibleValues.ContainsKey(value) == false)
                throw new ArgumentException("Value [" + value + "] is not supported for CollInquiryResult", nameof(value));

            return new CollInquiryResult(value);
        }

        public string ToEnumName()
        {
            string name;
            return _possibleValues.TryGetValue(_value.Value, out name) ? name : null;
        }

        public static CollInquiryResult FromEnumName(string name)
        {
            foreach (var possibleValue in _possibleValues)
            {
                if (possibleValue.Value == name)
                    return new CollInquiryResult(possibleValue.Key);
            }

            return Invalid;
        }

        public bool IsValid()
        {
            return !Equals(Invalid);
        }

        public static CollInquiryResult Invalid
        {
            get { return new CollInquiryResult(); }
        }

        public static CollInquiryResult Successful
        {
            get { return new CollInquiryResult(0); }
        }

        public static CollInquiryResult InvalidOrUnknownInstrument
        {
            get { return new CollInquiryResult(1); }
        }

        public static CollInquiryResult InvalidOrUnknownCollateralType
        {
            get { return new CollInquiryResult(2); }
        }

        public static CollInquiryResult InvalidParties
        {
            get { return new CollInquiryResult(3); }
        }

        public static CollInquiryResult InvalidTransportTypeRequested
        {
            get { return new CollInquiryResult(4); }
        }

        public static CollInquiryResult InvalidDestinationRequested
        {
            get { return new CollInquiryResult(5); }
        }

        public static CollInquiryResult NoCollateralFoundForTheTradeSpecified
        {
            get { return new CollInquiryResult(6); }
        }

        public static CollInquiryResult NoCollateralFoundForTheOrderSpecified
        {
            get { return new CollInquiryResult(7); }
        }

        public static CollInquiryResult CollateralInquiryTypeNotSupported
        {
            get { return new CollInquiryResult(8); }
        }

        public static CollInquiryResult UnauthorizedForCollateralInquiry
        {
            get { return new CollInquiryResult(9); }
        }

        public static CollInquiryResult Other
        {
            get { return new CollInquiryResult(99); }
        }
    }
}
