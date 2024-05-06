using UnityEngine;

namespace Assets.Scripts.Utils
{
	public static class Utils
	{
		public static Vector3 GetRandomPoint(float quadSize)
		{
			float x = Random.Range(-quadSize / 2, quadSize * 2);
			float y = Random.Range(-quadSize / 2, quadSize * 2);

			return new Vector3(x, y, 0);
		}
	}
}
