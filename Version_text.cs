using System;
using TMPro;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class Version_text : MonoBehaviour
{
	// Token: 0x0600050F RID: 1295 RVA: 0x000185C4 File Offset: 0x000167C4
	private void Start()
	{
		this.version_tmp.text = Application.version;
	}

	// Token: 0x0400056A RID: 1386
	[SerializeField]
	private TMP_Text version_tmp;
}
