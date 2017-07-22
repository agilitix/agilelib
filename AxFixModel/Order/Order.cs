using NodaTime;

namespace AxFixModel.Order
{
    public enum OrderSide
    {
        [FixEnum(Field.)]
        BUY,

        [FixEnum("2")]
        SELL
    }

    public enum HandlInst
    {
        Undefined = -1,
        AutomatedExecutionNoIntervention = (int) '1',
        AutomatedExecutionInterventionOK = (int) '2',
        ManualOrder = (int) '3',
    }

    public enum BusinessRejectReason
    {
        Undefined = -1,
        Other = (int) '0',
        UnknownID = (int) '1',
        UnknownSecurity = (int) '2',
        UnsupportedMessageType = (int) '3',
        ApplicationNotAvailable = (int) '4',
        ConditionallyRequiredFieldMissing = (int) '5',
    }

    public enum OrdStatus
    {
        Undefined = -1,
        New = (int) '0',
        PartiallyFilled = (int) '1',
        Filled = (int) '2',
        DoneForDay = (int) '3',
        Canceled = (int) '4',
        Replaced = (int) '5',
        PendingCancel = (int) '6',
        Stopped = (int) '7',
        Rejected = (int) '8',
        Suspended = (int) '9',
        PendingNew = (int) 'A',
        Calculated = (int) 'B',
        Expired = (int) 'C',
        AcceptedForBidding = (int) 'D',
        PendingReplace = (int) 'E',
    }

    public enum OrderType
    {
        Undefined = -1,
        Market,
        Limit,
        MarketOnOpen,
        MarketOnClose,
        LimitOnOpen,
        LimitOnClose,
    }

    public enum OrderDuration
    {
        Undefined = -1,
        Day = (int) '0',
        GoodTillCancel = (int) '1',
        AtTheOpening = (int) '2',
        ImmediateOrCancel = (int) '3',
        FillOrKill = (int) '4',
        GoodTillCrossing = (int) '5',
        GoodTillDate = (int) '6',
    }

    public enum PriceType
    {
        Undefined = -1,
        Percentage = (int) '1',
        PerUnit = (int) '2',
        FixedAmount = (int) '3',
    }

    public enum ExecTransType
    {
        Undefined = -1,
        New = (int) '0',
        Cancel = (int) '1',
        Correct = (int) '2',
        Status = (int) '3',
    }

    public enum ExecType
    {
        Undefined = -1,
        New = (int) '0',
        PartialFill = (int) '1',
        Fill = (int) '2',
        DoneForDay = (int) '3',
        Canceled = (int) '4',
        Replaced = (int) '5',
        PendingCancel = (int) '6',
        Stopped = (int) '7',
        Rejected = (int) '8',
        Suspended = (int) '9',
        PendingNew = (int) 'A',
        Calculated = (int) 'B',
        Expired = (int) 'C',
        Restated = (int) 'D',
        PendingReplace = (int) 'E',
    }

    public class Order
    {
        public int Id { get; internal set; }
        public Symbol Symbol { get; internal set; }
        public decimal Price { get; internal set; }
        public ZonedDateTime Time { get; internal set; }
        public int Quantity { get; internal set; }
        public OrderType Type { get; }
        public OrderStatus Status { get; internal set; }
        public OrderDuration Duration { get; internal set; }
        public OrderSide Side { get; internal set; }
        public decimal FilledQuantity { get; internal set; }
        public decimal AveragePrice { get; internal set; }

        public Order()
        {
        }
    }
}
