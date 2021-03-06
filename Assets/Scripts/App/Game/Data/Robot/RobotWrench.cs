﻿using UnityEngine;
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
		if (flower) return;
		if (other.gameObject.layer != LayerMask.NameToLayer("Soil")) return;
		Attach(other.GetComponentInParent<Flower>());
		flower.PlaySfx(AudioSfxCategory.FlowerCaught);
	}

	private void Throw(InputAction.CallbackContext context) {
		_animator.SetWrenchExtended();
		AudioManager.Sfx.Play(AudioSfxCategory.WrenchExpansion);
		if (!_flower) return;
		_flower.PlaySfx(AudioSfxCategory.FlowerThrown);
		DetachFlower(new Vector2(throwDirection * _wrenchAngleCoefficient, 1) * _throwStrength);
	}

	public void Attach(Flower flower) {
		_flower = flower;
		flower.AttachTo(transform, Vector2.zero);
		onFlowerGathered.Invoke(_flower);
	}

	private void DetachFlower(Vector2 force) {
		if (!_flower) return;
		_flower.Detach(transform, force);
		_flower = null;
	}

	private void Update() {
		CheckLongFall();
	}

	private void CheckLongFall() {
		if (!flower || _rigidbody.velocity.y > _flowerLostOnVerticalSpeed) return;
		flower.PlaySfx(AudioSfxCategory.FlowerLost);
		DetachFlower(new Vector2(_rigidbody.velocity.x, _flowerLostForce));
	}
}