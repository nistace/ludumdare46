using System;
using UnityEngine;

[Serializable]
public class AudioSfxClipSet {
	[SerializeField] protected AudioSfxCategory _category;
	[SerializeField] protected AudioClip[]      _clips;

	public AudioSfxCategory category => _category;
	public AudioClip[]      clips    => _clips;
}