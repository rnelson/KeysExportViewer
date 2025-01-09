using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace KeysExportViewer;

/// <summary>
/// Class MsdnKey
/// </summary>
[SuppressMessage("ReSharper", "PropertyCanBeMadeInitOnly.Global")]
internal class MsdnKey
{
	/// <summary>
	/// Class IndividualKey
	/// </summary>
	public class IndividualKey
	{
		#region Properties
		/// <summary>
		/// Gets or sets the claimed date.
		/// </summary>
		/// <value>The claimed date.</value>
		public DateTime? ClaimedDate { get; set; }

		/// <summary>
		/// Gets or sets the type of the key.
		/// </summary>
		/// <value>The type of the key.</value>
		public string KeyType { get; set; }

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		public string Note { get; set; }
		#endregion Properties

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="IndividualKey"/> class.
		/// </summary>
		public IndividualKey()
		{
			ClaimedDate = TryParseDateTime(null);
			KeyType = string.Empty;
			Key = string.Empty;
			Note = string.Empty;
		}
		#endregion Constructors
	}

	#region Data Members
	private readonly List<IndividualKey> _keys;
	#endregion Data Members

	#region Properties
	/// <summary>
	/// Gets the keys.
	/// </summary>
	/// <value>The keys.</value>
	public IEnumerable<IndividualKey> Keys => _keys;

	/// <summary>
	/// Gets or sets the name.
	/// </summary>
	/// <value>The name.</value>
	public string Name { get; set; }

	/// <summary>
	/// Gets or sets the id.
	/// </summary>
	/// <value>The id.</value>
	public int Id { get; set; }

	/// <summary>
	/// Gets or sets the CDATA.
	/// </summary>
	/// <value>The CDATA.</value>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public string CDATA { get; private set; }

	/// <summary>
	/// Gets or sets a value indicating whether this instance has key.
	/// </summary>
	/// <value><c>true</c> if this instance has key; otherwise, <c>false</c>.</value>
	public bool HasKey { get; private set; }

	/// <summary>
	/// Sets the key text.
	/// </summary>
	/// <value>The key text.</value>
	public string KeyText
	{
		set
		{
			if (string.IsNullOrEmpty(value))
				return;
				
			if (value.Contains('<', StringComparison.InvariantCultureIgnoreCase))
			{
				CDATA = value;
				HasKey = false;
			}
			else
			{
				HasKey = true;
			}
		}
	}
	#endregion Properties

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="MsdnKey"/> class.
	/// </summary>
	public MsdnKey()
	{
		_keys = [];
		Name = string.Empty;
		Id = -1;
		CDATA = string.Empty;
		HasKey = true;
	}
	#endregion Constructors

	#region Public Methods
	/// <summary>
	/// Adds the key.
	/// </summary>
	/// <param name="key">The key.</param>
	public void AddKey(IndividualKey key)
	{
		_keys.Add(key);
	}

	/// <summary>
	/// Tries the parse date/time.
	/// </summary>
	/// <param name="input">The input.</param>
	/// <returns>DateTime.</returns>
	public static DateTime? TryParseDateTime(string input)
	{
		if (string.IsNullOrEmpty(input))
			return null;

		if (DateTime.TryParse(input, out var dt))
		{
			return dt;
		}

		return null;
	}
	#endregion Public Methods
}