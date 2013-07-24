using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace KeysExportViewer
{
	class KeysCollection
	{
		#region Data Members
		/// <summary>
		/// The keys
		/// </summary>
		private IDictionary<Guid, MsdnKey> _keys;
		#endregion Data Members

		#region Properties
		/// <summary>
		/// Gets the keys.
		/// </summary>
		/// <value>The keys.</value>
		public IReadOnlyDictionary<Guid, MsdnKey> Keys
		{
			get { return new ReadOnlyDictionary<Guid, MsdnKey>(this._keys); }
		}
		#endregion Properties

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="KeysCollection"/> class.
		/// </summary>
		public KeysCollection()
		{
			this._keys = new Dictionary<Guid, MsdnKey>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KeysCollection"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public KeysCollection(string filename)
		{
			this._keys = new Dictionary<Guid, MsdnKey>();
			this.Load(filename);
		}
		#endregion Constructors

		#region Public Methods
		/// <summary>
		/// Loads the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.Parse(System.String)")]
		public void Load(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException("File not found", filename);
			}

			// Get rid of the existing set of keys
			this._keys = new Dictionary<Guid, MsdnKey>();

			// Load the document
			XDocument doc = XDocument.Load(filename);
			var keyNodes = from productKey in doc.Element("YourKey").Elements("Product_Key")
				let key = productKey.Element("Key")
				where (int)int.Parse((string)key.Attribute("ID"), CultureInfo.InvariantCulture) != -3
				select new
				{
					Name = (string)productKey.Attribute("Name"),
					Id = int.Parse((string)key.Attribute("ID")),
					KeyText = (string)key.Value,
					Keys = productKey.Elements("Key")
				};

			foreach (var keyNode in keyNodes)
			{
				// Convert the anonymous object to an MsdnKey object
				MsdnKey key = new MsdnKey();
				key.Name = keyNode.Name;
				key.Id = keyNode.Id;
				key.KeyText = keyNode.KeyText;

				// If this is an actual key (versus some CDATA'd HTML), add each key
				if (key.HasKey)
				{
					foreach (XElement indKey in keyNode.Keys)
					{
						MsdnKey.IndividualKey ik = new MsdnKey.IndividualKey();
						ik.ClaimedDate = MsdnKey.TryParseDateTime((string)indKey.Attribute("ClaimedDate"));
						ik.KeyType = (string)indKey.Attribute("Type");
						ik.Key = (string)indKey.Value;

						key.AddKey(ik);
					}
				}

				this._keys.Add(Guid.NewGuid(), key);
			}
		}
		#endregion Public Methods
	}
}
