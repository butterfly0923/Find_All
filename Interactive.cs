using System;
using UnityEngine;

// Token: 0x0200007C RID: 124
public class Interactive : MonoBehaviour
{
	// Token: 0x06000340 RID: 832 RVA: 0x000102CC File Offset: 0x0000E4CC
	public virtual void Set(Stady_Find stady_value, int index_value, bool load_status_value, bool first_status_value = false)
	{
		this.stady_find = stady_value;
		this.index = index_value;
		if (!first_status_value)
		{
			this.current_status = this.open_start;
			return;
		}
		this.current_status = load_status_value;
		this.used = true;
	}

	// Token: 0x06000341 RID: 833 RVA: 0x000102FB File Offset: 0x0000E4FB
	public virtual void Click_Collider_object(GameObject value)
	{
	}

	// Token: 0x06000342 RID: 834 RVA: 0x000102FD File Offset: 0x0000E4FD
	public virtual bool Check_click()
	{
		return true;
	}

	// Token: 0x06000343 RID: 835 RVA: 0x00010300 File Offset: 0x0000E500
	protected void Update_data()
	{
		Debug.Log("VAR");
		this.stady_find.update_data_interactive(this.index, this.current_status);
	}

	// Token: 0x040003EF RID: 1007
	[SerializeField]
	protected bool open_start;

	// Token: 0x040003F0 RID: 1008
	[SerializeField]
	protected bool current_status;

	// Token: 0x040003F1 RID: 1009
	[SerializeField]
	protected int index;

	// Token: 0x040003F2 RID: 1010
	[SerializeField]
	public bool used;

	// Token: 0x040003F3 RID: 1011
	protected Stady_Find stady_find;
}
