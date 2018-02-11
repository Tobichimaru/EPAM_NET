using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IoCContainer
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _mapper;

        public Container()
        {
            _mapper = new Dictionary<Type, Type>();
        }

        public void AddAssembly(Assembly assembly)
        {
            if (assembly == null)
                throw new NullReferenceException("Assembly could not be null");

            var types = assembly.ExportedTypes.Where(t => t.IsClass || t.IsInterface);
            foreach (var type in types)
            {
                var export = type.GetCustomAttribute<ExportAttribute>();
                if (export == null) continue;
                Register(export.ExportType ?? type, type);
            }
        }

        public void Register<TKey, TValue>()
        {
            _mapper.Add(typeof(TKey), typeof(TValue));
        }

        public void Register(Type type, Type baseType)
        {
            _mapper.Add(type, baseType);
        }

        public void AddType(Type type)
        {
            AddType(type, type);
        }

        public void AddType(Type targetType, Type sourceType)
        {
            Register(sourceType, targetType);
        }

        public T Resolve<T>()
        {
            var instance = (T)Resolve(typeof(T));
            ResolveProperties(instance);
            return instance;
        }

        private object Resolve(Type type)
        {
            Type resolvedType;
            if (_mapper.TryGetValue(type, out resolvedType) == false)
            {
                Register(type, type);
                resolvedType = type;
            }
            var ctorInfo = resolvedType.GetConstructors().FirstOrDefault();

            if (ctorInfo == null) return Activator.CreateInstance(resolvedType);

            var parameters = ctorInfo.GetParameters();
            return parameters.Any() ? ctorInfo.Invoke(ResolveParameters(parameters).ToArray()) : Activator.CreateInstance(resolvedType);
        }

        private IEnumerable<object> ResolveParameters(IEnumerable<ParameterInfo> parameters)
        {
            return parameters.Select(p => Resolve(p.ParameterType)).ToList();
        }

        private void ResolveProperties(object instance)
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                if (property.IsDefined(typeof(ImportAttribute)))
                {
                    property.SetValue(instance, Resolve(property.PropertyType));
                }
            }
        }
    }
}
