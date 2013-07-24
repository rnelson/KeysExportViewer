using System;
using System.Collections.Generic;

namespace KeysExportViewer
{
	/// <summary>
	/// Class MsdnKey
	/// </summary>
	class MsdnKey
	{
		/// <summary>
		/// Class IndividualKey
		/// </summary>
		public class IndividualKey
		{
			#region Data Members
			private DateTime? _claimedDate;
			private string _keyType;
			private string _key;
			#endregion Data Members

			#region Properties

			/// <summary>
			/// Gets or sets the claimed date.
			/// </summary>
			/// <value>The claimed date.</value>
			public DateTime? ClaimedDate
			{
				get { return this._claimedDate; }
				set { this._claimedDate = value; }
			}

			/// <summary>
			/// Gets or sets the type of the key.
			/// </summary>
			/// <value>The type of the key.</value>
			public string KeyType
			{
				get { return this._keyType; }
				set { this._keyType = value; }
			}

			/// <summary>
			/// Gets or sets the key.
			/// </summary>
			/// <value>The key.</value>
			public string Key
			{
				get { return this._key; }
				set { this._key = value; }
			}
			#endregion Properties

			#region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="IndividualKey"/> class.
			/// </summary>
			public IndividualKey()
			{
				this._claimedDate = MsdnKey.TryParseDateTime(null);
				this._keyType = string.Empty;
				this._key = string.Empty;
			}
			#endregion Constructors
		}

		#region Data Members
		private IList<IndividualKey> _keys;
		private string _name;
		private int _id;
		private string _cdata;
		private bool _hasKey;
		#endregion Data Members

		#region Properties
		/// <summary>
		/// Gets the keys.
		/// </summary>
		/// <value>The keys.</value>
		public IList<IndividualKey> Keys
		{
			get { return this._keys; }
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return this._name; }
			set { this._name = value; }
		}

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		/// <value>The id.</value>
		public int Id
		{
			get { return this._id; }
			set { this._id = value; }
		}

		/// <summary>
		/// Gets or sets the CDATA.
		/// </summary>
		/// <value>The CDATA.</value>
		public string CDATA
		{
			get { return this._cdata; }
			set { this._cdata = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether this instance has key.
		/// </summary>
		/// <value><c>true</c> if this instance has key; otherwise, <c>false</c>.</value>
		public bool HasKey
		{
			get { return this._hasKey; }
			set { this._hasKey = value; }
		}

		/// <summary>
		/// Sets the key text.
		/// </summary>
		/// <value>The key text.</value>
		public string KeyText
		{
			set
			{
				string text = (string)value;
				if (!string.IsNullOrEmpty(text))
				{
					if (text.Contains("<"))
					{
						this.CDATA = text; //.Trim().Substring(9, text.Trim().Length-2);
						this.HasKey = false;
					}
					else
					{
						this.HasKey = true;
					}
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
			this._keys = new List<IndividualKey>();
			this._name = string.Empty;
			this._id = -1;
			this._cdata = string.Empty;
			this._hasKey = true;
		}
		#endregion Constructors

		#region Public Methods
		/// <summary>
		/// Adds the key.
		/// </summary>
		/// <param name="key">The key.</param>
		public void AddKey(IndividualKey key)
		{
			this._keys.Add(key);
		}

		/// <summary>
		/// Tries the parse date/time.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns>DateTime.</returns>
		public static DateTime? TryParseDateTime(string input)
		{
			if (!string.IsNullOrEmpty(input))
			{
				DateTime dt;
				if (DateTime.TryParse(input, out dt))
				{
					return dt;
				}
			}

			return null;// new DateTime(1970, 1, 1, 0, 0, 0);
		}
		#endregion Public Methods
	}
}
