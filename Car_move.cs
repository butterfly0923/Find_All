using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200004B RID: 75
public class Car_move : MonoBehaviour
{
	// Token: 0x17000002 RID: 2
	// (get) Token: 0x060001F1 RID: 497 RVA: 0x0000A95A File Offset: 0x00008B5A
	public float Speed_move
	{
		get
		{
			return this.speed_move;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000A962 File Offset: 0x00008B62
	public Transform Transform_point_move
	{
		get
		{
			return this.transform_point_move;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x060001F3 RID: 499 RVA: 0x0000A96A File Offset: 0x00008B6A
	public bool Left_move
	{
		get
		{
			return this.left_move;
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0000A972 File Offset: 0x00008B72
	private void Awake()
	{
		this.Set_layer_sprite();
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0000A97A File Offset: 0x00008B7A
	private void Start()
	{
		this.update_layers();
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0000A984 File Offset: 0x00008B84
	private void Set_layer_sprite()
	{
		this.sprite_renderers = new Car_move.Sprite_renderer_layer[this.sprite_renderers_defoult.Length];
		for (int i = 0; i < this.sprite_renderers.Length; i++)
		{
			Car_move.Sprite_renderer_layer sprite_renderer_layer;
			sprite_renderer_layer.sprite_renderer = this.sprite_renderers_defoult[i];
			sprite_renderer_layer.layer = this.sprite_renderers_defoult[i].sortingOrder - this.start_layer;
			this.sprite_renderers[i] = sprite_renderer_layer;
		}
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x0000A9EE File Offset: 0x00008BEE
	[ContextMenu("Start_move")]
	public void Start_move()
	{
		base.StartCoroutine(this.IE_move());
		base.StartCoroutine(this.IE_multiply_speed_move());
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0000AA0A File Offset: 0x00008C0A
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

	// Token: 0x060001F9 RID: 505 RVA: 0x0000AA19 File Offset: 0x00008C19
	private IEnumerator IE_move()
	{
		for (;;)
		{
			this.multiply_wheel_rotate_void = Time.deltaTime * this.speed_move * this.multiply_wheel_rotate;
			this.wheel_1.Rotate(0f, 0f, this.multiply_wheel_rotate_void);
			this.wheel_2.Rotate(0f, 0f, this.multiply_wheel_rotate_void);
			this.local_position_start = this.car_point.localPosition;
			if (this.local_position_start.x < this.start_end.x)
			{
				this.left_move = false;
				this.local_position_start.x = this.start_end.x;
				this.local_position_start.y = this.up_param;
				this.transform_point_move.localScale = new Vector3(this.transform_point_move.localScale.x * -1f, 1f, 1f);
			}
			else if (this.local_position_start.x > this.start_end.y)
			{
				this.left_move = true;
				this.local_position_start.x = this.start_end.y;
				this.local_position_start.y = this.down_param;
				this.transform_point_move.localScale = new Vector3(this.transform_point_move.localScale.x * -1f, 1f, 1f);
			}
			if (this.left_move)
			{
				this.local_position_start.x = this.local_position_start.x - Time.deltaTime * this.speed_move;
				if (this.car_add != null && this.car_add.Left_move == this.left_move)
				{
					if (this.car_add.Speed_move < this.speed_move)
					{
						this.local_position_start.y = -this.curve_add_car.Evaluate(Vector3.Distance(this.car_add.Transform_point_move.localPosition, this.transform_point_move.localPosition)) + this.down_param;
					}
				}
				else
				{
					this.local_position_start.y = this.down_param;
				}
			}
			else
			{
				this.local_position_start.x = this.local_position_start.x + Time.deltaTime * this.speed_move;
				if (this.car_add != null && this.car_add.Left_move == this.left_move)
				{
					if (this.car_add.Speed_move < this.speed_move)
					{
						this.local_position_start.y = this.curve_add_car.Evaluate(Vector3.Distance(this.car_add.Transform_point_move.localPosition, this.transform_point_move.localPosition)) + this.up_param;
					}
				}
				else
				{
					this.local_position_start.y = this.up_param;
				}
			}
			this.local_position_start.z = this.curve_z_car.Evaluate(this.transform_point_move.localPosition.y);
			this.transform_point_move.localPosition = this.local_position_start;
			this.update_layers();
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0000AA28 File Offset: 0x00008C28
	private void update_layers()
	{
		for (int i = 0; i < this.sprite_renderers.Length; i++)
		{
			this.sprite_renderers[i].sprite_renderer.sortingOrder = this.start_layer + this.sprite_renderers[i].layer + (int)Mathf.Lerp(this.up_layer, this.down_layer, Mathf.InverseLerp(this.up_param, this.down_param, this.car_point.localPosition.y));
		}
	}

	// Token: 0x04000226 RID: 550
	[SerializeField]
	private Car_move car_add;

	// Token: 0x04000227 RID: 551
	[SerializeField]
	private Transform car_point;

	// Token: 0x04000228 RID: 552
	[SerializeField]
	private Transform wheel_1;

	// Token: 0x04000229 RID: 553
	[SerializeField]
	private Transform wheel_2;

	// Token: 0x0400022A RID: 554
	[SerializeField]
	private float multiply_wheel_rotate;

	// Token: 0x0400022B RID: 555
	[SerializeField]
	private float speed_move;

	// Token: 0x0400022C RID: 556
	[SerializeField]
	private float speed_move_max;

	// Token: 0x0400022D RID: 557
	[SerializeField]
	private float multiply_speed_move_plus;

	// Token: 0x0400022E RID: 558
	[SerializeField]
	private Transform transform_point_move;

	// Token: 0x0400022F RID: 559
	[SerializeField]
	private Vector3 local_position_start;

	// Token: 0x04000230 RID: 560
	[SerializeField]
	private Vector2 start_end;

	// Token: 0x04000231 RID: 561
	[SerializeField]
	private bool left_move;

	// Token: 0x04000232 RID: 562
	[SerializeField]
	private AnimationCurve curve_add_car;

	// Token: 0x04000233 RID: 563
	[SerializeField]
	private AnimationCurve curve_z_car;

	// Token: 0x04000234 RID: 564
	[SerializeField]
	private float up_param;

	// Token: 0x04000235 RID: 565
	[SerializeField]
	private float down_param;

	// Token: 0x04000236 RID: 566
	[SerializeField]
	private float up_layer;

	// Token: 0x04000237 RID: 567
	[SerializeField]
	private float down_layer;

	// Token: 0x04000238 RID: 568
	[SerializeField]
	private int start_layer;

	// Token: 0x04000239 RID: 569
	[SerializeField]
	private SpriteRenderer[] sprite_renderers_defoult;

	// Token: 0x0400023A RID: 570
	[SerializeField]
	private Car_move.Sprite_renderer_layer[] sprite_renderers;

	// Token: 0x0400023B RID: 571
	private float multiply_wheel_rotate_void;

	// Token: 0x02000147 RID: 327
	[Serializable]
	public struct Sprite_renderer_layer
	{
		// Token: 0x04000836 RID: 2102
		public SpriteRenderer sprite_renderer;

		// Token: 0x04000837 RID: 2103
		public int layer;
	}
}
