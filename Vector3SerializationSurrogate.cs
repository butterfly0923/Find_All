using System;
using System.Runtime.Serialization;
using UnityEngine;

// Token: 0x020000AD RID: 173
public class Vector3SerializationSurrogate : ISerializationSurrogate
{
	// Token: 0x060004DD RID: 1245 RVA: 0x000175D0 File Offset: 0x000157D0
	public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
	{
		Vector3 vector = (Vector3)obj;
		info.AddValue("x", vector.x);
		info.AddValue("y", vector.y);
		info.AddValue("z", vector.z);
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x00017618 File Offset: 0x00015818
	public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
	{
		Vector3 vector = (Vector3)obj;
		vector.x = (float)info.GetValue("x", typeof(float));
		vector.y = (float)info.GetValue("y", typeof(float));
		vector.z = (float)info.GetValue("z", typeof(float));
		obj = vector;
		return vector;
	}
}
