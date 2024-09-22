using UnityEngine;

namespace SimpleTowerDefence.BuilderRelated
{
	public class Builder : MonoBehaviour
	{
		[SerializeField] private Color _defaultBlueprintColor;
		[SerializeField] private Color _buildNotAcceptedColor;
		[SerializeField] private Blueprint _flyingBlueprint;

		public static Builder Instance;

		private void Awake()
		{
			if(Instance is not null) throw new ($"{nameof(Builder)} is already exists!");

			Instance = this;
		}

		private void Update()
		{
			if (_flyingBlueprint is null) return;

			if(Input.GetMouseButtonDown(1))
			{
				_flyingBlueprint.Destroy();
				_flyingBlueprint = null;
				return;
			}

			var mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
			_flyingBlueprint.transform.position = new (Mathf.RoundToInt(mousePosition.x), Mathf.RoundToInt(mousePosition.y), 0f);

			var hit = Physics2D.Raycast(mousePosition, Vector2.down, 0.001f);

			_flyingBlueprint.ChangeColor(hit.collider is null ? _defaultBlueprintColor : _buildNotAcceptedColor);

			if (hit.collider is not null) return;

			if (Input.GetMouseButtonDown(0) is false) return;
			if (_flyingBlueprint.TryBuild() is false) return;

			_flyingBlueprint = null;
		}

		public void PlaceBlueprint(Blueprint blueprint)
		{
			_flyingBlueprint?.Destroy();

			_flyingBlueprint = Instantiate(blueprint);
		}
	}
}
