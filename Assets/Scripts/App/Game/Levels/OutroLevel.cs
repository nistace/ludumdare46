using UnityEngine;

public class OutroLevel : MonoBehaviour {
	[SerializeField] protected Animator   _animator;
	[SerializeField] protected Camera     _camera;
	[SerializeField] protected Color      _targetColor;
	[SerializeField] protected Color      _fromColor;
	[SerializeField] protected float      _colorChangeSpeed = 1;
	[SerializeField] protected GameObject _canvasToHide;
	[SerializeField] protected GameObject _thankYou;

	private static readonly int startAnimParam  = Animator.StringToHash("Start");
	private static readonly int randomAnimParam = Animator.StringToHash("Random");

	private float lerpColor { get; set; }

	public void Play() {
		lerpColor = 0;
		enabled = true;
		_animator.SetTrigger(startAnimParam);
		_canvasToHide.SetActive(false);
	}

	private void Update() {
		UpdateColor();
		_animator.SetFloat(randomAnimParam, Random.value);
	}

	private void UpdateColor() {
		if (lerpColor >= 1) return;
		lerpColor += Time.deltaTime * _colorChangeSpeed;
		_camera.backgroundColor = Color.Lerp(_fromColor, _targetColor, lerpColor);
	}

	public void ShowThankYou() => _thankYou.SetActive(true);
}