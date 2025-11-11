using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
public class Item_Main : MonoBehaviour, Iinteractive
{
	// Token: 0x0600032F RID: 815 RVA: 0x00010160 File Offset: 0x0000E360
	public Vector3 help_point()
	{
		return this.item_Find_Material.This_collider.bounds.center;
	}

	// Token: 0x06000330 RID: 816 RVA: 0x00010185 File Offset: 0x0000E385
	public virtual void Add_Component_Set(Enums_Localization.Items_E item_Name_v = Enums_Localization.Items_E.VOID)
	{
		this.item_Name_Group = item_Name_v;
		this.item_Find_Material = base.gameObject.AddComponent<Item_Find_Material>();
		this.item_Find_Material.Add_Component_Set();
	}

	// Token: 0x06000331 RID: 817 RVA: 0x000101AA File Offset: 0x0000E3AA
	public bool Return_Test_Item_Find()
	{
		return this.item_Find_Material.Return_Find_Complite();
	}

	// Token: 0x06000332 RID: 818 RVA: 0x000101B7 File Offset: 0x0000E3B7
	public void Start_Find_Item()
	{
		this.item_Find_Material.start_item_find();
	}

	// Token: 0x06000333 RID: 819 RVA: 0x000101C4 File Offset: 0x0000E3C4
	public void Update_Find_Item()
	{
		this.item_Find_Material.Update_White_Color(30f);
	}

	// Token: 0x06000334 RID: 820 RVA: 0x000101D6 File Offset: 0x0000E3D6
	public void Item_find_complite()
	{
		Action<Enums_Localization.Items_E, Item_Main> find_Item = EA.Find_Item;
		if (find_Item != null)
		{
			find_Item(this.item_Name_Group, this);
		}
		this.item_Find_Material.Update_White_Color(30f);
		if (this.help_this_item_find)
		{
			Action help_end_item_find_complite = EA.Help_end_item_find_complite;
			if (help_end_item_find_complite == null)
			{
				return;
			}
			help_end_item_find_complite();
		}
	}

	// Token: 0x06000335 RID: 821 RVA: 0x00010216 File Offset: 0x0000E416
	public void item_load_complite()
	{
		this.item_Find_Material.Load_White_Color();
	}

	// Token: 0x06000336 RID: 822 RVA: 0x00010223 File Offset: 0x0000E423
	public Enums_Localization.Items_E Return_Group_Name()
	{
		return this.item_Name_Group;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x0001022B File Offset: 0x0000E42B
	public void This_Item_Help()
	{
		this.help_this_item_find = true;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x00010234 File Offset: 0x0000E434
	public void Visible(bool value)
	{
		this.item_Find_Material.Visible(value);
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00010242 File Offset: 0x0000E442
	public void Collider_enabled(bool value)
	{
		this.item_Find_Material.Collider_enabled(value);
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00010250 File Offset: 0x0000E450
	public void IStart()
	{
	}

	// Token: 0x0600033B RID: 827 RVA: 0x00010252 File Offset: 0x0000E452
	public void IClick()
	{
		this.Item_find_complite();
	}

	// Token: 0x0600033C RID: 828 RVA: 0x0001025A File Offset: 0x0000E45A
	public void Test_Color(Color color_value)
	{
		this.item_Find_Material.Test_Color(color_value);
	}

	// Token: 0x040003EC RID: 1004
	[SerializeField]
	protected Enums_Localization.Items_E item_Name_Group;

	// Token: 0x040003ED RID: 1005
	[SerializeField]
	protected Item_Find_Material item_Find_Material;

	// Token: 0x040003EE RID: 1006
	[SerializeField]
	protected bool help_this_item_find;
}
