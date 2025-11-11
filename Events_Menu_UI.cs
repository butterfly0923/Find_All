using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000024 RID: 36
public static class Events_Menu_UI
{
	// Token: 0x040000D4 RID: 212
	public static bool level_load_map;

	// Token: 0x040000D5 RID: 213
	public static Action<int[], string> a_Reset_Level_Data;

	// Token: 0x040000D6 RID: 214
	public static Action<int[], string> a_reset_level;

	// Token: 0x040000D7 RID: 215
	public static Action<List<Enums_Localization.Items_E>> Set_new_cards;

	// Token: 0x040000D8 RID: 216
	public static Action<Card_mover, Enums_Localization.Items_E> Card_selection;

	// Token: 0x040000D9 RID: 217
	public static Action<Enums_Localization.Items_E> Return_Group_Item;

	// Token: 0x040000DA RID: 218
	public static Action<Enums_Localization.Items_E> Start_Group_Find;

	// Token: 0x040000DB RID: 219
	public static Action<Enums_Localization.Items_E> item_Find_add;

	// Token: 0x040000DC RID: 220
	public static Action Group_item_find_SOUND;

	// Token: 0x040000DD RID: 221
	public static Action<int> count_find_items;

	// Token: 0x040000DE RID: 222
	public static Action Help_button_down;

	// Token: 0x040000DF RID: 223
	public static Action<Transform, Enums_Localization.Items_E> Help_find_item;

	// Token: 0x040000E0 RID: 224
	public static Action<Transform, Enums_Localization.Items_E> Help_arrow_find;

	// Token: 0x040000E1 RID: 225
	public static Action Help_end_item_find_complite;

	// Token: 0x040000E2 RID: 226
	public static Action<Transform, Enum_Data.Puzzle_Name> Puzzle_arrow;

	// Token: 0x040000E3 RID: 227
	public static Action<bool, bool> Puzzle_stady_on_off;

	// Token: 0x040000E4 RID: 228
	public static Action<Puzzle_Manager> Puzzle_Complite;

	// Token: 0x040000E5 RID: 229
	public static Action<Puzzle_Manager, int> Puzzle_Segment_Complite;

	// Token: 0x040000E6 RID: 230
	public static Action<int> End_Level;

	// Token: 0x040000E7 RID: 231
	public static Action Open_Tutorial_Game;

	// Token: 0x040000E8 RID: 232
	public static Action Open_Tutorial_Puzzle;

	// Token: 0x040000E9 RID: 233
	public static Action Puzzle_END_DEMO;

	// Token: 0x040000EA RID: 234
	public static Action Open_puzzle_help;

	// Token: 0x040000EB RID: 235
	public static Action<string> Update_key_map;

	// Token: 0x040000EC RID: 236
	public static Action St_item_find;

	// Token: 0x040000ED RID: 237
	public static Action St_reset_level;

	// Token: 0x040000EE RID: 238
	public static Action St_puzzle_complite;

	// Token: 0x040000EF RID: 239
	public static Action St_puzzle_segment_complite;

	// Token: 0x040000F0 RID: 240
	public static Action St_minuts;

	// Token: 0x040000F1 RID: 241
	public static Action St_final;

	// Token: 0x040000F2 RID: 242
	public static Action St_helper_use;

	// Token: 0x040000F3 RID: 243
	public static Action St_card_select;

	// Token: 0x040000F4 RID: 244
	public static Action Update_info_map;

	// Token: 0x040000F5 RID: 245
	public static Action St_communers;
}
