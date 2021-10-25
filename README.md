This tool allows to automatically parse a certain message flow from provided log files sets or clipboard data.

A convenient WinForms UI provides easy setup for the report data.

There are two modes of operation: automatic (for input containing a set of files), and manual (for clipboard input).

Log file sets can be multiple tracing files from multiple components.
Specifics for each trace file set are provided via configuration files and regular expressions.
The messages are parsed for timestamp and other fields like Call-ID according to provided configuration files (regular expressions are used).

A final all-in-one HTML report is generated with all parsed messages put into a table, sorted by a timestamp. 

The technique used is serialization of parsed messages and then XSL conversion to a readable HTML.
Messages are placed in a sequential order.
There is one column in report table per each component involved.

Prior to report generation, a user can set up several filters: by date and time, by Call-ID, and other fields.

After a report generation, user is provided with a link to this newly generated report, which he can open in a browser.
A generated report supports fold/unfold functionality for each message and for all messages (Fold / Unfold All button).

See README.pdf for more information.

NOTE:
This application can be compiled and run under Linux.
Follow these steps:
- install mono package for your linux
- go to the project directory and compile the app:
xbuild /p:Configuration=Release ParseTHSMsg.csproj
- to run the tool after compilation:
mono bin/Release/ParseTHSMsg.exe