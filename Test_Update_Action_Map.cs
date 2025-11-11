using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Token: 0x02000064 RID: 100
public class Test_Update_Action_Map : MonoBehaviour
{
	// Token: 0x060002A8 RID: 680 RVA: 0x0000DBC2 File Offset: 0x0000BDC2
	public void Main_On()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Main, true);
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x0000DBD9 File Offset: 0x0000BDD9
	public void Add_On()
	{
		Sa_IS.Active_Input_map(Sa_IS.input_Main.Add, true);
	}

	// Token: 0x060002AA RID: 682 RVA: 0x0000DBF0 File Offset: 0x0000BDF0
	public void Re_Map()
	{
		Sa_IS.Re_Active_Input_map();
	}

	// Token: 0x060002AB RID: 683 RVA: 0x0000DBF7 File Offset: 0x0000BDF7
	private void key_1_t(InputAction.CallbackContext cc)
	{
		Debug.Log("Кнопка 1 нажимается");
	}

	// Token: 0x060002AC RID: 684 RVA: 0x0000DC03 File Offset: 0x0000BE03
	private void key_2_t(InputAction.CallbackContext cc)
	{
		Debug.Log("Кнопка 2 нажимается");
	}

	// Token: 0x060002AD RID: 685 RVA: 0x0000DC0F File Offset: 0x0000BE0F
	private void key_3_t(InputAction.CallbackContext cc)
	{
	}

	// Token: 0x04000377 RID: 887
	private InputAction key_1;

	// Token: 0x04000378 RID: 888
	private InputAction key_2;

	// Token: 0x04000379 RID: 889
	private InputAction key_3;
}
