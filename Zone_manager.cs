using System;
using UnityEngine;

// Token: 0x02000053 RID: 83
public class Zone_manager : MonoBehaviour
{
	// Token: 0x0600024D RID: 589 RVA: 0x0000C781 File Offset: 0x0000A981
	private void Awake()
	{
		Zone_manager.st = (Zone_manager)Set_Singleton.This<Zone_manager, Zone_manager>(this, Zone_manager.st);
	}

	// Token: 0x0600024E RID: 590 RVA: 0x0000C798 File Offset: 0x0000A998
	public ValueTuple<Vector2, Vector2> Map_Zone()
	{
		return new ValueTuple<Vector2, Vector2>(this.left_down_transform.position, this.right_up_transform.position);
	}

	// Token: 0x0600024F RID: 591 RVA: 0x0000C7BF File Offset: 0x0000A9BF
	public void Update_map_zone(Vector3 left_down_value, Vector3 right_up_value)
	{
		this.left_down_transform.position = left_down_value;
		this.right_up_transform.position = right_up_value;
	}

	// Token: 0x04000296 RID: 662
	[Header("Границы камеры:")]
	[SerializeField]
	private Transform left_down_transform;

	// Token: 0x04000297 RID: 663
	[SerializeField]
	private Transform right_up_transform;

	// Token: 0x04000298 RID: 664
	public static Zone_manager st;
}
