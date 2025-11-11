using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
public class Cloud_move_old : MonoBehaviour
{
	// Token: 0x060001B3 RID: 435 RVA: 0x000098DC File Offset: 0x00007ADC
	private void Start()
	{
		this._this_transform = base.GetComponent<Transform>();
		this.cloud_position = this._this_transform.position;
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x000098FC File Offset: 0x00007AFC
	private void FixedUpdate()
	{
		if (this.Left_right)
		{
			this.cloud_position = new Vector3(this.cloud_position.x + this.cloud_speed, this.cloud_position.y, this.cloud_position.z);
			if (this.cloud_position.x > this.point_left_right.y)
			{
				this.cloud_position = new Vector3(this.point_left_right.x, this.cloud_position.y, this.cloud_position.z);
			}
		}
		else
		{
			this.cloud_position = new Vector3(this.cloud_position.x - this.cloud_speed, this.cloud_position.y, this.cloud_position.z);
			if (this.cloud_position.x < this.point_left_right.x)
			{
				this.cloud_position = new Vector3(this.point_left_right.y, this.cloud_position.y, this.cloud_position.z);
			}
		}
		this._this_transform.position = this.cloud_position;
	}

	// Token: 0x040001D0 RID: 464
	private Transform _this_transform;

	// Token: 0x040001D1 RID: 465
	private Vector3 cloud_position;

	// Token: 0x040001D2 RID: 466
	[SerializeField]
	private bool Left_right = true;

	// Token: 0x040001D3 RID: 467
	[SerializeField]
	private float cloud_speed;

	// Token: 0x040001D4 RID: 468
	[SerializeField]
	private float coef = 20f;

	// Token: 0x040001D5 RID: 469
	[SerializeField]
	private Vector2 point_left_right;
}
