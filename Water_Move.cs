using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200006B RID: 107
public class Water_Move : MonoBehaviour
{
	// Token: 0x060002C2 RID: 706 RVA: 0x0000DE68 File Offset: 0x0000C068
	private void Awake()
	{
		for (int i = 0; i < this.water_Lines.Length; i++)
		{
			this.water_Lines[i].water_line_position = this.water_Lines[i].water_line_transform.localPosition;
			this.water_Lines[i].water_line_start_position_x = this.water_Lines[i].water_line_position.x;
			this.water_Lines[i].start_position_y = this.water_Lines[i].water_line_position.y;
			this.water_Lines[i].water_line_end_position_x = this.water_Lines[i].water_line_start_position_x + this.value_1_segment;
			this.water_Lines[i].water_line_position.y = this.water_Lines[i].start_position_y + this.water_Lines[i].water_up_down.Evaluate(this.water_Lines[i].curve_float) * this.multiply_water_wave;
			this.water_Lines[i].water_line_transform.localPosition = this.water_Lines[i].water_line_position;
		}
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0000DFA9 File Offset: 0x0000C1A9
	public void Start_Event()
	{
		base.StartCoroutine(this.IE_Water_move());
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0000DFB8 File Offset: 0x0000C1B8
	private IEnumerator IE_Water_move()
	{
		for (;;)
		{
			for (int i = 0; i < this.water_Lines.Length; i++)
			{
				Water_Move.Water_Lines[] array = this.water_Lines;
				int num = i;
				array[num].water_line_position.x = array[num].water_line_position.x + Time.deltaTime * this.speed_water_line;
				if (this.water_Lines[i].water_line_position.x > this.water_Lines[i].water_line_end_position_x)
				{
					this.water_Lines[i].water_line_position.x = this.water_Lines[i].water_line_start_position_x - (Mathf.Abs(this.water_Lines[i].water_line_end_position_x) - Mathf.Abs(this.water_Lines[i].water_line_position.x));
				}
				Water_Move.Water_Lines[] array2 = this.water_Lines;
				int num2 = i;
				array2[num2].curve_float = array2[num2].curve_float + this.water_up_down_speed * Time.deltaTime;
				this.water_Lines[i].water_line_position.y = this.water_Lines[i].start_position_y + this.water_Lines[i].water_up_down.Evaluate(this.water_Lines[i].curve_float) * this.multiply_water_wave;
				this.water_Lines[i].water_line_transform.localPosition = this.water_Lines[i].water_line_position;
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x04000398 RID: 920
	[SerializeField]
	private float value_1_segment;

	// Token: 0x04000399 RID: 921
	[SerializeField]
	private float multiply_water_wave;

	// Token: 0x0400039A RID: 922
	[SerializeField]
	private Water_Move.Water_Lines[] water_Lines;

	// Token: 0x0400039B RID: 923
	[SerializeField]
	private float water_up_down_speed;

	// Token: 0x0400039C RID: 924
	[SerializeField]
	private float speed_water_line;

	// Token: 0x020001A0 RID: 416
	[Serializable]
	public struct Water_Lines
	{
		// Token: 0x04000955 RID: 2389
		public Transform water_line_transform;

		// Token: 0x04000956 RID: 2390
		public Vector3 water_line_position;

		// Token: 0x04000957 RID: 2391
		public float water_line_start_position_x;

		// Token: 0x04000958 RID: 2392
		public float water_line_end_position_x;

		// Token: 0x04000959 RID: 2393
		public float start_position_y;

		// Token: 0x0400095A RID: 2394
		public AnimationCurve water_up_down;

		// Token: 0x0400095B RID: 2395
		public float add_curve;

		// Token: 0x0400095C RID: 2396
		public float curve_float;
	}
}
