﻿//  Dapplo - building blocks for desktop applications
//  Copyright (C) 2016 Dapplo
// 
//  For more information see: http://dapplo.net/
//  Dapplo repositories are hosted on GitHub: https://github.com/dapplo
// 
//  This file is part of Dapplo.Confluence
// 
//  Dapplo.Confluence is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  Dapplo.Confluence is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have a copy of the GNU Lesser General Public License
//  along with Dapplo.Confluence. If not, see <http://www.gnu.org/licenses/lgpl.txt>.

#region using

using System;
using System.Linq;

#endregion

namespace Dapplo.Confluence.Query
{
	/// <summary>
	///     An interface for a date time calculations clause
	/// </summary>
	public interface ISimpleValueClause
	{
		/// <summary>
		///     Negates the expression
		/// </summary>
		ISimpleValueClause Not { get; }

		/// <summary>
		///     This allows fluent constructs like Space.In("DEV", "PRODUCTION")
		/// </summary>
		IFinalClause In(params string[] values);

		/// <summary>
		///     This allows fluent constructs like Space.Is("DEV")
		/// </summary>
		IFinalClause Is(string value);
	}

	/// <summary>
	///     A clause for simple fields like container, macro and label
	/// </summary>
	internal class SimpleValueClause : ISimpleValueClause
	{
		private readonly Fields[] _allowedFields = {Fields.Container, Fields.Macro, Fields.Label};
		private readonly Clause _clause;

		private bool _negate;

		internal SimpleValueClause(Fields simpleField)
		{
			if (!_allowedFields.Any(field => simpleField == field))
			{
				throw new InvalidOperationException("Can't add function for the field {Field}");
			}
			_clause = new Clause
			{
				Field = simpleField
			};
		}


		/// <inheritDoc />
		public ISimpleValueClause Not
		{
			get
			{
				_negate = !_negate;
				return this;
			}
		}

		/// <inheritDoc />
		public IFinalClause Is(string value)
		{
			_clause.Operator = Operators.EqualTo;
			_clause.Value = $"\"{value}\"";
			if (_negate)
			{
				_clause.Negate();
			}
			return _clause;
		}

		/// <inheritDoc />
		public IFinalClause In(params string[] values)
		{
			_clause.Operator = Operators.In;
			_clause.Value = "(" + string.Join(", ", values.Select(user => $"\"{user}\"")) + ")";
			if (_negate)
			{
				_clause.Negate();
			}
			return _clause;
		}
	}
}