using System.Collections.Generic;

namespace AxFixEngine.Engine
{
    public class FixEngineManager : IFixEngineManager
    {
        protected readonly IList<IFixEngine> _fixEngines = new List<IFixEngine>();

        public void CreateFixEngine(string fixConfig)
        {
            IFixEngine fixEngine = new FixEngine(fixConfig);
            _fixEngines.Add(fixEngine);
        }

        public void Start()
        {
            foreach (IFixEngine fixEngine in _fixEngines)
            {
                fixEngine.CreateApplication();
                fixEngine.Start();
            }
        }

        public void Stop()
        {
            foreach (IFixEngine fixEngine in _fixEngines)
            {
                fixEngine.Stop();
            }
        }
    }
}
