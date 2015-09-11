﻿namespace System
{
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable, ComVisible(true)]
    public class ArgumentException : SystemException, ISerializable
    {
        private string m_paramName;

        public ArgumentException() : base(Environment.GetResourceString("Arg_ArgumentException"))
        {
            base.SetErrorCode(-2147024809);
        }

        public ArgumentException(string message) : base(message)
        {
            base.SetErrorCode(-2147024809);
        }

        protected ArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.m_paramName = info.GetString("ParamName");
        }

        public ArgumentException(string message, Exception innerException) : base(message, innerException)
        {
            base.SetErrorCode(-2147024809);
        }

        public ArgumentException(string message, string paramName) : base(message)
        {
            this.m_paramName = paramName;
            base.SetErrorCode(-2147024809);
        }

        public ArgumentException(string message, string paramName, Exception innerException) : base(message, innerException)
        {
            this.m_paramName = paramName;
            base.SetErrorCode(-2147024809);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            base.GetObjectData(info, context);
            info.AddValue("ParamName", this.m_paramName, typeof(string));
        }

        public override string Message
        {
            get
            {
                string message = base.Message;
                if ((this.m_paramName != null) && (this.m_paramName.Length != 0))
                {
                    return (message + Environment.NewLine + string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Arg_ParamName_Name"), new object[] { this.m_paramName }));
                }
                return message;
            }
        }

        public virtual string ParamName
        {
            get
            {
                return this.m_paramName;
            }
        }
    }
}

