using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[CreateAssetMenu(fileName = "Puzzle_Data", menuName = "Item_Data/New Puzzle Data", order = 111)]
public class Puzzle_Data : ScriptableObject
{
	// Token: 0x0600026B RID: 619 RVA: 0x0000CDC4 File Offset: 0x0000AFC4
	public Sprite Return_Icon_Sprite(Enum_Data.Puzzle_Name item_group_enum)
	{
		for (int i = 0; i < this.puzzle_name_sprite.Length; i++)
		{
			if (item_group_enum == this.puzzle_name_sprite[i].puzzle_name)
			{
				return this.puzzle_name_sprite[i].Puzzle_Sprite;
			}
		}
		return this.puzzle_name_sprite[0].Puzzle_Sprite;
	}

	// Token: 0x040002F9 RID: 761
	public Puzzle_Data.Puzzle_name_sprite[] puzzle_name_sprite;

	// Token: 0x02000169 RID: 361
	[Serializable]
	public struct Puzzle_name_sprite
	{
		// Token: 0x04000919 RID: 2329
		public Enum_Data.Puzzle_Name puzzle_name;

		// Token: 0x0400091A RID: 2330
		public Sprite Puzzle_Sprite;
	}

	// Token: 0x0200016A RID: 362
	[Serializable]
	public struct Language_name_text
	{
		// Token: 0x0400091B RID: 2331
		public St_main.Language_enum Language_enum;

		// Token: 0x0400091C RID: 2332
		public string Language_name;
	}
}
