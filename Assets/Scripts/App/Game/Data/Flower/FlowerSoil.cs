using UnityEngine;
using UnityEngine.Events;

public class FlowerSoil : MonoBehaviour {
	public UnityEvent onHitNotSoilFriendly { get; } = new UnityEvent();

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("SoilFriendly")) return;
		onHitNotSoilFriendly.Invoke();
	}
}