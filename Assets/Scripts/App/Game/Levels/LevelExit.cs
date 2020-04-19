using UnityEngine;
using UnityEngine.Events;

public class LevelExit : MonoBehaviour {
	public UnityEvent onReached { get; } = new UnityEvent();

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("RobotBody")) {
			onReached.Invoke();
		}
	}
}