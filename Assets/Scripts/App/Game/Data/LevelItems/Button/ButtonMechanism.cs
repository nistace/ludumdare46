using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ButtonMechanism : MonoBehaviour, IMechanism {
	[SerializeField] protected GameObject[]   _mechanisms;
	[SerializeField] protected ButtonAnimator _animator;
	[SerializeField] protected SpriteRenderer _renderer;
	[SerializeField] protected GroundCheck    _groundCheck;
	[SerializeField] protected bool           _on;
	[SerializeField] protected bool           _statusOnStart = true;
	[SerializeField] protected Color          _offColor;
	[SerializeField] protected Color          _onColor;

	private IMechanism[] mechanisms { get; set; } = new IMechanism[0];

	public bool       isOn            => _on;
	public UnityEvent onStatusChanged { get; } = new UnityEvent();

	private void Awake() {
		_groundCheck.onChange.AddListenerOnce(HandlePressChanged);
	}

	private void HandlePressChanged() {
		var pressed = _groundCheck.isOnGround;
		_animator.SetPressed(pressed);
		if (!pressed) SetOn(!_on);
		AudioManager.Sfx.Play(pressed ? AudioSfxCategory.ButtonPress : AudioSfxCategory.ButtonRelease);
	}

	private void Start() {
		mechanisms = _mechanisms.Select(t => t.GetComponent<IMechanism>()).ToArray();
		SetOn(_on, true);
	}

	public void SetOn(bool on, bool force = false) {
		if (!force && on == _on) return;
		_on = on;
		_renderer.color = _on ? _onColor : _offColor;
		foreach (var mechanism in mechanisms) {
			mechanism.SetOn(_on);
		}
		onStatusChanged.Invoke();
	}

	public void ResetOn() => SetOn(_statusOnStart);
}