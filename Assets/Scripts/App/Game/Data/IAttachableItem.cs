using UnityEngine;

public interface IAttachableItem {
	Transform transform { get; }
	void AttachTo(Transform parent, Vector2? setPosition);
	void Detach(Transform parent, Vector2? force);
}