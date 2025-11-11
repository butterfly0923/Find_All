using System;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class BW_open_house : Button_world_main
{
	// Token: 0x0600001C RID: 28 RVA: 0x000024CC File Offset: 0x000006CC
	private void Awake()
	{
		this.start_position_house_out = this.transform_house_out.position;
		this.start_position_house_in = this.transform_house_out.position;
		this.transform_house_in.position = new Vector3(this.start_position_house_in.x, this.start_position_house_in.y + (float)this.value_up_position, this.start_position_house_in.z);
		this.spriteRenderer_button.sprite = this.Enter_house;
		this.position_button_out = base.transform.position;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002558 File Offset: 0x00000758
	public override void Button_down()
	{
		Debug.Log("ДОМ ОТКРЫВАЕТСЯ/ЗАКРЫВАЕТСЯ");
		if (this.transform_house_in.position.y > (float)this.value_up_position / 2f)
		{
			this.transform_house_in.position = this.start_position_house_in;
			this.transform_house_out.position = new Vector3(this.start_position_house_out.x, this.start_position_house_out.y + (float)this.value_up_position, this.start_position_house_out.z);
			this.spriteRenderer_button.sprite = this.Exit_house;
			base.transform.position = this.position_button_in;
			return;
		}
		this.transform_house_in.position = new Vector3(this.start_position_house_in.x, this.start_position_house_in.y + (float)this.value_up_position, this.start_position_house_in.z);
		this.transform_house_out.position = this.start_position_house_out;
		this.spriteRenderer_button.sprite = this.Enter_house;
		base.transform.position = this.position_button_out;
	}

	// Token: 0x04000012 RID: 18
	[SerializeField]
	private Transform transform_house_out;

	// Token: 0x04000013 RID: 19
	private Vector3 start_position_house_out;

	// Token: 0x04000014 RID: 20
	[SerializeField]
	private Transform transform_house_in;

	// Token: 0x04000015 RID: 21
	private Vector3 start_position_house_in;

	// Token: 0x04000016 RID: 22
	[SerializeField]
	private int value_up_position;

	// Token: 0x04000017 RID: 23
	[SerializeField]
	private SpriteRenderer spriteRenderer_button;

	// Token: 0x04000018 RID: 24
	[SerializeField]
	private Sprite Enter_house;

	// Token: 0x04000019 RID: 25
	[SerializeField]
	private Sprite Exit_house;

	// Token: 0x0400001A RID: 26
	private Vector3 position_button_out;

	// Token: 0x0400001B RID: 27
	[SerializeField]
	private Vector3 position_button_in;
}
