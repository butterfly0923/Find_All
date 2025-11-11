using System;
using Spine.Unity;
using UnityEngine;

// Token: 0x0200006F RID: 111
public class Event_spine_add_animation : MonoBehaviour
{
	// Token: 0x060002E6 RID: 742 RVA: 0x0000E844 File Offset: 0x0000CA44
	[ContextMenu("Spine_animation_next")]
	public void Spine_animation_next()
	{
		if (base.GetComponent<SkeletonAnimation>() != null)
		{
			this.this_SkeletonAnimation = base.GetComponent<SkeletonAnimation>();
			this.this_SkeletonAnimation.AnimationState.AddAnimation(0, this.animation_next, true, 0f);
			this.this_SkeletonAnimation.timeScale = 1f;
		}
	}

	// Token: 0x040003B1 RID: 945
	[SerializeField]
	private SkeletonAnimation this_SkeletonAnimation;

	// Token: 0x040003B2 RID: 946
	[SpineAnimation("", "", true, false)]
	public string animation_next;
}
