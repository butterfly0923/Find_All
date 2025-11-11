using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000068 RID: 104
public class Clock_Arrows : MonoBehaviour
{
	// Token: 0x060002B5 RID: 693 RVA: 0x0000DCDA File Offset: 0x0000BEDA
	private void Start()
	{
		this.Clockwise = (this.Clockwise_flag ? 1 : -1);
		base.StartCoroutine(this.Clock_Update_Timer());
		if (this.gear_rotate)
		{
			base.StartCoroutine(this.Clock_Gears_Update());
		}
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x0000DD10 File Offset: 0x0000BF10
	private IEnumerator Clock_Update_Timer()
	{
		for (;;)
		{
			this.Update_Clock();
			yield return new WaitForSeconds(60f);
			Action st_minuts = Events_Menu_UI.St_minuts;
			if (st_minuts != null)
			{
				st_minuts();
			}
		}
		yield break;
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x0000DD1F File Offset: 0x0000BF1F
	private IEnumerator Clock_Gears_Update()
	{
		for (;;)
		{
			this.gear_1.localEulerAngles = new Vector3(this.gear_1.localEulerAngles.x, this.gear_1.localEulerAngles.y, this.gear_1.localEulerAngles.z + this.speed_gear_1);
			this.gear_2.localEulerAngles = new Vector3(this.gear_2.localEulerAngles.x, this.gear_2.localEulerAngles.y, this.gear_2.localEulerAngles.z + this.speed_gear_2);
			this.gear_3.localEulerAngles = new Vector3(this.gear_3.localEulerAngles.x, this.gear_3.localEulerAngles.y, this.gear_3.localEulerAngles.z + this.speed_gear_3);
			yield return new WaitForSeconds(1f);
		}
		yield break;
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x0000DD30 File Offset: 0x0000BF30
	private void Update_Clock()
	{
		DateTime now = DateTime.Now;
		float num = (now.Hour > 12) ? ((float)now.Hour - 12f) : ((float)now.Hour);
		this.Hour.transform.rotation = Quaternion.Euler(0f, 0f, (float)this.Clockwise * 0.5f * (num * 60f + (float)now.Minute));
		this.Minute.transform.rotation = Quaternion.Euler(0f, 0f, (float)(this.Clockwise * 360 / 60 * now.Minute));
	}

	// Token: 0x04000384 RID: 900
	[Header("Стрелка часов и минут")]
	[SerializeField]
	private Transform Hour;

	// Token: 0x04000385 RID: 901
	[SerializeField]
	private Transform Minute;

	// Token: 0x04000386 RID: 902
	[Header("Шестеренки:")]
	[SerializeField]
	private bool gear_rotate;

	// Token: 0x04000387 RID: 903
	[SerializeField]
	private Transform gear_1;

	// Token: 0x04000388 RID: 904
	[SerializeField]
	private float speed_gear_1;

	// Token: 0x04000389 RID: 905
	[SerializeField]
	private Transform gear_2;

	// Token: 0x0400038A RID: 906
	[SerializeField]
	private float speed_gear_2;

	// Token: 0x0400038B RID: 907
	[SerializeField]
	private Transform gear_3;

	// Token: 0x0400038C RID: 908
	[SerializeField]
	private float speed_gear_3;

	// Token: 0x0400038D RID: 909
	[Header("Определение поворота часов:")]
	[SerializeField]
	private bool Clockwise_flag;

	// Token: 0x0400038E RID: 910
	private int Clockwise;
}
