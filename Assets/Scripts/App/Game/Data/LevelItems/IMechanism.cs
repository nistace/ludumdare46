using UnityEngine.Events;

public interface IMechanism {
	bool isOn { get; }

	UnityEvent onStatusChanged { get; }

	void SetOn(bool on, bool force = false);
	void ResetOn();
}