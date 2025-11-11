using System;
using UnityEngine;

// Token: 0x0200005D RID: 93
public class Frame_Helper : MonoBehaviour
{
	// Token: 0x0600025C RID: 604 RVA: 0x0000C8DE File Offset: 0x0000AADE
	private void Awake()
	{
		Frame_Helper.st = (Frame_Helper)Set_Singleton.This<Frame_Helper, Frame_Helper>(this, Frame_Helper.st);
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0000C8F5 File Offset: 0x0000AAF5
	public ValueTuple<Transform, SpriteRenderer, SpriteRenderer> RT_data()
	{
		return new ValueTuple<Transform, SpriteRenderer, SpriteRenderer>(this.this_transform, this.Frame, this.Icon);
	}

	// Token: 0x040002E7 RID: 743
	[SerializeField]
	private Transform this_transform;

	// Token: 0x040002E8 RID: 744
	[SerializeField]
	private SpriteRenderer Frame;

	// Token: 0x040002E9 RID: 745
	[SerializeField]
	private SpriteRenderer Icon;

	// Token: 0x040002EA RID: 746
	public static Frame_Helper st;
}
