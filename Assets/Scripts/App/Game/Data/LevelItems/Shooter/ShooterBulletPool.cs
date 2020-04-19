using System.Collections.Generic;
using UnityEngine;

namespace LD46.Game.Data.LevelItems.Shooter {
	public class ShooterBulletPool : MonoBehaviour {
		private static ShooterBulletPool instance { get; set; }

		private Dictionary<string, Queue<ShooterBullet>> pools { get; } = new Dictionary<string, Queue<ShooterBullet>>();

		private void Awake() {
			if (!instance) instance = this;
			if (instance != this) Destroy(this);
		}

		public static ShooterBullet GetPrefabInstance(ShooterBullet prefab) => instance.GetInstance(prefab);

		private ShooterBullet GetInstance(ShooterBullet prefab) {
			if (!pools.ContainsKey(prefab.name)) pools.Add(prefab.name, new Queue<ShooterBullet>());
			if (pools[prefab.name].Count == 0) {
				var newInstance = Instantiate(prefab);
				newInstance.name = prefab.name;
				newInstance.gameObject.SetActive(false);
				pools[prefab.name].Enqueue(newInstance);
			}
			var item = pools[prefab.name].Dequeue();
			item.onHit.AddListenerOnce(PoolBullet);
			return item;
		}

		private void PoolBullet(ShooterBullet bullet) {
			if (!pools.ContainsKey(bullet.name)) pools.Add(bullet.name, new Queue<ShooterBullet>());
			bullet.onHit.RemoveListener(PoolBullet);
			bullet.gameObject.SetActive(false);
			pools[bullet.name].Enqueue(bullet);
		}
	}
}