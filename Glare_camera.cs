using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
public class Glare_camera : MonoBehaviour
{
	// Token: 0x0600050D RID: 1293 RVA: 0x000185A9 File Offset: 0x000167A9
	private void Awake()
	{
		Setting_st_data.Set_Glare_Camera(this.glare_camera_sprite, this.glare_curve);
	}

	// Token: 0x04000568 RID: 1384
	[SerializeField]
	private SpriteRenderer glare_camera_sprite;

	// Token: 0x04000569 RID: 1385
	[SerializeField]
	private AnimationCurve glare_curve;
}
