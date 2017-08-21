﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickFix;

namespace AxFixEngine.Extensions
{
    public static class SessionIDExtensions
    {
        public static SessionID GetReverseSessionID(this SessionID self)
        {
            Message msg = new Message();
            msg.SetSessionID(self);
            return Message.GetReverseSessionID(msg);
        }
    }
}
