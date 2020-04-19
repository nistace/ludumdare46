using UnityEngine;
using UnityEngine.Events;

public class TravelatorObjectCatcher : MonoBehaviour {
	public class Collider2DEvent : UnityEvent<Collider2D> { }

	public Collider2DEvent onEnter { get; } = new Collider2DEvent();
	public Collider2DEvent onExit  { get; } = new Collider2DEvent();

	private void OnTriggerEnter2D(Collider2D other) => onEnter.Invoke(other);

	private void OnTriggerExit2D(Collider2D other) => onExit.Invoke(other);
}