using System;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class Item_Groups_Manager : MonoBehaviour
{
	// Token: 0x0600007D RID: 125 RVA: 0x00003A20 File Offset: 0x00001C20
	public void Test_Material_Setup()
	{
		for (int i = 0; i < this.Items_Go.Length; i++)
		{
			this.Items_Go[i].AddComponent<Item_Main>().Add_Component_Set(Enums_Localization.Items_E.VOID);
		}
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00003A53 File Offset: 0x00001C53
	private void Start()
	{
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00003A55 File Offset: 0x00001C55
	private void Update()
	{
	}

	// Token: 0x04000090 RID: 144
	[SerializeField]
	private Materials_SO materials_SO;

	// Token: 0x04000091 RID: 145
	[SerializeField]
	private GameObject[] Items_Go;
}
