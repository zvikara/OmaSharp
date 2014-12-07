SharpOMA
========
The [Open Mobile Alliance](http://www.openmobilealliance.org) specifications implemetated in C#.

Original code forked from [wbxml.codeplex.com](http://wbxml.codeplex.com)

The current implementations are available:

WBXML
--------
Encoder and decoder for [WAP Binary XML](http://en.wikipedia.org/wiki/WBXML) messages.

The [WBXML specification](http://www.openmobilealliance.org/tech/affiliates/wap/wap-192-wbxml-20010725-a.pdf)
makes use of token pages for encoding and decoding from and to plain XML. 

Thanks to Tamir Khason for his ideas written in [his blog](http://khason.net/blog/wbxml-support-in-c-or-lets-make-it-smaller/) at [CodeProject](http://www.codeproject.com/Articles/21138/WBXML-Support-in-C-Handy)

WapProvisioning
---------------
Encoder and decoder for [WAP Client Provisioning](http://en.wikipedia.org/wiki/WBXML) messages.

SyncML
------
Data synchronization between mobile device and server based on the [SyncML specification](http://www.syncml.org),
