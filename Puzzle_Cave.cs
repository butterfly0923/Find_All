using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class Puzzle_Cave : MonoBehaviour
{
	// Token: 0x0600002C RID: 44 RVA: 0x000029F7 File Offset: 0x00000BF7
	public void Start_sprite_alpha()
	{
		if (this._coroutine != null)
		{
			base.StopCoroutine(this._coroutine);
		}
		this._coroutine = base.StartCoroutine(this.IE_start_sprite_alpha());
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002A1F File Offset: 0x00000C1F
	private IEnumerator IE_start_sprite_alpha()
	{
		GameObject[] array = this.sprite_off_find_complite;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		SpriteRenderer[] array2 = this.sprites_off;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].enabled = true;
		}
		base.StartCoroutine(this.IE_sprite_off_alpha_zero());
		yield return new WaitForSeconds(this.delay_on_start);
		base.StartCoroutine(this.IE_sprite_on_alpha_full());
		yield break;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002A2E File Offset: 0x00000C2E
	private IEnumerator IE_sprite_off_alpha_zero()
	{
		float value = 0f;
		while (value < 1f)
		{
			value += this.speed_off * Time.deltaTime;
			SpriteRenderer[] array = this.sprites_off;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002A3D File Offset: 0x00000C3D
	private IEnumerator IE_sprite_on_alpha_full()
	{
		float value = 0f;
		while (value < 1f)
		{
			value += this.speed_on * Time.deltaTime;
			SpriteRenderer[] array = this.sprites_on;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002A4C File Offset: 0x00000C4C
	public void Load_sprite_alpha()
	{
		GameObject[] array = this.sprite_off_find_complite;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(false);
		}
		SpriteRenderer[] array2 = this.sprites_off;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].enabled = true;
		}
		array2 = this.sprites_on;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].color = new Color(1f, 1f, 1f, 1f);
		}
		array2 = this.sprites_off;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].color = new Color(1f, 1f, 1f, 0f);
		}
	}

	// Token: 0x0400002D RID: 45
	[SerializeField]
	private GameObject[] sprite_off_find_complite;

	// Token: 0x0400002E RID: 46
	[SerializeField]
	private SpriteRenderer[] sprites_off;

	// Token: 0x0400002F RID: 47
	[SerializeField]
	private SpriteRenderer[] sprites_on;

	// Token: 0x04000030 RID: 48
	[SerializeField]
	private float speed_on;

	// Token: 0x04000031 RID: 49
	[SerializeField]
	private float delay_on_start;

	// Token: 0x04000032 RID: 50
	[SerializeField]
	private float speed_off;

	// Token: 0x04000033 RID: 51
	private Coroutine _coroutine;
}
