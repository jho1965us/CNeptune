﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Runtime.CompilerServices;
using Mono;
using Mono.Cecil;


namespace Mono.Cecil
{
    static internal class __TypeDefinition
    {
        static public FieldDefinition Field(this TypeDefinition type, string name, FieldAttributes attributes, TypeReference @return)
        {
            var _field = new FieldDefinition(name, attributes, @return);
            type.Fields.Add(_field);
            _field.Attribute<CompilerGeneratedAttribute>();
            return _field;
        }

        static public FieldDefinition Field(this TypeDefinition type, string name, FieldAttributes attributes, Type @return)
        {
            var _field = new FieldDefinition(name, attributes, type.Module.Import(@return));
            type.Fields.Add(_field);
            _field.Attribute<CompilerGeneratedAttribute>();
            return _field;
        }

        static public FieldDefinition Field<T>(this TypeDefinition type, string name, FieldAttributes attributes)
        {
            var _field = new FieldDefinition(name, attributes, type.Module.Import(typeof(T)));
            type.Fields.Add(_field);
            _field.Attribute<CompilerGeneratedAttribute>();
            return _field;
        }

        static public MethodDefinition Method(this TypeDefinition type, string name, MethodAttributes attributes, TypeReference @return)
        {
            var _method = new MethodDefinition(name, attributes, @return);
            type.Methods.Add(_method);
            _method.Attribute<CompilerGeneratedAttribute>();
            return _method;
        }

        static public MethodDefinition Method(this TypeDefinition type, string name, MethodAttributes attributes, Type @return)
        {
            var _method = new MethodDefinition(name, attributes, type.Module.Import(@return));
            type.Methods.Add(_method);
            _method.Attribute<CompilerGeneratedAttribute>();
            return _method;
        }

        static public MethodDefinition Method<T>(this TypeDefinition type, string name, MethodAttributes attributes)
        {
            var _method = new MethodDefinition(name, attributes, type.Module.Import(typeof(T)));
            type.Methods.Add(_method);
            _method.Attribute<CompilerGeneratedAttribute>();
            return _method;
        }

        static public TypeDefinition Type(this TypeDefinition type, string name, TypeAttributes attributes)
        {
            var _type = new TypeDefinition(null, name, attributes, type.Module.TypeSystem.Object);
            type.NestedTypes.Add(_type);
            _type.Attribute<CompilerGeneratedAttribute>();
            return _type;
        }

        static public CustomAttribute Attribute<T>(this TypeDefinition type)
            where T : Attribute
        {
            var _attribute = new CustomAttribute(type.Module.Import(typeof(T).GetConstructor(System.Type.EmptyTypes)));
            type.CustomAttributes.Add(_attribute);
            return _attribute;
        }

        static public CustomAttribute Attribute<T>(this TypeDefinition type, Expression<Func<T>> expression)
            where T : Attribute
        {
            var _constructor = (expression.Body as NewExpression).Constructor;
            var _attribute = new CustomAttribute(type.Module.Import(_constructor));
            foreach (var _argument in (expression.Body as NewExpression).Arguments) { _attribute.ConstructorArguments.Add(new CustomAttributeArgument(type.Module.Import(_argument.Type), (_argument as ConstantExpression).Value)); }
            type.CustomAttributes.Add(_attribute);
            return _attribute;
        }

        static public MethodDefinition Constructor(this TypeDefinition type)
        {
            var _method = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName, type.Module.TypeSystem.Void);
            type.Methods.Add(_method);
            _method.Attribute<CompilerGeneratedAttribute>();
            return _method;
        }

        static public MethodDefinition Initializer(this TypeDefinition type)
        {
            var _method = new MethodDefinition(".cctor", MethodAttributes.Static | MethodAttributes.Assembly | MethodAttributes.HideBySig | MethodAttributes.SpecialName, type.Module.TypeSystem.Void);
            type.Methods.Add(_method);
            _method.Attribute<CompilerGeneratedAttribute>();
            return _method;
        }
    }
}