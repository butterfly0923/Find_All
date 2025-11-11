using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class Cloud_move : MonoBehaviour
{
	// Token: 0x060002BA RID: 698 RVA: 0x0000DDE3 File Offset: 0x0000BFE3
	private void Start()
	{
		base.StartCoroutine(this.IE_Cloud_move());
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0000DDF2 File Offset: 0x0000BFF2
	private IEnumerator IE_Cloud_move()
	{
		for (;;)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			for (int i = 0; i < this.cloud_transform.Length; i++)
			{
				this.cloud_transform[i].position = new Vector3(this.cloud_transform[i].position.x + this.speed * Time.deltaTime, this.cloud_transform[i].position.y, this.cloud_transform[i].position.z);
				if (this.cloud_transform[i].position.x >= this.limit_x)
				{
					this.cloud_transform[i].position = new Vector3(this.start_x + (this.limit_x - this.cloud_transform[i].position.x), this.cloud_transform[i].position.y, this.cloud_transform[i].position.z);
				}
			}
		}
		yield break;
	}

	// Token: 0x0400038F RID: 911
	[SerializeField]
	private Transform[] cloud_transform;

	// Token: 0x04000390 RID: 912
	[SerializeField]
	private float speed;

	// Token: 0x04000391 RID: 913
	[SerializeField]
	private float limit_x;

	// Token: 0x04000392 RID: 914
	[SerializeField]
	private float start_x;
}
