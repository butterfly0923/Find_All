using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000081 RID: 129
public static class Struct_Interactive
{
	// Token: 0x020001B0 RID: 432
	[Serializable]
	public struct Momental_objects
	{
		// Token: 0x060009BD RID: 2493 RVA: 0x000299BC File Offset: 0x00027BBC
		public void start_set(Interactive value)
		{
			this.interactive_object = new List<Interactive_object>();
			this.interactive_collider = new List<Collider>();
			this.item_find = new List<Item_Main>();
			this.sprite_add = new List<SpriteRenderer>();
			for (int i = 0; i < this.Click_object.Length; i++)
			{
				this.Click_object[i].SetActive(true);
				if (this.Click_object[i].GetComponent<Interactive_object>() == null)
				{
					this.Click_object[i].AddComponent<Interactive_object>().set_parent(value);
				}
				if (this.Click_object[i].GetComponent<SpriteRenderer>() != null)
				{
					this.Click_object[i].GetComponent<SpriteRenderer>().enabled = true;
					this.sprite_add.Add(this.Click_object[i].GetComponent<SpriteRenderer>());
				}
				if (this.Click_object[i].GetComponent<Collider>() == null)
				{
					this.Click_object[i].AddComponent<BoxCollider>();
					this.interactive_collider.Add(this.Click_object[i].GetComponent<Collider>());
				}
				else
				{
					for (int j = 0; j < this.Click_object[i].GetComponents<Collider>().Length; j++)
					{
						this.interactive_collider.Add(this.Click_object[i].GetComponents<Collider>()[j]);
					}
				}
				this.interactive_object.Add(this.Click_object[i].GetComponent<Interactive_object>());
			}
			for (int k = 0; k < this.Add_object.Length; k++)
			{
				if (this.Add_object[k] != null && this.Add_object[k].GetComponent<Item_Main>() != null)
				{
					this.item_find.Add(this.Add_object[k].GetComponent<Item_Main>());
				}
			}
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x00029B60 File Offset: 0x00027D60
		public void on_off(bool value)
		{
			for (int i = 0; i < this.interactive_collider.Count; i++)
			{
				this.interactive_collider[i].enabled = value;
			}
			for (int j = 0; j < this.item_find.Count; j++)
			{
				this.item_find[j].Collider_enabled(value);
			}
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x00029BC0 File Offset: 0x00027DC0
		public void on_off_start()
		{
			for (int i = 0; i < this.interactive_collider.Count; i++)
			{
				this.interactive_collider[i].enabled = false;
			}
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00029BF5 File Offset: 0x00027DF5
		public List<SpriteRenderer> RT_sprite()
		{
			return this.sprite_add;
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x00029C00 File Offset: 0x00027E00
		public void on_off_end(bool value)
		{
			for (int i = 0; i < this.interactive_collider.Count; i++)
			{
				this.interactive_collider[i].enabled = value;
			}
			for (int j = 0; j < this.item_find.Count; j++)
			{
				this.item_find[j].Collider_enabled(value);
			}
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x00029C5D File Offset: 0x00027E5D
		public List<Item_Main> RT_item_find()
		{
			return this.item_find;
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00029C65 File Offset: 0x00027E65
		public List<Interactive_object> RT_interactive_objects()
		{
			return this.interactive_object;
		}

		// Token: 0x0400099A RID: 2458
		[Header("Интерактивные элементы:")]
		public GameObject[] Click_object;

		// Token: 0x0400099B RID: 2459
		private List<Interactive_object> interactive_object;

		// Token: 0x0400099C RID: 2460
		[SerializeField]
		private List<Collider> interactive_collider;

		// Token: 0x0400099D RID: 2461
		[Header("Поисковые/дополнительные объекты:")]
		public GameObject[] Add_object;

		// Token: 0x0400099E RID: 2462
		[SerializeField]
		private List<Item_Main> item_find;

		// Token: 0x0400099F RID: 2463
		private List<SpriteRenderer> sprite_add;
	}

	// Token: 0x020001B1 RID: 433
	[Serializable]
	public struct Move_line_object
	{
		// Token: 0x060009C4 RID: 2500 RVA: 0x00029C70 File Offset: 0x00027E70
		public void start_set(Interactive value)
		{
			if (this.g_object.GetComponent<Interactive_object>() == null)
			{
				this.interactive_object = this.g_object.AddComponent<Interactive_object>();
				this.interactive_object.set_parent(value);
			}
			if (this.g_object.GetComponent<Collider>() == null)
			{
				this.go_collider = this.g_object.AddComponent<BoxCollider>();
			}
			this.go_transform = this.g_object.transform;
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x00029CE2 File Offset: 0x00027EE2
		public void update_position(float value_curve)
		{
			this.go_transform.localPosition = Vector3.Lerp(this.closed, this.open, this.curve_move.Evaluate(value_curve));
		}

		// Token: 0x040009A0 RID: 2464
		public GameObject g_object;

		// Token: 0x040009A1 RID: 2465
		public Vector3 open;

		// Token: 0x040009A2 RID: 2466
		public Vector3 closed;

		// Token: 0x040009A3 RID: 2467
		public AnimationCurve curve_move;

		// Token: 0x040009A4 RID: 2468
		public Interactive_object interactive_object;

		// Token: 0x040009A5 RID: 2469
		public Collider go_collider;

		// Token: 0x040009A6 RID: 2470
		public Transform go_transform;
	}
}
