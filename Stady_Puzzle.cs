using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
public class Stady_Puzzle : Stady_Main
{
	// Token: 0x060003D2 RID: 978 RVA: 0x000130AC File Offset: 0x000112AC
	private void Start()
	{
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x000130AE File Offset: 0x000112AE
	private void Update()
	{
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x000130B0 File Offset: 0x000112B0
	public override void Set_play(int level_value, int stady_value, int max_count_value)
	{
		Debug.Log("Set_play. Level - " + level_value.ToString() + ". Stady - " + stady_value.ToString());
		base.Set_data(level_value, stady_value);
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x000130DC File Offset: 0x000112DC
	[ContextMenu("Завершить стадию пазла")]
	public void Complite_puzzle_stady()
	{
		base.Complite_stady();
	}
}
