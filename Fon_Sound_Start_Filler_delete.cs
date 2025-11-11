using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class Fon_Sound_Start_Filler_delete : MonoBehaviour
{
	// Token: 0x06000188 RID: 392 RVA: 0x000093E9 File Offset: 0x000075E9
	private void Start()
	{
		this.audioSource = base.gameObject.GetComponent<AudioSource>();
		this.audioSource.volume = 0f;
		base.StartCoroutine(this.Del_Sound_Filter());
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00009419 File Offset: 0x00007619
	private IEnumerator Del_Sound_Filter()
	{
		yield return new WaitForSeconds(3f);
		float I = 0f;
		while (I < 1f)
		{
			I += Time.deltaTime * this.speed_max_volume;
			this.audioSource.volume = Mathf.Lerp(0f, this.max_volume, I);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00009428 File Offset: 0x00007628
	public void Off_sound_stady()
	{
		base.StartCoroutine(this.IE_off());
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00009437 File Offset: 0x00007637
	private IEnumerator IE_off()
	{
		float I = 1f;
		while (I > 0f)
		{
			I -= Time.deltaTime * this.speed_max_volume;
			this.audioSource.volume = Mathf.Lerp(this.max_volume, 0f, I);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x04000199 RID: 409
	private AudioSource audioSource;

	// Token: 0x0400019A RID: 410
	[SerializeField]
	private float max_volume;

	// Token: 0x0400019B RID: 411
	[SerializeField]
	private float speed_max_volume;
}
