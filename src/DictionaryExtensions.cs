using System.Collections.Generic;

namespace YA.Common
{
    public static class DictionaryExtensions
    {
        ///<summary>Получает значение ключа из словаря без выбрасывания исключения KeyNotFoundException.</summary>
        ///<param name="dict">Исходный словарь.</param>
        ///<param name="key">Ключ, значение которого нужно получить.</param>
        ///<param name="defaultValue">Значение по-умолчанию, которое нужно вернуть, если ключ не найден.</param>
        ///<returns>Значение ключа.</returns>
        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dict, TK key, TV defaultValue = default)
        {
            return dict.TryGetValue(key, out TV value) ? value : defaultValue;
        }
    }
}
