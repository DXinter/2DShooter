using System;

namespace Core
{
    public interface IDependency
    {
        public event Action OnInit;

        public bool IsInitializing { get; }
        public bool IsInitialized { get; }
    }
}