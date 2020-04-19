using UnityEngine;

public static class GameObjectExtension {
	public static bool TryGetComponentInParent<E>(this Component o, out E component) => o.gameObject.TryGetComponentInParent(out component);

	public static bool TryGetComponentInParent<E>(this GameObject o, out E component) {
		component = o.GetComponentInParent<E>();
		return component != null;
	}
}