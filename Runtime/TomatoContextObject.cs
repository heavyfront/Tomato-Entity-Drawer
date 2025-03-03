using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TomatoEntityDrawer
{
    public class TomatoContextObject : MonoBehaviour
    {
        private const string Suffix = "Component";

        private BaseContext _context;
        private List<Type> _components = new();
        private Dictionary<string, Type> _componentsMap = new();

        public BaseContext Context => _context;
        public List<Type> Components => _components;
        public Dictionary<string, Type> ComponentsMap => _componentsMap;

        public void Initialize(BaseContext context)
        {
            _context = context;
        }

        private void Awake()
        {
            Type interfaceType = typeof(ITomatoComponent);
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    Type[] allTypes = assembly.GetTypes();
                    var implementingTypes = allTypes.Where(t =>
                        interfaceType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                    _components.AddRange(implementingTypes);
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Debug.LogError("Ошибка при загрузке типов: " + ex.Message);
                }
            }

            _components = _components.OrderBy(item => item.Name).ToList();

            foreach (var type in _components)
            {
                var name = RemoveSuffix(type.Name);
                _componentsMap[name] = type;
            }
        }

        public string RemoveSuffix(string input)
        {
            if (input.EndsWith(Suffix))
            {
                return input.Substring(0, input.Length - Suffix.Length);
            }

            return input; // Возвращаем оригинальную строку, если суффикс не найден
        }
    }
}