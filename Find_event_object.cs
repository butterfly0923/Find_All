using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

// Token: 0x02000073 RID: 115
public class Find_event_object : MonoBehaviour
{
	// Token: 0x06000303 RID: 771 RVA: 0x0000F5DC File Offset: 0x0000D7DC
	public void Add_Component_Setup()
	{
		if (base.GetComponent<SpriteRenderer>() != null)
		{
			this.this_SpriteRenderer = base.GetComponent<SpriteRenderer>();
			this.material_main = new Material(Level_Data.st.Materials_level.Return_Material(this.this_SpriteRenderer.sprite.texture));
			this.this_SpriteRenderer.material = this.material_main;
			this.material_main = this.this_SpriteRenderer.material;
			this.material_main.SetFloat("Color_Alpha_Sc", -10f);
			return;
		}
		if (base.GetComponent<MeshRenderer>() != null)
		{
			this.this_MeshRenderer = base.GetComponent<MeshRenderer>();
			this.material_base = this.this_MeshRenderer.material;
			this.material_main = new Material(this.this_MeshRenderer.material);
			this.material_main.SetFloat("Color_Alpha_Sc", -10f);
			this.this_MeshRenderer.material = this.material_main;
			if (base.GetComponent<SkeletonAnimation>() != null)
			{
				this.this_SkeletonAnimation = base.GetComponent<SkeletonAnimation>();
				this.this_SkeletonAnimation.timeScale = 0f;
			}
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x0000F6FC File Offset: 0x0000D8FC
	public void Load_White_Color()
	{
		if (this.this_SpriteRenderer != null || this.this_MeshRenderer != null)
		{
			if (!this.color_flag)
			{
				this.material_main.SetFloat("Color_Alpha_Sc", this.Max_Color_Shader);
				if (this.this_SkeletonAnimation != null)
				{
					if (!this.spine_animation_end)
					{
						this.Spine_animation_start(30f);
					}
					else
					{
						float duration = this.this_SkeletonAnimation.Skeleton.Data.FindAnimation(this.animation_start).Duration;
						Debug.Log("Персонаж " + base.gameObject.name + " - завершил свою анимацию и отправляется в безнду", this);
						this.this_SkeletonAnimation.AnimationState.SetAnimation(0, this.animation_start, false);
						this.this_SkeletonAnimation.AnimationState.GetCurrent(0).TrackTime = duration - 0.1f;
					}
				}
				this.color_flag = true;
			}
			if (this.this_MeshRenderer != null)
			{
				this.this_MeshRenderer.material = Level_Data.st.Materials_Spine_level.Return_Material(this.material_base);
			}
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x0000F81B File Offset: 0x0000DA1B
	[ContextMenu("Update_White_Color")]
	public void Update_test()
	{
		this.Update_White_Color(30f);
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0000F828 File Offset: 0x0000DA28
	public void Update_White_Color(float value = 30f)
	{
		if (this.this_SpriteRenderer != null || this.this_MeshRenderer != null)
		{
			this.Spine_animation_start(value);
			if (this.coroutine != null && !this.color_flag)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_White_Color(value));
			if (this.this_MeshRenderer != null)
			{
				base.StartCoroutine(this.IE_Delay_Material_Update(value));
			}
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
	public void Spine_animation_start(float value = 30f)
	{
		if (this.this_SkeletonAnimation != null)
		{
			this.this_SkeletonAnimation.timeScale = 1f;
			if (this.spine_set)
			{
				this.this_SkeletonAnimation.AnimationState.SetAnimation(0, this.animation_start, false);
				if (!this.spine_animation_end)
				{
					this.this_SkeletonAnimation.AnimationState.AddAnimation(0, this.animation_main, true, 0f);
				}
			}
		}
	}

	// Token: 0x06000308 RID: 776 RVA: 0x0000F916 File Offset: 0x0000DB16
	private IEnumerator IE_Delay_Material_Update(float value)
	{
		float value_delay = -10f;
		while (value_delay <= 10f)
		{
			value_delay += value * Time.deltaTime;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield return new WaitForSeconds(Time.deltaTime);
		this.this_MeshRenderer.material = Level_Data.st.Materials_Spine_level.Return_Material(this.material_base);
		yield break;
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0000F92C File Offset: 0x0000DB2C
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

	// Token: 0x0600030A RID: 778 RVA: 0x0000F944 File Offset: 0x0000DB44
	public void Re_test_color()
	{
		if (base.GetComponent<SpriteRenderer>() != null || base.GetComponent<MeshRenderer>() != null)
		{
			Debug.Log("Всё сбросилось " + base.gameObject.name, base.gameObject);
			this.material_main.SetFloat("Color_Alpha_Sc", this.Min_White_Shader);
			this.color_flag = false;
		}
	}

	// Token: 0x040003C6 RID: 966
	[SerializeField]
	private Material material_main;

	// Token: 0x040003C7 RID: 967
	[SerializeField]
	private Material material_base;

	// Token: 0x040003C8 RID: 968
	[SerializeField]
	private Material[] materials_main;

	// Token: 0x040003C9 RID: 969
	private bool color_flag;

	// Token: 0x040003CA RID: 970
	[SerializeField]
	private SpriteRenderer this_SpriteRenderer;

	// Token: 0x040003CB RID: 971
	[SerializeField]
	private MeshRenderer this_MeshRenderer;

	// Token: 0x040003CC RID: 972
	[SerializeField]
	private SkeletonAnimation this_SkeletonAnimation;

	// Token: 0x040003CD RID: 973
	[SpineAnimation("", "", true, false)]
	public string animation_start;

	// Token: 0x040003CE RID: 974
	[SpineAnimation("", "", true, false)]
	public string animation_main;

	// Token: 0x040003CF RID: 975
	[SerializeField]
	private bool spine_set;

	// Token: 0x040003D0 RID: 976
	[SerializeField]
	private bool spine_animation_end;

	// Token: 0x040003D1 RID: 977
	private Coroutine coroutine;

	// Token: 0x040003D2 RID: 978
	private float Min_White_Shader = -10f;

	// Token: 0x040003D3 RID: 979
	private float Max_Color_Shader = 10f;
}
