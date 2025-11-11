using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000014 RID: 20
public class Sound_Update_Stady : MonoBehaviour
{
	// Token: 0x06000059 RID: 89 RVA: 0x0000305F File Offset: 0x0000125F
	public void Stady_Update()
	{
		base.StartCoroutine(this.IE_Stady_Update());
	}

	// Token: 0x0600005A RID: 90 RVA: 0x0000306E File Offset: 0x0000126E
	private IEnumerator IE_Stady_Update()
	{
		this._fonSound_stady_1.Off_sound_stady();
		this._musicController_1.load_new_scene_music_false(1f);
		this.effect_update.Play();
		this.effect_update.loop = false;
		yield return new WaitForSeconds(1f);
		this._musicController_2.gameObject.SetActive(true);
		this._fonSound_stady_2.gameObject.SetActive(true);
		this._musicController_2.enabled = true;
		this._fonSound_stady_1.gameObject.SetActive(false);
		this._musicController_1.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00003080 File Offset: 0x00001280
	public void Start_2_stady()
	{
		Object.Destroy(this._musicController_1.gameObject);
		Object.Destroy(this._fonSound_stady_1.gameObject);
		this.effect_update.enabled = false;
		this._musicController_2.gameObject.SetActive(true);
		this._fonSound_stady_2.gameObject.SetActive(true);
		this._musicController_2.enabled = true;
	}

	// Token: 0x04000069 RID: 105
	[SerializeField]
	private AudioSource effect_update;

	// Token: 0x0400006A RID: 106
	[SerializeField]
	private Music_controller _musicController_1;

	// Token: 0x0400006B RID: 107
	[SerializeField]
	private Fon_Sound_Start_Filler_delete _fonSound_stady_1;

	// Token: 0x0400006C RID: 108
	[SerializeField]
	private Music_controller _musicController_2;

	// Token: 0x0400006D RID: 109
	[SerializeField]
	private Fon_Sound_Start_Filler_delete _fonSound_stady_2;
}
