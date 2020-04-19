using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour {
	[SerializeField] protected Vector3    _cameraPosition         = new Vector3(0, 0, -10);
	[SerializeField] protected float      _cameraOrthographicSize = 5;
	[SerializeField] protected Transform  _respawnPosition;
	[SerializeField] protected GameObject _backwardBlocker;
	[SerializeField] protected GameObject _forwardBlocker;
	[SerializeField] protected GameObject _levelItemContainer;
	[SerializeField] protected GameObject _levelUi;
	[SerializeField] protected LevelExit  _exit;

	public Vector3 cameraPosition         => _cameraPosition;
	public float   cameraOrthographicSize => _cameraOrthographicSize;

	public UnityEvent onExitReached => _exit.onReached;

	public void SetLevelEnabled(bool enabled) {
		_backwardBlocker.SetActive(enabled);
		_forwardBlocker.SetActive(enabled);
		_exit.enabled = enabled;
		_levelItemContainer.SetActive(enabled);
		if (_levelUi?.gameObject) _levelUi.gameObject.SetActive(enabled);
	}

	public void Respawn(Robot robot) {
		robot.transform.position = _respawnPosition.position;
	}
}