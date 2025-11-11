using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200008A RID: 138
public abstract class Open_door_helper_manager : MonoBehaviour
{
	// Token: 0x0600038C RID: 908 RVA: 0x000116EF File Offset: 0x0000F8EF
	public static IEnumerator IE_update_helper_check()
	{
		yield return new WaitForSeconds(3f);
		Open_door_helper_manager.update_stady_find();
		for (;;)
		{
			yield return new WaitForSeconds(60f);
			if (SL_Data.d_Setting.Helper)
			{
				List<int> list = new List<int>();
				if (Level_Data.st.RT_current_stady().GetComponent<Stady_Find>() != null && Open_door_helper_manager.inst_prefab == null)
				{
					Debug.Log("Level_Data.st.RT_current_stady().GetComponent<Stady_Find>() != null && inst_prefab == null");
					if (Level_Data.st.RT_current_stady().GetComponent<Stady_Find>() == Open_door_helper_manager.stady_find)
					{
						Debug.Log("for (int i = 0; i < all_interactive_data.Count; i++)");
						List<Enums_Localization.Items_E> list2 = Open_door_helper_manager.stady_find.RT_items_group_name();
						for (int i = 0; i < Open_door_helper_manager.all_interactive_data.Count; i++)
						{
							Open_door_helper_manager.interactive_check interactive_check = Open_door_helper_manager.all_interactive_data[i];
							Debug.Log(string.Format("{0} interactiveCheck.all_complite = {1};", i, interactive_check.all_complite));
							Debug.Log(string.Format("!all_interactive_data[{0}].all_complite", i));
							Debug.Log(string.Format("VAR - {0}", interactive_check.items.Count));
							interactive_check.check_this_group = false;
							for (int j = 0; j < list2.Count; j++)
							{
								for (int k = 0; k < interactive_check.items.Count; k++)
								{
									if (list2[j] == interactive_check.items[k].Return_Group_Name() && !interactive_check.interactive_momental.used)
									{
										interactive_check.check_this_group = true;
										list.Add(i);
										Debug.Log(string.Format("random_index.Add({0}) - {1};", i, list.Count));
										break;
									}
								}
								if (interactive_check.check_this_group)
								{
									break;
								}
							}
							Debug.Log(string.Format("{0} interactiveCheck.all_complite = {1};", i, interactive_check.all_complite));
							Open_door_helper_manager.all_interactive_data[i] = interactive_check;
						}
						if (list.Count > 0)
						{
							int index = list[Random.Range(0, list.Count)];
							Debug.Log(string.Format("random_index.Count - {0}", list.Count));
							Open_door_helper_manager.new_open_door_help(Open_door_helper_manager.all_interactive_data[index].position_point, Open_door_helper_manager.all_interactive_data[index].interactive_momental);
						}
					}
					else
					{
						Open_door_helper_manager.update_stady_find();
					}
				}
			}
			Debug.Log("Open_door_helper_manager");
		}
		yield break;
	}

	// Token: 0x0600038D RID: 909 RVA: 0x000116F7 File Offset: 0x0000F8F7
	private static void new_open_door_help(Vector3 vector3_value, Interactive_momental interactiveMomental)
	{
		Open_door_helper_manager.inst_prefab = Object.Instantiate<GameObject>(Open_door_helper_manager.prefab);
		Open_door_helper_manager.inst_prefab.transform.position = vector3_value;
		interactiveMomental.helper_open = Open_door_helper_manager.inst_prefab;
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00011724 File Offset: 0x0000F924
	private static void update_stady_find()
	{
		if (Level_Data.st.RT_current_stady().GetComponent<Stady_Find>())
		{
			Open_door_helper_manager.all_interactive_data = new List<Open_door_helper_manager.interactive_check>();
			Open_door_helper_manager.stady_find = Level_Data.st.RT_current_stady().GetComponent<Stady_Find>();
			List<Interactive_momental> list = Open_door_helper_manager.stady_find.RT_interactive_momental();
			Debug.Log("1");
			for (int i = 0; i < list.Count; i++)
			{
				Open_door_helper_manager.interactive_check interactive_check = default(Open_door_helper_manager.interactive_check);
				List<Transform> list2 = new List<Transform>();
				List<Item_Main> list3 = new List<Item_Main>();
				interactive_check.interactive_momental = list[i];
				ValueTuple<List<Transform>, List<Item_Main>> valueTuple = list[i].RT_data_interactive_momental();
				list2 = valueTuple.Item1;
				list3 = valueTuple.Item2;
				Debug.Log("3");
				if (list2.Count > 0)
				{
					Debug.Log("3");
					for (int j = 0; j < list2.Count; j++)
					{
						interactive_check.position_point += list2[j].position;
					}
					interactive_check.position_point /= (float)list2.Count;
					Debug.Log(string.Format("4 - {0}", interactive_check.position_point));
				}
				Debug.Log(string.Format("items_void - {0}", list3.Count));
				interactive_check.items = list3;
				Open_door_helper_manager.all_interactive_data.Add(interactive_check);
			}
		}
	}

	// Token: 0x04000422 RID: 1058
	public static GameObject prefab;

	// Token: 0x04000423 RID: 1059
	public static GameObject inst_prefab;

	// Token: 0x04000424 RID: 1060
	private static List<Open_door_helper_manager.interactive_check> all_interactive_data;

	// Token: 0x04000425 RID: 1061
	private static Stady_Find stady_find;

	// Token: 0x020001B7 RID: 439
	public struct interactive_check
	{
		// Token: 0x040009B6 RID: 2486
		public Interactive_momental interactive_momental;

		// Token: 0x040009B7 RID: 2487
		public Vector3 position_point;

		// Token: 0x040009B8 RID: 2488
		public List<Item_Main> items;

		// Token: 0x040009B9 RID: 2489
		public bool all_complite;

		// Token: 0x040009BA RID: 2490
		public bool check_this_group;
	}
}
