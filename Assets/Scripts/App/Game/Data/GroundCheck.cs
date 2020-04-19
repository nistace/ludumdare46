using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundCheck : MonoBehaviour {
	private HashSet<Collider2D> groundItems { get; } = new HashSet<Collider2D>();
	public  bool                isOnGround  => groundItems.Count > 0;

	private void OnTriggerEnter2D(Collider2D other) => groundItems.Add(other);

	private void OnTriggerExit2D(Collider2D other) => groundItems.Remove(other);
}