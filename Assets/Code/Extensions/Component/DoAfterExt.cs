using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Extensions.Component {
   public static class DoAfterExt {
      public static Coroutine DoAfter(this MonoBehaviour behaviour, Action action, float     duration) => behaviour.StartCoroutine(DoAfterRoutine(action, duration));
      public static Coroutine DoAfter(this MonoBehaviour behaviour, Action action, Coroutine routine) => behaviour.StartCoroutine(DoAfterRoutine(action, routine));
      
      
      public static async Task DoAfterAsync<T>(this T obj, Action<T> action, float duration)
      {
         await Awaitable.WaitForSecondsAsync(duration);
         action.Invoke(obj);
      }

      public static async Task DoAfterAsync<T>(this T obj, Action<T> action, Task task)
      {
         await task;
         action.Invoke(obj);
      }


      private static IEnumerator DoAfterRoutine(Action action, float duration) {
         yield return new WaitForSeconds(duration);

         action?.Invoke();
      }

      private static IEnumerator DoAfterRoutine(Action action, Coroutine duration) {
         yield return duration;

         action?.Invoke();
      }
   }
}