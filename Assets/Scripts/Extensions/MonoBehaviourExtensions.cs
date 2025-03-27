using System;
using System.Collections;
using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class MonoBehaviourExtensions
	{
		public static bool IsDestroyed(this MonoBehaviour origin)
		{
			return origin == null && !ReferenceEquals(origin, null);
		}

		public static Coroutine InvokeWithDelay(this MonoBehaviour origin, Action action, float delay)
			=> origin.StartCoroutine(InvokeWithDelayRoutine(action, delay));

		private static IEnumerator InvokeWithDelayRoutine(Action action, float delay)
		{
			yield return new WaitForSeconds(delay);
			action();
		}
	}
}
