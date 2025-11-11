using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x02000022 RID: 34
public class All_Buttons_Menu : MonoBehaviour
{
	// Token: 0x060000B7 RID: 183 RVA: 0x0000626A File Offset: 0x0000446A
	private void Awake()
	{
		this.awake_Input_Action();
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00006274 File Offset: 0x00004474
	private void OnEnable()
	{
		this.enable_Button_Setting();
		this.enable_Input_Action();
		Events_Menu_UI.Puzzle_END_DEMO = (Action)Delegate.Combine(Events_Menu_UI.Puzzle_END_DEMO, new Action(this.End_Game_Demo));
		Events_Menu_UI.Open_Tutorial_Puzzle = (Action)Delegate.Combine(Events_Menu_UI.Open_Tutorial_Puzzle, new Action(this.Tutorial_puzzle_open));
		Events_Menu_UI.Open_Tutorial_Game = (Action)Delegate.Combine(Events_Menu_UI.Open_Tutorial_Game, new Action(this.Tutorial_game_open));
		Events_Menu_UI.a_reset_level = (Action<int[], string>)Delegate.Combine(Events_Menu_UI.a_reset_level, new Action<int[], string>(this.reset_d));
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00006310 File Offset: 0x00004510
	private void OnDisable()
	{
		this.disable_Button_Setting();
		this.disable_Input_Action();
		Events_Menu_UI.Puzzle_END_DEMO = (Action)Delegate.Remove(Events_Menu_UI.Puzzle_END_DEMO, new Action(this.End_Game_Demo));
		Events_Menu_UI.Open_Tutorial_Puzzle = (Action)Delegate.Remove(Events_Menu_UI.Open_Tutorial_Puzzle, new Action(this.Tutorial_puzzle_open));
		Events_Menu_UI.Open_Tutorial_Game = (Action)Delegate.Remove(Events_Menu_UI.Open_Tutorial_Game, new Action(this.Tutorial_game_open));
		Events_Menu_UI.a_reset_level = (Action<int[], string>)Delegate.Remove(Events_Menu_UI.a_reset_level, new Action<int[], string>(this.reset_d));
	}

	// Token: 0x060000BA RID: 186 RVA: 0x000063A9 File Offset: 0x000045A9
	private void Start()
	{
		if (Events_Menu_UI.level_load_map)
		{
			this.play_d();
			return;
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Menu_Main, true);
		this.Menu_Frame.Scroll_On_Off(true);
		Cursor.visible = false;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x000063E0 File Offset: 0x000045E0
	private void enable_Button_Setting()
	{
		this.b_Play.onClick.AddListener(new UnityAction(this.play_d));
		this.b_Setting.onClick.AddListener(new UnityAction(this.setting_d));
		this.b_Setting_Closed.onClick.AddListener(new UnityAction(this.setting_closed_d));
		this.b_Map.onClick.AddListener(delegate()
		{
			this.map_d(true);
		});
		this.b_Map_in_level.onClick.AddListener(delegate()
		{
			this.map_d(false);
		});
		this.b_Closed_Map.onClick.AddListener(new UnityAction(this.map_closed_d));
		this.b_Reset_No.onClick.AddListener(new UnityAction(this.reset_no_d));
		this.b_Reset_Yes.onClick.AddListener(new UnityAction(this.reset_yes_d));
		this.b_Exit.onClick.AddListener(new UnityAction(this.exit_d));
		this.b_Closed_End_Game_Frame.onClick.AddListener(new UnityAction(this.End_Game_Demo_Closed));
		this.b_Tutorial_Puzzle_OK.onClick.AddListener(new UnityAction(this.Tutorial_puzzle_OK));
		this.b_Tutorial_Game_OK.onClick.AddListener(new UnityAction(this.Tutorial_game_OK));
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00006540 File Offset: 0x00004740
	private void disable_Button_Setting()
	{
		this.b_Play.onClick.RemoveListener(new UnityAction(this.play_d));
		this.b_Setting.onClick.RemoveListener(new UnityAction(this.setting_d));
		this.b_Setting_Closed.onClick.RemoveListener(new UnityAction(this.setting_closed_d));
		this.b_Map.onClick.RemoveListener(delegate()
		{
			this.map_d(true);
		});
		this.b_Map_in_level.onClick.RemoveListener(delegate()
		{
			this.map_d(false);
		});
		this.b_Closed_Map.onClick.RemoveListener(new UnityAction(this.map_closed_d));
		this.b_Reset_No.onClick.RemoveListener(new UnityAction(this.reset_no_d));
		this.b_Reset_Yes.onClick.RemoveListener(new UnityAction(this.reset_yes_d));
		this.b_Exit.onClick.RemoveListener(new UnityAction(this.exit_d));
		this.b_Closed_End_Game_Frame.onClick.RemoveListener(new UnityAction(this.End_Game_Demo_Closed));
		this.b_Tutorial_Puzzle_OK.onClick.RemoveListener(new UnityAction(this.Tutorial_puzzle_OK));
		this.b_Tutorial_Game_OK.onClick.RemoveListener(new UnityAction(this.Tutorial_game_OK));
	}

	// Token: 0x060000BD RID: 189 RVA: 0x000066A0 File Offset: 0x000048A0
	private void awake_Input_Action()
	{
		this.ia_Play_Stop = Sa_IS.input_Main.am_play.escape;
		this.ia_Setting_Exit = Sa_IS.input_Main.Menu_Setting.Escape;
		this.ia_Reset_No = Sa_IS.input_Main.Menu_Reset.Escape;
		this.ia_Main_menu_Play_Escape = Sa_IS.input_Main.Menu_Main.Escape;
		this.ia_Map_Closed = Sa_IS.input_Main.Map.Escape;
		this.ia_U = Sa_IS.input_Main.Menu_Setting.U;
		this.ia_N = Sa_IS.input_Main.Menu_Setting.N;
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00006758 File Offset: 0x00004958
	private void enable_Input_Action()
	{
		this.ia_Play_Stop.started += this.play_stop_ia;
		this.ia_Setting_Exit.started += this.setting_closed_ia;
		this.ia_Reset_No.started += this.reset_no_ia;
		this.ia_Main_menu_Play_Escape.started += this.play_start_ia;
		this.ia_Map_Closed.started += this.map_closed_ia;
		this.ia_U.started += this.U_;
		this.ia_N.started += this.N_;
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00006808 File Offset: 0x00004A08
	private void disable_Input_Action()
	{
		this.ia_Play_Stop.started -= this.play_stop_ia;
		this.ia_Setting_Exit.started -= this.setting_closed_ia;
		this.ia_Reset_No.started -= this.reset_no_ia;
		this.ia_Main_menu_Play_Escape.started -= this.play_start_ia;
		this.ia_Map_Closed.started -= this.map_closed_ia;
		this.ia_U.started -= this.U_;
		this.ia_N.started -= this.N_;
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x000068B6 File Offset: 0x00004AB6
	private void play_start_ia(InputAction.CallbackContext cc)
	{
		if (Status_All.First_Play_Button_Down)
		{
			this.play_d();
		}
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x000068C5 File Offset: 0x00004AC5
	private void play_stop_ia(InputAction.CallbackContext cc)
	{
		this.play_stop_d();
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x000068CD File Offset: 0x00004ACD
	private void setting_closed_ia(InputAction.CallbackContext cc)
	{
		this.setting_closed_d();
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x000068D5 File Offset: 0x00004AD5
	private void reset_no_ia(InputAction.CallbackContext cc)
	{
		this.reset_no_d();
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000068DD File Offset: 0x00004ADD
	private void map_closed_ia(InputAction.CallbackContext cc)
	{
		this.map_closed_d();
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x000068E8 File Offset: 0x00004AE8
	private void play_d()
	{
		Status_All.First_Play_Button_Down = true;
		this.Menu_Frame.Scroll_On_Off(false);
		this.Frame_3_Slot.UI_On_Menu();
		this.Next_Level_or_Map_panel.UI_On();
		if (SL_Data.d_Setting.Helper)
		{
			this.Frame_Helper.UI_On();
		}
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00006934 File Offset: 0x00004B34
	private void play_stop_d()
	{
		this.Menu_Frame.Scroll_On_Off(true);
		this.Frame_3_Slot.UI_Off();
		this.Next_Level_or_Map_panel.UI_Off();
		if (SL_Data.d_Setting.Helper)
		{
			this.Frame_Helper.UI_Off();
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x0000696F File Offset: 0x00004B6F
	private void setting_d()
	{
		base.StartCoroutine(this.IE_setting_d());
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x0000697E File Offset: 0x00004B7E
	private IEnumerator IE_setting_d()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		yield return base.StartCoroutine(this.Menu_Frame.IE_off_alpha_scroll());
		yield return base.StartCoroutine(this.Setting_Frame.IE_on_alpha_scroll());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Menu_Setting, true);
		yield break;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x0000698D File Offset: 0x00004B8D
	private void setting_closed_d()
	{
		base.StartCoroutine(this.IE_setting_closed_d());
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000699C File Offset: 0x00004B9C
	private IEnumerator IE_setting_closed_d()
	{
		SL_Data.st.Save_Setting();
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		yield return base.StartCoroutine(this.Setting_Frame.IE_off_alpha_scroll());
		yield return base.StartCoroutine(this.Menu_Frame.IE_on_alpha_scroll());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Menu_Main, true);
		yield break;
	}

	// Token: 0x060000CB RID: 203 RVA: 0x000069AB File Offset: 0x00004BAB
	private void map_d(bool menu_level)
	{
		this.map_open_menu_or_level = menu_level;
		if (menu_level)
		{
			base.StartCoroutine(this.IE_map_open_d());
			return;
		}
		base.StartCoroutine(this.IE_map_open_level_d());
	}

	// Token: 0x060000CC RID: 204 RVA: 0x000069D2 File Offset: 0x00004BD2
	private IEnumerator IE_map_open_d()
	{
		Action update_info_map = Events_Menu_UI.Update_info_map;
		if (update_info_map != null)
		{
			update_info_map();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		yield return base.StartCoroutine(this.Menu_Frame.IE_off_alpha_scroll());
		yield return base.StartCoroutine(this.Map_Frame.IE_on_alpha_scroll());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Map, true);
		yield break;
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000069E1 File Offset: 0x00004BE1
	private IEnumerator IE_map_open_level_d()
	{
		Action update_info_map = Events_Menu_UI.Update_info_map;
		if (update_info_map != null)
		{
			update_info_map();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		yield return base.StartCoroutine(this.Map_Frame.IE_on_alpha_scroll());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Map, true);
		yield break;
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000069F0 File Offset: 0x00004BF0
	private void map_closed_d()
	{
		base.StartCoroutine(this.IE_map_closed_d());
	}

	// Token: 0x060000CF RID: 207 RVA: 0x000069FF File Offset: 0x00004BFF
	private IEnumerator IE_map_closed_d()
	{
		if (this.map_open_menu_or_level)
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
			yield return base.StartCoroutine(this.Map_Frame.IE_off_alpha_scroll());
			yield return base.StartCoroutine(this.Menu_Frame.IE_on_alpha_scroll());
			Sa_IS.Active_Input_map(Sa_IS.input_Main.Menu_Main, true);
		}
		else
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
			yield return base.StartCoroutine(this.Map_Frame.IE_off_alpha_scroll());
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		}
		yield break;
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00006A0E File Offset: 0x00004C0E
	private void reset_d(int[] stage_level, string name_scene)
	{
		this.stage_level_reset = stage_level;
		this.name_scene_reset = name_scene;
		this.Reset_Frame.Scroll_On_Off(true);
		this.Black_Reset.Frame_Reset_On();
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Menu_Reset, true);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00006A4A File Offset: 0x00004C4A
	private void reset_yes_d()
	{
		Action<int[], string> a_Reset_Level_Data = Events_Menu_UI.a_Reset_Level_Data;
		if (a_Reset_Level_Data == null)
		{
			return;
		}
		a_Reset_Level_Data(this.stage_level_reset, this.name_scene_reset);
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00006A67 File Offset: 0x00004C67
	private void reset_no_d()
	{
		this.Reset_Frame.Scroll_On_Off(false);
		this.Black_Reset.Frame_Reset_Off();
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Map, true);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00006A95 File Offset: 0x00004C95
	private void exit_d()
	{
		base.StartCoroutine(this.IE_exit_d());
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00006AA4 File Offset: 0x00004CA4
	private IEnumerator IE_exit_d()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		base.StartCoroutine(this.Menu_Frame.IE_off_alpha_scroll());
		yield return base.StartCoroutine(this.Black_Reset.IE_exit_game());
		Exit_Game.Exit();
		yield break;
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00006AB3 File Offset: 0x00004CB3
	private void End_Game_Demo()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.End_Game, true);
		base.StartCoroutine(this.End_Game.IE_on_alpha_scroll());
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00006ADC File Offset: 0x00004CDC
	private void End_Game_Demo_Closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		base.StartCoroutine(this.End_Game.IE_off_alpha_scroll());
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00006B05 File Offset: 0x00004D05
	private void Tutorial_puzzle_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		base.StartCoroutine(this.Tutorial_Puzzle.IE_on_alpha_scroll());
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00006B2E File Offset: 0x00004D2E
	private void Tutorial_puzzle_OK()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Puzzle_Play, true);
		base.StartCoroutine(this.Tutorial_Puzzle.IE_off_alpha_scroll());
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00006B57 File Offset: 0x00004D57
	private void Tutorial_game_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Void, true);
		base.StartCoroutine(this.Tutorial_Game.IE_on_alpha_scroll());
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00006B80 File Offset: 0x00004D80
	private void Tutorial_game_OK()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		base.StartCoroutine(this.Tutorial_Game.IE_off_alpha_scroll());
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00006BAC File Offset: 0x00004DAC
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

	// Token: 0x060000DC RID: 220 RVA: 0x00006C30 File Offset: 0x00004E30
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

	// Token: 0x060000DD RID: 221 RVA: 0x00006C8F File Offset: 0x00004E8F
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

	// Token: 0x040000AA RID: 170
	public Button b_Play;

	// Token: 0x040000AB RID: 171
	public Button b_Setting;

	// Token: 0x040000AC RID: 172
	public Button b_Setting_Closed;

	// Token: 0x040000AD RID: 173
	public Button b_Map;

	// Token: 0x040000AE RID: 174
	public Button b_Map_in_level;

	// Token: 0x040000AF RID: 175
	public Button b_Closed_Map;

	// Token: 0x040000B0 RID: 176
	public Button b_Reset;

	// Token: 0x040000B1 RID: 177
	public Button b_Reset_Yes;

	// Token: 0x040000B2 RID: 178
	public Button b_Reset_No;

	// Token: 0x040000B3 RID: 179
	public Button b_Exit;

	// Token: 0x040000B4 RID: 180
	public Button b_Closed_End_Game_Frame;

	// Token: 0x040000B5 RID: 181
	public Button b_Tutorial_Puzzle_OK;

	// Token: 0x040000B6 RID: 182
	public Button b_Tutorial_Game_OK;

	// Token: 0x040000B7 RID: 183
	private InputAction ia_Play_Stop;

	// Token: 0x040000B8 RID: 184
	private InputAction ia_Setting_Exit;

	// Token: 0x040000B9 RID: 185
	private InputAction ia_Main_menu_Play_Escape;

	// Token: 0x040000BA RID: 186
	private InputAction ia_Reset_No;

	// Token: 0x040000BB RID: 187
	private InputAction ia_Map_Closed;

	// Token: 0x040000BC RID: 188
	private InputAction ia_Closed_End_Game_Frame;

	// Token: 0x040000BD RID: 189
	private InputAction ia_U;

	// Token: 0x040000BE RID: 190
	private InputAction ia_N;

	// Token: 0x040000BF RID: 191
	[SerializeField]
	private Main_Menu_Open_Closed Menu_Frame;

	// Token: 0x040000C0 RID: 192
	[SerializeField]
	private Main_Menu_Open_Closed Reset_Frame;

	// Token: 0x040000C1 RID: 193
	[SerializeField]
	private Reset_Frame_and_Scene Black_Reset;

	// Token: 0x040000C2 RID: 194
	[SerializeField]
	private Main_Menu_Open_Closed Setting_Frame;

	// Token: 0x040000C3 RID: 195
	[SerializeField]
	private Main_Menu_Open_Closed Map_Frame;

	// Token: 0x040000C4 RID: 196
	[SerializeField]
	private bool map_open_menu_or_level;

	// Token: 0x040000C5 RID: 197
	[SerializeField]
	private Main_Menu_Open_Closed Tutorial_Game;

	// Token: 0x040000C6 RID: 198
	[SerializeField]
	private Main_Menu_Open_Closed Tutorial_Puzzle;

	// Token: 0x040000C7 RID: 199
	[SerializeField]
	private Main_Menu_Open_Closed End_Game;

	// Token: 0x040000C8 RID: 200
	[SerializeField]
	private UI_Move_Up_Down Frame_3_Slot;

	// Token: 0x040000C9 RID: 201
	[SerializeField]
	private UI_Move_Up_Down Next_Level_or_Map_panel;

	// Token: 0x040000CA RID: 202
	[SerializeField]
	private UI_Move_Up_Down Frame_Helper;

	// Token: 0x040000CB RID: 203
	private int[] stage_level_reset;

	// Token: 0x040000CC RID: 204
	private string name_scene_reset;

	// Token: 0x040000CD RID: 205
	private Coroutine _coroutine_test;

	// Token: 0x040000CE RID: 206
	private bool start_test;

	// Token: 0x040000CF RID: 207
	private int n;
}
