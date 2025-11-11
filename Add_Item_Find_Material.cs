using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000076 RID: 118
public class Add_Item_Find_Material : MonoBehaviour
{
	// Token: 0x06000312 RID: 786 RVA: 0x0000FA14 File Offset: 0x0000DC14
	public virtual void Add_Component_Setup()
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

	// Token: 0x06000313 RID: 787 RVA: 0x0000FA9C File Offset: 0x0000DC9C
	public void White_Color_start()
	{
		if (!this.color_flag)
		{
			if (this.material_main == null)
			{
				Debug.Log("material_main.SetFloat(Color_Alpha_Sc, Max_Color_Shader)", this);
			}
			this.material_main.SetFloat("Color_Alpha_Sc", this.Max_Color_Shader);
			this.color_flag = true;
		}
	}

	// Token: 0x06000314 RID: 788 RVA: 0x0000FADC File Offset: 0x0000DCDC
	public void Update_White_Color(float value = 30f)
	{
		Debug.Log("начато закрашивание дополнительно объекта", this);
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.White_Color_cor(value));
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0000FB10 File Offset: 0x0000DD10
	private IEnumerator White_Color_cor(float value)
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
		yield break;
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0000FB26 File Offset: 0x0000DD26
	public virtual void Visible(bool value)
	{
		this.this_SpriteRenderer.enabled = value;
	}

	// Token: 0x040003D9 RID: 985
	[SerializeField]
	protected Material material_main;

	// Token: 0x040003DA RID: 986
	private bool color_flag;

	// Token: 0x040003DB RID: 987
	private SpriteRenderer this_SpriteRenderer;

	// Token: 0x040003DC RID: 988
	private Coroutine coroutine;

	// Token: 0x040003DD RID: 989
	private float Min_White_Shader = -10f;

	// Token: 0x040003DE RID: 990
	private float Max_Color_Shader = 10f;
}
