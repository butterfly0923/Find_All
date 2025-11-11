using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200008B RID: 139
public class Open_door_point : MonoBehaviour
{
	// Token: 0x06000390 RID: 912 RVA: 0x00011896 File Offset: 0x0000FA96
	public void Start()
	{
		this.coroutine = base.StartCoroutine(this.IE_start_alpha());
	}

	// Token: 0x06000391 RID: 913 RVA: 0x000118AA File Offset: 0x0000FAAA
	private IEnumerator IE_start_alpha()
	{
		float value = 0f;
		Color color_value = new Color(1f, 1f, 1f, 0f);
		while (value < 1f)
		{
			value += Time.deltaTime * this.speed_value;
			color_value.a = value;
			for (int i = 0; i < this.all_sprite.Length; i++)
			{
				this.all_sprite[i].color = color_value;
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.animation.Play();
		yield break;
	}

	// Token: 0x06000392 RID: 914 RVA: 0x000118B9 File Offset: 0x0000FAB9
	public void off_all_sprite()
	{
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_end_alpha());
	}

	// Token: 0x06000393 RID: 915 RVA: 0x000118E1 File Offset: 0x0000FAE1
	private IEnumerator IE_end_alpha()
	{
		this.animation.Stop();
		List<Color> list = new List<Color>();
		List<float> alpha_color = new List<float>();
		for (int i = 0; i < this.all_sprite.Length; i++)
		{
			list.Add(this.all_sprite[i].color);
			alpha_color.Add(this.all_sprite[i].color.a);
		}
		float value = 0f;
		while (value <= 1f)
		{
			value += Time.deltaTime * this.speed_value;
			for (int j = 0; j < this.all_sprite.Length; j++)
			{
				this.all_sprite[j].color = new Color(this.all_sprite[j].color.r, this.all_sprite[j].color.g, this.all_sprite[j].color.b, Mathf.Lerp(alpha_color[j], 0f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x04000426 RID: 1062
	[SerializeField]
	private SpriteRenderer[] all_sprite;

	// Token: 0x04000427 RID: 1063
	[SerializeField]
	private Animation animation;

	// Token: 0x04000428 RID: 1064
	[SerializeField]
	private float speed_value;

	// Token: 0x04000429 RID: 1065
	private Coroutine coroutine;
}
