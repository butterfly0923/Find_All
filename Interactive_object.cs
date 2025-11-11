using System;
using UnityEngine;

// Token: 0x02000080 RID: 128
public class Interactive_object : MonoBehaviour, Iinteractive, ICursorReaction
{
	// Token: 0x06000359 RID: 857 RVA: 0x000107ED File Offset: 0x0000E9ED
	public void set_parent(Interactive value)
	{
		this.interactive = value;
	}

	// Token: 0x0600035A RID: 858 RVA: 0x000107F6 File Offset: 0x0000E9F6
	public void IStart()
	{
	}

	// Token: 0x0600035B RID: 859 RVA: 0x000107F8 File Offset: 0x0000E9F8
	public void IClick()
	{
		this.interactive.Click_Collider_object(base.gameObject);
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0001080B File Offset: 0x0000EA0B
	public bool ICheck()
	{
		return this.interactive.Check_click();
	}

	// Token: 0x04000402 RID: 1026
	[SerializeField]
	private Interactive interactive;
}
