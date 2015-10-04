
using System;
using System.Linq.Expressions;

namespace Generics
{
    public static class GenericsFactory
    {
        public static T New<T>()
        {
            var ctor = Cache<T>.Func;
            return ctor();
        }

        public static T New<TArg1, T>(TArg1 arg1)
        {
            var ctor = Cache<T, TArg1>.Func;
            return ctor(arg1);
        }

        public static T New<TArg1, TArg2, T>(TArg1 arg1, TArg2 arg2)
        {
            var ctor = Cache<T, TArg1, TArg2>.Func;
            return ctor(arg1, arg2);
        }

        public static T New<TArg1, TArg2, TArg3, T>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            var ctor = Cache<T, TArg1, TArg2, TArg3>.Func;
            return ctor(arg1, arg2, arg3);
        }

        public static T New<TArg1, TArg2, TArg3, TArg4, T>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        {
            var ctor = Cache<T, TArg1, TArg2, TArg3, TArg4>.Func;
            return ctor(arg1, arg2, arg3, arg4);
        }

        public static T New<TArg1, TArg2, TArg3, TArg4, TArg5, T>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        {
            var ctor = Cache<T, TArg1, TArg2, TArg3, TArg4, TArg5>.Func;
            return ctor(arg1, arg2, arg3, arg4, arg5);
        }

        private static Delegate CreateConstructor(Type type, params Type[] args)
        {
            if (type == null) throw new ArgumentNullException("type");
            if (args == null) args = Type.EmptyTypes;

            // Converts the arguments to an array of expression parameters
            var parameters = Array.ConvertAll(args, Expression.Parameter);

            // Creates an expression that represent calling the constructor
            var expression = Expression.Lambda(Expression.New(type.GetConstructor(args), parameters), parameters);

            var result = expression.Compile(); // Compiles the expression
            return result;
        }

        private static class Cache<T>
        {
            public static readonly Func<T> Func = (Func<T>)CreateConstructor(typeof(T));
        }

        private static class Cache<T, TArg1>
        {
            public static readonly Func<TArg1, T> Func = (Func<TArg1, T>)CreateConstructor(typeof(T), typeof(TArg1));
        }

        private static class Cache<T, TArg1, TArg2>
        {
            public static readonly Func<TArg1, TArg2, T> Func = (Func<TArg1, TArg2, T>)CreateConstructor(typeof(T), typeof(TArg1), typeof(TArg2));
        }

        private static class Cache<T, TArg1, TArg2, TArg3>
        {
            public static readonly Func<TArg1, TArg2, TArg3, T> Func = (Func<TArg1, TArg2, TArg3, T>)CreateConstructor(typeof(T), typeof(TArg1), typeof(TArg2), typeof(TArg3));
        }

        private static class Cache<T, TArg1, TArg2, TArg3, TArg4>
        {
            public static readonly Func<TArg1, TArg2, TArg3, TArg4, T> Func = (Func<TArg1, TArg2, TArg3, TArg4, T>)CreateConstructor(typeof(T), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4));
        }

        private static class Cache<T, TArg1, TArg2, TArg3, TArg4, TArg5>
        {
            public static readonly Func<TArg1, TArg2, TArg3, TArg4, TArg5, T> Func = (Func<TArg1, TArg2, TArg3, TArg4, TArg5, T>)CreateConstructor(typeof(T), typeof(TArg1), typeof(TArg2), typeof(TArg3), typeof(TArg4), typeof(TArg5));
        }
    }
}
