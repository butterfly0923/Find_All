using System;
using System.Collections;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x0200009C RID: 156
public class Level_Manager_UI : MonoBehaviour
{
	// Token: 0x06000427 RID: 1063 RVA: 0x000142E4 File Offset: 0x000124E4
	private void Awake()
	{
		this.escape_play = Sa_IS.input_Main.am_play.escape;
		this.escape_menu = Sa_IS.input_Main.am_menu.escape;
		this.escape_setting = Sa_IS.input_Main.am_setting.escape;
		this.escape_map = Sa_IS.input_Main.am_map.escape;
		this.escape_tutorial_1 = Sa_IS.input_Main.am_tutorial_1.escape;
		this.escape_tutorial_2 = Sa_IS.input_Main.am_tutorial_2.escape;
		this.escape_tutorial_setting = Sa_IS.input_Main.am_tutorial_setting.escape;
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x0001439C File Offset: 0x0001259C
	private void OnEnable()
	{
		Button button = this.button_play;
		if (button != null)
		{
			button.onClick.AddListener(new UnityAction(this.menu_closed));
		}
		Button button2 = this.button_reset;
		if (button2 != null)
		{
			button2.onClick.AddListener(new UnityAction(this.reset_level));
		}
		Button button3 = this.button_setting;
		if (button3 != null)
		{
			button3.onClick.AddListener(new UnityAction(this.setting_open));
		}
		Button button4 = this.button_setting_closed;
		if (button4 != null)
		{
			button4.onClick.AddListener(new UnityAction(this.setting_closed));
		}
		Button button5 = this.button_exit_game;
		if (button5 != null)
		{
			button5.onClick.AddListener(new UnityAction(this.exit_game));
		}
		this.escape_play.started += this.menu_open_key;
		this.escape_menu.started += this.menu_closed_key;
		this.escape_setting.started += this.setting_closed_key;
		this.escape_map.started += this.map_closed_key;
		this.escape_tutorial_1.started += this.tutorial_1_closed_key;
		this.escape_tutorial_2.started += this.tutorial_2_closed_key;
		this.escape_tutorial_setting.started += this.tutorial_setting_closed_key;
		EA.Update_stady = (Action)Delegate.Combine(EA.Update_stady, new Action(this.update_down_panels));
		EA.Exit_map_level_play = (Action)Delegate.Combine(EA.Exit_map_level_play, new Action(this.map_closed_in_play_map));
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x00014534 File Offset: 0x00012734
	private void OnDisable()
	{
		Button button = this.button_play;
		if (button != null)
		{
			button.onClick.RemoveListener(new UnityAction(this.menu_closed));
		}
		Button button2 = this.button_reset;
		if (button2 != null)
		{
			button2.onClick.RemoveListener(new UnityAction(this.reset_level));
		}
		Button button3 = this.button_setting;
		if (button3 != null)
		{
			button3.onClick.RemoveListener(new UnityAction(this.setting_open));
		}
		Button button4 = this.button_setting_closed;
		if (button4 != null)
		{
			button4.onClick.RemoveListener(new UnityAction(this.setting_closed));
		}
		Button button5 = this.button_exit_game;
		if (button5 != null)
		{
			button5.onClick.RemoveListener(new UnityAction(this.exit_game));
		}
		this.escape_play.started -= this.menu_open_key;
		this.escape_menu.started -= this.menu_closed_key;
		this.escape_setting.started -= this.setting_closed_key;
		this.escape_map.started -= this.map_closed_key;
		this.escape_tutorial_1.started -= this.tutorial_1_closed_key;
		this.escape_tutorial_2.started -= this.tutorial_2_closed_key;
		this.escape_tutorial_setting.started -= this.tutorial_setting_closed_key;
		EA.Update_stady = (Action)Delegate.Remove(EA.Update_stady, new Action(this.update_down_panels));
		EA.Exit_map_level_play = (Action)Delegate.Remove(EA.Exit_map_level_play, new Action(this.map_closed_in_play_map));
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x000146CC File Offset: 0x000128CC
	private void Start()
	{
		if (EA.first_load_scene)
		{
			this.ui_menu.off_momental();
			if (this.ui_menu_coloring_books != null)
			{
				this.ui_menu_coloring_books.off_momental();
			}
			if (this.ui_menu_old_game != null)
			{
				this.ui_menu_old_game.off_momental();
			}
			base.StartCoroutine(this.IE_Start());
		}
		else
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_menu, true);
		}
		EA.first_load_scene = true;
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x00014747 File Offset: 0x00012947
	private IEnumerator IE_Start()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.IE_down_panel_on());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		yield break;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x00014756 File Offset: 0x00012956
	private void reset_level()
	{
		Action reset_level_check = EA.Reset_level_check;
		if (reset_level_check == null)
		{
			return;
		}
		reset_level_check();
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x00014767 File Offset: 0x00012967
	private void wishlist_demo()
	{
		if (SteamManager.Initialized)
		{
			SteamFriends.ActivateGameOverlayToWebPage("http://store.steampowered.com/app/3444050/FIND_ALL_6_Netherlands/", EActivateGameOverlayToWebPageMode.k_EActivateGameOverlayToWebPageMode_Default);
			return;
		}
		Application.OpenURL("http://store.steampowered.com/app/3444050/FIND_ALL_6_Netherlands/");
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x00014786 File Offset: 0x00012986
	private void update_down_panels()
	{
		this.down_panel_off();
		base.StartCoroutine(this.IE_down_panel_on());
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0001479B File Offset: 0x0001299B
	[ContextMenu("menu_open")]
	private void menu_open()
	{
		Action escape_level = EA.Escape_level;
		if (escape_level != null)
		{
			escape_level();
		}
		base.StartCoroutine(this.IE_menu_open());
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x000147BA File Offset: 0x000129BA
	private void menu_open_key(InputAction.CallbackContext value)
	{
		this.menu_open();
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x000147C2 File Offset: 0x000129C2
	private IEnumerator IE_menu_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		this.down_panel_off();
		if (this.ui_menu_coloring_books != null)
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_On());
			}
			base.StartCoroutine(this.ui_menu.IE_Panel_On());
			yield return base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_On());
		}
		else
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_On());
			}
			yield return base.StartCoroutine(this.ui_menu.IE_Panel_On());
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_menu, true);
		yield break;
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x000147D1 File Offset: 0x000129D1
	[ContextMenu("menu_closed")]
	private void menu_closed()
	{
		base.StartCoroutine(this.IE_menu_closed());
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x000147E0 File Offset: 0x000129E0
	private void menu_closed_key(InputAction.CallbackContext value)
	{
		this.menu_closed();
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x000147E8 File Offset: 0x000129E8
	private IEnumerator IE_menu_closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		base.StartCoroutine(this.IE_down_panel_on());
		if (this.ui_menu_coloring_books != null)
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_Off());
			}
			base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_Off());
			yield return base.StartCoroutine(this.ui_menu.IE_Panel_Off());
		}
		else
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_Off());
			}
			yield return base.StartCoroutine(this.ui_menu.IE_Panel_Off());
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		yield break;
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x000147F7 File Offset: 0x000129F7
	[ContextMenu("map_open")]
	private void map_open()
	{
		this.map_in_level = false;
		base.StartCoroutine(this.IE_map_open());
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0001480D File Offset: 0x00012A0D
	private IEnumerator IE_map_open()
	{
		Action update_map = EA.Update_map;
		if (update_map != null)
		{
			update_map();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		if (!this.map_in_level)
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_Off());
			}
			base.StartCoroutine(this.ui_menu.IE_Panel_Off());
			if (this.ui_menu_coloring_books != null)
			{
				base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_Off());
			}
		}
		else
		{
			this.down_panel_off();
		}
		yield return base.StartCoroutine(this.ui_map.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_map, true);
		yield break;
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0001481C File Offset: 0x00012A1C
	[ContextMenu("map_closed")]
	private void map_closed_in_play_map()
	{
		this.map_in_level = true;
		base.StartCoroutine(this.IE_map_closed());
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x00014832 File Offset: 0x00012A32
	[ContextMenu("map_closed")]
	private void map_closed()
	{
		base.StartCoroutine(this.IE_map_closed());
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x00014841 File Offset: 0x00012A41
	private void map_closed_key(InputAction.CallbackContext value)
	{
		this.map_closed();
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x00014849 File Offset: 0x00012A49
	private IEnumerator IE_map_closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		base.StartCoroutine(this.ui_map.IE_Panel_Off());
		if (!this.map_in_level)
		{
			if (this.ui_menu_coloring_books != null)
			{
				if (this.ui_menu_old_game != null)
				{
					base.StartCoroutine(this.ui_menu_old_game.IE_Panel_On());
				}
				base.StartCoroutine(this.ui_menu.IE_Panel_On());
				yield return base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_On());
			}
			else
			{
				if (this.ui_menu_old_game != null)
				{
					base.StartCoroutine(this.ui_menu_old_game.IE_Panel_On());
				}
				yield return base.StartCoroutine(this.ui_menu.IE_Panel_On());
			}
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_menu, true);
		}
		else
		{
			yield return base.StartCoroutine(this.IE_down_panel_on());
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		}
		yield break;
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x00014858 File Offset: 0x00012A58
	[ContextMenu("setting_open")]
	private void setting_open()
	{
		base.StartCoroutine(this.IE_setting_open());
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x00014867 File Offset: 0x00012A67
	private IEnumerator IE_setting_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		if (this.ui_menu_old_game != null)
		{
			base.StartCoroutine(this.ui_menu_old_game.IE_Panel_Off());
		}
		base.StartCoroutine(this.ui_menu.IE_Panel_Off());
		if (this.ui_menu_coloring_books != null)
		{
			base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_Off());
		}
		yield return new WaitForSeconds(0.1f);
		yield return base.StartCoroutine(this.ui_setting.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_setting, true);
		yield break;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x00014876 File Offset: 0x00012A76
	[ContextMenu("setting_closed")]
	private void setting_closed()
	{
		base.StartCoroutine(this.IE_setting_closed());
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x00014885 File Offset: 0x00012A85
	private void setting_closed_key(InputAction.CallbackContext value)
	{
		this.setting_closed();
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0001488D File Offset: 0x00012A8D
	private IEnumerator IE_setting_closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		base.StartCoroutine(this.ui_setting.IE_Panel_Off());
		if (this.ui_menu_coloring_books != null)
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_On());
			}
			base.StartCoroutine(this.ui_menu.IE_Panel_On());
			yield return base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_On());
		}
		else
		{
			if (this.ui_menu_old_game != null)
			{
				base.StartCoroutine(this.ui_menu_old_game.IE_Panel_On());
			}
			yield return base.StartCoroutine(this.ui_menu.IE_Panel_On());
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_menu, true);
		yield break;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0001489C File Offset: 0x00012A9C
	[ContextMenu("tutorial_1_open")]
	private void tutorial_1_open()
	{
		base.StartCoroutine(this.IE_tutorial_1_open());
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x000148AB File Offset: 0x00012AAB
	private IEnumerator IE_tutorial_1_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_tutorial_1.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_tutorial_1, true);
		yield break;
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x000148BA File Offset: 0x00012ABA
	[ContextMenu("tutorial_1_closed")]
	private void tutorial_1_closed()
	{
		base.StartCoroutine(this.IE_tutorial_1_closed());
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x000148C9 File Offset: 0x00012AC9
	private void tutorial_1_closed_key(InputAction.CallbackContext value)
	{
		this.tutorial_1_closed();
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x000148D1 File Offset: 0x00012AD1
	private IEnumerator IE_tutorial_1_closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_tutorial_1.IE_Panel_Off());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		yield break;
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x000148E0 File Offset: 0x00012AE0
	[ContextMenu("tutorial_2_open")]
	private void tutorial_2_open()
	{
		base.StartCoroutine(this.IE_tutorial_2_open());
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x000148EF File Offset: 0x00012AEF
	private IEnumerator IE_tutorial_2_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_tutorial_2.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_tutorial_2, true);
		yield break;
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x000148FE File Offset: 0x00012AFE
	[ContextMenu("tutorial_2_closed")]
	private void tutorial_2_closed()
	{
		base.StartCoroutine(this.IE_tutorial_2_closed());
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0001490D File Offset: 0x00012B0D
	private void tutorial_2_closed_key(InputAction.CallbackContext value)
	{
		this.tutorial_2_closed();
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x00014915 File Offset: 0x00012B15
	private IEnumerator IE_tutorial_2_closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		yield return base.StartCoroutine(this.ui_tutorial_2.IE_Panel_Off());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		yield break;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x00014924 File Offset: 0x00012B24
	[ContextMenu("tutorial_setting_open")]
	private void tutorial_setting_open()
	{
		base.StartCoroutine(this.IE_tutorial_setting_open());
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x00014933 File Offset: 0x00012B33
	private IEnumerator IE_tutorial_setting_open()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		base.StartCoroutine(this.ui_setting.IE_Panel_Off());
		yield return new WaitForSeconds(0.3f);
		yield return base.StartCoroutine(this.ui_tutorial_setting.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_tutorial_setting, true);
		yield break;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x00014942 File Offset: 0x00012B42
	[ContextMenu("tutorial_setting_closed")]
	private void tutorial_setting_closed()
	{
		base.StartCoroutine(this.IE_tutorial_setting_closed());
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x00014951 File Offset: 0x00012B51
	private void tutorial_setting_closed_key(InputAction.CallbackContext value)
	{
		this.tutorial_setting_closed();
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x00014959 File Offset: 0x00012B59
	private IEnumerator IE_tutorial_setting_closed()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
		base.StartCoroutine(this.ui_tutorial_setting.IE_Panel_Off());
		yield return new WaitForSeconds(0.3f);
		yield return base.StartCoroutine(this.ui_setting.IE_Panel_On());
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_setting, true);
		yield break;
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x00014968 File Offset: 0x00012B68
	[ContextMenu("dlc")]
	private void dlc()
	{
		Action dlc_open = EA.DLC_open;
		if (dlc_open == null)
		{
			return;
		}
		dlc_open();
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0001497C File Offset: 0x00012B7C
	[ContextMenu("main_menu")]
	private void main_menu()
	{
		SL_Data.d_Game.load_level = -1;
		Action load_level = EA.Load_level;
		if (load_level != null)
		{
			load_level();
		}
		if (this.ui_menu_old_game != null)
		{
			base.StartCoroutine(this.ui_menu_old_game.IE_Panel_Off());
		}
		base.StartCoroutine(this.ui_menu.IE_Panel_Off());
		if (this.ui_menu_coloring_books != null)
		{
			base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_Off());
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x00014A0B File Offset: 0x00012C0B
	[ContextMenu("map_open_in_level")]
	private void map_open_in_level()
	{
		this.map_in_level = true;
		base.StartCoroutine(this.IE_map_open());
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x00014A21 File Offset: 0x00012C21
	[ContextMenu("next_level")]
	private void load_next_level()
	{
		SL_Data.d_Game.load_level = Level_Data.st.RT_level_index() + 1;
		Action load_level = EA.Load_level;
		if (load_level == null)
		{
			return;
		}
		load_level();
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x00014A48 File Offset: 0x00012C48
	[ContextMenu("exit_game")]
	private void exit_game()
	{
		Action exit_game = EA.Exit_game;
		if (exit_game != null)
		{
			exit_game();
		}
		if (this.ui_menu_old_game != null)
		{
			base.StartCoroutine(this.ui_menu_old_game.IE_Panel_Off());
		}
		base.StartCoroutine(this.ui_menu.IE_Panel_Off());
		if (this.ui_menu_coloring_books != null)
		{
			base.StartCoroutine(this.ui_menu_coloring_books.IE_Panel_Off());
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_void, true);
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x00014ACC File Offset: 0x00012CCC
	private IEnumerator IE_down_panel_on()
	{
		Enums_Level.Stady stady = Level_Data.st.RT_stady_level();
		Debug.Log(string.Format("Enums_Level.Stady - {0}", stady));
		if (stady <= Enums_Level.Stady.Puzzle)
		{
			if (stady != Enums_Level.Stady.Find)
			{
				if (stady == Enums_Level.Stady.Puzzle)
				{
					yield return base.StartCoroutine(this.ui_down_panel_puzzle.IE_Panel_On());
				}
			}
			else
			{
				if (SL_Data.d_Setting.Timer_On)
				{
					base.StartCoroutine(this.ui_down_panel_timer.IE_Panel_On());
				}
				yield return base.StartCoroutine(this.ui_down_panel_find.IE_Panel_On());
			}
		}
		else if (stady != Enums_Level.Stady.Next_level)
		{
			if (stady == Enums_Level.Stady.Map)
			{
				if (EA.down_panel_open)
				{
					EA.down_panel_open = false;
					yield return base.StartCoroutine(this.ui_down_panel_next_level.IE_Panel_On());
				}
			}
		}
		else if (EA.down_panel_open)
		{
			EA.down_panel_open = false;
			yield return base.StartCoroutine(this.ui_down_panel_next_level.IE_Panel_On());
		}
		yield break;
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x00014ADC File Offset: 0x00012CDC
	private void down_panel_off()
	{
		if (this.ui_down_panel_find != null && this.ui_down_panel_find.Current_status)
		{
			base.StartCoroutine(this.ui_down_panel_find.IE_Panel_Off());
			if (SL_Data.d_Setting.Timer_On)
			{
				if (this.old_game && !SL_Data.d_Game.sl_stady_complite[2, 0])
				{
					base.StartCoroutine(this.ui_down_panel_timer.IE_Panel_Off());
				}
				else if (!this.old_game)
				{
					base.StartCoroutine(this.ui_down_panel_timer.IE_Panel_Off());
				}
			}
		}
		if (this.ui_down_panel_puzzle != null && this.ui_down_panel_puzzle.Current_status)
		{
			base.StartCoroutine(this.ui_down_panel_puzzle.IE_Panel_Off());
		}
		if (this.ui_down_panel_next_level != null && this.ui_down_panel_next_level.Current_status)
		{
			base.StartCoroutine(this.ui_down_panel_next_level.IE_Panel_Off());
		}
	}

	// Token: 0x0400047C RID: 1148
	[Header("Окно меню:")]
	[SerializeField]
	private UI_Panel_Move ui_menu;

	// Token: 0x0400047D RID: 1149
	[SerializeField]
	private UI_Panel_Move ui_menu_coloring_books;

	// Token: 0x0400047E RID: 1150
	[SerializeField]
	private UI_Panel_Move ui_menu_old_game;

	// Token: 0x0400047F RID: 1151
	[Header("Окно настроек:")]
	[SerializeField]
	private UI_Panel_Move ui_setting;

	// Token: 0x04000480 RID: 1152
	[Header("Окно карты:")]
	[SerializeField]
	private UI_Panel_Move ui_map;

	// Token: 0x04000481 RID: 1153
	[Header("Окно поиска (стадция уровня):")]
	[SerializeField]
	private UI_Panel_Move ui_down_panel_find;

	// Token: 0x04000482 RID: 1154
	[Header("Окно таймера (стадция уровня):")]
	[SerializeField]
	private UI_Panel_Move ui_down_panel_timer;

	// Token: 0x04000483 RID: 1155
	[Header("Окно пазла (стадция уровня):")]
	[SerializeField]
	private UI_Panel_Move ui_down_panel_puzzle;

	// Token: 0x04000484 RID: 1156
	[Header("Окно (следующий уровень):")]
	[SerializeField]
	private UI_Panel_Move ui_down_panel_next_level;

	// Token: 0x04000485 RID: 1157
	[Header("Окно обучения №1")]
	[SerializeField]
	private UI_Panel_Move ui_tutorial_1;

	// Token: 0x04000486 RID: 1158
	[Header("Окно обучения №2")]
	[SerializeField]
	private UI_Panel_Move ui_tutorial_2;

	// Token: 0x04000487 RID: 1159
	[Header("Окно обучения из настроек")]
	[SerializeField]
	private UI_Panel_Move ui_tutorial_setting;

	// Token: 0x04000488 RID: 1160
	[Header("Кнопки главного меню:")]
	[SerializeField]
	private Button button_play;

	// Token: 0x04000489 RID: 1161
	[SerializeField]
	private Button button_setting;

	// Token: 0x0400048A RID: 1162
	[SerializeField]
	private Button button_exit_game;

	// Token: 0x0400048B RID: 1163
	[SerializeField]
	private Button button_reset;

	// Token: 0x0400048C RID: 1164
	[Header("Кнопка закрытия настроек:")]
	[SerializeField]
	private Button button_setting_closed;

	// Token: 0x0400048D RID: 1165
	private InputAction escape_play;

	// Token: 0x0400048E RID: 1166
	private InputAction escape_menu;

	// Token: 0x0400048F RID: 1167
	private InputAction escape_setting;

	// Token: 0x04000490 RID: 1168
	private InputAction escape_map;

	// Token: 0x04000491 RID: 1169
	private InputAction escape_tutorial_1;

	// Token: 0x04000492 RID: 1170
	private InputAction escape_tutorial_2;

	// Token: 0x04000493 RID: 1171
	private InputAction escape_tutorial_setting;

	// Token: 0x04000494 RID: 1172
	private bool map_in_level;

	// Token: 0x04000495 RID: 1173
	[SerializeField]
	private bool old_game;
}
