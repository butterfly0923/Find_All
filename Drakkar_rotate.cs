using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class Drakkar_rotate : MonoBehaviour
{
	// Token: 0x0600002A RID: 42 RVA: 0x0000297C File Offset: 0x00000B7C
	private void Update()
	{
		if (this.target != null)
		{
			Vector3 normalized = (this.target.position - base.transform.position).normalized;
			Vector3 up = Vector3.RotateTowards(base.transform.up, normalized, this.rotationSpeed, 10f);
			base.transform.up = up;
		}
	}

	// Token: 0x0400002B RID: 43
	public Transform target;

	// Token: 0x0400002C RID: 44
	public float rotationSpeed = 5f;
}
