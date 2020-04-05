using System;
using UnityEngine;
using UnityEngine.Networking;
using GameLovers.AsyncAwait;
using UnityEditor;

public class UnityWebRequestExample
{
	[MenuItem("Tools/AsyncAwaitTest")]
	public static async void AsyncAwaitTest()
	{
		var request = UnityWebRequest.Get("www.google.com");

		await request.SendWebRequest();

		if (request.isHttpError || request.isNetworkError)
		{
			throw new Exception(request.error);
		}

		Debug.Log(request.downloadHandler.text);
	}
}