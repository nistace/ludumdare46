using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RobotWrench : MonoBehaviour {
	[SerializeField] protected float         _wrenchAngleCoefficient = .4f;
	[SerializeField] protected float         _throwStrength;
	[SerializeField] protected RobotAnimator _animator;
	[SerializeField] protected Flower        _flower;
	[SerializeField] protected Rigidbody2D   _rigidbody;
	[SerializeField] protected float         _flowerLostOnVerticalSpeed;
	[SerializeField] protected float         _flowerLostForce;

	public float  throwDirection { get; set; }
	public Flower flower         => _flower;

	public Flower.Event onFlowerGathered { get; } = new Flower.Event();
	public UnityEvent   onFlowerLost     { get; } = new UnityEvent();

	private void Awake() {
		Inputs.controls.Robot.Throw.AddPerformListenerOnce(Throw);
	}

	private void OnEnable() {
		Inputs.controls.Robot.Throw.Enable();
		Inputs.controls.Robot.MoveWrench.Enable();
	}

	private void OnDisable() {
		Inputs.controls.Robot.Throw.Disable();
		Inputs.controls.Robot.MoveWrench.Disable();
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.layer != LayerMask.NameToLayer("Soil")) return;
		Attach(other.GetComponentInParent<Flower>());
	}

	private void Throw(InputAction.CallbackContext context) {
		_animator.SetWrenchExtended();
		DetachFlower(new Vector2(throwDirection * _wrenchAngleCoefficient, 1) * _throwStrength);
	}

	public void Attach(Flower flower) {
		_flower = flower;
		flower.AttachTo(transform, Vector2.zero);
		onFlowerGathered.Invoke(_flower);
	}

	private void DetachFlower(Vector2 force) {
		if (!_flower) return;
		_flower.Detach(force);
		_flower = null;
		onFlowerLost.Invoke();
	}

	private void Update() {
		if (flower && _rigidbody.velocity.y < _flowerLostOnVerticalSpeed) {
			DetachFlower(new Vector2(_rigidbody.velocity.x, _flowerLostForce));
		}
	}
}