using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour {
	private HashSet<Collider2D> groundItems { get; } = new HashSet<Collider2D>();
	public  bool                isOnGround  => groundItems.Count > 0;

	public UnityEvent onChange { get; } = new UnityEvent();

	private void OnTriggerEnter2D(Collider2D other) {
		if (groundItems.Contains(other)) return;
		var before = isOnGround;
		groundItems.Add(other);
		if (before != isOnGround) onChange.Invoke();
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (!groundItems.Contains(other)) return;
		var before = isOnGround;
		groundItems.Remove(other);
		if (before != isOnGround) onChange.Invoke();
	}

	public void Clear() => groundItems.Clear();
}