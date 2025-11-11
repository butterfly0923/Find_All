using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000008 RID: 8
public class S1_E_Open_Door : MonoBehaviour
{
	// Token: 0x0600001F RID: 31 RVA: 0x00002670 File Offset: 0x00000870
	private void Awake()
	{
		this._spriteRenderer = base.gameObject.GetComponent<SpriteRenderer>();
		Color color = this._spriteRenderer.color;
		color.a = 0f;
		this._spriteRenderer.color = color;
	}

	// Token: 0x06000020 RID: 32 RVA: 0x000026B2 File Offset: 0x000008B2
	private IEnumerator IE_Open_door_alpha()
	{
		yield return new WaitForSeconds(this.delay_door);
		Color color_door = this._spriteRenderer.color;
		float start_alpha = color_door.a;
		float lerp_value = 0f;
		while (color_door.a < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			lerp_value += Time.deltaTime * this.speed_alpha;
			color_door.a = Mathf.Lerp(start_alpha, 1f, lerp_value);
			this._spriteRenderer.color = color_door;
		}
		yield break;
	}

	// Token: 0x06000021 RID: 33 RVA: 0x000026C1 File Offset: 0x000008C1
	public void Door_Open()
	{
		base.StartCoroutine(this.IE_Open_door_alpha());
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000026D0 File Offset: 0x000008D0
	public void Door_Open_Load()
	{
		Color color = this._spriteRenderer.color;
		color.a = 1f;
		this._spriteRenderer.color = color;
	}

	// Token: 0x0400001C RID: 28
	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	// Token: 0x0400001D RID: 29
	[SerializeField]
	private float delay_door;

	// Token: 0x0400001E RID: 30
	[SerializeField]
	private float speed_alpha;
}
