using System;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x0200004F RID: 79
public class Audio_Effect_Player : MonoBehaviour
{
	// Token: 0x06000216 RID: 534 RVA: 0x0000B527 File Offset: 0x00009727
	private void Awake()
	{
		Audio_Effect_Player.st = this;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x0000B52F File Offset: 0x0000972F
	private void OnEnable()
	{
		EA.Audio_effect_Play = (Action<Enums_Audio.Effect>)Delegate.Combine(EA.Audio_effect_Play, new Action<Enums_Audio.Effect>(this.Play_Effect_Check));
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0000B551 File Offset: 0x00009751
	private void OnDisable()
	{
		EA.Audio_effect_Play = (Action<Enums_Audio.Effect>)Delegate.Remove(EA.Audio_effect_Play, new Action<Enums_Audio.Effect>(this.Play_Effect_Check));
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0000B573 File Offset: 0x00009773
	[ContextMenu("Play_Effect_Test")]
	private void Play_Effect_Test()
	{
		this.Play_Effect_Check(this.Effect);
	}

	// Token: 0x0600021A RID: 538 RVA: 0x0000B584 File Offset: 0x00009784
	private void Play_Effect_Check(Enums_Audio.Effect Effect_value)
	{
		if (Effect_value != Enums_Audio.Effect.Find_Item)
		{
			if (Effect_value != Enums_Audio.Effect.Find_Group)
			{
				goto IL_27;
			}
			if (SL_Data.d_Setting.Sound_Group_Find)
			{
				goto IL_27;
			}
		}
		else if (SL_Data.d_Setting.Sound_Item_Find)
		{
			goto IL_27;
		}
		return;
		IL_27:
		bool flag = false;
		int value = 0;
		Debug.Log(string.Format("Effect_value - {0}", Effect_value));
		for (int i = 0; i < this.audio_clips.Length; i++)
		{
			if (Effect_value == this.audio_clips[i].clip_name)
			{
				flag = true;
				value = i;
			}
		}
		if (!flag)
		{
			return;
		}
		this.Play_Effect_Instantiate(value);
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0000B608 File Offset: 0x00009808
	private void Play_Effect_Instantiate(int value)
	{
		Debug.Log(string.Format("VAR - {0}", value));
		Object.Instantiate<GameObject>(this.prefab_audio_effect.gameObject).GetComponent<Audio_Effect>().Set_Audio_Play(this.audio_clips[value].clip, this.audio_clips[value].speed, this.audio_clips[value].volume, this.mixer_sound, this.audio_clips[value].turn_down, this.audio_clips[value].volume_down, this.audio_clips[value].start_time);
	}

	// Token: 0x04000251 RID: 593
	[SerializeField]
	private Enums_Audio.Effect Effect;

	// Token: 0x04000252 RID: 594
	[SerializeField]
	private AudioMixerGroup mixer_sound;

	// Token: 0x04000253 RID: 595
	[SerializeField]
	private Structs.Audio_Clip[] audio_clips;

	// Token: 0x04000254 RID: 596
	[SerializeField]
	private Audio_Effect prefab_audio_effect;

	// Token: 0x04000255 RID: 597
	public static Audio_Effect_Player st;
}
