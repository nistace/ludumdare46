using LD46.Menu.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LD46.Menu {
	public class MenuSceneManager : MonoBehaviour {
		[SerializeField] protected MenuUi _ui;

		private void Awake() {
			_ui.onStartGameClicked.AddListener(StartGame);
		}

		private static void StartGame() {
			SceneManager.LoadSceneAsync("Game");
		}
	}
}