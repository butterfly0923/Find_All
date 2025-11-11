using System;
using UnityEngine;

// Token: 0x02000016 RID: 22
public class Bridge_Open_Zone : MonoBehaviour
{
	// Token: 0x06000067 RID: 103 RVA: 0x000034D1 File Offset: 0x000016D1
	public void Open_New_Zone()
	{
		Action help_end_item_find_complite = Events_Menu_UI.Help_end_item_find_complite;
		if (help_end_item_find_complite != null)
		{
			help_end_item_find_complite();
		}
		this.Right_Up_Point.transform.position = this.Right_Up_Point_2_Islands.transform.position;
	}

	// Token: 0x0400007D RID: 125
	[SerializeField]
	private Transform Right_Up_Point;

	// Token: 0x0400007E RID: 126
	[SerializeField]
	private Transform Right_Up_Point_2_Islands;
}
