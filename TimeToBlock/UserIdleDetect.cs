using System;
using System.Runtime.InteropServices;
using System.Timers;

namespace TimeToBlock
{
    public sealed class UserIdleDetect
    {
        [DllImport("user32.dll")]
        private static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);
        private struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public Int32 dwTime;
        }

        // fields
        private Timer _timer;
        private bool _inIdle;
        private int _idleIndicator = 10000; // 10 seconds

        //events
        public event EventHandler UserIdleDetected;
        public event EventHandler UserIdleInterrupted;

        // constructor
        private UserIdleDetect()
        {
            this._timer = new Timer(50);
            this._timer.Elapsed += this.timer_Elapsed;
            this._timer.Enabled = true;
        }

        // public
        public UserIdleDetect SetIdleIndicator(int idleIndicatorSeconds)
        {
            this._idleIndicator = idleIndicatorSeconds;
            return this;
        }
        public static UserIdleDetect StartDetection(int secondsForIdleIndication)
        {
            var idleDetect = new UserIdleDetect();
            idleDetect.SetIdleIndicator(secondsForIdleIndication);

            return idleDetect;
        }
        public void StopDetection()
        {
            if (this._timer == null)
            {
                throw new InvalidOperationException("Idle detection is not started.");
            }

            this._timer.Enabled = false;
            this._timer.Elapsed -= this.timer_Elapsed;
            this._timer.Dispose();
            this._timer = null;
        }


        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            tagLASTINPUTINFO lastInput = new tagLASTINPUTINFO();
            lastInput.cbSize = (uint)Marshal.SizeOf(lastInput);
            lastInput.dwTime = 0;

            if (GetLastInputInfo(ref lastInput))
            {
                int idleTime = Environment.TickCount - lastInput.dwTime;

                if (idleTime > 50)
                {
                    if (idleTime > this._idleIndicator)
                    {
                        bool shouldLaunchEvent = !this._inIdle && this.UserIdleDetected != null;
                        if (shouldLaunchEvent)
                        {
                            this.UserIdleDetected(this, EventArgs.Empty);
                        }

                        this._inIdle = true;
                    }
                }
                else
                {
                    bool shouldLaunchEvent = this._inIdle && this.UserIdleInterrupted != null;
                    if (shouldLaunchEvent)
                    {
                        this.UserIdleInterrupted(this, EventArgs.Empty);
                    }

                    this._inIdle = false;
                }
            }
        }
    }
}
