using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000027 RID: 39
public class Reset_Frame_and_Scene : MonoBehaviour
{
	// Token: 0x060000F5 RID: 245 RVA: 0x00007079 File Offset: 0x00005279
	private void Start()
	{
		this.start_Setting();
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x00007084 File Offset: 0x00005284
	private void start_Setting()
	{
		this.back_black.color = new Color(this.back_black.color.r, this.back_black.color.g, this.back_black.color.b, 0f);
		this.front_black.color = new Color(this.front_black.color.r, this.front_black.color.g, this.front_black.color.b, 0f);
		this.back_black.enabled = false;
		this.front_black.enabled = false;
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x00007133 File Offset: 0x00005333
	public void Frame_Reset_On()
	{
		this.start_coroutine(this.IE_reset_frame_on());
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00007141 File Offset: 0x00005341
	public void Frame_Reset_Off()
	{
		this.start_coroutine(this.IE_reset_frame_off());
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x0000714F File Offset: 0x0000534F
	public void Exit_Game()
	{
		this.start_coroutine(this.IE_exit_game());
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000715D File Offset: 0x0000535D
	private void start_coroutine(IEnumerator ienumerator)
	{
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(ienumerator);
	}

	// Token: 0x060000FB RID: 251 RVA: 0x00007180 File Offset: 0x00005380
	private IEnumerator IE_reset_frame_on()
	{
		float value_alpha = 0f;
		this.back_black.color = new Color(this.back_black.color.r, this.back_black.color.g, this.back_black.color.b, this.back_alpha_curve.Evaluate(value_alpha));
		this.back_black.enabled = true;
		while (value_alpha < 1f)
		{
			value_alpha += Time.deltaTime * this.speed_alpha_back;
			this.back_black.color = new Color(this.back_black.color.r, this.back_black.color.g, this.back_black.color.b, this.back_alpha_curve.Evaluate(value_alpha));
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0000718F File Offset: 0x0000538F
	private IEnumerator IE_reset_frame_off()
	{
		float value_alpha = 1f;
		this.back_black.color = new Color(this.back_black.color.r, this.back_black.color.g, this.back_black.color.b, this.back_alpha_curve.Evaluate(value_alpha));
		while (value_alpha > 0f)
		{
			value_alpha -= Time.deltaTime * this.speed_alpha_back;
			this.back_black.color = new Color(this.back_black.color.r, this.back_black.color.g, this.back_black.color.b, this.back_alpha_curve.Evaluate(value_alpha));
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.back_black.enabled = false;
		yield break;
	}

	// Token: 0x060000FD RID: 253 RVA: 0x0000719E File Offset: 0x0000539E
	public IEnumerator IE_exit_game()
	{
		float value_alpha = 0f;
		this.front_black.color = new Color(this.front_black.color.r, this.front_black.color.g, this.front_black.color.b, this.front_alpha_curve.Evaluate(value_alpha));
		this.front_black.enabled = true;
		while (value_alpha < 1f)
		{
			value_alpha += Time.deltaTime * this.speed_alpha_back;
			this.front_black.color = new Color(this.front_black.color.r, this.front_black.color.g, this.front_black.color.b, this.front_alpha_curve.Evaluate(value_alpha));
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x04000108 RID: 264
	[SerializeField]
	private Image back_black;

	// Token: 0x04000109 RID: 265
	[SerializeField]
	private Image front_black;

	// Token: 0x0400010A RID: 266
	[SerializeField]
	private AnimationCurve back_alpha_curve;

	// Token: 0x0400010B RID: 267
	[SerializeField]
	private AnimationCurve front_alpha_curve;

	// Token: 0x0400010C RID: 268
	[SerializeField]
	private float speed_alpha_back;

	// Token: 0x0400010D RID: 269
	[SerializeField]
	private float speed_alpha_front;

	// Token: 0x0400010E RID: 270
	private Coroutine coroutine;
}
