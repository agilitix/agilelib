using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AxFixModel.Order
{
    public class OrderResponse
    {
        public int OrderId
        {
            get; private set;
        }

        public string ErrorMessage
        {
            get; private set;
        }

        public OrderResponseErrorCode ErrorCode
        {
            get; private set;
        }

        public bool IsSuccess
        {
            get { return IsProcessed && !IsError; }
        }

        public bool IsError
        {
            get { return IsProcessed && ErrorCode != OrderResponseErrorCode.None; }
        }

        public bool IsProcessed
        {
            get { return this != Unprocessed; }
        }
    }
}
