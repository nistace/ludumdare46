using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsUi : MonoBehaviour {
	[SerializeField] protected Slider   _musicSlider;
	[SerializeField] protected Slider   _sfxSlider;
	[SerializeField] protected TMP_Text _infoInput;

	public Slider.SliderEvent onMusicSliderChanged => _musicSlider.onValueChanged;
	public Slider.SliderEvent onSfxSliderChanged   => _sfxSlider.onValueChanged;

	public void Init(float musicVolume, float sfxVolume) {
		_musicSlider.SetValueWithoutNotify(musicVolume);
		_sfxSlider.SetValueWithoutNotify(sfxVolume);
		SetInfoInput();
	}

	private void SetInfoInput() {
		try {
			var action = Inputs.controls.Global.ToggleAudioSettings;
			_infoInput.text = $"Show / Hide anytime<br>using <b>{action.GetControl(action.GetNonCompositeBinding()).displayName}</b>";
		}
		catch (Exception e) {
			_infoInput.text = $"Show / Hide anytime<br>using <b>U</b>";
		}
	}
}