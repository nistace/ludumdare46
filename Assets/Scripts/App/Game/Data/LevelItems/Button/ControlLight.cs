using UnityEngine;

public class ControlLight : MonoBehaviour {
	[SerializeField] protected SpriteRenderer _renderer;
	[SerializeField] protected GameObject     _mechanism;
	[SerializeField] protected Color          _offColor;
	[SerializeField] protected Color          _onColor1;
	[SerializeField] protected Color          _onColor2;
	[SerializeField] protected float          _onBlinkSpeed;

	private IMechanism mechanism          { get; set; }
	private float      colorLerp          { get; set; }
	private float      colorLerpDirection { get; set; } = 1;

	public void Start() {
		mechanism = _mechanism.GetComponent<IMechanism>();
		mechanism.onStatusChanged.AddListenerOnce(RefreshStatus);
	}

	private void Update() {
		if (!mechanism.isOn) return;
		colorLerp += colorLerpDirection * _onBlinkSpeed * Time.deltaTime;
		if (colorLerp < 0) {
			colorLerp = 0;
			colorLerpDirection = 1;
		}
		else if (colorLerp > 1) {
			colorLerp = 1;
			colorLerpDirection = -1;
		}
		_renderer.color = Color.Lerp(_onColor1, _onColor2, colorLerp);
	}

	private void RefreshStatus() {
		if (mechanism.isOn) {
			colorLerp = 0;
			colorLerpDirection = 1;
			_renderer.color = _onColor1;
		}
		else _renderer.color = _offColor;
	}
}