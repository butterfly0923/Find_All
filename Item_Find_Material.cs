using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000078 RID: 120
public class Item_Find_Material : MonoBehaviour
{
	// Token: 0x17000023 RID: 35
	// (get) Token: 0x0600031B RID: 795 RVA: 0x0000FBCD File Offset: 0x0000DDCD
	public Collider This_collider
	{
		get
		{
			return this.this_collider;
		}
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0000FBD8 File Offset: 0x0000DDD8
	public virtual void Add_Component_Set()
	{
		if (base.GetComponent<SpriteRenderer>() != null)
		{
			this.this_SpriteRenderer = base.GetComponent<SpriteRenderer>();
			this.material_main = new Material(Level_Data.st.Materials_level.Return_Material(this.this_SpriteRenderer.sprite.texture));
			this.this_SpriteRenderer.material = this.material_main;
			this.material_main = this.this_SpriteRenderer.material;
			All_Material_Scene.st.Add_Material(this.material_main);
			this.material_main.SetFloat("Color_Alpha_Sc", -10f);
		}
		if (base.GetComponent<Collider>() == null)
		{
			this.this_collider = base.gameObject.AddComponent<BoxCollider>();
		}
		else
		{
			this.this_collider = base.gameObject.GetComponent<Collider>();
		}
		base.gameObject.GetComponent<Collider>().enabled = false;
		if (base.transform.childCount > 0)
		{
			this.Add_Items = true;
			this.Child_Add_Item = new List<Add_Item_Find_Material>();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				this.Child_Add_Item.Add(base.transform.GetChild(i).gameObject.AddComponent<Add_Item_Find_Material>());
			}
			this.Set_Child_Component();
		}
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0000FD10 File Offset: 0x0000DF10
	protected void Set_Child_Component()
	{
		for (int i = 0; i < this.Child_Add_Item.Count; i++)
		{
			this.Child_Add_Item[i].Add_Component_Setup();
		}
	}

	// Token: 0x0600031E RID: 798 RVA: 0x0000FD44 File Offset: 0x0000DF44
	public void Set_Find_event(Find_event_items value)
	{
		if (this.findEventItems == null)
		{
			this.findEventItems = new List<Find_event_items>();
		}
		if (!this.findEventItems.Contains(value))
		{
			this.findEventItems.Add(value);
		}
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0000FD73 File Offset: 0x0000DF73
	public virtual void start_item_find()
	{
		if (!this.color_flag)
		{
			this.start_find = true;
			if (this.this_SpriteRenderer.enabled)
			{
				this.this_collider.enabled = true;
			}
		}
	}

	// Token: 0x06000320 RID: 800 RVA: 0x0000FD9D File Offset: 0x0000DF9D
	public bool Return_Find_Complite()
	{
		return this.color_flag;
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
	public virtual void Visible(bool value)
	{
		this.this_SpriteRenderer.enabled = value;
		if (this.Add_Items)
		{
			foreach (Add_Item_Find_Material add_Item_Find_Material in this.Child_Add_Item)
			{
				add_Item_Find_Material.Visible(value);
			}
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0000FE10 File Offset: 0x0000E010
	public void Collider_enabled(bool value)
	{
		if (this.start_find)
		{
			this.this_collider.enabled = value;
		}
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0000FE26 File Offset: 0x0000E026
	public void Load_White_Color()
	{
		if (!this.color_flag)
		{
			this.material_main.SetFloat("Color_Alpha_Sc", this.Max_Color_Shader);
			this.color_flag = true;
		}
		this.this_collider.enabled = false;
		this.start_find = false;
		this.Add_Item_White_Color_start();
	}

	// Token: 0x06000324 RID: 804 RVA: 0x0000FE68 File Offset: 0x0000E068
	private void Add_Item_White_Color_start()
	{
		if (this.Add_Items)
		{
			for (int i = 0; i < this.Child_Add_Item.Count; i++)
			{
				this.Child_Add_Item[i].White_Color_start();
			}
		}
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0000FEA4 File Offset: 0x0000E0A4
	public void Update_White_Color(float value = 30f)
	{
		Debug.Log("Закрашивается объект - " + base.gameObject.name, this);
		this.this_collider.enabled = false;
		this.start_find = false;
		if (!this.color_flag)
		{
			this.color_flag = true;
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_White_Color(value));
			this.Add_Item_Update_White_Color();
		}
		if (this.findEventItems != null)
		{
			for (int i = 0; i < this.findEventItems.Count; i++)
			{
				this.findEventItems[i].Check_event_complite_play();
			}
		}
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0000FF4C File Offset: 0x0000E14C
	private void Add_Item_Update_White_Color()
	{
		if (this.Add_Items)
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				this.Child_Add_Item[i].Update_White_Color(30f);
			}
		}
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0000FF8D File Offset: 0x0000E18D
	private IEnumerator IE_White_Color(float value)
	{
		bool color_end = false;
		float value_color = this.Min_White_Shader;
		while (!color_end)
		{
			value_color += value * Time.deltaTime;
			this.material_main.SetFloat("Color_Alpha_Sc", value_color);
			if (value_color >= this.Max_Color_Shader)
			{
				color_end = true;
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0000FFA3 File Offset: 0x0000E1A3
	public void Test_Color(Color color_value)
	{
		this.material_main.SetColor("Colos_Test_Sc", color_value);
	}

	// Token: 0x040003E0 RID: 992
	[SerializeField]
	protected Material material_main;

	// Token: 0x040003E1 RID: 993
	[SerializeField]
	protected bool color_flag;

	// Token: 0x040003E2 RID: 994
	[SerializeField]
	protected List<Find_event_items> findEventItems;

	// Token: 0x040003E3 RID: 995
	[SerializeField]
	private SpriteRenderer this_SpriteRenderer;

	// Token: 0x040003E4 RID: 996
	private Coroutine coroutine;

	// Token: 0x040003E5 RID: 997
	protected float Min_White_Shader = -10f;

	// Token: 0x040003E6 RID: 998
	protected float Max_Color_Shader = 10f;

	// Token: 0x040003E7 RID: 999
	[SerializeField]
	protected List<Add_Item_Find_Material> Child_Add_Item;

	// Token: 0x040003E8 RID: 1000
	protected bool Add_Items;

	// Token: 0x040003E9 RID: 1001
	protected Collider this_collider;

	// Token: 0x040003EA RID: 1002
	[SerializeField]
	protected bool start_find;
}
