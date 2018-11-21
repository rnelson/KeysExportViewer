KeysExport Viewer
=================

About
-----
KeysExport Viewer, or KEV for short because I'm lazy, is a viewer for the
KeysExport.xml file available to MSDN subscribers. This file contains all of
the serial numbers that they have generated or that have been generated for
them.

It's very easy to download new versions of this file, but I'd rather not have
to read through a bunch of XML if I'm trying to grab the right key to use on
an install. Yes, I'm lazy. If it makes the situation any better, writing this
little application also let me learn a few new things about C# and .NET that I
hadn't had a chance to play with yet.

Features
--------
* Displays each serial number for product keys
* Displays HTML data where present in place of serial numbers

Future Goals
------------
The one disadvantage KEV has to my previous system of a text file where I
enter the keys I've used is that I can't make any notes in the document (and
if I do, they'll be overwritten when I update the file). My one and only goal
at the moment is to support adding comments, which will be saved to a separate
file to ensure they still exist if a new XML file is downloaded.

License
-------
This program is licensed under the [MIT license][license].

[license]: https://github.com/rnelson/KeysExportViewer/blob/master/LICENSE