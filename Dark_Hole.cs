using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000012 RID: 18
public class Dark_Hole : MonoBehaviour
{
	// Token: 0x06000050 RID: 80 RVA: 0x00002F1B File Offset: 0x0000111B
	private void OnEnable()
	{
		Events_Menu_UI.count_find_items = (Action<int>)Delegate.Combine(Events_Menu_UI.count_find_items, new Action<int>(this.Update_size));
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002F3D File Offset: 0x0000113D
	private void OnDisable()
	{
		Events_Menu_UI.count_find_items = (Action<int>)Delegate.Remove(Events_Menu_UI.count_find_items, new Action<int>(this.Update_size));
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002F60 File Offset: 0x00001160
	private void Update_size(int item_count_value)
	{
		this.dark_hole_image.gameObject.SetActive(true);
		if (!this.first_play)
		{
			if (item_count_value >= 100)
			{
				this.dark_hole_image.gameObject.SetActive(false);
				base.enabled = false;
				return;
			}
			this.first_play = true;
		}
		if (!this.events_end)
		{
			if (item_count_value >= 100)
			{
				this.events_end = true;
				if (this.coroutine != null)
				{
					base.StopCoroutine(this.coroutine);
				}
				this.coroutine = base.StartCoroutine(this.IE_end_size());
				return;
			}
			this.item_count = item_count_value;
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_first_size());
		}
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00003013 File Offset: 0x00001213
	private IEnumerator IE_first_size()
	{
		float size_hole_start = this.dark_hole_image.transform.localScale.x;
		float size_hole_end = this.size_hole.Evaluate((float)this.item_count);
		float value = 0f;
		while (value <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_size_first;
			float num = Mathf.Lerp(size_hole_start, size_hole_end, value);
			this.dark_hole_image.transform.localScale = new Vector3(num, num, 1f);
		}
		yield break;
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00003022 File Offset: 0x00001222
	private IEnumerator IE_end_size()
	{
		float size_hole_start = this.dark_hole_image.transform.localScale.x;
		float size_hole_end = 3f;
		float value = 0f;
		Color color_value = this.dark_hole_image.color;
		while (value <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_size_first;
			float num = Mathf.Lerp(size_hole_start, size_hole_end, value);
			color_value.a = Mathf.Lerp(1f, 0f, value);
			this.dark_hole_image.color = color_value;
			this.dark_hole_image.transform.localScale = new Vector3(num, num, 1f);
			Image[] array = this.add_dark_image;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].color = color_value;
			}
		}
		this.dark_hole_image.gameObject.SetActive(false);
		base.enabled = false;
		yield break;
	}

	// Token: 0x0400005C RID: 92
	[SerializeField]
	private Image dark_hole_image;

	// Token: 0x0400005D RID: 93
	[SerializeField]
	private Image[] add_dark_image;

	// Token: 0x0400005E RID: 94
	[SerializeField]
	private AnimationCurve size_hole;

	// Token: 0x0400005F RID: 95
	[SerializeField]
	private float speed_size_first;

	// Token: 0x04000060 RID: 96
	[SerializeField]
	private bool first_play;

	// Token: 0x04000061 RID: 97
	[SerializeField]
	private int item_count;

	// Token: 0x04000062 RID: 98
	[SerializeField]
	private bool events_end;

	// Token: 0x04000063 RID: 99
	private Coroutine coroutine;
}
