using System;
using System.Collections;
using TMPro;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class EnvMapAnimator : MonoBehaviour
{
	// Token: 0x06000530 RID: 1328 RVA: 0x00018AD6 File Offset: 0x00016CD6
	private void Awake()
	{
		this.m_textMeshPro = base.GetComponent<TMP_Text>();
		this.m_material = this.m_textMeshPro.fontSharedMaterial;
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00018AF5 File Offset: 0x00016CF5
	private IEnumerator Start()
	{
		Matrix4x4 matrix = default(Matrix4x4);
		for (;;)
		{
			matrix.SetTRS(Vector3.zero, Quaternion.Euler(Time.time * this.RotationSpeeds.x, Time.time * this.RotationSpeeds.y, Time.time * this.RotationSpeeds.z), Vector3.one);
			this.m_material.SetMatrix("_EnvMatrix", matrix);
			yield return null;
		}
		yield break;
	}

	// Token: 0x04000585 RID: 1413
	public Vector3 RotationSpeeds;

	// Token: 0x04000586 RID: 1414
	private TMP_Text m_textMeshPro;

	// Token: 0x04000587 RID: 1415
	private Material m_material;
}
