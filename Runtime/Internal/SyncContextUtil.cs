using System.Threading;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace GameLovers.AsyncAwait
{
    internal static class SyncContextUtil
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Install()
        {
            UnitySynchronizationContext = SynchronizationContext.Current;
            UnityThreadId = Thread.CurrentThread.ManagedThreadId;
        }

        internal static int UnityThreadId
        {
            get; private set;
        }

        internal static SynchronizationContext UnitySynchronizationContext
        {
            get; private set;
        }
    }
}

