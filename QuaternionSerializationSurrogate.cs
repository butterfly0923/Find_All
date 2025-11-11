using System;
using System.Runtime.Serialization;
using UnityEngine;

// Token: 0x020000AC RID: 172
public class QuaternionSerializationSurrogate : ISerializationSurrogate
{
	// Token: 0x060004DA RID: 1242 RVA: 0x000174C8 File Offset: 0x000156C8
	public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
	{
		Quaternion quaternion = (Quaternion)obj;
		info.AddValue("x", quaternion.x);
		info.AddValue("y", quaternion.y);
		info.AddValue("z", quaternion.z);
		info.AddValue("w", quaternion.w);
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x00017520 File Offset: 0x00015720
	public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
	{
		Quaternion quaternion = (Quaternion)obj;
		quaternion.x = (float)info.GetValue("x", typeof(float));
		quaternion.y = (float)info.GetValue("y", typeof(float));
		quaternion.z = (float)info.GetValue("z", typeof(float));
		quaternion.w = (float)info.GetValue("w", typeof(float));
		obj = quaternion;
		return quaternion;
	}
}
