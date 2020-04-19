using UnityEngine;
using UnityEngine.Events;

public class Flower : MonoBehaviour, IAttachableItem {
	public class Event : UnityEvent<Flower> { }

	[SerializeField] protected FlowerHeart    _heart;
	[SerializeField] protected FlowerSoil     _soil;
	[SerializeField] protected Transform      _transform;
	[SerializeField] protected Rigidbody2D    _rigidbody;
	[SerializeField] protected SpriteRenderer _renderer;
	[SerializeField] protected FlowerAnimator _animator;

	private bool attached { get; set; }
	private bool dead     { get; set; }

	public UnityEvent onDied { get; } = new UnityEvent();

	private void Awake() {
		_heart.onHitSomething.AddListenerOnce(Die);
		_soil.onHitNotSoilFriendly.AddListenerOnce(Die);
	}

	public void Revive() {
		dead = false;
		_animator.SetDead(false);
	}

	private void Die() {
		PlaySfx(AudioSfxCategory.FlowerDie);
		dead = true;
		_animator.SetDead(true);
		onDied.Invoke();
	}

	public void AttachTo(Transform parent, Vector2? setPosition) {
		_rigidbody.bodyType = RigidbodyType2D.Kinematic;
		_rigidbody.velocity = Vector2.zero;
		_transform.SetParent(parent);
		if (setPosition != null) _transform.localPosition = setPosition.Value;
		attached = true;
		_animator.SetAttached(true);
	}

	public void Detach(Vector2? force) {
		_rigidbody.bodyType = RigidbodyType2D.Dynamic;
		if (force != null) _rigidbody.AddForce(force.Value);
		_transform.SetParent(null);
		attached = false;
		_animator.SetAttached(false);
	}

	public void SetFlipX(bool flipped) => _renderer.flipX = flipped;

	private void Update() {
		if (attached) return;
		_animator.SetVerticalMovement(_rigidbody.velocity.y);
	}

	public void PlaySfx(AudioSfxCategory category) {
		if (dead) return;
		AudioManager.Sfx.Play(category);
	}
}