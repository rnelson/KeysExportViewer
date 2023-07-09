KeysExport Viewer
=================

About
-----
KeysExport Viewer is a viewer for the KeysExport.xml file available to MSDN 
subscribers. This file contains all of the serial numbers that they have 
generated or that have been generated for
them.

It's very easy to download new versions of this file, but I'd rather not 
have to read through a bunch of XML if I'm trying to grab the right key to 
use on an install. At the time I created this project, this was also a 
great way to learn some new-to-me .NET development.

A huge thank you to [all those who have contributed](https://github.com/rnelson/KeysExportViewer/blob/master/CONTRIBUTORS.md) 
to the project, helping keep it alive and useful to developers.

Features
--------
* Displays each serial number for product keys
* Displays HTML data where present in place of serial numbers
* Allows you to filter the list, showing just the entries you are looking for

Future Goals
------------
Prior to writing KeysExport Viewer, I just tossed generated keys into a 
text  file. The advantage this had over parsing the XML is that I could 
add notes, documenting things like which VM a specific serial number was 
used in.

"Someday" I want to build a way to add additional notes like that. Perhaps 
a zip file (with some custom extension) that contains a SQLite database 
and the most recently provided XML file?

License
-------
This program is licensed under the [MIT license][license].

[license]: https://rnelson.mit-license.org/