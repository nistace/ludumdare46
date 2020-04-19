using UnityEngine;

public class ButtonAnimator : MonoBehaviour {
	[SerializeField] protected Animator _animator;
	private static readonly    int      pressedAnimParam = Animator.StringToHash("Pressed");

	public void SetPressed(bool pressed) => _animator.SetBool(pressedAnimParam, pressed);
}