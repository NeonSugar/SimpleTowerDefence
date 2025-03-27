using SimpleTowerDefence.PlayerBaseRelated;
using UnityEngine;

namespace SimpleTowerDefence.EnemiesRelated
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class SimpleMovement : MonoBehaviour
	{
		private Rigidbody2D _rigidbody;
		private Transform _target;

		[SerializeField] private float _speed;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			_target = PlayerBase.Instance.transform;
		}

		private void FixedUpdate()
		{
			_rigidbody.velocity = (_target.position - transform.position).normalized * _speed;
		}
	}
}
