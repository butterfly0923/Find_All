using System;
using UnityEngine;

// Token: 0x0200009E RID: 158
[CreateAssetMenu(fileName = "Scenes_Data", menuName = "ScriptableObject/Scenes_Data", order = 112)]
public class Scenes_Data : ScriptableObject
{
	// Token: 0x0600046A RID: 1130 RVA: 0x00014F90 File Offset: 0x00013190
	public string RT_name_scene(int index_value)
	{
		string result = "";
		for (int i = 0; i < this.scene_index_name.Length; i++)
		{
			if (this.scene_index_name[i].index == index_value)
			{
				result = this.scene_index_name[i].name;
				break;
			}
		}
		return result;
	}

	// Token: 0x040004A3 RID: 1187
	[SerializeField]
	private Scenes_Data.Scene_index_name[] scene_index_name;

	// Token: 0x020001E5 RID: 485
	[Serializable]
	public struct Scene_index_name
	{
		// Token: 0x04000A4B RID: 2635
		public int index;

		// Token: 0x04000A4C RID: 2636
		public string name;
	}
}
