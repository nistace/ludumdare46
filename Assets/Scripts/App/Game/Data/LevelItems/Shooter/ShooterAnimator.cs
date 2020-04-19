using UnityEngine;

public class ShooterAnimator : MonoBehaviour {
	[SerializeField] protected Animator _animator;
	private static readonly    int      shootAnimParam = Animator.StringToHash("Shoot");

	public void Shoot() => _animator.SetTrigger(shootAnimParam);
}