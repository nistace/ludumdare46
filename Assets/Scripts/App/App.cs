using UnityEngine;
using UnityEngine.InputSystem;

namespace LD46 {
	public class App : MonoBehaviour {
		private static App instance { get; set; }

		[SerializeField] protected AudioSettingsUi _audioSettingsUi;
		[SerializeField] protected bool            _audioSettingsVisibleOnStart = true;

		private void Awake() {
			if (!instance) instance = this;
			if (instance != this) Destroy(gameObject);
			else {
				DontDestroyOnLoad(gameObject);
				_audioSettingsUi.gameObject.SetActive(_audioSettingsVisibleOnStart);
				_audioSettingsUi.onMusicSliderChanged.AddListenerOnce(HandleMusicVolumeChanged);
				_audioSettingsUi.onSfxSliderChanged.AddListenerOnce(HandleSfxVolumeChanged);
				_audioSettingsUi.Init(AudioManager.Music.volume, AudioManager.Sfx.volume);

				Inputs.controls.Global.ToggleAudioSettings.AddPerformListenerOnce(ToggleAudioSettingsVisible);
				Inputs.controls.Global.ToggleAudioSettings.Enable();
			}
		}

		private void ToggleAudioSettingsVisible(InputAction.CallbackContext obj) => _audioSettingsUi.gameObject.SetActive(!_audioSettingsUi.gameObject.activeSelf);

		private static void HandleMusicVolumeChanged(float value) => AudioManager.Music.volume = value;
		private static void HandleSfxVolumeChanged(float value) => AudioManager.Sfx.SetVolume(value);
	}
}