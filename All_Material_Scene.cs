using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class All_Material_Scene : MonoBehaviour
{
	// Token: 0x06000016 RID: 22 RVA: 0x0000243E File Offset: 0x0000063E
	private void Awake()
	{
		if (All_Material_Scene.st != null)
		{
			Object.Destroy(All_Material_Scene.st.gameObject);
		}
		All_Material_Scene.st = this;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002462 File Offset: 0x00000662
	public void Add_Material(Material material_value)
	{
		this.Materials_all_go.Add(material_value);
		this.Update_start_while();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002478 File Offset: 0x00000678
	private void Update_start_while()
	{
		for (int i = 0; i < this.Materials_all_go.Count; i++)
		{
			this.Materials_all_go[i].SetColor("Colos_Test_Sc", this.color_add);
		}
	}

	// Token: 0x0400000F RID: 15
	[SerializeField]
	private List<Material> Materials_all_go;

	// Token: 0x04000010 RID: 16
	[SerializeField]
	private Color color_add;

	// Token: 0x04000011 RID: 17
	public static All_Material_Scene st;
}
