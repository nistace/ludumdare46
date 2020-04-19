using UnityEngine;

public class FlowerAnimator : MonoBehaviour {
	[SerializeField] protected Animator _animator;

	private static readonly int verticalMovementAnimParam = Animator.StringToHash("VerticalMovement");
	private static readonly int deadAnimParam             = Animator.StringToHash("Dead");
	private static readonly int attachedAnimParam         = Animator.StringToHash("Attached");

	public void SetVerticalMovement(float verticalMovement) {
		_animator.SetFloat(verticalMovementAnimParam, verticalMovement);
	}

	public void SetAttached(bool attached) => _animator.SetBool(attachedAnimParam, attached);

	public void SetDead(bool dead) => _animator.SetBool(deadAnimParam, dead);
}