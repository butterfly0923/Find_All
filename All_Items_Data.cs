using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[CreateAssetMenu(fileName = "All_Items_Data", menuName = "Item_Data/All_Items_Data", order = 117)]
public class All_Items_Data : ScriptableObject
{
	// Token: 0x060002AF RID: 687 RVA: 0x0000DC1C File Offset: 0x0000BE1C
	[ContextMenu("Creat_List_All_enums_item")]
	public void Creat_List_All_enums_item()
	{
		this.find_group_sprite = new Struct_Level.Find_group_sprite[Enum.GetValues(typeof(Enums_Localization.Items_E)).Length];
		Array values = Enum.GetValues(typeof(Enums_Localization.Items_E));
		for (int i = 0; i < this.find_group_sprite.Length; i++)
		{
			this.find_group_sprite[i].Item_Group = (Enums_Localization.Items_E)values.GetValue(i);
		}
	}

	// Token: 0x0400037A RID: 890
	[Header("Размер икинок:")]
	[Range(10f, 100f)]
	[SerializeField]
	public float size_icon = 10f;

	// Token: 0x0400037B RID: 891
	[Header("Все группы и предметы для поиска:")]
	public Struct_Level.Find_group_sprite[] find_group_sprite;
}
