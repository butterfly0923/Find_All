using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200002C RID: 44
public class Button_Puzzle_On : MonoBehaviour
{
	// Token: 0x0600011B RID: 283 RVA: 0x00007628 File Offset: 0x00005828
	private void Awake()
	{
		this.sprite_button = base.GetComponent<SpriteRenderer>();
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00007636 File Offset: 0x00005836
	public void Puzzle_On()
	{
		UnityEvent unityEvent = this.event_click;
		if (unityEvent == null)
		{
			return;
		}
		unityEvent.Invoke();
	}

	// Token: 0x0600011D RID: 285 RVA: 0x00007648 File Offset: 0x00005848
	public void Button_On_Find()
	{
		base.StartCoroutine(this.IE_Button_On_Find());
	}

	// Token: 0x0600011E RID: 286 RVA: 0x00007657 File Offset: 0x00005857
	private IEnumerator IE_Button_On_Find()
	{
		float value = 0f;
		while (value < 1f)
		{
			this.sprite_button.color = new Color(1f, 1f, 1f, value);
			this.count_text.alpha = value;
			value += Time.deltaTime * 2f;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x0400012C RID: 300
	[SerializeField]
	private UnityEvent event_click;

	// Token: 0x0400012D RID: 301
	private SpriteRenderer sprite_button;

	// Token: 0x0400012E RID: 302
	[SerializeField]
	private TMP_Text count_text;
}
