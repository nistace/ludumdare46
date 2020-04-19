using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

	public class MenuUi : MonoBehaviour {
		[SerializeField] protected Button _startGameButton;

		public UnityEvent onStartGameClicked => _startGameButton.onClick;
	}