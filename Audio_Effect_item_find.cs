using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
public class Audio_Effect_item_find : MonoBehaviour
{
	// Token: 0x06000212 RID: 530 RVA: 0x0000B4C2 File Offset: 0x000096C2
	private void OnEnable()
	{
		EA.Audio_effect_find_item_play = (Action)Delegate.Combine(EA.Audio_effect_find_item_play, new Action(this.Find_item));
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0000B4E4 File Offset: 0x000096E4
	private void OnDisable()
	{
		EA.Audio_effect_find_item_play = (Action)Delegate.Remove(EA.Audio_effect_find_item_play, new Action(this.Find_item));
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0000B506 File Offset: 0x00009706
	private void Find_item()
	{
		if (SL_Data.d_Setting.Sound_Item_Find)
		{
			this.audio_source.Play();
		}
	}

	// Token: 0x04000250 RID: 592
	[SerializeField]
	private AudioSource audio_source;
}
