using System;

// Token: 0x0200007B RID: 123
public class Item_Main_Spine : Item_Main
{
	// Token: 0x0600033E RID: 830 RVA: 0x00010270 File Offset: 0x0000E470
	public override void Add_Component_Set(Enums_Localization.Items_E item_Name_v = Enums_Localization.Items_E.VOID)
	{
		this.item_Name_Group = item_Name_v;
		if (base.gameObject.GetComponent<Item_Find_Material_Spine>() == null)
		{
			this.item_Find_Material = base.gameObject.AddComponent<Item_Find_Material_Spine>();
		}
		this.item_Find_Material = base.gameObject.GetComponent<Item_Find_Material_Spine>();
		this.item_Find_Material.Add_Component_Set();
	}
}
