using System;
using System.Collections;
using Steamworks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Token: 0x020000AA RID: 170
public class SL_Data : MonoBehaviour
{
	// Token: 0x060004B9 RID: 1209 RVA: 0x00016624 File Offset: 0x00014824
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		SL_Data.st = (SL_Data)Set_Singleton.This<SL_Data, Frame_Items>(this, Frame_Items.st);
		this.storage = new Storage();
		SL_Data.d_Setting = new D_Setting();
		SL_Data.d_Game = new D_Game();
		this.Load_start_game();
		this.reset_data_game = Sa_IS.input_Main.All.Reset_data_game;
		this.reset_data_setting = Sa_IS.input_Main.All.Reset_data_setting;
		this.reset_this_scene = Sa_IS.input_Main.All.Reset_this_scene;
		this.reset_press = Sa_IS.input_Main.All.Reset_data_press_key;
		this.ia_U = Sa_IS.input_Main.am_setting.U;
		this.ia_N = Sa_IS.input_Main.am_setting.N;
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x00016708 File Offset: 0x00014908
	private void OnEnable()
	{
		if (EA.scroll_test)
		{
			this.reset_data_game.started += this.reset_save_game;
			this.reset_data_setting.started += this.reset_save_setting;
			this.reset_this_scene.started += this.reset_scene;
		}
		Events_Menu_UI.St_item_find = (Action)Delegate.Combine(Events_Menu_UI.St_item_find, new Action(this.LB_item_find));
		Events_Menu_UI.St_reset_level = (Action)Delegate.Combine(Events_Menu_UI.St_reset_level, new Action(this.LB_reset_game));
		Events_Menu_UI.St_puzzle_complite = (Action)Delegate.Combine(Events_Menu_UI.St_puzzle_complite, new Action(this.LB_puzzle_complite));
		Events_Menu_UI.St_puzzle_segment_complite = (Action)Delegate.Combine(Events_Menu_UI.St_puzzle_segment_complite, new Action(this.LB_puzzle_segment_complite));
		Events_Menu_UI.St_minuts = (Action)Delegate.Combine(Events_Menu_UI.St_minuts, new Action(this.LB_minuts));
		Events_Menu_UI.St_final = (Action)Delegate.Combine(Events_Menu_UI.St_final, new Action(this.LB_final));
		Events_Menu_UI.St_helper_use = (Action)Delegate.Combine(Events_Menu_UI.St_helper_use, new Action(this.LB_helper_use));
		Events_Menu_UI.St_card_select = (Action)Delegate.Combine(Events_Menu_UI.St_card_select, new Action(this.LB_card_select));
		this.ia_U.started += this.U_;
		this.ia_N.started += this.N_;
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x00016890 File Offset: 0x00014A90
	private void OnDisable()
	{
		if (EA.scroll_test)
		{
			this.reset_data_game.started -= this.reset_save_game;
			this.reset_data_setting.started -= this.reset_save_setting;
			this.reset_this_scene.started -= this.reset_scene;
		}
		Events_Menu_UI.St_item_find = (Action)Delegate.Remove(Events_Menu_UI.St_item_find, new Action(this.LB_item_find));
		Events_Menu_UI.St_reset_level = (Action)Delegate.Remove(Events_Menu_UI.St_reset_level, new Action(this.LB_reset_game));
		Events_Menu_UI.St_puzzle_complite = (Action)Delegate.Remove(Events_Menu_UI.St_puzzle_complite, new Action(this.LB_puzzle_complite));
		Events_Menu_UI.St_puzzle_segment_complite = (Action)Delegate.Remove(Events_Menu_UI.St_puzzle_segment_complite, new Action(this.LB_puzzle_segment_complite));
		Events_Menu_UI.St_minuts = (Action)Delegate.Remove(Events_Menu_UI.St_minuts, new Action(this.LB_minuts));
		Events_Menu_UI.St_final = (Action)Delegate.Remove(Events_Menu_UI.St_final, new Action(this.LB_final));
		Events_Menu_UI.St_helper_use = (Action)Delegate.Remove(Events_Menu_UI.St_helper_use, new Action(this.LB_helper_use));
		Events_Menu_UI.St_card_select = (Action)Delegate.Remove(Events_Menu_UI.St_card_select, new Action(this.LB_card_select));
		this.ia_U.started -= this.U_;
		this.ia_N.started -= this.N_;
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x00016A17 File Offset: 0x00014C17
	public void reset_save_game()
	{
		Debug.Log("Reset save game - complite");
		SL_Data.d_Game = new D_Game();
		this.Save_Game();
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x00016A34 File Offset: 0x00014C34
	public void update_game_data()
	{
		if (SL_Data.d_Game.sl_level_complite.Length <= 2)
		{
			D_Game d_Game = SL_Data.d_Game;
			SL_Data.d_Game = new D_Game();
			SL_Data.d_Game.first_enter_game = d_Game.first_enter_game;
			SL_Data.d_Game.first_end_game = d_Game.first_end_game;
			SL_Data.d_Game.load_level = d_Game.load_level;
			SL_Data.d_Game.current_level = d_Game.current_level;
			SL_Data.d_Game.level_index_actual = d_Game.level_index_actual;
			SL_Data.d_Game.Time_Help_level = d_Game.Time_Help_level;
			SL_Data.d_Game.ACH_hot_help_item_count = d_Game.ACH_hot_help_item_count;
			for (int i = 0; i < d_Game.sl_level_complite.GetLength(0); i++)
			{
				SL_Data.d_Game.sl_level_complite[i] = d_Game.sl_level_complite[i];
			}
			for (int j = 0; j < d_Game.sl_level_complite_first.GetLength(0); j++)
			{
				SL_Data.d_Game.sl_level_complite_first[j] = d_Game.sl_level_complite_first[j];
			}
			for (int k = 0; k < d_Game.sl_stady_complite.GetLength(0); k++)
			{
				for (int l = 0; l < d_Game.sl_stady_complite.GetLength(1); l++)
				{
					SL_Data.d_Game.sl_stady_complite[k, l] = d_Game.sl_stady_complite[k, l];
				}
			}
			for (int m = 0; m < d_Game.sl_stady_complite_first.GetLength(0); m++)
			{
				for (int n = 0; n < d_Game.sl_stady_complite_first.GetLength(1); n++)
				{
					SL_Data.d_Game.sl_stady_complite_first[m, n] = d_Game.sl_stady_complite_first[m, n];
				}
			}
			for (int num = 0; num < d_Game.sl_details.GetLength(0); num++)
			{
				for (int num2 = 0; num2 < d_Game.sl_details.GetLength(1); num2++)
				{
					for (int num3 = 0; num3 < d_Game.sl_details.GetLength(2); num3++)
					{
						for (int num4 = 0; num4 < d_Game.sl_details.GetLength(3); num4++)
						{
							SL_Data.d_Game.sl_details[num, num2, num3, num4] = d_Game.sl_details[num, num2, num3, num4];
						}
					}
				}
			}
			for (int num5 = 0; num5 < d_Game.sl_interactive_use.GetLength(0); num5++)
			{
				for (int num6 = 0; num6 < d_Game.sl_interactive_use.GetLength(1); num6++)
				{
					for (int num7 = 0; num7 < d_Game.sl_interactive_use.GetLength(2); num7++)
					{
						SL_Data.d_Game.sl_interactive_use[num5, num6, num7] = d_Game.sl_interactive_use[num5, num6, num7];
					}
				}
			}
			for (int num8 = 0; num8 < d_Game.sl_interactive.GetLength(0); num8++)
			{
				for (int num9 = 0; num9 < d_Game.sl_interactive.GetLength(1); num9++)
				{
					for (int num10 = 0; num10 < d_Game.sl_interactive.GetLength(2); num10++)
					{
						SL_Data.d_Game.sl_interactive[num8, num9, num10] = d_Game.sl_interactive[num8, num9, num10];
					}
				}
			}
			for (int num11 = 0; num11 < d_Game.sl_active.GetLength(0); num11++)
			{
				for (int num12 = 0; num12 < d_Game.sl_active.GetLength(1); num12++)
				{
					for (int num13 = 0; num13 < d_Game.sl_active.GetLength(2); num13++)
					{
						SL_Data.d_Game.sl_active[num11, num12, num13] = d_Game.sl_active[num11, num12, num13];
					}
				}
			}
			for (int num14 = 0; num14 < d_Game.sl_complite.GetLength(0); num14++)
			{
				for (int num15 = 0; num15 < d_Game.sl_complite.GetLength(1); num15++)
				{
					for (int num16 = 0; num16 < d_Game.sl_complite.GetLength(2); num16++)
					{
						SL_Data.d_Game.sl_complite[num14, num15, num16] = d_Game.sl_complite[num14, num15, num16];
					}
				}
			}
			for (int num17 = 0; num17 < d_Game.sl_add.GetLength(0); num17++)
			{
				for (int num18 = 0; num18 < d_Game.sl_add.GetLength(1); num18++)
				{
					for (int num19 = 0; num19 < d_Game.sl_add.GetLength(2); num19++)
					{
						SL_Data.d_Game.sl_add[num17, num18, num19] = d_Game.sl_add[num17, num18, num19];
					}
				}
			}
		}
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00016EC2 File Offset: 0x000150C2
	private void reset_save_game(InputAction.CallbackContext cc)
	{
		Debug.Log("Reset save game - complite");
		SL_Data.d_Game = new D_Game();
		this.Save_Game();
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x00016EDE File Offset: 0x000150DE
	private void reset_save_setting(InputAction.CallbackContext cc)
	{
		Debug.Log("Reset save setting - start");
		if (this.reset_press.IsPressed())
		{
			Debug.Log("Reset save setting - complite");
			SL_Data.d_Setting = new D_Setting();
			this.Save_Setting();
		}
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x00016F14 File Offset: 0x00015114
	private void reset_scene(InputAction.CallbackContext cc)
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x00016F33 File Offset: 0x00015133
	private void Start()
	{
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00016F38 File Offset: 0x00015138
	private void LB_item_find()
	{
		this.UploadScore(++SL_Data.d_Setting.item_find_stat, this.name_item_find_stat);
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00016F68 File Offset: 0x00015168
	private void LB_reset_game()
	{
		this.UploadScore(++SL_Data.d_Setting.reset_game_stat, this.name_reset_game_stat);
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x00016F98 File Offset: 0x00015198
	private void LB_puzzle_complite()
	{
		this.UploadScore(++SL_Data.d_Setting.puzzle_complite_stat, this.name_puzzle_complite_stat);
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x00016FC8 File Offset: 0x000151C8
	private void LB_puzzle_segment_complite()
	{
		this.UploadScore(++SL_Data.d_Setting.puzzle_segment_complite_stat, this.name_puzzle_segment_complite_stat);
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x00016FF8 File Offset: 0x000151F8
	private void LB_minuts()
	{
		this.UploadScore(++SL_Data.d_Setting.minuts_stat, this.name_minuts_stat);
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00017028 File Offset: 0x00015228
	private void LB_final()
	{
		this.UploadScore(++SL_Data.d_Setting.final_stat, this.name_final_stat);
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00017058 File Offset: 0x00015258
	private void LB_helper_use()
	{
		this.UploadScore(++SL_Data.d_Setting.helper_use_stat, this.name_helper_use_stat);
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x00017088 File Offset: 0x00015288
	private void LB_card_select()
	{
		this.UploadScore(++SL_Data.d_Setting.card_select_stat, this.name_card_select);
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x000170B8 File Offset: 0x000152B8
	private void LB_wishers(bool poop)
	{
		this.UploadScore(++SL_Data.d_Setting.wishers_stat, this.name_wishers);
	}

	// Token: 0x060004CB RID: 1227 RVA: 0x000170E8 File Offset: 0x000152E8
	private void LB_communers(bool poop)
	{
		this.UploadScore(++SL_Data.d_Setting.communers_stat, this.name_communers);
	}

	// Token: 0x060004CC RID: 1228 RVA: 0x00017118 File Offset: 0x00015318
	public void UploadScore(int score, string name_lb)
	{
		this.Save_Setting();
		this._score = score;
		SteamAPICall_t hAPICall = SteamUserStats.FindLeaderboard(name_lb);
		this.m_LeaderboardFindResult = CallResult<LeaderboardFindResult_t>.Create(new CallResult<LeaderboardFindResult_t>.APIDispatchDelegate(this.OnLeaderboardFindResult));
		this.m_LeaderboardFindResult.Set(hAPICall, null);
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x00017160 File Offset: 0x00015360
	private void OnLeaderboardFindResult(LeaderboardFindResult_t pCallback, bool bIOFailure)
	{
		if (pCallback.m_bLeaderboardFound != 1 || bIOFailure)
		{
			Debug.Log("Thwrw was an error with OnLeaderboardFindResult");
			Debug.Log(pCallback.m_bLeaderboardFound);
			Debug.Log(pCallback.m_hSteamLeaderboard);
			Debug.Log(bIOFailure);
			return;
		}
		this._board = pCallback.m_hSteamLeaderboard;
		SteamUserStats.UploadLeaderboardScore(this._board, ELeaderboardUploadScoreMethod.k_ELeaderboardUploadScoreMethodKeepBest, this._score, new int[0], 0);
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x000171DC File Offset: 0x000153DC
	private void U_(InputAction.CallbackContext cc)
	{
		if (!this.start_test)
		{
			this.n = 0;
			this._coroutine_test = base.StartCoroutine(this.IE_test_());
			return;
		}
		this.n *= 2;
		if (this.n == 13)
		{
			SL_Data.st.god_mod = !SL_Data.st.god_mod;
			base.StopCoroutine(this._coroutine_test);
			this.start_test = false;
		}
		Debug.Log(this.n);
	}

	// Token: 0x060004CF RID: 1231 RVA: 0x00017260 File Offset: 0x00015460
	private void N_(InputAction.CallbackContext cc)
	{
		this.n++;
		if (this.n == 13)
		{
			SL_Data.st.god_mod = !SL_Data.st.god_mod;
			base.StopCoroutine(this._coroutine_test);
			this.start_test = false;
		}
		Debug.Log(this.n);
	}

	// Token: 0x060004D0 RID: 1232 RVA: 0x000172BF File Offset: 0x000154BF
	private IEnumerator IE_test_()
	{
		this.start_test = true;
		yield return new WaitForSeconds(6f);
		if (this.n == 13)
		{
			SL_Data.st.god_mod = !SL_Data.st.god_mod;
		}
		this.start_test = false;
		Debug.Log("SKIP");
		yield break;
	}

	// Token: 0x060004D1 RID: 1233 RVA: 0x000172CE File Offset: 0x000154CE
	private void Load_start_game()
	{
		SL_Data.d_Setting = (D_Setting)this.storage.Load(new D_Setting());
		SL_Data.d_Game = (D_Game)this.storage.Load(new D_Game());
	}

	// Token: 0x060004D2 RID: 1234 RVA: 0x00017304 File Offset: 0x00015504
	public void Save_Setting()
	{
		this.storage.Save(SL_Data.d_Setting);
	}

	// Token: 0x060004D3 RID: 1235 RVA: 0x00017316 File Offset: 0x00015516
	public void Save_Game()
	{
		this.storage.Save(SL_Data.d_Game);
	}

	// Token: 0x060004D4 RID: 1236 RVA: 0x00017328 File Offset: 0x00015528
	public void Load_Game()
	{
		SL_Data.d_Game = (D_Game)this.storage.Load(new D_Game());
		this.update_game_data();
	}

	// Token: 0x04000518 RID: 1304
	private Storage storage;

	// Token: 0x04000519 RID: 1305
	[Header("Название файла с настройками:")]
	public static D_Setting d_Setting;

	// Token: 0x0400051A RID: 1306
	[Header("Название файла с прогрессом игры:")]
	public static D_Game d_Game;

	// Token: 0x0400051B RID: 1307
	public static SL_Data st;

	// Token: 0x0400051C RID: 1308
	public bool god_mod;

	// Token: 0x0400051D RID: 1309
	[SerializeField]
	private string name_enter_game_stat;

	// Token: 0x0400051E RID: 1310
	[SerializeField]
	private string name_reset_game_stat;

	// Token: 0x0400051F RID: 1311
	[SerializeField]
	private string name_item_find_stat;

	// Token: 0x04000520 RID: 1312
	[SerializeField]
	private string name_puzzle_complite_stat;

	// Token: 0x04000521 RID: 1313
	[SerializeField]
	private string name_puzzle_segment_complite_stat;

	// Token: 0x04000522 RID: 1314
	[SerializeField]
	private string name_minuts_stat;

	// Token: 0x04000523 RID: 1315
	[SerializeField]
	private string name_final_stat;

	// Token: 0x04000524 RID: 1316
	[SerializeField]
	private string name_helper_use_stat;

	// Token: 0x04000525 RID: 1317
	[SerializeField]
	private string name_card_select;

	// Token: 0x04000526 RID: 1318
	[SerializeField]
	private string name_wishers;

	// Token: 0x04000527 RID: 1319
	[SerializeField]
	private string name_communers;

	// Token: 0x04000528 RID: 1320
	private CallResult<LeaderboardFindResult_t> m_LeaderboardFindResult;

	// Token: 0x04000529 RID: 1321
	private SteamLeaderboard_t _board;

	// Token: 0x0400052A RID: 1322
	private InputAction reset_data_game;

	// Token: 0x0400052B RID: 1323
	private InputAction reset_data_setting;

	// Token: 0x0400052C RID: 1324
	private InputAction reset_this_scene;

	// Token: 0x0400052D RID: 1325
	private InputAction reset_press;

	// Token: 0x0400052E RID: 1326
	private InputAction ia_U;

	// Token: 0x0400052F RID: 1327
	private InputAction ia_N;

	// Token: 0x04000530 RID: 1328
	[SerializeField]
	private Scenes_Data scenes_data;

	// Token: 0x04000531 RID: 1329
	private int _score;

	// Token: 0x04000532 RID: 1330
	private Coroutine _coroutine_test;

	// Token: 0x04000533 RID: 1331
	private bool start_test;

	// Token: 0x04000534 RID: 1332
	private int n;
}
