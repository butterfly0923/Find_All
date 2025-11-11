using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000088 RID: 136
public class Level_Data : MonoBehaviour
{
	// Token: 0x06000371 RID: 881 RVA: 0x00010E2B File Offset: 0x0000F02B
	public int RT_level_index()
	{
		return this.level_index;
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x06000372 RID: 882 RVA: 0x00010E33 File Offset: 0x0000F033
	public Materials_SO Materials_level
	{
		get
		{
			return this.materials_level;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000373 RID: 883 RVA: 0x00010E3B File Offset: 0x0000F03B
	public Materials_Spine_SO Materials_Spine_level
	{
		get
		{
			return this.materials_spine_level;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000374 RID: 884 RVA: 0x00010E43 File Offset: 0x0000F043
	public Item_Data Item_data
	{
		get
		{
			return this.item_data;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000375 RID: 885 RVA: 0x00010E4B File Offset: 0x0000F04B
	public Scenes_Data Scenes_data
	{
		get
		{
			return this.scenes_data;
		}
	}

	// Token: 0x06000376 RID: 886 RVA: 0x00010E54 File Offset: 0x0000F054
	private void Awake()
	{
		Open_door_helper_manager.prefab = this.helper_door;
		Level_Data.st = (Level_Data)Set_Singleton.This<Level_Data, Level_Data>(this, Level_Data.st);
		SL_Data.st.Load_Game();
		for (int i = 0; i < this.Stady_levels.Length; i++)
		{
			this.Stady_levels[i].Awake_set();
		}
		if (SL_Data.d_Game.sl_level_complite[this.level_index])
		{
			for (int j = 0; j < this.Stady_levels.Length; j++)
			{
				this.Stady_levels[j].Set_complite(this.level_index, j);
			}
			Stady_Main[] stady_levels = this.Stady_levels;
			stady_levels[stady_levels.Length - 1].Set_Camera_position();
			Camera_controller.st.Max_coef();
		}
		else
		{
			for (int k = 0; k < this.Stady_levels.Length; k++)
			{
				if (!SL_Data.d_Game.sl_stady_complite[this.level_index, k])
				{
					int num = 0;
					for (int l = 0; l < k; l++)
					{
						if (this.Stady_levels[l].GetComponent<Stady_Find>() != null)
						{
							num += this.Stady_levels[l].GetComponent<Stady_Find>().RT_count_max;
						}
					}
					this.Stady_levels[k].Set_play(this.level_index, k, num);
					this.Stady_levels[k].Set_Camera_position();
					this.stady_index = k;
					break;
				}
				this.Stady_levels[k].Set_complite(this.level_index, k);
			}
		}
		if (EA.scroll_test && this.start_test_button)
		{
			this.TEST();
		}
	}

	// Token: 0x06000377 RID: 887 RVA: 0x00010FCC File Offset: 0x0000F1CC
	private void OnEnable()
	{
		EA.Help_button_down = (Action)Delegate.Combine(EA.Help_button_down, new Action(this.Help_stady));
		EA.Return_Group_Item = (Action<Enums_Localization.Items_E>)Delegate.Combine(EA.Return_Group_Item, new Action<Enums_Localization.Items_E>(this.Card_group_return));
		EA.Reset_level = (Action)Delegate.Combine(EA.Reset_level, new Action(this.reset_level));
		if (EA.scroll_test)
		{
			Sa_IS.input_Main.All.Test_Scroll.started += this.TEST_key;
		}
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00011064 File Offset: 0x0000F264
	private void OnDisable()
	{
		EA.Help_button_down = (Action)Delegate.Remove(EA.Help_button_down, new Action(this.Help_stady));
		EA.Return_Group_Item = (Action<Enums_Localization.Items_E>)Delegate.Remove(EA.Return_Group_Item, new Action<Enums_Localization.Items_E>(this.Card_group_return));
		EA.Reset_level = (Action)Delegate.Remove(EA.Reset_level, new Action(this.reset_level));
		if (EA.scroll_test)
		{
			Sa_IS.input_Main.All.Test_Scroll.started -= this.TEST_key;
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x000110FC File Offset: 0x0000F2FC
	private void Start()
	{
		SL_Data.d_Game.current_level = this.level_index;
		base.StartCoroutine(Open_door_helper_manager.IE_update_helper_check());
		List<Enums_Localization.Items_E> list = new List<Enums_Localization.Items_E>();
		for (int i = 0; i < this.Stady_levels.Length; i++)
		{
			Debug.Log(string.Format("Stady_levels - {0}", i));
			List<Enums_Localization.Items_E> list2 = this.Stady_levels[i].GetComponent<Stady_Find>().RT_List_items();
			Debug.Log(string.Format("list_items_void - {0}", list2.Count));
			for (int j = 0; j < list2.Count; j++)
			{
				if (!list.Contains(list2[j]))
				{
					list.Add(list2[j]);
				}
			}
		}
		Debug.Log(string.Format("list_items.Count - {0}", list.Count));
		for (int k = 0; k < list.Count; k++)
		{
		}
		if (Achievement_manager.st != null)
		{
			Achievement_manager.st.Achievement_Start_Game();
		}
	}

	// Token: 0x0600037A RID: 890 RVA: 0x000111F3 File Offset: 0x0000F3F3
	private void Help_stady()
	{
		this.Stady_levels[this.stady_index].Help();
	}

	// Token: 0x0600037B RID: 891 RVA: 0x00011207 File Offset: 0x0000F407
	private void TEST_key(InputAction.CallbackContext cc)
	{
		this.TEST();
	}

	// Token: 0x0600037C RID: 892 RVA: 0x00011210 File Offset: 0x0000F410
	[ContextMenu("Test_Stady")]
	private void TEST()
	{
		for (int i = 0; i < this.Stady_levels.Length; i++)
		{
			this.Stady_levels[i].TEST();
		}
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00011240 File Offset: 0x0000F440
	private void reset_level()
	{
		SL_Data.d_Game.Reset_level(this.level_index);
		SL_Data.d_Game.current_level = this.level_index;
		SL_Data.d_Game.load_level = this.level_index;
		SL_Data.st.Save_Game();
		Action load_level = EA.Load_level;
		if (load_level == null)
		{
			return;
		}
		load_level();
	}

	// Token: 0x0600037E RID: 894 RVA: 0x00011298 File Offset: 0x0000F498
	public void reset_level_old()
	{
		SL_Data.d_Game.Reset_level(2);
		SL_Data.d_Game.current_level = this.level_index;
		SL_Data.d_Game.load_level = this.level_index;
		SL_Data.st.Save_Game();
		Action load_level = EA.Load_level;
		if (load_level == null)
		{
			return;
		}
		load_level();
	}

	// Token: 0x0600037F RID: 895 RVA: 0x000112E9 File Offset: 0x0000F4E9
	[ContextMenu("All_button_event")]
	private void All_button_even()
	{
		Action all_button = Level_Data.All_button;
		if (all_button == null)
		{
			return;
		}
		all_button();
	}

	// Token: 0x06000380 RID: 896 RVA: 0x000112FC File Offset: 0x0000F4FC
	public void Stady_Complite(Stady_Main stady_value)
	{
		for (int i = 0; i < this.Stady_levels.Length; i++)
		{
			if (this.Stady_levels[i] == stady_value)
			{
				Achievement_manager.st.Achievement_stady(this.level_index, i);
				SL_Data.d_Game.sl_stady_complite[this.level_index, i] = true;
				SL_Data.d_Game.sl_stady_complite_first[this.level_index, i] = true;
				SL_Data.st.Save_Game();
				if (i == this.Stady_levels.Length - 1)
				{
					Debug.Log("<color=#" + ColorUtility.ToHtmlStringRGB(Color.green) + ">УРОВЕНЬ ПРОЙДЕН!!!</color>");
					SL_Data.d_Game.sl_level_complite[this.level_index] = true;
					SL_Data.d_Game.sl_level_complite_first[this.level_index] = true;
					EA.down_panel_open = true;
					Action update_stady = EA.Update_stady;
					if (update_stady != null)
					{
						update_stady();
					}
					Camera_controller.st.Max_coef();
					Action<int> level_COMPLITE = EA.LEVEL_COMPLITE;
					if (level_COMPLITE != null)
					{
						level_COMPLITE(this.level_index);
					}
					if (this.level_index >= SL_Data.d_Game.level_max - 1)
					{
						Debug.Log("<color=#" + ColorUtility.ToHtmlStringRGB(Color.blue) + ">ИГРА ПРОЙДЕНА!!!</color>");
						Achievement_manager.st.Achievement_End_Game();
						if (!SL_Data.d_Game.first_end_game)
						{
							Action game_COMPLITE = EA.GAME_COMPLITE;
							if (game_COMPLITE != null)
							{
								game_COMPLITE();
							}
							SL_Data.d_Game.first_end_game = true;
						}
					}
				}
				else
				{
					Debug.Log("VAR");
					this.stady_index = i + 1;
					Debug.Log(string.Concat(new string[]
					{
						"<color=#",
						ColorUtility.ToHtmlStringRGB(Color.green),
						">СЛЕДУЮЩАЯ СТАДИЯ - ",
						this.stady_index.ToString(),
						" !!!</color>"
					}));
					int num = 0;
					for (int j = 0; j <= i; j++)
					{
						if (this.Stady_levels[j].GetComponent<Stady_Find>() != null)
						{
							num += this.Stady_levels[j].GetComponent<Stady_Find>().RT_count_max;
						}
					}
					this.Stady_levels[this.stady_index].Set_play(this.level_index, this.stady_index, num);
					this.Stady_levels[this.stady_index].Set_Camera_position();
				}
			}
		}
		SL_Data.st.Save_Game();
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00011540 File Offset: 0x0000F740
	public Enums_Level.Stady RT_stady_level()
	{
		if (!SL_Data.d_Game.sl_level_complite[this.level_index])
		{
			Stady_Main stady_Main = this.Stady_levels[this.stady_index];
			Enums_Level.Stady result;
			if (!(stady_Main is Stady_Find))
			{
				if (!(stady_Main is Stady_Puzzle))
				{
					result = Enums_Level.Stady.Null;
				}
				else
				{
					result = Enums_Level.Stady.Puzzle;
				}
			}
			else
			{
				result = Enums_Level.Stady.Find;
			}
			return result;
		}
		Debug.Log("ЕСЛИ ПРОИЗОШЛО");
		if (this.level_index + 1 >= SL_Data.d_Game.level_max)
		{
			return Enums_Level.Stady.Map;
		}
		if (SL_Data.d_Game.sl_level_complite_first[this.level_index + 1])
		{
			return Enums_Level.Stady.Map;
		}
		return Enums_Level.Stady.Next_level;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x000115C7 File Offset: 0x0000F7C7
	public Stady_Main RT_current_stady()
	{
		if (SL_Data.d_Game.sl_level_complite[this.level_index])
		{
			Stady_Main[] stady_levels = this.Stady_levels;
			return stady_levels[stady_levels.Length - 1];
		}
		return this.Stady_levels[this.stady_index];
	}

	// Token: 0x06000383 RID: 899 RVA: 0x000115F6 File Offset: 0x0000F7F6
	private void Card_group_return(Enums_Localization.Items_E item_Name_v)
	{
		this.Stady_levels[this.stady_index].next_group_find(item_Name_v);
	}

	// Token: 0x04000411 RID: 1041
	[Header("--- Тестовый кусок ---")]
	public int load_stady_level;

	// Token: 0x04000412 RID: 1042
	[Header("Окно предметов поиска:")]
	[SerializeField]
	private UI_Panel_Move ui_down_panel_level;

	// Token: 0x04000413 RID: 1043
	[SerializeField]
	public int level_index;

	// Token: 0x04000414 RID: 1044
	[SerializeField]
	public int stady_index;

	// Token: 0x04000415 RID: 1045
	[SerializeField]
	private Stady_Main[] Stady_levels;

	// Token: 0x04000416 RID: 1046
	[SerializeField]
	private Materials_SO materials_level;

	// Token: 0x04000417 RID: 1047
	[SerializeField]
	private Materials_Spine_SO materials_spine_level;

	// Token: 0x04000418 RID: 1048
	[SerializeField]
	public AnimationCurve alpha_curve_interactive_momental;

	// Token: 0x04000419 RID: 1049
	public bool start_test_button;

	// Token: 0x0400041A RID: 1050
	public GameObject button_collider_find_stady;

	// Token: 0x0400041B RID: 1051
	public static Level_Data st;

	// Token: 0x0400041C RID: 1052
	[SerializeField]
	private GameObject helper_door;

	// Token: 0x0400041D RID: 1053
	[SerializeField]
	private Item_Data item_data;

	// Token: 0x0400041E RID: 1054
	[SerializeField]
	private Scenes_Data scenes_data;

	// Token: 0x0400041F RID: 1055
	public static Action All_button;
}
