using System.Collections;
using System.Linq;
using SimpleTowerDefence.Shared;
using UnityEngine;

namespace SimpleTowerDefence.EnemiesRelated
{
	public class SimpleAttack : MonoBehaviour
	{
		[SerializeField] private float _radius = 0.35f;
		[SerializeField] private float _attackSpeed = 1f;
		[SerializeField] private float _damage = 1f;

		public ComponentState State { get; private set; }

		private void Start()
		{
			StartCoroutine(AttackRoutine());
		}

		private IEnumerator AttackRoutine()
		{
			while(State is ComponentState.Active)
			{
				// Debug.DrawLine(transform.position, transform.position + new Vector3(_radius, 0, 0), Color.cyan, 1f);
				// TODO: Code
				var colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
				foreach(var collider in colliders.Where(item => item.CompareTag(nameof(Enemy)) is false))
				{
					collider.TryGetComponent(out Damageable damageable);
					damageable.ApplyDamage(_damage);
				}

				yield return new WaitForSeconds(_attackSpeed);
			}
		}
	}
}
