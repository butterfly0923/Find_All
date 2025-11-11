using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000071 RID: 113
public class Find_event_items : Find_event_main
{
	// Token: 0x060002EE RID: 750 RVA: 0x0000EBAC File Offset: 0x0000CDAC
	[ContextMenu("Set_item_find")]
	public void Set_item_find()
	{
		if (this.Parent_item_find == null)
		{
			this.Parent_item_find = new List<Transform>();
		}
		if (this.Parent_item_find.Count <= 0)
		{
			this.Parent_item_find = new List<Transform>();
			GameObject gameObject = Object.Instantiate<GameObject>(new GameObject("Items_to_search_for"), base.transform);
			gameObject.AddComponent<Marker_find_items>();
			gameObject.name = "Items_to_search_for -- " + base.gameObject.name;
			gameObject.transform.SetAsFirstSibling();
			this.Parent_item_find.Add(gameObject.transform);
		}
		this.Item_need_find = new GameObject[0];
		List<GameObject> list = new List<GameObject>();
		if (this.Add_item_need_find != null)
		{
			for (int i = 0; i < this.Add_item_need_find.Length; i++)
			{
				list.Add(this.Add_item_need_find[i]);
			}
		}
		for (int j = 0; j < this.Parent_item_find.Count; j++)
		{
			if (this.Parent_item_find != null)
			{
				for (int k = 0; k < this.Parent_item_find[j].childCount; k++)
				{
					list.Add(this.Parent_item_find[j].GetChild(k).gameObject);
				}
			}
		}
		Marker_spine_items[] componentsInChildren = base.GetComponentsInChildren<Marker_spine_items>(true);
		for (int l = 0; l < componentsInChildren.Length; l++)
		{
			list.Add(componentsInChildren[l].gameObject);
		}
		this.Item_need_find = list.ToArray();
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0000ED0C File Offset: 0x0000CF0C
	public override void Set_Awake(Stady_Find stady_find_value)
	{
		this.Clear_item_find_null();
		base.Clear_object_null();
		this.Item_need_material = new Item_Find_Material[this.Item_need_find.Length];
		List<Item_Find_Material> list = new List<Item_Find_Material>();
		for (int i = 0; i < this.Item_need_find.Length; i++)
		{
			if (EA.scroll_test && this.Item_need_find[i].GetComponent<Item_Find_Material>() == null)
			{
				Debug.Log(string.Format("У объекта поиска нет компонента - {0}", this.Item_need_find[i]), this.Item_need_find[i]);
				Debug.Log(string.Format("Группа с ошибкой - {0}", this), this);
			}
			Item_Find_Material item_Find_Material;
			if (this.Item_need_find[i].TryGetComponent<Item_Find_Material>(out item_Find_Material))
			{
				item_Find_Material.Set_Find_event(this);
				list.Add(item_Find_Material);
			}
		}
		this.Item_need_material = list.ToArray();
		base.Set_Awake(stady_find_value);
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0000EDD0 File Offset: 0x0000CFD0
	protected override bool Check_event_complite()
	{
		for (int i = 0; i < this.Item_need_material.Length; i++)
		{
			if (!this.Item_need_material[i].Return_Find_Complite())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x0000EE02 File Offset: 0x0000D002
	public override void Check_event_complite_play()
	{
		if (this.Check_event_complite())
		{
			base.Update_White_Color();
		}
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0000EE14 File Offset: 0x0000D014
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
		List<GameObject> list5 = new List<GameObject>();
		for (int m = 0; m < this.Item_need_find.Length; m++)
		{
			if (this.Item_need_find[m].GetComponent<SpriteRenderer>())
			{
				list4.Add(this.Item_need_find[m]);
			}
			else if (this.Item_need_find[m].GetComponent<MeshRenderer>())
			{
				list5.Add(this.Item_need_find[m]);
			}
		}
		GameObject[] gameObject_find_v = list4.ToArray();
		gameObject.GetComponent<Test_Button_>().start_setting(list2, gameObject_find_v, list3, list5, this);
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0000F070 File Offset: 0x0000D270
	[ContextMenu("Clear_item_find_null")]
	public void Clear_item_find_null()
	{
		List<GameObject> list = new List<GameObject>();
		for (int i = 0; i < this.Item_need_find.Length; i++)
		{
			if (this.Item_need_find[i] != null)
			{
				list.Add(this.Item_need_find[i]);
			}
		}
		if (this.Item_need_find.Length != list.Count)
		{
			this.Item_need_find = list.ToArray();
		}
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0000F0D0 File Offset: 0x0000D2D0
	[ContextMenu("Creat_Color_Parent_1")]
	public override void Creat_Color_Parent_1()
	{
		if (this.parent_objects_Color_Time == null || this.parent_objects_Color_Time.Length == 0)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (object obj in base.transform)
			{
				Transform transform = (Transform)obj;
				if (!this.Parent_item_find.Contains(transform))
				{
					list.Add(transform.gameObject);
				}
			}
			GameObject gameObject = Object.Instantiate<GameObject>(new GameObject("Color (1)"), base.transform);
			foreach (GameObject gameObject2 in list)
			{
				gameObject2.transform.SetParent(gameObject.transform);
			}
			gameObject.name = "Color (1)";
			this.parent_objects_Color_Time = new GameObject[1];
			this.parent_objects_Color_Time[0] = gameObject;
		}
	}

	// Token: 0x040003B6 RID: 950
	[Header("Родительские объекты предметов для поиска:")]
	[SerializeField]
	private List<Transform> Parent_item_find;

	// Token: 0x040003B7 RID: 951
	[Header("Дополнительные предметы поиска для срабатывания события:")]
	[SerializeField]
	private GameObject[] Add_item_need_find;

	// Token: 0x040003B8 RID: 952
	[Header("Предметы поиска для срабатывания события:")]
	[SerializeField]
	private GameObject[] Item_need_find;

	// Token: 0x040003B9 RID: 953
	private Item_Find_Material[] Item_need_material;
}
