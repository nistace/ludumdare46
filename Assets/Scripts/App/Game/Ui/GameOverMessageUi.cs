using TMPro;
using UnityEngine;

public class GameOverMessageUi : MonoBehaviour {
	[SerializeField] protected TMP_Text _commentText;
	[SerializeField] protected string[] _comments;

	public void SetVisible(bool visible) {
		gameObject.SetActive(visible);
		if (!visible) return;
		_commentText.text = GetRandomComment();
	}

	private string GetRandomComment() => _comments == null || _comments.Length == 0 ? string.Empty : _comments[Random.Range(0, _comments.Length)];
}