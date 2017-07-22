using QuickFix;
using AxFixNHibernate.Fields;
namespace AxFixNHibernate
{
    public class UserResponse : Message
    {
        public const string MsgType = "BF";

        public UserResponse():base()
        {
            this.Header.SetField(new QuickFix.Fields.MsgType(MsgType));
        }
        public UserResponse(AxFixNHibernate.Fields.UserRequestID aUserRequestID,
				AxFixNHibernate.Fields.Username aUsername)
               : this()
        {
            this.UserRequestID = aUserRequestID;
			this.Username = aUsername;
        }

        public AxFixNHibernate.Fields.UserRequestID UserRequestID
        {
            get
            {
                var val = new AxFixNHibernate.Fields.UserRequestID();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.UserRequestID val) { this.UserRequestID = val; }

        public AxFixNHibernate.Fields.UserRequestID Get(AxFixNHibernate.Fields.UserRequestID val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.UserRequestID val) { return IsSetUserRequestID(); }

        public bool IsSetUserRequestID() { return IsSetField(Tags.UserRequestID); }

        public AxFixNHibernate.Fields.Username Username
        {
            get
            {
                var val = new AxFixNHibernate.Fields.Username();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.Username val) { this.Username = val; }

        public AxFixNHibernate.Fields.Username Get(AxFixNHibernate.Fields.Username val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.Username val) { return IsSetUsername(); }

        public bool IsSetUsername() { return IsSetField(Tags.Username); }

        public AxFixNHibernate.Fields.UserStatus UserStatus
        {
            get
            {
                var val = new AxFixNHibernate.Fields.UserStatus();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.UserStatus val) { this.UserStatus = val; }

        public AxFixNHibernate.Fields.UserStatus Get(AxFixNHibernate.Fields.UserStatus val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.UserStatus val) { return IsSetUserStatus(); }

        public bool IsSetUserStatus() { return IsSetField(Tags.UserStatus); }

        public AxFixNHibernate.Fields.UserStatusText UserStatusText
        {
            get
            {
                var val = new AxFixNHibernate.Fields.UserStatusText();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.UserStatusText val) { this.UserStatusText = val; }

        public AxFixNHibernate.Fields.UserStatusText Get(AxFixNHibernate.Fields.UserStatusText val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.UserStatusText val) { return IsSetUserStatusText(); }

        public bool IsSetUserStatusText() { return IsSetField(Tags.UserStatusText); }


    }
}
