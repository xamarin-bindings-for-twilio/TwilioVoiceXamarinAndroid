using System;
using System.Collections.Generic;
using Java.Interop;
using TwilioVoice;

namespace Sample
{
    public class CallListener : Java.Lang.Object, Call.IListener
    {
        #region Fields

        private static CallListener _instance;

        #endregion

        #region Properties

        public static CallListener Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CallListener();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        public void OnCallQualityWarningsChanged(Call call, ICollection<Call.CallQualityWarning> currentWarnings, ICollection<Call.CallQualityWarning> previousWarnings)
        {
            Console.WriteLine("OnCallQualityWarningsChanged");
        }

        public void OnConnectFailure(Call p0, CallException p1)
        {
            Console.WriteLine("OnConnectFailure");
        }

        public void OnConnected(Call p0)
        {
            Console.WriteLine("OnConnected");
        }

        public void OnDisconnected(Call p0, CallException p1)
        {
            Console.WriteLine("OnDisconnected");
        }

        public void OnReconnected(Call p0)
        {
            Console.WriteLine("OnReconnected");
        }

        public void OnReconnecting(Call p0, CallException p1)
        {
            Console.WriteLine("OnReconnecting");
        }

        public void OnRinging(Call p0)
        {
            Console.WriteLine("OnRinging");
        }

        #endregion
    }
}
