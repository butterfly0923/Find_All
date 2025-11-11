using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x02000043 RID: 67
public class Color_Menu : MonoBehaviour
{
	// Token: 0x060001B6 RID: 438 RVA: 0x00009A2F File Offset: 0x00007C2F
	private void Awake()
	{
		this.material_main.SetFloat("Color_Alpha_Sc", -10f);
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00009A48 File Offset: 0x00007C48
	public void Color_menu_load()
	{
		this.material_main.SetFloat("Color_Alpha_Sc", 10f);
		for (int i = 0; i < this.text_color.Length; i++)
		{
			this.text_color[i].color = Color.Lerp(this.start, this.end, 1f);
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00009AA0 File Offset: 0x00007CA0
	public void Color_menu_update()
	{
		base.StartCoroutine(this.IE_White_Color());
		base.StartCoroutine(this.IE_White_Color_Text());
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00009ABC File Offset: 0x00007CBC
	private IEnumerator IE_White_Color()
	{
		float value_color = -10f;
		while (value_color <= 10f)
		{
			value_color += 30f * Time.deltaTime;
			this.material_main.SetFloat("Color_Alpha_Sc", value_color);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.material_main.SetFloat("Color_Alpha_Sc", 10f);
		yield break;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00009ACB File Offset: 0x00007CCB
	private IEnumerator IE_White_Color_Text()
	{
		float value_color = 0f;
		while (value_color <= 1f)
		{
			value_color += 30f * Time.deltaTime;
			for (int i = 0; i < this.text_color.Length; i++)
			{
				this.text_color[i].color = Color.Lerp(this.start, this.end, value_color);
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x040001D6 RID: 470
	[SerializeField]
	private TMP_Text[] text_color;

	// Token: 0x040001D7 RID: 471
	[SerializeField]
	private Color start;

	// Token: 0x040001D8 RID: 472
	[SerializeField]
	private Color end;

	// Token: 0x040001D9 RID: 473
	[SerializeField]
	private Material material_main;
}
