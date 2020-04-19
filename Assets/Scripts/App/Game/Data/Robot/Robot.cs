using UnityEngine;

public class Robot : MonoBehaviour {
	[SerializeField] protected RobotMovement _movement;
	[SerializeField] protected RobotWrench   _wrench;
	public                     bool          holdsFlower => _wrench.flower;

	public void SetEnabled(bool enabled) {
		_movement.enabled = enabled;
		_wrench.enabled = enabled;
	}

	public void Attach(Flower flower) => _wrench.Attach(flower);
}