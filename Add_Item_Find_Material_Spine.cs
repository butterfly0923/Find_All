using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
public class Add_Item_Find_Material_Spine : Add_Item_Find_Material
{
	// Token: 0x06000318 RID: 792 RVA: 0x0000FB54 File Offset: 0x0000DD54
	public override void Add_Component_Setup()
	{
		if (base.GetComponent<MeshRenderer>() != null)
		{
			this.this_MeshRenderer = base.GetComponent<MeshRenderer>();
			this.material_main = new Material(this.this_MeshRenderer.material);
			this.material_main.SetFloat("Color_Alpha_Sc", -10f);
			this.this_MeshRenderer.material = this.material_main;
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0000FBB7 File Offset: 0x0000DDB7
	public override void Visible(bool value)
	{
		this.this_MeshRenderer.enabled = value;
	}

	// Token: 0x040003DF RID: 991
	private MeshRenderer this_MeshRenderer;
}
