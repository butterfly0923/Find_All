using System;
using UnityEngine;

// Token: 0x0200009A RID: 154
[CreateAssetMenu(fileName = "Card_Move_SO", menuName = "Item_Data/Card_Move_SO", order = 112)]
public class Card_Move_SO : ScriptableObject
{
	// Token: 0x1700002B RID: 43
	// (get) Token: 0x06000414 RID: 1044 RVA: 0x0001416F File Offset: 0x0001236F
	public float Speed_value_update_size
	{
		get
		{
			return this.speed_value_update_size;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000415 RID: 1045 RVA: 0x00014177 File Offset: 0x00012377
	public AnimationCurve Scale_multiply_curve
	{
		get
		{
			return this.scale_multiply_curve;
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x06000416 RID: 1046 RVA: 0x0001417F File Offset: 0x0001237F
	public float Speed_card_start
	{
		get
		{
			return this.speed_card_start;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000417 RID: 1047 RVA: 0x00014187 File Offset: 0x00012387
	public AnimationCurve Curve_move_start_center
	{
		get
		{
			return this.curve_move_start_center;
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x06000418 RID: 1048 RVA: 0x0001418F File Offset: 0x0001238F
	public AnimationCurve Curve_size_start_center
	{
		get
		{
			return this.curve_size_start_center;
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x06000419 RID: 1049 RVA: 0x00014197 File Offset: 0x00012397
	public float Speed_card_end
	{
		get
		{
			return this.speed_card_end;
		}
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x0600041A RID: 1050 RVA: 0x0001419F File Offset: 0x0001239F
	public AnimationCurve Curve_move_center_end
	{
		get
		{
			return this.curve_move_center_end;
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x0600041B RID: 1051 RVA: 0x000141A7 File Offset: 0x000123A7
	public AnimationCurve Curve_size_center_end
	{
		get
		{
			return this.curve_size_center_end;
		}
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x0600041C RID: 1052 RVA: 0x000141AF File Offset: 0x000123AF
	public float Speed_card_alpha
	{
		get
		{
			return this.speed_card_alpha;
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x0600041D RID: 1053 RVA: 0x000141B7 File Offset: 0x000123B7
	public float Time_delay_last_card
	{
		get
		{
			return this.time_delay_last_card;
		}
	}

	// Token: 0x0400046C RID: 1132
	[Header("Наведение на карту:")]
	[Header("Скорость увеличения/уменьшения:")]
	[SerializeField]
	private float speed_value_update_size;

	// Token: 0x0400046D RID: 1133
	[Header("График размера:")]
	[SerializeField]
	private AnimationCurve scale_multiply_curve;

	// Token: 0x0400046E RID: 1134
	[Space(5f)]
	[Header("Появление карт:")]
	[Header("Скорость:")]
	[SerializeField]
	private float speed_card_start;

	// Token: 0x0400046F RID: 1135
	[Header("График перемещения:")]
	[SerializeField]
	private AnimationCurve curve_move_start_center;

	// Token: 0x04000470 RID: 1136
	[Header("График размера:")]
	[SerializeField]
	private AnimationCurve curve_size_start_center;

	// Token: 0x04000471 RID: 1137
	[Space(5f)]
	[Header("Убирание выбранной карты вниз:")]
	[Header("Скорость:")]
	[SerializeField]
	private float speed_card_end;

	// Token: 0x04000472 RID: 1138
	[Header("График перемещения:")]
	[SerializeField]
	private AnimationCurve curve_move_center_end;

	// Token: 0x04000473 RID: 1139
	[Header("График размера:")]
	[SerializeField]
	private AnimationCurve curve_size_center_end;

	// Token: 0x04000474 RID: 1140
	[Space(5f)]
	[Header("Исчезновение не выбранных карт:")]
	[Header("Скорость исчезновения:")]
	[SerializeField]
	private float speed_card_alpha;

	// Token: 0x04000475 RID: 1141
	[Header("Время ожидания последний карты:")]
	[SerializeField]
	private float time_delay_last_card;
}
