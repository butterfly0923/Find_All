using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000051 RID: 81
public class Boat_move : MonoBehaviour
{
	// Token: 0x0600022E RID: 558 RVA: 0x0000BB31 File Offset: 0x00009D31
	public void Start_move()
	{
		base.StartCoroutine(this.IE_move());
		base.StartCoroutine(this.IE_rotate());
		base.StartCoroutine(this.IE_multiply_speed_move());
		base.StartCoroutine(this.IE_multiply_speed_rotate());
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0000BB67 File Offset: 0x00009D67
	private IEnumerator IE_move()
	{
		this.local_position_start = this.transform_point_move.localPosition;
		for (;;)
		{
			if (this.local_position_start.x < this.start_end.x)
			{
				this.left_move = false;
				this.local_position_start.x = this.start_end.x;
				this.transform_point_move.localScale = new Vector3(-1f, 1f, 1f);
			}
			else if (this.local_position_start.x > this.start_end.y)
			{
				this.left_move = true;
				this.local_position_start.x = this.start_end.y;
				this.transform_point_move.localScale = new Vector3(1f, 1f, 1f);
			}
			if (this.left_move)
			{
				this.local_position_start.x = this.local_position_start.x - Time.deltaTime * this.speed_move;
			}
			else
			{
				this.local_position_start.x = this.local_position_start.x + Time.deltaTime * this.speed_move;
			}
			this.transform_point_move.localPosition = this.local_position_start;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000230 RID: 560 RVA: 0x0000BB76 File Offset: 0x00009D76
	private IEnumerator IE_rotate()
	{
		this.local_rotate_start = this.transform_point_rotate.localEulerAngles;
		float value = 0f;
		for (;;)
		{
			value += Time.deltaTime * this.speed_rotate;
			yield return new WaitForSeconds(Time.deltaTime);
			if (value > 1f)
			{
				value -= 1f;
			}
			this.local_rotate_start.z = this.curve_rotate.Evaluate(value);
			this.transform_point_rotate.localEulerAngles = this.local_rotate_start;
		}
		yield break;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0000BB85 File Offset: 0x00009D85
	private IEnumerator IE_multiply_speed_move()
	{
		while (this.speed_move < this.speed_move_max)
		{
			this.speed_move += Time.deltaTime * this.multiply_speed_move_plus;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.speed_move = this.speed_move_max;
		yield break;
	}

	// Token: 0x06000232 RID: 562 RVA: 0x0000BB94 File Offset: 0x00009D94
	private IEnumerator IE_multiply_speed_rotate()
	{
		while (this.speed_rotate < this.speed_rotate_max)
		{
			this.speed_rotate += Time.deltaTime * this.multiply_speed_rotate_plus;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.speed_rotate = this.speed_rotate_max;
		yield break;
	}

	// Token: 0x04000261 RID: 609
	[SerializeField]
	private Transform transform_point_move;

	// Token: 0x04000262 RID: 610
	[SerializeField]
	private Vector3 local_position_start;

	// Token: 0x04000263 RID: 611
	[SerializeField]
	private Transform transform_point_rotate;

	// Token: 0x04000264 RID: 612
	[SerializeField]
	private Vector3 local_rotate_start;

	// Token: 0x04000265 RID: 613
	[SerializeField]
	private Vector2 start_end;

	// Token: 0x04000266 RID: 614
	[SerializeField]
	private AnimationCurve curve_move;

	// Token: 0x04000267 RID: 615
	[SerializeField]
	private bool left_move;

	// Token: 0x04000268 RID: 616
	[SerializeField]
	private AnimationCurve curve_rotate;

	// Token: 0x04000269 RID: 617
	[SerializeField]
	private float speed_move;

	// Token: 0x0400026A RID: 618
	[SerializeField]
	private float speed_move_max;

	// Token: 0x0400026B RID: 619
	[SerializeField]
	private float speed_rotate;

	// Token: 0x0400026C RID: 620
	[SerializeField]
	private float speed_rotate_max;

	// Token: 0x0400026D RID: 621
	[SerializeField]
	private float multiply_speed_move_plus;

	// Token: 0x0400026E RID: 622
	[SerializeField]
	private float multiply_speed_rotate_plus;
}
