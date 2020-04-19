using LD46.Game.Data.LevelItems.Shooter;
using UnityEngine;

public class Shooter : MonoBehaviour {
	[SerializeField] protected ShooterAnimator _animator;
	[SerializeField] protected ShooterBullet   _bulletPrefab;
	[SerializeField] protected float           _bulletsPerSecond = .5f;
	[SerializeField] protected Transform       _spawnPosition;
	[SerializeField] protected Vector2         _initialForce;
	[SerializeField] protected float           _loadNextBullet = .5f;

	private void Update() {
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
	}
}