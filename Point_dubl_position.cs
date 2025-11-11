using System;
using UnityEngine;

// Token: 0x020000A6 RID: 166
public class Point_dubl_position : MonoBehaviour
{
	// Token: 0x060004B0 RID: 1200 RVA: 0x00016002 File Offset: 0x00014202
	private void Start()
	{
		this.this_transform = base.transform;
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x00016010 File Offset: 0x00014210
	private void Update()
	{
		this.target_point.position = this.this_transform.position;
	}

	// Token: 0x040004CF RID: 1231
	[SerializeField]
	private Transform target_point;

	// Token: 0x040004D0 RID: 1232
	private Transform this_transform;
}
