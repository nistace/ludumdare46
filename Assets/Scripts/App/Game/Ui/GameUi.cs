using TMPro;
using UnityEngine;

public class GameUi : MonoBehaviour {
	[SerializeField] protected TMP_Text _levelCounter;

	public void SetLevelName(string name) {
		_levelCounter.text = name;
	}
}