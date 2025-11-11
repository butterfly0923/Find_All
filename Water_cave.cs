using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class Water_cave : MonoBehaviour
{
	// Token: 0x06000042 RID: 66 RVA: 0x00002CC0 File Offset: 0x00000EC0
	private void Start()
	{
		base.StartCoroutine(this.Move_Water_Cor());
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002CCF File Offset: 0x00000ECF
	private IEnumerator Move_Water_Cor()
	{
		this.massive_step = 1f / (float)this.waters.Length;
		for (int i = 0; i < this.waters.Length; i++)
		{
			this.waters[i].distance = this.Distance_curve.Evaluate((float)i * this.massive_step);
			this.waters[i].curve = this.Start_curve.Evaluate((float)i * this.massive_step);
			this.waters[i].this_position = this.waters[i].this_transform.localPosition;
		}
		for (;;)
		{
			yield return new WaitForFixedUpdate();
			for (int j = 0; j < this.waters.Length; j++)
			{
				Water_cave.Water[] array = this.waters;
				int num = j;
				array[num].curve = array[num].curve - this.speed_wave;
				this.waters[j].curve = ((this.waters[j].curve < 0f) ? 1f : this.waters[j].curve);
				this.waters[j].this_transform.localPosition = new Vector3(this.waters[j].this_position.x + this.Move_X.Evaluate(this.waters[j].curve) * this.speed_Wave_x * this.waters[j].distance, this.waters[j].this_position.y + this.Move_Y.Evaluate(this.waters[j].curve + 0.25f) * this.speed_wave_Y * this.waters[j].distance, this.waters[j].this_position.z);
			}
		}
		yield break;
	}

	// Token: 0x04000048 RID: 72
	[SerializeField]
	private AnimationCurve Move_X;

	// Token: 0x04000049 RID: 73
	[SerializeField]
	private AnimationCurve Move_Y;

	// Token: 0x0400004A RID: 74
	[SerializeField]
	private float speed_Wave_x;

	// Token: 0x0400004B RID: 75
	[SerializeField]
	private AnimationCurve Distance_curve;

	// Token: 0x0400004C RID: 76
	[SerializeField]
	private float massive_step;

	// Token: 0x0400004D RID: 77
	[SerializeField]
	private AnimationCurve Start_curve;

	// Token: 0x0400004E RID: 78
	public float speed_wave_Y;

	// Token: 0x0400004F RID: 79
	public float speed_wave;

	// Token: 0x04000050 RID: 80
	[SerializeField]
	private Water_cave.Water[] waters;

	// Token: 0x020000E9 RID: 233
	[Serializable]
	public struct Water
	{
		// Token: 0x04000671 RID: 1649
		public Transform this_transform;

		// Token: 0x04000672 RID: 1650
		public Vector3 this_position;

		// Token: 0x04000673 RID: 1651
		public float curve;

		// Token: 0x04000674 RID: 1652
		public float distance;
	}
}
