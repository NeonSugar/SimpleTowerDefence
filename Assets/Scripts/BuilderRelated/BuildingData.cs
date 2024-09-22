using System;
using UnityEngine;

namespace SimpleTowerDefence.BuilderRelated
{
	[Serializable]
	public class BuildingData : IReadOnlyBuildingData
	{
		[field: SerializeField] public int MaxLevel { get; set; } = 10;
		[field: SerializeField] public int Level    { get; set; } = 1;

		[field: SerializeField] public Sprite Icon { get; set; }
		[field: SerializeField] public string Name { get; set; }
		[field: SerializeField] public int    Cost { get; set; }

		[field: SerializeField] public BuildingType Type { get; set; }
	}
}
