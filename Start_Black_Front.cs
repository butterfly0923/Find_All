using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200003B RID: 59
public class Start_Black_Front : MonoBehaviour
{
	// Token: 0x06000199 RID: 409 RVA: 0x00009651 File Offset: 0x00007851
	private void Awake()
	{
		this.Black_image.enabled = true;
	}

	// Token: 0x0600019A RID: 410 RVA: 0x0000965F File Offset: 0x0000785F
	private void Start()
	{
		base.StartCoroutine(this.Start_black_false());
	}

	// Token: 0x0600019B RID: 411 RVA: 0x0000966E File Offset: 0x0000786E
	private IEnumerator Start_black_false()
	{
		float U = 1f;
		while (U > 0f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			U -= Time.deltaTime;
			this.Black_image.color = new Color(this.color_black.r, this.color_black.g, this.color_black.b, U);
		}
		Object.Destroy(base.gameObject);
		yield break;
	}

	// Token: 0x040001A4 RID: 420
	[SerializeField]
	private Image Black_image;

	// Token: 0x040001A5 RID: 421
	[SerializeField]
	private Color color_black;
}
