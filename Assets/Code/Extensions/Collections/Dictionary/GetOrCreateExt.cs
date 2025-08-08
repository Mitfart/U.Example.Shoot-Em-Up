using System.Collections.Generic;

namespace Extensions.Collections.Dictionary
{
   public static class GetOrCreateExt {
      public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
      {
         dictionary.TryAdd(key, new TValue());

         return dictionary[key];
      }
   }
}