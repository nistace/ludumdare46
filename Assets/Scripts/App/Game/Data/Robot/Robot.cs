using LD46.Game.Data;
using UnityEngine;

public class Robot : MonoBehaviour, IAttachableItem {
	[SerializeField] protected RobotMovement _movement;
	[SerializeField] protected RobotWrench   _wrench;
	public                     bool          holdsFlower => _wrench.flower;

	public void SetEnabled(bool enabled) {
		_movement.enabled = enabled;
		_wrench.enabled = enabled;
	}

	public void Attach(Flower flower) => _wrench.Attach(flower);

	public void AttachTo(Transform parent, Vector2? setPosition) {
		transform.SetParent(parent);
		if (setPosition != null) transform.position = setPosition.Value;
	}

	public void Detach(Vector2? force) => transform.SetParent(null);
}