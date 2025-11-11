using System;
using Unity.VisualScripting;
using UnityEngine;

// Token: 0x020000B5 RID: 181
public abstract class Set_Singleton
{
	// Token: 0x06000511 RID: 1297 RVA: 0x000185DE File Offset: 0x000167DE
	public static object Another<T, Y>(T script_value, Y st_value) where T : MonoBehaviour
	{
		if (st_value != null)
		{
			Object.Destroy(script_value.gameObject);
		}
		return script_value;
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x000185FE File Offset: 0x000167FE
	public static object This<T, Y>(T script_value, Y st_value) where T : MonoBehaviour where Y : Object
	{
		if (st_value != null)
		{
			Object.Destroy(st_value.GameObject());
		}
		return script_value;
	}
}
