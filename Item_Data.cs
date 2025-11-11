using System;
using UnityEngine;

// Token: 0x0200001F RID: 31
[CreateAssetMenu(fileName = "Item_Data", menuName = "Item_Data/New Item Data", order = 111)]
public class Item_Data : ScriptableObject
{
	// Token: 0x060000A5 RID: 165 RVA: 0x00005FB8 File Offset: 0x000041B8
	public Sprite[] Return_All_Sprite_card_frame()
	{
		return this.card_frame_sprite;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00005FC0 File Offset: 0x000041C0
	public ValueTuple<Sprite, Sprite, string, Color, Color> RT_Data_item(Enums_Localization.Items_E item_Name_v, int I)
	{
		Debug.Log(string.Format("item_Name_v -{0}", item_Name_v));
		for (int i = 0; i < this.item_Groups.Length; i++)
		{
			if (item_Name_v == this.item_Groups[i].group_items_name)
			{
				return new ValueTuple<Sprite, Sprite, string, Color, Color>(this.card_frame_sprite[I], this.item_Groups[i].Card_Sprite, Localization_manager.st.LocalizationData.RT_local_text(item_Name_v), this.item_Groups[i].Text_Color, this.item_Groups[i].Text_Color);
			}
		}
		return new ValueTuple<Sprite, Sprite, string, Color, Color>(this.card_frame_sprite[0], this.item_Groups[0].Card_Sprite, "null", this.item_Groups[0].Text_Color, this.item_Groups[0].Text_Color);
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x000060A0 File Offset: 0x000042A0
	public Sprite Return_Icon_Sprite(Enums_Localization.Items_E item_group_enum)
	{
		for (int i = 0; i < this.item_Groups.Length; i++)
		{
			if (item_group_enum == this.item_Groups[i].group_items_name)
			{
				return this.item_Groups[i].Icon_Sprite;
			}
		}
		return this.item_Groups[0].Icon_Sprite;
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x000060F8 File Offset: 0x000042F8
	public string RT_ach_name(Enums_Localization.Items_E itemName)
	{
		string result = "";
		for (int i = 0; i < this.item_Groups.Length; i++)
		{
			if (this.item_Groups[i].group_items_name == itemName)
			{
				result = this.item_Groups[i].group_items_name.ToString();
			}
		}
		return result;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00006150 File Offset: 0x00004350
	public Color RT_color_group(Enums_Localization.Items_E item_value)
	{
		for (int i = 0; i < this.item_Groups.Length; i++)
		{
			if (item_value == this.item_Groups[i].group_items_name)
			{
				return this.item_Groups[i].Text_Color;
			}
		}
		return new Color(1f, 1f, 1f);
	}

	// Token: 0x040000A4 RID: 164
	[HideInInspector]
	public Item_Data.Item_Group[] item_Groups;

	// Token: 0x040000A5 RID: 165
	[HideInInspector]
	[SerializeField]
	public Sprite[] card_frame_sprite;

	// Token: 0x02000101 RID: 257
	[Serializable]
	public struct Item_Group
	{
		// Token: 0x04000734 RID: 1844
		public Enums_Localization.Items_E group_items_name;

		// Token: 0x04000735 RID: 1845
		public Sprite Card_Sprite;

		// Token: 0x04000736 RID: 1846
		public Sprite Icon_Sprite;

		// Token: 0x04000737 RID: 1847
		public Color Text_Color;

		// Token: 0x04000738 RID: 1848
		public string Ach_name;
	}

	// Token: 0x02000102 RID: 258
	[Serializable]
	public struct Language_name_text
	{
		// Token: 0x04000739 RID: 1849
		public St_main.Language_enum Language_enum;

		// Token: 0x0400073A RID: 1850
		public string Language_name;
	}
}
