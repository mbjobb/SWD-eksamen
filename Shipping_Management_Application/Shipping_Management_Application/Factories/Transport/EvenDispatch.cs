using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace EventDispatcher{
	public delegate void Eventhandler(object? sender, EventArgs? arguments);
    
	public class DispatchTerminal{

        public event EventHandler? TruckReceivedHandler;
        private Timer _truckSendTimer;
		private Random _randomGenerator;

		// Constructor.
        
        // Ready, in transit, delivered, returning
        public DispatchTerminal(){
            _randomGenerator = new Random();
            _truckSendTimer = new Timer();

            _truckSendTimer.Elapsed += SendMessageByEvent;
            SetupNextMessage();
            
        }
		protected virtual void InvokeSubscribersCallbackMethods() {
			TruckReceivedHandler?.Invoke(this, EventArgs.Empty);
		}
		private void SendMessageByEvent(object? sender, ElapsedEventArgs? arguments) {
			InvokeSubscribersCallbackMethods();
			SetupNextMessage();
		}
        
		private void SetupNextMessage() {
			_truckSendTimer.Interval = _randomGenerator.Next(1000, 5000);
			_truckSendTimer.Start();
		}
	}
}
