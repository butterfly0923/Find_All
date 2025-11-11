using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x0200000C RID: 12
public class Ship_move : MonoBehaviour
{
	// Token: 0x06000032 RID: 50 RVA: 0x00002B09 File Offset: 0x00000D09
	private void Start()
	{
		this.Component_Setting();
		this.Scale_and_Position_object_Setting();
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002B17 File Offset: 0x00000D17
	[ContextMenu("Update_layers")]
	public void Go()
	{
		this.Start_Coroutines();
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002B1F File Offset: 0x00000D1F
	private void Component_Setting()
	{
		this.this_transform = base.GetComponent<Transform>();
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002B30 File Offset: 0x00000D30
	private void Scale_and_Position_object_Setting()
	{
		this.position_object = this.this_transform.localPosition;
		this.this_transform.localScale = new Vector3(this.this_transform.localScale.x * (float)(this.scale_inversion ? 1 : -1), this.this_transform.localScale.y, this.this_transform.localScale.z);
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002B9C File Offset: 0x00000D9C
	public void Start_Coroutines()
	{
		base.StartCoroutine(this.speed_start());
		this.Component_Setting();
		this.coroutine_main = base.StartCoroutine(this.start_right_left ? this.Move_Right() : this.Move_Left());
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002BD3 File Offset: 0x00000DD3
	private IEnumerator Move_Right()
	{
		while (this.curve_time <= this.max_min_curve_time.y)
		{
			this.curve_time += this.speed_move_curve_time;
			this.this_transform.localPosition = new Vector3(this.curve_position_x_right.Evaluate(this.curve_time), this.position_object.y, this.position_object.z);
			yield return new WaitForFixedUpdate();
		}
		this.this_transform.localScale = new Vector3(this.this_transform.localScale.x * -1f, this.this_transform.localScale.y, this.this_transform.localScale.z);
		UnityEvent unityEvent = this.event_right;
		if (unityEvent != null)
		{
			unityEvent.Invoke();
		}
		this.coroutine_main = base.StartCoroutine(this.Move_Left());
		yield break;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002BE2 File Offset: 0x00000DE2
	private IEnumerator Move_Left()
	{
		while (this.curve_time >= this.max_min_curve_time.x)
		{
			this.curve_time -= this.speed_move_curve_time;
			this.this_transform.localPosition = new Vector3(this.curve_position_x_left.Evaluate(this.curve_time), this.position_object.y, this.position_object.z);
			yield return new WaitForFixedUpdate();
		}
		this.this_transform.localScale = new Vector3(this.this_transform.localScale.x * -1f, this.this_transform.localScale.y, this.this_transform.localScale.z);
		UnityEvent unityEvent = this.event_left;
		if (unityEvent != null)
		{
			unityEvent.Invoke();
		}
		this.coroutine_main = base.StartCoroutine(this.Move_Right());
		yield break;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002BF1 File Offset: 0x00000DF1
	private IEnumerator speed_start()
	{
		float speed_max = this.speed_move_curve_time;
		this.speed_move_curve_time = 0.001f;
		while (this.speed_move_curve_time < speed_max)
		{
			yield return new WaitForFixedUpdate();
			this.speed_move_curve_time += this.speed_start_plus;
			if (this.speed_move_curve_time > speed_max)
			{
				this.speed_move_curve_time = speed_max;
			}
		}
		yield break;
	}

	// Token: 0x04000034 RID: 52
	[Header("Трансфорт родительского объекта:")]
	[SerializeField]
	private Transform this_transform;

	// Token: 0x04000035 RID: 53
	[Header("Скорость перемещения:")]
	[SerializeField]
	private float speed_move_curve_time;

	// Token: 0x04000036 RID: 54
	[Header("Скорость набора скорости:")]
	[SerializeField]
	private float speed_start_plus;

	// Token: 0x04000037 RID: 55
	[Header("Начальная позиция:")]
	[SerializeField]
	private Vector3 position_object;

	// Token: 0x04000038 RID: 56
	[Header("Направление движения при старте:")]
	[SerializeField]
	private bool start_right_left;

	// Token: 0x04000039 RID: 57
	[Header("Инверсия направления:")]
	[SerializeField]
	private bool scale_inversion;

	// Token: 0x0400003A RID: 58
	[Header("Длинна круга:")]
	[SerializeField]
	private float circle_lenght;

	// Token: 0x0400003B RID: 59
	[Header("График скорости движения")]
	[SerializeField]
	private AnimationCurve curve_position_x_right;

	// Token: 0x0400003C RID: 60
	[SerializeField]
	private AnimationCurve curve_position_x_left;

	// Token: 0x0400003D RID: 61
	[Header("Начальная позиция на графике:")]
	[SerializeField]
	private float curve_time;

	// Token: 0x0400003E RID: 62
	[Header("Минимальная и максимальная позиция")]
	[SerializeField]
	private Vector2 max_min_curve_time;

	// Token: 0x0400003F RID: 63
	[SerializeField]
	private UnityEvent event_left;

	// Token: 0x04000040 RID: 64
	[SerializeField]
	private UnityEvent event_right;

	// Token: 0x04000041 RID: 65
	private Coroutine coroutine_main;
}
