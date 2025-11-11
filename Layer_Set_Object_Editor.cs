using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
public class Layer_Set_Object_Editor : MonoBehaviour
{
	// Token: 0x040002D3 RID: 723
	[SerializeField]
	private int min_layer;

	// Token: 0x040002D4 RID: 724
	[SerializeField]
	private int max_layer;

	// Token: 0x040002D5 RID: 725
	[SerializeField]
	private bool Gizmos_ON_OFF = true;

	// Token: 0x040002D6 RID: 726
	[SerializeField]
	private bool Set_layers;

	// Token: 0x040002D7 RID: 727
	[SerializeField]
	private bool Not_child_set;

	// Token: 0x040002D8 RID: 728
	[SerializeField]
	private bool Update_layers;

	// Token: 0x040002D9 RID: 729
	[Range(-50f, 50f)]
	[SerializeField]
	private int layer_correct;

	// Token: 0x040002DA RID: 730
	[SerializeField]
	private bool x_10;

	// Token: 0x040002DB RID: 731
	[SerializeField]
	private bool check_update_all_layer;

	// Token: 0x040002DC RID: 732
	[SerializeField]
	private bool update_all_layer;

	// Token: 0x040002DD RID: 733
	[SerializeField]
	private bool false_count;

	// Token: 0x040002DE RID: 734
	[SerializeField]
	private bool false_frame;

	// Token: 0x040002DF RID: 735
	[SerializeField]
	private bool circle;

	// Token: 0x040002E0 RID: 736
	[SerializeField]
	private bool set_color_all;

	// Token: 0x040002E1 RID: 737
	[SerializeField]
	private Color color_all;

	// Token: 0x040002E2 RID: 738
	[SerializeField]
	private bool name_visible;

	// Token: 0x040002E3 RID: 739
	[SerializeField]
	private bool individual_size_text;

	// Token: 0x040002E4 RID: 740
	[SerializeField]
	private int size_text;

	// Token: 0x040002E5 RID: 741
	[SerializeField]
	private bool set_item_random_color;

	// Token: 0x040002E6 RID: 742
	[SerializeField]
	private bool visual_only_select;
}
