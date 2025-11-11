using System;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

// Token: 0x02000079 RID: 121
public class Item_Find_Material_Spine : Item_Find_Material
{
	// Token: 0x0600032A RID: 810 RVA: 0x0000FFD4 File Offset: 0x0000E1D4
	public override void Add_Component_Set()
	{
		if (base.GetComponent<MeshRenderer>() != null)
		{
			this.this_MeshRenderer = base.GetComponent<MeshRenderer>();
			this.material_main = new Material(this.this_MeshRenderer.material);
			this.material_main.SetFloat("Color_Alpha_Sc", -10f);
			this.this_MeshRenderer.material = this.material_main;
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
		if (base.transform.childCount > 0 && base.GetComponent<SkeletonPartsRenderer>() != null)
		{
			this.Add_Items = true;
			this.Child_Add_Item = new List<Add_Item_Find_Material>();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				this.Child_Add_Item.Add(base.transform.GetChild(i).gameObject.AddComponent<Add_Item_Find_Material_Spine>());
			}
			base.Set_Child_Component();
		}
	}

	// Token: 0x0600032B RID: 811 RVA: 0x000100E5 File Offset: 0x0000E2E5
	public void Destroy_collider()
	{
		if (base.gameObject.GetComponent<Collider>() != null)
		{
			Object.Destroy(base.gameObject.GetComponent<Collider>());
		}
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0001010A File Offset: 0x0000E30A
	public override void Visible(bool value)
	{
		if (!this.color_flag)
		{
			this.this_collider.enabled = value;
		}
		this.this_MeshRenderer.enabled = value;
	}

	// Token: 0x0600032D RID: 813 RVA: 0x0001012C File Offset: 0x0000E32C
	public override void start_item_find()
	{
		if (!this.color_flag)
		{
			this.start_find = true;
			if (this.this_MeshRenderer.enabled)
			{
				this.this_collider.enabled = true;
			}
		}
	}

	// Token: 0x040003EB RID: 1003
	[SerializeField]
	private MeshRenderer this_MeshRenderer;
}
