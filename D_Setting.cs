using System;

// Token: 0x020000A8 RID: 168
[Serializable]
public class D_Setting
{
	// Token: 0x060004B6 RID: 1206 RVA: 0x000164FC File Offset: 0x000146FC
	public D_Setting()
	{
		this.FullScreenMode_Setting = 0;
		this.ResolutionMonitor_Setting = 0;
		this.Speed_interface = 1;
		this.Language_first_complite = false;
		this.Language_name_Setting = "english";
		this.Sound_Mixer = 1f;
		this.Music_Mixer = 1f;
		this.Sound_Item_Find = false;
		this.Sound_Group_Find = true;
		this.Glare = 1f;
		this.Speed_Camera = 0.5f;
		this.Speed_scroll = 3f;
		this.Momental_speed_UI = false;
		this.Speed_UI = 3f;
		this.Speed_cards_UI = 2f;
		this.Max_FPS = 240;
		this.Helper = true;
		this.Next_Card = true;
		this.Tutorial_Puzzle = false;
		this.Tutorial_Game = false;
		this.Timer_On = true;
		this.enter_game_stat = 0;
		this.reset_game_stat = 0;
		this.item_find_stat = 0;
		this.puzzle_complite_stat = 0;
		this.minuts_stat = 0;
		this.final_stat = 0;
		this.helper_use_stat = 0;
		this.card_select_stat = 0;
		this.wishers_stat = 0;
		this.communers_stat = 0;
	}

	// Token: 0x040004F6 RID: 1270
	public int FullScreenMode_Setting;

	// Token: 0x040004F7 RID: 1271
	public int ResolutionMonitor_Setting;

	// Token: 0x040004F8 RID: 1272
	public int Speed_interface;

	// Token: 0x040004F9 RID: 1273
	public bool Language_first_complite;

	// Token: 0x040004FA RID: 1274
	public string Language_name_Setting;

	// Token: 0x040004FB RID: 1275
	public float Sound_Mixer;

	// Token: 0x040004FC RID: 1276
	public float Music_Mixer;

	// Token: 0x040004FD RID: 1277
	public bool Sound_Item_Find;

	// Token: 0x040004FE RID: 1278
	public bool Sound_Group_Find;

	// Token: 0x040004FF RID: 1279
	public float Glare;

	// Token: 0x04000500 RID: 1280
	public float Speed_Camera;

	// Token: 0x04000501 RID: 1281
	public float Speed_UI;

	// Token: 0x04000502 RID: 1282
	public float Speed_cards_UI;

	// Token: 0x04000503 RID: 1283
	public bool Momental_speed_UI;

	// Token: 0x04000504 RID: 1284
	public int Max_FPS;

	// Token: 0x04000505 RID: 1285
	public bool Helper;

	// Token: 0x04000506 RID: 1286
	public bool Next_Card;

	// Token: 0x04000507 RID: 1287
	public bool Tutorial_Puzzle;

	// Token: 0x04000508 RID: 1288
	public bool Tutorial_Game;

	// Token: 0x04000509 RID: 1289
	public bool Timer_On;

	// Token: 0x0400050A RID: 1290
	public int enter_game_stat;

	// Token: 0x0400050B RID: 1291
	public int reset_game_stat;

	// Token: 0x0400050C RID: 1292
	public int item_find_stat;

	// Token: 0x0400050D RID: 1293
	public int puzzle_complite_stat;

	// Token: 0x0400050E RID: 1294
	public int puzzle_segment_complite_stat;

	// Token: 0x0400050F RID: 1295
	public int minuts_stat;

	// Token: 0x04000510 RID: 1296
	public int final_stat;

	// Token: 0x04000511 RID: 1297
	public int helper_use_stat;

	// Token: 0x04000512 RID: 1298
	public int card_select_stat;

	// Token: 0x04000513 RID: 1299
	public int wishers_stat;

	// Token: 0x04000514 RID: 1300
	public int communers_stat;

	// Token: 0x04000515 RID: 1301
	public float Speed_scroll;
}
