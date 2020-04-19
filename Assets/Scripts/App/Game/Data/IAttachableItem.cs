using UnityEngine;

namespace LD46.Game.Data {
	public interface IAttachableItem {
		Transform transform { get; }
		void AttachTo(Transform parent, Vector2? setPosition);
		void Detach(Vector2? force);
	}
}