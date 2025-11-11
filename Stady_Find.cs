using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x0200008D RID: 141
public class Stady_Find : Stady_Main
{
	// Token: 0x17000028 RID: 40
	// (get) Token: 0x06000396 RID: 918 RVA: 0x00011900 File Offset: 0x0000FB00
	public int RT_count_max
	{
		get
		{
			int num = 0;
			for (int i = 0; i < this.find_group_items.Length; i++)
			{
				num += this.find_group_items[i].item_Main.Length;
			}
			this.count_max = num;
			return this.count_max;
		}
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x06000397 RID: 919 RVA: 0x00011945 File Offset: 0x0000FB45
	public int RT_count_find
	{
		get
		{
			return this.count_find;
		}
	}

	// Token: 0x06000398 RID: 920 RVA: 0x0001194D File Offset: 0x0000FB4D
	public Struct_Level.Find_Group_Items[] RT_find_group_items()
	{
		return this.find_group_items;
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00011955 File Offset: 0x0000FB55
	public void SET_find_group_items(Struct_Level.Find_Group_Items[] find_group_items_value)
	{
		this.find_group_items = find_group_items_value;
		this.SET_Find_event_item_group();
	}

	// Token: 0x0600039A RID: 922 RVA: 0x00011964 File Offset: 0x0000FB64
	private void SET_Find_event_item_group()
	{
		this.find_event_group = base.GetComponentsInChildren<Find_event_main>(true);
		for (int i = 0; i < this.find_event_group.Length; i++)
		{
			this.find_event_group[i].Set_Color_object();
			if (this.find_event_group[i].GetComponent<Find_event_items>() != null)
			{
				this.find_event_group[i].GetComponent<Find_event_items>().Set_item_find();
			}
		}
		this.interactive_main = base.GetComponentsInChildren<Interactive>(true);
	}

	// Token: 0x0600039B RID: 923 RVA: 0x000119D4 File Offset: 0x0000FBD4
	public override void Awake_set()
	{
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			this.find_group_items[i].setup_item_go();
		}
		for (int j = 0; j < this.find_event_group.Length; j++)
		{
			if (this.find_event_group[j].GetComponent<Find_event_count>() != null)
			{
				this.find_event_count_group.Add(this.find_event_group[j].GetComponent<Find_event_count>());
			}
		}
		this.load_set_find_event();
	}

	// Token: 0x0600039C RID: 924 RVA: 0x00011A4C File Offset: 0x0000FC4C
	public List<Enums_Localization.Items_E> RT_List_items()
	{
		List<Enums_Localization.Items_E> list = new List<Enums_Localization.Items_E>();
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			list.Add(this.find_group_items[i].Item_Group);
		}
		return list;
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00011A8C File Offset: 0x0000FC8C
	private void OnDestroy()
	{
		Sa_IS.input_Main.am_play.Q_key.started -= this.Find_Group_1;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00011ABC File Offset: 0x0000FCBC
	public override void Set_play(int level_value, int stady_value, int count_max_value)
	{
		Sa_IS.input_Main.am_play.Q_key.started += this.Find_Group_1;
		this.recount_max = count_max_value;
		EA.Find_Item = (Action<Enums_Localization.Items_E, Item_Main>)Delegate.Combine(EA.Find_Item, new Action<Enums_Localization.Items_E, Item_Main>(this.item_find));
		Debug.Log("Set_play. Level - " + level_value.ToString() + ". Stady - " + stady_value.ToString());
		base.Set_data(level_value, stady_value);
		this.index_find_group = new int[SL_Data.d_Game.find_group_max];
		if (this.check_new_find())
		{
			Debug.Log("first_set_find_groups();");
			this.first_set_find_groups();
		}
		else
		{
			Debug.Log("load_set_find_groups();");
			this.load_set_find_groups();
		}
		this.load_set_groups();
		this.math_max_all_count_items();
		this.update_all_count_items_find();
		this.load_set_find_event();
		this.load_interactive_objects();
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00011B9C File Offset: 0x0000FD9C
	public override void Set_complite(int level_value, int stady_value)
	{
		Debug.Log("Set_complite. Level - " + level_value.ToString() + ". Stady - " + stady_value.ToString());
		base.Set_data(level_value, stady_value);
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			this.load_complite_group_all_item(i);
		}
		this.load_interactive_objects();
		this.math_max_all_count_items();
		this.count_find = 1000;
		this.load_set_find_event();
		this.load_interactive_objects();
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x00011C10 File Offset: 0x0000FE10
	public override void TEST()
	{
		for (int i = 0; i < this.find_event_group.Length; i++)
		{
			this.find_event_group[i].Unity_Editor_Awake();
		}
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00011C40 File Offset: 0x0000FE40
	public override void Help()
	{
		SL_Data.d_Game.ACH_hot_help_item_count = 0;
		List<int> list = new List<int>();
		for (int i = 0; i < this.index_find_group.Length; i++)
		{
			if (this.index_find_group[i] >= 0)
			{
				list.Add(this.index_find_group[i]);
			}
		}
		if (list.Count > 0)
		{
			int num = 0;
			int num2 = 1000;
			for (int j = 0; j < list.Count; j++)
			{
				Item_Main[] item_Main = this.find_group_items[list[j]].item_Main;
				List<Item_Main> list2 = new List<Item_Main>();
				for (int k = 0; k < item_Main.Length; k++)
				{
					if (!item_Main[k].Return_Test_Item_Find())
					{
						list2.Add(item_Main[k]);
					}
				}
				if (list2.Count < num2)
				{
					num2 = list2.Count;
					num = list[j];
				}
			}
			Item_Main[] item_Main2 = this.find_group_items[num].item_Main;
			List<Item_Main> list3 = new List<Item_Main>();
			for (int l = 0; l < item_Main2.Length; l++)
			{
				if (!item_Main2[l].Return_Test_Item_Find())
				{
					list3.Add(item_Main2[l]);
				}
			}
			Item_Main item_Main3 = list3[Random.Range(0, list3.Count)];
			item_Main3.This_Item_Help();
			Debug.Log(string.Format("Определен предмет для помощи - {0}", item_Main3));
			Action<Vector3, Enums_Localization.Items_E> help_find_item = EA.Help_find_item;
			if (help_find_item == null)
			{
				return;
			}
			help_find_item(item_Main3.help_point(), item_Main3.Return_Group_Name());
		}
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00011DAC File Offset: 0x0000FFAC
	private void item_find(Enums_Localization.Items_E group_value, Item_Main item_value)
	{
		SL_Data.d_Game.ACH_hot_help_item_count++;
		Achievement_manager.st.Achievement_hot_help_item_count_check();
		for (int i = 0; i < this.index_find_group.Length; i++)
		{
			Debug.Log(string.Format("Enums_Localization.Items_E - {0}, Item_Main - {1}", group_value, item_value));
			if (this.index_find_group[i] != -1)
			{
				Debug.Log(string.Format("index_find_group[i] - {0}", this.index_find_group[i]));
				if (this.find_group_items[this.index_find_group[i]].Item_Group == group_value)
				{
					int index_group_current = this.index_find_group[i];
					int num = Array.IndexOf<Item_Main>(this.find_group_items[index_group_current].item_Main, item_value);
					if (num != -1)
					{
						this.data_details[index_group_current, num] = true;
						this.update_all_count_items_find();
						for (int j = 0; j < this.find_event_count_group.Count; j++)
						{
							this.find_event_count_group[j].Check_event_complite_play();
						}
					}
					int num2 = this.find_group_items[index_group_current].item_Main.Length - Enumerable.Range(0, this.data_details.GetLength(1)).Count((int t) => this.data_details[index_group_current, t]);
					Frame_Items.st.Group_Find_item(this.find_group_items[index_group_current].Item_Group, num2);
					if (num2 <= 0)
					{
						Achievement_manager.st.Achievement_group_items(this.find_group_items[index_group_current].Item_Group);
						Action<Enums_Audio.Effect> audio_effect_Play = EA.Audio_effect_Play;
						if (audio_effect_Play != null)
						{
							audio_effect_Play(Enums_Audio.Effect.Find_Group);
						}
						Debug.Log("EA.Audio_effect_Play?.Invoke(Enums_Audio.Effect.Find_Group);");
						this.data_complite[index_group_current] = true;
						this.data_active[index_group_current] = false;
						this.find_group_items[index_group_current].group_find_complite = true;
						this.find_group_items[index_group_current].group_active_find = false;
						this.index_find_group[i] = -1;
						if (this.check_new_find_group())
						{
							if (!this.old_scene)
							{
								if (SL_Data.d_Setting.Next_Card)
								{
									this.next_index_find_group = i;
									this.card_select_new_group();
								}
								else
								{
									this.index_find_group[i] = this.search_new_group_find();
									index_group_current = this.index_find_group[i];
									this.data_active[index_group_current] = true;
									this.find_group_items[index_group_current].start_find_group();
									Frame_Items.st.Add_Group_Items(this.find_group_items[index_group_current].Item_Group, this.find_group_items[index_group_current].item_Main.Length);
								}
							}
							else
							{
								this.index_find_group[i] = this.search_new_group_find();
								index_group_current = this.index_find_group[i];
								this.data_active[index_group_current] = true;
								this.find_group_items[index_group_current].start_find_group();
								Frame_Items.st.Add_Group_Items(this.find_group_items[index_group_current].Item_Group, this.find_group_items[index_group_current].item_Main.Length);
							}
						}
						else if (this.check_stady_complite())
						{
							EA.Find_Item = (Action<Enums_Localization.Items_E, Item_Main>)Delegate.Remove(EA.Find_Item, new Action<Enums_Localization.Items_E, Item_Main>(this.item_find));
							Sa_IS.input_Main.am_play.Find_Group_1.started -= this.Find_Group_1;
							base.Complite_stady();
						}
					}
					else
					{
						Action<Enums_Audio.Effect> audio_effect_Play2 = EA.Audio_effect_Play;
						if (audio_effect_Play2 != null)
						{
							audio_effect_Play2(Enums_Audio.Effect.Find_Item);
						}
						Action audio_effect_find_item_play = EA.Audio_effect_find_item_play;
						if (audio_effect_find_item_play != null)
						{
							audio_effect_find_item_play();
						}
					}
					base.Save_data();
					return;
				}
			}
		}
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0001216C File Offset: 0x0001036C
	private void Check_all_group_events()
	{
		for (int i = 0; i < this.find_event_group.Length; i++)
		{
			this.find_event_group[i].Check_event_complite_play();
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x0001219C File Offset: 0x0001039C
	private void card_select_new_group()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.hard_stady.Length; i++)
		{
			for (int j = 0; j < this.find_group_items.Length; j++)
			{
				if (!list.Contains(j) && this.find_group_items[j].hard_index <= this.hard_stady[i] && !this.data_active[j] && !this.data_complite[j])
				{
					list.Add(j);
				}
			}
			if (list.Count >= 3)
			{
				break;
			}
		}
		int num;
		if (list.Count >= 3)
		{
			num = 3;
		}
		else
		{
			num = list.Count;
		}
		List<ValueTuple<Enums_Localization.Items_E, int>> list2 = new List<ValueTuple<Enums_Localization.Items_E, int>>();
		for (int k = 0; k < num; k++)
		{
			int index = Random.Range(0, list.Count);
			list2.Add(new ValueTuple<Enums_Localization.Items_E, int>(this.find_group_items[list[index]].Item_Group, this.find_group_items[list[index]].find_items_go.Length));
			list.RemoveAt(index);
		}
		Cards_Manager.st.setup_card(list2);
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x000122B0 File Offset: 0x000104B0
	public override void next_group_find(Enums_Localization.Items_E item_Name_v)
	{
		Debug.Log(string.Format("Next_group_find - {0}", item_Name_v));
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			if (this.find_group_items[i].Item_Group == item_Name_v)
			{
				this.index_find_group[this.next_index_find_group] = i;
				this.data_active[i] = true;
				this.find_group_items[i].start_find_group();
				Frame_Items.st.Add_Group_Items(this.find_group_items[i].Item_Group, this.find_group_items[i].item_Main.Length);
				break;
			}
		}
		base.Save_data();
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00012358 File Offset: 0x00010558
	public void update_data_interactive(int index_value, bool status_value)
	{
		this.data_interactive[index_value] = status_value;
		this.data_interactive_use[index_value] = true;
		base.Save_data();
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00012374 File Offset: 0x00010574
	private int search_new_group_find()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.hard_stady.Length; i++)
		{
			for (int j = 0; j < this.find_group_items.Length; j++)
			{
				if (this.find_group_items[j].hard_index <= this.hard_stady[i] && !this.data_active[j] && !this.data_complite[j])
				{
					list.Add(j);
				}
			}
			if (list.Count > 0)
			{
				break;
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return -1;
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0001240C File Offset: 0x0001060C
	private void math_max_all_count_items()
	{
		int num = 0;
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			num += this.find_group_items[i].item_Main.Length;
		}
		this.count_max = num + this.recount_max;
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00012454 File Offset: 0x00010654
	private void update_all_count_items_find()
	{
		int num = 0;
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			if (this.find_group_items[i].group_find_complite)
			{
				num += this.find_group_items[i].item_Main.Length;
			}
			else
			{
				for (int j = 0; j < this.find_group_items[i].item_Main.Length; j++)
				{
					if (this.data_details[i, j])
					{
						num++;
					}
				}
			}
		}
		this.count_find = num + this.recount_max;
		Frame_Items.st.All_count_update(this.count_find, this.count_max);
	}

	// Token: 0x060003AA RID: 938 RVA: 0x000124F8 File Offset: 0x000106F8
	private void first_set_find_groups()
	{
		for (int i = 0; i < this.index_find_group.Length; i++)
		{
			this.index_find_group[i] = -1;
		}
		if (this.find_group_items.Length < 3)
		{
			Debug.Log(string.Concat(new string[]
			{
				"<color=#",
				ColorUtility.ToHtmlStringRGB(Color.red),
				">СЛИШКОМ МАЛО ГРУПП ДЛЯ ПОИСКА - ",
				this.find_group_items.Length.ToString(),
				"</color>"
			}));
			return;
		}
		for (int j = 0; j < this.index_find_group.Length; j++)
		{
			this.index_find_group[j] = this.search_new_group_find();
			this.data_active[this.index_find_group[j]] = true;
			this.find_group_items[this.index_find_group[j]].group_active_find = true;
		}
	}

	// Token: 0x060003AB RID: 939 RVA: 0x000125C0 File Offset: 0x000107C0
	private void load_set_find_groups()
	{
		Array.Fill<int>(this.index_find_group, -1);
		int num = 0;
		for (int i = 0; i < this.data_active.Length; i++)
		{
			if (this.data_active[i])
			{
				this.index_find_group[num] = i;
				num++;
			}
		}
		for (int j = 0; j < this.index_find_group.Length; j++)
		{
			if (this.index_find_group[j] < 0 && this.search_new_group_find() > -1)
			{
				this.index_find_group[j] = this.search_new_group_find();
				this.data_active[this.index_find_group[j]] = true;
				this.find_group_items[this.index_find_group[j]].group_active_find = true;
			}
		}
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00012664 File Offset: 0x00010864
	private void load_set_groups()
	{
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			if (this.data_complite[i])
			{
				this.load_complite_group_all_item(i);
			}
		}
		for (int j = 0; j < this.index_find_group.Length; j++)
		{
			if (this.index_find_group[j] != -1)
			{
				Debug.Log("find_group_items[index_find_group[i]].item_Main.Length - " + this.index_find_group[j].ToString());
				int num = this.index_find_group[j];
				int num2 = this.find_group_items[num].item_Main.Length;
				this.find_group_items[num].start_find_group();
				this.data_active[num] = true;
				for (int k = 0; k < this.find_group_items[num].item_Main.Length; k++)
				{
					if (this.data_details[num, k])
					{
						num2--;
						this.find_group_items[num].item_Main[k].item_load_complite();
					}
				}
				Frame_Items.st.Add_Group_Items(this.find_group_items[num].Item_Group, num2);
			}
		}
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00012780 File Offset: 0x00010980
	private void load_complite_group_all_item(int index_group_value)
	{
		this.find_group_items[index_group_value].group_find_complite = true;
		for (int i = 0; i < this.find_group_items[index_group_value].item_Main.Length; i++)
		{
			this.find_group_items[index_group_value].item_Main[i].item_load_complite();
		}
	}

	// Token: 0x060003AE RID: 942 RVA: 0x000127D8 File Offset: 0x000109D8
	private void load_interactive_objects()
	{
		if (this.data_interactive.Length < this.interactive_main.Length)
		{
			Debug.Log("<color=#" + ColorUtility.ToHtmlStringRGB(Color.red) + ">ПРОВЫШЕН ЛИМИТ ИНТЕРАКТИВНЫХ ОБЪЕКТОВ В СТАДИИ</color>");
		}
		for (int i = 0; i < this.interactive_main.Length; i++)
		{
			Debug.Log(string.Format("{0} - {1} - {2} - {3}", new object[]
			{
				this.interactive_main[i].gameObject.name,
				i,
				this.data_interactive[i],
				this.data_interactive_use[i]
			}));
			this.interactive_main[i].Set(this, i, this.data_interactive[i], this.data_interactive_use[i]);
		}
	}

	// Token: 0x060003AF RID: 943 RVA: 0x000128A0 File Offset: 0x00010AA0
	public List<Interactive_momental> RT_interactive_momental()
	{
		List<Interactive_momental> list = new List<Interactive_momental>();
		for (int i = 0; i < this.interactive_main.Length; i++)
		{
			if (this.interactive_main[i].GetComponent<Interactive_momental>())
			{
				list.Add(this.interactive_main[i].GetComponent<Interactive_momental>());
			}
		}
		return list;
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x000128F0 File Offset: 0x00010AF0
	private void load_set_find_event()
	{
		for (int i = 0; i < this.find_event_group.Length; i++)
		{
			this.find_event_group[i].Set_Awake(this);
		}
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x00012920 File Offset: 0x00010B20
	private bool check_new_find()
	{
		for (int i = 0; i < this.data_active.Length; i++)
		{
			if (this.data_active[i] || this.data_complite[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x00012958 File Offset: 0x00010B58
	private bool check_stady_complite()
	{
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			if (!this.data_complite[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x00012988 File Offset: 0x00010B88
	private bool check_new_find_group()
	{
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			if (!this.data_active[i] && !this.data_complite[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x000129C0 File Offset: 0x00010BC0
	private void Find_Group_1(InputAction.CallbackContext cc)
	{
		if (SL_Data.st.god_mod)
		{
			for (int i = 0; i < this.index_find_group.Length; i++)
			{
				if (this.index_find_group[i] != -1)
				{
					Item_Main[] item_Main = this.find_group_items[this.index_find_group[i]].item_Main;
					for (int j = 0; j < item_Main.Length; j++)
					{
						item_Main[j].Item_find_complite();
					}
					return;
				}
			}
			SL_Data.st.Save_Game();
			this.Find_all_items_in_group(0);
		}
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x00012A38 File Offset: 0x00010C38
	private void Find_Group_2(InputAction.CallbackContext cc)
	{
		this.Find_all_items_in_group(1);
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x00012A41 File Offset: 0x00010C41
	private void Find_Group_3(InputAction.CallbackContext cc)
	{
		this.Find_all_items_in_group(2);
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x00012A4A File Offset: 0x00010C4A
	private void Find_all_items_in_group(int index)
	{
		base.StartCoroutine(this.IE_Find_items(index));
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00012A5A File Offset: 0x00010C5A
	private IEnumerator IE_Find_items(int index)
	{
		Item_Main[] item_Main = this.find_group_items[this.index_find_group[index]].item_Main;
		for (int i = 0; i < item_Main.Length; i++)
		{
			item_Main[i].Item_find_complite();
		}
		yield return new WaitForSeconds(0.1f);
		SL_Data.st.Save_Game();
		yield break;
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x00012A70 File Offset: 0x00010C70
	public List<Enums_Localization.Items_E> RT_items_group_name()
	{
		List<Enums_Localization.Items_E> list = new List<Enums_Localization.Items_E>();
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			if (this.find_group_items[i].group_active_find)
			{
				list.Add(this.find_group_items[i].Item_Group);
			}
		}
		return list;
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00012AC4 File Offset: 0x00010CC4
	[ContextMenu("Test_Group_Color")]
	public void Test_group_Color()
	{
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			Color color_value = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
			for (int j = 0; j < this.find_group_items[i].item_Main.Length; j++)
			{
				this.find_group_items[i].item_Main[j].Test_Color(color_value);
			}
		}
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00012B54 File Offset: 0x00010D54
	[ContextMenu("Clear_find_item_null")]
	public void Clear_find_item_null()
	{
		for (int i = 0; i < this.find_group_items.Length; i++)
		{
			List<GameObject> list = new List<GameObject>();
			for (int j = 0; j < this.find_group_items[i].find_items_go.Length; j++)
			{
				if (this.find_group_items[i].find_items_go[j] != null)
				{
					list.Add(this.find_group_items[i].find_items_go[j]);
				}
			}
			if (this.find_group_items[i].find_items_go.Length != list.Count)
			{
				this.find_group_items[i].find_items_go = list.ToArray();
			}
		}
	}

	// Token: 0x060003BC RID: 956 RVA: 0x00012C04 File Offset: 0x00010E04
	[ContextMenu("Clear_event_group_null")]
	public void Clear_event_group_null()
	{
		List<Find_event_main> list = new List<Find_event_main>();
		for (int i = 0; i < this.find_event_group.Length; i++)
		{
			if (this.find_event_group[i] != null)
			{
				list.Add(this.find_event_group[i]);
				this.find_event_group[i].Clear_object_null();
				if (this.find_event_group[i].GetComponent<Find_event_items>() != null)
				{
					this.find_event_group[i].GetComponent<Find_event_items>().Clear_item_find_null();
				}
			}
		}
		if (this.find_event_group.Length != list.Count)
		{
			this.find_event_group = list.ToArray();
		}
	}

	// Token: 0x060003BD RID: 957 RVA: 0x00012C98 File Offset: 0x00010E98
	[ContextMenu("Clear_interactive_null")]
	public void Clear_interactive_null()
	{
		List<Interactive> list = new List<Interactive>();
		for (int i = 0; i < this.interactive_main.Length; i++)
		{
			if (this.interactive_main[i] != null)
			{
				list.Add(this.interactive_main[i]);
			}
		}
		if (this.interactive_main.Length != list.Count)
		{
			this.interactive_main = list.ToArray();
		}
	}

	// Token: 0x0400042A RID: 1066
	[Header("Группы для поиска:")]
	[SerializeField]
	private Struct_Level.Find_Group_Items[] find_group_items;

	// Token: 0x0400042B RID: 1067
	[Header("Градация сложности поиска:")]
	[SerializeField]
	private int[] hard_stady;

	// Token: 0x0400042C RID: 1068
	[Header("Интерактивные группы:")]
	[SerializeField]
	private Interactive[] interactive_main;

	// Token: 0x0400042D RID: 1069
	[Header("Группы событий:")]
	[SerializeField]
	private Find_event_main[] find_event_group;

	// Token: 0x0400042E RID: 1070
	[SerializeField]
	private List<Find_event_count> find_event_count_group;

	// Token: 0x0400042F RID: 1071
	[SerializeField]
	private int recount_max;

	// Token: 0x04000430 RID: 1072
	[SerializeField]
	private int count_max;

	// Token: 0x04000431 RID: 1073
	[SerializeField]
	private int count_find;

	// Token: 0x04000432 RID: 1074
	[SerializeField]
	private int[] index_find_group;

	// Token: 0x04000433 RID: 1075
	[SerializeField]
	private bool old_scene;

	// Token: 0x04000434 RID: 1076
	private int next_index_find_group;

	// Token: 0x04000435 RID: 1077
	public GameObject prefab_layers;

	// Token: 0x04000436 RID: 1078
	public List<GameObject> Layer_set_object_editors;
}
