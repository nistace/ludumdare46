using UnityEngine;

public class TravelatorAnimator : MonoBehaviour {
	[SerializeField] protected Animator _animator;

	private static readonly int movementSpeedAnimParam = Animator.StringToHash("MovementSpeed");

	public void SetMovementSpeed(float movementSpeed) => _animator.SetFloat(movementSpeedAnimParam, movementSpeed);
}