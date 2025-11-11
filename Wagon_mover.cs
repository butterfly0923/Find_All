using System;
using UnityEngine;

// Token: 0x0200000D RID: 13
public class Wagon_mover : MonoBehaviour
{
	// Token: 0x0600003B RID: 59 RVA: 0x00002C08 File Offset: 0x00000E08
	private void Start()
	{
		this.Component_Setting();
		this.Circle_lenght_setting();
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002C16 File Offset: 0x00000E16
	private void Component_Setting()
	{
		this.this_transform = base.GetComponent<Transform>();
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00002C24 File Offset: 0x00000E24
	private void Circle_lenght_setting()
	{
		this.diameter = (this.rotation_inversion ? (-1f * this.diameter) : this.diameter);
		this.circle_lenght = 3.14f * this.diameter;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00002C5A File Offset: 0x00000E5A
	private void Update()
	{
		this.Rotate_Z_Wheel();
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002C64 File Offset: 0x00000E64
	private void Rotate_Z_Wheel()
	{
		this.this_transform.rotation = Quaternion.Euler(0f, 0f, this.this_transform.position.x / -this.circle_lenght * 360f + this.adjustment_angle_start);
	}

	// Token: 0x04000042 RID: 66
	[Header("Колесо:")]
	[SerializeField]
	private Transform this_transform;

	// Token: 0x04000043 RID: 67
	[Header("Диаметр колеса:")]
	[SerializeField]
	private float diameter;

	// Token: 0x04000044 RID: 68
	[Header("Корректировка изначального угла:")]
	[SerializeField]
	private float adjustment_angle_start;

	// Token: 0x04000045 RID: 69
	[Header("Инверсия вращения:")]
	[SerializeField]
	private bool rotation_inversion;

	// Token: 0x04000046 RID: 70
	[Header("Длинна круга:")]
	[SerializeField]
	private float circle_lenght;
}
