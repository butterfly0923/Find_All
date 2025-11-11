using System;
using UnityEngine;

// Token: 0x020000B6 RID: 182
public static class Structs
{
	// Token: 0x020001F8 RID: 504
	[Serializable]
	public struct Localization_language
	{
		// Token: 0x04000A98 RID: 2712
		public Structs.Menu_Button_L[] MenuButtons;

		// Token: 0x04000A99 RID: 2713
		public Structs.Setting_Button_L[] SettingButtons;

		// Token: 0x04000A9A RID: 2714
		public Structs.Screen_modes_L[] ScreenModes;

		// Token: 0x04000A9B RID: 2715
		public Structs.Speed_interface_modes_L[] SpeedInterface;

		// Token: 0x04000A9C RID: 2716
		public Structs.ItemGroup_L[] ItemGroup;

		// Token: 0x04000A9D RID: 2717
		public Structs.Add_Interface_L[] AddInterface;
	}

	// Token: 0x020001F9 RID: 505
	[Serializable]
	public struct Menu_Button_L
	{
		// Token: 0x04000A9E RID: 2718
		public Enums_Localization.Menu_E function_E;

		// Token: 0x04000A9F RID: 2719
		public string text_L;
	}

	// Token: 0x020001FA RID: 506
	[Serializable]
	public struct Setting_Button_L
	{
		// Token: 0x04000AA0 RID: 2720
		public Enums_Localization.Setting_E function_E;

		// Token: 0x04000AA1 RID: 2721
		public string text_L;
	}

	// Token: 0x020001FB RID: 507
	[Serializable]
	public struct Screen_modes_L
	{
		// Token: 0x04000AA2 RID: 2722
		public Enums_Localization.Screen_mode_E function_E;

		// Token: 0x04000AA3 RID: 2723
		public string text_L;
	}

	// Token: 0x020001FC RID: 508
	[Serializable]
	public struct Speed_interface_modes_L
	{
		// Token: 0x04000AA4 RID: 2724
		public Enums_Localization.Speed_interface_E function_E;

		// Token: 0x04000AA5 RID: 2725
		public string text_L;
	}

	// Token: 0x020001FD RID: 509
	[Serializable]
	public struct Add_Interface_L
	{
		// Token: 0x04000AA6 RID: 2726
		public Enums_Localization.Add_Interface_E function_E;

		// Token: 0x04000AA7 RID: 2727
		public string text_L;
	}

	// Token: 0x020001FE RID: 510
	[Serializable]
	public struct Language_steam_name
	{
		// Token: 0x04000AA8 RID: 2728
		public Enums_Localization.Language_E language_enum;

		// Token: 0x04000AA9 RID: 2729
		public string language_name;

		// Token: 0x04000AAA RID: 2730
		public string language_steam;

		// Token: 0x04000AAB RID: 2731
		public string file_path;

		// Token: 0x04000AAC RID: 2732
		public bool localization_complite;
	}

	// Token: 0x020001FF RID: 511
	[Serializable]
	public struct Audio_Clip
	{
		// Token: 0x04000AAD RID: 2733
		public Enums_Audio.Effect clip_name;

		// Token: 0x04000AAE RID: 2734
		public AudioClip clip;

		// Token: 0x04000AAF RID: 2735
		public bool turn_down;

		// Token: 0x04000AB0 RID: 2736
		[Range(0f, 1f)]
		public float volume_down;

		// Token: 0x04000AB1 RID: 2737
		[Range(0f, 3f)]
		public float speed;

		// Token: 0x04000AB2 RID: 2738
		[Range(0f, 1f)]
		public float volume;

		// Token: 0x04000AB3 RID: 2739
		public float start_time;
	}

	// Token: 0x02000200 RID: 512
	[Serializable]
	public struct ItemGroup_L
	{
		// Token: 0x04000AB4 RID: 2740
		public Enums_Localization.Items_E function_E;

		// Token: 0x04000AB5 RID: 2741
		public string text_L;
	}
}
