using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000099 RID: 153
public class Card_mover : MonoBehaviour
{
	// Token: 0x06000406 RID: 1030 RVA: 0x00013E61 File Offset: 0x00012061
	public void Awake_setting(Card_Move_SO card_Move_SO_v, Item_Data item_Data_v)
	{
		this.card_Move_SO = card_Move_SO_v;
		this.item_Data = item_Data_v;
		this.card_Selection.Awake_setting(this.card_Move_SO, this);
		this.card_Selection.click_enabled_on_off(false);
		this.rectTransform = base.GetComponent<RectTransform>();
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x00013E9B File Offset: 0x0001209B
	private void OnEnable()
	{
		EA.Card_selection = (Action<Card_mover, Enums_Localization.Items_E>)Delegate.Combine(EA.Card_selection, new Action<Card_mover, Enums_Localization.Items_E>(this.Select_Card_End));
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x00013EBD File Offset: 0x000120BD
	private void OnDisable()
	{
		EA.Card_selection = (Action<Card_mover, Enums_Localization.Items_E>)Delegate.Remove(EA.Card_selection, new Action<Card_mover, Enums_Localization.Items_E>(this.Select_Card_End));
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x00013EE0 File Offset: 0x000120E0
	public void setup_setting_card(Enums_Localization.Items_E item_Name_v, int count_find_items, Vector3 start_down_position_v, Vector3 center_monitor_position_v, Vector3 end_position_select_v, int i, bool last_card_v = false)
	{
		this.start_down_position = start_down_position_v;
		this.center_monitor_position = center_monitor_position_v;
		this.end_position_select = end_position_select_v;
		this.item_Name = item_Name_v;
		this.count_item.text = (count_find_items.ToString() ?? "");
		Image image = this.frame;
		Image image2 = this.item_big;
		TMP_Text tmp_Text = this.name_item;
		TMP_Text tmp_Text2 = this.name_item;
		TMP_Text tmp_Text3 = this.count_item;
		ValueTuple<Sprite, Sprite, string, Color, Color> valueTuple = this.item_Data.RT_Data_item(this.item_Name, i);
		image.sprite = valueTuple.Item1;
		image2.sprite = valueTuple.Item2;
		tmp_Text.text = valueTuple.Item3;
		tmp_Text2.color = valueTuple.Item4;
		tmp_Text3.color = valueTuple.Item5;
		if (!last_card_v)
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_move_start_center());
		}
		else
		{
			this.coroutine = base.StartCoroutine(this.IE_move_last_card());
		}
		this.start_setting_to_move();
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x00013FF0 File Offset: 0x000121F0
	public void setup_last_card()
	{
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x00013FF2 File Offset: 0x000121F2
	public void setup_not_card()
	{
		this.card_Selection.gameObject.SetActive(false);
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00014008 File Offset: 0x00012208
	private void start_setting_to_move()
	{
		this.card_Selection.gameObject.SetActive(true);
		this.this_select_card = false;
		float num = 1f;
		this.frame.color = new Color(1f, 1f, 1f, num);
		this.item_big.color = new Color(1f, 1f, 1f, num);
		this.name_item.alpha = num;
		this.count_item.alpha = num;
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x0001408B File Offset: 0x0001228B
	public void select_this_card()
	{
		this.this_select_card = true;
		Action st_card_select = EA.St_card_select;
		if (st_card_select != null)
		{
			st_card_select();
		}
		Action<Card_mover, Enums_Localization.Items_E> card_selection = EA.Card_selection;
		if (card_selection == null)
		{
			return;
		}
		card_selection(this, this.item_Name);
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x000140BC File Offset: 0x000122BC
	private void Select_Card_End(Card_mover card_Mover_v, Enums_Localization.Items_E item_Name_v)
	{
		if (this.this_select_card)
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_move_center_down());
		}
		else
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_alpha_zero());
		}
		this.card_Selection.click_enabled_on_off(false);
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0001412B File Offset: 0x0001232B
	private IEnumerator IE_move_start_center()
	{
		float value_lerp = 0f;
		while (value_lerp < 1f)
		{
			value_lerp += this.card_Move_SO.Speed_card_start * Time.deltaTime * SL_Data.d_Setting.Speed_cards_UI;
			this.rectTransform.localPosition = Vector3.Lerp(this.start_down_position, this.center_monitor_position, this.card_Move_SO.Curve_move_start_center.Evaluate(value_lerp));
			this.rectTransform.localScale = new Vector3(this.card_Move_SO.Curve_size_start_center.Evaluate(value_lerp), this.card_Move_SO.Curve_size_start_center.Evaluate(value_lerp), 1f);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.card_Selection.click_enabled_on_off(true);
		yield break;
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x0001413A File Offset: 0x0001233A
	private IEnumerator IE_move_center_down()
	{
		float value_lerp = 1f;
		while (value_lerp > 0f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_lerp -= this.card_Move_SO.Speed_card_end * Time.deltaTime * SL_Data.d_Setting.Speed_cards_UI;
			this.rectTransform.localPosition = Vector3.Lerp(this.end_position_select, this.center_monitor_position, this.card_Move_SO.Curve_move_center_end.Evaluate(value_lerp));
			this.rectTransform.localScale = new Vector3(this.card_Move_SO.Curve_size_center_end.Evaluate(value_lerp), this.card_Move_SO.Curve_size_center_end.Evaluate(value_lerp), 1f);
			this.frame.color = new Color(1f, 1f, 1f, value_lerp);
			this.item_big.color = new Color(1f, 1f, 1f, value_lerp);
			this.name_item.alpha = value_lerp;
			this.count_item.alpha = value_lerp;
		}
		this.card_Selection.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x00014149 File Offset: 0x00012349
	private IEnumerator IE_alpha_zero()
	{
		float value_lerp = 1f;
		while (value_lerp > 0f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_lerp -= this.card_Move_SO.Speed_card_alpha * Time.deltaTime * SL_Data.d_Setting.Speed_cards_UI;
			this.frame.color = new Color(1f, 1f, 1f, value_lerp);
			this.item_big.color = new Color(1f, 1f, 1f, value_lerp);
			this.name_item.alpha = value_lerp;
			this.count_item.alpha = value_lerp;
		}
		this.card_Selection.gameObject.SetActive(false);
		yield break;
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x00014158 File Offset: 0x00012358
	private IEnumerator IE_move_last_card()
	{
		float value_lerp = 0f;
		while (value_lerp < 1f)
		{
			value_lerp += this.card_Move_SO.Speed_card_start * Time.deltaTime * SL_Data.d_Setting.Speed_cards_UI;
			this.rectTransform.localPosition = Vector3.Lerp(this.start_down_position, this.center_monitor_position, this.card_Move_SO.Curve_move_start_center.Evaluate(value_lerp));
			this.rectTransform.localScale = new Vector3(this.card_Move_SO.Curve_size_start_center.Evaluate(value_lerp), this.card_Move_SO.Curve_size_start_center.Evaluate(value_lerp), 1f);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield return new WaitForSeconds(this.card_Move_SO.Time_delay_last_card);
		this.select_this_card();
		yield break;
	}

	// Token: 0x0400045E RID: 1118
	[SerializeField]
	private Card_selection card_Selection;

	// Token: 0x0400045F RID: 1119
	private RectTransform rectTransform;

	// Token: 0x04000460 RID: 1120
	[SerializeField]
	private Vector3 start_down_position;

	// Token: 0x04000461 RID: 1121
	[SerializeField]
	private Vector3 center_monitor_position;

	// Token: 0x04000462 RID: 1122
	[SerializeField]
	private Vector3 end_position_select;

	// Token: 0x04000463 RID: 1123
	private Card_Move_SO card_Move_SO;

	// Token: 0x04000464 RID: 1124
	private Item_Data item_Data;

	// Token: 0x04000465 RID: 1125
	[SerializeField]
	private Image frame;

	// Token: 0x04000466 RID: 1126
	[SerializeField]
	private Image item_big;

	// Token: 0x04000467 RID: 1127
	[SerializeField]
	private TMP_Text name_item;

	// Token: 0x04000468 RID: 1128
	[SerializeField]
	private TMP_Text count_item;

	// Token: 0x04000469 RID: 1129
	private Enums_Localization.Items_E item_Name;

	// Token: 0x0400046A RID: 1130
	private bool this_select_card;

	// Token: 0x0400046B RID: 1131
	private Coroutine coroutine;
}
