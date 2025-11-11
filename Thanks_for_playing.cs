using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class Thanks_for_playing : MonoBehaviour
{
	// Token: 0x0600051B RID: 1307 RVA: 0x000186DB File Offset: 0x000168DB
	private void Awake()
	{
		this.Canvas_tfp.SetActive(false);
		this.tfp_text.alpha = 0f;
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x000186F9 File Offset: 0x000168F9
	private void OnEnable()
	{
		EA.GAME_COMPLITE = (Action)Delegate.Combine(EA.GAME_COMPLITE, new Action(this.Event_play));
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x0001871B File Offset: 0x0001691B
	private void OnDisable()
	{
		EA.GAME_COMPLITE = (Action)Delegate.Remove(EA.GAME_COMPLITE, new Action(this.Event_play));
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x0001873D File Offset: 0x0001693D
	[ContextMenu("Event_play")]
	public void Event_play()
	{
		base.StartCoroutine(this.IE_Thanks_for_playing());
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x0001874C File Offset: 0x0001694C
	private IEnumerator IE_Thanks_for_playing()
	{
		this.Canvas_tfp.SetActive(true);
		this.tfp_text.alpha = 0f;
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime;
			this.tfp_text.alpha = value;
		}
		yield return new WaitForSeconds(this.delay_time);
		while (value > 0f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value -= Time.deltaTime;
			this.tfp_text.alpha = value;
		}
		this.Canvas_tfp.SetActive(false);
		yield break;
	}

	// Token: 0x04000578 RID: 1400
	[SerializeField]
	private GameObject Canvas_tfp;

	// Token: 0x04000579 RID: 1401
	[SerializeField]
	private TMP_Text tfp_text;

	// Token: 0x0400057A RID: 1402
	[SerializeField]
	private float delay_time;
}
