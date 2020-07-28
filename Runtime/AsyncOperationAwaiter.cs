using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace GameLovers.AsyncAwait
{
	/// <summary>
	/// Allows to use <seealso cref="AsyncOperation"/> with async/await mechanism
	/// </summary>
	public class AsyncOperationAwaiter : INotifyCompletion
	{
		protected readonly AsyncOperation _asyncOp;
		
		private Action _continuation;
		private bool _invoked;

		public AsyncOperation AsyncOperation => _asyncOp;
		
		private AsyncOperationAwaiter() {}

		public AsyncOperationAwaiter(AsyncOperation asyncOp)
		{
			_asyncOp = asyncOp;
			asyncOp.completed += OnRequestCompleted;
		}

		public bool IsCompleted => _asyncOp.isDone;

		public void GetResult() { }

		public void OnCompleted(Action continuation)
		{
			_continuation = continuation;

			if (_invoked)
			{
				_continuation();
			}
		}

		private void OnRequestCompleted(AsyncOperation obj)
		{
			_invoked = true;
			
			_continuation?.Invoke();
		}

		public static implicit operator AsyncOperationAwaiter(AsyncOperation asyncOp)
		{
			return new AsyncOperationAwaiter(asyncOp);
		}

		public static implicit operator AsyncOperation(AsyncOperationAwaiter awaiter)
		{
			return awaiter.AsyncOperation;
		}
	}

	public static class AsyncOperationAwaiterExtension
	{
		public static AsyncOperationAwaiter GetAwaiter(this AsyncOperation asyncOp)
		{
			return new AsyncOperationAwaiter(asyncOp);
		}
	}
}