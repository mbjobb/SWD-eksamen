using System.Timers;
using Timer = System.Timers.Timer;

namespace Shipping_Management_Application.Factories.Transport
{
    public delegate void Eventhandler(object? sender, EventArgs? arguments);

    public class DispatchTerminal
    {

        public event EventHandler? TransportReceivedHandler;
        private readonly Timer _transportSendTimer;
        private readonly Random _randomGenerator;

        public DispatchTerminal()
        {
            _randomGenerator = new Random();
            _transportSendTimer = new Timer();

            _transportSendTimer.Elapsed += SendMessageByEvent;
            SetupNextMessage();
        }
        protected virtual void InvokeSubscribersCallbackMethods()
        {
            TransportReceivedHandler?.Invoke(this, EventArgs.Empty);
        }
        private void SendMessageByEvent(object? sender, ElapsedEventArgs? arguments)
        {
            InvokeSubscribersCallbackMethods();
            SetupNextMessage();
        }

        private void SetupNextMessage()
        {
            _transportSendTimer.Interval = _randomGenerator.Next(1000, 5000);
            _transportSendTimer.Start();
        }
    }
}
