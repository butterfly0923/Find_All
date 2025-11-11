using System;
using System.Collections;
using System.IO;
using UnityEngine;

// Token: 0x02000010 RID: 16
public class Collider_Click : MonoBehaviour
{
	// Token: 0x06000045 RID: 69 RVA: 0x00002CE8 File Offset: 0x00000EE8
	[ContextMenu("TakeScreenshot")]
	private void TakeScreenshot()
	{
		RenderTexture renderTexture = new RenderTexture(this.width, this.height, 24);
		this.screenshotCamera.targetTexture = renderTexture;
		Texture2D texture2D = new Texture2D(this.width, this.height, TextureFormat.RGB24, false);
		this.screenshotCamera.Render();
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, (float)this.width, (float)this.height), 0, 0);
		texture2D.Apply();
		byte[] bytes = texture2D.EncodeToPNG();
		string text = string.Format("Screenshot_{0}x{1}_{2:yyyyMMdd_HHmmss}.png", this.width, this.height, DateTime.Now);
		File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(Application.dataPath) + "/Color_Booking_Screenshot", text), bytes);
		this.screenshotCamera.targetTexture = null;
		RenderTexture.active = null;
		Object.Destroy(renderTexture);
		Object.Destroy(texture2D);
		Debug.Log(string.Format("Скриншот {0}x{1} сохранён: {2}", this.width, this.height, text));
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002DF9 File Offset: 0x00000FF9
	[ContextMenu("Screen_full_scene")]
	private void Screen_full_scene()
	{
		base.StartCoroutine(this.IE_Screen_full_scene());
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002E08 File Offset: 0x00001008
	private IEnumerator IE_Screen_full_scene()
	{
		this.Camera_position_set(0, 0);
		int num;
		for (int i = 0; i < this.for_y; i = num + 1)
		{
			for (int j = 0; j < this.for_x; j = num + 1)
			{
				this.Camera_position_set(j, i);
				yield return new WaitForSeconds(1f);
				this.TakeScreenshot();
				yield return new WaitForSeconds(1f);
				num = j;
			}
			num = i;
		}
		yield break;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002E18 File Offset: 0x00001018
	private void Camera_position_set(int plus_x, int plus_y)
	{
		this.screenshotCamera.transform.position = new Vector3((float)Mathf.RoundToInt(this.start_position.x + (float)(plus_x * this.plus_grid)), (float)Mathf.RoundToInt(this.start_position.y + (float)(plus_y * this.plus_grid)), -250f);
	}

	// Token: 0x04000051 RID: 81
	public Camera screenshotCamera;

	// Token: 0x04000052 RID: 82
	public int width = 5000;

	// Token: 0x04000053 RID: 83
	public int height = 5000;

	// Token: 0x04000054 RID: 84
	public Vector2 start_position;

	// Token: 0x04000055 RID: 85
	public int plus_grid;

	// Token: 0x04000056 RID: 86
	public int for_x;

	// Token: 0x04000057 RID: 87
	public int for_y;
}
