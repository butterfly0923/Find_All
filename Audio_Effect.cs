using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x0200004D RID: 77
public class Audio_Effect : MonoBehaviour
{
	// Token: 0x06000210 RID: 528 RVA: 0x0000B41C File Offset: 0x0000961C
	public void Set_Audio_Play(AudioClip clip_value, float speed_play, float volume_play, AudioMixerGroup mixer_value, bool turn_down_value, float down_value, float start_time_value)
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = clip_value;
		audioSource.outputAudioMixerGroup = mixer_value;
		audioSource.loop = false;
		audioSource.pitch = speed_play;
		audioSource.volume = volume_play;
		audioSource.time = start_time_value;
		audioSource.Play();
		float num = clip_value.length / speed_play;
		if (turn_down_value)
		{
			Action<float, float> music_turn_down = EA.Music_turn_down;
			if (music_turn_down != null)
			{
				music_turn_down(num, down_value);
			}
		}
		Debug.Log("speed - " + num.ToString() + 1f.ToString());
		Object.Destroy(this.GameObject(), num + 1f);
	}
}
