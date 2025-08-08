using UnityEngine;

namespace Extensions.Transform
{
   public static class Rotate2DExt {
      private static Vector3 ZAxis => Vector3.forward;



      public static UnityEngine.Transform Rotate2D(this UnityEngine.Transform transform, float by, bool faceTop = false) {
         transform.Rotate(ZAxis, by + (faceTop ? -90f : 0f));
         return transform;
      }

      public static GameObject Rotate2D(this GameObject go, float by, bool faceTop = false) {
         go.transform.Rotate2D(by, faceTop);
         return go;
      }

      public static TComp Rotate2D<TComp>(this TComp comp, float by, bool faceTop = false) where TComp : UnityEngine.Component {
         comp.transform.Rotate2D(by, faceTop);
         return comp;
      }



      public static UnityEngine.Transform Rotate2D(this UnityEngine.Transform transform, Vector2 at, bool faceTop = false)
      {
         var dir = transform.InverseTransformPoint(at);
         var angle = AngleOf(dir);
         transform.Rotate2D(angle, faceTop);
         return transform;
      }

      public static GameObject Rotate2D(this GameObject go, Vector2 at, bool faceTop = false) {
         go.transform.Rotate2D(at, faceTop);
         return go;
      }
      
      public static TComp Rotate2D<TComp>(this TComp comp, Vector2 at, bool faceTop = false) where TComp : UnityEngine.Component {
         comp.transform.Rotate2D(at, faceTop);
         return comp;
      }

      
      private static float AngleOf(Vector2 dir) => Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
   }
}