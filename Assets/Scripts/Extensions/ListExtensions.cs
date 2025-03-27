using System.Collections.Generic;
using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class ListExtensions
	{
		public static T GetRandom<T>(this List<T> origin)
		{
			return origin[Random.Range(0, origin.Count)];
		}
	}
}
