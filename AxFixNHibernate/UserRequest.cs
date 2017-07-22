using QuickFix;
using AxFixNHibernate.Fields;
namespace AxFixNHibernate
{
    public class UserRequest : Message
    {
        public const string MsgType = "BE";

        public UserRequest():base()
        {
            this.Header.SetField(new QuickFix.Fields.MsgType(MsgType));
        }
        public UserRequest(AxFixNHibernate.Fields.UserRequestID aUserRequestID,
				AxFixNHibernate.Fields.UserRequestType aUserRequestType,
				AxFixNHibernate.Fields.Username aUsername)
               : this()
        {
            this.UserRequestID = aUserRequestID;
			this.UserRequestType = aUserRequestType;
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

        public AxFixNHibernate.Fields.UserRequestType UserRequestType
        {
            get
            {
                var val = new AxFixNHibernate.Fields.UserRequestType();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.UserRequestType val) { this.UserRequestType = val; }

        public AxFixNHibernate.Fields.UserRequestType Get(AxFixNHibernate.Fields.UserRequestType val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.UserRequestType val) { return IsSetUserRequestType(); }

        public bool IsSetUserRequestType() { return IsSetField(Tags.UserRequestType); }

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

        public AxFixNHibernate.Fields.Password Password
        {
            get
            {
                var val = new AxFixNHibernate.Fields.Password();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.Password val) { this.Password = val; }

        public AxFixNHibernate.Fields.Password Get(AxFixNHibernate.Fields.Password val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.Password val) { return IsSetPassword(); }

        public bool IsSetPassword() { return IsSetField(Tags.Password); }

        public AxFixNHibernate.Fields.NewPassword NewPassword
        {
            get
            {
                var val = new AxFixNHibernate.Fields.NewPassword();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.NewPassword val) { this.NewPassword = val; }

        public AxFixNHibernate.Fields.NewPassword Get(AxFixNHibernate.Fields.NewPassword val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.NewPassword val) { return IsSetNewPassword(); }

        public bool IsSetNewPassword() { return IsSetField(Tags.NewPassword); }

        public AxFixNHibernate.Fields.RawDataLength RawDataLength
        {
            get
            {
                var val = new AxFixNHibernate.Fields.RawDataLength();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.RawDataLength val) { this.RawDataLength = val; }

        public AxFixNHibernate.Fields.RawDataLength Get(AxFixNHibernate.Fields.RawDataLength val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.RawDataLength val) { return IsSetRawDataLength(); }

        public bool IsSetRawDataLength() { return IsSetField(Tags.RawDataLength); }

        public AxFixNHibernate.Fields.RawData RawData
        {
            get
            {
                var val = new AxFixNHibernate.Fields.RawData();
                GetField(val);
                return val;
            }
            set { SetField(value); }
        }

        public void Set(AxFixNHibernate.Fields.RawData val) { this.RawData = val; }

        public AxFixNHibernate.Fields.RawData Get(AxFixNHibernate.Fields.RawData val)
        {
            GetField(val);
            return val;
        }

        public bool IsSet(AxFixNHibernate.Fields.RawData val) { return IsSetRawData(); }

        public bool IsSetRawData() { return IsSetField(Tags.RawData); }


    }
}
