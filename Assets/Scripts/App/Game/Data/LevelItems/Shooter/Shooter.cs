using LD46.Game.Data.LevelItems.Shooter;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour, IMechanism {
	[SerializeField] protected ShooterAnimator _animator;
	[SerializeField] protected ShooterBullet   _bulletPrefab;
	[SerializeField] protected float           _bulletsPerSecond = .5f;
	[SerializeField] protected Transform       _spawnPosition;
	[SerializeField] protected Vector2         _initialForce;
	[SerializeField] protected float           _loadNextBullet        = .5f;
	[SerializeField] protected float           _loadNextBulletOnStart = .5f;
	[SerializeField] protected bool            _on                    = true;
	[SerializeField] protected bool            _statusOnStart         = true;

	public bool       isOn            => _on;
	public UnityEvent onStatusChanged { get; } = new UnityEvent();

	private void Start() {
		SetOn(_on, true);
	}

	private void Update() {
		if (!_on) return;
		_loadNextBullet += _bulletsPerSecond * Time.deltaTime;
		if (_loadNextBullet < 1) return;
		_animator.Shoot();
		_loadNextBullet -= 1;
	}

	public void SpawnBullet() {
		var newBullet = ShooterBulletPool.GetPrefabInstance(_bulletPrefab);
		newBullet.transform.position = _spawnPosition.position;
		newBullet.gameObject.SetActive(true);
		newBullet.rigidbody.velocity = _initialForce;
		AudioManager.Sfx.Play(AudioSfxCategory.Shoot);
	}

	public void SetOn(bool on, bool force = false) {
		if (!force && _on == on) return;
		_on = on;
		onStatusChanged.Invoke();
	}

	public void ResetOn() {
		_loadNextBullet = _loadNextBulletOnStart;
		SetOn(_statusOnStart);
	}
}