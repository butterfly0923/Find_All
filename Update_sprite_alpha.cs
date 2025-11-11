using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000075 RID: 117
public class Update_sprite_alpha : MonoBehaviour
{
	// Token: 0x0600030D RID: 781 RVA: 0x0000F9D0 File Offset: 0x0000DBD0
	[ContextMenu("Test_1_Event_stady_update")]
	public void Event_stady_update()
	{
		base.StartCoroutine(this.IE_event_stady_update());
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0000F9DF File Offset: 0x0000DBDF
	private IEnumerator IE_event_stady_update()
	{
		base.StartCoroutine(this.IE_event_stady_start());
		yield return new WaitForSeconds(this.delay_stady_end);
		base.StartCoroutine(this.IE_event_stady_end());
		yield break;
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0000F9EE File Offset: 0x0000DBEE
	private IEnumerator IE_event_stady_start()
	{
		for (int i = 0; i < this.sprite_stady_start.Length; i++)
		{
			this.sprite_stady_start[i].gameObject.SetActive(true);
		}
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_alpha_start;
			for (int j = 0; j < this.sprite_stady_start.Length; j++)
			{
				this.sprite_stady_start[j].material.SetFloat("_Alpha", Mathf.Lerp(1f, 0f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		for (int k = 0; k < this.sprite_stady_start.Length; k++)
		{
			this.sprite_stady_start[k].gameObject.SetActive(false);
		}
		yield break;
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0000F9FD File Offset: 0x0000DBFD
	private IEnumerator IE_event_stady_end()
	{
		for (int i = 0; i < this.sprite_stady_end.Length; i++)
		{
			this.sprite_stady_end[i].gameObject.SetActive(true);
		}
		float value = 0f;
		while (value < 1f)
		{
			value += Time.deltaTime * this.speed_alpha_end;
			for (int j = 0; j < this.sprite_stady_end.Length; j++)
			{
				this.sprite_stady_end[j].color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x040003D4 RID: 980
	[SerializeField]
	private SpriteRenderer[] sprite_stady_start;

	// Token: 0x040003D5 RID: 981
	[SerializeField]
	private SpriteRenderer[] sprite_stady_end;

	// Token: 0x040003D6 RID: 982
	[SerializeField]
	private float speed_alpha_start;

	// Token: 0x040003D7 RID: 983
	[SerializeField]
	private float speed_alpha_end;

	// Token: 0x040003D8 RID: 984
	[SerializeField]
	private float delay_stady_end;
}
