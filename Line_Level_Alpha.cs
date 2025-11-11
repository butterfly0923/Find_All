using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000089 RID: 137
public class Line_Level_Alpha : MonoBehaviour
{
	// Token: 0x06000385 RID: 901 RVA: 0x00011614 File Offset: 0x0000F814
	public void Alpha_Start_Full()
	{
		for (int i = 0; i < this.sprite_renderer.Length; i++)
		{
			this.sprite_renderer[i].color = new Color(1f, 1f, 1f, 1f);
		}
	}

	// Token: 0x06000386 RID: 902 RVA: 0x0001165A File Offset: 0x0000F85A
	public void Alpha_Update_Full()
	{
		base.StartCoroutine(this.IE_Alpha_Update_Full());
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00011669 File Offset: 0x0000F869
	private IEnumerator IE_Alpha_Update_Full()
	{
		float value_alpha = 0f;
		while (value_alpha <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_alpha += Time.deltaTime * this.alpha_speed;
			for (int i = 0; i < this.sprite_renderer.Length; i++)
			{
				this.sprite_renderer[i].color = new Color(1f, 1f, 1f, value_alpha);
			}
		}
		yield break;
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00011678 File Offset: 0x0000F878
	public void Alpha_Start_Zero()
	{
		for (int i = 0; i < this.sprite_renderer.Length; i++)
		{
			this.sprite_renderer[i].color = new Color(1f, 1f, 1f, 0f);
		}
	}

	// Token: 0x06000389 RID: 905 RVA: 0x000116BE File Offset: 0x0000F8BE
	public void Alpha_Update_Zero()
	{
		base.StartCoroutine(this.IE_Alpha_Update_Zero());
	}

	// Token: 0x0600038A RID: 906 RVA: 0x000116CD File Offset: 0x0000F8CD
	private IEnumerator IE_Alpha_Update_Zero()
	{
		float value_alpha = 1f;
		while (value_alpha >= 0f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_alpha -= Time.deltaTime * this.alpha_speed;
			for (int i = 0; i < this.sprite_renderer.Length; i++)
			{
				this.sprite_renderer[i].color = new Color(1f, 1f, 1f, value_alpha);
			}
		}
		yield break;
	}

	// Token: 0x04000420 RID: 1056
	[SerializeField]
	private SpriteRenderer[] sprite_renderer;

	// Token: 0x04000421 RID: 1057
	[SerializeField]
	private float alpha_speed = 1.5f;
}
