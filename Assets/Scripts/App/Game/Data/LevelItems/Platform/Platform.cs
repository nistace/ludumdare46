using UnityEngine;
using UnityEngine.Events;

public class Platform : MonoBehaviour, IMechanism {
	[SerializeField] protected Transform[]             _points;
	[SerializeField] protected bool                    _on            = true;
	[SerializeField] protected bool                    _statusOnStart = true;
	[SerializeField] protected TravelatorObjectCatcher _overPlatform;
	[SerializeField] protected int                     _passedPoint;
	[SerializeField] protected int                     _pointOnStart;
	[SerializeField] protected float                   _lerp;
	[SerializeField] protected float                   _lerpOnStart;
	[SerializeField] protected float                   _distancePerSecond;

	public bool       isOn            => _on;
	public UnityEvent onStatusChanged { get; } = new UnityEvent();

	private float currentPathLerpPerSecond { get; set; }

	private void Awake() {
		_overPlatform.onEnter.AddListenerOnce(HandleObjectEntered);
		_overPlatform.onExit.AddListenerOnce(HandleObjectLeft);
	}

	private void HandleObjectEntered(Collider2D item) {
		if (!item.TryGetComponentInParent<IAttachableItem>(out var attachableItem)) return;
		attachableItem.AttachTo(transform, null);
	}

	private static void HandleObjectLeft(Collider2D item) {
		if (!item.TryGetComponentInParent<IAttachableItem>(out var attachableItem)) return;
		attachableItem.Detach(null);
	}

	private void Start() {
		SetOn(_on, true);
	}

	private void Update() {
		if (!_on) return;
		SetLerp(_lerp + currentPathLerpPerSecond * Time.deltaTime);
	}

	public void SetOn(bool on, bool force = false) {
		if (!force && on == _on) return;
		_on = on;
		onStatusChanged.Invoke();
	}

	public void ResetOn() {
		PreparePath(_pointOnStart);
		SetLerp(_lerpOnStart);
		SetOn(_statusOnStart, true);
	}

	private void SetLerp(float lerp) {
		_lerp = Mathf.Clamp(lerp, 0, 1);
		transform.position = Vector3.Lerp(_points[_passedPoint].position, _points[(_passedPoint + 1) % _points.Length].position, lerp);
		if (_lerp >= 1) PrepareNextPath();
	}

	private void PrepareNextPath() => PreparePath((_passedPoint + 1) % _points.Length);

	private void PreparePath(int originPointIndex) {
		_passedPoint = originPointIndex;
		SetLerp(0);
		currentPathLerpPerSecond = _distancePerSecond / Vector3.Distance(_points[_passedPoint].position, _points[(_passedPoint + 1) % _points.Length].position);
	}
}