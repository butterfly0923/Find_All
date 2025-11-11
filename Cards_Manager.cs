using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000098 RID: 152
public class Cards_Manager : MonoBehaviour
{
	// Token: 0x060003FC RID: 1020 RVA: 0x00013B18 File Offset: 0x00011D18
	private void Awake()
	{
		this.black_back.enabled = false;
		if (Cards_Manager.st != null)
		{
			Object.Destroy(Cards_Manager.st.gameObject);
		}
		Cards_Manager.st = this;
		for (int i = 0; i < this.card_Mover_Selections.Length; i++)
		{
			this.card_Mover_Selections[i].Awake_setting(this.card_Move_SO, this.item_Data);
		}
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x00013B7F File Offset: 0x00011D7F
	private void OnEnable()
	{
		EA.Card_selection = (Action<Card_mover, Enums_Localization.Items_E>)Delegate.Combine(EA.Card_selection, new Action<Card_mover, Enums_Localization.Items_E>(this.return_select_group_item));
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x00013BA1 File Offset: 0x00011DA1
	private void OnDisable()
	{
		EA.Card_selection = (Action<Card_mover, Enums_Localization.Items_E>)Delegate.Remove(EA.Card_selection, new Action<Card_mover, Enums_Localization.Items_E>(this.return_select_group_item));
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x00013BC3 File Offset: 0x00011DC3
	private void Start()
	{
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x00013BC8 File Offset: 0x00011DC8
	public void setup_card(List<ValueTuple<Enums_Localization.Items_E, int>> item_list_v)
	{
		this.Random_List_test = new List<int>();
		for (int i = 0; i < this.item_Data.Return_All_Sprite_card_frame().Length; i++)
		{
			this.Random_List_test.Add(i);
		}
		this.random_list = new List<int>();
		for (int j = 0; j < item_list_v.Count; j++)
		{
			int index = Random.Range(0, this.Random_List_test.Count);
			this.random_list.Add(this.Random_List_test[index]);
			this.Random_List_test.RemoveAt(index);
		}
		if (item_list_v.Count > 1)
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.Card_variant, true);
			for (int k = 0; k < this._cardSelections.Length; k++)
			{
				this._cardSelections[k].enabled = true;
			}
			if (this.black_cooroutine != null)
			{
				base.StopCoroutine(this.black_cooroutine);
			}
			this.black_cooroutine = base.StartCoroutine(this.black_back_on());
		}
		else
		{
			for (int l = 0; l < this._cardSelections.Length; l++)
			{
				this._cardSelections[l].enabled = false;
			}
		}
		for (int m = 0; m < this.card_Mover_Selections.Length; m++)
		{
			if (m < item_list_v.Count)
			{
				this.card_Mover_Selections[m].setup_setting_card(item_list_v[m].Item1, item_list_v[m].Item2, this.variants_Count_Card[item_list_v.Count - 1].count_Card_And_Position[m].start_down_point, this.variants_Count_Card[item_list_v.Count - 1].count_Card_And_Position[m].center_monitor_point, this.variants_Count_Card[item_list_v.Count - 1].count_Card_And_Position[m].down_point, this.random_list[m], item_list_v.Count <= 1);
			}
			else
			{
				this.card_Mover_Selections[m].setup_not_card();
			}
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x00013DC9 File Offset: 0x00011FC9
	private IEnumerator black_back_on()
	{
		this.black_back.enabled = true;
		Color color_start_value = this.black_back.color;
		float value = 0f;
		while (value <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_black_on_off;
			this.black_back.color = Color.Lerp(color_start_value, this.color_select, this.black_on_curve.Evaluate(value));
		}
		yield break;
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00013DD8 File Offset: 0x00011FD8
	private IEnumerator black_back_off()
	{
		this.black_back.enabled = false;
		Color color_start_value = this.black_back.color;
		float value = 0f;
		while (value <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_black_on_off;
			this.black_back.color = Color.Lerp(color_start_value, this.color_deselect, value);
		}
		yield break;
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x00013DE8 File Offset: 0x00011FE8
	private void return_select_group_item(Card_mover card_Mover_v, Enums_Localization.Items_E item_Name_v)
	{
		Action<Enums_Localization.Items_E> return_Group_Item = EA.Return_Group_Item;
		if (return_Group_Item != null)
		{
			return_Group_Item(item_Name_v);
		}
		Debug.Log(string.Format(" Выбранный предмет - {0}", item_Name_v));
		SL_Data.st.Save_Game();
		if (this.black_cooroutine != null)
		{
			base.StopCoroutine(this.black_cooroutine);
		}
		this.black_cooroutine = base.StartCoroutine(this.black_back_off());
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00013E4B File Offset: 0x0001204B
	public string RT_name_ach_group(Enums_Localization.Items_E itemsE)
	{
		return this.item_Data.RT_ach_name(itemsE);
	}

	// Token: 0x0400044E RID: 1102
	[SerializeField]
	private Image black_back;

	// Token: 0x0400044F RID: 1103
	[SerializeField]
	private Color color_select;

	// Token: 0x04000450 RID: 1104
	[SerializeField]
	private Color color_deselect;

	// Token: 0x04000451 RID: 1105
	[SerializeField]
	private float speed_black_on_off;

	// Token: 0x04000452 RID: 1106
	[SerializeField]
	private AnimationCurve black_on_curve;

	// Token: 0x04000453 RID: 1107
	[SerializeField]
	private Cards_Manager.variant_count_card[] variants_Count_Card;

	// Token: 0x04000454 RID: 1108
	[SerializeField]
	private Card_mover[] card_Mover_Selections;

	// Token: 0x04000455 RID: 1109
	[SerializeField]
	private Item_Data item_Data;

	// Token: 0x04000456 RID: 1110
	[SerializeField]
	private Card_Move_SO card_Move_SO;

	// Token: 0x04000457 RID: 1111
	[SerializeField]
	private List<int> Random_List_test;

	// Token: 0x04000458 RID: 1112
	[SerializeField]
	private List<int> random_list;

	// Token: 0x04000459 RID: 1113
	[SerializeField]
	private Card_selection[] _cardSelections;

	// Token: 0x0400045A RID: 1114
	public static Cards_Manager st;

	// Token: 0x0400045B RID: 1115
	public List<Enums_Localization.Items_E> test_list;

	// Token: 0x0400045C RID: 1116
	[SerializeField]
	private bool card_select;

	// Token: 0x0400045D RID: 1117
	private Coroutine black_cooroutine;

	// Token: 0x020001C7 RID: 455
	[Serializable]
	public struct move_go_to_points
	{
		// Token: 0x040009E9 RID: 2537
		public RectTransform rectTransform;

		// Token: 0x040009EA RID: 2538
		public Vector3 start_down_point;

		// Token: 0x040009EB RID: 2539
		public Vector3 center_monitor_point;

		// Token: 0x040009EC RID: 2540
		public Vector3 down_point;

		// Token: 0x040009ED RID: 2541
		public Color text_color;
	}

	// Token: 0x020001C8 RID: 456
	[Serializable]
	public struct variant_count_card
	{
		// Token: 0x040009EE RID: 2542
		public Cards_Manager.count_card_and_position[] count_Card_And_Position;
	}

	// Token: 0x020001C9 RID: 457
	[Serializable]
	public struct count_card_and_position
	{
		// Token: 0x040009EF RID: 2543
		public Vector3 start_down_point;

		// Token: 0x040009F0 RID: 2544
		public Vector3 center_monitor_point;

		// Token: 0x040009F1 RID: 2545
		public Vector3 down_point;
	}
}
