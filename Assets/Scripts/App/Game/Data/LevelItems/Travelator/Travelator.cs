using System.Collections.Generic;
using LD46.Game.Data;
using UnityEngine;
using UnityEngine.Events;

public class Travelator : MonoBehaviour, IMechanism {
	[SerializeField]                     protected TravelatorAnimator      _animator;
	[SerializeField]                     protected TravelatorObjectCatcher _catcher;
	[SerializeField]                     protected float                   _travelatorSpeed;
	[SerializeField]                     protected Vector2                 _throwForce;
	[SerializeField]                     protected bool                    _on            = true;
	[SerializeField]                     protected bool                    _statusOnStart = true;
	[Header("Arrows")] [SerializeField]  protected SpriteRenderer[]        _arrows;
	[SerializeField]                     protected Color                   _offColor;
	[SerializeField]                     protected Color                   _onColor1;
	[SerializeField]                     protected Color                   _onColor2;
	[SerializeField]                     protected float                   _onBlinkSpeed;
	[Header("Effects")] [SerializeField] protected ParticleSystem          _soilExitEffect;

	private HashSet<IAttachableItem> objectsOnTravelator { get; } = new HashSet<IAttachableItem>();

	private float colorLerp          { get; set; }
	private float colorLerpDirection { get; set; } = 1;

	public bool       isOn            => _on;
	public UnityEvent onStatusChanged { get; } = new UnityEvent();

	private void Awake() {
		_catcher.onEnter.AddListenerOnce(HandleObjectEntered);
		_catcher.onExit.AddListenerOnce(HandleObjectLeft);
	}

	private void Start() {
		SetOn(_on, true);
	}

	private void Update() {
		UpdateArrowsColor();
	}

	private void HandleObjectEntered(Collider2D item) {
		if (!item.TryGetComponentInParent<IAttachableItem>(out var attachableItem)) return;
		attachableItem.AttachTo(transform, null);
		objectsOnTravelator.Add(attachableItem);
	}

	private void HandleObjectLeft(Collider2D item) {
		if (!item.TryGetComponentInParent<IAttachableItem>(out var attachableItem)) return;
		attachableItem.Detach(_throwForce);
		objectsOnTravelator.Remove(attachableItem);
	}

	private void FixedUpdate() {
		if (!_on) return;
		foreach (var item in objectsOnTravelator) {
			item.transform.position += new Vector3(_travelatorSpeed * Time.deltaTime, 0, 0);
		}
	}

	private void UpdateArrowsColor() {
		if (!_on) return;
		colorLerp += colorLerpDirection * _onBlinkSpeed * Time.deltaTime;
		if (colorLerp < 0) {
			colorLerp = 0;
			colorLerpDirection = 1;
		}
		else if (colorLerp > 1) {
			colorLerp = 1;
			colorLerpDirection = -1;
		}
		SetArrowsColor(Color.Lerp(_onColor1, _onColor2, colorLerp));
	}

	public void SetOn(bool on, bool force = false) {
		if (!force && on == _on) return;
		_on = on;
		if (!_on) SetArrowsColor(_offColor);
		colorLerp = 0;
		colorLerpDirection = 1;
		_animator.SetMovementSpeed(_on ? _travelatorSpeed : 0);
		if (_on) _soilExitEffect.Play();
		else _soilExitEffect.Stop();
		onStatusChanged.Invoke();
	}

	private void SetArrowsColor(Color c) {
		foreach (var arrow in _arrows) arrow.color = c;
	}

	public void ResetOn() => SetOn(_statusOnStart);
}