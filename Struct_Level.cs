using System;
using Spine.Unity;
using UnityEngine;

// Token: 0x02000090 RID: 144
public static class Struct_Level
{
	// Token: 0x020001BE RID: 446
	[Serializable]
	public struct Stage_Find_Puzzle
	{
		// Token: 0x040009D0 RID: 2512
		public Struct_Level.Find_Group_Items[] find_group_items;
	}

	// Token: 0x020001BF RID: 447
	[Serializable]
	public struct Find_Group_Items
	{
		// Token: 0x060009F8 RID: 2552 RVA: 0x0002A7B8 File Offset: 0x000289B8
		public void setup_item_go()
		{
			this.item_Main = new Item_Main[this.find_items_go.Length];
			for (int i = 0; i < this.find_items_go.Length; i++)
			{
				if (this.find_items_go[i].GetComponent<SpriteRenderer>() != null)
				{
					if (this.find_items_go[i].GetComponent<Item_Main>() == null)
					{
						this.find_items_go[i].AddComponent<Item_Main>();
					}
					this.item_Main[i] = this.find_items_go[i].GetComponent<Item_Main>();
					this.item_Main[i].Add_Component_Set(this.Item_Group);
				}
				else if (this.find_items_go[i].GetComponent<MeshRenderer>() != null)
				{
					if (this.find_items_go[i].GetComponent<Item_Main>() == null && (this.find_items_go[i].GetComponent<SkeletonAnimation>() != null || this.find_items_go[i].GetComponent<SkeletonPartsRenderer>() != null))
					{
						this.find_items_go[i].AddComponent<Item_Main_Spine>();
					}
					this.item_Main[i] = this.find_items_go[i].GetComponent<Item_Main_Spine>();
					this.item_Main[i].Add_Component_Set(this.Item_Group);
				}
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0002A8E0 File Offset: 0x00028AE0
		public void start_find_group()
		{
			this.group_active_find = true;
			Item_Main[] array = this.item_Main;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Start_Find_Item();
			}
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0002A914 File Offset: 0x00028B14
		public void load_complite_all_item()
		{
			this.group_find_complite = true;
			Item_Main[] array = this.item_Main;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].item_load_complite();
			}
		}

		// Token: 0x040009D1 RID: 2513
		[SerializeField]
		public Enums_Localization.Items_E Item_Group;

		// Token: 0x040009D2 RID: 2514
		[SerializeField]
		[Range(0f, 100f)]
		public int hard_index;

		// Token: 0x040009D3 RID: 2515
		[SerializeField]
		public GameObject[] find_items_go;

		// Token: 0x040009D4 RID: 2516
		[SerializeField]
		public Item_Main[] item_Main;

		// Token: 0x040009D5 RID: 2517
		[SerializeField]
		public bool group_active_find;

		// Token: 0x040009D6 RID: 2518
		[SerializeField]
		public bool group_find_complite;
	}

	// Token: 0x020001C0 RID: 448
	[Serializable]
	public struct Objects_Color_Time
	{
		// Token: 0x060009FB RID: 2555 RVA: 0x0002A945 File Offset: 0x00028B45
		public void Set_group(GameObject[] go_color_sprite_value)
		{
			this.go_color_sprite = go_color_sprite_value;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0002A950 File Offset: 0x00028B50
		public void Set_objects_group(float delay_time_value, bool set_delay_time_value)
		{
			if (set_delay_time_value)
			{
				this.delay_time_next = delay_time_value;
			}
			this.find_event_objects = new Find_event_object[this.go_color_sprite.Length];
			for (int i = 0; i < this.find_event_objects.Length; i++)
			{
				if (this.go_color_sprite[i].GetComponent<Find_event_object>() == null)
				{
					this.go_color_sprite[i].AddComponent<Find_event_object>();
				}
				this.find_event_objects[i] = this.go_color_sprite[i].GetComponent<Find_event_object>();
				this.find_event_objects[i].Add_Component_Setup();
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0002A9D2 File Offset: 0x00028BD2
		public float RT_delay_time()
		{
			return this.delay_time_next;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0002A9DC File Offset: 0x00028BDC
		public void Update_White_Color(float speed_color_update_value)
		{
			for (int i = 0; i < this.find_event_objects.Length; i++)
			{
				this.find_event_objects[i].Update_White_Color(speed_color_update_value);
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0002AA0C File Offset: 0x00028C0C
		public void Load_White_Color()
		{
			for (int i = 0; i < this.find_event_objects.Length; i++)
			{
				this.find_event_objects[i].Load_White_Color();
			}
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0002AA3C File Offset: 0x00028C3C
		public void Test_color()
		{
			for (int i = 0; i < this.find_event_objects.Length; i++)
			{
				this.find_event_objects[i].Re_test_color();
			}
		}

		// Token: 0x040009D7 RID: 2519
		public GameObject[] go_color_sprite;

		// Token: 0x040009D8 RID: 2520
		private float delay_time_next;

		// Token: 0x040009D9 RID: 2521
		private Find_event_object[] find_event_objects;
	}

	// Token: 0x020001C1 RID: 449
	[Serializable]
	public struct Find_group_sprite
	{
		// Token: 0x040009DA RID: 2522
		public Enums_Localization.Items_E Item_Group;

		// Token: 0x040009DB RID: 2523
		public Sprite[] sprite_item;

		// Token: 0x040009DC RID: 2524
		public bool foldout;
	}

	// Token: 0x020001C2 RID: 450
	[Serializable]
	public struct Find_group_go
	{
		// Token: 0x040009DD RID: 2525
		public Enums_Localization.Items_E Item_Group;

		// Token: 0x040009DE RID: 2526
		public GameObject Game_object;
	}
}
