using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000070 RID: 112
public class Find_event_count : Find_event_main
{
	// Token: 0x060002E8 RID: 744 RVA: 0x0000E8A4 File Offset: 0x0000CAA4
	public override void Set_Awake(Stady_Find stady_find_value)
	{
		base.Clear_object_null();
		this.stady_find = stady_find_value;
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			this.objects_Color_Time[i].Set_objects_group(this.all_delay_time, this.all_delay_time_setting);
		}
		Debug.Log(string.Format("{0} - {1}", this.count_complite, this.stady_find.RT_count_find));
		Debug.Log(string.Format("{0} - {1} - ПРОВЕРКА ------------------- !!!!!!!!!", this, this.stady_find.RT_count_find), this);
		if (this.Check_event_complite())
		{
			Debug.Log(string.Format("{0} - типо пройдено ------------------- !!!!!!!!!", this));
			this.event_complite = true;
			base.Load_White_Color();
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0000E95E File Offset: 0x0000CB5E
	protected override bool Check_event_complite()
	{
		return this.stady_find.RT_count_find >= this.count_complite;
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0000E976 File Offset: 0x0000CB76
	public override void Check_event_complite_play()
	{
		if (!this.event_complite && this.Check_event_complite())
		{
			this.Event_Ach();
			base.Update_White_Color();
			this.event_complite = true;
		}
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0000E99B File Offset: 0x0000CB9B
	public void Event_Ach()
	{
		Achievement_manager.st.Achievement_complite_api(this.achievement_e);
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0000E9B0 File Offset: 0x0000CBB0
	public override void Unity_Editor_Awake()
	{
		List<Transform> list = new List<Transform>();
		Vector3 vector = default(Vector3);
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			for (int j = 0; j < this.objects_Color_Time[i].go_color_sprite.Length; j++)
			{
				list.Add(this.objects_Color_Time[i].go_color_sprite[j].transform);
			}
		}
		foreach (Transform transform in list)
		{
			vector += transform.position;
		}
		vector /= (float)list.Count;
		vector.z -= 10f;
		GameObject gameObject = Object.Instantiate<GameObject>(Level_Data.st.button_collider_find_stady, base.transform, false);
		gameObject.transform.position = vector;
		List<GameObject> list2 = new List<GameObject>();
		List<GameObject> list3 = new List<GameObject>();
		for (int k = 0; k < this.objects_Color_Time.Length; k++)
		{
			for (int l = 0; l < this.objects_Color_Time[k].go_color_sprite.Length; l++)
			{
				if (this.objects_Color_Time[k].go_color_sprite[l].GetComponent<SpriteRenderer>())
				{
					list2.Add(this.objects_Color_Time[k].go_color_sprite[l]);
				}
				else if (this.objects_Color_Time[k].go_color_sprite[l].GetComponent<MeshRenderer>())
				{
					list3.Add(this.objects_Color_Time[k].go_color_sprite[l]);
				}
			}
		}
		List<GameObject> list4 = new List<GameObject>();
		List<GameObject> gameObject_find_mesh_v = new List<GameObject>();
		GameObject[] gameObject_find_v = list4.ToArray();
		gameObject.GetComponent<Test_Button_>().start_setting(list2, gameObject_find_v, list3, gameObject_find_mesh_v, this);
	}

	// Token: 0x040003B3 RID: 947
	[SerializeField]
	private int count_complite;

	// Token: 0x040003B4 RID: 948
	[SerializeField]
	private bool event_complite;

	// Token: 0x040003B5 RID: 949
	[Header("Достижение при нахождении куска:")]
	[SerializeField]
	protected Enums_Steam.Achievement_E achievement_e;
}
