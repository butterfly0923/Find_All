using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200006D RID: 109
public class Frame_Items : MonoBehaviour
{
	// Token: 0x060002CF RID: 719 RVA: 0x0000E160 File Offset: 0x0000C360
	private void Awake()
	{
		Frame_Items.st = (Frame_Items)Set_Singleton.This<Frame_Items, Frame_Items>(this, Frame_Items.st);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0000E177 File Offset: 0x0000C377
	private void Start()
	{
		this.item_Data = Level_Data.st.Item_data;
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0000E18C File Offset: 0x0000C38C
	public bool Add_Group_Items(Enums_Localization.Items_E item_group_value, int count_items_value)
	{
		SL_Data.st.Save_Game();
		if (item_group_value != Enums_Localization.Items_E.VOID)
		{
			for (int i = 0; i < this.slots_main.Length; i++)
			{
				if (this.slots_main[i].slot_item_enum == Enums_Localization.Items_E.VOID)
				{
					this.slots_main[i].slot_item_enum = item_group_value;
					this.set_stol(i, count_items_value);
					Action<Enums_Localization.Items_E> set_Group_Find = EA.Set_Group_Find;
					if (set_Group_Find != null)
					{
						set_Group_Find(item_group_value);
					}
					return true;
				}
			}
			return false;
		}
		return false;
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x0000E1FC File Offset: 0x0000C3FC
	public void Stady_Complite()
	{
		for (int i = 0; i < this.slots_main.Length; i++)
		{
			this.slots_main[i].count_item.text = "";
			this.slots_main[i].slot_item_enum = Enums_Localization.Items_E.VOID;
			this.slots_main[i].sprite_icon.sprite = this.item_Data.Return_Icon_Sprite(this.slots_main[i].slot_item_enum);
		}
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0000E27C File Offset: 0x0000C47C
	public int Return_Count_free_slot()
	{
		int num = 0;
		for (int i = 0; i < this.slots_main.Length; i++)
		{
			if (this.slots_main[i].slot_item_enum == Enums_Localization.Items_E.VOID)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0000E2B6 File Offset: 0x0000C4B6
	public Enums_Localization.Items_E Return_int_slot_item(int I)
	{
		return this.slots_main[I].slot_item_enum;
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x0000E2CC File Offset: 0x0000C4CC
	private void set_stol(int index_slot_v, int count_items_v)
	{
		this.slots_main[index_slot_v].count_item.text = (count_items_v.ToString() ?? "");
		this.slots_main[index_slot_v].sprite_icon.sprite = this.item_Data.Return_Icon_Sprite(this.slots_main[index_slot_v].slot_item_enum);
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x0000E334 File Offset: 0x0000C534
	public void Group_Find_item(Enums_Localization.Items_E item_group_v, int count_items_v)
	{
		if (count_items_v > 0)
		{
			for (int i = 0; i < this.slots_main.Length; i++)
			{
				if (this.slots_main[i].slot_item_enum == item_group_v)
				{
					this.slots_main[i].count_item.text = (count_items_v.ToString() ?? "");
				}
			}
			return;
		}
		for (int j = 0; j < this.slots_main.Length; j++)
		{
			if (this.slots_main[j].slot_item_enum == item_group_v)
			{
				this.slots_main[j].count_item.text = "";
				this.slots_main[j].slot_item_enum = Enums_Localization.Items_E.VOID;
				this.slots_main[j].sprite_icon.sprite = this.item_Data.Return_Icon_Sprite(this.slots_main[j].slot_item_enum);
			}
		}
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x0000E41C File Offset: 0x0000C61C
	public void All_count_update(int find_count_v, int max_count_v)
	{
		this.find_all_count.text = find_count_v.ToString() + "/" + max_count_v.ToString();
		this.count_and_text = false;
	}

	// Token: 0x0400039F RID: 927
	public static Frame_Items st;

	// Token: 0x040003A0 RID: 928
	[SerializeField]
	private Item_Data item_Data;

	// Token: 0x040003A1 RID: 929
	[SerializeField]
	private TMP_Text find_all_count;

	// Token: 0x040003A2 RID: 930
	[SerializeField]
	private Frame_Items.Slot_Main[] slots_main;

	// Token: 0x040003A3 RID: 931
	private St_main.Language_enum language_void;

	// Token: 0x040003A4 RID: 932
	private bool count_and_text;

	// Token: 0x020001A2 RID: 418
	[Serializable]
	public struct Slot_Main
	{
		// Token: 0x04000960 RID: 2400
		public Enums_Localization.Items_E slot_item_enum;

		// Token: 0x04000961 RID: 2401
		public TMP_Text count_item;

		// Token: 0x04000962 RID: 2402
		public Image sprite_icon;
	}
}
