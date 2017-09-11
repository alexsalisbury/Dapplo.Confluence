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

using System.Runtime.Serialization;

#endregion

namespace Dapplo.Confluence.Entities
{
	/// <summary>
	///     Metadata information, used in attachment
	///     See: https://docs.atlassian.com/confluence/REST/latest
	/// </summary>
	[DataContract]
	public class AttachmentMetadata
	{
		/// <summary>
		///     A comment for the attachment
		/// </summary>
		[DataMember(Name = "comment", EmitDefaultValue = false)]
		public string Comment { get; set; }

		/// <summary>
		///     Type of media (content-type)
		/// </summary>
		[DataMember(Name = "mediaType", EmitDefaultValue = false)]
		public string MediaType { get; set; }
    }

    /// <summary>
    ///     Metadata information, used in attachment
    ///     See: https://docs.atlassian.com/confluence/REST/latest
    /// </summary>
    [DataContract]
    public class ContentMetadata
    {
        /// <summary>
        ///     A comment for the attachment
        /// </summary>
        [DataMember(Name = "labels", EmitDefaultValue = false)]
        public Result<Labels<long>> Labels { get; set; }
    }
}