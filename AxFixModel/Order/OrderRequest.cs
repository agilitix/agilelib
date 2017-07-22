using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NodaTime;

namespace AxFixModel.Order
{
    public abstract class OrderRequest
    {
        public abstract OrderRequestType OrderRequestType
        {
            get;
        }

        public OrderRequestStatus Status
        {
            get; private set;
        }

        public DateTime Time
        {
            get; private set;
        }

        public int OrderId
        {
            get; protected set;
        }

        public OrderResponse Response
        {
            get; private set;
        }
    }
}
