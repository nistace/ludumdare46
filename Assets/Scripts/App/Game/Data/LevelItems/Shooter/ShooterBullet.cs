using UnityEngine;
using UnityEngine.Events;

public class ShooterBullet : MonoBehaviour {
	public class Event : UnityEvent<ShooterBullet> { }

	[SerializeField] protected Rigidbody2D _rigidbody;

	public new Rigidbody2D rigidbody => _rigidbody;

	public Event onHit { get; } = new Event();

	private void OnCollisionEnter2D() => onHit.Invoke(this);
}