using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000067 RID: 103
public class Arrow_position_z : MonoBehaviour
{
	// Token: 0x060002B2 RID: 690 RVA: 0x0000DC9B File Offset: 0x0000BE9B
	[ContextMenu("Start_Math")]
	public void Start_Math()
	{
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_Math_Arrow_Position_Z());
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x0000DCC3 File Offset: 0x0000BEC3
	private IEnumerator IE_Math_Arrow_Position_Z()
	{
		this.vector3_start_position = this.start_position.position;
		this.vector3_end_position = this.end_position.position;
		for (;;)
		{
			yield return new WaitForEndOfFrame();
			Vector3 position = this.arrow.position;
			float t = this.curve_way.Evaluate(Mathf.InverseLerp(this.vector3_start_position.x, this.vector3_end_position.x, this.arrow_bone.position.x));
			float z = Mathf.Lerp(this.vector3_start_position.z, this.vector3_end_position.z, t);
			position = new Vector3(position.x, position.y, z);
			this.arrow.position = position;
		}
		yield break;
	}

	// Token: 0x0400037C RID: 892
	[SerializeField]
	private Transform arrow;

	// Token: 0x0400037D RID: 893
	[SerializeField]
	private Transform arrow_bone;

	// Token: 0x0400037E RID: 894
	[SerializeField]
	private AnimationCurve curve_way;

	// Token: 0x0400037F RID: 895
	[SerializeField]
	private Transform start_position;

	// Token: 0x04000380 RID: 896
	[SerializeField]
	private Transform end_position;

	// Token: 0x04000381 RID: 897
	private Vector3 vector3_start_position;

	// Token: 0x04000382 RID: 898
	private Vector3 vector3_end_position;

	// Token: 0x04000383 RID: 899
	private Coroutine coroutine;
}
