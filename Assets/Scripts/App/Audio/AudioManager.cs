using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	private static AudioManager instance { get; set; }

	[SerializeField] protected AudioSource       _musicSource;
	[SerializeField] protected AudioSource       _sfxPrefab;
	[SerializeField] protected float             _sfxVolume;
	[SerializeField] protected float             _initialMusicVolume;
	[SerializeField] protected AudioSfxClipSet[] _sfxClipsPerCategory;

	private void Awake() {
		if (!instance) instance = this;
		if (instance != this) Destroy(gameObject);
		else {
			Music.volume = _initialMusicVolume;
			Sfx.SetVolume(_sfxVolume);
			Sfx.LoadCategories(_sfxClipsPerCategory);
		}
	}

	private void Update() {
		Sfx.GatherDoneSources();
	}

	public static class Music {
		public static float volume {
			get => instance._musicSource.volume;
			set => instance._musicSource.volume = value;
		}
	}

	public static class Sfx {
		private static float volume {
			get => instance._sfxVolume;
			set => instance._sfxVolume = value;
		}

		private static Dictionary<AudioSfxCategory, List<AudioClip>> clips { get; } = new Dictionary<AudioSfxCategory, List<AudioClip>>();

		private static Queue<AudioSource> pool    { get; } = new Queue<AudioSource>();
		private static List<AudioSource>  playing { get; } = new List<AudioSource>();

		public static void SetVolume(float volume) {
			Sfx.volume = volume;
			foreach (var audioSource in playing) audioSource.volume = volume;
		}

		public static void Play(AudioClip clip) {
			if (pool.Count == 0) pool.Enqueue(Instantiate(instance._sfxPrefab, instance.transform));
			var source = pool.Dequeue();
			source.gameObject.SetActive(true);
			playing.Add(source);
			source.volume = volume;
			source.clip = clip;
			source.Play();
		}

		public static void GatherDoneSources() {
			for (var i = 0; i < playing.Count; ++i) {
				if (playing[i].isPlaying) continue;
				pool.Enqueue(playing[i]);
				playing[i].gameObject.SetActive(false);
				playing.RemoveAt(i);
				i--;
			}
		}

		public static void Play(AudioSfxCategory category) {
			if (TryGetRandomClip(category, out var clip)) Play(clip);
		}

		public static void LoadCategories(IEnumerable<AudioSfxClipSet> clipSets) {
			clips.Clear();
			foreach (var clipSet in clipSets) {
				if (!clips.ContainsKey(clipSet.category)) clips.Add(clipSet.category, new List<AudioClip>());
				clips[clipSet.category].AddRange(clipSet.clips);
			}
		}

		private static bool TryGetRandomClip(AudioSfxCategory category, out AudioClip clip) {
			clip = null;
			if (!clips.ContainsKey(category) || clips[category].Count == 0) return false;
			clip = clips[category][Random.Range(0, clips[category].Count)];
			return clip;
		}
	}
}