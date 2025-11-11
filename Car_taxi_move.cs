using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000048 RID: 72
public class Car_taxi_move : MonoBehaviour
{
	// Token: 0x060001D5 RID: 469 RVA: 0x0000A33B File Offset: 0x0000853B
	[ContextMenu("Start_move")]
	public void Start_move()
	{
		base.StartCoroutine(this.move_car());
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0000A34C File Offset: 0x0000854C
	private void Check_pasanger()
	{
		if (this.pasangers_next != null)
		{
			this.pasangers_next.Exit_car();
			this.pasangers_next = null;
			this.point_stoped = null;
		}
		int num = -1;
		float num2 = 1000f;
		for (int i = 0; i < this.pasangers.Count; i++)
		{
			if (this.pasangers[i].Pasanger_complite() && Mathf.Abs(this.point_car.position.x - this.pasangers[i].Point_pasanger.position.x) > 10f && Mathf.Abs(this.point_car.position.x - this.pasangers[i].Point_pasanger.position.x) < num2)
			{
				num2 = Mathf.Abs(this.point_car.position.x - this.pasangers[i].Point_pasanger.position.x);
				num = i;
			}
		}
		if (num >= 0)
		{
			this.pasangers_next = this.pasangers[num];
			this.point_stoped = this.pasangers_next.Point_pasanger;
			if (this.point_stoped != null)
			{
				this.stop = true;
				this.first_stop = true;
			}
		}
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0000A49D File Offset: 0x0000869D
	private IEnumerator move_car()
	{
		for (;;)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			this.value_move += Time.deltaTime;
			Vector3 position_car = this.point_car.localPosition;
			this.Rotate_wheels(position_car.x);
			if (this.stop && this.point_stoped != null)
			{
				this.distance = Mathf.Abs(this.point_car.position.x - this.point_stoped.position.x);
				if (this.distance < this.start_distance_stop)
				{
					float time = Mathf.InverseLerp(0f, this.start_distance_stop, this.distance);
					this.multiply_speed = this.curve_x_stoped.Evaluate(time);
				}
				if (this.distance < 0.2f)
				{
					this.multiply_speed = 0f;
					yield return new WaitForSeconds(1f);
					if (this.pasangers_next != null)
					{
						this.pasangers_next.Sit_in_car();
					}
					Debug.Log("Садим пассажира");
					yield return new WaitForSeconds(1f);
					this.stop = false;
				}
			}
			else
			{
				this.multiply_speed += Time.deltaTime / 5f;
				if (this.multiply_speed >= 1f)
				{
					this.multiply_speed = 1f;
				}
			}
			if (this.left_right)
			{
				this.point_car.localScale = new Vector3(1f, 1f, 1f);
				if (position_car.x > this.left_right_end_point.y)
				{
					this.left_right = false;
					this.Check_pasanger();
				}
				else
				{
					position_car.x += this.speed * this.multiply_speed * Time.deltaTime;
				}
			}
			else
			{
				this.point_car.localScale = new Vector3(-1f, 1f, 1f);
				if (position_car.x < this.left_right_end_point.x)
				{
					this.left_right = true;
					this.Check_pasanger();
				}
				else
				{
					position_car.x -= this.speed * this.multiply_speed * Time.deltaTime;
				}
			}
			if (this.first_stop)
			{
				position_car.y = this.curve_y_stop.Evaluate(this.multiply_speed);
			}
			position_car.z = this.curve_z_position.Evaluate(position_car.y);
			this.point_car.localPosition = position_car;
			position_car = default(Vector3);
		}
		yield break;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000A4AC File Offset: 0x000086AC
	private void Rotate_wheels(float x_value)
	{
		float z = this.left_right ? this.wheel_rotate_position_x.Evaluate(x_value) : (this.wheel_rotate_position_x.Evaluate(x_value) * -1f);
		this.wheel_1.localEulerAngles = new Vector3(0f, 0f, z);
		this.wheel_2.localEulerAngles = new Vector3(0f, 0f, z);
	}

	// Token: 0x040001FD RID: 509
	[SerializeField]
	private float distance;

	// Token: 0x040001FE RID: 510
	[SerializeField]
	private Transform point_car;

	// Token: 0x040001FF RID: 511
	[SerializeField]
	private bool left_right;

	// Token: 0x04000200 RID: 512
	[SerializeField]
	private float value_move;

	// Token: 0x04000201 RID: 513
	[SerializeField]
	private float speed;

	// Token: 0x04000202 RID: 514
	[SerializeField]
	private float multiply_speed;

	// Token: 0x04000203 RID: 515
	[SerializeField]
	private float road_y;

	// Token: 0x04000204 RID: 516
	[SerializeField]
	private float road_border_y;

	// Token: 0x04000205 RID: 517
	[SerializeField]
	private Vector2 left_right_end_point;

	// Token: 0x04000206 RID: 518
	[SerializeField]
	private bool pasanger;

	// Token: 0x04000207 RID: 519
	[SerializeField]
	private bool stop;

	// Token: 0x04000208 RID: 520
	[SerializeField]
	private Transform point_stoped;

	// Token: 0x04000209 RID: 521
	[SerializeField]
	private AnimationCurve curve_x_stoped;

	// Token: 0x0400020A RID: 522
	[SerializeField]
	private float start_distance_stop;

	// Token: 0x0400020B RID: 523
	[SerializeField]
	private AnimationCurve curve_y_stop;

	// Token: 0x0400020C RID: 524
	[SerializeField]
	private AnimationCurve curve_z_position;

	// Token: 0x0400020D RID: 525
	[SerializeField]
	private AnimationCurve wheel_rotate_position_x;

	// Token: 0x0400020E RID: 526
	[SerializeField]
	private Transform wheel_1;

	// Token: 0x0400020F RID: 527
	[SerializeField]
	private Transform wheel_2;

	// Token: 0x04000210 RID: 528
	[SerializeField]
	private List<Pasanger> pasangers;

	// Token: 0x04000211 RID: 529
	[SerializeField]
	private Pasanger pasangers_next;

	// Token: 0x04000212 RID: 530
	[SerializeField]
	private bool first_stop;
}
