using System;
using UnityEngine;
using UnityEngine.Events;

public class FlowerHeart : MonoBehaviour {
	public UnityEvent onHitSomething { get; } = new UnityEvent();

	private void OnTriggerEnter2D(Collider2D other) => onHitSomething.Invoke();
}