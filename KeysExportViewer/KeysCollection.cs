using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace KeysExportViewer;

[SuppressMessage("ReSharper", "HeapView.ObjectAllocation.Possible")]
[SuppressMessage("ReSharper", "HeapView.ClosureAllocation")]
internal class KeysCollection
{
	#region Data Members
	/// <summary>
	/// The keys
	/// </summary>
	private readonly IDictionary<string, MsdnKey> _keys = new Dictionary<string, MsdnKey>();
	#endregion Data Members

	#region Properties
	/// <summary>
	/// Gets the keys.
	/// </summary>
	/// <value>The keys.</value>
	public IReadOnlyDictionary<string, MsdnKey> Keys => new ReadOnlyDictionary<string, MsdnKey>(_keys);
	#endregion Properties

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="KeysCollection"/> class.
	/// </summary>
	/// <param name="filename">The filename.</param>
	public KeysCollection(string filename)
	{
		Load(filename);
	}
	#endregion Constructors

	#region Private Methods
	/// <summary>
	/// Loads the specified filename.
	/// </summary>
	/// <param name="filename">The filename.</param>
	[SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.Int32.Parse(System.String)")]
	private void Load(string filename)
	{
		if (!File.Exists(filename))
		{
			throw new FileNotFoundException("File not found", filename);
		}

		// Get rid of the existing set of keys
		_keys.Clear();

		// Load the document
		var doc = XDocument.Load(filename);
		var keyNodes = from productKey in doc.Descendants("YourKey").Elements("Product_Key")
			let key = productKey.Element("Key")
			where int.Parse((string)key.Attribute("ID"), CultureInfo.InvariantCulture) != -3
			select new
			{
				Name = (string)productKey.Attribute("Name"),
				Id = int.Parse((string)key.Attribute("ID")),
				KeyText = key.Value,
				Keys = productKey.Elements("Key")
			};

		foreach (var keyNode in keyNodes)
		{
			// Convert the anonymous object to an MsdnKey object
			var key = new MsdnKey {Name = keyNode.Name, Id = keyNode.Id, KeyText = keyNode.KeyText};

			// If this is an actual key (versus some CDATA in HTML), add each key
			if (key.HasKey)
			{
				foreach (var indKey in keyNode.Keys)
				{
					var ik = new MsdnKey.IndividualKey
					{
						ClaimedDate = MsdnKey.TryParseDateTime((string) indKey.Attribute("ClaimedDate")),
						KeyType = (string) indKey.Attribute("Type"),
						Key = indKey.Value,
						Note = (string)indKey.Attribute("notes")
					};

					key.AddKey(ik);
				}
			}

			// If the product already exists, add the new keys to it
			if (_keys.TryGetValue(key.Name, out var msdnKey))
			{
				foreach (var individualKey in key.Keys)
				{
					if(msdnKey.Keys.All(k => k.Key != individualKey.Key))
						msdnKey.AddKey(individualKey);
				}
			}
			else
			{
				// Add the new product and its keys
				_keys.Add(key.Name, key);
			}
		}
	}
	#endregion Private Methods
}