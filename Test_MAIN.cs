using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class Test_MAIN : MonoBehaviour
{
	// Token: 0x060001AB RID: 427 RVA: 0x000097D2 File Offset: 0x000079D2
	private void Start()
	{
		this.name_aaadddd = new Test_ADD();
		base.StartCoroutine(this.IE_test_cor());
	}

	// Token: 0x060001AC RID: 428 RVA: 0x000097EC File Offset: 0x000079EC
	private IEnumerator IE_test_cor()
	{
		for (;;)
		{
			yield return new WaitForSeconds(5f);
			this.name_aaadddd.PPPPPlus_value(Time.time);
			this.ttt += this.name_aaadddd.Plus_1_Int();
		}
		yield break;
	}

	// Token: 0x040001BD RID: 445
	private Test_ADD name_aaadddd;

	// Token: 0x040001BE RID: 446
	[SerializeField]
	private float ttt;
}
