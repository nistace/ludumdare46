using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LD46.Menu.Ui {
	public class MenuUi : MonoBehaviour {
		[SerializeField] protected Button _startGameButton;

		public UnityEvent onStartGameClicked => _startGameButton.onClick;
	}
}