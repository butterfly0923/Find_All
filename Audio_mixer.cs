using System;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x020000B1 RID: 177
public class Audio_mixer : MonoBehaviour
{
	// Token: 0x06000509 RID: 1289 RVA: 0x0001856D File Offset: 0x0001676D
	private void Awake()
	{
		Setting_st_data.Set_Mixer_Group(this.sound_group, this.music_group, this.voice_group, this.volume_curve);
	}

	// Token: 0x04000563 RID: 1379
	[SerializeField]
	private AudioMixerGroup sound_group;

	// Token: 0x04000564 RID: 1380
	[SerializeField]
	private AudioMixerGroup music_group;

	// Token: 0x04000565 RID: 1381
	[SerializeField]
	private AudioMixerGroup voice_group;

	// Token: 0x04000566 RID: 1382
	[SerializeField]
	private AnimationCurve volume_curve;
}
