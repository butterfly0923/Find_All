using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
public class Layer_distance_multiply : MonoBehaviour
{
	// Token: 0x06000255 RID: 597 RVA: 0x0000C827 File Offset: 0x0000AA27
	[ContextMenu("Search_child")]
	public void Search_childs()
	{
		this.sprite_renderers_child = base.GetComponentsInChildren<SpriteRenderer>();
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0000C838 File Offset: 0x0000AA38
	[ContextMenu("Update_position_z")]
	public void Update_position_z()
	{
		if (this.sprite_renderers_child.Length != 0)
		{
			for (int i = 0; i < this.sprite_renderers_child.Length; i++)
			{
				this.sprite_renderers_child[i].transform.localPosition = new Vector3(this.sprite_renderers_child[i].transform.localPosition.x, this.sprite_renderers_child[i].transform.localPosition.y, (float)this.sprite_renderers_child[i].sortingOrder * this.Multiply_layer_position_z);
			}
		}
	}

	// Token: 0x040002D1 RID: 721
	[Header("Множитель относительно слоя:")]
	[SerializeField]
	[Range(-1f, 1f)]
	private float Multiply_layer_position_z;

	// Token: 0x040002D2 RID: 722
	[Header("Список всех объектов спрайт рендерера:")]
	[SerializeField]
	private SpriteRenderer[] sprite_renderers_child;
}
