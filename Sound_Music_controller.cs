using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

// Token: 0x02000036 RID: 54
public class Sound_Music_controller : MonoBehaviour
{
	// Token: 0x06000184 RID: 388 RVA: 0x00009399 File Offset: 0x00007599
	public void update_slider_value_music(float value)
	{
		Setting_st_data.Update_Volume_Music(value);
	}

	// Token: 0x06000185 RID: 389 RVA: 0x000093A1 File Offset: 0x000075A1
	public void update_slider_value_sound(float value)
	{
		Setting_st_data.Update_Volume_Sound(value);
	}

	// Token: 0x06000186 RID: 390 RVA: 0x000093AC File Offset: 0x000075AC
	public void Reset_all_value()
	{
		D_Setting d_Setting = new D_Setting();
		this.slider_value_music.value = d_Setting.Music_Mixer;
		this.slider_value_sound.value = d_Setting.Sound_Mixer;
	}

	// Token: 0x04000194 RID: 404
	[SerializeField]
	private AudioMixerGroup Mixer_music;

	// Token: 0x04000195 RID: 405
	[SerializeField]
	private AudioMixerGroup Mixer_sound;

	// Token: 0x04000196 RID: 406
	[SerializeField]
	private AnimationCurve Volume_Curve;

	// Token: 0x04000197 RID: 407
	[SerializeField]
	private Slider slider_value_music;

	// Token: 0x04000198 RID: 408
	[SerializeField]
	private Slider slider_value_sound;
}
