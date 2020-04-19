using UnityEngine;
using UnityEngine.InputSystem;

public class RobotMovement : MonoBehaviour {
	[SerializeField] protected SpriteRenderer _robotRenderer;
	[SerializeField] protected RobotWrench    _wrench;
	[SerializeField] protected GroundCheck    _groundCheck;
	[SerializeField] protected Rigidbody2D    _rigidbody;
	[SerializeField] protected float          _speed = 1;
	[SerializeField] protected RobotAnimator  _animator;

	[Header("Body friction")] [SerializeField] protected Collider2D        _bodyCollider;
	[SerializeField]                           protected PhysicsMaterial2D _enabledFrictionPhysicsMaterial;
	[SerializeField]                           protected PhysicsMaterial2D _disabledFrictionPhysicsMaterial;

	private float movement { get; set; }

	private void Awake() {
		_wrench.onFlowerGathered.AddListenerOnce(HandleFlowerGathered);
		Inputs.controls.Robot.HorizontalMovement.AddAnyListenerOnce(HandleHorizontalMovementChanged);
		_groundCheck.onChange.AddListenerOnce(RefreshBodyColliderFriction);
	}

	private void RefreshBodyColliderFriction() => _bodyCollider.sharedMaterial = _groundCheck.isOnGround ? _enabledFrictionPhysicsMaterial : _disabledFrictionPhysicsMaterial;

	private void OnEnable() {
		Inputs.controls.Robot.HorizontalMovement.Enable();
	}

	private void OnDisable() {
		Inputs.controls.Robot.HorizontalMovement.Disable();
	}

	private void HandleHorizontalMovementChanged(InputAction.CallbackContext obj) => movement = obj.ReadValue<float>();

	private void FixedUpdate() {
		/*if (_groundCheck.isOnGround)*/
		_rigidbody.velocity = new Vector2(_speed * movement, _rigidbody.velocity.y);
		_animator.SetMoving(movement != 0 && _groundCheck.isOnGround);
		_wrench.throwDirection = movement;
		if (movement == 0) return;
		_robotRenderer.flipX = movement < 0;
		_wrench.flower?.SetFlipX(movement < 0);
	}

	private void HandleFlowerGathered(Flower flower) => flower.SetFlipX(_robotRenderer.flipX);
}