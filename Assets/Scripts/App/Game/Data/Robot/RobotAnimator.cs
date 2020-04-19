using UnityEngine;

public class RobotAnimator : MonoBehaviour {
	[SerializeField] protected Animator _animator;

	private static readonly int movingAnimParam         = Animator.StringToHash("Moving");
	private static readonly int wrenchPositionAnimParam = Animator.StringToHash("WrenchPosition");
	private static readonly int extendWrenchAnimParam   = Animator.StringToHash("ExtendWrench");

	public void SetWrenchPosition(float position) => _animator.SetFloat(wrenchPositionAnimParam, position);
	public void SetMoving(bool moving) => _animator.SetBool(movingAnimParam, moving);
	public void SetWrenchExtended() => _animator.SetTrigger(extendWrenchAnimParam);
}