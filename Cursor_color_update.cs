using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000044 RID: 68
public class Cursor_color_update : MonoBehaviour
{
	// Token: 0x060001BC RID: 444 RVA: 0x00009AE4 File Offset: 0x00007CE4
	private void Start()
	{
		Cursor.visible = false;
		this._this_image = base.GetComponent<Image>();
		this._color_button_up = this._this_image.color;
		this._color_r_tik_color = (this._color_button_up.r - this._color_button_down.r) / (this._count_tik * this._time_tik_multiply);
		this._color_g_tik_color = (this._color_button_up.g - this._color_button_down.g) / (this._count_tik * this._time_tik_multiply);
		this._color_b_tik_color = (this._color_button_up.b - this._color_button_down.b) / (this._count_tik * this._time_tik_multiply);
		this._color_a_tik_color = (this._color_button_up.a - this._color_button_down.a) / (this._count_tik * this._time_tik_multiply);
		this._color_r_tik_white = (this._color_button_up.r - this._color_button_down.r) / this._count_tik;
		this._color_g_tik_white = (this._color_button_up.g - this._color_button_down.g) / this._count_tik;
		this._color_b_tik_white = (this._color_button_up.b - this._color_button_down.b) / this._count_tik;
		this._color_a_tik_white = (this._color_button_up.a - this._color_button_down.a) / this._count_tik;
		this._color_button_moment = this._color_button_up;
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00009C5C File Offset: 0x00007E5C
	private void OnEnable()
	{
		EA.Find_Item = (Action<Enums_Localization.Items_E, Item_Main>)Delegate.Combine(EA.Find_Item, new Action<Enums_Localization.Items_E, Item_Main>(this.Color_new));
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00009C7E File Offset: 0x00007E7E
	private void OnDisable()
	{
		EA.Find_Item = (Action<Enums_Localization.Items_E, Item_Main>)Delegate.Remove(EA.Find_Item, new Action<Enums_Localization.Items_E, Item_Main>(this.Color_new));
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00009CA0 File Offset: 0x00007EA0
	private void Color_new(Enums_Localization.Items_E item_value, Item_Main dont_value)
	{
		this._color_button_down = this.item_data.RT_color_group(item_value);
		this._color_button_down.a = 1f;
		base.StopAllCoroutines();
		base.StartCoroutine(this.Color_white());
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00009CD7 File Offset: 0x00007ED7
	private IEnumerator Color_white()
	{
		this._color_plus = true;
		this._color_minus = false;
		while (this._color_plus)
		{
			if (this._color_button_moment.r < this._color_button_up.r)
			{
				this._color_button_moment.r = this._color_button_moment.r + this._color_r_tik_white;
			}
			else
			{
				this._color_button_moment.r = this._color_button_up.r;
			}
			if (this._color_button_moment.g < this._color_button_up.g)
			{
				this._color_button_moment.g = this._color_button_moment.g + this._color_g_tik_white;
			}
			else
			{
				this._color_button_moment.g = this._color_button_up.g;
			}
			if (this._color_button_moment.b < this._color_button_up.b)
			{
				this._color_button_moment.b = this._color_button_moment.b + this._color_b_tik_white;
			}
			else
			{
				this._color_button_moment.b = this._color_button_up.b;
			}
			if (this._color_button_moment.a < this._color_button_up.a)
			{
				this._color_button_moment.a = this._color_button_moment.a + this._color_b_tik_white;
			}
			else
			{
				this._color_button_moment.a = this._color_button_up.a;
			}
			this._this_image.color = new Color(this._color_button_moment.r, this._color_button_moment.g, this._color_button_moment.b, this._color_button_moment.a);
			if (this._color_button_moment.r == this._color_button_up.r && this._color_button_moment.g == this._color_button_up.g && this._color_button_moment.b == this._color_button_up.b && this._color_button_moment.a == this._color_button_up.a)
			{
				this._color_plus = false;
				this.Not_Dabl = true;
				break;
			}
			yield return new WaitForSeconds(this._time_tik);
		}
		this._color_r_tik_color = (this._color_button_up.r - this._color_button_down.r) / (this._count_tik * this._time_tik_multiply);
		this._color_g_tik_color = (this._color_button_up.g - this._color_button_down.g) / (this._count_tik * this._time_tik_multiply);
		this._color_b_tik_color = (this._color_button_up.b - this._color_button_down.b) / (this._count_tik * this._time_tik_multiply);
		this._color_a_tik_color = (this._color_button_up.a - this._color_button_down.a) / (this._count_tik * this._time_tik_multiply);
		this._color_r_tik_white = (this._color_button_up.r - this._color_button_down.r) / this._count_tik;
		this._color_g_tik_white = (this._color_button_up.g - this._color_button_down.g) / this._count_tik;
		this._color_b_tik_white = (this._color_button_up.b - this._color_button_down.b) / this._count_tik;
		this._color_a_tik_white = (this._color_button_up.a - this._color_button_down.a) / this._count_tik;
		yield return new WaitForSeconds(this._white_wait);
		base.StartCoroutine(this.Color_all());
		yield break;
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x00009CE6 File Offset: 0x00007EE6
	private IEnumerator Color_all()
	{
		this._color_plus = false;
		this._color_minus = true;
		while (this._color_minus)
		{
			if (this._color_button_moment.r > this._color_button_down.r)
			{
				this._color_button_moment.r = this._color_button_moment.r - this._color_r_tik_color;
			}
			else
			{
				this._color_button_moment.r = this._color_button_down.r;
			}
			if (this._color_button_moment.g > this._color_button_down.g)
			{
				this._color_button_moment.g = this._color_button_moment.g - this._color_g_tik_color;
			}
			else
			{
				this._color_button_moment.g = this._color_button_down.g;
			}
			if (this._color_button_moment.b > this._color_button_down.b)
			{
				this._color_button_moment.b = this._color_button_moment.b - this._color_b_tik_color;
			}
			else
			{
				this._color_button_moment.b = this._color_button_down.b;
			}
			if (this._color_button_moment.a > this._color_button_down.a)
			{
				this._color_button_moment.a = this._color_button_moment.a - this._color_b_tik_color;
			}
			else
			{
				this._color_button_moment.a = this._color_button_down.a;
			}
			this._this_image.color = new Color(this._color_button_moment.r, this._color_button_moment.g, this._color_button_moment.b, this._color_button_moment.a);
			if (this._color_button_moment.r == this._color_button_down.r && this._color_button_moment.g == this._color_button_down.g && this._color_button_moment.b == this._color_button_down.b && this._color_button_moment.a == this._color_button_down.a)
			{
				this._color_minus = false;
				break;
			}
			yield return new WaitForSeconds(this._time_tik);
		}
		yield break;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00009CF5 File Offset: 0x00007EF5
	public void Color_update()
	{
		this._color_button_down = this._color_full;
		this._color_button_down.a = 1f;
		base.StopAllCoroutines();
		base.StartCoroutine(this.Color_white());
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x00009D26 File Offset: 0x00007F26
	public void Color_load()
	{
		this._this_image.color = this._color_full;
	}

	// Token: 0x040001DA RID: 474
	private Color _color_button_up;

	// Token: 0x040001DB RID: 475
	[SerializeField]
	private Item_Data item_data;

	// Token: 0x040001DC RID: 476
	[SerializeField]
	private Color _color_button_down;

	// Token: 0x040001DD RID: 477
	[SerializeField]
	private Color _color_button_moment;

	// Token: 0x040001DE RID: 478
	[SerializeField]
	private Image _this_image;

	// Token: 0x040001DF RID: 479
	[SerializeField]
	private bool _color_plus;

	// Token: 0x040001E0 RID: 480
	[SerializeField]
	private bool _color_minus;

	// Token: 0x040001E1 RID: 481
	[SerializeField]
	private float _time_tik = 0.05f;

	// Token: 0x040001E2 RID: 482
	[SerializeField]
	private float _time_tik_multiply = 1f;

	// Token: 0x040001E3 RID: 483
	[SerializeField]
	private float _white_wait = 1f;

	// Token: 0x040001E4 RID: 484
	[SerializeField]
	private float _count_tik;

	// Token: 0x040001E5 RID: 485
	[SerializeField]
	private float _color_r_tik_color;

	// Token: 0x040001E6 RID: 486
	[SerializeField]
	private float _color_g_tik_color;

	// Token: 0x040001E7 RID: 487
	[SerializeField]
	private float _color_b_tik_color;

	// Token: 0x040001E8 RID: 488
	[SerializeField]
	private float _color_a_tik_color;

	// Token: 0x040001E9 RID: 489
	[SerializeField]
	private float _color_r_tik_white;

	// Token: 0x040001EA RID: 490
	[SerializeField]
	private float _color_g_tik_white;

	// Token: 0x040001EB RID: 491
	[SerializeField]
	private float _color_b_tik_white;

	// Token: 0x040001EC RID: 492
	[SerializeField]
	private float _color_a_tik_white;

	// Token: 0x040001ED RID: 493
	[SerializeField]
	private bool Not_Dabl = true;

	// Token: 0x040001EE RID: 494
	[SerializeField]
	private Color _color_full;
}
