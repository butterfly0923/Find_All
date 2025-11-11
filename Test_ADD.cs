using System;

// Token: 0x0200003F RID: 63
public class Test_ADD
{
	// Token: 0x060001A7 RID: 423 RVA: 0x0000978C File Offset: 0x0000798C
	public float Plus_1_Int()
	{
		return this.add_one_value();
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00009794 File Offset: 0x00007994
	private float add_one_value()
	{
		this.float_value += this.Plus_Value;
		return this.float_value;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x000097AF File Offset: 0x000079AF
	public void PPPPPlus_value(float F)
	{
		this.Plus_Value += F;
	}

	// Token: 0x040001BB RID: 443
	private float float_value;

	// Token: 0x040001BC RID: 444
	private float Plus_Value = 1f;
}
