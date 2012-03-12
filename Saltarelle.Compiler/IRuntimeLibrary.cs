﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.NRefactory.TypeSystem;
using Saltarelle.Compiler.JSModel.Expressions;

namespace Saltarelle.Compiler {
	public interface IRuntimeLibrary {
		/// <summary>
		/// Returns an expression that determines if an expression is of a type (equivalent to C# "is").
		/// </summary>
		JsExpression TypeIs(JsExpression expression, JsExpression targetType);

		/// <summary>
		/// Returns an expression that casts an expression to a specified type, or returns null if the expression is not of that type (equivalent to C# "as").
		/// </summary>
		JsExpression TryCast(JsExpression expression, JsExpression targetType);

		/// <summary>
		/// Returns an expression that casts an expression to a specified type, or throws an exception if the expression is not of that type (equivalent to C# "(Type)expression").
		/// </summary>
		JsExpression Cast(JsExpression expression, JsExpression targetType);

		/// <summary>
		/// Returns an expression that performs an implicit reference conversion (equivalent to (IList)list, where list is a List).
		/// </summary>
		JsExpression ImplicitReferenceConversion(JsExpression expression, JsExpression targetType);

		/// <summary>
		/// Returns an expression that will instantiate a generic type.
		/// </summary>
		JsExpression InstantiateGenericType(JsExpression type, IEnumerable<JsExpression> typeArguments);

		/// <summary>
		/// Returns an expression that will instantiate a generic method.
		/// </summary>
		JsExpression InstantiateGenericMethod(JsExpression method, IEnumerable<JsExpression> typeArguments);

		/// <summary>
		/// Returns an expression that will convert a given expression to an exception. This is used to be able to throw a JS string and catch it as an Exception.
		/// </summary>
		JsExpression MakeException(JsExpression operand);

		/// <summary>
		/// Returns an expression that will perform integer division.
		/// </summary>
		JsExpression IntegerDivision(JsExpression numerator, JsExpression denominator);

		/// <summary>
		/// Returns an expression that will perform null coalesce (C#: a ?? b).
		/// </summary>
		JsExpression Coalesce(JsExpression a, JsExpression b);

		/// <summary>
		/// Generates a lifted version of an expression.
		/// </summary>
		/// <param name="expression">Expression to lift. This will always be an invocation, or a (unary or binary) operator.</param>
		JsExpression Lift(JsExpression expression);

		/// <summary>
		/// Generates a call to the lifted boolean &amp; operator, which has the same semantics as the SQL AND operator.
		/// </summary>
		JsExpression LiftedBooleanAnd(JsExpression a, JsExpression b);

		/// <summary>
		/// Generates a call to the lifted boolean | operator, which has the same semantics as the SQL OR operator.
		/// </summary>
		JsExpression LiftedBooleanOr(JsExpression a, JsExpression b);

		/// <summary>
		/// Bind a function to a target that will become "this" inside the function.
		/// </summary>
		JsExpression Bind(JsExpression function, JsExpression target);
	}
}