using System;
using System.Diagnostics;
using System.Threading;
using Core.Systems;

namespace Server.ServerCore
{
    public class ServerEngine
    {
        private Thread _updateThread;
        private bool _isRun;
        private int _maxDeltaTimeMilliseconds;
        public readonly SystemCollection Systems = new();
        private int _deltaTime;
        private float _deltaTimeF;

        public void Start(int deltaTimeMilliseconds)
        {
            _maxDeltaTimeMilliseconds = deltaTimeMilliseconds;
            _updateThread = new Thread(UpdateCycle);
            _isRun = true;
            _updateThread.Start();
        }

        public void Stop()
        {
            _isRun = false;
            _updateThread.Join();
        }

        private void UpdateCycle()
        {
            _deltaTime = _maxDeltaTimeMilliseconds;
            
            while (_isRun)
            {
                try
                {
                    _deltaTimeF = _deltaTime / 1000f;

                    var stopwatch = Stopwatch.StartNew();
                    Systems.Update(_deltaTimeF);
                    stopwatch.Stop();
                    
                    var executionTime = (int)stopwatch.ElapsedMilliseconds;
                    var waitTime = Math.Clamp(_maxDeltaTimeMilliseconds - executionTime, 0, _maxDeltaTimeMilliseconds);
                    
                    _deltaTime = Math.Max(executionTime, _maxDeltaTimeMilliseconds);
                    Thread.Sleep(waitTime);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}