using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000013 RID: 19
public class Forest_New_Stady : MonoBehaviour
{
	// Token: 0x06000056 RID: 86 RVA: 0x00003039 File Offset: 0x00001239
	[ContextMenu("Update_stady")]
	public void Update_stady()
	{
		base.StartCoroutine(this.IE_update_stady());
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003048 File Offset: 0x00001248
	private IEnumerator IE_update_stady()
	{
		this.Front_image.gameObject.SetActive(true);
		if (this._audioSource != null)
		{
			this._audioSource.Play();
		}
		Color color_value = this.Front_image.color;
		while (color_value.a <= 1f)
		{
			color_value.a += Time.deltaTime * this.speed;
			this.Front_image.color = color_value;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield return new WaitForSeconds(0.1f);
		this.Forest_dry.SetActive(false);
		this.Forest_green.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		while (color_value.a >= 0f)
		{
			color_value.a -= Time.deltaTime * this.speed;
			this.Front_image.color = color_value;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.Front_image.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x04000064 RID: 100
	[SerializeField]
	private GameObject Forest_dry;

	// Token: 0x04000065 RID: 101
	[SerializeField]
	private GameObject Forest_green;

	// Token: 0x04000066 RID: 102
	[SerializeField]
	private Image Front_image;

	// Token: 0x04000067 RID: 103
	[SerializeField]
	private float speed;

	// Token: 0x04000068 RID: 104
	private AudioSource _audioSource;
}
