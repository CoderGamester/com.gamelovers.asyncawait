using UnityEngine.Networking;

// ReSharper disable once CheckNamespace

namespace GameLovers.AsyncAwait
{
	/// <summary>
	/// Allows to use <seealso cref="UnityWebRequest"/> with async/await mechanism
	/// </summary>
	public class UnityWebRequestAwaiter : AsyncOperationAwaiter
	{
		public new UnityWebRequestAsyncOperation AsyncOperation => (UnityWebRequestAsyncOperation) _asyncOp;

		public UnityWebRequestAwaiter(UnityWebRequestAsyncOperation asyncOp) : base(asyncOp)
		{
		}

		public static implicit operator UnityWebRequestAwaiter(UnityWebRequestAsyncOperation asyncOp)
		{
			return new UnityWebRequestAwaiter(asyncOp);
		}

		public static implicit operator UnityWebRequestAsyncOperation(UnityWebRequestAwaiter awaiter)
		{
			return awaiter.AsyncOperation;
		}
	}

	public static class UnityWebRequestAwaiterExtension
	{
		public static UnityWebRequestAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
		{
			return new UnityWebRequestAwaiter(asyncOp);
		}
	}
}