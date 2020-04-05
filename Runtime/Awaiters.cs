using System;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace GameLovers.AsyncAwait
{
    public static class Awaiters
    {
        private readonly static WaitForUpdate _waitForUpdate = new WaitForUpdate();
        private readonly static WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
        private readonly static WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame();

        public static WaitForUpdate NextFrame
        {
            get { return _waitForUpdate; }
        }

        public static WaitForFixedUpdate FixedUpdate
        {
            get { return _waitForFixedUpdate; }
        }

        public static WaitForEndOfFrame EndOfFrame
        {
            get { return _waitForEndOfFrame; }
        }

        public static WaitForSeconds Seconds(float seconds)
        {
            return new WaitForSeconds(seconds);
        }

        public static WaitForSecondsRealtime SecondsRealtime(float seconds)
        {
            return new WaitForSecondsRealtime(seconds);
        }

        public static WaitUntil Until(Func<bool> predicate)
        {
            return new WaitUntil(predicate);
        }

        public static WaitWhile While(Func<bool> predicate)
        {
            return new WaitWhile(predicate);
        }
    }
}
