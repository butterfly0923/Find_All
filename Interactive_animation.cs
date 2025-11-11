using System;
using UnityEngine;

// Token: 0x0200007D RID: 125
public class Interactive_animation : Interactive
{
	// Token: 0x06000345 RID: 837 RVA: 0x0001032C File Offset: 0x0000E52C
	public override void Set(Stady_Find stady_value, int index_value, bool load_status_value, bool first_status_value = false)
	{
		base.Set(stady_value, index_value, load_status_value, first_status_value);
		if (this.animation_main == null && base.GetComponent<Animation>() != null)
		{
			this.animation_main = base.GetComponent<Animation>();
		}
		if (!this.current_status)
		{
			if (this.g_object.GetComponent<Interactive_object>() == null)
			{
				this.interactive_object = this.g_object.AddComponent<Interactive_object>();
				this.interactive_object.set_parent(this);
			}
			if (this.g_object.GetComponent<Collider>() == null)
			{
				this.go_collider = this.g_object.AddComponent<BoxCollider>();
				return;
			}
		}
		else
		{
			this.load_animation();
		}
	}

	// Token: 0x06000346 RID: 838 RVA: 0x000103CF File Offset: 0x0000E5CF
	public override void Click_Collider_object(GameObject go_value)
	{
		this.play_animation();
		this.go_collider.enabled = false;
		this.current_status = true;
		base.Update_data();
	}

	// Token: 0x06000347 RID: 839 RVA: 0x000103F0 File Offset: 0x0000E5F0
	private void play_animation()
	{
		this.animation_main.Play();
	}

	// Token: 0x06000348 RID: 840 RVA: 0x00010400 File Offset: 0x0000E600
	private void load_animation()
	{
		this.animation_main.Stop();
		float time = this.animation_main.clip.length * this.animation_main.clip.frameRate;
		this.animation_main.clip.SampleAnimation(this.animation_main.gameObject, time);
	}

	// Token: 0x040003F4 RID: 1012
	[SerializeField]
	private GameObject g_object;

	// Token: 0x040003F5 RID: 1013
	[SerializeField]
	private Collider go_collider;

	// Token: 0x040003F6 RID: 1014
	[SerializeField]
	private Interactive_object interactive_object;

	// Token: 0x040003F7 RID: 1015
	[SerializeField]
	private Animation animation_main;
}
