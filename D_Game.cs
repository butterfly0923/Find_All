using System;

// Token: 0x020000A7 RID: 167
[Serializable]
public class D_Game
{
	// Token: 0x060004B3 RID: 1203 RVA: 0x00016030 File Offset: 0x00014230
	public D_Game()
	{
		this.first_enter_game = false;
		this.first_end_game = false;
		this.load_level = 0;
		this.current_level = 0;
		this.level_index_actual = 0;
		this.level_complite_first = new bool[10];
		this.level_complite = new bool[]
		{
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true,
			true
		};
		this.level_stage_find_complite = new bool[10];
		this.level_stage_quest_complite = new bool[10];
		this.quest_segment_complite = new bool[10, 50];
		this.find_items_group = new bool[10, 50, 30];
		this.level_group_active_find = new bool[10, 50];
		this.level_group_find_complite = new bool[10, 50];
		this.all_levels = 5;
		this.Time_Help_level = 0f;
		this.ACH_hot_help_item_count = 0;
		this.level_max = 3;
		this.stady_max = 5;
		this.group_max = 50;
		this.detail_max = 50;
		this.interactive_max = 50;
		this.find_group_max = 3;
		this.sl_level_complite = new bool[this.level_max];
		this.sl_stady_complite = new bool[this.level_max, this.stady_max];
		this.sl_level_complite_first = new bool[this.level_max];
		this.sl_stady_complite_first = new bool[this.level_max, this.stady_max];
		this.sl_details = new bool[this.level_max, this.stady_max, this.group_max, this.detail_max];
		this.sl_interactive_use = new bool[this.level_max, this.stady_max, this.interactive_max];
		this.sl_interactive = new bool[this.level_max, this.stady_max, this.interactive_max];
		this.sl_active = new bool[this.level_max, this.stady_max, this.group_max];
		this.sl_complite = new bool[this.level_max, this.stady_max, this.group_max];
		this.sl_add = new int[this.level_max, this.stady_max, this.find_group_max];
		for (int i = 0; i < this.sl_add.GetLength(0); i++)
		{
			for (int j = 0; j < this.sl_add.GetLength(1); j++)
			{
				for (int k = 0; k < this.sl_add.GetLength(2); k++)
				{
					this.sl_add[i, j, k] = -1;
				}
			}
		}
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x00016284 File Offset: 0x00014484
	public void Reset_level(int index_value)
	{
		if (index_value == 0)
		{
			this.Timer_complite_level_1 = 0f;
		}
		if (index_value == 2)
		{
			this.Timer_complite_level_old = 0f;
		}
		this.ACH_hot_help_item_count = 0;
		this.level_stage_find_complite[index_value] = false;
		this.level_stage_quest_complite[index_value] = false;
		this.sl_level_complite[index_value] = false;
		for (int i = 0; i < this.sl_stady_complite.GetLength(1); i++)
		{
			this.sl_stady_complite[index_value, i] = false;
		}
		for (int j = 0; j < this.sl_details.GetLength(1); j++)
		{
			for (int k = 0; k < this.sl_details.GetLength(2); k++)
			{
				for (int l = 0; l < this.sl_details.GetLength(3); l++)
				{
					this.sl_details[index_value, j, k, l] = false;
				}
			}
		}
		for (int m = 0; m < this.sl_interactive_use.GetLength(1); m++)
		{
			for (int n = 0; n < this.sl_interactive_use.GetLength(2); n++)
			{
				this.sl_interactive_use[index_value, m, n] = false;
			}
		}
		for (int num = 0; num < this.sl_interactive.GetLength(1); num++)
		{
			for (int num2 = 0; num2 < this.sl_interactive.GetLength(2); num2++)
			{
				this.sl_interactive[index_value, num, num2] = false;
			}
		}
		for (int num3 = 0; num3 < this.sl_active.GetLength(1); num3++)
		{
			for (int num4 = 0; num4 < this.sl_active.GetLength(2); num4++)
			{
				this.sl_active[index_value, num3, num4] = false;
			}
		}
		for (int num5 = 0; num5 < this.sl_complite.GetLength(1); num5++)
		{
			for (int num6 = 0; num6 < this.sl_complite.GetLength(2); num6++)
			{
				this.sl_complite[index_value, num5, num6] = false;
			}
		}
		for (int num7 = 0; num7 < this.sl_add.GetLength(1); num7++)
		{
			for (int num8 = 0; num8 < this.sl_add.GetLength(2); num8++)
			{
				this.sl_add[index_value, num7, num8] = -1;
			}
		}
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x000164B0 File Offset: 0x000146B0
	public void Reset_All_Game()
	{
		for (int i = 0; i < this.level_complite_first.Length; i++)
		{
			this.Reset_level(i);
		}
		this.load_level = -1;
		this.current_level = 0;
		this.level_index_actual = 0;
		Action action = EA.Load_level;
		if (action == null)
		{
			return;
		}
		action();
	}

	// Token: 0x040004D1 RID: 1233
	public int load_level;

	// Token: 0x040004D2 RID: 1234
	public int current_level;

	// Token: 0x040004D3 RID: 1235
	public int level_index_actual;

	// Token: 0x040004D4 RID: 1236
	public bool[] level_complite_first;

	// Token: 0x040004D5 RID: 1237
	public bool[] level_complite;

	// Token: 0x040004D6 RID: 1238
	public bool[] level_stage_find_complite;

	// Token: 0x040004D7 RID: 1239
	public bool[] level_stage_quest_complite;

	// Token: 0x040004D8 RID: 1240
	public bool[,] quest_segment_complite;

	// Token: 0x040004D9 RID: 1241
	public bool[,,] find_items_group;

	// Token: 0x040004DA RID: 1242
	public bool[,] level_group_active_find;

	// Token: 0x040004DB RID: 1243
	public bool[,] level_group_find_complite;

	// Token: 0x040004DC RID: 1244
	public int all_levels;

	// Token: 0x040004DD RID: 1245
	public float Timer_complite_level_1;

	// Token: 0x040004DE RID: 1246
	public float Timer_complite_level_old;

	// Token: 0x040004DF RID: 1247
	public float Time_Help_level;

	// Token: 0x040004E0 RID: 1248
	public int ACH_hot_help_item_count;

	// Token: 0x040004E1 RID: 1249
	public bool first_enter_game;

	// Token: 0x040004E2 RID: 1250
	public bool first_end_game;

	// Token: 0x040004E3 RID: 1251
	public bool first_load_scene;

	// Token: 0x040004E4 RID: 1252
	public int level_max;

	// Token: 0x040004E5 RID: 1253
	public int stady_max;

	// Token: 0x040004E6 RID: 1254
	public int group_max;

	// Token: 0x040004E7 RID: 1255
	public int detail_max;

	// Token: 0x040004E8 RID: 1256
	public int interactive_max;

	// Token: 0x040004E9 RID: 1257
	public int find_group_max;

	// Token: 0x040004EA RID: 1258
	public bool[] sl_level_complite;

	// Token: 0x040004EB RID: 1259
	public bool[,] sl_stady_complite;

	// Token: 0x040004EC RID: 1260
	public bool[] sl_level_complite_first;

	// Token: 0x040004ED RID: 1261
	public bool[,] sl_stady_complite_first;

	// Token: 0x040004EE RID: 1262
	public bool[,,,] sl_details;

	// Token: 0x040004EF RID: 1263
	public bool[,,] sl_interactive_use;

	// Token: 0x040004F0 RID: 1264
	public bool[,,] sl_interactive;

	// Token: 0x040004F1 RID: 1265
	public bool[,,] sl_active;

	// Token: 0x040004F2 RID: 1266
	public bool[,,] sl_complite;

	// Token: 0x040004F3 RID: 1267
	public int[,,] sl_add;

	// Token: 0x040004F4 RID: 1268
	public bool first_set_next_stady;

	// Token: 0x040004F5 RID: 1269
	public int[] active_index_in_stady;
}
