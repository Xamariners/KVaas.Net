About
=============================

The .Net Standard Key Value as a Service (KVaaS) is a library for using the online HTTP key-value store at https://keyvalue.xyz/ which has documentation at https://github.com/kvaas/docs for the web service API.

Features
========

* Simple API following the KVaaS HTTP API.
* HTTP Get/Post functionality is built into library.

License
===============================

This library is licensed under the Apache-2 License.

Usage
===============================

    string key = "testkey";
    string value = "testvalue";

	//get token
    var token = await KVaaSClient.NewKey(key);

    // set value
    var setValueResult = await KVaaSClient.PutValue(token, key, value);
    
    // get value
    var getValueResult = await KVaaSClient.GetValue(token, key);    
    

External Dependencies
=====================================
This library is self-contained. It does not depend on any additional libraries, only .Net Standard.