using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pixyz.ImportSDK
{
	public static partial class Conversions
	{
		#region Point <> Vector

		public static Native.Geom.Point4 ToPoint4(this Vector4 point)
		{
			return new Native.Geom.Point4() { x = (double)point.x, y = (double)point.y, z = (double)point.z, w = (double)point.w };
		}

		public static Native.Geom.Point3 ToPoint3(this Vector3 point)
		{
			return new Native.Geom.Point3() { x = (double)point.x, y = (double)point.y, z = (double)point.z };
		}

		public static Native.Geom.Point3 ToPoint2(this Vector2 point)
		{
			return new Native.Geom.Point3() { x = (double)point.x, y = (double)point.y };
		}

		public static Vector4 ToVector3(this Native.Geom.Point4 point)
		{
			return new Vector4((float)point.x, (float)point.y, (float)point.z, (float)point.w);
		}

		public static Vector3 ToVector3(this Native.Geom.Point3 point)
		{
			return new Vector3((float)point.x, (float)point.y, (float)point.z);
		}

		public static Vector2 ToVector2(this Native.Geom.Point2 point)
		{
			return new Vector2((float)point.x, (float)point.y);
		}

		#endregion

		#region Matrix4 <> Matrix4x4
		public static Native.Geom.Matrix4 ConvertMatrix(Matrix4x4 matrix4x4)
		{
			var matrix4 = new Native.Geom.Matrix4();
			matrix4.tab = new Native.Geom.Array4[4];
			matrix4[0] = new Native.Geom.Array4();
			matrix4[0][0] = matrix4x4.m00;
			matrix4[0][1] = matrix4x4.m01;
			matrix4[0][2] = matrix4x4.m02;
			matrix4[0][3] = matrix4x4.m03;
			matrix4[1] = new Native.Geom.Array4();
			matrix4[1][0] = matrix4x4.m10;
			matrix4[1][1] = matrix4x4.m11;
			matrix4[1][2] = matrix4x4.m12;
			matrix4[1][3] = matrix4x4.m13;
			matrix4[2] = new Native.Geom.Array4();
			matrix4[2][0] = matrix4x4.m20;
			matrix4[2][1] = matrix4x4.m21;
			matrix4[2][2] = matrix4x4.m22;
			matrix4[2][3] = matrix4x4.m23;
			matrix4[3] = new Native.Geom.Array4();
			matrix4[3][0] = matrix4x4.m30;
			matrix4[3][1] = matrix4x4.m31;
			matrix4[3][2] = matrix4x4.m32;
			matrix4[3][3] = matrix4x4.m33;
			return matrix4;
		}

		public static Matrix4x4 ConvertMatrix(Native.Geom.Matrix4 matrix4)
		{
			var matrix4x4 = new Matrix4x4();
			matrix4x4.m00 = (float)matrix4[0][0];
			matrix4x4.m01 = (float)matrix4[0][1];
			matrix4x4.m02 = (float)matrix4[0][2];
			matrix4x4.m03 = (float)matrix4[0][3];
			matrix4x4.m10 = (float)matrix4[1][0];
			matrix4x4.m11 = (float)matrix4[1][1];
			matrix4x4.m12 = (float)matrix4[1][2];
			matrix4x4.m13 = (float)matrix4[1][3];
			matrix4x4.m20 = (float)matrix4[2][0];
			matrix4x4.m21 = (float)matrix4[2][1];
			matrix4x4.m22 = (float)matrix4[2][2];
			matrix4x4.m23 = (float)matrix4[2][3];
			matrix4x4.m30 = (float)matrix4[3][0];
			matrix4x4.m31 = (float)matrix4[3][1];
			matrix4x4.m32 = (float)matrix4[3][2];
			matrix4x4.m33 = (float)matrix4[3][3];

			return matrix4x4;
		}

		public static Native.Geom.Matrix4List ConvertMatrices(IList<Matrix4x4> matrices)
		{
			var matrix4List = new Native.Geom.Matrix4List(matrices.Count);
			for (int i = 0; i < matrices.Count; i++)
			{
				matrix4List[i] = ConvertMatrix(matrices[i]);
			}
			return matrix4List;
		}

		public static IList<Matrix4x4> ConvertMatrices(Native.Geom.Matrix4List matrices)
		{
			var matrix4x4List = new List<Matrix4x4>();
			for (int i = 0; i < matrices.length; i++)
			{
				matrix4x4List.Add(ConvertMatrix(matrices[i]));
			}
			return matrix4x4List;
		}

		public static Native.Geom.Matrix4 Identity()
		{
			Native.Geom.Matrix4 mat = new Native.Geom.Matrix4();

			mat.tab = new Native.Geom.Array4[4];
			mat.tab[0] = new Native.Geom.Array4(new double[] { 1.0, 0.0, 0.0, 0.0 });
			mat.tab[1] = new Native.Geom.Array4(new double[] { 0.0, 1.0, 0.0, 0.0 });
			mat.tab[2] = new Native.Geom.Array4(new double[] { 0.0, 0.0, 1.0, 0.0 });
			mat.tab[3] = new Native.Geom.Array4(new double[] { 0.0, 0.0, 0.0, 1.0 });

			return mat;
		}
		#endregion

		#region ColorPixyz <> ColorUnity

		public static Native.Core.Color ToPiXYZColor(this Color colorU)
		{
			return new Native.Core.Color() { r = colorU.r, g = colorU.g, b = colorU.b };
		}

		public static Color ToUnityColor(this Native.Core.Color color)
		{
			return new Color() { r = (float)color.r, g = (float)color.g, b = (float)color.b };
		}

		public static Native.Core.ColorAlpha ToPiXYZColorAlpha(this Color colorU)
		{
			return new Native.Core.ColorAlpha() { r = colorU.r, g = colorU.g, b = colorU.b, a = colorU.a };
		}

		public static Color ToUnityColor(this Native.Core.ColorAlpha color)
		{
			return new Color() { r = (float)color.r, g = (float)color.g, b = (float)color.b, a = (float)color.a };
		}
		#endregion

		#region TimePixyz <> TimeUnity

		public static DateTime ToUnityTime(this Native.Core.Date date)
		{
			return new DateTime(date.year, date.month, date.day);
		}

		public static Native.Core.Date ToPixyzTime(this DateTime date)
		{
			return new Native.Core.Date() { year = date.Year, month = date.Month, day = date.Day };
		}

		#endregion
	}
}