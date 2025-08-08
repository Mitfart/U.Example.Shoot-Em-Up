using UnityEngine;

namespace Extensions.Component {
   public static class OnOffExt {
      public static void On(this  Behaviour behaviour) => behaviour.enabled = true;
      public static void Off(this Behaviour behaviour) => behaviour.enabled = false;
   }
}