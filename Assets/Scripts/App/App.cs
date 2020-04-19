using UnityEngine;

namespace LD46 {
	public class App : MonoBehaviour {
		private static App instance { get; set; }

		private void Awake() {
			if (!instance) instance = this;
			if (instance != this) Destroy(gameObject);
			else DontDestroyOnLoad(gameObject);
		}
	}
}