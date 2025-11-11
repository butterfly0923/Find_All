using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000055 RID: 85
public static class EA
{
	// Token: 0x040002A1 RID: 673
	public static bool scroll_test = false;

	// Token: 0x040002A2 RID: 674
	public static bool find_test = true;

	// Token: 0x040002A3 RID: 675
	public static bool play_game = false;

	// Token: 0x040002A4 RID: 676
	public static bool first_load_scene = false;

	// Token: 0x040002A5 RID: 677
	public static bool down_panel_open = false;

	// Token: 0x040002A6 RID: 678
	public static Action Update_Language;

	// Token: 0x040002A7 RID: 679
	public static Action End_scene;

	// Token: 0x040002A8 RID: 680
	public static Action<Enums_Audio.Effect> Audio_effect_Play;

	// Token: 0x040002A9 RID: 681
	public static Action Audio_effect_find_item_play;

	// Token: 0x040002AA RID: 682
	public static Action<Enums_Audio.Music_group_variant, bool> Music_play;

	// Token: 0x040002AB RID: 683
	public static Action<Enums_Audio.Special_music> Special_music_play;

	// Token: 0x040002AC RID: 684
	public static Action<float, float> Music_turn_down;

	// Token: 0x040002AD RID: 685
	public static Action Load_level;

	// Token: 0x040002AE RID: 686
	public static Action Tutorial_1_open;

	// Token: 0x040002AF RID: 687
	public static Action DLC_open_Extra_level;

	// Token: 0x040002B0 RID: 688
	public static Action DLC_open;

	// Token: 0x040002B1 RID: 689
	public static Action Exit_game;

	// Token: 0x040002B2 RID: 690
	public static Action Update_map;

	// Token: 0x040002B3 RID: 691
	public static Action Reset_level_check;

	// Token: 0x040002B4 RID: 692
	public static Action Reset_level;

	// Token: 0x040002B5 RID: 693
	public static Action Exit_map_level_play;

	// Token: 0x040002B6 RID: 694
	public static Action<List<Enums_Localization.Items_E>> Set_new_cards;

	// Token: 0x040002B7 RID: 695
	public static Action<Card_mover, Enums_Localization.Items_E> Card_selection;

	// Token: 0x040002B8 RID: 696
	public static Action<Enums_Localization.Items_E> Return_Group_Item;

	// Token: 0x040002B9 RID: 697
	public static Action<Enums_Localization.Items_E> Set_Group_Find;

	// Token: 0x040002BA RID: 698
	public static Action<Enums_Localization.Items_E, Item_Main> Find_Item;

	// Token: 0x040002BB RID: 699
	public static Action Update_stady;

	// Token: 0x040002BC RID: 700
	public static Action<int, bool> Update_interactive_status;

	// Token: 0x040002BD RID: 701
	public static Action Escape_level;

	// Token: 0x040002BE RID: 702
	public static Action<int> LEVEL_COMPLITE;

	// Token: 0x040002BF RID: 703
	public static Action GAME_COMPLITE;

	// Token: 0x040002C0 RID: 704
	public static Action St_item_find;

	// Token: 0x040002C1 RID: 705
	public static Action St_reset_level;

	// Token: 0x040002C2 RID: 706
	public static Action St_puzzle_complite;

	// Token: 0x040002C3 RID: 707
	public static Action St_puzzle_segment_complite;

	// Token: 0x040002C4 RID: 708
	public static Action St_minuts;

	// Token: 0x040002C5 RID: 709
	public static Action St_final;

	// Token: 0x040002C6 RID: 710
	public static Action St_helper_use;

	// Token: 0x040002C7 RID: 711
	public static Action St_card_select;

	// Token: 0x040002C8 RID: 712
	public static Action Update_info_map;

	// Token: 0x040002C9 RID: 713
	public static Action St_communers;

	// Token: 0x040002CA RID: 714
	public static Action Help_update_setting;

	// Token: 0x040002CB RID: 715
	public static Action Help_button_down;

	// Token: 0x040002CC RID: 716
	public static Action<Vector3, Enums_Localization.Items_E> Help_find_item;

	// Token: 0x040002CD RID: 717
	public static Action<Vector3, Enum_Data.Puzzle_Name> Puzzle_arrow;

	// Token: 0x040002CE RID: 718
	public static Action Help_end_item_find_complite;

	// Token: 0x040002CF RID: 719
	public static Action<bool> Timer_play_stop;

	// Token: 0x040002D0 RID: 720
	public static Action<int> Scene_load_event;
}
