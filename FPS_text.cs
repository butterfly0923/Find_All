using System;
using TMPro;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class FPS_text : MonoBehaviour
{
	// Token: 0x0600050B RID: 1291 RVA: 0x00018594 File Offset: 0x00016794
	private void Awake()
	{
		Setting_st_data.Set_FPS(this.FPS_count);
	}

	// Token: 0x04000567 RID: 1383
	[SerializeField]
	private TMP_Text FPS_count;
}
