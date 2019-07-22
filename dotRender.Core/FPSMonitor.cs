namespace dotRender.Core {
    using System.Diagnostics;

    public interface IFPSMonitor {
        int FPS { get; set; }
        void Tick();
    }

    public class FPSMonitor : IFPSMonitor {
        public FPSMonitor() {
            this._stopwatch = Stopwatch.StartNew();
        }

        public int FPS { get; set; }
        private readonly Stopwatch _stopwatch;
        private int _currentCount;

        public void Tick() {
            if (this._stopwatch.ElapsedMilliseconds >= 1000) {
                this.FPS = this._currentCount;
                this._currentCount = 0;
                this._stopwatch.Restart();
            } else {
                this._currentCount++;
            }
        }
    }
}
