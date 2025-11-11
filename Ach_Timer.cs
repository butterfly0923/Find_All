using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
public class Ach_Timer : MonoBehaviour
{
	// Token: 0x060001C8 RID: 456 RVA: 0x00009D95 File Offset: 0x00007F95
	public void Ach_use_Timer()
	{
		if (SL_Data.d_Setting.Timer_On)
		{
			Achievement_manager.st.Achievement_complite("Ach_Timer");
		}
	}
}
