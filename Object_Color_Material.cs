using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class Object_Color_Material : MonoBehaviour
{
	// Token: 0x06000077 RID: 119 RVA: 0x000038D0 File Offset: 0x00001AD0
	public void Add_Component_Setup()
	{
		if (base.GetComponent<SpriteRenderer>() != null)
		{
			this.this_SpriteRenderer = base.GetComponent<SpriteRenderer>();
			this.material_main = new Material(Level_Data.st.Materials_level.Return_Material(this.this_SpriteRenderer.sprite.texture));
			this.this_SpriteRenderer.material = this.material_main;
			this.material_main = this.this_SpriteRenderer.material;
			this.material_main.SetFloat("Color_Alpha_Sc", -10f);
		}
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00003958 File Offset: 0x00001B58
	public void Load_White_Color()
	{
		if (!this.color_flag)
		{
			this.material_main.SetFloat("Color_Alpha_Sc", this.Max_Color_Shader);
			this.color_flag = true;
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x0000397F File Offset: 0x00001B7F
	public void Update_White_Color(float value = 30f)
	{
		if (this.coroutine != null && !this.color_flag)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_White_Color(value));
	}

	// Token: 0x0600007A RID: 122 RVA: 0x000039B0 File Offset: 0x00001BB0
	private IEnumerator IE_White_Color(float value)
	{
		if (!this.color_flag)
		{
			bool color_end = false;
			float value_color = this.Min_White_Shader;
			while (!color_end)
			{
				value_color += value * Time.deltaTime;
				this.material_main.SetFloat("Color_Alpha_Sc", value_color);
				if (value_color >= this.Max_Color_Shader)
				{
					color_end = true;
				}
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
		yield break;
	}

	// Token: 0x0600007B RID: 123 RVA: 0x000039C6 File Offset: 0x00001BC6
	public void Re_test_color()
	{
		Debug.Log("Всё сбросилось " + base.gameObject.name);
		this.material_main.SetFloat("Color_Alpha_Sc", this.Min_White_Shader);
		this.color_flag = false;
	}

	// Token: 0x0400008A RID: 138
	[SerializeField]
	private Material material_main;

	// Token: 0x0400008B RID: 139
	private bool color_flag;

	// Token: 0x0400008C RID: 140
	private SpriteRenderer this_SpriteRenderer;

	// Token: 0x0400008D RID: 141
	private Coroutine coroutine;

	// Token: 0x0400008E RID: 142
	private float Min_White_Shader = -10f;

	// Token: 0x0400008F RID: 143
	private float Max_Color_Shader = 10f;
}
