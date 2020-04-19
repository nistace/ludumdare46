using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour {
	[SerializeField] protected TMP_Text          _levelCounter;
	[SerializeField] protected GameOverMessageUi _gameOverUi;

	private void Awake() {
		SetGameOverUiVisible(false);
	}

	public void SetLevelName(string name) {
		_levelCounter.text = name;
	}

	public void SetGameOverUiVisible(bool visible) => _gameOverUi.SetVisible(visible);
}